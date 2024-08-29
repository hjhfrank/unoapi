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
                <el-table :data="slist1" key="allid" height="520" highlight-current-row ref="wt1" id="wt1"
                    @cell-click="btn2">
                    <el-table-column prop="allid" label="allid" style="width:100px" />
                </el-table>
            </el-col>
            <el-col :span="12">
                <div style="height:40px">
                    <div style="font-size:36px">
                        {{ npt + 1 }}
                    </div>
                </div>
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
            npt: 0,
        };
    },
    methods: {
        btn1(nn) {
            let n1 = 0;
            let n2 = 0;
            let n3 = 30;
            if (nn == 0) { n1 = 0; }
            if (nn == -1) {
                n1 = this.npt - 1;
                if (n1 < 0) { n1 = 0; }
            }
            if (nn == 1) {
                n1 = this.npt + 1;
                if (n1 > 99) { n1 = 99; }
            }
            if (nn == 99) {
                n1 = 99;
            }
            this.$nextTick(() => {
                //el-table row min height 35px set 40px
                this.npt = n1;
                n3 = n1 * 40;
                this.$refs.wt1.scrollTo(0, n3);
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
            this.npt = parseInt(s1)-1;
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
        },
    },
    mounted() {
        let el = document.getElementById("wt1");
        focus();
    },
    created() {
        this.crtdata();
    },
});
</script>
