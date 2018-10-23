using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MikrotikAPIServer.Controllers
{
    public class NguyenController : ApiController
    {
        [HttpPost]
        public string Hello(JObject j)
        {
            string str = j.SelectToken("token").ToString();
            if(str.Equals("1"))
            {
                return "1";
            }
            return "a";
        }
    }
}
