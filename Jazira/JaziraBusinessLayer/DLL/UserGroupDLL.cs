using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using JaziraDatabaseLayer;

namespace JaziraBusinessLayer.DLL
{
   public class UserGroupDLL
    {
        internal static bool Save(BLL.UserGroupBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("UserGroupName", data.UserGroupName);
            da.AddParameter("UserTypeId", data.UserTypeId);
            da.AddParameter("Status", data.Status);
            da.AddParameter("LoginId", data.LoginId);
            da.AddParameter("LogDateTime", data.LogDateTime);
            int row = 0;
            if (data.UserGroupId == 0)
            {
                da.AddParameter("Mode", "I");
                row = da.ExecuteNonQuery("Sp_UserGroup", System.Data.CommandType.StoredProcedure);
            }
            else
            {
                da.AddParameter("UserGroupId", data.UserGroupId);
                da.AddParameter("Mode", "U");
                row = da.ExecuteNonQuery("Sp_UserGroup", System.Data.CommandType.StoredProcedure);
            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;

        }

        internal static DataTable GetUserTypeByIdName()
        {
            DataAccess da = new DataAccess();
            string sql = @"Select UserTypeId as Id, UserTypeName as Name from Tbl_UserType";
            System.Data.DataTable dt = da.ExecuteDataTable(sql, System.Data.CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static DataTable GetUserTypeById(int Id)
        {
            DataAccess da = new DataAccess();
            string query = "Select *from Tbl_UserGroup Where UserGroupId='" + Id + "'";
            DataTable dt = da.ExecuteDataTable(query, System.Data.CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static DataTable GetUserType()
        {
            DataAccess da = new DataAccess();
            string sql = "select UserTypeId, UserTypeName from [dbo].[Tbl_UserType]";
            DataTable dt= da.ExecuteDataTable(sql, System.Data.CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static DataTable GetUserGroupByName()
        {
            DataAccess da = new DataAccess();
            string sql = "select UserTypeId, UserTypeName from Tbl_UserType";
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int rows = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }
       //******this function for gridview and ordering value if not equal to Gname other wise search()
       //******By Bishnu Khaling -2014-***************************************************************

        internal static DataTable GetUserGroup(string Gname)
        {
            DataAccess da = new DataAccess();
            string sql = "";
            if (Gname == "")
            {
                sql = @"select UG.UserGroupId, UG.UserGroupName, UG.Status, UT.UserTypeName 
                           from Tbl_UserGroup UG 
                           inner join Tbl_UserType UT on UT.[UserTypeId]=UG.[UserTypeId] where UG.Status!='D'  ORDER BY UG.UserGroupName";
            }
            else
            {
               sql = @"select UG.UserGroupId, UG.UserGroupName, UG.Status, UT.UserTypeName 
                           from Tbl_UserGroup UG 
                           inner join Tbl_UserType UT on UT.[UserTypeId]=UG.[UserTypeId]";
                if (string.IsNullOrWhiteSpace(Gname) == false)
                    sql += " where UserGroupName like '%" + Gname + "%'";
            }
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int rows = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }

       //******this is optional does't affect on program
        //internal static object GetDataByUserGroupName(string name)
        //{
        //    DataAccess da = new DataAccess();
        //    string sql = "Select *from Tbl_UserGroup ORDER BY UserGroupName where UserGroupName Like'" + name + "%'";
        //    da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
        //    da.CloseConnection();
        //    return da.datatable;
        //}

        internal static bool Delete(int Id)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("UserGroupId", Id);
            da.AddParameter("@LogDateTime", DateTime.Now);
            da.AddParameter("Mode", "D");
            int count = da.ExecuteNonQuery("Sp_UserGroup", System.Data.CommandType.StoredProcedure);
            if (count > 0)
                return true;
            else
                return false;
        }

        internal static bool ValidationUserGroup(string p, int Id)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("Select Count(*) From Tbl_UserGroup Where UserGroupName='" + p + "' and  UserGroupId!=" + Id + "", CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }
    }
}
