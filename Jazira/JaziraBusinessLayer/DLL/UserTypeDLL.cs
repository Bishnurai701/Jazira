using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JaziraDatabaseLayer;
using JaziraBusinessLayer.BLL;


namespace JaziraBusinessLayer.DLL
{
   public  class UserTypeDLL
    {
        internal static bool Save(UserTypeBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("UserTypeId", data.UserTypeId);
            da.AddParameter("UserTypeName", data.UserTypeName);
            da.AddParameter("Status", data.Status);
            da.AddParameter("LoginId", data.LoginId);
            da.AddParameter("LogDateTime", data.LogDateTime);
            int row = 0;
            if (data.UserTypeId == 0)
            {
                da.AddParameter("Mode", "I");
                row = da.ExecuteNonQuery("Sp_UserType", System.Data.CommandType.StoredProcedure);
            }
            else
            {
                //da.AddParameter("UserTypeId", data.UserTypeId);
                da.AddParameter("Mode", "U");
                row = da.ExecuteNonQuery("Sp_UserType", System.Data.CommandType.StoredProcedure);
            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;
        }

        internal static DataTable GetUserTypeByUserTyneName(string name)
        {
            DataAccess da = new DataAccess();
            string sql = "";
            if (name == "")
            {

                sql = @"select UserTypeId, UserTypeName, Status from Tbl_UserType 
                            ORDER BY UserTypeName";
            }
            else
            {
                sql = @"select UserTypeId, UserTypeName, Status from Tbl_UserType";
                if (string.IsNullOrWhiteSpace(name) == false)
                    sql += " where UserTypeName like '%" + name + "%' ";
            }
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int rows = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }

        internal static bool Delete(int Id)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("UserTypeId", Id);
            da.AddParameter("Mode", "D");
            da.AddParameter("LogDateTime", DateTime.Now);
            int flag = da.ExecuteNonQuery("Sp_UserType", System.Data.CommandType.StoredProcedure);
            da.CloseConnection();
            if (flag > 0)
                return true;
            else
                return false;
        }

        internal static DataTable GetUserTypeById(int Id)
        {
            DataAccess da = new DataAccess();
            string sql = @"Select  UserTypeId,UserTypeName from Tbl_UserType
                            where Status!='D' and  UserTypeId='" + Id+"'";
            da.datatable=da.ExecuteDataTable(sql, System.Data.CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            //da.datatable = da.ExecuteDataTable(sql, System.Data.CommandType.Text);
            //int rows = dt.Rows.Count;
            return da.datatable;
        }

        internal static bool ValidationUserType(string p, int Id)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("Select Count(*) From Tbl_UserType Where UserTypeName='" + p + "' and UserTypeId!=" + Id + "", CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }
    }
}
