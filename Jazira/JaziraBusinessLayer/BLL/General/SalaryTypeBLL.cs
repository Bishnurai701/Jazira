using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JaziraBusinessLayer.DLL.General;

namespace JaziraBusinessLayer.BLL.General
{
  public  class SalaryTypeBLL
  {
      #region Property Created By Bishnu Khaling
      private int _SalaryTypeId;

         public int SalaryTypeId
         {
           get { return _SalaryTypeId; }
           set { _SalaryTypeId = value; }
         }
         private int _SalaryTypeCode;

         public int SalaryTypeCode
         {
             get { return _SalaryTypeCode; }
             set { _SalaryTypeCode = value; }
         }
      private string _SalaryTypeName;

         public string SalaryTypeName
         {
           get { return _SalaryTypeName; }
           set { _SalaryTypeName = value; }
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

         public static DataTable GetSalaryTypeName(int Id)
         {
             return SalaryTypeDLL.GetSalaryTypeName(Id);
         }

         public static bool Delete(int Id)
         {
             return SalaryTypeDLL.Delete(Id);
         }

         public static bool ValidationSalaryType(string p, int SalId)
         {
             return SalaryTypeDLL.ValidationSalaryType(p,SalId);
         }

         public bool Save(SalaryTypeBLL data)
         {
             return SalaryTypeDLL.Save(data);
         }

         public static DataTable GetSalaryTypeNameGridView(string SalName)
         {
             return SalaryTypeDLL.GetSalaryTypeNameGridView(SalName);
         }
  }
}
