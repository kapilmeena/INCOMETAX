using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INCOMETAX.DbModel;
using INCOMETAX.Models;
using System.IO;
using System.Net;

namespace INCOMETAX
{
    public class JobsMethods
    {


        public static void DailyMessagePercentWise()
        {
            using (var db = new DataBaseDataContext())
            {
                var NotCompletedfiles = db.FILE_DETAILs.Where(m => m.IS_ASSIGN == true && m.IS_COMPLETED != true).ToList();
                foreach (var file in NotCompletedfiles)
                {
                    //for 75 %over 
                    var num = 100 / 2;
                    int seventyfivepercent = (Convert.ToInt32(file.COMPLETE_IN_DAYS))*75/100;
                    int eightyPercent =Convert.ToInt16((file.COMPLETE_IN_DAYS)*0.80);
                    int nintyPercent = Convert.ToInt16((file.COMPLETE_IN_DAYS) * 0.90);
                    var DAYS_OVER = GetWorkingDays((DateTime)file.ASSIGN_DATE, DateTime.Now);
                    if (DAYS_OVER == nintyPercent|| DAYS_OVER== eightyPercent||DAYS_OVER== seventyfivepercent)
                    {
                        var User = db.USERs.Where(u => u.ID == file.ASSIGN_STAFF_ID).FirstOrDefault();
                        //String url = "https://2factor.in/API/R1/?module=TRANS_SMS&apikey=24c78e13-211e-11e8-a895-0200cd936042&to=" + User.MobileNo + "&from=ASSIGN&templatename=ASSIGNED&var1=" + User.FirstName + "," + file.FILE_NAME+ "&var2=" + "";
                        String url = "https://2factor.in/API/R1/?module=TRANS_SMS&apikey=24c78e13-211e-11e8-a895-0200cd936042&to=" + User.MobileNo + "&from=SECKUL&templatename=C3SECR&var1=" + User.FirstName + " " + file.FILE_NAME + "&var2=" + file.FILE_NAME;

                        try
                        {


                            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(string.Format(url));
                            webReq.Method = "GET";
                            HttpWebResponse webResponse = (HttpWebResponse)webReq.GetResponse();

                            //I don't use the response for anything right now. But I might log the response answer later on.   
                            Stream answer = webResponse.GetResponseStream();
                            StreamReader _recivedAnswer = new StreamReader(answer);
                          
                        }
                        catch (Exception e)
                        {
                           
                        }

                    }
                  
                   


                }

            }
        }
        public static void sendDaily()
        {
            using (var db = new DataBaseDataContext())
            {
                try
                {
                    var files = new List<FileDetailModel>();
                    files = (from F in db.FILE_DETAILs
                             where F.IS_COMPLETED != true
                             select new FileDetailModel
                             {
                                 ASSIGN_DATE = F.ASSIGN_DATE,
                                 FILE_NAME = F.FILE_NAME,
                                 FILE_ID = F.FILE_ID,

                                 CREATED_DATE = F.CREATED_DATE,
                                 ASSIGN_STAFF_ID = F.ASSIGN_STAFF_ID,

                                 IS_ASSIGN = F.IS_ASSIGN,
                                 COMPLETE_IN_DAYS = F.COMPLETE_IN_DAYS,
                                 DEADLINE_DATE = F.DEADLINE_DATE,
                                 IS_PENDING = F.IS_PENDING,
                                 IS_COMPLETED = F.IS_COMPLETED,
                                 CREATED_BY = F.CREATED_BY
                             }).ToList();
                    foreach (var item in files)
                    {
                        item.DAYS_OVER = GetWorkingDays((DateTime)item.CREATED_DATE, DateTime.Now);
                    }
                    var DistinctOfficer = db.FILE_DETAILs.Where(m => m.IS_COMPLETED != true && m.ASSIGN_STAFF_ID != null).Select(M => M.ASSIGN_STAFF_ID).Distinct().ToList();
                    foreach (var item in DistinctOfficer)
                    {

                        var COUNT = (from F in files where F.ASSIGN_STAFF_ID == item && F.DAYS_OVER >= 40 select F).Count();
                        var n = (from s in db.USERs where s.ID == (int)item select s).FirstOrDefault();
                        String url = "https://2factor.in/API/R1/?module=TRANS_SMS&apikey=24c78e13-211e-11e8-a895-0200cd936042&to="+ "917974411038" + "&from=SECKUL&templatename=C3SECR&var1="+n.FirstName+" "+n.LastName+"&var2="+COUNT;
                        try
                        {


                            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(string.Format(url));
                            webReq.Method = "GET";
                            HttpWebResponse webResponse = (HttpWebResponse)webReq.GetResponse();

                            //I don't use the response for anything right now. But I might log the response answer later on.   
                            Stream answer = webResponse.GetResponseStream();
                            StreamReader _recivedAnswer = new StreamReader(answer);
                        }
                        catch (Exception e)
                        {
                        }
                    }
                }
                catch (Exception e)
                {
                }
            }





        }
        public static int GetWorkingDays(DateTime from, DateTime to)
        {
            var dayDifference = (int)to.Subtract(from).TotalDays;
            return Enumerable
                .Range(1, dayDifference)
                .Select(x => from.AddDays(x))
                .Count(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday);
        }


    }
}