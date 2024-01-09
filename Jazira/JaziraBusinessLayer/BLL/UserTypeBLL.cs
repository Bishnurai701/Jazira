using JaziraBusinessLayer.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using JaziraBusinessLayer.BLL;

namespace JaziraBusinessLayer.BLL
{
#region property created by Bishnu Khaling
    public class UserTypeBLL
    {
        private int _UserTypeId;

        public int UserTypeId
        {
            get { return _UserTypeId; }
            set { _UserTypeId = value; }
        }

        private string _UserTypeName;

        public string UserTypeName
        {
            get { return _UserTypeName; }
            set { _UserTypeName = value; }
        }

        private char _Status;

        public char Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private Int32 _LoginId;

        public Int32 LoginId
        {
            get { return _LoginId; }
            set { _LoginId = value; }
        }
        private DateTime _LogDateTime;

        public DateTime LogDateTime
        {
            get { return _LogDateTime; }
            set { _LogDateTime = value; }
        }
#endregion
        public bool Save(UserTypeBLL data)
        {
            return UserTypeDLL.Save(data);
        }

        public System.Data.DataTable GetUserTypeById(int Id)
        {
            return UserTypeDLL.GetUserTypeById(Id);
        }

        public static bool Delete(int Id)
        {
            return UserTypeDLL.Delete(Id);
        }

        public System.Data.DataTable GetUserTypeByUserTyneName(string name)
        {
            return UserTypeDLL.GetUserTypeByUserTyneName(name);
        }

        public static bool ValidationUserType(string p, int Id)
        {
            return UserTypeDLL.ValidationUserType(p, Id);
        }
    }
}
