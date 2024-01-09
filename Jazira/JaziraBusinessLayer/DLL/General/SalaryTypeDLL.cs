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
  public  class SalaryTypeDLL
    {
        internal static DataTable GetSalaryTypeName(int Id)
        {
            DataAccess data = new DataAccess();
            string sql = @"select SalaryTypeId, SalaryTypeCode, SalaryTypeName from Tbl_SalaryType where Status!='D' and SalaryTypeId='" + Id + "'";
            data.datatable = data.ExecuteDataTable(sql, CommandType.Text);
            int row = data.datatable.Rows.Count;
            data.CloseConnection();
            return data.datatable;
        }

        internal static bool Delete(int Id)
        {
            DataAccess data = new DataAccess();
            data.AddParameter("SalaryTypeId", Id);
            data.AddParameter("LogDateTime", DateTime.Now);
            data.AddParameter("Mode", "D");
            int Count = data.ExecuteNonQuery("Sp_SalaryType", System.Data.CommandType.StoredProcedure);
            if (Count > 0)
                return true;
            else
                return false;
        }

        internal static bool ValidationSalaryType(string p, int SalId)
        {
            DataAccess data = new DataAccess();
            object obj = data.ExecuteScaler("select Count(*) From Tbl_SalaryType where SalaryTypeName='" + p + "' and SalaryTypeId!='" + SalId + "'",CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }

        internal static bool Save(SalaryTypeBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("SalaryTypeId", data.SalaryTypeId);
            da.AddParameter("SalaryTypeCode", data.SalaryTypeCode);
            da.AddParameter("SalaryTypeName", data.SalaryTypeName);
            da.AddParameter("Status", data.Status);
            da.AddParameter("LoginId", data.LoginId);
            da.AddParameter("LogDateTime", data.LogDateTime);
            //SqlParameter SalaryTypeId = new SqlParameter("SalaryTypeId", SqlDbType.Int);
            //SalaryTypeId.Direction = ParameterDirection.Output;
            int row = 0;
            if (data.SalaryTypeId == 0)
            {
                da.AddParameter("Mode", "I");
                row = da.ExecuteNonQuery("Sp_SalaryType", System.Data.CommandType.StoredProcedure);
            }
            else
            {
                da.AddParameter("Mode", "U");
                row = da.ExecuteNonQuery("Sp_SalaryType", System.Data.CommandType.StoredProcedure);
            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;

        }

        internal static DataTable GetSalaryTypeNameGridView(string SalName)
        {
            DataAccess data=new DataAccess();
            string sql = "";
            if (SalName == "")
            {
                sql = @"Select SalaryTypeId, SalaryTypeCode, SalaryTypeName, Status from Tbl_SalaryType ORDER BY SalaryTypeCode";
            }
            else
            {
                sql = @"Select SalaryTypeId, SalaryTypeCode, SalaryTypeName, Status from Tbl_SalaryType ";
                if (string.IsNullOrWhiteSpace(SalName) == false)
                {
                    sql += " where SalaryTypeName like'" + SalName + "%'";
                }
            }
            data.datatable = data.ExecuteDataTable(sql, CommandType.Text);
            int row = data.datatable.Rows.Count;
            data.CloseConnection();
            return data.datatable;

        }
    }
}
