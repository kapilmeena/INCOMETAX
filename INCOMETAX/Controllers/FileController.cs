using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INCOMETAX.Models;
using INCOMETAX.DbModel;
using static INCOMETAX.Enum;

namespace INCOMETAX.Controllers
{
    [Authorize(Roles = "1,2,3")]
    public class FileController : BaseController
    {
        // GET: File
        Business _buss = new Business();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddNEWFile()
        {
            using (var db = new DataBaseDataContext())
            {
                ViewBag.Staffs = (from u in db.USERs where u.RollId == 3 select u).ToList();

            }
            return View();
        }
        [HttpPost]
        public ActionResult AddNEWFile(FileDetailModel file)
        {
            using (var db = new DataBaseDataContext())
            {
                FILE_DETAIL newfile = new FILE_DETAIL();
                try
                {
                    if ((file.FILE_ID != 0))
                    {
                        newfile = db.FILE_DETAILs.Where(m => m.FILE_ID == file.FILE_ID).FirstOrDefault();
                        newfile.FILE_NAME = file.FILE_NAME;
                        if (file.ASSIGN_STAFF_ID != null)
                        {
                            newfile.ASSIGN_STAFF_ID = file.ASSIGN_STAFF_ID;
                            newfile.ASSIGN_DATE = DateTime.Now;
                            newfile.DEADLINE_DATE = DateTime.Now.AddDays(Convert.ToDouble(file.COMPLETE_IN_DAYS));
                            newfile.IS_ASSIGN = true;
                            _buss.SendFileAssignedMessage((int)file.ASSIGN_STAFF_ID, file.FILE_NAME);

                        }
                        newfile.CREATED_DATE = DateTime.Now;
                        newfile.COMPLETE_IN_DAYS = file.COMPLETE_IN_DAYS;
                        newfile.IS_COMPLETED = false;
                        newfile.IS_PENDING = true;
                        db.SubmitChanges();
                        Alert("This is success message", NotificationType.success);
                        ViewBag.Staffs = (from u in db.USERs select u).ToList();
                        return RedirectToAction("index", "dashboard");

                    }
                    else
                    {

                        newfile.FILE_NAME = file.FILE_NAME;
                        if (file.ASSIGN_STAFF_ID != null)
                        {
                            newfile.ASSIGN_STAFF_ID = file.ASSIGN_STAFF_ID;
                            newfile.ASSIGN_DATE = DateTime.Now;
                            newfile.DEADLINE_DATE = DateTime.Now.AddDays(Convert.ToDouble(file.COMPLETE_IN_DAYS));
                            newfile.IS_ASSIGN = true;

                        }
                        newfile.CREATED_DATE = DateTime.Now;
                        newfile.COMPLETE_IN_DAYS = file.COMPLETE_IN_DAYS;
                        newfile.IS_COMPLETED = false;
                        newfile.IS_PENDING = true;
                        db.FILE_DETAILs.InsertOnSubmit(newfile);
                        db.SubmitChanges();
                        Alert("This is success message", NotificationType.success);
                        ModelState.Clear();
                        ViewBag.Staffs = (from u in db.USERs select u).ToList();
                        return View();
                    }
                }
                catch (Exception ex)
                {


                }




            }

            return View();
        }
        public ActionResult DeleteFile(int fileid)
        {
            using (var db = new DataBaseDataContext())
            {
                var f = db.FILE_DETAILs.Where(m => m.FILE_ID == fileid).FirstOrDefault();
                f.IS_DELETE = true;
                Alert("File Deleted Successfully", NotificationType.success);
                db.SubmitChanges();
            }

            return RedirectToAction("ShowAllFiles", "File");
        }
        public PartialViewResult FileDetails(int fileid)
        {
            using (var db = new DataBaseDataContext())
            {
                try
                {
                    var f = db.FILE_DETAILs.Where(m => m.FILE_ID == fileid && m.IS_DELETE != true).FirstOrDefault();


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
                    ViewBag.Staffs = (from u in db.USERs where u.RollId == 3 select u).ToList();
                    return PartialView(nf);

                }
                catch (Exception e)
                {
                    return null;
                }
            }

        }
        public ActionResult ShowAllFiles()
        {
            using (var db = new DataBaseDataContext())
            {
                try
                {
                    var uid = Session["userid"];
                    var files = db.FILE_DETAILs.Where(m => m.IS_DELETE == null).OrderByDescending(x => x.CREATED_DATE);
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
                    ViewBag.AllFiles = fileList;

                    return View();
                }
                catch (Exception ex)
                {

                }
                return View();


            }

        }
        public ActionResult getFIleStaff()
        {
            using (var db = new DataBaseDataContext())
            {
                try
                {
                    var uid = Session["userid"];
                    var files = db.FILE_DETAILs.Where((m => m.ASSIGN_STAFF_ID.Equals(Session["userid"]) && m.IS_DELETE == null)).ToList();
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

                    return View(fileList);
                }
                catch (Exception ex)
                {

                }
                return View();


            }
        }

        public ActionResult ChngeToComplete(string FileId)
        {
            using (var db = new DataBaseDataContext())
            {
                var Fid = Convert.ToInt32(FileId);
                var file = db.FILE_DETAILs.Where(m => m.FILE_ID == Fid).FirstOrDefault();
                file.IS_COMPLETED = true;
                file.IS_PENDING = false;
                db.SubmitChanges();
                return RedirectToAction("getFIleStaff");
            }
        }

    }
}