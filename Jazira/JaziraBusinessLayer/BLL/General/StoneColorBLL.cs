using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using JaziraBusinessLayer.DLL.General;

namespace JaziraBusinessLayer.BLL.General
{
  public class StoneColorBLL
  {
      #region Property Created By Bishnu Khaling

      private int _StoneColorId;
            public int StoneColorId
            {
              get { return _StoneColorId; }
              set { _StoneColorId = value; }
            }
    private int _StoneColorCode;
             public int StoneColorCode
             {
                 get { return _StoneColorCode; }
                 set { _StoneColorCode = value; }
             }

     private string _StoneColorName;
            public string StoneColorName
            {
              get { return _StoneColorName; }
              set { _StoneColorName = value; }
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

public static System.Data.DataTable SetStoneColorName(int Id)
{
    return StoneColorDLL.SetStoneColorName(Id);
}

public static bool Delete(int Id)
{
    return StoneColorDLL.Delete(Id);
}

public static bool ValidationStoneColor(string p, int SCId)
{
    return StoneColorDLL.ValidationStoneColor(p,SCId);
}

public bool Save(StoneColorBLL data)
{
    return StoneColorDLL.Save(data);
}

public static System.Data.DataTable GetStoneColorName(string StoneCname)
{
    return StoneColorDLL.GetStoneColorName(StoneCname);
}
  }
}
