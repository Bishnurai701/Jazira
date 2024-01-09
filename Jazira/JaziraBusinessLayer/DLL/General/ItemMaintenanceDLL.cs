using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using JaziraBusinessLayer.BLL.General;
using JaziraDatabaseLayer;

namespace JaziraBusinessLayer.DLL.General
{
  public  class ItemMaintenanceDLL
    {
        internal static DataTable GetStoneCUT()
        {
            DataAccess da = new DataAccess();
            string sql = @"select StoneCUTId as Id, StoneShapeCUTName as Name from Tbl_StoneShapeCUT";
            DataTable dt = da.ExecuteDataTable(sql, System.Data.CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static  DataTable GetStoneClearity()
        {
            DataAccess da = new DataAccess();
            string sql = @"select StoneClearityId as Id, StoneClearityName as Name from Tbl_StoneClearity";
            DataTable dt = da.ExecuteDataTable(sql,System.Data.CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static DataTable GetColor()
        {
            DataAccess da = new DataAccess();
            string sql = @"select StoneColorId as Id, StoneColorName as Name from Tbl_StoneColor";
            DataTable dt = da.ExecuteDataTable(sql,System.Data.CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static DataTable GetStoneShape()
        {
            DataAccess da = new DataAccess();
            string sql = @"select StoneShapeId as Id, StoneShapeName as Name from Tbl_StoneShape";
            DataTable dt = da.ExecuteDataTable(sql,System.Data.CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static DataTable SetMasterMaintenance(int Id)
        {
            DataAccess da = new DataAccess();
            string sql = @"select TypeMastId, TypeCodee, TypeDescription,
                             case when RPTColumnD=1 then 'D-CUT' 
                                  when RPTColumnD=2 then 'R/MADE'
                                  when RPTColumnD=3 then 'STONE'
                                  when RPTColumnD=4 then 'OTHER'
                                  else RPTColumnD
                              end as RPTColumnD, 
                              case when RPTColumnR=1 then 'H.R/MADE'
                                   when RPTColumnR=2 then 'R/MADE'
                                   when RPTColumnR=3 then 'STONE'
                                   when RPTColumnR=4 then 'OTHER'
                                else RPTColumnR
                              end as RPTColumnR,TypePricePC,TypeCarat,TypeDWL,TypeRWL,TypeStone,TypeSize,TypeEntryDate,StoneColorId,StoneCUTId,StoneShapeId,StoneClearityId,WeightPC,ROL,TypeDelCharge,TypeRecChage,Stype from Tbl_TypeMaster where Status!='D' and TypeMastId='" + Id + "'";
            //string sql = "select *from Tbl_TypeMaster where TypeMastId='"+Id+"'";
            DataTable dt = da.ExecuteDataTable(sql, System.Data.CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static bool Delete(int Id)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("TypeMastId", Id);
            da.AddParameter("@LogDateTime", DateTime.Now);
            da.AddParameter("@TypeEntryDate", DateTime.Now);
            da.AddParameter("Mode", "D");
            int count = da.ExecuteNonQuery("Sp_TypeMaster", System.Data.CommandType.StoredProcedure);
            if (count > 0)
                return true;
            else
                return false;
        }

        internal static bool ValidationItemCode(string Code, int Id)
        {
            DataAccess da = new DataAccess();
            Object obj = da.ExecuteScaler("select Count(*) from Tbl_TypeMaster where TypeCodee='" + Code + "' and TypeMastId!='" + Id + "'", CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }

        internal static bool ValidationItemDescription(string Desc, int Id)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("select Count(*) from Tbl_TypeMaster where TypeDescription='" + Desc + "' and TypeMastId!='" + Id + "'", CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }

        internal static bool Save(ItemMaintenanceBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("@TypeMastId", data.TypeMastId);
            da.AddParameter("@TypeCodee", data.TypeCodee);
            da.AddParameter("@TypeDescription", data.TypeDescription);
            da.AddParameter("@TypePricePC", data.TypePricePC);
            da.AddParameter("@TypeCarat", data.TypeCarat);
            da.AddParameter("@TypeDWL", data.TypeDWL);
            da.AddParameter("@TypeRWL", data.TypeRWL);
            da.AddParameter("@TypeStone", data.TypeStone);
            da.AddParameter("@TypeSize", data.TypeSize);
            da.AddParameter("@TypeEntryDate", data.TypeEntryDate);
            da.AddParameter("@StoneColorId", data.StoneColorId);
            da.AddParameter("@StoneCUTId", data.StoneCUTId);
            da.AddParameter("@StoneShapeId", data.StoneShapeId);
            da.AddParameter("@StoneClearityId", data.StoneClearityId);
            da.AddParameter("@RPTColumnD", data.RPTColumnD);
            da.AddParameter("@RPTColumnR", data.RPTColumnR);
            da.AddParameter("@WeightPC", data.WeightPC);
            da.AddParameter("@ROL", data.ROL);
            da.AddParameter("@TypeDelCharge", data.TypeDelCharge);
            da.AddParameter("@TypeRecChage", data.TypeRecChage);
            da.AddParameter("@Status", data.Status);
            da.AddParameter("@LoginId", data.LoginId);
            da.AddParameter("@LogDateTime", data.LogDateTime);
            int row=2;
            if (data.TypeMastId == 0)
            {
                da.AddParameter("Mode", "I");
                row += da.ExecuteNonQuery("Sp_TypeMaster", System.Data.CommandType.StoredProcedure);
            }
            else
            {
                //da.AddParameter("TypeMastId", data.TypeMastId);
                da.AddParameter("Mode", "U");
                row += da.ExecuteNonQuery("Sp_TypeMaster", System.Data.CommandType.StoredProcedure);
            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;
        }

        internal static bool SaveUnchked(ItemMaintenanceBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("@TypeMastId", data.TypeMastId);
            da.AddParameter("@TypeCodee", data.TypeCodee);
            da.AddParameter("@TypeDescription", data.TypeDescription);
            da.AddParameter("@TypePricePC", data.TypePricePC);
            da.AddParameter("@TypeCarat", data.TypeCarat);
            da.AddParameter("@TypeDWL", data.TypeDWL);
            da.AddParameter("@TypeRWL", data.TypeRWL);
            da.AddParameter("@RPTColumnD", data.RPTColumnD);
            da.AddParameter("@RPTColumnR", data.RPTColumnR);
            da.AddParameter("@TypeDelCharge", data.TypeDelCharge);
            da.AddParameter("@TypeRecChage", data.TypeRecChage);
            da.AddParameter("@TypeStone", data.TypeStone);
            da.AddParameter("@TypeEntryDate", data.TypeEntryDate);
            da.AddParameter("@Status", data.Status);
            da.AddParameter("@LoginId", data.LoginId);
            da.AddParameter("@LogDateTime", data.LogDateTime);
            int row=2;
            if (data.TypeMastId == 0)
            {
                da.AddParameter("Mode", "I");
                row += da.ExecuteNonQuery("Sp_TypeMasterUnchecked", System.Data.CommandType.StoredProcedure);
            }
            else
            {
                //da.AddParameter("TypeMastId", data.TypeMastId);
                da.AddParameter("Mode", "U");
                row += da.ExecuteNonQuery("Sp_TypeMasterUnchecked", System.Data.CommandType.StoredProcedure);
            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;
        }

        internal static DataTable GetItemCode(string ItemCode)
        {
            DataAccess da = new DataAccess();
            string sql = "";
            if (ItemCode == "")
            {
                sql = @"select TypeMastId, TypeCodee, TypeDescription,RPTColumnD,RPTColumnR,TypePricePC,TypeCarat,TypeDWL,TypeRWL,TypeStone,TypeSize,TypeEntryDate,StoneColorId,StoneCUTId,StoneShapeId,StoneClearityId,WeightPC,ROL,TypeDelCharge,TypeRecChage, Status from Tbl_TypeMaster ORDER BY (CONVERT(int,TypeCodee))";
            }
            else
            {
                sql = @"select TypeMastId, TypeCodee, TypeDescription,RPTColumnD,RPTColumnR,TypePricePC,TypeCarat,TypeDWL,TypeRWL,TypeStone,TypeSize,TypeEntryDate,StoneColorId,StoneCUTId,StoneShapeId,StoneClearityId,WeightPC,ROL,TypeDelCharge,TypeRecChage, Status from Tbl_TypeMaster";
                if (string.IsNullOrWhiteSpace(ItemCode) == false)
                { 
                    sql+=" where TypeCodee like'" + ItemCode + "'";
                }
            }
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int rows = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }

        //internal static bool DeleteUNCHKD(int Id)
        //{
        //    DataAccess da = new DataAccess();
        //    da.AddParameter("TypeMastId", Id);
        //    da.AddParameter("TypeEntryDate", DateTime.Now);
        //    da.AddParameter("LogDateTime", DateTime.Now);
        //    da.AddParameter("Mode", "D");
        //    int Count = da.ExecuteNonQuery("Sp_TypeMasterUnchecked", System.Data.CommandType.StoredProcedure);
        //    if (Count > 0)
        //        return true;
        //    else
        //        return false;
        //}
    }
}
