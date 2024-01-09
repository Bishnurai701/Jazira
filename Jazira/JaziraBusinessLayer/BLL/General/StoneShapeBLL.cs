using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JaziraBusinessLayer.DLL.General;

namespace JaziraBusinessLayer.BLL.General
{
 public  class StoneShapeBLL
 {
     #region Property Created By Bishnu Khaling
     private int _StoneShapeId;

           public int StoneShapeId
           {
             get { return _StoneShapeId; }
             set { _StoneShapeId = value; }
           }
    private int _StoneShapeCode;

           public int StoneShapeCode
           {
               get { return _StoneShapeCode; }
               set { _StoneShapeCode = value; }
           }
     private string _StoneShapeName;

            public string StoneShapeName
            {
              get { return _StoneShapeName; }
              set { _StoneShapeName = value; }
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
                 return StoneShapeDLL.Delete(Id);
             }

             public static DataTable SetStopneShapeName(int Id)
             {
                 return StoneShapeDLL.SetStopneShapeName(Id);
             }

             public static bool ValidationStoneShape(string p, int SSId)
             {
                 return StoneShapeDLL.ValidationStoneShape(p, SSId);
             }

             public bool Save(StoneShapeBLL data)
             {
                 return StoneShapeDLL.Save(data);
             }

             public static DataTable GetStoneShapeGridView(string StoneSName)
             {
                 return StoneShapeDLL.GetStoneShapeGridView(StoneSName);
             }
 }
}
