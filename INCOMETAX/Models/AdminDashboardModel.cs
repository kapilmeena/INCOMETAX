using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INCOMETAX.Models;

namespace INCOMETAX.Models
{
    public class SuperAdminDashboard
    {
        public List<FileDetailModel> AllFiles { get; set; }
        public List<UserModel> AllOfficerList { get; set; }
        public List<UserModel> AllOperator { get; set; }

    }
    public class AdminDashboardModel
    {
        public List<FileDetailModel> AllFiles { get; set; }
        public List<UserModel> AllOfficerList { get; set; }
        public List<UserModel> AllOperator { get; set; }

    }


}