<template>
    <el-row style="position: relative;top:0;left:0;">
        <button @click="btn1(0)"><img src="../assets/Firstv.jpg" /></button>
        <div style="width:5px;"></div>
        <button @click="btn1(-1)"><img src="../assets/Previousv.jpg" /></button>
        <div style="width:5px;"></div>
        <button @click="btn1(1)"><img src="../assets/Nextv.jpg" /></button>
        <div style="width:5px;"></div>
        <button @click="btn1(99)"><img src="../assets/Lastv.jpg" /></button>
        <div style="width:40px;"></div>
        <button @click="btn1(0)"><img src="../assets/Addv.jpg" /></button>
        <div style="width:5px;"></div>
        <button @click="btn1(0)"><img src="../assets/Editv.jpg" /></button>
        <div style="width:5px;"></div>
        <button @click="btn1(0)"><img src="../assets/Deletev.jpg" /></button>
        <div style="width:10px;"></div>
        <button @click="btn1(0)"><img src="../assets/Queryv.jpg" /></button>
        <div style="width:5px;"></div>
        <button @click="btn1(0)"><img src="../assets/Okv.jpg" /></button>
        <div style="width:5px;"></div>
        <button @click="btn1(0)"><img src="../assets/Cancelv.jpg" /></button>
        <div style="width:5px;"></div>
        <button @click="btn1(0)"><img src="../assets/Quitv.jpg" /></button>
    </el-row>
    <div style="width:100%;height:70vh">
        <el-row>
            <el-col :span="2">
                <el-table :data="slist1" key="allid" height="520" style="width:100%" highlight-current-row ref="wt1"
                    id="wt1" @cell-click="btn2">
                    <el-table-column prop="allid" label="allid" width=100 />
                </el-table>
            </el-col>
            <el-col :span="22">
                <div style="height:40px">
                    <div style="font-size:36px">
                        {{ npt + 1 }}
                    </div>
                </div>
                <el-tabs v-model="tab" type="card" class="demo-tabs">
                    <el-tab-pane label="A.Expense in TWD" name="tab1">
                        <el-table :data="lista" key="sec" height="420" highlight-current-row ref="wt11" id="wt11">
                            <el-table-column prop="sec" label="No" width="60" />
                            <el-table-column prop="desc" label="Descrip" width="400" />
                            <el-table-column prop="unit" label="Unit" width="100" />
                            <el-table-column prop="qty" label="Qty" width="100" />
                        </el-table>
                    </el-tab-pane>
                    <el-tab-pane label="B.Accomondation" name="tab2">
                        <el-table :data="listb" key="sec" height="420" highlight-current-row ref="wt12" id="wt12">
                            <el-table-column prop="sec" label="day" width="60" />
                            <el-table-column prop="Location" label="Location" width="200" />
                            <el-table-column prop="Cat" label="Cat" width="60" />
                            <el-table-column prop="htname" label="Hotail Name" width="200" />
                            <el-table-column prop="nts" label="NTS" width="60" />
                            <el-table-column prop="twn" label="1/2TWN" width="100" />
                            <el-table-column prop="sgl" label="SGL" width="60" />
                            <el-table-column prop="tax" label="TAX" width="60" />
                            <el-table-column prop="hb" label="HB" width="100" />
                            <el-table-column prop="ptr" label="PTR" width="100" />
                            <el-table-column prop="ttl" label="TTL of SGL" width="100" />
                        </el-table>
                    </el-tab-pane>
                    <el-tab-pane label="C.Transportation" name="tab3">
                        <el-table :data="listc" key="sec" height="420" highlight-current-row ref="wt13" id="wt13">
                            <el-table-column prop="sec" label="day" width="60" />
                            <el-table-column prop="location" label="Location" width="200" />
                            <el-table-column prop="cat" label="Cat" width="60" />
                            <el-table-column prop="type" label="Type" width="200" />
                            <el-table-column prop="unit" label="Unit" width="100" />
                            <el-table-column prop="qty" label="Qty" width="100" />
                        </el-table>
                    </el-tab-pane>
                    <el-tab-pane label="D.Meal allowence" name="tab4">
                        <el-table :data="listd" key="sec" height="420" highlight-current-row ref="wt14" id="wt14">
                            <el-table-column prop="sec" label="day" width="60" />
                            <el-table-column prop="location" label="Location" width="200" />
                            <el-table-column prop="type" label="Type" width="200" />
                            <el-table-column prop="unit" label="Unit" width="100" />
                            <el-table-column prop="qty" label="Qty" width="100" />
                        </el-table>
                    </el-tab-pane>
                    <el-tab-pane label="E.Entrance" name="tab5">
                        <el-table :data="liste" key="sec" height="420" highlight-current-row ref="wt15" id="wt15">
                            <el-table-column prop="sec" label="day" width="60" />
                            <el-table-column prop="location" label="Location" width="200" />
                            <el-table-column prop="service" label="Service" width="200" />
                            <el-table-column prop="unit" label="Unit" width="100" />
                            <el-table-column prop="qty" label="Qty" width="100" />
                        </el-table>
                    </el-tab-pane>
                    <el-tab-pane label="Guide & General Expense & LOCAL" name="tab6">
                        <el-table :data="listf" key="sec" height="420" highlight-current-row ref="wt16" id="wt16">
                            <el-table-column prop="sec" label="day" width="60" />
                            <el-table-column prop="location" label="Location" width="200" />
                            <el-table-column prop="service" label="Service" width="200" />
                            <el-table-column prop="unit" label="Unit" width="100" />
                            <el-table-column prop="qty" label="Qty" width="100" />
                        </el-table>
                    </el-tab-pane>
                </el-tabs>
            </el-col>
        </el-row>
    </div>
