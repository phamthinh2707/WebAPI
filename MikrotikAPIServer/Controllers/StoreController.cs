using MikrotikAPIServer.Models;
using MikrotikAPIServer.Repository;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MikrotikAPIServer.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Store/Hello/{brandId}")]
        public JsonResult Hello(string brandId, string token)
        {
            StoreRepository repo = new StoreRepository();
            bool check = repo.checkStore(brandId, token);
            if(check == true)
            {
                var v = repo.getStoreName(brandId, token);
                return Json(v, JsonRequestBehavior.AllowGet);
            } else
            {
                return Json("Wrong Credential!", JsonRequestBehavior.AllowGet);
            }
        }

    }
}