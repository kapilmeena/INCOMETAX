using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INCOMETAX.Models;
using INCOMETAX.DbModel;

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
                    return RedirectToAction("Officer", "Dashboard");
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

                if (loginuser.Email == "admin" && loginuser.Password == "admin123")
                {
                    Session["username"] = user.UserName;
                    Session["userid"] = user.ID;
                    return RedirectToAction("Admin", "Dashboard");
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

                if (loginuser.Email == "admin" && loginuser.Password == "admin123")
                {
                    Session["username"] = user.UserName;
                    Session["userid"] = user.ID;
                    return RedirectToAction("SuperAdmin", "Dashboard");
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
            return RedirectToAction( "index", "home");
        }
    }
}
