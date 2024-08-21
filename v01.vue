<template>
  <el-button @click="btn1(0)">btn1</el-button>
  <el-button @click="btn1(-1)">btn1</el-button>
  <el-button @click="btn1(1)">btn1</el-button>
  <el-button @click="btn1(99)">btn1</el-button>
  <el-row>
    {{ npt }}
  </el-row>
  <div style="width:100%;height:70vh">
    <el-table :data="list1" key="allid" height="400" highlight-current-row ref="wt1">
      <el-table-column prop="allid" label="allid" style="width:100px" />
      <el-table-column prop="prodname" label="prodname" style="width:900px;" />
    </el-table>
  </div>
</template>

<script>
import { defineComponent, ref } from 'vue';
import axios from 'axios';

export default defineComponent({
  name: "HelloWorld",
  data() {
    return {
      list1: [],
      npt: 0,
    };
  },
  methods: {
    btn1(nn) {
      let n1 = 0;
      let n2=0;
      let n3=30;
      if (nn == 0) { n1 = 0; }
      if (nn == -1) {
        n1 = this.npt - 1;;
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
        this.npt = n1;
        this.$refs.wt1.setCurrentRow(this.list1[this.npt]);
        if (n1<=6) {
          this.$refs.wt1.scrollTo(0, 0);
          this.$refs.wt1.setCurrentRow(this.list1[this.npt]);
        }
        else
        {        
          n3=n1*40;
          this.$refs.wt1.scrollTo(0, n3);
          this.$refs.wt1.setCurrentRow(this.list1[this.npt]);
        }
         
      });
    },
    async crtdata() {
      this.ex = await this.crtdata1();
    },
    crtdata1() {
      return new Promise((res, rej) => {
        axios({
          method: 'GET',
          url: "http://localhost:5055/listok"
        }).then(async (res) => {
          this.list1 = res.data.dt;
        }).catch((error) => {
          alert(error);
        });
      });

    },
  },
  created() {
    this.crtdata();
    this.npt = 0;
  },
});
</script>

//https://blog.csdn.net/chyuanrufeng/article/details/132663139
