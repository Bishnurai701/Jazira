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
 public  class StoneShapeDLL
    {
        internal static bool Delete(int Id)
        {
            DataAccess data = new DataAccess();
            data.AddParameter("StoneShapeId", Id);
            data.AddParameter("LogDateTime", DateTime.Now);
            data.AddParameter("Mode", "D");
            int Count = data.ExecuteNonQuery("Sp_StoneShape", System.Data.CommandType.StoredProcedure);
            if (Count > 0)
                return true;
            else
                return false;
        }

        internal static DataTable SetStopneShapeName(int Id)
        {
            DataAccess da = new DataAccess();
            string sql = @"select StoneShapeId,StoneShapeCode, StoneShapeName from Tbl_StoneShape where Status!='D' and StoneShapeId='" + Id + "'";
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }

        internal static bool ValidationStoneShape(string p, int SSId)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("select Count(*) From Tbl_StoneShape where StoneShapeName='" + p + "' and StoneShapeId!='" + SSId + "'", CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }

        internal static bool Save(StoneShapeBLL data)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("StoneShapeId", data.StoneShapeId);
            da.AddParameter("StoneShapeCode", data.StoneShapeCode);
            da.AddParameter("StoneShapeName", data.StoneShapeName);
            da.AddParameter("Status", data.Status);
            da.AddParameter("LoginId", data.LoginId);
            da.AddParameter("LogDateTime", data.LogDateTime);
            SqlParameter StoneShapeId = new SqlParameter("StoneShapeId", SqlDbType.Int);
            StoneShapeId.Direction = ParameterDirection.Output;
            int row = 0;
            if (data.StoneShapeId == 0)
            {
                da.AddParameter("Mode", "I");
                row = da.ExecuteNonQuery("Sp_StoneShape", System.Data.CommandType.StoredProcedure);

            }
            else
            {
                da.AddParameter("Mode", "U");
                row = da.ExecuteNonQuery("Sp_StoneShape", System.Data.CommandType.StoredProcedure);

            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;
        }

        internal static DataTable GetStoneShapeGridView(string StoneSName)
        {
            DataAccess da = new DataAccess();
            string sql = "";
            if (StoneSName == "")
            {
                sql = @"select StoneShapeId,StoneShapeCode, StoneShapeName, Status from Tbl_StoneShape ORDER BY StoneShapeCode";

            }
            else
            {
                sql = @"select StoneShapeId,StoneShapeCode, StoneShapeName, Status from Tbl_StoneShape";
                if (string.IsNullOrWhiteSpace(StoneSName) == false)
                {
                    sql += " where StoneShapeName like '" + StoneSName + "%'";
                }
            }
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int row = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }
    }
}
