<template>
  <div style="background-color: #31ccec; height: 70px; width: 100%">
    <q-btn
      id="btn01"
      @click="test01('01')"
      style="width: 50px; height: 50px; left: 10px"
      v-bind:disabled="!vstatus"
    >
      <img src="http://192.168.1.31/statics/Firstv.jpg" />
    </q-btn>
    <q-btn
      id="btn02"
      @click="test01('02')"
      style="width: 50px; height: 50px; left: 10px"
      v-bind:disabled="!vstatus"
    >
      <img src="http://192.168.1.31/statics/Previousv.jpg" />
    </q-btn>
    <q-btn
      id="btn03"
      @click="test01('03')"
      style="width: 50px; height: 50px; left: 10px"
      v-bind:disabled="!vstatus"
    >
      <img src="http://192.168.1.31/statics/Nextv.jpg"
    /></q-btn>
    <q-btn
      id="btn04"
      @click="test01('04')"
      style="width: 50px; height: 50px; left: 10px"
      v-bind:disabled="!vstatus"
    >
      <img src="http://192.168.1.31/statics/Lastv.jpg" />
    </q-btn>
    <q-btn
      id="btn05"
      @click="test01('05')"
      style="width: 50px; height: 50px; left: 70px"
      v-bind:disabled="!vstatus"
    >
      <img src="http://192.168.1.31/statics/Addv.jpg"
    /></q-btn>
    <q-btn
      id="btn06"
      @click="test01('06')"
      style="width: 50px; height: 50px; left: 70px"
      v-bind:disabled="!vstatus"
    >
      <img src="http://192.168.1.31/statics/Editv.jpg"
    /></q-btn>
    <q-btn
      id="btn07"
      @click="test01('07')"
      style="width: 50px; height: 50px; left: 70px"
      v-bind:disabled="!vstatus"
    >
      <img src="http://192.168.1.31/statics/Deletev.jpg"
    /></q-btn>
    <q-btn
      id="btn08"
      @click="test01('08')"
      style="width: 50px; height: 50px; left: 100px"
      v-bind:disabled="!vstatus"
    >
      <img src="http://192.168.1.31/statics/Queryv.jpg"
    /></q-btn>
    <q-btn
      id="btn09"
      @click="test01('09')"
      style="width: 50px; height: 50px; left: 100px"
      v-bind:disabled="!vstatus"
    >
      <img src="http://192.168.1.31/statics/Printv.jpg"
    /></q-btn>
    <q-btn
      id="btn10"
      @click="test01('10')"
      style="width: 50px; height: 50px; left: 120px"
      v-bind:disabled="vstatus"
    >
      <img src="http://192.168.1.31/statics/Okv.jpg"
    /></q-btn>
    <q-btn
      id="btn11"
      @click="test01('11')"
      style="width: 50px; height: 50px; left: 120px"
      v-bind:disabled="vstatus"
    >
      <img src="http://192.168.1.31/statics/Cancelv.jpg"
    /></q-btn>
    <q-btn
      id="btn12"
      @click="test01('12')"
      style="width: 50px; height: 50px; left: 150px"
      v-bind:disabled="!vstatus"
    >
      <img src="http://192.168.1.31/statics/Quitv.jpg"
    /></q-btn>

    <q-btn
      id="bplstatus"
      style="left: 160px; font-weight: bolder"
      size="1.5em"
      label="瀏覽"
      flat
    />
    <div
      style="
        width: 100%;
        height: 580px;
        background-color: #98dfed;
        font-size: 18px;
      "
    >
      <div style="height: 20px; width: 100%"></div>
      <div style="height: 40px; width: 100%">
        <div class="row">
          <div class="col-4">
            <label>單號:</label>
            <input
              type="text"
              v-model="st101m.id101"
              v-bind:disabled="vstatus"
              readonly="true"
            />
          </div>
          <div class="col-4">
            <label>日期:</label>
            <input
              id="ida_date"
              mask="date"
              type="text"
              v-model="st101m.a_date"
              v-bind:disabled="vstatus"
            />
            <q-btn
              @click="test09()"
              style="width: 20px; height: 20px"
              v-bind:disabled="vstatus"
            >
              <img src="http://192.168.1.31/statics/RefVal.gif" />
            </q-btn>
          </div>
        </div>
      </div>
      <div style="height: 40px; width: 100%">
        <div class="row">
          <div class="col-4">
            <label>客戶編號:</label>
            <input
              type="text"
              v-model="st101m.cust_id"
              v-bind:disabled="vstatus"
            />
            <q-btn
              @click="test08()"
              style="width: 20px; height: 20px"
              v-bind:disabled="vstatus"
            >
              <img src="http://192.168.1.31/statics/RefVal.gif" />
            </q-btn>
          </div>
          <div class="col-4">
            <label>名稱:</label>
            <input
              type="text"
              v-model="st101m.cust_name"
              v-bind:disabled="vstatus"
              readonly="true"
            />
          </div>
        </div>
      </div>
      <div>
        <q-table
          :rows="st101sv"
          :columns="st101cols"
          row-key="sec"
          v-bind:disabled="!vstatus"
          class="my-sticky-header-table"
        >
          <template v-slot:header="props">
            <q-tr :props="props">
              <q-th v-for="col in props.cols" :key="col.name" :props="props">
                {{ col.label }}
              </q-th>
            </q-tr>
          </template>
          <template v-slot:body="props">
            <q-tr :props="props">
              <q-td
                auto-width
                v-for="col in props.cols"
                :key="col.name"
                :props="props"
              >
                {{ col.value }}
              </q-td>
              <q-td>
                <q-btn
                  @click="test07(props.row, '1')"
                  v-bind:disabled="vstatus"
                >
                  <img src="http://192.168.1.31/statics/Add.gif" />
                </q-btn>
                <q-btn
                  @click="test07(props.row, '2')"
                  v-bind:disabled="vstatus"
                >
                  <img src="http://192.168.1.31/statics/Edit.gif" />
                </q-btn>
                <q-btn
                  @click="test07(props.row, '3')"
                  v-bind:disabled="vstatus"
                >
                  <img src="http://192.168.1.31/statics/Delete.gif" />
                </q-btn>
              </q-td>
            </q-tr>
          </template>
        </q-table>
      </div>
    </div>

    <q-dialog v-model="show1">
      <q-card class="my-card" style="width: 40%; max-width: 80%">
        <q-table
          title="產品選擇"
          :rows="prodlistv"
          :columns="prodcols"
          row-key="prod_id"
          @row-click="test03"
        >
          <template v-slot:top>
            <h6 style="text-color: blue">產品選擇　</h6>
            <q-input
              style="width: 80%"
              color="primary"
              label="產品編號"
              v-model="sprod_id"
            >
              <template v-slot:append>
                <q-icon name="search" @click="test05('1')" />
                <q-icon name="home" @click="test05('2')" />
              </template>
            </q-input>
          </template>
        </q-table>
        <q-card-actions align="right">
          <q-btn flat label="重新下載" color="primary" @click="test05()" />
          <q-btn flat label="放棄" color="red" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>
  </div>

  <q-dialog v-model="show2">
    <q-card style="width: 40%; max-width: 80%">
      <q-table
        title="產品選擇"
        :rows="custlistv"
        :columns="custcols"
        row-key="cust_id"
        @row-click="test081"
      >
        <template v-slot:top>
          <h6 style="text-color: blue">客戶選擇　</h6>
          <q-input
            style="width: 80%"
            color="primary"
            label="客戶編號"
            v-model="scust_id"
          >
            <template v-slot:append>
              <q-icon name="search" @click="test082('1')" />
              <q-icon name="home" @click="test082('2')" />
            </template>
          </q-input>
        </template>
      </q-table>
      <q-card-actions align="right">
        <q-btn flat label="重新下載" color="primary" @click="test082('3')" />
        <q-btn flat label="放棄" color="red" v-close-popup />
      </q-card-actions>
    </q-card>
  </q-dialog>

  <q-dialog v-model="show3">
    <q-card class="my-card" style="width: 30%; max-width: 60%">
      <div class="q-pa-md bg-grey-10 text-white">
        <div class="q-gutter-md">
          <q-date
            v-model="sa_date"
            color="orange"
            text-color="black"
            dark
            bordered
          />
        </div>
      </div>
      <q-card-actions align="right">
        <q-btn flat label="確定" color="red" @click="test06()" />
      </q-card-actions>
    </q-card>
  </q-dialog>

  <q-dialog v-model="show4">
    <q-card class="my-card" style="width: 40%; max-width: 80%">
      <h6>{{ dlgmsg }}</h6>
      <q-card-actions align="right">
        <q-btn flat label="確定" color="red" v-close-popup />
      </q-card-actions>
    </q-card>
  </q-dialog>

  <q-dialog v-model="show5">
    <q-card class="my-card" style="width: 40%; max-width: 80%">
      <h6>{{ dlgmsg }}</h6>
      <q-card-actions align="right">
        <q-btn flat label="確定" color="primary" @click="test10()" />
        <q-btn flat label="放棄" color="red" v-close-popup />
      </q-card-actions>
    </q-card>
  </q-dialog>

  <q-dialog v-model="show6">
    <q-card class="my-card" style="width: 40%; max-width: 80%">
      <div>
        >
        <label style="text-color: blue">表身編輯 {{ bodystatus }} ></label>
      </div>
      <div class="row">
        <label>序號{{ st101ss.sec }}</label>
      </div>
      <div class="row">
        <label>產品編號</label>
        <input
          type="text"
          v-model="st101ss.prod_id"
          v-bind:disabled="bodystatus != '新增'"
        />
        <q-btn
          @click="test12()"
          style="width: 20px; height: 20px"
          v-bind:disabled="bodystatus != '新增'"
        >
          <img src="http://192.168.1.31/statics/RefVal.gif" />
        </q-btn>
      </div>
      <div class="row">
        <label>名稱:</label>
        <input type="text" v-model="st101ss.prod_name" readonly="true" />
      </div>
      <div class="row">
        <label>數量</label>
        <input type="text" v-model="st101ss.qty" />
      </div>
      <div class="row">
        <label>單價</label>
        <input type="text" v-model="st101ss.price" />
      </div>
      <div class="row">
        <label>小計{{ (st101ss.tot = st101ss.price * st101ss.qty) }}</label>
      </div>
      <q-card-actions align="right">
        <q-btn flat label="確定" color="primary" @click="test11()" />
        <q-btn flat label="放棄" color="red" v-close-popup />
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>

