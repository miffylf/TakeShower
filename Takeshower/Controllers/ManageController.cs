using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Common;
using Model;

namespace Takeshower.Controllers
{
    public class ManageController : Controller
    {
        // GET: Manage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Regist()
        {
            string Username = System.Web.HttpContext.Current.Request["username"].ToString();
            string emial = System.Web.HttpContext.Current.Request["emial"].ToString();
            string password = System.Web.HttpContext.Current.Request["password"].ToString();
            Userinfo userinfo = new Userinfo();
            userinfo.UserName = Username;
            userinfo.UserPwd = password;
            
            return View();
        }
    }
}