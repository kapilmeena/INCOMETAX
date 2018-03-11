using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INCOMETAX.Models;

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
            var listnumber = MessgeModel.officers.Where(m => m.Chekbox == true).Select(m => m.MobileNo).ToList();
            var message = MessgeModel.MessageText;
            
            return View( );
        }
    }
}