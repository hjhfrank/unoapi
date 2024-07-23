<template>
  <el-row>
    <div style="font-size:24px">出發日期起迄:</div>
    <el-date-picker v-model="v011" type="date" style="width:150px" />
    <div style="font-size:24px">～</div>
    <el-date-picker v-model="v012" type="date" style="width:150px" />
  </el-row>
  <div style="height:5px"></div>
  <el-row>
    <div style="font-size:24px">團費區間:</div>
    <el-input v-model="v021" style="width: 100px;text-align: left;" />
    <div style="font-size:24px">～</div>
    <el-input v-model="v022" style="width: 100px;text-align: left;" />
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
    <el-input v-model="v07" style="width: 400px" placeholder="請輸入關鍵字" />
    <el-button @click="btn1()">確定</el-button>
  </el-row>
  <el-table :data="srrec" style="width: 100%">   
    <el-table-column prop="PRODNAME" label="名稱" width="300" />
    <el-table-column prop="AIRLINE" label="班機" width="60"/>
    <el-table-column prop="STDATE" label="出發日" width="100"/>
    <el-table-column prop="WEEKOF" label="星期" width="60"/>
    <el-table-column prop="T_DAY" label="天數" width="60"/>
    <el-table-column prop="SALES" label="團費" width="80"/>
    <el-table-column prop="VISAC" label="簽證費" width="60"/>
    <el-table-column prop="TAXC" label="稅金" width="60"/>
    <el-table-column prop="TIPC" label="小費" width="60"/>
    <el-table-column prop="QTY" label="機位" width="60"/>
    <el-table-column prop="SIGNSTS" label="報名" width="60"/>
    <el-table-column prop="REM" label="備註" width="60"/>
    <el-table-column prop="SALENO" label="團號" width="180"/>
    <el-table-column prop="CRTDT" label="日期" width="100" />
  </el-table>
</template>

<script>
import { defineComponent, ref } from 'vue';
import axios from 'axios';
import dayjs from 'dayjs'

export default defineComponent({
  name: "HelloWorld",
  data() {
    return {
      v011: dayjs().format('YYYY-MM-DD'),
      v012: dayjs().format('YYYY-MM-DD'),
      v021: '10000',
      v022: '100000',
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
      srrec:[],
    };
  },
  methods: {
    async btn1() {
      let param = {
        'v011': this.v011,
        'v012': this.v012,
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
          data: param
        }).then(async (res) => {
          this.srrec=res.data.dt;          
        }).catch((error) => {
          //
        });
      });
    },
  },
  created() {
    let v1 = dayjs();
    let v2 = v1.add(1, 'month');
    this.v011 = v1.format('YYYY-MM-DD');
    this.v012 = v2.format('YYYY-MM-DD');
  },
});

/*
<el-checkbox v-model="v062" label="候補" size="xlarge" />
    <el-checkbox v-model="v063" label="即將成團" size="large" />
    <el-checkbox v-model="v064" label="已成團 " size="large" />
    <el-checkbox v-model="v065" label="保證出團" size="large" />
    <el-checkbox v-model="v066" label="結團" size="large" />    
     <div style="height:5px"></div>
  <el-row>   
    <div style="font-size:24px">出發日星期:</div>
    <el-input v-model="v051" style="width: 40px;text-align: left;"/>
    <div style="font-size:24px">～</div>    
    <el-input v-model="v052" style="width: 40px;text-align: left;" />  
  </el-row>
*/
</script>


<style scoped>
.read-the-docs {
  color: #888;
}
</style>
