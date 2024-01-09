using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JaziraBusinessLayer.DLL.General;

namespace JaziraBusinessLayer.BLL.General
{
   public class WorkingSectionBLL
   {
       #region Property Created By Bishnu Khaling

        private int _WorkingSectionId;
            public int WorkingSectionId
            {
              get { return _WorkingSectionId; }
              set { _WorkingSectionId = value; }
            }

       private int _WorkingSectionCode;
            public int WorkingSectionCode
            {
              get { return _WorkingSectionCode; }
              set { _WorkingSectionCode = value; }
            }

       private string _WorkingSectionName;
            public string WorkingSectionName
            {
              get { return _WorkingSectionName; }
              set { _WorkingSectionName = value; }
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

            public DataTable SetWorkingSectionName(int Id)
            {
                return WorkingSectionDLL.SetWorkingSectionName(Id);
            }

            public bool Delete(int Id)
            {
                return WorkingSectionDLL.Delete(Id);
            }

            public static bool ValidationWorkingSectionName(string wsname, int Id)
            {
                return WorkingSectionDLL.ValidationWorkingSectionName(wsname,Id);
            }


            public bool Save(WorkingSectionBLL data)
            {
                return WorkingSectionDLL.Save(data);
            }

            public static DataTable GetWSectionCode(string wsectioncode)
            {
                return WorkingSectionDLL.GetWSectionCode(wsectioncode);
            }
   }
}
