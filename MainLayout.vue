<template>
  <q-layout>
    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import { defineComponent, ref } from "vue";
import EssentialLink from "components/EssentialLink.vue";

const linksList = [
  {
    title: "首頁",
    //caption: "quasar.dev",
    icon: "home",
    link: "/",
  },
  {
    title: "搜尋",
    //caption: "github.com/quasarframework",
    icon: "search",
    link: "userindex",
  },
 
export default defineComponent({
  name: "MainLayout",
  data() {
    return { isshow: true };
  },
  methods: {
    btn1() {
      this.$router.push("/userindex");
    },
    btn2() {},
    btn3() {
      this.$router.push("/postlist");
    },
    btn4() {},
    btn5() {},
  },
  created() {
    window.addEventListener("resize", () => {
      let w1 = window.innerWidth > 0 ? window.innerWidth : screen.width;
      if (w1 > 700) {
        this.isshow = true;
      } else {
        this.isshow = false;
      }
    });
    let w1 = window.innerWidth > 0 ? window.innerWidth : screen.width;
    if (w1 > 700) {
      this.isshow = true;
    } else {
      this.isshow = false;
    }
  },
});
</script>
