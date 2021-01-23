using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baomingadmin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string id)
        {
            return View();
        }

        public ActionResult Login(string id, string username, string message)
        {
            if (String.IsNullOrEmpty(message))
            {
                message = "请输入用户名密码";
            }
            else
            {
                message = string.Format("<span style='color:red'>{0}</span>", message);
            }
            string password = "";
            if (String.IsNullOrEmpty(username))
            {
                Access.User.Login.LoginGetRemember(ref username, ref password, ref message);
                if (!String.IsNullOrEmpty(username)){
                    ViewBag.CHECKED = "checked=\"checked\"";
                }
            }
            ViewBag.USERNAME = username;
            ViewBag.PASSWORD = password;
            ViewBag.MESSAGE = message;
            return View();
        }

        public ActionResult LoginDo(string id, string username, string password, string remember)
        {
            string message = "";
            Model.Login.LoginStatus loginStatus = Access.User.Login.LoginDo(username, password, ref message);
            if(loginStatus!= Model.Login.LoginStatus.SUCCESS)
            {
                return RedirectToAction("Login", "Login", new { id = id, username = username, message = Function.FEnum.GetDescription(loginStatus) });
            }
            if (remember == "on")
            {
                Access.User.Login.LoginRemember(username, password, ref message);
            }
            else
            {
                Access.User.Login.LoginRememberClear(ref message);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}