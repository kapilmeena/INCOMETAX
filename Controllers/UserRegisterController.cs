using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INCOMETAX.DbModel;
using INCOMETAX.Models;


namespace INCOMETAX.Controllers
{
    public class UserRegisterController : Controller
    {
        // GET: UserRegister
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult RegisterSuperAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterSuperAdmin(UserModel reg)
        {
            using (var db = new DataBaseDataContext())
            {
                try
                {
                    var user = new USER();
                    user.ID = reg.ID;
                    user.RollId = 1;
                    user.FirstName = reg.FirstName;
                    user.LastName = reg.LastName;
                    user.Email = reg.Email;
                    user.UserName = reg.UserName;
                    user.Password = reg.Password;
                    user.MobileNo = reg.MobileNo;
                    user.Address = reg.Address;
                    db.USERs.InsertOnSubmit(user);
                    db.SubmitChanges();

                    return RedirectToAction("SuperAdminLogin", "Login");
                }
                catch (Exception ex) { }


                return View();
            }





        }
        public ActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterAdmin(UserModel reg)
        {
            using (var db = new DataBaseDataContext())
            {
                try
                {
                    var user = new USER();
                    user.ID = reg.ID;
                    user.RollId = 2;
                    user.FirstName = reg.FirstName;
                    user.LastName = reg.LastName;
                    user.Email = reg.Email;
                    user.UserName = reg.UserName;
                    user.Password = reg.Password;
                    user.MobileNo = reg.MobileNo;
                    user.Address = reg.Address;
                    db.USERs.InsertOnSubmit(user);
                    db.SubmitChanges();
                    return RedirectToAction("AdminLogin", "Login");
                }
                catch (Exception ex) { }


                return View();
            }





        }
        public ActionResult RegisterOfficer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterOfficer(UserModel reg)
        {

            using (var db = new DataBaseDataContext())
            {
                try
                {
                    var user = new USER();
                    user.ID = reg.ID;
                    user.RollId = 3;
                    user.FirstName = reg.FirstName;
                    user.LastName = reg.LastName;
                    user.Email = reg.Email;
                    user.UserName = reg.UserName;
                    user.Password = reg.Password;
                    user.MobileNo = reg.MobileNo;
                    user.Address = reg.Address;
                    db.USERs.InsertOnSubmit(user);
                    db.SubmitChanges();
                    return RedirectToAction("OfficerLogin", "Login");
                }
                catch (Exception ex) { }


                return View();
            }




        }
    }
}