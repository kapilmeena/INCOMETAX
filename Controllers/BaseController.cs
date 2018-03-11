using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace INCOMETAX.Controllers
{
    public  abstract class BaseController : Controller
    {
        // GET: Base
        //public void Alert(string message, Enum.NotificationType notificationType)
        //{
        //    var msg = "swal('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "";
        //    TempData["notification"] = msg;
        //}
        public void Alert(string message, Enum.NotificationType notificationType)
        {
            var msg = "<script language='javascript'>swal('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "</script>";
            TempData["notification"] = msg;
        }
        public void Notify(string message, Enum.NotificationType notificationType)
        {
            var msg = "<script language='javascript'>swal('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "' ,{buttons: false,timer: 2000,})" + "</script>";
            TempData["notification"] = msg;
        }
        /// <summary>
        /// Sets the information for the system notification.
        /// </summary>
        /// <param name="message">The message to display to the user.</param>
        /// <param name="notifyType">The type of notification to display to the user: Success, Error or Warning.</param>
        public void Message(string message, Enum.NotificationType notifyType)
        {
            TempData["Notification2"] = message;

            switch (notifyType)
            {
                case Enum.NotificationType.success:
                    TempData["NotificationCSS"] = "alert-box success";
                    break;
                case Enum.NotificationType.error:
                    TempData["NotificationCSS"] = "alert-box errors";
                    break;
                case Enum.NotificationType.warning:
                    TempData["NotificationCSS"] = "alert-box warning";
                    break;

                case Enum.NotificationType.info:
                    TempData["NotificationCSS"] = "alert-box notice";
                    break;
            }
        }
    }
}