<script>
import { defineComponent, ref } from "vue";
import { api } from "boot/axios";
import { axios } from "axios";
import { date } from "quasar";

export default defineComponent({
  name: "Page-5",
  data() {
    return {
      prodcols: [
        {
          name: "prod_id",
          required: true,
          label: "產品編號",
          align: "left",
          field: "prod_id",
          sortable: true,
        },
        {
          name: "prod_name",
          align: "left",
          label: "名稱",
          field: "prod_name",
        },
      ],
      custcols: [
        {
          name: "cust__id",
          required: true,
          label: "客戶編號",
          align: "left",
          field: "cust_id",
          sortable: true,
        },
        {
          name: "cust_name",
          align: "left",
          label: "簡稱",
          field: "cust_name",
        },
      ],
      st101m: {
        id101: "",
        a_date: "",
        cust_id: "",
        cust_name: "",
      },
      st101ss: {
        id101: "",
        sec: "",
        prod_id: "",
        prod_name: "",
        qty: "0",
        price: "0",
        tot: "0",
      },
      st101cols: [
        {
          name: "sec",
          required: true,
          label: "序號",
          align: "left",
          field: "sec",
          sortable: true,
        },
        {
          name: "prod_id",
          align: "left",
          label: "產品編號",
          field: "prod_id",
        },
        {
          name: "prod_name",
          align: "left",
          label: "名稱",
          field: "prod_name",
        },
        {
          name: "qty",
          align: "right",
          label: "數量",
          field: "qty",
        },
        {
          name: "price",
          align: "right",
          label: "單價",
          field: "price",
        },
        {
          name: "tot",
          align: "right",
          label: "小計",
          field: "tot",
        },
      ],
      prodlist: [],
      prodlistv: [],
      custlist: [],
      custlistv: [],
      st101mv: [],
      st101s: [],
      st101sv: [],
      show1: false,
      show2: false,
      show3: false,
      show4: false,
      show5: false,
      show6: false,
      vstatus: true,
      statusname: "瀏覽",
      bodystatus: "新增",
      sprod_id: "",
      sa_date: "",
      scust_id: "",
      dlgmsg: "",
      ServerMsg: "",
    };
  },
  methods: {
    async st101del1(param) {
      this.ex = await this.st101del2(param);
    },
    st101del2(param) {
      return new Promise((res, rej) => {
        api
          .post("/st101dele", param)
          .then(async (res) => {
            this.ServerMsg = res.data["ServerMsg"];
          })
          .catch((error) => {
            this.ServerMsg = "ng";
          });
      });
    },
    async st101crud1(param) {
      this.ex = await this.st101crud2(param);
    },
    st101crud2(param) {
      return new Promise((res, rej) => {
        api
          .post("/st101crud", param)
          .then(async (res) => {
            this.ServerMsg = res.data["ServerMsg"];
            this.st101m.id101 = res.data["id101"];
          })
          .catch((error) => {
            this.ServerMsg = "ng";
          });
      });
    },
    async st101move1(param) {
      this.ex = await this.st101move2(param);
    },
    st101move2(param) {
      return new Promise((res, rej) => {
        api
          .post("/st101data", param)
          .then(async (res) => {
            this.st101mv = res.data["st101m"];
            this.st101m.id101 = this.st101mv[0]["id101"];
            this.st101m.a_date = this.st101mv[0]["a_date"];
            this.st101m.cust_id = this.st101mv[0]["cust_id"];
            this.st101m.cust_name = this.st101mv[0]["cust_name"];
            this.st101sv = res.data["st101s"];
            this.ServerMsg = "ok";
          })
          .catch((error) => {
            this.ServerMsg = "ng";
          });
      });
    },
    async getProd1() {
      this.ex = await this.getProd();
    },
    getProd() {
      const paramdata = { userkey: sessionStorage.getItem("userKey") };
      return new Promise((res, rej) => {
        api
          .post("/prods", paramdata)
          .then(async (res) => {
            this.prodlist = res.data;
            this.prodlistv = res.data;
          })
          .catch((error) => {
            this.ServerMsg = "ng";
          });
      });
    },
    async getCust1() {
      this.ex = await this.getCust();
    },
    getCust() {
      const paramdata = { userkey: sessionStorage.getItem("userKey") };
      return new Promise((res, rej) => {
        api
          .post("/custs", paramdata)
          .then(async (res) => {
            this.custlist = res.data;
            this.custlistv = res.data;
          })
          .catch((error) => {
            this.ServerMsg = "ng";
          });
      });
    },
    test07(n1, n2) {
      let vsec = "",
        s1 = "";
      let nX = 0;
      if (n1["sec"] == "") {
        if (n2 == "2" || n2 == "3") {
          this.dlgmsg = "沒有資料,無法編輯";
          if (n2 == "3") {
            this.dlgmsg = "沒有資料,無法刪除";
          }
          this.show4 = true;
        } else {
          vsec = "0010";
          this.bodystatus = "新增";
          this.st101ss.id101 = this.st101m.id101;
          this.st101ss.sec = vsec;
          this.st101ss.prod_id = "";
          this.st101ss.prod_name = "";
          this.st101ss.qty = "0";
          this.st101ss.price = "0";
          this.st101ss.tot = "0";
          this.show6 = true;
        }
      } else {
        this.st101ss.id101 = n1["id101"];
        this.st101ss.sec = n1["sec"];
        this.st101ss.prod_id = n1["prod_id"];
        this.st101ss.prod_name = n1["prod_name"];
        this.st101ss.qty = n1["qty"];
        this.st101ss.price = n1["price"];
        this.st101ss.tot = n1["tot"];
        if (n2 == "1") {
          this.st101sv.forEach((item) => {
            if (item["sec"] > vsec) {
              vsec = item["sec"];
            }
          });
          if (vsec == "") {
            vsec = "0010";
          } else {
            nX = parseInt(vsec, 10) + 10010;
            s1 = nX.toString();
            vsec = s1.substring(1, 100);
          }
          this.bodystatus = "新增";
          this.st101ss.id101 = this.st101m.id101;
          this.st101ss.sec = vsec;
          this.st101ss.prod_id = "";
          this.st101ss.prod_name = "";
          this.st101ss.qty = "0";
          this.st101ss.price = "0";
          this.st101ss.tot = "0";
          this.show6 = true;
        }
        if (n2 == "2") {
          this.bodystatus = "修改";
          this.show6 = true;
        }
        if (n2 == "3") {
          this.dlgmsg = "Body:請問要刪除本筆資料嗎?";
          this.show5 = true;
        }
      }
    },
    test03(evt, row) {
      this.show1 = false;
      this.st101ss.prod_id = row["prod_id"];
      this.st101ss.prod_name = row["prod_name"];
    },
    test11() {
      this.show6 = false;
      const v2 = {
        id101: this.st101ss.id101,
        sec: this.st101ss.sec,
        prod_id: this.st101ss.prod_id,
        prod_name: this.st101ss.prod_name,
        qty: this.st101ss.qty,
        price: this.st101ss.price,
        tot: this.st101ss.tot,
      };
      const v1 = [v2];
      if (this.bodystatus == "新增") {
        if (this.st101sv[0]["sec"] == "") {
          this.st101sv = v1;
        } else {
          this.st101sv.push(v2);
        }
      } else {
        this.st101sv.forEach((item, index) => {
          if (item["sec"] == this.st101ss.sec) {
            this.st101sv[index]["qty"] = this.st101ss.qty;
            this.st101sv[index]["price"] = this.st101ss.price;
            this.st101sv[index]["tot"] = this.st101ss.tot;
          }
        });
      }
    },
    test12() {
      this.show1 = true;
    },
    test10() {
      //javascript無法刪除特定元素，重做一個來替代
      let s1 = this.dlgmsg;
      let v1 = -1;
      if (s1 == "Body:請問要刪除本筆資料嗎?") {
        let s1 = this.dlgmsg;
        let v1 = [];
        if (s1 == "Body:請問要刪除本筆資料嗎?") {
          this.st101sv.forEach((item) => {
            if (item["sec"] != this.st101ss.sec) {
              v1.push(item);
            }
          });
          if (v1.length == 0) {
            v1 = [
              {
                id101: this.st101m.id101,
                sec: "",
                prod_id: "",
                prod_name: "",
                qty: "0",
                price: "0",
                tot: "0",
              },
            ];
          }
        }
        this.st101sv = v1;
        this.show5 = false;
      }
      if (s1 == "Header:請問要刪除本筆資料嗎?") {
        this.st101del1({
          userkey: sessionStorage.getItem("userKey"),
          id101: this.st101m.id101,
        });
        this.test01("03");
        this.show5 = false;
      }
    },
    test06() {
      //javascript substring真讓人吐血
      let s1 = "",
        s2 = "",
        s3 = "",
        symd = "";

      symd = this.sa_date;
      s1 = symd.substring(0, 4);
      s2 = symd.substring(5, 100);
      s2 = s2.substring(0, 2);
      s3 = symd.substring(8, 100);
      s3 = s3.substring(0, 2);
      this.st101m.a_date = s1 + s2 + s3;
      this.show3 = false;
    },
    test09() {
      this.show3 = true;
    },
    test08() {
      this.show2 = true;
    },
    test081(evt, rows) {
      this.show2 = false;
      this.st101m.cust_id = rows["cust_id"];
      this.st101m.cust_name = rows["cust_name"];
    },
    test082(n1) {
      if (n1 == "1") {
        const paramdata = {
          userkey: sessionStorage.getItem("userKey"),
          scust_id: this.scust_id,
        };
        api.post("/custss", paramdata).then((res) => {
          this.custlistv = res.data;
        });
      }
      if (n1 == "2") {
        this.scust_id = "";
        this.custlistv = this.custlist;
      }
      if (n1 == "3") {
        this.getcCust1();
        this.custlistv = this.custlist;
      }
    },
    test01(n1) {
      if (n1 == "01" || n1 == "02" || n1 == "03" || n1 == "04") {
        this.st101move1({
          userkey: sessionStorage.getItem("userKey"),
          sid101: this.st101m.id101,
          btn_no: n1,
        });
      }

      if (n1 == "05") {
        const vdate = Date.now();
        this.st101m.id101 = "新增單號";
        this.st101m.a_date = date.formatDate(vdate, "YYYYMMDD");
        this.sa_date = date.formatDate(vdate, "YYYYMMDD");
        this.st101m.cust_id = "";
        this.st101m.cust_name = "";
        this.st101sv = [
          {
            id101: this.st101m.id101,
            sec: "",
            prod_id: "",
            prod_name: "",
            qty: "0",
            price: "0",
            tot: "0",
          },
        ];
        this.vstatus = false;
        this.statusname = "新增";
        document.getElementById("bplstatus").innerText = this.statusname;
        document.getElementById("ida_date").focus();
      }
      if (n1 == "06") {
        this.vstatus = false;
        this.statusname = "修改";
        document.getElementById("bplstatus").innerText = this.statusname;
        document.getElementById("ida_date").focus();
      }
      if (n1 == "07") {
        this.dlgmsg = "Header:請問要刪除本筆資料嗎?";
        this.show5 = true;
      }
      if (n1 == "10") {
        //ok
        this.st101crud1({
          userkey: sessionStorage.getItem("userKey"),
          st101m: this.st101m,
          st101s: this.st101sv,
        });
        this.vstatus = true;
        this.st101move1({
          userkey: sessionStorage.getItem("userKey"),
          sid101: this.st101m.id101,
          btn_no: "00",
        });
        this.statusname = "瀏覽";
        document.getElementById("bplstatus").innerText = this.statusname;
      }
      if (n1 == "11") {
        this.vstatus = true;
        this.statusname = "瀏覽";
        document.getElementById("bplstatus").innerText = this.statusname;
        this.st101move1({
          userkey: sessionStorage.getItem("userKey"),
          sid101: this.st101mv[0]["id101"],
          btn_no: "00",
        });
      }
      if (n1 == "12") {
        this.$router.push("/emptydata");
      }
    },
    test05(n1) {
      if (n1 == "1") {
        const paramdata = {
          userkey: sessionStorage.getItem("userKey"),
          sprod_id: this.sprod_id,
        };
        api.post("/prodss", paramdata).then((res) => {
          this.prodlistv = res.data;
        });
      }
      if (n1 == "2") {
        this.sprod_id = "";
        this.prodlistv = this.prodlist;
      }
      if (n1 == "3") {
        this.getProd();
      }
    },
  },
  created() {
    this.getProd1();
    this.getCust1();
    this.test01("04");
  },
});
</script>

<style lang="sass" scoped>
.my-sticky-header-table
  /* height or max-height is important */
  height: 310px

  .q-table__top,
  .q-table__bottom,
  thead tr:first-child th
    /* bg color is important for th; just specify one */
    background-color: #c1f4cd

  thead tr th
    position: sticky
    z-index: 1
  thead tr:first-child th
    top: 0

  /* this is when the loading indicator appears */
  &.q-table--loading thead tr:last-child th
    /* height of all previous header rows */
    top: 48px
.my-card
  background-color: red
  text-color: blue
</style>