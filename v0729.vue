<template>
  <el-row>
    <div style="font-size:24px">出發日期起迄:</div>
    <el-date-picker v-model="v011" type="date" style="width:150px" />
    <div style="font-size:24px">～</div>
    <el-date-picker v-model="v012" type="date" style="width:150px" />
  </el-row>  
  <div style="height:5px"></div>
  <el-row>
    <div style="font-size:24px">旅遊天數:</div>
    <el-input v-model="v031" style="width: 40px;text-align: left;" />
    <div style="font-size:24px">～</div>
    <el-input v-model="v032" style="width: 40px;text-align: left;" />
  </el-row>
  <div style="height:5px"></div>
  <el-row>
    <div style="font-size:24px">航空公司:</div>
    <el-input v-model="v041" style="width: 40px;text-align: left;" />
    <div style="font-size:24px">～</div>
    <el-input v-model="v042" style="width: 40px;text-align: left;" />
  </el-row>
  <div style="height:5px"></div>
  <el-row>
    <div style="font-size:18px;padding-top: 3px;">團體狀態:</div>
    <el-checkbox v-model="v061" label="報名" />
    <el-checkbox v-model="v062" label="候補" />
    <el-checkbox v-model="v063" label="即將成團" />
    <el-checkbox v-model="v064" label="已成團 " />
    <el-checkbox v-model="v065" label="保證出團" />
    <el-checkbox v-model="v066" label="結團" />
  </el-row>
  <div style="height:5px"></div>
  <el-row>
    <div style="font-size:24px">關鍵字 </div>
    <el-input v-model="v07" style="width: 400px" placeholder="請輸入關鍵字">
    </el-input>
  </el-row>
  <div style="height:5px"></div>
  <el-row>
    <el-button @click="btn1()">條件搜尋+關鍵字</el-button>
    <el-button @click="btn4()">只搜關鍵字</el-button>
    <el-button @click="btn5()">團號歷史搜尋</el-button>
  </el-row>
  <template v-if="isshow1">
    <div style="height:3px"></div>
    <el-button type="primary" @click="btn2">Excel輸出</el-button>
    <el-table :data="srrec" style="width: 100%" id="excelo">
      <el-table-column prop="PRODNAME" label="名稱" width="300" />
      <el-table-column prop="AIRLINE" label="班機" width="60" />
      <el-table-column prop="STDATE" label="出發日" width="100" />
      <el-table-column prop="WEEKOF" label="星期" width="60" />
      <el-table-column prop="T_DAY" label="天數" width="60" />
      <el-table-column prop="SALES" label="團費" width="80" />
      <el-table-column prop="VISAC" label="簽證費" width="80" />
      <el-table-column prop="TAXC" label="稅金" width="60" />
      <el-table-column prop="TIPC" label="小費" width="60" />
      <el-table-column prop="QTY" label="機位" width="60" />
      <el-table-column prop="SIGNSTS" label="報名" width="60" />
      <el-table-column prop="REM" label="備註" width="60" />
      <el-table-column prop="SALENO" label="團號" width="180" />
      <el-table-column prop="CRTDT" label="日期" width="100" />
    </el-table>
  </template>
  <el-dialog v-model="isdlg1" title="團號歷史查詢" width="300">
    <el-input v-model="sno" style="width: 100%" />
    <template #footer>
      <div class="dialog-footer">
        <el-button @click="dlg1btn(1)">放棄</el-button>
        <el-button type="primary" @click="dlg1btn(2)">
          確定
        </el-button>
      </div>
    </template>
  </el-dialog>
  <el-dialog v-model="isdlg2" title="Excel檔案名稱" width="300">
    <el-input v-model="dnfile" style="width: 100%" />
    <template #footer>
      <div class="dialog-footer">
        <el-button @click="dlg2btn(1)">放棄</el-button>
        <el-button type="primary" @click="dlg2btn(2)">
          確定
        </el-button>
      </div>
    </template>
  </el-dialog>
</template>

<script>
import { defineComponent, ref } from 'vue';
import axios from 'axios';
import dayjs from 'dayjs';
import * as XLSX from "xlsx";
//    <el-button @click="btn3()">關鍵字組合</el-button>

