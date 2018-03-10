using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INCOMETAX
{
    public class Enum
    {
        public enum NotificationType
        {
            error,
            success,
            warning,
            info
        }
        public enum Rolls
        {
            SuperAdmin=1,
            Admin=2,
            Officer=3
        }

    }
}