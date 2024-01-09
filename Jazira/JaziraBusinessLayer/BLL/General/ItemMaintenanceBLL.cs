using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JaziraBusinessLayer.DLL.General;

namespace JaziraBusinessLayer.BLL.General
{
  public  class ItemMaintenanceBLL
  {
      #region Property Created By Bishnu Khaling
private int _TypeMastId;

     public int TypeMastId
     {
       get { return _TypeMastId; }
       set { _TypeMastId = value; }
     }
private string _TypeCodee;

     public string TypeCodee
     {
       get { return _TypeCodee; }
       set { _TypeCodee = value; }
     }
private string _TypeDescription;

     public string TypeDescription
     {
       get { return _TypeDescription; }
       set { _TypeDescription = value; }
     }
private decimal _TypePricePC;

     public decimal TypePricePC
     {
       get { return _TypePricePC; }
       set { _TypePricePC = value; }
     }
private decimal _TypeCarat;

     public decimal TypeCarat
     {
       get { return _TypeCarat; }
       set { _TypeCarat = value; }
     }
private bool _TypeDWL;

     public bool TypeDWL
     {
       get { return _TypeDWL; }
       set { _TypeDWL = value; }
     }
private bool _TypeRWL;

     public bool TypeRWL
     {
       get { return _TypeRWL; }
       set { _TypeRWL = value; }
     }
private bool _TypeStone;

     public bool TypeStone
     {
       get { return _TypeStone; }
       set { _TypeStone = value; }
     }
private string _TypeSize;

     public string TypeSize
     {
       get { return _TypeSize; }
       set { _TypeSize = value; }
     }
private DateTime _TypeEntryDate;

     public DateTime TypeEntryDate
     {
       get { return _TypeEntryDate; }
       set { _TypeEntryDate = value; }
     }
private int _StoneColorId;

     public int StoneColorId
     {
       get { return _StoneColorId; }
       set { _StoneColorId = value; }
     }
private int _StoneCUTId;

     public int StoneCUTId
     {
       get { return _StoneCUTId; }
       set { _StoneCUTId = value; }
     }
private int _StoneShapeId;

     public int StoneShapeId
     {
       get { return _StoneShapeId; }
       set { _StoneShapeId = value; }
     }
private int _StoneClearityId;

     public int StoneClearityId
     {
       get { return _StoneClearityId; }
       set { _StoneClearityId = value; }
     } 
private string _RPTColumnD;

     public string RPTColumnD
     {
       get { return _RPTColumnD; }
       set { _RPTColumnD = value; }
     }
private string _RPTColumnR;

     public string RPTColumnR
     {
       get { return _RPTColumnR; }
       set { _RPTColumnR = value; }
     }   
private decimal _WeightPC;

     public decimal WeightPC
     {
       get { return _WeightPC; }
       set { _WeightPC = value; }
     }  
private decimal _ROL;

     public decimal ROL
     {
       get { return _ROL; }
       set { _ROL = value; }
     }
private bool _TypeDelCharge;

     public bool TypeDelCharge
     {
       get { return _TypeDelCharge; }
       set { _TypeDelCharge = value; }
     }
private bool _TypeRecChage;

     public bool TypeRecChage
     {
       get { return _TypeRecChage; }
       set { _TypeRecChage = value; }
     }
private char _Stype;

     public char Stype
     {
       get { return _Stype; }
       set { _Stype = value; }
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

     public DataTable GetStoneCUT()
     {
         return ItemMaintenanceDLL.GetStoneCUT();
     }
     public DataTable GetColor()
     {
         return ItemMaintenanceDLL.GetColor();
     }
     public DataTable GetStoneClearity()
     {
         return ItemMaintenanceDLL.GetStoneClearity();
     }
     public DataTable GetStoneShape()
     {
         return ItemMaintenanceDLL.GetStoneShape();
     }

     public static DataTable SetMasterMaintenance(int Id)
     {
         return ItemMaintenanceDLL.SetMasterMaintenance(Id);
     }

     public bool Delete(int Id)
     {
         return ItemMaintenanceDLL.Delete(Id);
     }

     public static bool ValidationItemCode(string Code, int Id)
     {
         return ItemMaintenanceDLL.ValidationItemCode(Code,Id);
     }

     public static bool ValidationItemDescription(string Desc, int Id)
     {
         return ItemMaintenanceDLL.ValidationItemDescription(Desc,Id);
     }

     public bool Save(ItemMaintenanceBLL data)
     {
         return ItemMaintenanceDLL.Save(data);
     }

     public bool SaveUnchked(ItemMaintenanceBLL data)
     {
         return ItemMaintenanceDLL.SaveUnchked(data);
     }

     public static DataTable GetItemCode(string ItemCode)
     {
         return ItemMaintenanceDLL.GetItemCode(ItemCode);
     }

     //public bool DeleteUNCHKD(int Id)
     //{
     //    return ItemMaintenanceDLL.DeleteUNCHKD(Id);
     //}
  }
}