export default defineComponent({
  name: "HelloWorld",
  data() {
    return {
      v011: dayjs(), 
      v012: dayjs(),
      v021: '10000',
      v022: '200000',
      v031: '7',
      v032: '14',
      v041: 'BR',
      v042: 'TK',
      v051: '日',
      v052: '六',
      v061: true,
      v062: true,
      v063: true,
      v064: true,
      v065: true,
      v066: true,
      v07: '',
      srrec: [],
      isshow1: false,
      sno: '',
      isdlg1: false,
      isdlg2: false,
      dnfile: '',
      nselbtn: 0,
    };
  },
  methods: {
    async btn1() {
      console.log(this.v011);
      console.log(this.v012);
      let param = {
        'v011': dayjs(this.v011).format('YYYY-MM-DD'),
        'v012': dayjs(this.v012).format('YYYY-MM-DD'),
        'v021': this.v021,
        'v022': this.v022,
        'v031': this.v031,
        'v032': this.v032,
        'v041': this.v041,
        'v042': this.v042,
        'v051': this.v051,
        'v052': this.v052,
        'v061': this.v061,
        'v062': this.v062,
        'v063': this.v063,
        'v064': this.v064,
        'v065': this.v065,
        'v066': this.v066,
        'v07': this.v07,
      }
      this.ex = await this.btn11(param);
    },
    btn11(param) {
      return new Promise((res, rej) => {
        axios({
          method: 'POST',
          url: "http://localhost:5055/listvvv",
          //url:'http://localhost:60334/API/listvvv',
          data: param
        }).then(async (res) => {
          this.srrec = res.data.dt;
          if (this.srrec.length > 0) { this.isshow1 = true }
          else { alert('搜尋不到資料') }

        }).catch((error) => {
          alert('網路出現錯誤');
        });
      });
    },
    async dlg1btn(nn) {
      if (nn == 2) {
        let param = {'sno':this.sno};        
        this.ex = await this.dlg1btn1(param);           
      }
      this.isdlg1 = false;
    },
    dlg1btn1(param) {
      return new Promise((res, rej) => {
        axios({
          method: 'POST',
          url: "http://localhost:5055/listvvv2",
          //url: 'http://localhost:60334/API/listvvv2',          
          data: param
        }).then(async (res) => {
          this.srrec = res.data.dt;
          if (this.srrec.length > 0) { this.isshow1 = true }
          else { alert('搜尋不到資料') }
          this.isdlg1=false;
        }).catch((error) => {
          alert('網路出現錯誤');
        });
      });
    },
    dlg2btn(nn) {
      if (nn == 2) {
        if (this.dnfile.indexOf('.') < 0) {
          this.dnfile = this.dnfile + '.xlsx';
        }
        this.btn21();
      }
      this.isdlg2 = false;
    },
    btn2() {
      this.isdlg2 = true;
    },
    btn21() {
      //我直接加表頭
      let n1, n2;
      let a1 = [];
      let aa1 = [];
      let j1 = {};
      //PRODNAME,AIRLINE,STDATE,WEEKOF,T_DAY,SALES,VISAC,TAXC,TIPC,QTY,SIGNSTS,REM,SALENO,CRTDT,ALLID,URLPATH,URLPATH1           
      aa1 = ["產品名稱", "航班", "出發日", "星期", "天數", "團費", "簽證費", "稅金", "小費", "機位", "報名", "備註", "團號", "搜尋日期", "序號", "查詢網址", "產品網址"];
      a1.push(aa1);
      n1 = 0;
      n2 = this.srrec.length - 1;
      while (n1 <= n2) {
        j1 = this.srrec[n1];
        console.log(j1);
        aa1 = [j1["PRODNAME"], j1["AIRLINE"], j1["STDATE"], j1["WEEKOF"], j1["T_DAY"], j1["SALES"], j1["VISAC"], j1["TAXC"], j1["TIPC"], j1["QTY"], j1["SIGNSTS"], j1["REM"], j1["SALENO"], j1["CRTDT"], j1["ALLID"], j1["URLPATH"], j1["URLPATH1"]];
        a1.push(aa1)
        n1++;
      }
      const workbook = XLSX.utils.book_new();
      //const worksheet = XLSX.utils.json_to_sheet(this.srrec);
      const worksheet = XLSX.utils.aoa_to_sheet(a1);
      let wscols = [
        { wch: 40 },
        { wch: 4 },
        { wch: 10 },
        { wch: 4 },
        { wch: 6 },
        { wch: 10 },
        { wch: 10 },
        { wch: 10 },
        { wch: 10 },
        { wch: 10 },
        { wch: 10 },
        { wch: 10 },
        { wch: 20 },
        { wch: 20 },
        { wch: 6 },
        { wch: 10 },
        { wch: 20 },
        { wch: 20 }
      ];
      worksheet['!cols'] = wscols;
      XLSX.utils.book_append_sheet(workbook, worksheet, "Sheet1");
      const excelBuffer = XLSX.write(workbook, {
        bookType: "xlsx",
        type: "array",
      });
      this.saveExcelFile(excelBuffer, this.dnfile);
    },
    //這個要修,有空
    saveExcelFile(buffer, filename) {
      const data = new Blob([buffer], {
        type: "application/octet-stream",
      });
      const url = URL.createObjectURL(data);
      const link = document.createElement("a");
      link.href = url;
      link.setAttribute("download", filename);
      document.body.appendChild(link);
      link.click();
      document.body.removeChild(link);
    },
    btn3() {
      alert('ok3');
    },
    async btn4() {
      let param = {
        'v01': this.v07,
      }
      this.isshow1 = false;
      this.ex = await this.btn41(param);
    },
    btn41(param) {
      return new Promise((res, rej) => {
        axios({
          method: 'POST',
          url: "http://localhost:5055/listvvv1",
          //url : 'http://localhost:60334/API/listvvv1',
          data: param
        }).then(async (res) => {
          this.srrec = res.data.dt;
          //console.log(this.srrec);
          if (this.srrec.length > 0) { this.isshow1 = true }
          else { alert('搜尋不到資料') }

        }).catch((error) => {
          alert('網路出現錯誤');
        });
      });
    },
    btn5() {      
      //EUF082611TK24A
      this.isdlg1 = true;
    }
  },
  created() {
    let v1 = dayjs();
    let v2 = v1.add(1, 'month');
    this.v011 = v1;
    this.v012 = v2;
  },
  /*
   <el-row>
    <div style="font-size:24px">團費區間:</div>
    <el-input v-model="v021" style="width: 100px;text-align: left;" />
    <div style="font-size:24px">～</div>
    <el-input v-model="v022" style="width: 100px;text-align: left;" />
  </el-row>
  */
});

</script>

<style scoped>
.read-the-docs {
  color: #888;
}
</style>
