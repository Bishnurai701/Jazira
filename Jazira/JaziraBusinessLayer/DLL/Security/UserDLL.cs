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
  public class UserDLL
    {
        internal static DataTable GetUserGroup()
        {
            DataAccess da = new DataAccess();
            string sql = @"select UserGroupId as ID, UserGroupName as Name from Tbl_UserGroup";
            DataTable dt = da.ExecuteDataTable(sql, System.Data.CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static bool Delete(int Id)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("UserId", Id);
            da.AddParameter("LogDateTime", DateTime.Now);
            da.AddParameter("Mode", "D");
            int Count = da.ExecuteNonQuery("Sp_User", System.Data.CommandType.StoredProcedure);
            if (Count > 0)
                return true;
            else
                return false;
        }

        internal static bool ValidationUserCode(string UCode, int Id)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("select Count(*) from Tbl_User where UserCode='" + UCode + "' and UserId!='" + Id + "'", CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }

        internal static bool ValidationLoginName(string LogName, int Id)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("select Count(*) from Tbl_User where LoginName='" + LogName + "' and UserId!='" + Id + "'", CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }

        internal static DataTable SetUser(int Id)
        {
            DataAccess da = new DataAccess();
            string sql = @"select UserId,UserCode, UserName, LoginName, Password,UserGroupId, SuperUser, JobView, GroupView,IsActive from Tbl_User where Status!='D' and UserId='"+Id+"'";
            DataTable dt = da.ExecuteDataTable(sql, CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static bool Save(UserBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("UserId", data.UserId);
            da.AddParameter("UserCode", data.UserCode);
            da.AddParameter("UserName", data.UserName);
            da.AddParameter("LoginName", data.LoginName);
            da.AddParameter("Password", data.Password);
            da.AddParameter("IsLogin", data.IsLogin);
            da.AddParameter("UserGroupId", data.UserGroupId);
            da.AddParameter("SuperUser", data.SuperUser);
            da.AddParameter("JobView", data.JobView);
            da.AddParameter("GroupView", data.GroupView);
            da.AddParameter("IsActive", data.IsActive);
            da.AddParameter("Status", data.Status);
            da.AddParameter("LoginId", data.LoginId);
            da.AddParameter("LogDateTime", data.LogDateTime);
            int row = 0;
            if (data.UserId == 0)
            {
                da.AddParameter("Mode", "I");
                row = da.ExecuteNonQuery("Sp_User", System.Data.CommandType.StoredProcedure);

            }
            else
            {
                da.AddParameter("Mode", "U");
                row = da.ExecuteNonQuery("Sp_User", System.Data.CommandType.StoredProcedure);
            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;

        }

        internal static DataTable GetUserName(string UName)
        {
            DataAccess da = new DataAccess();
            string sql = "";
            if (UName == "")
            {
                sql = @"select U.UserId, U.UserCode, U.UserName, U.LoginName, U.Password, UG.UserGroupName, U.SuperUser, U.JobView, U.GroupView, U.IsActive, U.Status
		                from Tbl_User  U 
                        inner join Tbl_UserGroup  UG on UG.UserGroupId=U.UserGroupId  ORDER BY(CONVERT(int,U.UserCode))";

            }
            else
            {
                sql = @"select U.UserId, U.UserCode, U.UserName, U.LoginName, U.Password, UG.UserGroupName, U.SuperUser, U.JobView, U.GroupView, U.IsActive, U.Status
		                from Tbl_User  U 
                        inner join Tbl_UserGroup  UG on UG.UserGroupId=U.UserGroupId";
                if (string.IsNullOrWhiteSpace(UName) == false)
                {
                    sql += " where UserName like '" + UName + "%'";
                }
            }
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }

        //internal static bool ValidationOldPassword(int id, string password)
        //{
        //    DataAccess da = new DataAccess();
        //    string sql = @"select COUNT(*) from Tbl_User where UserId='"+id+"' and Password='"+password+"'";
        //    object count = da.ExecuteScaler(sql, CommandType.Text);
        //    da.CloseConnection();
        //    if (Convert.ToInt32(count) > 0)
        //        return true;
        //    else
        //        return false;

        //}

        internal static bool ChangePassword(string id, string password)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("Password", password);
            da.AddParameter("UserId", id);
            da.AddParameter("LogDateTime", DateTime.Now);
            da.AddParameter("Mode", "CP");
            int row = da.ExecuteNonQuery("Sp_User", CommandType.StoredProcedure);
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;
        }

        internal static bool ValidationOldPassword(string id, string password)
        {
            DataAccess da = new DataAccess();
            string sql = @"select COUNT(*) from Tbl_User where UserId='" + id + "' and [Password]='" + password + "'";
            object count = da.ExecuteScaler(sql, CommandType.Text);
            da.CloseConnection();
            if (Convert.ToInt32(count) > 0)
                return true;
            else
                return false;
        }

        internal static DataTable GetUserDetails(string loginname, string password)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("loginname", loginname);
            da.AddParameter("password", password);
            da.datatable = da.ExecuteDataTable("Sp_GetUserDetails", System.Data.CommandType.StoredProcedure);
            da.CloseConnection();
            return da.datatable;
        }

        internal static void InsertLogin(int userid)
        {
            DataAccess da = new DataAccess();
            string sql ="select [LoginCount] from [Tbl_UserLoginStatus] where [UserId]=" + userid + ""; ;
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int logincount;
            if (da.datatable.Rows.Count > 0)
            {
                //logincount = Convert.ToInt32(da.datatable.Rows[0]["logincount"]);
                logincount =Convert.ToInt32( da.datatable.Rows.Count);
            }
            else
            {
                logincount = 0;
            }
            string mainsql = string.Empty;
            if (logincount == 0)
            {
                mainsql ="insert into Tbl_UserLoginStatus values(@UserId,@LoginDateTime,@LogOutDateTime,@Status,@LoginCount)";
                SqlCommand cmd = new SqlCommand(mainsql, da.connection);
                cmd.Parameters.AddWithValue("@UserId", userid);
                cmd.Parameters.AddWithValue("@LoginDateTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogOutDateTime", DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", "I");
                cmd.Parameters.AddWithValue("@LoginCount", logincount);
                cmd.ExecuteNonQuery();
            }
            else if (logincount > 0)
            {
                logincount = logincount + 1;
                mainsql ="insert into Tbl_UserLoginStatus values(@UserId,@LoginDateTime,@LogOutDateTime,@Status,@LoginCount)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = mainsql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = da.connection;
                cmd.Parameters.AddWithValue("@UserId", userid);
                cmd.Parameters.AddWithValue("@LoginDateTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@LogOutDateTime", DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", "I");
                cmd.Parameters.AddWithValue("@LoginCount", logincount);
                da.OpenConnection();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
