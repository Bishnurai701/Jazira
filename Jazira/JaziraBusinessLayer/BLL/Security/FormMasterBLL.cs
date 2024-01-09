using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JaziraBusinessLayer.DLL.Security;

namespace JaziraBusinessLayer.BLL.Security
{
  public class FormMasterBLL
  {
      #region Property Created By Bishnu Khaling

      private int _FormId;
           public int FormId
           {
             get { return _FormId; }
             set { _FormId = value; }
           }

      private string _DisplayName;
            public string DisplayName
            {
              get { return _DisplayName; }
              set { _DisplayName = value; }
            }

      private string _PagenName;
            public string PagenName
            {
              get { return _PagenName; }
              set { _PagenName = value; }
            }

      private int _FormCode;
            public int FormCode
            {
              get { return _FormCode; }
              set { _FormCode = value; }
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

           public bool Delete(int Id)
           {
               return FormMasterDLL.Delete(Id);
           }

           public DataTable SetFromPageName(int Id)
           {
               return FormMasterDLL.SetFromPageName(Id);
           }

           public static bool ValidationFormCode(string code, int Id)
           {
               return FormMasterDLL.ValidationFormCode(code,Id);
           }

           public static bool ValidationPageName(string pagename, int Id)
           {
               return FormMasterDLL.ValidationPageName(pagename,Id);
           }

           public bool Save(FormMasterBLL data)
           {
               return FormMasterDLL.Save(data);
           }

           public static DataTable GetFormCode(string fcode)
           {
               return FormMasterDLL.GetFormCode(fcode);
           }
  }
}
