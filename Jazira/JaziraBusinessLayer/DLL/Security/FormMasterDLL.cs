using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using JaziraBusinessLayer.BLL.Security;
using JaziraDatabaseLayer;


namespace JaziraBusinessLayer.DLL.Security
{
   public class FormMasterDLL
    {
        internal static bool Delete(int Id)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("FormId", Id);
            da.AddParameter("LogDateTime", DateTime.Now);
            da.AddParameter("Mode", "D");
            int Cout = da.ExecuteNonQuery("Sp_Form", System.Data.CommandType.StoredProcedure);
            if (Cout > 0)
                return true;
            else
                return false;
        }

        internal static DataTable SetFromPageName(int Id)
        {
            DataAccess da = new DataAccess();
            string sql = @"select FormId, DisplayName, PagenName, FormCode from Tbl_Form where Status!='D' and FormId='"+Id+"'";
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }

        internal static bool ValidationFormCode(string code, int Id)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("select Count(*) from Tbl_Form where FormCode='"+code+"' and FormId!='"+Id+"'",CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }

        internal static bool ValidationPageName(string pagename, int Id)
        {
            DataAccess da = new DataAccess();
            object objpage = da.ExecuteScaler("select Count(*) from Tbl_Form where PagenName='"+pagename+"' and FormId!='"+Id+"'",CommandType.Text);
            if (Convert.ToInt32(objpage) > 0)
                return false;
            else
                return true;
        }

        internal static bool Save(FormMasterBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("FormId", data.FormId);
            da.AddParameter("FormCode", data.FormCode);
            da.AddParameter("PagenName", data.PagenName);
            da.AddParameter("DisplayName", data.DisplayName);
            da.AddParameter("Status", data.Status);
            da.AddParameter("LoginId", data.LoginId);
            da.AddParameter("LogDateTime", data.LogDateTime);
            int row = 0;
            if (data.FormId == 0)
            {
                da.AddParameter("Mode", "I");
                row = da.ExecuteNonQuery("Sp_Form", CommandType.StoredProcedure); 
            }
            else
            {
                da.AddParameter("Mode","U");
                row = da.ExecuteNonQuery("Sp_Form", CommandType.StoredProcedure); 
            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;
        }

        internal static DataTable GetFormCode(string fcode)
        {
            DataAccess da = new DataAccess();
            string sql = "";
            if (fcode == "")
            {
                sql = @"select FormId, FormCode, PagenName, DisplayName, Status from Tbl_Form ORDER BY (CONVERT(int,FormCode))";
            }
            else
            {
                sql = @"select FormId, FormCode, PagenName , DisplayName, Status from Tbl_Form";
                if (string.IsNullOrWhiteSpace(fcode) == false)
                {
                    sql += " where FormCode like'"+fcode+"'";
                }
            }
            da.datatable = da.ExecuteDataTable(sql,CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }
    }
}
