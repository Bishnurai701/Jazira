using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Jazira.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //JaziraBusinessLayer.BLL.Admin.LoginBLL objUser = new JaziraBusinessLayer.BLL.Admin.LoginBLL();
            //JaziraBusinessLayer.BLL.Admin.LoginBLL objReturnUser = new JaziraBusinessLayer.BLL.Admin.LoginBLL();
            //objReturnUser.UserId = 0;
            //objUser.LoginName = Session["LoginName"].ToString();
            //objUser.Password = Session["Password"].ToString();
            //objUser.UserGroupId = Convert.ToInt32(Session["UserGroupId"].ToString());

            //objReturnUser = JaziraBusinessLayer.BLL.Admin.LoginBLL.ifLoggedIn(objUser);
            //if (objReturnUser.UserId == 0)
            //{
            //    Response.Redirect("/Admin/Login.aspx?msg=unauthorised");
            //}
        }
    }
}