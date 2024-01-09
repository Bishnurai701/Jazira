using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using JaziraBusinessLayer.BLL.General;
using JaziraDatabaseLayer;


namespace JaziraBusinessLayer.DLL.General
{
  public  class GoldTypeDLL
    {

      internal static bool Save(GoldTypeBLL dataa)
        {

            DataAccess da = new DataAccess();
            da.AddParameter("GoldTypeCode", dataa.GoldTypeCode);
            da.AddParameter("GoldTypeName", dataa.GoldTypeName);
            da.AddParameter("Status", dataa.Status);
            da.AddParameter("LoginId", dataa.LoginId);
            da.AddParameter("GoldTypeId", dataa.GoldTypeId);
            da.AddParameter("LogDateTime", dataa.LogDateTime);
            //SqlParameter GoldTypeId = new SqlParameter("GoldTypeId", SqlDbType.Int);
            //GoldTypeId.Direction = ParameterDirection.Output;
            int row = 0;
            if (dataa.GoldTypeId == 0)
            {
                da.AddParameter("Mode", "I");
                row = da.ExecuteNonQuery("Sp_GoldType", System.Data.CommandType.StoredProcedure);
            }
            else
            {
                //da.AddParameter("GoldTypeId", dataa.GoldTypeId);
                da.AddParameter("Mode", "U");
                row = da.ExecuteNonQuery("Sp_GoldType", System.Data.CommandType.StoredProcedure);
            }
            da.CloseConnection();
            if (row > 0)
                return true;
            else
                return false;
            
        }

        internal static bool ValidationGOldType(string p, int Id)
        {
            DataAccess da = new DataAccess();
            object obj = da.ExecuteScaler("Select Count(*) From Tbl_GoldType where GoldTypeName='" + p + "' and GoldTypeId!=" + Id + "", CommandType.Text);
            if (Convert.ToInt32(obj) > 0)
                return false;
            else
                return true;
        }

        internal static bool Delete(int Id)
        {
            DataAccess da = new DataAccess();
            da.AddParameter("GoldTypeId", Id);
            da.AddParameter("LogDateTime", DateTime.Now);
            da.AddParameter("Mode", "D");
            int count = da.ExecuteNonQuery("Sp_GoldType", System.Data.CommandType.StoredProcedure);
            if (count > 0)
                return true;
            else
                return false;

        }

        //internal static bool GetIDToShow(int Id)
        //{
        //    DataAccess da = new DataAccess();
        //    SqlCommand command = new SqlCommand();
        //    string cmd = new SqlCommand("Select GoldTypeId from Tbl_GoldType where GoldTypeID='" + txtGoldTypeCode.Text + "'");
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    int row = da.datatable.Rows.Count;
        //    SqlDataReader dr = command.ExecuteReader();
        //    if (!dr.HasRows)
        //    {
        //        dr.Read();
        //        int nId = Convert.ToInt32(dr[0]);

        //    }

        //    da.CloseConnection();
        //    return true;
        //}


        internal static DataTable GetGoldType(string GoldName)
        {
            DataAccess da = new DataAccess();
            string sql = "";
            if (GoldName == "")
            {
                sql = @"select GoldTypeId, GoldTypeCode, GoldTypeName, Status from Tbl_GoldType ORDER BY GoldTypeCode";
            }
            else
            {
                sql = @"select GoldTypeId, GoldTypeCode, GoldTypeName, Status from Tbl_GoldType";
                if (string.IsNullOrWhiteSpace(GoldName) == false)
                {
                    sql += " where GoldTypeName like '%" + GoldName + "%'";
                }
            }
            da.datatable = da.ExecuteDataTable(sql, CommandType.Text);
            int rows = da.datatable.Rows.Count;
            da.CloseConnection();
            return da.datatable;
        }




        //internal static DataTable GETGoldID(int Id)
        //{

