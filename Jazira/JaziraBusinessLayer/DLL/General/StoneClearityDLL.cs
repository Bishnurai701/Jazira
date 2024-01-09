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
  public class StoneClearityDLL
    {
        internal static DataTable SetStoneClearityName(int Id)
        {
            DataAccess da = new DataAccess();
            string sql = @"select StoneClearityId, StoneClearityCode, StoneClearityName from Tbl_StoneClearity where Status!='S' and StoneClearityId='" + Id + "'";
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }

        internal static bool Delete(int Id)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("StoneClearityId", Id);
            da.AddParameter("LogDateTime", DateTime.Now);
            da.AddParameter("Mode", "D");
            int Count = da.ExecuteNonQuery("Sp_StoneClearity", CommandType.StoredProcedure);
            if (Count > 0)
                return true;
            else
                return false;
        }

        internal static bool ValidationStoneShapeClearity(string p, int SSCId)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("select Count(*) from Tbl_Stoneclearity where StoneClearityName='" + p + "' and StoneClearityId!='" + SSCId + "'",CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }

        internal static bool Save(StoneClearityBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("StoneClearityId", data.StoneClearityId);
            da.AddParameter("StoneClearityCode", data.StoneClearityCode);
            da.AddParameter("StoneClearityName", data.StoneClearityName);
            da.AddParameter("Status", data.Status);
            da.AddParameter("LoginId", data.LoginId);
            da.AddParameter("LogDateTime", data.LogDateTime);
            SqlParameter StoneClearityId = new SqlParameter("StoneClearityId", SqlDbType.Int);
            StoneClearityId.Direction = ParameterDirection.Output;
            int row = 0;
            if (data.StoneClearityId == 0)
            {
                da.AddParameter("Mode", "I");
                row = da.ExecuteNonQuery("Sp_StoneClearity", CommandType.StoredProcedure);

            }
            else
            {
                da.AddParameter("Mode", "U");
                row = da.ExecuteNonQuery("Sp_StoneClearity", CommandType.StoredProcedure);
            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;
        }

        internal static DataTable GetStoneClearityName(string SSClearityName)
        {
            DataAccess da = new DataAccess();
            string sql = "";
            if (SSClearityName == "")
            {
                sql = @"select StoneClearityId, StoneClearityCode, StoneClearityName, Status from Tbl_StoneClearity ORDER BY StoneClearityCode";
            }
            else
            {
                sql = @"select StoneClearityId, StoneClearityCode, StoneClearityName, Status from Tbl_StoneClearity";
                if (string.IsNullOrWhiteSpace(SSClearityName) == false)
                {
                    sql += " where StoneClearityName like'" + SSClearityName + "%'";
                }
            }
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }
    }
}
