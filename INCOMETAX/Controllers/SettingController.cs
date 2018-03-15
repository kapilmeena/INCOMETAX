using INCOMETAX.DbModel;
using INCOMETAX.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INCOMETAX.Controllers
{
    public class SettingController : Controller
    {
        // GET: Setting
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profiles()
        {
            using (var db = new DataBaseDataContext())
            {
                try
                {
                    var dbusersList = (from user in db.USERs where user.RollId != 1 select user).ToList();
                    var userList = new List<UserModel>();
                    foreach (var user in dbusersList)
                    {
                        var userdetails = new UserModel();
                        userdetails.ID = user.ID;
                        userdetails.FirstName = user.FirstName;
                        userdetails.LastName = user.LastName;
                        userdetails.Email = user.Email;
                        userdetails.UserName = user.UserName;
                        userdetails.Password = user.Password;
                        userdetails.MobileNo = user.MobileNo;
                        userList.Add(userdetails);
                    }
                    ViewBag.AllOfficer = userList;
                    return View();
                }
                catch (Exception ex)
                {

                }
            }


            return View();
        }
        public ActionResult EditOfficerDetails( int uid)
        {
            using (var db = new DataBaseDataContext())
            {
                try
                {
                    var user = (from u in db.USERs where u.ID==uid select u).FirstOrDefault();
                    var userdetails = new UserModel();
                    userdetails.ID = user.ID;

                    userdetails.FirstName = user.FirstName;
                    userdetails.LastName = user.LastName;
                    userdetails.Email = user.Email;
                    userdetails.UserName = user.UserName;
                    userdetails.Password = user.Password;
                    userdetails.MobileNo = user.MobileNo;
                    return View(userdetails);
                }
                catch (Exception ex)
                {

                }


                return View();
            }

        }
        [HttpPost]
        public ActionResult EditOfficerDetails(UserModel user)
        {
            using (var db = new DataBaseDataContext())
            {
                try
                {
                    var userdetails = (from u in db.USERs where (u.ID==user.ID) select u).FirstOrDefault();

                    userdetails.ID = user.ID;

                    userdetails.FirstName = user.FirstName;
                    userdetails.LastName = user.LastName;
                    userdetails.Email = user.Email;
                    userdetails.UserName = user.UserName;
                    userdetails.Password = user.Password;
                    userdetails.MobileNo = user.MobileNo;
                    db.SubmitChanges();
                    return RedirectToAction("Profiles", "setting");
                }
                catch (Exception ex)
                {

                }


                return Json(0, JsonRequestBehavior.AllowGet);

            }
        }
    }
}