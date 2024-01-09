using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JaziraBusinessLayer.DLL.General;

namespace JaziraBusinessLayer.BLL.General
{
   public class GoldTypeBLL
   {
#region property created by Bishnu Khaling
       private int _GoldTypeId;

public int GoldTypeId
{
  get { return _GoldTypeId; }
  set { _GoldTypeId = value; }
}
private int _GoldTypeCode;

public int GoldTypeCode
{
    get { return _GoldTypeCode; }
    set { _GoldTypeCode = value; }
}

       private string _GoldTypeName;

public string GoldTypeName
{
  get { return _GoldTypeName; }
  set { _GoldTypeName = value; }
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
    return GoldTypeDLL.Delete(Id);
}

//public DataTable GetGoldType(int Id)
//{
//    return JaziraBusinessLayer.DLL.General.GoldTypeDLL.GetGoldType(Id);
//}

public static bool ValidationGOldType(string p, int Id)
{
    return GoldTypeDLL.ValidationGOldType(p,Id);
}

public bool Save(GoldTypeBLL dataa)
{
    return GoldTypeDLL.Save(dataa);
}

public static DataTable GetGoldType(string GoldName)
{
    return GoldTypeDLL.GetGoldType(GoldName);
}


//public static bool GetIDToShow(int Id)
//{
//    return GoldTypeDLL.GetIDToShow(Id);
//}

//public static DataTable GETGoldID(int Id)
//{
//    return GoldTypeDLL.GETGoldID(Id);
//}

//public static bool FetchGoldId(GoldTypeBLL data)
//{
//   return   GoldTypeDLL.FetchGoldId(data);
//}

//public static void FetchGoldId(int Id)
//{
//     GoldTypeDLL.FetchGoldId(Id);
//}

//public static bool FetchGoldId(int Id)
//{
//    return GoldTypeDLL.FetchGoldId(Id);
//}

//public static DataTable FetchGoldId(int Id)
//{
//    return GoldTypeDLL.FetchGoldId(Id);
//}

//public static object GetMaxGoldIdNo()
//{
//    return GoldTypeDLL.GetMaxGoldIdNo();
//}



//public static DataTable GetGoldId(int a)
//{
//    return GoldTypeDLL.GetGoldId(a);
//}


//public static DataTable GoldIdSave(GoldTypeBLL dataa)
//{
//    return GoldTypeDLL.GoldIdSave(dataa);
//}

public System.Data.DataTable GetGoldTypeName(int Id)
{
    return JaziraBusinessLayer.DLL.General.GoldTypeDLL.GetGoldTypeName(Id);
}
   }
}
