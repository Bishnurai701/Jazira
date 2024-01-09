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
   public class GroupMasterMaintenaceDLL
    {
        internal static DataTable GetSectionCode()
        {
            DataAccess da = new DataAccess();
            string sql = "select SectionCode as ID, SectionName as Name from Tbl_Section";
            DataTable dt = da.ExecuteDataTable(sql,CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static DataTable GetSalaryType()
        {
            DataAccess da = new DataAccess();
            string sql = "select SalaryTypeCode as ID, SalaryTypeName as Name from Tbl_SalaryType";
            DataTable dt = da.ExecuteDataTable(sql,CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static DataTable GetWSection()
        {
            DataAccess da = new DataAccess();
            string sql = "select WorkingSectionCode as ID, WorkingSectionName as Name from Tbl_WorkingSection";
            DataTable dt = da.ExecuteDataTable(sql,CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static DataTable GetGroupCode(int Id)
        {
            DataAccess da = new DataAccess();
            string sql = @"select GroupCodeId, GroupNo, RecCode, DelCode, SafeNo, Status from Tbl_GroupCode where GroupCodeId='"+Id+"'";
            try
            {
                DataTable dt = da.ExecuteDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                da.CloseConnection();
            }
        }

        internal static DataTable SetGroupMaster(int Id)
        {
            DataAccess da = new DataAccess();
            string sql = @"select GroupMastId, GroupNo,GroupName,SectionCode,SalaryTypeCode,Salary,WorkCarat,Productive,IsSafe,IDRequired,IsMainSafe,RelatedGroup,IsActiveGroup,WorkingSectionId, JobNo, JobChar, TypeMastId, TypeDescription from Tbl_GroupMast where Status!='D' and GroupMastId='"+Id+"' ";
            DataTable dt = da.ExecuteDataTable(sql, CommandType.Text);
            da.CloseConnection();
            return dt;
        }

        internal static bool ValidationGroupCode(string gcode, int Id)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("Select Count(*) from Tbl_GroupMast where GroupNo='"+gcode+"' and GroupMastId!='"+Id+"'");
            if (Convert.ToInt32(obj) >= 0)
                return false;
            else
                return true;
        }

        internal static bool ValidationDescription(string gname, int Id)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("Select Count(*) from Tbl_GroupMast where GroupName='"+gname+"' and GroupMastId!='"+Id+"'");
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }

        internal static bool ValidationUnique(string uqname, int Id)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("select Count(*) from Tbl_UniqueNo where UniqueNo='"+uqname+"' and UniqueId!='"+Id+"'");
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }
    }
}
