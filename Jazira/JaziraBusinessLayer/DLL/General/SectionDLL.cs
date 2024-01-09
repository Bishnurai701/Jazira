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
  public  class SectionDLL
    {
        internal static bool Delete(int Id)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("SectionId", Id);
            da.AddParameter("LogDateTime", DateTime.Now);
            da.AddParameter("Mode", "D");
            int Count = da.ExecuteNonQuery("Sp_Section", System.Data.CommandType.StoredProcedure);
            if (Count > 0)
                return true;
            else
                return false;
        }

        internal static DataTable SetSectionName(int Id)
        {
            DataAccess data = new DataAccess();
            string sql = @"select SectionId, SectionCode, SectionName from Tbl_Section where Status!='D' and SectionId='" + Id + "'";
            data.datatable = data.ExecuteDataTable(sql, CommandType.Text);
            int rows = data.datatable.Rows.Count;
            data.CloseConnection();
            return data.datatable;
        }

        internal static bool ValidationSectionName(string p, int Id)
        {
            DataAccess data = new DataAccess();
            object obj = data.ExecuteScaler("select Count(*) From Tbl_Section where SectionName='" + p + "'and SectionId!='" + Id + "'", CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }

        internal static bool Save(SectionBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("SectionId", data.SectionId);
            da.AddParameter("SectionCode", data.SectionCode);
            da.AddParameter("SectionName", data.SectionName);
            da.AddParameter("Status", data.Status);
            da.AddParameter("LoginId", data.LoginId);
            da.AddParameter("LogDateTime", data.LogDateTime);
            //SqlParameter SectionId = new SqlParameter("SectionId", SqlDbType.Int);
            //SectionId.Direction = ParameterDirection.Output;
            int row = 0;
            if (data.SectionId == 0)
            {
                da.AddParameter("Mode", "I");
                row = da.ExecuteNonQuery("Sp_Section", System.Data.CommandType.StoredProcedure);

            }
            else
            {
                da.AddParameter("Mode", "U");
                row = da.ExecuteNonQuery("Sp_Section", System.Data.CommandType.StoredProcedure);

            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;
        }

        internal static DataTable GetSectionName(string Secname)
        {
            DataAccess data = new DataAccess();
            string sql = "";
            if (Secname == "")
            {
                sql = @"select  SectionCode, SectionName, Status From Tbl_Section ORDER BY SectionCode";
            }
            else
            {
                sql = @"Select  SectionCode, SectionName, Status from Tbl_Section";
                if (string.IsNullOrWhiteSpace(Secname) == false)
                {
                    sql += " where SectionName like '%" + Secname + "%'";
                }
            }
            data.datatable = data.ExecuteDataTable(sql, CommandType.Text);
            int row = data.datatable.Rows.Count;
            data.CloseConnection();
            return data.datatable;
        }
    }
}
