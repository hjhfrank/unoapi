<template>
  
</template>

<script>
import { ref, defineComponent } from "vue";
import { date, useQuasar } from "quasar";
const $q = useQuasar();

export default defineComponent({
  name: "IndexPage",
  data() {
    return {
      tab: "tab1",
      tabu: "tabu1",
      isshow: true,
      nHH: 0,
      nWW: 0,
      hostna: "",
      num: 0,
      cnt: 0,
      dt1: 0,
      dt2: 0,
      nsy: 0,
      ney: 0,
      ny: 0,
      nsx: 0,
      nex: 0,
      nx: 0,
      a1: [],
      sec: 0,
      nvh: "80",
      ppic: "",
      innerw: 0,
      innerh: 0,
      una: "",
    };
  },
  methods: {
    load01() {
      let n1 = 1;
      let n2 = 54;
      let vhostpic = "";
      while (n1 <= n2) {
        vhostpic =
          "http://219.91.2.29:8000/getpicxx?key1=" +
          String(n1).padStart(2, "0") +
          ".jpg";
        this.a1.push({ sec: n1, hostna: vhostpic });
        n1 = n1 + 1;
      }
    },
    btn1() {
      this.dt2 = Date.now();
      if (this.dt2 - this.dt1 > 100) {
        this.dt1 = Date.now();
        this.dt2 = Date.now();
        this.num = this.num + 1;
        if (this.num >= 53) {
          this.hostna = this.a1[53]["hostna"];
        } else {
          this.hostna = this.a1[this.num]["hostna"];
        }
      }
    },
    btn2() {
      this.dt2 = Date.now();
      if (this.dt2 - this.dt1 > 100) {
        this.dt1 = Date.now();
        this.dt2 = Date.now();
        this.num = this.num - 1;
        if (this.num <= 0) {
          this.hostna = this.a1[0]["hostna"];
        } else {
          this.hostna = this.a1[this.num + 1]["hostna"];
        }
      }
    },
    tch01(e) {
      e.preventDefault();
      this.nsx = e.changedTouches[0].pageX;
      this.nsy = e.changedTouches[0].pageY;
    },
    tch02(e) {
      e.preventDefault();
      this.nex = e.changedTouches[0].pageX;
      this.ney = e.changedTouches[0].pageY;
      this.nx = this.nex - this.nsx;
      this.ny = this.ney - this.nsy;
      if (this.ny > 0) {
        this.btn2();
      }
      if (this.ny < 0) {
        this.btn1();
      }
    },
    tch03(e) {
      //模擬window mouse clisk
      e.preventDefault();
      let nsx = e.changedTouches[0].pageX;
      let nsy = e.changedTouches[0].pageY;
      if (nsy == this.nsy) {
        this.t01();
      }
    },
    handleScroll1(e) {
      if (e.deltaY > 0) {
        this.btn1();
      } else {
        this.btn2();
      }
    },
    t01() {
      //alert("ok");
    },
    xbtn1() {
      this.$router.push("/userindex");
    },
    xbtn2() {},
    xbtn3() {
      this.$router.push("/postlist");
    },
    xbtn4() {},
    xbtn5() {},
  },
  mounted() {
    let el = document.getElementById("mainbody");
    if (this.$q.platform.is.mobile) {
      el.addEventListener("touchstart", this.tch01, false);
      el.addEventListener("touchmove", this.tch02, false);
      el.addEventListener("touchend", this.tch03, false);
    }
    if (this.$q.platform.is.desktop) {
      el.addEventListener("mousewheel", this.handleScroll1, false);
    }
  },
  created() {
    this.dt1 = Date.now();
    this.dt2 = Date.now();
    this.load01();
    window.addEventListener("resize", () => {
      let w1 = window.innerWidth > 0 ? window.innerWidth : screen.width;
      if (w1 > 700) {
        this.isshow = true;
      } else {
        this.isshow = false;
      }
      this.innerw = window.innerWidth;
    });
    let w1 = window.innerWidth > 0 ? window.innerWidth : screen.width;
    if (w1 > 700) {
      this.isshow = true;
    } else {
      this.isshow = false;
    }
    this.nHH = window.innerHeight;
    this.nWW = window.innerWidth;
    this.dt1 = Date.now();
    this.dt2 = Date.now();
    //this.num = this.a1.length;
    this.hostna = this.a1[0]["hostna"];
    this.innerw = window.innerWidth;
    this.innerh = window.innerHeight;
    if (this.$q.platform.is.mobile) {
      this.nvh = "70";
      this.innerw = window.innerWidth;
      this.innerh = window.innerHeight;
    }
    this.ppic = sessionStorage.getItem("ppic");
    this.una = sessionStorage.getItem("una");
  },
});