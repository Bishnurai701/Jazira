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
   public class StoneColorDLL
    {
        internal static DataTable SetStoneColorName(int Id)
        {
            DataAccess da = new DataAccess();
            string sql = @"select StoneColorId,StoneColorCode, StoneColorName from Tbl_StoneColor where Status!='D' and StoneColorId='" + Id + "'";
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }

        internal static bool Delete(int Id)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("StoneColorId", Id);
            da.AddParameter("LogDateTime", DateTime.Now);
            da.AddParameter("Mode", "D");
            int Count = da.ExecuteNonQuery("Sp_StoneColor", System.Data.CommandType.StoredProcedure);
            if (Count > 0)
                return true;
            else
                return false;
        }

        internal static bool ValidationStoneColor(string p, int SCId)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("select Count(*) From Tbl_StoneColor where StoneColorName='" + p + "' and StoneColorId!='" + SCId + "'",CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }

        internal static bool Save(StoneColorBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("StoneColorId", data.StoneColorId);
            da.AddParameter("StoneColorCode", data.StoneColorCode);
            da.AddParameter("StoneColorName", data.StoneColorName);
            da.AddParameter("Status", data.Status);
            da.AddParameter("LoginId", data.LoginId);
            da.AddParameter("LogDateTime", data.LogDateTime);
            SqlParameter StoneColorId = new SqlParameter("StoneColorId", SqlDbType.Int);
            StoneColorId.Direction = ParameterDirection.Output;
            int row = 0;
            if (data.StoneColorId == 0)
            {
                da.AddParameter("Mode", "I");
                row = da.ExecuteNonQuery("Sp_StoneColor", System.Data.CommandType.StoredProcedure);
            }
            else
            {
                da.AddParameter("Mode", "U");
                row = da.ExecuteNonQuery("Sp_StoneColor",System.Data.CommandType.StoredProcedure);
            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;
        }

        internal static DataTable GetStoneColorName(string StoneCname)
        {
            DataAccess da = new DataAccess();
            string sql = "";
            if (StoneCname == "")
            {
                sql = @"select StoneColorId, StoneColorCode, StoneColorName, Status from Tbl_StoneColor ORDER BY StoneColorCode ";
            }
            else
            {
                sql = @"select StoneColorId, StoneColorCode, StoneColorName,Status from Tbl_StoneColor ";
                if (string.IsNullOrWhiteSpace(StoneCname) == false)
                {
                    sql += " where StoneColorName like '" + StoneCname + "%'";
                }
            }
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }
    }
}
