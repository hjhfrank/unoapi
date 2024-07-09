<template>
  <div style="height: 70px; width: 100%">
    <el-button id="btn01" @click="test01('01')" style="width: 50px; height: 50px; left: 10px" v-bind:disabled="status">
      <img src="@/assets/Firstv.jpg" />
    </el-button>
    <el-button id="btn02" @click="test01('02')" style="width: 50px; height: 50px; left: 10px" v-bind:disabled="status">
      <img src="@/assets/Previousv.jpg" />
    </el-button>
    <el-button id="btn03" @click="test01('03')" style="width: 50px; height: 50px; left: 10px" v-bind:disabled="status">
      <img src="@/assets/Nextv.jpg" />
    </el-button>
    <el-button id="btn04" @click="test01('04')" style="width: 50px; height: 50px; left: 10px" v-bind:disabled="status">
      <img src="@/assets/Lastv.jpg" />
    </el-button>
    <el-button id="btn05" @click="test01('05')" style="width: 50px; height: 50px; left: 70px" v-bind:disabled="status">
      <img src="@/assets/Addv.jpg" />
    </el-button>
    <el-button id="btn06" @click="test01('06')" style="width: 50px; height: 50px; left: 70px" v-bind:disabled="status">
      <img src="@/assets/Editv.jpg" />
    </el-button>
    <el-button id="btn07" @click="test01('07')" style="width: 50px; height: 50px; left: 70px" v-bind:disabled="status">
      <img src="@/assets/Deletev.jpg" />
    </el-button>
    <el-button id="btn08" @click="test01('08')" style="width: 50px; height: 50px; left: 100px"
      v-bind:disabled="!status">
      <img src="@/assets/Queryv.jpg" />
    </el-button>
    <el-button id="btn09" @click="test01('09')" style="width: 50px; height: 50px; left: 100px" v-bind:disabled="status">
      <img src="@/assets/Printv.jpg" />
    </el-button>
    <el-button id="btn10" @click="test01('10')" style="width: 50px; height: 50px; left: 120px"
      v-bind:disabled="!status">
      <img src="@/assets/Okv.jpg" />
    </el-button>
    <el-button id="btn11" @click="test01('11')" style="width: 50px; height: 50px; left: 120px"
      v-bind:disabled="!status">
      <img src="@/assets/Cancelv.jpg" />
    </el-button>
    <el-button id="btn12" @click="test01('12')" style="width: 50px; height: 50px; left: 150px" v-bind:disabled="status">
      <img src="@/assets/Quitv.jpg" />
    </el-button>

    <el-button id="bplstatus" style="background-color=#c6e2ff;left:165px;font-color=black;font-size=30px">瀏覽</el-button>
    <div style="height:30px"></div>
    <el-row>
      <el-col :span="8">
        <label>單號:</label>
        <input type="text" style="width:80px;height:22px" v-model="st101m.id101" v-bind:disabled="true" />
      </el-col>
      <el-col :span="8">
        <label>日期:</label>
        <el-date-picker id="cdate1" v-model="st101m.v_date" type="date" :size="size" v-bind:disabled="!status" />
      </el-col>
    </el-row>
    <div style="height:10px"></div>
    <el-row>
      <el-col :span="8">
        <label>客戶編號:</label>
        <el-input ref="cust_id1" type="text" style="width:150px;height:22px" v-model="st101m.cust_id"
          @keydown.enter="chkcust" @keyup.f2="GetCustV" v-bind:disabled="!status">
          <template #prefix>
            <el-icon class="el-input__icon" @click="GetCustV()" v-bind:disabled="!status">
              <Search />
            </el-icon>
          </template>
        </el-input>
      </el-col>
      <el-col :span="8">
        <label>名稱:</label>
        <input type="text" style="width:300px;height:22px" v-model="st101m.cust_name" v-bind:disabled="true" />
      </el-col>
    </el-row>
    <div style="height:10px"></div>
    <el-table :data="st101sv.slice((cCurPage - 1) * fixpg, cCurPage * fixpg)" style="width: 100%;height:350px"
      v-bind:disabled="!status">
      <el-table-column label="序號" prop="sec" width="80px">
      </el-table-column>
      <el-table-column label="產品編號" width="150px">
        <template #default="scope">
          <el-input v-model="scope.row.prod_id" v-bind:readonly="GetProdStatus()" :ref="'prod_id' + scope.row['sec']"
            @keydown.enter="chkprod(scope.row)" @keyup.f2="GetProdV(scope)">
            <template #prefix>
              <el-icon class="el-input__icon" @click="GetProdV(scope)" v-bind:disabled="!status">
                <Search />
              </el-icon>
            </template>
          </el-input>
        </template>
      </el-table-column>
      <el-table-column label="名稱" prop="prod_name" width="300px">
      </el-table-column>
      <el-table-column label="數量" width="100px">
        <template #default="scope">
          <el-input v-model="scope.row.qty" v-bind:readonly="!status" input-style="text-align:right"
            :ref="'qty' + scope.row['sec']" @keydown.enter="chkqty(scope.row)" />
        </template>
      </el-table-column>
      <el-table-column label="單價" width="100px">
        <template #default="scope">
          <el-input v-model="scope.row.price" v-bind:readonly="!status" input-style="text-align:right"
            :ref="'price' + scope.row['sec']" @keydown.enter="chkprice(scope.row)" />
        </template>
      </el-table-column>
      <el-table-column label="小計" prop="tot" align="right" width="100px">

      </el-table-column>
    </el-table>
    <div style="text-align:center;margin-top:20px;">
      <el-pagination background layout="prev, pager,next" :total="st101svtot" :page-size="6"
        @current-change="current_change2">
      </el-pagination>
    </div>
  </div>
  <el-dialog v-model="ProdDlg" title="產品選擇" width="30%">
    <div style="width:100%;height:80px">
      <label>產品編號</label>
      <el-input style="width: 70%" color="primary" v-model="sprod_id" />
      <el-icon :size="20" style="left:5px;top:2px" @click="getprods('1')">
        <Search />
      </el-icon>
      <el-icon :size="20" style="left:10px;top:2px" @click="getprods('2')">
        <House />
      </el-icon>
    </div>
    <el-table :data="prodlistv.slice((cProdPage - 1) * fixpg1, cProdPage * fixpg1)" style="width: 100%"
      @row-click="GetCProd">
      <el-table-column prop="prod_id" label="產品編號" width="100" />
      <el-table-column prop="prod_name" label="名稱" width="250" />
    </el-table>
    <div style="text-align: center;margin-top: 30px;">
      <el-pagination background layout="prev, pager, next" :total="ProdTot" :page-size="5"
        @current-change="current_change">
      </el-pagination>
    </div>
    <template #footer>
      <span class="dialog-footer">
        <el-button type="primary" @click="getprods('3')">重新下載</el-button>
        <el-button @click="ProdDlg = false">取消</el-button>
      </span>
    </template>
  </el-dialog>
  <el-dialog v-model="CustDlg" title="客戶選擇" width="30%">
    <div style="width:100%;height:80px">
      <label>客戶編號</label>
      <el-input style="width: 70%" color="primary" v-model="scust_id" />
      <el-icon :size="20" style="left:5px;top:2px" @click="getcusts('1')">
        <Search />
      </el-icon>
      <el-icon :size="20" style="left:10px;top:2px" @click="getcusts('2')">
        <House />
      </el-icon>
    </div>
    <el-table :data="custlistv.slice((cCustPage - 1) * fixpg1, cCustPage * fixpg1)" style="width: 100%"
      @row-click="GetCCust">
      <el-table-column prop="cust_id" label="客戶編號" width="100" />
      <el-table-column prop="cust_name" label="名稱" width="250" />
    </el-table>
    <div style="text-align: center;margin-top: 30px;">
      <el-pagination background layout="prev, pager, next" :total="CustTot" :page-size="5"
        @current-change="current_change1">
      </el-pagination>
    </div>
    <template #footer>
      <span class="dialog-footer">
        <el-button type="primary" @click="getcusts('3')">重新下載</el-button>
        <el-button @click="CustDlg = false">取消</el-button>
      </span>
    </template>
  </el-dialog>

