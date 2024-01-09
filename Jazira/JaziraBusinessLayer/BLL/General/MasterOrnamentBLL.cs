using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JaziraBusinessLayer.DLL.General;


namespace JaziraBusinessLayer.BLL.General
{
  public class MasterOrnamentBLL
  {
      #region Property Created By Bishnu Khaling

      private int _MasterOrnamentId;

           public int MasterOrnamentId
           {
             get { return _MasterOrnamentId; }
             set { _MasterOrnamentId = value; }
           }
      private int _OrnamentCode;

           public int OrnamentCode
           {
               get { return _OrnamentCode; }
               set { _OrnamentCode = value; }
           }
      private string _MasterOrnamentName;

           public string MasterOrnamentName
           {
             get { return _MasterOrnamentName; }
             set { _MasterOrnamentName = value; }
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


public static DataTable SetOrnamentName(int Id)
{
    return MasterOrnamentDLL.SetOrnamentName(Id);
}

public static bool Delete(int Id)
{
    return MasterOrnamentDLL.Delete(Id);
}

public static bool ValidationMasterOrnament(string p, int MOId)
{
    return MasterOrnamentDLL.ValidationMasterOrnament(p, MOId);
}

public bool Save(MasterOrnamentBLL data)
{
    return MasterOrnamentDLL.Save(data);
}

public static DataTable GetMasterOrnament(string MOName)
{
    return MasterOrnamentDLL.GetMasterOrnament(MOName);
}
  }
}
