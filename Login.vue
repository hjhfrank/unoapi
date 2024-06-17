<template>
  <q-form ref="loginForm">
    <div class="row flex-center">
      <h6 style="color: #ffd700">創作者測試網站login</h6>
    </div>
    <div class="row flex-center">
      <div class="col-md-3 col">
        <q-icon name="email" size="2em" style="color: #fb6d48"></q-icon>
        <input
          type="email"
          name="usermail"
          id="usermail"
          v-model="loginData.usermail"
          placeholder="請輸入email"
        />
      </div>
    </div>
    <div class="row" style="height: 10px"></div>
    <div class="row flex-center">
      <div class="col-md-3 col">
        <q-icon name="lock" size="2em" style="color: #fb6d48"></q-icon>
        <input
          v-bind:type="isPwd ? 'password' : 'text'"
          name="userpassword"
          id="userpassword"
          v-model="loginData.userpassword"
          placeholder="請輸密碼"
        />
        <q-icon
          :name="isPwd ? 'visibility_off' : 'visibility'"
          style="color: #fb6d48"
          size="2em"
          @click="isPwd = !isPwd"
        ></q-icon>
      </div>
    </div>
    <div class="row" style="height: 10px"></div>
    <div class="row flex-center">
      <div class="col-md-3 col">
        <q-btn
          unelevated
          rounded
          color="primary"
          style="width: 100%"
          label="登錄"
          @click="btn1()"
        ></q-btn>
      </div>
    </div>
    <div style="height: 10px"></div>
    <div class="row flex-center">
      <div class="col-md-3 col">
        <q-btn
          unelevated
          rounded
          color="teal"
          style="width: 100%"
          label="註冊"
          @click="btn3()"
        ></q-btn>
      </div>
    </div>
    <div style="height: 10px"></div>
    <div class="row flex-center">
      <div class="col-md-3 col">
        <q-btn
          unelevated
          rounded
          color="red"
          style="width: 100%"
          label="忘記密碼"
          @click="btn2()"
        ></q-btn>
      </div>
    </div>
  </q-form>
  <q-dialog v-model="alert1">
    <q-card
      style="height: 100%; width: 100%; max-width: 480px; max-height: 140px"
    >
      <q-card-section class="bg-purple text-white">
        <div class="row">警告</div>
        <div class="row">帳號或者密碼錯誤,請重新輸入</div>
      </q-card-section>
      <q-card-actions vertical align="right">
        <q-btn flat label="OK" v-close-popup />
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>

<script>
import { defineComponent } from "vue";
import { api } from "boot/axios";
import { Base64 } from "js-base64";
//import { LocalStorage, SessionStorage } from "quasar";

export default {
  name: "Login-1",
  data() {
    return {
      loginData: {
        usermail: "",
        userpassword: "",
      },
      accept: false,
      isPwd: true,
      vkey: "",
      msg: "",
      alert1: false,
      uid: -1,
      ppic: "",
      una: "",
    };
  },
  methods: {
    async btn1() {
      let s1 = this.loginData["userpassword"];
      let s2 = Base64.encode(s1);
      s1 = this.loginData["usermail"];
      this.ex = await this.btn11(s1, s2);
    },
    btn11(s1, s2) {
      const paramdata = {
        usermail: s1,
        userpassword: s2,
      };
      return new Promise((res, rej) => {
        api
          .post("/login", paramdata)
          .then(async (res) => {
            this.msg = res.data.msg;
            this.vkey = res.data.vkey;
            this.ppic = res.data.ppic;
            this.una = res.data.una;
            this.uid = res.data.uid;
            let v1 = res.data.userid;
            if (this.msg == "ok") {
              sessionStorage.setItem("userKey", this.vkey);
              sessionStorage.setItem("userid", this.uid);
              sessionStorage.setItem("una", this.una);
              sessionStorage.setItem("ppic", this.ppic);
              console.log(this.ppic);
              localStorage.setItem("v1", s1);
              localStorage.setItem("v2", s2);
              this.$router.push("/indexpage");
              //this.$router.push("/");
            } else {
              this.alert1 = true;
              this.loginData["userpassword"] = s1;
              this.$router.push("/login");
            }
          })
          .catch((error) => {
            alert(error);
          });
      });
    },
    btn2() {
      this.$router.push("/");
    },
    btn3() {
      this.$router.push("/userreg");
    },
  },
};
</script>

<style scoped>
input[type="email"] {
  width: 90%;
  padding: 3px 5px;
  margin: 3px 0;
  box-sizing: border-box;
  border: 1px solid #ff7ed4;
  border-radius: 15px;
  -webkit-transition: 0.5s;
  transition: 0.5s;
  outline: none;
}

input[type="text"],
input[type="password"] {
  width: 80%;
  padding: 3px 5px;
  margin: 3px 0;
  box-sizing: border-box;
  border: 1px solid #ff7ed4;
  border-radius: 15px;
  -webkit-transition: 0.5s;
  transition: 0.5s;
  outline: none;
}

input[type="email"],
input[type="text"],
input[type="password"] :focus {
  border: 1px solid #ff3ea5;
}
</style>
