using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INCOMETAX.Models;
using INCOMETAX.DbModel;
using INCOMETAX.Models;

namespace INCOMETAX.Controllers
{
    public class DashBoardController : Controller
    {
        Business _buss = new Business();
        [Authorize(Roles ="1,2,3")]
        public ActionResult index()
        {
            var roll = Convert.ToInt32(Session["Role"]);
            if (Convert.ToInt32(Session["Role"]) == 1)
            {
                ViewBag.AllFiles = _buss.getAllFilesList();
                ViewBag.AllOfficers = _buss.GetAllUSer().Where(m=>m.RollId=="3");
                ViewBag.AllOperator = _buss.GetAllUSer().Where(m => m.RollId == "2"); ;

                return View("SuperAdmin");

            }
            if (Convert.ToInt32(Session["Role"]) == 2)
            {
                var adminModel = new AdminDashboardModel();
                ViewBag.AllFiles = _buss.getAllFilesList();

                //return View("Admin");
               return RedirectToAction("ShowAllFiles", "File");

            }
            if (Convert.ToInt32(Session["Role"]) == 3)
            {
                //return View("Officer");
                return RedirectToAction("getFIleStaff", "File");

            }




            return View();
        }




        // GET: DashBoard
        public ActionResult Staff()
        {
            return View();
        }
        public ActionResult Admin()
        {
            var dashbordModel = new SuperAdminDashboard();
            using (var db = new DataBaseDataContext())
            {
                try
                {
                    var files = db.FILE_DETAILs;
                    var fileList = new List<FileDetailModel>();
                    foreach (var f in files)
                    {
                        var nf = new FileDetailModel();
                        nf.FILE_ID = f.FILE_ID;
                        nf.FILE_NAME = f.FILE_NAME;
                        nf.CREATED_DATE = (DateTime)f.CREATED_DATE;
                        nf.ASSIGN_STAFF_ID = f.ASSIGN_STAFF_ID;
                        nf.ASSIGN_DATE = f.ASSIGN_DATE;
                        nf.IS_ASSIGN = f.IS_ASSIGN;
                        nf.COMPLETE_IN_DAYS = f.COMPLETE_IN_DAYS;
                        nf.DEADLINE_DATE = f.DEADLINE_DATE;
                        nf.IS_PENDING = f.IS_PENDING;
                        nf.IS_COMPLETED = f.IS_COMPLETED;
                        nf.CREATED_BY = f.CREATED_BY;
                        fileList.Add(nf);

                    }

                    dashbordModel.AllFiles = fileList;
                }
                catch (Exception ex)
                {

                }

            }
            return View(dashbordModel);
        }
       





    }
}
