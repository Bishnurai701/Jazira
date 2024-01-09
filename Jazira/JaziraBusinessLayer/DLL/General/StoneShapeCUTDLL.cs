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
  public class StoneShapeCUTDLL
    {
        internal static DataTable SetStoneShapeCUTName(int Id)
        {
            DataAccess da = new DataAccess();
            string sql = @"select StoneCUTId, StoneCUTCode, StoneShapeCUTName from Tbl_StoneShapeCUT where Status!='D' and StoneCUTId='" + Id + "'";
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }

        internal static bool Delete(int Id)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("StoneCUTId", Id);
            da.AddParameter("LogDateTime", DateTime.Now);
            da.AddParameter("Mode", "D");
            int Count = da.ExecuteNonQuery("Sp_StoneShapeCUT", CommandType.StoredProcedure);
            if (Count > 0)
                return true;
            else
                return false;
        }

        internal static bool ValidationStoneCUT(string p, int SCUTId)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("select Count(*) From Tbl_StoneShapeCUT where StoneShapeCUTName='" + p + "' and StoneCUTId!='" + SCUTId + "' ", CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }

        internal static bool Save(StoneShapeCUTBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("StoneCUTId", data.StoneCUTId);
            da.AddParameter("StoneShapeCUTName", data.StoneShapeCUTName);
            da.AddParameter("Status", data.Status);
            da.AddParameter("LoginId", data.LoginId);
            da.AddParameter("LogDateTime", data.LogDateTime);
            SqlParameter StoneCUTId = new SqlParameter("StoneCUTId", SqlDbType.Int);
            StoneCUTId.Direction = ParameterDirection.Output;
            int row = 0;
            if (data.StoneCUTId == 0)
            {
                da.AddParameter("Mode", "I");
                row = da.ExecuteNonQuery("Sp_StoneShapeCUT", System.Data.CommandType.StoredProcedure);
            }
            else
            {
                da.AddParameter("Mode", "U");
                row = da.ExecuteNonQuery("Sp_StoneShapeCUT", System.Data.CommandType.StoredProcedure);
            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;
        }

        internal static DataTable GetStoneCUTName(string StoneCUTName)
        {
            DataAccess da = new DataAccess();
            string sql = "";
            if (StoneCUTName == "")
            {
                sql = @"Select StoneCUTId, StoneCUTCode, StoneShapeCUTName, Status from Tbl_StoneShapeCUT ORDER BY StoneCUTCode";
            }
            else
            {
                sql = @"Select StoneCUTId, StoneCUTCode, StoneShapeCUTName, Status from Tbl_StoneShapeCUT";
                if (string.IsNullOrWhiteSpace(StoneCUTName) == false)
                {
                    sql += " where StoneShapeCUTName like '"+StoneCUTName+"%'";
                }
            }
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }
    }
}
