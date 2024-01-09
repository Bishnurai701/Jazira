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
   public class WorkingSectionDLL
    {
        internal static DataTable SetWorkingSectionName(int Id)
        {
            DataAccess da = new DataAccess();
            string sql = @"select WorkingSectionId, WorkingSectionCode, WorkingSectionName from Tbl_WorkingSection where Status!='D' and WorkingSectionId='"+Id+"'";
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }

        internal static bool Delete(int Id)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("WorkingSectionId", Id);
            da.AddParameter("LogDateTime", DateTime.Now);
            da.AddParameter("Mode", "D");
            int Count = da.ExecuteNonQuery("Sp_WorkingSection", CommandType.StoredProcedure);
            if (Count > 0)
                return true;
            else
                return false;
        }

        internal static bool ValidationWorkingSectionName(string wsname, int Id)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("select Count(*) from Tbl_WorkingSection where WorkingSectionName='"+wsname+"' and WorkingSectionId!='"+Id+"'",CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }

        internal static bool Save(WorkingSectionBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("WorkingSectionId", data.WorkingSectionId);
            da.AddParameter("WorkingSectionCode", data.WorkingSectionCode);
            da.AddParameter("WorkingSectionName", data.WorkingSectionName);
            da.AddParameter("Status", data.Status);
            da.AddParameter("LoginId", data.LoginId);
            da.AddParameter("LogDateTime", data.LogDateTime);
            int row = 0;
            if (data.WorkingSectionId == 0)
            {
                da.AddParameter("Mode", "I");
                row = da.ExecuteNonQuery("Sp_WorkingSection", CommandType.StoredProcedure);
            }
            else
            {
                da.AddParameter("Mode", "U");
                row = da.ExecuteNonQuery("Sp_WorkingSection", CommandType.StoredProcedure);
            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;
        }

        internal static DataTable GetWSectionCode(string wsectioncode)
        {
            DataAccess da = new DataAccess();
            string sql = "";
            if (wsectioncode == "")
            {
                sql = @"select WorkingSectionId, WorkingSectionCode, WorkingSectionName, Status from Tbl_WorkingSection ORDER BY (CONVERT(int,WorkingSectionCode))";
            }
            else
            {
                sql = @"select WorkingSectionId, WorkingSectionCode, WorkingSectionName, Status from Tbl_WorkingSection";
                if (string.IsNullOrWhiteSpace(wsectioncode) == false)
                {
                    sql += " where WorkingSectionCode like'"+wsectioncode+"'";
                }
            }
            da.datatable = da.ExecuteDataTable(sql,CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }
    }
}
