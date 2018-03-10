using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INCOMETAX.Models
{
    public class FileDetailModel
    {
     
        public int FILE_ID { get; set; }
        public String FILE_NAME { get; set; }
        public DateTime ?CREATED_DATE { get; set; }
        public int? CREATED_BY { get; set; }
        public DateTime? ASSIGN_DATE { get; set; }
        public int? ASSIGN_STAFF_ID { get; set; }
        public bool? IS_ASSIGN { get; set; }

        public DateTime? DEADLINE_DATE { get; set; }
        public bool? IS_PENDING { get; set; }
        public int DAYS_OVER { get; set; }
        public bool? IS_COMPLETED { get; set; }
        
        public int? COMPLETE_IN_DAYS { get; set; }
        public FileDetailModel AllFilesDetails { get; set; }

    }
}