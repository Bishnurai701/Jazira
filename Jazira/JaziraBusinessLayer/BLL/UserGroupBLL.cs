using JaziraBusinessLayer.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaziraBusinessLayer.BLL
{
#region property created by bishnu khaling
  public  class UserGroupBLL
    {
      private int _UserGroupId;

public int UserGroupId
{
  get { return _UserGroupId; }
  set { _UserGroupId = value; }
}
      private string _UserGroupName;

public string UserGroupName
{
  get { return _UserGroupName; }
  set { _UserGroupName = value; }
}
    private int _UserTypeId;

public int UserTypeId
{
  get { return _UserTypeId; }
  set { _UserTypeId = value; }
}
      private char _Status;

public char Status
{
  get { return _Status; }
  set { _Status = value; }
}
      private int _LoginId;

public int LoginId
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

public bool Save(UserGroupBLL data)
{
    return JaziraBusinessLayer.DLL.UserGroupDLL.Save(data);
}

public System.Data.DataTable GetUserTypeByIdName()
{
    return JaziraBusinessLayer.DLL.UserGroupDLL.GetUserTypeByIdName();
}

public System.Data.DataTable GetUserTypeById(int Id)
{
    return JaziraBusinessLayer.DLL.UserGroupDLL.GetUserTypeById(Id);
}

public System.Data.DataTable GetUserType()
{
    return JaziraBusinessLayer.DLL.UserGroupDLL.GetUserType();
}

public System.Data.DataTable GetUserGroupByName()
{
    return UserGroupDLL.GetUserGroupByName();
}
//*****this is for gridview and search function
public System.Data.DataTable GetUserGroup(string Gname)
{
    return UserGroupDLL.GetUserGroup(Gname);
}

//public object GetDataByUserGroupName(string name)
//{
//    return UserGroupDLL.GetDataByUserGroupName(name);
//}

public bool Delete(int Id)
{
    return UserGroupDLL.Delete(Id);
}

public bool ValidationUserGroup(string p, int Id)
{
    return UserGroupDLL.ValidationUserGroup(p, Id);
}
    } 
}