        //    DataAccess da = new DataAccess();
        //    SqlCommand command = new SqlCommand();
        //    //String GoldTypeId = command.Parameters["GoldTypeId"].Value.ToString();
        //    string cmd = "Select GoldTypeId from Tbl_GoldType where GoldTypeID='" + Id + "'";
        //    SqlDataReader dr = command.ExecuteReader();
        //    //da.datatable = da.ExecuteDataTable(cmd, CommandType.Text);
        //    int row = da.datatable.Rows.Count;
        //    if (!dr.HasRows)
        //    {
        //        dr.Read();
        //        int nId = Convert.ToInt32(dr[0]);
        //        SqlInfoMessageEventArgs.Equals("Id", +nId);
        //    }

        //    da.CloseConnection();
        //    return da.datatable;
            
        //}
        //internal static object FetchGoldId(int Id)
        //{
        //    DataAccess da = new DataAccess();
        //    string sql = "";
        //    sql="select GoldTypeId  from Tbl_GoldType where GoldTypeId='" + Id + "' ";
        //    da.ExecuteNonQuery(sql, CommandType.Text);
        //    if (SqlDataReader.Read())
        //    { 
               
        //    }
            
        //    da.CloseConnection();
        //    return sql;

        //internal static bool FetchGoldId(int Id)
        //{
        //    var GoldId=(from s in from s in db.Tbl_GoldType where s.ID==Id select s.GoldTypeId).FirstOrDefault();
        //    if(Tbl_GoldType!=null)
        //    {
        //        Gold=GoldId;
        //    }

        //    return true;
        //}


        //internal static DataTable FetchGoldId(int Id)
        //{
        //    DataAccess da = new DataAccess();
        //    da.AddParameter("GoldTypeId", Id);
        //    SqlParameter GoldTypeId = new SqlParameter("@GoldTypeId", SqlDbType.Int);
        //    GoldTypeId.Direction = ParameterDirection.Output;
        //    int rows = 0;
        //    da.AddParameter("Mode", "SW");
        //    rows = da.ExecuteNonQuery("Sp_ShowGoldId", System.Data.CommandType.StoredProcedure);
        //    int r = da.datatable.Rows.Count;
        //    SqlDataReader dr=new SqlDataReader();
        //    if (!dr.HasRows)
        //    {
        //        dr.Read();
        //        int nId = Convert.ToInt32(dr[0].ToString());

        //    }
        //    da.CloseConnection();
        //    return da.datatable;

        //}

        //internal static object GetMaxGoldIdNo()
        //{
        //    DataAccess da = new DataAccess();
        //    string sql = "select MAX(GoldTypeId) from Tbl_GoldType";
        //    object obj = da.ExecuteScaler(sql, System.Data.CommandType.Text);
        //    //int rows = da.datatable.Rows.Count;
        //    if (obj.ToString() == "")
        //        obj = 0;
        //    return obj;
        //}


        //internal static DataTable GetGoldId(int a)
        //{
           
        //    DataAccess da = new DataAccess();
        //    SqlConnection con=new SqlConnection(@" Data Source=BISHNU\SQLEXPRESSDB;Initial Catalog=Jaziradb;Persist Security Info=True;User ID=admin; Password=adminsql");
        //    con.Open();
        //    string Sql = "select *from Tbl_GoldType";
        //    SqlDataAdapter sqlda = new SqlDataAdapter(Sql,con);
        //    DataSet ds = new DataSet();
        //    sqlda.Fill(ds);
        //    if (ds.Tables[0].Rows.Count!=0)
        //    {
        //        a = ds.Tables[0].Rows.Count;
        //        a += 1;
        //    }
        //    return da.datatable;


        //}


        //internal static DataTable GoldIdSave(GoldTypeBLL dataa)
        //{
        //    DataAccess data = new DataAccess();
        //    SqlCommand sqlcomd = new SqlCommand();
        //    sqlcomd.Parameters.AddWithValue("@GoldTypeId", dataa.GoldTypeId);
        //    return data.datatable;
        //}

        internal static DataTable GetGoldTypeName(int Id)
        {
            DataAccess data = new DataAccess();
            string sql = @"select GoldTypeId, GoldTypeCode, GoldTypeName From Tbl_GoldType where Status!='D' and GoldTypeId='" + Id + "'";
            data.datatable = data.ExecuteDataTable(sql, CommandType.Text);
            int rows = data.datatable.Rows.Count;
            data.CloseConnection();
            return data.datatable;
        }
    }
}
