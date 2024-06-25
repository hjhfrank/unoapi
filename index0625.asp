<!--#include virtual="includes/sys_prelude1.asp"-->

<% On Error Resume Next '清除HTML標籤
  Function RemoveHTML( strText )
    Dim RegEx
    Set RegEx = New RegExp
    RegEx.Pattern = "<[^>]*>"
    RegEx.Global = True
    RemoveHTML = RegEx.Replace(strText, "")
    RemoveHTML = replace(RemoveHTML," "," ")
  End Function
%>

<%
  ' sdate=check_date(request("sdate"),0,0) 'edate=check_date(request("edate"),0,0)

  ' 出發日期範圍 sdate="2024-06-15" edate="2099-10-15" 'edate = "2024-09-15"

  ' 鎖定的關鍵字 searchword="情人節優惠" '行程區域
  this_category=0

  ' 資料分頁 page=skipbad(request("page"),1) '資料是否乙分頁呈現
  pageHave= 1

  if page = "" then
    page = 1
  end if
  ' response.write "<p>page: " & page & "<p/>" %>

  <!DOCTYPE html>
  <html class="easy-sidebar-active">

  <head>
    <title>搜尋最佳歐洲的旅遊行程．行健旅遊 UNOTOUR</title>
    <meta name="description"
      content="搜尋歐洲旅遊行程，我們有二十多年團體旅遊經驗，提供穩健的產品規劃，追求務實不浮誇的內容！由精煉細膩的達人領隊帶領出遊，陪同每位旅客貴賓走訪各國大城小鎮，一覽風光美景，您的旅程有我們一路相伴，讓每一次出發旅行都能帶回美好難忘的回憶。">
    <meta name="keywords" content="搜尋歐洲旅遊行程．行健旅遊 UNOTOUR">

    <meta name="robots" content="index, follow">
    <meta name="googlebot" content="index, follow">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <!-- Facebook -->
    <meta property="fb:app_id" content="1250691798388398" />
    <meta property="og:title" content="搜尋歐洲旅遊行程，行健旅遊 UNOTOUR" />
    <meta property="og:type" content="website" />
    <meta property="og:url" content="https://www.unotour.com.tw/search" />
    <meta property="og:image" content="https://www.unotour.com.tw/search/images/link.jpg" />
    <meta property="og:site_name" content="行健旅遊" />
    <meta property="og:description"
      content="搜尋歐洲旅遊行程，我們有二十多年團體旅遊經驗，提供穩健的產品規劃，追求務實不浮誇的內容！由精煉細膩的達人領隊帶領出遊，陪同每位旅客貴賓走訪各國大城小鎮，一覽風光美景，您的旅程有我們一路相伴，讓每一次出發旅行都能帶回美好難忘的回憶。" />
    <!--#include virtual="includes/UNO_GA.asp"-->
    <link rel="stylesheet" type="text/css" href="css/events2024.css" />
    <script src="https://cdn.tailwindcss.com"></script>
  </head>

  <body>
    <!-- 網頁資料內容-開始 STAR -->
    <!-- 最外圍區塊 Star -->
    <div class="Wap contentBack">

      <div class="container-fulid TOP_BOX">
        <div class="" id="TOP_BLOCK" style="margin-top: 0px;">
          <!--覆蓋大圖開始-->
          <!--# include virtual="include2/TOP_BLOCK.asp"-->
          <!--覆蓋大圖結束-->
        </div>

        <div class="row" id="TOP_BLOCK2">
          <!--#include virtual="include2/TOP_BLOCK2.asp"-->
        </div>

        <div class="container" id="TOP_MENU_BLOCK">
          <!-- MAIN Menu 區塊 Start -->
          <!--#include virtual="include2/TOP_MENU_BLOCK.asp"-->
          <!-- MAIN Menu 區塊 End -->
        </div>
      </div>


      <!-- *************************************************************************************** -->

      <div class="container-fulid eventsBack bandbgk areaBtBoxAll">
        <div class="container eventsBlockIn">
          <div class="row mt-10">
            <h1 class="text-3xl text-white">搜尋旅遊行程</h1>

          </div>
        </div>
      </div>


      <!-- 搜尋行程 STAR -->
      <div class="SEARCH_BLOCK container" id="search_app2">
        <div class="panel-body p-3 m-3">
          <form class="form flex flex-row flex-wrap items-center" method="post" name="savForm" action=""
            @submit.prevent="submitForm">
            <!-- 日期範圍選擇器 -->
            <date-picker v-model="timeRange.value1" type="date" range placeholder="Select date range"></date-picker>

            <select id="area" name="area" class="form-control w-[200px] m-3" v-model="selectedArea"
              @change="fetchMtypes">
              <option value="0" selected>選擇旅遊區域</option>
              <option v-for="item in areas" :value="item.NNO">{{ item.NEWS_TITLE }}</option>
            </select>

            <select id="mtype" name="mtype" class="form-control w-[200px] m-3" v-model="selectedMtype">
              <option value="0" selected>選擇旅遊國家</option>
              <option v-for="item in mtypes" :value="item.S_NNO">{{ item.S_NEWS_TITLE }}</option>
            </select>

            <select id="airline" name="airline" class="form-control w-[200px] m-3" v-model="selectedAirline"
              @change="logSelectedAirline">
              <option value="" selected>選擇航空</option>
              <option value="土耳其航空">土耳其航空</option>
              <option value="荷蘭皇家航空">荷蘭皇家航空</option>
              <option value="阿聯酋航空">阿聯酋航空</option>
            </select>
            <select id="apply" name="apply" class="form-control w-[200px] m-3" v-model="selectedApply"
              @change="logSelectedApply">
              <option value="" selected>選擇報名狀態</option>
              <option value="0">報名中</option>
              <option value="1">收訂報名中</option>
              <option value="2">已成團報名中</option>
              <option value="7">即將成團</option>
              <option value="6">可候補</option>
              <option value="8">滿團可候補</option>
            </select>
            <input type="text" name="searchword" v-model="searchword" placeholder="輸入搜索關鍵字"
              class="form-control w-[200px] m-3" hidden />
            <button id="searchBtn" type="submit" name="submit"
              class="form-control w-[150px] bg-slate-100 tracking-widest m-3">搜尋最佳行程</button>
          </form>
        </div>

        <div id="itf" class="bandbgk mb-16">
          <template v-if="isshow1">
            <a name="List"></a>
            <div class="container-fulid eventsBack">
              <div class="container eventsBlockIn">
                <div class="mx-auto p-10 bg-white my-10">
                  抱歉，目前沒有相關資料，敬請期待!!<br><br>近期尚無相關行程，如需行程訊息請電(02)2752-9293，將由專員為您服務！</div>
              </div>
            </div>
          </template>
          <template v-if="isshow2">
            <a name="List"></a>
            <div class="container-fulid eventsBack">
              <div class="container eventsBlockIn">
                <div class="container mx-auto text-lg leading-7 tracking-wider bg-gray-200">
                  <ul class="bg-white">
                    <li class="hidden bg-stone-300 border-b lg:block sm:py-1">
                      <ul class="flex flex-col font-semibold lg:flex-row">
                        <li class="p-2 lg:w-[167px] text-left lg:text-center">
                          <div>出發日期</div>
                        </li>
                        <li class="w-auto p-2 grow lg:w-[440px] text-center">
                          <div class="pb-2 text-xl">行程名稱</div>
                        </li>
                        <li class="p-2 lg:w-[140px]">
                          <div>航空公司</div>
                        </li>
                        <li class="p-2 lg:w-[120px]">
                          <div>團費</div>
                        </li>
                        <li class="p-2 lg:w-[110px]">
                          <div>團體狀態</div>
                        </li>
                        <li class="hidden p-2 sm:flex lg:w-[190px]">
                          <div>備註</div>
                        </li>
                      </ul>
                    </li>  
                    <template v-for="item in srlist">
                      <li class="p-4 border-b sm:py-4">
                        <ul class="flex flex-col lg:flex-row">
                          <li class="p-2 lg:w-[167px] text-left lg:text-center">
                            <div>
                              <i style="padding-right:5px;">
                                {{ item.SS_ADATE }}
                              </i>                            
                            </div>
                          </li>
                        </ul>
                      </li>
                    </template>                
                  </ul>                  
                </div>
              </div>
            </div>
          </template>
        </div>


        <!-- 最外圍區塊 End -->
        <!-- 網頁資料內容-結束 End -->

        <div class="footer-v1 FOOTER_BLOCK">
          <!-- Footer END-->
          <!--=== Footer Version 1 ===-->
          <!--#include virtual="include2/FOOTER_BLOCK.asp"-->
          <!--=== End Footer Version 1 ===-->
          <!-- Footer STAR-->
        </div>

        <!-- Star Javascript 區塊 End -->

        <!--#include virtual="include2/GoTop.asp"-->
        <!--#include virtual="includes/UNO_JS.asp"-->


        <script src="https://cdn.jsdelivr.net/npm/vue2-datepicker@3.11.1/index.min.js"></script>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/vue2-datepicker@3.11.1/index.min.css" />

        <script>
          new Vue({
            el: "#search_app2",
            data: function () {
              return {
                // 此處需要定義一個包含 value1 和 value2 的對象 timeRange
                timeRange: {
                  // 給定一個初始日期範圍
                  value1: [new Date(2024, 6, 1), new Date(2024, 7, 31)], // 注意月份是從 0 開始的
                  //value1: [moment().format(), moment().add(1, 'M').format()],
                  // 初始為空的日期時間範圍
                  value2: [],
                },
                areas: [], // 用於存儲從 API 加載的區域資料
                mtypes: [], // 用於存儲從 API 加載的 mtype 資料
                selectedArea: null, // 當前選中的區域 ID
                selectedMtype: null, // 當前選中的 mtype ID
                selectedAirline: null, // 當前選中的航空公司
                searchword: "",
                selectedApply: 0,
                srlist: [],
                isshow1: false,
                isshow2: false,
                isshow3: false,
              };
            },
            methods: {
              logSelectedApply() {
                //console.log("selectedApply: " + this.selectedApply);
              },
              logSelectedAirline() {
                //console.log("selectedAirline: " + this.selectedAirline);
              },
              //fetchAreas: function () {
              async fetchAreas() {
                await axios.get('http://localhost:5055/listx')
                  .then((response) => {
                    this.areas = response.data.listarea;
                    this.listc = response.data.listc;
                  }).catch((error) => {
                    console.log(error);
                  });
                //var self = this;
                //axios.get("/api/api-area.asp").then(function (response) {
                //  self.areas = response.data;
                //});
              },
              //fetchMtypes: function () {
              fetchMtypes() {
                let vkey = this.selectedArea
                this.mtypes = [];
                n1 = 0;
                n2 = this.listc.length - 1;
                while (n1 <= n2) {
                  if (this.listc[n1]['NNO'] === vkey) {
                    this.mtypes.push({ 'S_NNO': this.listc[n1]['S_NNO'], 'NNO': this.listc[n1]['NNO'], 'S_NEWS_TITLE': this.listc[n1]['S_NEWS_TITLE'] });
                  }
                  n1++;
                }
                //var self = this;
                //if (self.selectedArea) {
                //console.log("selectedArea: " + self.selectedArea);
                //  axios.get("/api/api-mtype.asp?area=" + self.selectedArea).then(function (response) {
                //    self.mtypes = response.data;
                //  });
              },

              //submitForm: function () {
              async submitForm() {
                const sdate = this.timeRange.value1[0] ? this.formatDate(this.timeRange.value1[0]) : "";
                const edate = this.timeRange.value1[1] ? this.formatDate(this.timeRange.value1[1]) : "";

                const area = this.selectedArea || "";
                console.log("selectedArea: " + area);

                const mtype = this.selectedMtype || "";
                console.log("selectedMtype: " + mtype);

                const airline = this.selectedAirline || "";
                console.log("selectedAirline: " + airline);

                const apply = this.selectedApply || "";
                console.log("selectedApply: " + apply);

                const searchword = this.searchword || "";
                console.log("searchword: " + searchword);

                //將所有參數轉parameter, 用post方式呼叫api
                const slist = {
                  'sdate': sdate,
                  'edate': edate,
                  'area': area,
                  'mtype': mtype,
                  'airline': airline,
                  'apply': apply,
                  'searchword': searchword
                };
                //queryString mark
                //console.log(param)
                await axios.post('http://localhost:5055/listx1', data = slist)
                  .then((response) => {
                    this.srlist = response.data.dt;
                    //console.log(this.srlist);
                  }).catch((error) => {
                    console.log(error);
                  });
                let n1=0;
                let n2=0;
                let recj={};
                if (this.srlist.length>0) {
                  n2=this.srlist.length-1;
                  while (n1<=n2)
                  {
                    recj=this.srlist[n1];
                    recj['sec']=n1;
                    this.srlist[n1]=recj;
                    n1++;
                  }
                  console.log(this.srlist);
                } 
                /*
                //這段mark,不要透過data.asp顯示資料,直接在vue中做
    
                const queryString = `sdate=${encodeURIComponent(sdate)}&edate=${encodeURIComponent(edate)}&nno=${encodeURIComponent(area)}&airline=${encodeURIComponent(airline)}&mtype=${encodeURIComponent(mtype)}&apply=${encodeURIComponent(apply)}&searchword=${encodeURIComponent(searchword)}`;
    
                //window.location.href = `Data.asp?${queryString}`;
                //console.log(data);
                $.get(`Data.asp?${queryString}`,
                  function (data) {
                    $("#itf").html(data);
                  }
                );
                */
                this.isshow1 = false;
                if (this.srlist.length > 0) {
                  this.isshow1 = false;
                  this.isshow2 = true;
                }

              },
              formatDate: function (date) {
                return `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`;
              },
            },
            mounted: function () {
              this.fetchAreas();
            },
          });
        </script>


        <script>
          //移除出發日列表樣式********************************************* 
          $(document).ready(function () {
            $(".S_Reminder").removeAttr('style');
            $(".S_Reminder span").removeAttr('style');
            $(".S_Reminder div").removeAttr('style');
          });
          //*************************************************************
        </script>

  </body>

  </html>