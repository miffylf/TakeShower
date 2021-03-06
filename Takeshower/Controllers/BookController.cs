﻿using Common;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Takeshower.Controllers
{
    public class BookController : Controller
    {
        /// <summary>
        /// 时间戳计时开始时间
        /// </summary>
        BookService BookService = new BookService();
        ProjectService ProjectService = new ProjectService();
        private static DateTime timeStampStartTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public string appId = string.Empty;
        public string corpId = string.Empty;
        public string timestamp = string.Empty;
        public string nonceStr = string.Empty;
        public string signature = string.Empty;
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取accesstoken
        /// </summary>
        /// <returns></returns>
        private string GetaccessToken()
        {
            appId = DingConfig.EAgentID;
            corpId = DingConfig.ECorpId;
            string corpSecret = DingConfig.ECorpSecret;
            nonceStr = Tools.randNonce();
            timestamp = Tools.timeStamp();
            string url = Request.Url.ToString();

            //这里重新实现
            string accessToken = EnterpriseBusiness.GetToken(corpId, corpSecret).access_token;
            return accessToken;
            //CreateUser(accessToken, userModel);
        }

        /// <summary>
        /// 获取jsapiTicket
        /// </summary>
        /// <returns></returns>
        private string GetTicket(string access_ticket)
        {
            //这里重新实现
            string jsTicket = EnterpriseBusiness.GetJsApiTicket(access_ticket).ticket;
            return jsTicket;
            //CreateUser(accessToken, userModel);
        }

        public ActionResult BookList()
        {
            string accessToken = GetaccessToken();
            UserModel temp = new UserModel();
            string code = System.Web.HttpContext.Current.Request["Code"];
            code = code.Replace('#', ' ').Trim();
            if (!string.IsNullOrEmpty(code))
            {
                temp = GetUserMode(accessToken, code);
            }
            UserInfo userInfo = EnterpriseBusiness.GetUserInfo(accessToken, temp.userid);
            DataTable dt = ProjectService.GetList("", "ProjectId desc").Tables[0];
            DataColumn dataColumn = new DataColumn("Last");
            dt.Columns.Add(dataColumn);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Session[dt.Rows[i]["ProjectId"].ToString()] != null)
                {
                    dt.Rows[i]["Last"] = Session[dt.Rows[i]["ProjectId"].ToString()];
                }
                else
                {
                    dt.Rows[i]["Last"] = dt.Rows[i]["ProjectCount"];
                }
            }
            ViewBag.UserInfo = userInfo;
            ViewBag.UserDId = userInfo.userid;
            ViewBag.UserName = userInfo.name;
            ViewBag.dt = dt;
            return View();
        }

        public ActionResult Booking()
        {
            string projectid = string.IsNullOrEmpty(System.Web.HttpContext.Current.Request["projectid"]) ? "0" : System.Web.HttpContext.Current.Request["projectid"].ToString();
            string projectname = string.IsNullOrEmpty(System.Web.HttpContext.Current.Request["projectname"]) ? string.Empty : System.Web.HttpContext.Current.Request["projectname"].ToString();
            string UserName = string.IsNullOrEmpty(System.Web.HttpContext.Current.Request["username"]) ? string.Empty : System.Web.HttpContext.Current.Request["username"].ToString();
            string duserid = string.IsNullOrEmpty(System.Web.HttpContext.Current.Request["duserid"]) ? string.Empty : System.Web.HttpContext.Current.Request["duserid"].ToString();
            Project project = ProjectService.GetModel(Convert.ToInt32(projectid));
            if (Session[project.ProjectId.ToString()] == null)
            {
                Session[project.ProjectId.ToString()] = project.ProjectCount;
                Session[project.ProjectId.ToString()] = Convert.ToInt32(Session[project.ProjectId.ToString()]) - 1;
                Book book = new Book();
                book.BookTime = DateTime.Now;
                book.DUserId = duserid;
                book.ProjectId = Convert.ToInt32(projectid);
                book.ProjectName = projectname;
                book.UserName = UserName;
                if (BookService.Add(book))
                {
                    return Content("Success");
                }
                else
                {
                    return Content("Fail");
                }
            }
            else
            {
                if (Convert.ToInt32(Session[project.ProjectId.ToString()]) > 0)
                {
                    Session[project.ProjectId.ToString()] = Convert.ToInt32(Session[project.ProjectId.ToString()]) - 1;
                    Book book = new Book();
                    book.BookTime = DateTime.Now;
                    book.DUserId = duserid;
                    book.ProjectId = Convert.ToInt32(projectid);
                    book.ProjectName = projectname;
                    if (BookService.Add(book))
                    {
                        return Content("Success");
                    }
                    else
                    {
                        return Content("Fail");
                    }
                }
                else
                {
                    return Content("Fail");
                }
            }

        }
        public UserModel GetUserMode(string access, string code)
        {
            UserModel temp = EnterpriseBusiness.GetCurrentUser(access, code);
            return temp;
        }

        public ActionResult BookInfo()
        {
            string duserid = string.IsNullOrEmpty(System.Web.HttpContext.Current.Request["duserid"]) ? string.Empty : System.Web.HttpContext.Current.Request["duserid"].ToString();
            DataTable dt = BookService.GetList(" DUserId='" + duserid + "' ", " BookId desc ").Tables[0];
            ViewBag.dt = dt;
            return View();
        }

        public ActionResult BookVerification()
        {
            string ProjectId = string.IsNullOrEmpty(System.Web.HttpContext.Current.Request["ProjectId"]) ? string.Empty : System.Web.HttpContext.Current.Request["ProjectId"].ToString();
            ViewBag.ProjectId = ProjectId;
            return View();
        }

        public ActionResult Verification()
        {
            string ProjectId = string.IsNullOrEmpty(System.Web.HttpContext.Current.Request["projectid"]) ? string.Empty : System.Web.HttpContext.Current.Request["projectid"].ToString();
            string userid = string.IsNullOrEmpty(System.Web.HttpContext.Current.Request["userid"]) ? string.Empty : System.Web.HttpContext.Current.Request["userid"].ToString();
            string username = string.IsNullOrEmpty(System.Web.HttpContext.Current.Request["username"]) ? string.Empty : System.Web.HttpContext.Current.Request["username"].ToString();

            if (!string.IsNullOrEmpty(userid))
            {
                Book item = new Book();
                item = BookService.DataRowToModel(BookService.GetList(" ProjectId = " + ProjectId + " and DuserId= '" + userid + "'", "").Tables[0].Rows[0]);
                item.IsVerification = true;
                if (BookService.Update(item))
                {
                    return Content("Success");
                }
                else
                {
                    return Content("Fail");
                }
            }
            else
            {
                return Content("Fail");
            }
        }

        public ActionResult ReturnBook()
        {
            string accessToken = GetaccessToken();
            UserModel temp = new UserModel();
            string ProjectId = string.IsNullOrEmpty(System.Web.HttpContext.Current.Request["ProjectId"]) ? string.Empty : System.Web.HttpContext.Current.Request["ProjectId"].ToString();
            string code = string.IsNullOrEmpty(System.Web.HttpContext.Current.Request["code"]) ? string.Empty : System.Web.HttpContext.Current.Request["code"].ToString();
            if (!string.IsNullOrEmpty(code))
            {
                temp = GetUserMode(accessToken, code);
            }
            UserInfo userInfo = EnterpriseBusiness.GetUserInfo(accessToken, temp.userid);
            ViewBag.UserName = userInfo.name;
            ViewBag.UserId = userInfo.userid;
            ViewBag.ProjectId = ProjectId;
            return View();
        }
    }
}