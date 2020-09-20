using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Common;
using Model;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;

namespace Takeshower.Controllers
{
    public class ManageController : Controller
    {
        ProjectService ProjectService = new ProjectService();
        BathService BathService = new BathService();
        UserinfoService UserinfoService = new UserinfoService();
        BookService BookService = new BookService();
        const int PageSize = 10;
        int CurrentPage = 1;
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
            userinfo.Email = emial;
            if (UserinfoService.Add(userinfo))
            {
                return Content("Success");
            }
            else
            {
                return Content("Fail");
            }

        }

        public ActionResult Login()
        {
            string Username = System.Web.HttpContext.Current.Request["username"].ToString();
            string password = System.Web.HttpContext.Current.Request["password"].ToString();
            if (UserinfoService.GetList(" UserName = '" + Username.Trim() + "' and UserPwd ='" + password.Trim() + "'").Tables[0].Rows.Count > 0)
            {
                return Content("Success");
            }
            else
            {
                return Content("Fail");
            }

        }

        public ActionResult Manage()
        {
            DataTable dt = new DataTable();
            string Current = System.Web.HttpContext.Current.Request["Current"] == null ? "1" : System.Web.HttpContext.Current.Request["Current"].ToString();
            CurrentPage = Convert.ToInt32(Current);
            dt = ProjectService.GetListByPageOne("", "ProjectId desc", CurrentPage, PageSize).Tables[0];
            int total = ProjectService.GetRecordCount("");
            ViewBag.Table = dt;
            ViewBag.Current = CurrentPage;
            ViewBag.Total = (total + PageSize - 1) / PageSize;
            return View();
        }

        public ActionResult AddProject()
        {
            DataTable dt = new DataTable();
            dt = BathService.GetList("").Tables[0];
            ViewBag.Bath = dt;
            return View();
        }
        public ActionResult AddBath()
        {

            return View();
        }

        public ActionResult Submit()
        {
            Project project = new Project();
            int projectname = System.Web.HttpContext.Current.Request["projectname"] == null ? -1 : Convert.ToInt32(System.Web.HttpContext.Current.Request["projectname"].ToString());
            string startTime = System.Web.HttpContext.Current.Request["startTime"] == null ? "1900-01-01 00:00:00" : System.Web.HttpContext.Current.Request["startTime"].ToString();
            string endTime = System.Web.HttpContext.Current.Request["endTime"] == null ? "1900-01-01 00:00:00" : System.Web.HttpContext.Current.Request["endTime"].ToString();
            int count = System.Web.HttpContext.Current.Request["count"] == null ? 0 : Convert.ToInt32(System.Web.HttpContext.Current.Request["count"]);
            //string lastName = DateTime.Now.Millisecond.ToString() + hdClaseesId.ToString() + ".Jpeg";
            //string url = Server.MapPath("~/upload/") + lastName;
            //Bitmap bitmapTemp = Common.QRcode.CreateQRcode("http://10.150.41.56:8081/StudentApply/Index?ClassesId=" + hdClaseesId + "");
            //bitmapTemp.Save(url, ImageFormat.Jpeg);

            //classesMode.QRCode = "../../upload/" + lastName;
            project.ProjectCount = count;
            project.ProjectEndTime = Convert.ToDateTime(endTime);
            project.ProjectName = BathService.GetModel(projectname).BathName;
            project.ProjectStartTime = Convert.ToDateTime(startTime);
            project.BathId = projectname;
            int id = ProjectService.Add(project);

            string lastName = DateTime.Now.Millisecond.ToString() + id.ToString() + ".Jpeg";
            string url = Server.MapPath("~/upload/") + lastName;
            Bitmap bitmapTemp = Common.QRcode.CreateQRcode("http://10.150.41.56:8081/Book/BookVerification?ProjectId=" + id + "");
            bitmapTemp.Save(url, ImageFormat.Jpeg);

            string tmepUrl = "../upload/" + lastName;
            Project temp = new Project();
            temp = ProjectService.GetModel(id);
            temp.Qrcode = tmepUrl;

            if (ProjectService.Update(temp))
            {
                return Content("Success");
            }
            else
            {
                return Content("Fail");
            }

        }

        public ActionResult SubmitBath()
        {
            Bath bath = new Bath();
            string projectname = System.Web.HttpContext.Current.Request["projectname"] == null ? "" : System.Web.HttpContext.Current.Request["projectname"].ToString();
            bath.BathName = projectname;
            if (string.IsNullOrEmpty(projectname))
            {
                return Content("Fail");
            }
            else
            {
                if (BathService.Add(bath))
                {
                    return Content("Success");
                }
                else
                {
                    return Content("Fail");
                }
            }
        }

        public ActionResult BookList()
        {
            DataTable dt = new DataTable();
            string Current = System.Web.HttpContext.Current.Request["Current"] == null ? "1" : System.Web.HttpContext.Current.Request["Current"].ToString();
            CurrentPage = Convert.ToInt32(Current);
            dt = BookService.GetListByPageOne("", "BookId desc", CurrentPage, PageSize).Tables[0];
            int total = ProjectService.GetRecordCount("");
            ViewBag.Table = dt;
            ViewBag.Current = CurrentPage;
            ViewBag.Total = (total + PageSize - 1) / PageSize;
            return View();
        }
    }
}