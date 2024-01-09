using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace JaziraDatabaseLayer
{
    using System;
    using System.Data;
    using System.Configuration;
    using System.Data.SqlClient;
    public class DataAccess:IDisposable
    {
        public SqlCommand command;
        public SqlConnection connection;
        public static string constr;
        public System.Data.SqlClient.SqlDataReader datareader;
        public System.Data.DataTable datatable;

     public DataAccess()
        {
            connection = new SqlConnection();
            command = new SqlCommand();
            //connection.ConnectionString = @" Data Source=BISHNU\SQLEXPRESSDB; Initial Catalog=Jaziradb;Persist Security Info=True;User ID=admin; Password=adminnn";
            connection.ConnectionString = @" Data Source=PC\SQLEXPRESS;Initial Catalog=jaziradb;Persist Security Info=True;User ID=admin;Password=admin1";

            //connection.ConnectionString = @"Data Source=EKHLAQUE-PC\SQLEXPRESS;Initial Catalog=NewYMAcademic_Db;Persist Security Info=True;User ID=sa; Password=sa2sa";
            //connection.ConnectionString = @"Data Source=Lalit-PC\SQLEXPRESS\SQLEXPRESS;Initial Catalog=YMAcademicDB;Persist Security Info=True;User ID=sa; Password=sa2sa";
            // connection.ConnectionString = @"Data Source=Lalit-PC\SQLEXPRESS\SQLEXPRESS;Initial Catalog=YMAcademicDB;Persist Security Info=True;User ID=sa; Password=sa2sa";
            command.Connection = connection;
        }

        #region "Connection"
        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
        public void Dispose()
        {
            CloseConnection();
            GC.SuppressFinalize(this);
        }
        #endregion

        #region "Execute Adapter"
        public SqlDataAdapter ExecuteAdapter(string commstr)
        {
            return (ExecuteAdapter(commstr, CommandType.StoredProcedure));
        }
        public SqlDataAdapter ExecuteAdapter(string commstr, CommandType commtype)
        {
            command.CommandText = commstr;
            command.CommandType = commtype;
            OpenConnection();
            SqlDataAdapter objadapter = new SqlDataAdapter(command);
            return (objadapter);
        }

        #endregion

        #region "ExecuteNonQuery"
        public int ExecuteNonQuery(string commstr)
        {
            return (ExecuteNonQuery(commstr, CommandType.StoredProcedure));
        }
        public int ExecuteNonQuery(string commstr, CommandType commtype)
        {
            command.CommandText = commstr;
            command.CommandType = commtype;
            OpenConnection();
            int rows = command.ExecuteNonQuery();
            return (rows);
        }

        #endregion

        #region "ExecuteReader"
        public SqlDataReader ExecuteReader(string commstr)
        {
            return (ExecuteReader(commstr, CommandType.StoredProcedure));
        }
        public SqlDataReader ExecuteReader(string commstr, CommandType commtype)
        {
            return (ExecuteReader(commstr, commtype, CommandBehavior.CloseConnection));
        }
        public SqlDataReader ExecuteReader(string commstr, CommandType commtype, CommandBehavior commbehavior)
        {
            command.CommandText = commstr;
            command.CommandType = commtype;
            OpenConnection();
            SqlDataReader dr = command.ExecuteReader();
            return dr;
        }
        #endregion

        #region "ExecuteDataTable"
        public DataTable ExecuteDataTable(string commstr)
        {
            return (ExecuteDataTable(commstr, CommandType.StoredProcedure));
        }
        public DataTable ExecuteDataTable(string commstr, CommandType commandtype)
        {
            return (ExecuteDataTable(commstr, commandtype, CommandBehavior.CloseConnection));
        }
        public DataTable ExecuteDataTable(string commstr, CommandType commandtype, CommandBehavior commandbehavior)
        {
            command.CommandText = commstr;
            command.CommandType = commandtype;
            OpenConnection();
            SqlDataReader dr = command.ExecuteReader();
            DataTable dt = new DataTable();

            if (dt.Columns.Count == 0)
            {
                for (int c = 0; c < dr.FieldCount; c++)
                {
                    dt.Columns.Add(dr.GetName(c), dr.GetFieldType(c));
                }
            }
            while (dr.Read())
            {
                if (dt.Columns.Count == 0)
                {
                    for (int c = 0; c < dr.FieldCount; c++)
                    {
                        dt.Columns.Add(dr.GetName(c), dr.GetFieldType(c));
                    }
                }
                DataRow row = dt.NewRow();
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    row[c] = dr[c];
                }
                dt.Rows.Add(row);
            }
            dr.Close();
            return dt;
        }

        #endregion

        #region "ExecuteScaler"
        public object ExecuteScaler(string commstr)
        {
            return (ExecuteScaler(commstr, CommandType.StoredProcedure));
        }
        public object ExecuteScaler(string commstr, CommandType commtype)
        {
            command.CommandText = commstr;
            command.CommandType = commtype;
            OpenConnection();
            object objreturn = command.ExecuteScalar();
            CloseConnection();
            return (objreturn);
        }
        #endregion

        #region "Parameters"
        public void AddParameter(string parametername, object value)
        {
            SqlParameter par = new SqlParameter();
            par.ParameterName = parametername;
            par.Value = value;
            command.Parameters.Add(par);
        }

        public void AddParameter(string parametrname, SqlDbType dbtype, object value)
        {
            SqlParameter par = new SqlParameter();
            par.ParameterName = parametrname;
            par.SqlDbType = dbtype;
            par.Value = value;
            par.Direction = ParameterDirection.Input;
            command.Parameters.Add(par);
        }

        public void AddParameter(string parametername, ParameterDirection parameterdirection, SqlDbType dbtype)
        {
            SqlParameter par = new SqlParameter();
            par.ParameterName = parametername;
            par.SqlDbType = dbtype;
            par.Direction = parameterdirection;
            command.Parameters.Add(par);
        }

        public void ModifyParameter(string parametername, object value)
        {
            if (command.Parameters[parametername].SqlDbType == SqlDbType.UniqueIdentifier)
            {
                if (value.GetType() == typeof(System.String))
                    value = new System.Guid(value.ToString());
            }
            command.Parameters[parametername].Value = value;
        }

        public Object GetParameter(string parametername)
        {
            if (command.Parameters.IndexOf(parametername) >= 0)
                return (command.Parameters[parametername].Value);
            else
                return null;
        }

        public void RemoveParameter(string parametername)
        {
            if (command.Parameters.IndexOf(parametername) != 0)
                command.Parameters.RemoveAt(command.Parameters.IndexOf(parametername));
        }


        #endregion
    }
}
