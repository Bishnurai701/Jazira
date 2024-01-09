using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JaziraBusinessLayer.DLL.General;

namespace JaziraBusinessLayer.BLL.General
{
   public class GroupMasterMaintenaceBLL
   {
       #region Property Created By Bishnu Khaling

       /*this is Tbl_GroupMast Properties */
       private int _GroupMastId;
           public int GroupMastId
           {
             get { return _GroupMastId; }
             set { _GroupMastId = value; }
           }

       private int _GroupNo;
            public int GroupNo
            {
              get { return _GroupNo; }
              set { _GroupNo = value; }
            }

       private string _GroupName;
            public string GroupName
            {
              get { return _GroupName; }
              set { _GroupName = value; }
            }

       private int _SectionCode;
            public int SectionCode
            {
              get { return _SectionCode; }
              set { _SectionCode = value; }
            }

       private int _SalaryTypeCode;
            public int SalaryTypeCode
            {
              get { return _SalaryTypeCode; }
              set { _SalaryTypeCode = value; }
            }

       private decimal _Salary;
            public decimal Salary
            {
              get { return _Salary; }
              set { _Salary = value; }
            }

       private decimal _WorkCarat;
            public decimal WorkCarat
            {
              get { return _WorkCarat; }
              set { _WorkCarat = value; }
            }

       private bool _Productive;
            public bool Productive
            {
              get { return _Productive; }
              set { _Productive = value; }
            }

       private bool _IsSafe;
            public bool IsSafe
            {
              get { return _IsSafe; }
              set { _IsSafe = value; }
            }

       private bool _IDRequired;
            public bool IDRequired
            {
              get { return _IDRequired; }
              set { _IDRequired = value; }
            }

       private bool _IsMainSafe;
            public bool IsMainSafe
            {
              get { return _IsMainSafe; }
              set { _IsMainSafe = value; }
            }

       private int _RelatedGroup;
            public int RelatedGroup
            {
              get { return _RelatedGroup; }
              set { _RelatedGroup = value; }
            }

      private bool _IsActiveGroup;
            public bool IsActiveGroup
            {
                get { return _IsActiveGroup; }
                set { _IsActiveGroup = value; }
            }

       private int _WorkingSectionId;
            public int WorkingSectionId
            {
              get { return _WorkingSectionId; }
              set { _WorkingSectionId = value; }
            }

       private bool _JobNo;
            public bool JobNo
            {
              get { return _JobNo; }
              set { _JobNo = value; }
            }

       private char _JobChar;
            public char JobChar
            {
              get { return _JobChar; }
              set { _JobChar = value; }
            }

       private int _TypeMastId;
            public int TypeMastId
            {
              get { return _TypeMastId; }
              set { _TypeMastId = value; }
            }

       private string _TypeDescription;
            public string TypeDescription
            {
              get { return _TypeDescription; }
              set { _TypeDescription = value; }
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
                   	
       		/*this is SerialMaster table properties*/	
       private int _SerialMasterId;
            public int SerialMasterId
            {
              get { return _SerialMasterId; }
              set { _SerialMasterId = value; }
            }

       private int _SafeNo;
            public int SafeNo
            {
              get { return _SafeNo; }
              set { _SafeNo = value; }
            }

       private int _SerialNo;
            public int SerialNo
            {
              get { return _SerialNo; }
              set { _SerialNo = value; }
            }

       private char _FirstLetter;
            public char FirstLetter
            {
              get { return _FirstLetter; }
              set { _FirstLetter = value; }
            }

       private int _NextSerialNo;
            public int NextSerialNo
            {
              get { return _NextSerialNo; }
              set { _NextSerialNo = value; }
            }
       /*this is GroupCode table properties*/
       private int _GroupCodeId;
            public int GroupCodeId
            {
              get { return _GroupCodeId; }
              set { _GroupCodeId = value; }
            }
       private string _RecCode;
            public string RecCode
            {
              get { return _RecCode; }
              set { _RecCode = value; }
            }

       private string _DelCode;
            public string DelCode
            {
              get { return _DelCode; }
              set { _DelCode = value; }
            }
       /*this is GroupCodeO properties*/
      private int _GroupCodeOId;
            public int GroupCodeOId
            {
                get { return _GroupCodeOId; }
                set { _GroupCodeOId = value; }
            }
       /*this is Unique table properties database jazirammyyyy*/
       private int _UniqueId;
            public int UniqueId
            {
              get { return _UniqueId; }
              set { _UniqueId = value; }
            }

       private int _UniqueNo;
            public int UniqueNo
            {
              get { return _UniqueNo; }
              set { _UniqueNo = value; }
            }
       #endregion


            public DataTable GetSectionCode()
            {
                return GroupMasterMaintenaceDLL.GetSectionCode();
            }

            public DataTable GetSalaryType()
            {
                return GroupMasterMaintenaceDLL.GetSalaryType();
            }

            public DataTable GetWSection()
            {
                return GroupMasterMaintenaceDLL.GetWSection();
            }

            public static DataTable GetGroupCode(int Id)
            {
                return GroupMasterMaintenaceDLL.GetGroupCode(Id);
            }

            public static DataTable SetGroupMaster(int Id)
            {
                return GroupMasterMaintenaceDLL.SetGroupMaster(Id);
            }

            public static bool ValidationGroupCode(string gcode, int Id)
            {
                return GroupMasterMaintenaceDLL.ValidationGroupCode(gcode,Id);
            }
            public static bool ValidationDescription(string gname, int Id)
            {
                return GroupMasterMaintenaceDLL.ValidationDescription(gname,Id);
            }


            public static bool ValidationUnique(string uqname, int Id)
            {
                return GroupMasterMaintenaceDLL.ValidationUnique(uqname,Id);
            }
   }
}
