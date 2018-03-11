using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INCOMETAX.Models;
using INCOMETAX.DbModel;

namespace INCOMETAX.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Staff()
        {
            return View();
        }
        public ActionResult Admin()
        {
            var dashbordModel = new AdminDashboardModel();
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
