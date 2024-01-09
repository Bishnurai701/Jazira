using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JaziraBusinessLayer.DLL.General;

namespace JaziraBusinessLayer.BLL.General
{
 public  class GroupCodeBLL
    {
#region Preperty Created By Bishnu Khaling 
     private int _GroupCodeId;

             public int GroupCodeId
             {
               get { return _GroupCodeId; }
               set { _GroupCodeId = value; }
             }
     private int _GroupNo;

               public int GroupNo
              {
                get { return _GroupNo; }
                set { _GroupNo = value; }
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
     private int _SafeNo;

                public int SafeNo
                {
                  get { return _SafeNo; }
                  set { _SafeNo = value; }
                }
     private char _Status;

                public char Status
                {
                  get { return _Status; }
                  set { _Status = value; }
                }
#endregion


                //public DataTable GetFlexGroupCode()
                //{
                //    return GroupCodeDLL.GetFlexGroupCode();
                //}


                //public DataTable AddGroupCode(GroupCodeBLL data)
                //{
                //    return GroupCodeDLL.AddGroupCode(data);
                //}

                //public DataTable UpdateGrid(GroupCodeBLL data)
                //{
                //    return GroupCodeDLL.UpdateGrid(data);
                //}

                //public bool Delete(int Id)
                //{
                //    return GroupCodeDLL.Delete(Id);
                //}
    }
}
