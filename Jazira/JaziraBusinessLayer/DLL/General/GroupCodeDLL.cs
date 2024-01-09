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
 public  class GroupCodeDLL
    {

        //internal static DataTable GetFlexGroupCode()
        //{
        //    DataAccess da = new DataAccess();
        //    string sql = "Select GroupCodeId, SafeNo,RecCode,DelCode"+" from Tbl_GroupCode";
        //    da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
        //    int row = da.datatable.Rows.Count;
        //    da.CloseConnection();
        //    return da.datatable;
        //}


        //internal static DataTable AddGroupCode(GroupCodeBLL data)
        //{
        //    DataAccess da = new DataAccess();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = @"insert into Tbl_GroupCode(GroupCodeID, SafeNo, RecCode, DelCode) " +
        //                            "values(@GroupCodeID, @SafeNo, @RecCode,@DelCode);" +
        //                            "select GroupCodeID, SafeNo, RecCode, DelCode from Tbl_GroupCode";
        //    cmd.Parameters.Add("@GroupCodeId", SqlDbType.Int).Value = data.GroupCodeId;
        //    cmd.Parameters.Add("SafeNo", SqlDbType.Int).Value = data.SafeNo;
        //    cmd.Parameters.Add("RecCode", SqlDbType.NVarChar).Value = data.RecCode;
        //    cmd.Parameters.Add("DelCode", SqlDbType.NVarChar).Value = data.DelCode;
        //    cmd.Parameters.Add("Status", SqlDbType.Char).Value = data.Status;
        //    return da.datatable;
        //}

        //internal static DataTable UpdateGrid(GroupCodeBLL data)
        //{
        //    DataAccess da = new DataAccess();
        //    da.AddParameter("GroupCodeId", data.GroupCodeId);
        //    da.AddParameter("SafeNo", data.SafeNo);
        //    da.AddParameter("RecCode", data.RecCode);
        //    da.AddParameter("DelCode", data.DelCode);
        //    da.AddParameter("Status", data.Status);
        //    int row = 0;
        //    if(data.GroupCodeId!=0)
        //    {
        //        da.AddParameter("Mode", "U");
        //        row = da.ExecuteNonQuery("Sp_GroupCode", CommandType.StoredProcedure);
        //    }
        //    da.CloseConnection();
        //    return da.datatable;

        //}

        //internal static bool Delete(int Id)
        //{
        //    DataAccess da = new DataAccess();
        //    da.AddParameter("GroupCodeId",Id);
        //    da.AddParameter("Mode", "D");
        //    int Count = da.ExecuteNonQuery("Sp_GroupCode", CommandType.StoredProcedure);
        //    if (Count > 0)
        //        return true;
        //    else
        //        return false;
        //}
    }
}
