using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace AndroidMvcServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult MainIndex()
        {
            return View();
        }

        public ActionResult MainPage()
        {
            return View();
        }

        #region Tab页面切换
        [HttpPost]
        public JsonResult SetModuleId()
        {
            string ModuleId = Request.Form["ModuleId"];          //账户
            string ModuleName = Request.Form["ModuleName"];
            Session["SystemId"] = ModuleId;
            return Json(true);
        }

        //[HttpPost]
        //[Description("获取用户快捷菜单）")]
        //public JsonResult ShortcutsListJson()
        //{
        //    Stream stream = FileHelper.FileToStream(Server.MapPath("~/JsonData/ShortcutsListJson.json"));
        //    StreamReader reader = new StreamReader(stream);
        //    string text = reader.ReadToEnd();
        //    return Json(text);
        //}

        //[HttpPost]
        //[Description("获取用户菜单（抽屉式手风琴）")]
        //public JsonResult LoadAccordionMenu()
        //{
        //    string strlan = Request["lan"];
        //    if (string.IsNullOrEmpty(strlan))
        //    {
        //        if (Session["Language"] != null)
        //        {
        //            strlan = Session["Language"] as string;
        //        }
        //    }
        //    var UserId = RequestSession.GetSessionUser().UserId;
        //    IList list = (IList)StorePermission.Instance.GetModulePermission(UserId, strlan, null);
        //    return Json(JsonHelper.ListToJson<BPMS_ModulePermission>(list, "Date"));
        //}

        [HttpPost]
        public JsonResult SetLeave()
        {
            string ModuleId = Request.Form["ModuleId"];          //账户
            string ModuleName = Request.Form["ModuleName"];
            Session["SystemId"] = ModuleId;
            return Json(true);
        }
        #endregion

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string sb()
        {
            return "1231321";
        }


        public string sa()
        {
            return "sadsad";
        }
    }
}
