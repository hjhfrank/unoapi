using Models;
using Models.UNO;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Org.BouncyCastle.Asn1.TeleTrust;

namespace UNOTOUR.API
{
    public class TestApiController : ApiController
    {
        //private UNOContext db = new UNOContext();
        [HttpGet]
        [Route("API/testapi")]
        public string testapi()
        {
            return "ok";
        }

        [HttpPost]
        [Route("API/testapi1")]
        public string testapi1([FromBody] JObject obj1)
        {
            string s1 = obj1["somekey"].ToString();
            return s1;
        }
    }
 }