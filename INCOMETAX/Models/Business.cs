using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INCOMETAX.DbModel;
using System.Net;
using System.IO;

namespace INCOMETAX.Models
{
    public class Business
    {
        public List<FileDetailModel> getAllFilesList()
        {
            var AllFiles = new List<FileDetailModel>();
            using (var db = new DataBaseDataContext())
            {
                try
                {


                    var dbfileList = db.FILE_DETAILs.Where(f=>f.IS_DELETE==null).ToList();
                    foreach (var f in dbfileList)
                    {
                        var file = new FileDetailModel();
                        file.FILE_ID = f.FILE_ID;
                        file.FILE_NAME = f.FILE_NAME;
                        file.CREATED_DATE = (DateTime)f.CREATED_DATE;
                        file.ASSIGN_STAFF_ID = f.ASSIGN_STAFF_ID;
                        file.ASSIGN_DATE = f.ASSIGN_DATE;
                        file.IS_ASSIGN = f.IS_ASSIGN;
                        file.COMPLETE_IN_DAYS = f.COMPLETE_IN_DAYS;
                        file.DEADLINE_DATE = f.DEADLINE_DATE;
                        file.IS_PENDING = f.IS_PENDING;
                        file.IS_COMPLETED = f.IS_COMPLETED;
                        file.CREATED_BY = f.CREATED_BY;
                        AllFiles.Add(file);
                    }
                }
                catch (Exception)
                {


                }



            }
            return AllFiles;
        }
        public List<UserModel> GetAllUSer()
        {
            var AlluserList = new List<UserModel>();

            using (var db = new DataBaseDataContext())
            {
                try
                {
                    var allDbUser = db.USERs;
                    foreach (var user in allDbUser)
                    {
                        var u = new UserModel();
                        u.ID = user.ID;
                        u.FirstName = user.FirstName;
                        u.LastName = user.LastName;
                        u.Email = user.Email;
                        u.UserName = user.UserName;
                        u.Password = user.Password;
                        u.RollId =Convert.ToString( user.RollId);
                        u.MobileNo = user.MobileNo;
                        AlluserList.Add(u);

                    }
                   

                }
                catch (Exception)
                {

                    throw;
                }

                return AlluserList;

            }

        }
        public bool SendFileAssignedMessage(int userId,String FileName)
        {

            using (var db = new DataBaseDataContext())
            {
                var User = db.USERs.Where(u => u.ID == userId).FirstOrDefault();
                String url = "https://2factor.in/API/R1/?module=TRANS_SMS&apikey=24c78e13-211e-11e8-a895-0200cd936042&to=" + User.MobileNo + "&from=ASSIGN&templatename=ASSIGNED&var1=" +User.FirstName+","+ FileName + "&var2=" + "";
                try
                {


                    HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(string.Format(url));
                    webReq.Method = "GET";
                    HttpWebResponse webResponse = (HttpWebResponse)webReq.GetResponse();

                    //I don't use the response for anything right now. But I might log the response answer later on.   
                    Stream answer = webResponse.GetResponseStream();
                    StreamReader _recivedAnswer = new StreamReader(answer);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}