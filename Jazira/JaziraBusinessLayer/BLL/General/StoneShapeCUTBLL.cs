using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JaziraBusinessLayer.DLL.General;

namespace JaziraBusinessLayer.BLL.General
{
  public class StoneShapeCUTBLL
  {
      #region Property Created By Bishnu Khaling

      private int _StoneCUTId;

           public int StoneCUTId
           {
             get { return _StoneCUTId; }
             set { _StoneCUTId = value; }
           }
     private int _StoneCUTCode;

           public int StoneCUTCode
           {
               get { return _StoneCUTCode; }
               set { _StoneCUTCode = value; }
           }
      private string _StoneShapeCUTName;

           public string StoneShapeCUTName
           {
             get { return _StoneShapeCUTName; }
             set { _StoneShapeCUTName = value; }
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


public static DataTable SetStoneShapeCUTName(int Id)
{
    return StoneShapeCUTDLL.SetStoneShapeCUTName(Id);
}

public static bool Delete(int Id)
{
    return StoneShapeCUTDLL.Delete(Id);
}

public static bool ValidationStoneCUT(string p, int SCUTId)
{
    return StoneShapeCUTDLL.ValidationStoneCUT(p,SCUTId);
}

public bool Save(StoneShapeCUTBLL data)
{
    return StoneShapeCUTDLL.Save(data);
}

public static DataTable GetStoneCUTName(string StoneCUTName)
{
    return StoneShapeCUTDLL.GetStoneCUTName(StoneCUTName);
}
  }
}
