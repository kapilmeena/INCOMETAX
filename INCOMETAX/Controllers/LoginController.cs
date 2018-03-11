using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INCOMETAX.Models;
using INCOMETAX.DbModel;
using System.Web.Security;

namespace INCOMETAX.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OfficerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OfficerLogin(LoginModel loginuser)
        {
            using (var db = new DataBaseDataContext())
            {
                var user = (from u in db.USERs where (u.UserName.Equals(loginuser.Email) || u.Email.Equals(loginuser.Email) && u.Password.Equals(loginuser.Password)&&u.RollId==3) select u).FirstOrDefault();
                if (user != null)
                {
                    Session["username"] = user.UserName;
                    Session["userid"] = user.ID;
                    Session["Role"] = user.RollId;
                    FormsAuthentication.SetAuthCookie(user.Email, false);

                    var authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, Convert.ToString(user.RollId));
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("index", "Dashboard");
                }

            }
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(LoginModel loginuser)
        {
            using (var db = new DataBaseDataContext())
            {
                var user = (from u in db.USERs where (u.UserName.Equals(loginuser.Email) || u.Email.Equals(loginuser.Email) && u.Password.Equals(loginuser.Password) && u.RollId == 2) select u).FirstOrDefault();

                if (user!=null)
                {
                    Session["username"] = user.UserName;
                    Session["userid"] = user.ID;
                    Session["Role"] = user.RollId;

                    FormsAuthentication.SetAuthCookie(user.Email, false);

                    var authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, Convert.ToString(user.RollId));
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("index", "Dashboard");
                }

            }
            return View();
        }
        public ActionResult SuperAdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SuperAdminLogin(LoginModel loginuser)
        {
            using (var db = new DataBaseDataContext())
            {
                var user = (from u in db.USERs where (u.UserName.Equals(loginuser.Email) || u.Email.Equals(loginuser.Email) && u.Password.Equals(loginuser.Password) && u.RollId == 1) select u).FirstOrDefault();

                if (user!=null)
                {
                    Session["username"] = user.UserName;
                    Session["userid"] = user.ID;
                    Session["Role"] = user.RollId;

                    FormsAuthentication.SetAuthCookie(user.Email, false);

                    var authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, Convert.ToString(user.RollId));
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("index", "Dashboard");
                }

            }
            return View();
        }

        //public ActionResult Register()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Register(RegisterModel reg)
        //{
        //    using (var db = new DataBaseDataContext())
        //    {
        //        try
        //        {
        //            var user = new USER();
        //            user.ID = reg.ID;
        //            user.FirstName = reg.FirstName;
        //            user.LastName = reg.LastName;
        //            user.Email = reg.Email;
        //            user.UserName = reg.UserName;
        //            user.Password = reg.Password;
        //            user.MobileNo = reg.MobileNo;
        //            db.USERs.InsertOnSubmit(user);
        //            db.SubmitChanges();
        //        }
        //        catch (Exception ex) { }


        //        return View();
        //    }
        //}
        public ActionResult Logout()
        {
            Session.Abandon();

            FormsAuthentication.SignOut();
            return RedirectToAction( "index", "home");
        }
    }
}