</template>
<script>
import { defineComponent, ref } from 'vue';

export default defineComponent({
    name: "TestPic",
    data() {
        return {
            slist1: [],
            lista: [],
            listb: [],
            listc: [],
            listd: [],
            liste: [],
            listf: [],
            npt: 0,
            nlpt: 0,
            onpt: 0,
            nwt1: 1,
            nwt2: 11,
            tab: "tab1",
        };
    },
    methods: {
        //只限el-table
        //el-table one row height 40 但是el-row高最低為35px,row height是抓經驗值40px
        //這裡設定el-table height=520 有title title也算1row
        //(520-40)/40=480/40=12
        btn1(nn) {
            //上下界指會發生在button click
            let n1 = 0;
            let n2 = 0;
            let n3 = 30;
            if (nn == 0) {
                this.npt = 0;
                this.nwt1 = 0;
                this.nwt2 = this.nwt1 + 11;
            }
            if (nn == -1) {
                n1 = this.npt - 1;
                if (n1 < 0) { this.npt = 0; }
                else { this.npt = n1; }
            }
            if (nn == 1) {
                n1 = this.npt + 1;
                if (n1 > 99) { n1 = 99; }
                else { this.npt = n1; }
            }
            if (nn == 99) {
                n1 = 99;
                this.npt = 99;
                this.nwt2 = 99;
                this.nwt1 = this.nwt2 - 11;
            }
            this.$nextTick(() => {
                //el-table row min height 35px set 40px                    
                n1 = this.npt;
                n2 = n1 * 40;
                if ((nn == 0) | (nn == 99)) {
                    this.$refs.wt1.scrollTo(0, n2);
                }
                if (nn == -1) {
                    if (this.npt < this.nwt1) {
                        this.nwt1 = this.npt;
                        this.nwt2 = this.nwt1 + 11;
                        this.$refs.wt1.scrollTo(0, this.nwt1 * 40);
                    }
                }
                if (nn == 1) {
                    if (this.npt > this.nwt2) {
                        this.nwt1 = this.npt - 11;
                        this.nwt2 = this.npt;
                        this.$refs.wt1.scrollTo(0, this.nwt1 * 40);
                    }
                }
                this.$refs.wt1.setCurrentRow(this.slist1[this.npt]);
            });
            document.getElementById("wt1").focus();
        },
        btn2(row, column, cell, event) {
            //取出cell值
            let s1 = "";
            let s2 = "<!---->";
            s1 = cell.innerHTML;
            let n1 = 0;
            n1 = s1.indexOf(s2);
            s1 = s1.substring(n1 + 7);
            s2 = "</div>"
            n1 = s1.indexOf(s2);
            s1 = s1.substring(0, n1);
            this.npt = parseInt(s1) - 1;
        },
        crtdata() {
            let j1 = {};
            let n1 = 1;
            let n2 = 100;
            while (n1 <= n2) {
                j1 = { 'allid': n1, 'pname': 'a' + n1.toString() };
                this.slist1.push(j1);
                n1++;
            }
            j1 = { 'sec': 0, 'desc': '', 'unit': '', 'qty': 0 }
            this.lista.push(j1);
            j1 = { 'sec': 0, 'location': '', 'cat': '', 'htname': '', 'nts': 0, 'twn': 0, 'sgl': 0, 'tax': 0, 'hb': 0, 'ptr': 0, 'ttl': 0 };
            this.listb.push(j1);
            j1 = { 'sec': 0, 'location': '', 'cat': '', 'type': '', 'unit': '', 'qty': 0 };
            this.listc.push(j1);
            j1 = { 'sec': 0, 'location': '', 'type': '', 'unit': '', 'qty': 0 };
            this.listd.push(j1);
            j1 = { 'sec': 0, 'location': '', 'service': '', 'unit': '', 'qty': 0 };
            this.liste.push(j1);
            j1 = { 'sec': 0, 'location': '', 'service': '', 'unit': '', 'qty': 0 };
            this.listf.push(j1);
        },
    },
    mounted() {
        //let el = document.getElementById("wt1");
        //el.focus();
    },
    created() {
        this.crtdata();
    },
});
</script>
