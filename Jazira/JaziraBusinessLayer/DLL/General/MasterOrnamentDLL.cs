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
   public class MasterOrnamentDLL
    {
        internal static DataTable SetOrnamentName(int Id)
        {
            DataAccess da = new DataAccess();
            string sql = @"select MasterOrnamentId,OrnamentCode, MasterOrnamentName from Tbl_MasterOrnament where Status!='D' and MasterOrnamentId='" + Id + "'";
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }

        internal static bool Delete(int Id)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("MasterOrnamentId", Id);
            da.AddParameter("LogDateTime", DateTime.Now);
            da.AddParameter("Mode", "D");
            int Count = da.ExecuteNonQuery("Sp_MasterOrnament", CommandType.StoredProcedure);
            if (Count > 0)
                return true;
            else
                return false;
        }

        internal static bool ValidationMasterOrnament(string p, int MOId)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("select Count(*) from Tbl_MasterOrnament where MasterOrnamentName='" + p + "' and MasterOrnamentId!='"+MOId+"'",CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }

        internal static bool Save(MasterOrnamentBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("MasterOrnamentId", data.MasterOrnamentId);
            da.AddParameter("OrnamentCode", data.OrnamentCode);
            da.AddParameter("MasterOrnamentName", data.MasterOrnamentName);
            da.AddParameter("Status", data.Status);
            da.AddParameter("LoginId", data.LoginId);
            da.AddParameter("LogDateTime", data.LogDateTime);
            SqlParameter MasterOrnamentId = new SqlParameter("MasterOrnamentId", SqlDbType.Int);
            MasterOrnamentId.Direction = ParameterDirection.Output;
            int row = 0;
            if (data.MasterOrnamentId == 0)
            {
                da.AddParameter("Mode", "I");
                row = da.ExecuteNonQuery("Sp_MasterOrnament", CommandType.StoredProcedure);
            }
            else
            {
                da.AddParameter("Mode", "U");
                row = da.ExecuteNonQuery("Sp_MasterOrnament", CommandType.StoredProcedure);
            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;
            
        }

        internal static DataTable GetMasterOrnament(string MOName)
        {
            DataAccess da = new DataAccess();
            string sql = "";
            if (MOName == "")
            {
                sql = @"select MasterOrnamentId, OrnamentCode, MasterOrnamentName, Status from Tbl_MasterOrnament ORDER BY OrnamentCode";
            }
            else
            {
                sql = @"select MasterOrnamentId, OrnamentCode, MasterOrnamentName, Status from Tbl_MasterOrnament";
                if (string.IsNullOrWhiteSpace(MOName) == false)
                {
                    sql += " where MasterOrnamentName like'" + MOName + "%'";
                }
            }
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }
    }
}
