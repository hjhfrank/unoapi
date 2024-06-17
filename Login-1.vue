<template>
  <q-form ref="loginForm" class="login-box">
    <div class="row">
      <div class="col">
        <q-input
          outlined
          clearable
          clear-icon="cancel"
          v-model="loginData.userid"
          dense
          debounce="1000"
          placeholder="使用者代號"
          square
          :rules="[(val) => (val && val.length > 0) || '請輸入使用者代號']"
        >
          <template v-slot:prepend>
            <q-icon name="person" />
          </template>
        </q-input>
      </div>
    </div>
    <div style="height: 40px"></div>
    <div class="row">
      <div class="col">
        <q-input
          outlined
          clearable
          clear-icon="cancel"
          :type="isPwd ? 'password' : 'text'"
          v-model="loginData.userpassword"
          dense
          debounce="1000"
          placeholder="密碼"
          square
          :rules="[(val) => (val && val.length > 0) || '請輸入使用者密碼']"
        >
          <template v-slot:prepend>
            <q-icon name="lock" />
          </template>
          <template v-slot:append>
            <q-icon
              :name="isPwd ? 'visibility_off' : 'visibility'"
              class="cursor-pointer"
              @click="isPwd = !isPwd"
            />
          </template>
        </q-input>
      </div>
    </div>
    <div style="height: 40px"></div>
    <div class="row">
      <div class="col">
        <q-btn color="primary" label="登錄" @click="btn1()"></q-btn>
      </div>
      <div class="col-6"></div>
      <div class="col">
        <q-btn color="red" label="放棄" @click="btn2()"></q-btn>
      </div>
    </div>
  </q-form>
  <q-dialog v-model="alert">
    <q-card>
      <q-card-section>
        <div
          class="text-h6"
          style="background-color: red; width: 300px; max-width: 800px"
        >
          警告
        </div>
      </q-card-section>

      <q-card-section class="q-pt-none" style="background-color: aquamarine">
        帳號或者密碼錯誤,請重新輸入
      </q-card-section>

      <q-card-actions align="right">
        <q-btn flat label="OK" color="primary" v-close-popup />
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>

<script>
import { defineComponent } from "vue";
import { api } from "boot/axios";

export default {
  name: "Login-1",
  data() {
    return {
      loginData: {
        usernid: "",
        userpassword: "",
      },
      accept: false,
      isPwd: true,
      vkey: "",
      msg: "",
      alert: false,
    };
  },
  methods: {
    btn1() {
      api
        .post("/login", this.loginData)
        .then((res) => {
          this.msg = res.data.msg;
          this.vkey = res.data.vkey;
          let v1 = res.data.userid;
          if (this.msg == "ok") {
            sessionStorage.setItem("userKey", this.vkey);
            sessionStorage.setItem("userid", v1);
            this.$router.push("/home");
          } else {
            //alert('登錄失敗,請重新登錄')
            this.alert = true;
            this.$router.push("/login");
          }
        })
        .catch((err) => {
          alert("ng");
        });
    },
    btn2() {
      this.$router.push("/error");
    },
  },
};
</script>


<style scoped>
.login-box {
  width: 320px;
  height: 300px;
  background: #e3f071;
  color: #fff;
  top: 200px;
  left: 50%;
  position: absolute;
  box-sizing: border-box;
  padding: 30px 30px;
  margin: -160px 0 0 -200px;
}

.login-box .avatar {
  width: 100px;
  height: 100px;
  border-radius: 50%;
  position: absolute;
  top: -50px;
  left: calc(50% - 50px);
}

.login-box h1 {
  margin: 0;
  padding: 0 0 20px;
  text-align: center;
  font-size: 22px;
}

.login-box label {
  margin: 0;
  padding: 0;
  font-weight: bold;
  display: block;
}

.login-box input {
  width: 100%;
  margin-bottom: 20px;
}

.login-box input[type="text"],
.login-box input[type="password"] {
  border: none;
  border-bottom: 1px solid #fff;
  background: transparent;
  outline: none;
  height: 40px;
  color: #fff;
  font-size: 16px;
}

.login-box input[type="submit"] {
  border: none;
  outline: none;
  height: 40px;
  background: #b80f22;
  color: #fff;
  font-size: 18px;
  border-radius: 20px;
}

.login-box input[type="submit"]:hover {
  cursor: pointer;
  background: #ffc107;
  color: #000;
}

.login-box a {
  text-decoration: none;
  font-size: 12px;
  line-height: 20px;
  color: darkgrey;
}

.login-box a:hover {
  color: #fff;
}
</style>