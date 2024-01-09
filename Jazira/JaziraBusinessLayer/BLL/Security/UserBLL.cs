using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JaziraBusinessLayer.DLL.Security;
using JaziraBusinessLayer.DLL.Security.Interface;

namespace JaziraBusinessLayer.BLL.Security
{
 public  class UserBLL
 {
     ISecurity encrypdecrypt = new EncryptDecryptDLL();
     #region Property Created By Bishnu Khaling
     private int _UserId;

          public int UserId
          {
            get { return _UserId; }
            set { _UserId = value; }
          }

     private string _UserCode;

          public string UserCode
          {
            get { return _UserCode; }
            set { _UserCode = value; }
          }

     private string _UserName;

           public string UserName
           {
             get { return _UserName; }
             set { _UserName = value; }
           }

     private string _LoginName;

            public string LoginName
            {
              get { return _LoginName; }
              set { _LoginName = value; }
            }

     private string _Password;

             public string Password
             {
               get { return _Password; }
               set { _Password = value; }
             }
             private char _IsLogin;

    public char IsLogin
             {
                 get { return _IsLogin; }
                 set { _IsLogin = value; }
             }

     private int _UserGroupId;

              public int UserGroupId
              {
                get { return _UserGroupId; }
                set { _UserGroupId = value; }
              }

     private int _BranchId;

               public int BranchId
               {
                 get { return _BranchId; }
                 set { _BranchId = value; }
               }

     private bool _SuperUser;

               public bool SuperUser
               {
                 get { return _SuperUser; }
                 set { _SuperUser = value; }
               }

     private bool _JobView;

               public bool JobView
               {
                 get { return _JobView; }
                 set { _JobView = value; }
               }

     private bool _GroupView;

              public bool GroupView
              {
                get { return _GroupView; }
                set { _GroupView = value; }
              }

     private bool _IsActive;

             public bool IsActive
             {
               get { return _IsActive; }
               set { _IsActive = value; }
             }

     private char _Status;

            public char Status
            {
              get { return _Status; }
              set { _Status = value; }
            }

     private int _LoginId;

           public int LoginId
           {
             get { return _LoginId; }
             set { _LoginId = value; }
           }

     private DateTime _LogDateTime;

           public DateTime LogDateTime
           {
             get { return _LogDateTime; }
             set { _LogDateTime = value; }
           }
     #endregion

           public DataTable GetUserGroup()
           {
               return UserDLL.GetUserGroup();
           }

           public bool Delete(int Id)
           {
               return UserDLL.Delete(Id);
           }

           public static bool ValidationUserCode(string UCode, int Id)
           {
               return UserDLL.ValidationUserCode(UCode,Id);
           }

           public static bool ValidationLoginName(string LogName, int Id)
           {
               return UserDLL.ValidationLoginName(LogName,Id);
           }

           public static DataTable SetUser(int Id)
           {
               return UserDLL.SetUser(Id);
           }

           public bool Save(UserBLL data)
           {
               return UserDLL.Save(data);
           }

           public static DataTable GetUserName(string UName)
           {
               return UserDLL.GetUserName(UName);
           }

           public string Encrypt(string password)
           {
               return encrypdecrypt.Encrypt(password);
           }
           public string Decrypt(string dcpassword)
           {
               return encrypdecrypt.Decrypt(dcpassword);
           }

           //public bool ValidationOldPa(int id, string password)
           //{
           //    return UserDLL.ValidationOldPas(id, password);
           //}

           public bool ChangePassword(string id, string password)
           {
               return UserDLL.ChangePassword(id,password);
           }

           public bool ValidationOldPassword(string id, string password)
           {
               return UserDLL.ValidationOldPassword(id, password);
           }

           public DataTable GetUserDetails(string loginname, string password)
           {
               return UserDLL.GetUserDetails(loginname, password); 
           }

           public void InsertLogin(int userid)
           {
                UserDLL.InsertLogin(userid);
           }
 }
}
