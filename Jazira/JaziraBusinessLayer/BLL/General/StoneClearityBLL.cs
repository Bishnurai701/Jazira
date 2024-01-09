using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JaziraBusinessLayer.DLL.General;

namespace JaziraBusinessLayer.BLL.General
{
   public class StoneClearityBLL
   {
       #region Property Created By Bishnu Khaling

       private int _StoneClearityId;

               public int StoneClearityId
               {
                 get { return _StoneClearityId; }
                 set { _StoneClearityId = value; }
               }
      private int _StoneClearityCode;

               public int StoneClearityCode
               {
                   get { return _StoneClearityCode; }
                   set { _StoneClearityCode = value; }
               }
       private string _StoneClearityName;

               public string StoneClearityName
               {
                 get { return _StoneClearityName; }
                 set { _StoneClearityName = value; }
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


public static DataTable SetStoneClearityName(int Id)
{
    return StoneClearityDLL.SetStoneClearityName(Id);
}

public static bool Delete(int Id)
{
    return StoneClearityDLL.Delete(Id);
}

public static bool ValidationStoneShapeClearity(string p, int SSCId)
{
    return StoneClearityDLL.ValidationStoneShapeClearity(p,SSCId);
}

public bool Save(StoneClearityBLL data)
{
    return StoneClearityDLL.Save(data);
}

public static DataTable GetStoneClearityName(string SSClearityName)
{
    return StoneClearityDLL.GetStoneClearityName(SSClearityName);
}
   }
}
