using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INCOMETAX.Models;
using INCOMETAX.DbModel;


using System.Net;

namespace INCOMETAX.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        Business _buss = new Business();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SendMessage()
        {
            var MessgeModel = new MessageModel();
            MessgeModel.officers = _buss.GetAllUSer().Where(m => m.RollId == "3").ToList();

            return View(MessgeModel);
        }
        [HttpPost]
        public ActionResult SendMessage(MessageModel MessgeModel)

        {
            var listSender = MessgeModel.officers.Where(m => m.Chekbox == true).ToList();
            var message = MessgeModel.MessageText;
            foreach (var item in listSender)
            {
                var messagelist = new List<MESSAGE_DETAIL>();
                {
                    var m = new MESSAGE_DETAIL();
                    m.CREATEDDATE = DateTime.Now;
                    m.TEXT = message;
                    m.SENDERID = item.ID;

                    messagelist.Add(m);
                }
                using (var db = new DataBaseDataContext())
                {
                    db.MESSAGE_DETAILs.InsertAllOnSubmit(messagelist);
                    db.SubmitChanges();
                }
            }
            string number = "";
            return View();
        }
        public ActionResult SendMessagex(string[] a, string text)
        {
            var listSender = new List<int>();
            foreach (var item in a)
            {

                listSender.Add(Convert.ToInt32(item));
            }
            var message = text;
            foreach (var item in listSender)
            {
                var messagelist = new List<MESSAGE_DETAIL>();
                {
                    var m = new MESSAGE_DETAIL();
                    m.CREATEDDATE = DateTime.Now;
                    m.TEXT = message;
                    m.SENDERID = item;

                    messagelist.Add(m);
                }
                using (var db = new DataBaseDataContext())
                {
                    db.MESSAGE_DETAILs.InsertAllOnSubmit(messagelist);
                    db.SubmitChanges();
                }
            }
            return View();
        }
        public ActionResult ShowMessage()
        {
            using (var db = new DataBaseDataContext())
            {
                var messgelist = new List<MessageModel>();
                var messages = db.MESSAGE_DETAILs.Where(m => m.SENDERID == Convert.ToInt32(Session["userid"])).OrderByDescending(d => d.CREATEDDATE).ToList();
                foreach (var item in messages)
                {
                    var m = new MessageModel();
                    m.MessageText = item.TEXT;
                    m.date = (DateTime)item.CREATEDDATE;
                    messgelist.Add(m);
                }
                ViewBag.Messages = messgelist;
            }
            return View();  
        }
    }
}