</template>

<script>
var moment = require('moment');
import { ElMessage } from 'element-plus'
import axios from 'axios';
import {urlbase} from './Apibase.js'

export default {
  name: 'St1011',
  data() {
    return {
      st101m: {
        id101: "",
        a_date: "",
        v_date: Date.now(),
        cust_id: "",
        cust_name: "",
      },
      st101s: [],
      st101sv: [],
      st101svo: [],
      st101mv: [],
      prodlist: [],
      prodlistv: [],
      custlist: [],
      custlistv: [],
      status: false,
      statusname: "瀏覽",
      ServerMsg: "",
      ProdDlg: false,
      CustDlg: false,
      GetDateV: Date.now(),
      fixpg: 6,
      fixpg1: 5,
      cCurPage: 1,
      st101svtot: 0,
      cProdPage: 1,
      ProdTot: 0,
      sprod_id: "",
      cCustPage: 1,
      CustTot: 0,
      scust_id: "",
      DateDlg: false,
      st101srec: [],
      //bodystatus: "新增",
      bodystatus: "",
      pdfUrl:"",
    };
  },
  methods: {
    async st101crud1(param) {
      this.ex = await this.st101crud2(param);
    },
    st101crud2(param) {
      return new Promise((res, rej) => {
        axios({
          method: 'POST',
          url: urlbase + "st101crud",
          data: param
        }).then(async (res) => {
          this.ServerMsg = res.data["ServerMsg"];
          this.st101m.id101 = res.data["id101"];         
        }).catch((error) => {
          this.ServerMsg = "ng";
        });
      });
    },
    async st101p1(param) {
      this.ex = await this.st101p2(param);
    },
    st101p2(param) {
      return new Promise((res, rej) => {
        axios({
          method: 'POST',
          url: urlbase + "st101p",
          data: param,          
          responseType: "blob"
        }).then(async (res) => {
          const binaryData = [];
          binaryData.push(res.data);
          this.pdfUrl = window.URL.createObjectURL(
            new Blob(binaryData, { type: "application/pdf" })
          );
          window.open(this.pdfUrl);   
        }).catch((error) => {
          this.ServerMsg = "ng";
        });
      });
    },
    chkqty(row) {
      let s1 = 'price' + row['sec'];
      this.$refs[s1].focus();
    },
    getMaxSec() {
      let s1 = ""
      let s2 = ""
      let s3 = ""
      this.st101sv.forEach((item) => {
        s2 = item["sec"]
        if (s2 > s1) { s1 = s2 }
      })
      if (s1 != "") {
        let n1 = parseInt(s1) + 10;
        s3 = n1.toString();
        if ((n1 >= 10) && (n1 < 100)) { s3 = '00' + s3 }
        if ((n1 >= 100) && (n1 < 1000)) { s3 = '0' + s3 }
      } else {
        s3 = "0010"
      }
      return s3
    },
    chkprice(row) {
      let s1 = this.getMaxSec();
      row['tot'] = parseInt(row['qty']) * parseInt(row['price']);   
      this.st101sv.push({
          id101: this.st101m.id101,
          sec: s1,
          prod_id: "",
          prod_name: "",
          qty: "",
          price: "",
          tot: ""
      })     
      this.st101svtot = this.st101svtot + 1
      let s2 = 'prod_id' + s1;
      let n1 = parseInt(s1);
      if ((n1 % 60) == 10) { this.cCurPage = this.cCurPage + 1 }
      //很重要 
        this.$nextTick(() => {
        this.$refs[s2].focus();
      })      
    },
    GetProdStatus() {
      return ((this.bodystatus != '新增') && (!this.status))
    },
    chkprod(row) {
      let lFind = false;
      let s1 = '';
      this.prodlist.forEach((item) => {
        if (item['prod_id'] == row.prod_id) {
          lFind = true;
          s1 = item["prod_name"]
        }
      })
      if (lFind) {
        row.prod_name = s1;
        let s2 = 'qty' + row['sec'];
        this.$refs[s2].focus();
      }
      else {
        ElMessage('找不到產品編號')
      }
    },
    chkcust() {
      let lFind = false;
      let s1 = '';
      this.custlist.forEach((item) => {
        if (item['cust_id'] == this.st101m.cust_id) {
          lFind = true;
          s1 = item["cust_name"]
        }
      })
      if (lFind) {
        this.st101m.cust_name = s1
      }
      else {
        ElMessage('找不到客戶編號')
      }
    },
    GetCProd(row, column, e) {
      this.st101srec.row.prod_id = row.prod_id;
      this.st101srec.row.prod_name = row.prod_name;
      let s1 = 'qty' + this.st101srec.row.sec;
      this.$refs[s1].focus();
      this.ProdDlg = false;
    },
    GetCCust(row, column, e) {
      this.st101m.cust_id = row.cust_id;
      this.st101m.cust_name = row.cust_name;
      this.CustDlg = false;
    },
    GetProdV(n1) {
      let lSUC=this.GetProdStatus();
      if (!lSUC) {
        this.st101srec = n1;
        this.ProdDlg = true;
      }
    },
    GetCustV() {
      this.CustDlg = true;
    },
    GetADateV() {
      this.DateDlg = true;
    },
    DateOk() {
      let ymd = moment(this.GetDateV).format('YYYYMMDD');
      this.st101m.a_date = ymd;
      this.DateDlg = false;
    },
    getprods(cS) {
      if (cS == "1") {
        this.getprods1()
      }
      if (cS == "2") {
        this.prodlistv = this.prodlist;
        this.ProdTot = this.prodlistv.length;
        this.cProdPage = 1;
        this.sprod_id = ""
      }
      if (cS == "3") {
        this.getProd1();
        this.sprod_id = "";
        this.cProdPage = 1;
      }
    },
    async getprods1() {
      this.ex = await this.getprods2();
    },
    getprods2() {
      let param = {
        userkey: sessionStorage.getItem("userKey"),
        sprod_id: this.sprod_id,
      }
      return new Promise((res, rej) => {
        axios({
          method: 'POST',
          url: urlbase + "prodss",
          data: param
        }).then(async (res) => {
          this.prodlistv = res.data
          this.ProdTot = this.prodlistv.length;
        }).catch((error) => {
          this.ServerMsg = "ng";
        });
      });
    },
    getcusts(cS) {
      if (cS == "1") {
        this.getcusts1()
      }
      if (cS == "2") {
        this.custlistv = this.custlist;
        this.CustTot = this.custlistv.length;
        this.cCustPage = 1;
        this.scust_id = ""
      }
      if (cS == "3") {
        this.getCust1();
        this.scust_id = "";
        this.cCustPage = 1;
      }
    },
    async getcusts1() {
      this.ex = await this.getcusts2();
    },
    getcusts2() {
      let param = {
        userkey: sessionStorage.getItem("userKey"),
        scust_id: this.scust_id,
      }
      return new Promise((res, rej) => {
        axios({
          method: 'POST',
          url: urlbase + "custss",
          data: param
        }).then(async (res) => {
          this.custlistv = res.data
          this.CustTot = this.custlistv.length;
        }).catch((error) => {
          this.ServerMsg = "ng";
        });
      });
    },
    async st101del1(param) {
      this.ex = await this.st101del2(param);
    },
    st101del2(param) {
      return new Promise((res, rej) => {
        axios
          .post("/st101dele", param)
          .then(async (res) => {
            this.ServerMsg = res.data["ServerMsg"];
          })
          .catch((error) => {
            this.ServerMsg = "ng";
          });
      });
    },
    current_change: function (cProdPage) {
      this.cProdPage = cProdPage;
    },
    current_change1: function (cCustPage) {
      this.cCustPage = cCustPage;
    },
    current_change2: function (cCurPage) {
      this.cCurPage = cCurPage;
    },
    async st101move1(param) {
      await this.st101move2(param)
    },
    st101move2(param) {
      return new Promise((res) => {
        axios({
          method: 'POST',
          url: urlbase + "st101data",
          data: param
        })
          .then(async (res) => {
            this.st101mv = res.data["st101m"];
            this.st101m.id101 = this.st101mv[0]["id101"];
            this.st101m.a_date = this.st101mv[0]["a_date"];
            this.st101m.v_date = this.st101mv[0]["v_date"];
            this.st101m.cust_id = this.st101mv[0]["cust_id"];
            this.st101m.cust_name = this.st101mv[0]["cust_name"];
            this.st101sv = res.data["st101s"];
            this.st101svo = res.data["st101s"];
            this.st101svtot = this.st101sv.length;
          }).catch((err) => {
            console.log(err)
          });
      });
    },
    async getProd1() {
      await this.getProd2();
    },
    getProd2() {
      //url: "urlbase+prods",
      const param = { userkey: sessionStorage.getItem("userKey") };
      return new Promise((res) => {
        axios({
          method: 'POST',
          url: urlbase + "prods",
          data: param
        })
          .then(async (res) => {
            this.prodlist = res.data;
            this.prodlistv = res.data;
            this.ProdTot = this.prodlistv.length
          })
          .catch((err) => {
            this.ServerMsg = "ng";
          });
      });
    },
    async getCust1() {
      this.ex = await this.getCust2();
    },
    getCust2() {
      const param = { userkey: sessionStorage.getItem("userKey") };
      return new Promise((res) => {
        axios({
          method: 'POST',
          url: urlbase + "custs",
          data: param
        })
          .then(async (res) => {
            this.custlist = res.data;
            this.custlistv = res.data;
            this.CustTot = this.custlistv.length
          })
          .catch((err) => {
            this.ServerMsg = "ng";
          });
      });
    },
    test01(n1) {
      if (n1 == "01" || n1 == "02" || n1 == "03" || n1 == "04") {
        this.st101move1({
          userkey: sessionStorage.getItem("userKey"),
          sid101: this.st101m.id101,
          btn_no: n1,
        })
      }
      if (n1 == '05') {
        this.GetDateV = Date.now();
        this.st101m.id101 = "新增單號";
        this.st101m.a_date = moment(this.GetDateV).format('YYYYMMDD');
        this.st101m.v_date = Date.now();
        this.st101m.cust_id = "";
        this.st101m.cust_name = "";
        this.st101sv = [
          {
            id101: this.st101m.id101,
            sec: "0010",
            prod_id: "",
            prod_name: "",
            qty: "",
            price: "",
            tot: "0",
          },
        ];
        this.st101svtot = 1;
        this.status = true;
        this.statusname = "新增";
        document.getElementById("bplstatus").innerText = this.statusname;
        this.bodystatus = "新增";
        this.$refs.cust_id1.focus();
      }
      if (n1 == "06") {
        this.status = true;
        this.statusname = "修改";
        document.getElementById("bplstatus").innerText = this.statusname;
        this.$refs.cust_id1.focus();
      }
      if (n1 == "07") {
        //this.dlgmsg = "Header:請問要刪除本筆資料嗎?";
        //this.show5 = true;
      }
      if (n1 == "09") {
        //印表
        //this.show5 = true;
        this.$nextTick(() => {
          this.st101m.a_date = moment(this.st101m.v_date).format('YYYYMMDD');
          this.st101p1({
            userkey: sessionStorage.getItem("userKey"),
            id101: this.st101m.id101,            
          })
        });
      }
      if (n1 == "10") {
        this.$nextTick(() => {
          this.st101m.a_date = moment(this.st101m.v_date).format('YYYYMMDD');
          this.st101crud1({
            userkey: sessionStorage.getItem("userKey"),
            st101m: this.st101m,
            st101s: this.st101sv,
          })
        });
        this.status = false;
        this.$nextTick(() => {
          this.st101move1({
            userkey: sessionStorage.getItem("userKey"),
            sid101: this.st101m.id101,
            btn_no: "00",
          })
        });
        this.statusname = "瀏覽";
        document.getElementById("bplstatus").innerText = this.statusname;
      }
      if (n1 == "11") {
        this.status = false;
        this.statusname = "瀏覽";
        document.getElementById("bplstatus").innerText = this.statusname;
        this.st101move1({
          userkey: sessionStorage.getItem("userKey"),
          sid101: this.st101mv[0]["id101"],
          btn_no: "00",
        });
      }
    },
  },
  created() {
    this.getProd1()
    this.getCust1()
    this.test01("04");
  },
}     
</script>