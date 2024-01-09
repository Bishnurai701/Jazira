using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JaziraBusinessLayer.DLL.General;

namespace JaziraBusinessLayer.BLL.General
{
   public class SectionBLL
    {

#region property created by Bishnu Khaling
        private int _SectionId;

        public int SectionId
        {
            get { return _SectionId; }
            set { _SectionId = value; }
        }
      private int _SectionCode;

             public int SectionCode
             {
                 get { return _SectionCode; }
                 set { _SectionCode = value; }
             }
       private string _SectionName;

             public string SectionName
             {
               get { return _SectionName; }
               set { _SectionName = value; }
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


             public static bool Delete(int Id)
             {
                 return SectionDLL.Delete(Id);
             }

             public DataTable SetSectionName(int Id)
             {
                 return SectionDLL.SetSectionName(Id);
             }

             public static bool ValidationSectionName(string p, int Id)
             {
                 return SectionDLL.ValidationSectionName(p, Id);
             }

             public bool Save(SectionBLL data)
             {
                 return SectionDLL.Save(data);
             }

             public static DataTable GetSectionName(string Secname)
             {
                 return SectionDLL.GetSectionName(Secname);
             }
    }
}
