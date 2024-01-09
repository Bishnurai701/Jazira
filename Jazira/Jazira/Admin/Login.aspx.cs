using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using JaziraBusinessLayer.BLL.Admin;
using JaziraBusinessLayer.BLL.Security;
using JaziraBusinessLayer.BLL;


namespace Jazira.adminn
{
    public partial class Login1 : System.Web.UI.Page
    {
        UserBLL objUserBLL = new UserBLL();
        UserGroupBLL objUserGroupBLL = new UserGroupBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) == true)
            {
                lblMessage.Text = "*Enter LoginID !";
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text) == true)
            {
                lblMessage.Text = "*Enter Password !";
            }
            if (string.IsNullOrWhiteSpace(txtDate.Text) == true)
            {
                lblMessage.Text = "*Enter Date !";
            }
         
            Session["UserId"] = "0";
            Session["UserName"] = "";
            Session["Password"] = "";
            Session["UserGroupId"] = "0";
            string act = Request.QueryString["act"];
            if (!(string.IsNullOrEmpty(act)))
            {
                if(act=="logout")
                {
                Session["UserId"] = "0";
                Session["UserName"] = "";
                Session["Password"] = "";
                Session["UserGroupId"] = "0";
                lblMessage.Text = "Log Out Successfully! ";
                }
                else if (act == "invalid")
                {
                    Session["UserId"] = "0";
                    Session["UserName"] = "";
                    Session["Password"] = "";
                    Session["UserGroupId"] = "0";
                    lblMessage.Text = "Unauthorized Access! "; 
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
          
            if ((string.IsNullOrWhiteSpace(txtDate.Text)==true)||(string.IsNullOrWhiteSpace(txtPassword.Text)==true)||(string.IsNullOrWhiteSpace(txtUserName.Text) == true))
            {
                lblMessage.Text = "*You Missed! UserID/Password/Date !";
            }
            else
            {
                DateTime date = DateTime.Now;
                string sdate = Convert.ToDateTime(date).ToShortDateString();
                string cdate = Convert.ToDateTime(txtDate.Text).ToShortDateString();

                if (cdate == sdate)
                {
                    string password = objUserBLL.Encrypt(txtPassword.Text);
                    DataTable dt = objUserBLL.GetUserDetails(txtUserName.Text, password);
                    if (dt.Rows.Count > 0)
                    {
                        objUserBLL.InsertLogin(Convert.ToInt32(dt.Rows[0]["UserId"]));
                        Session["UserId"] = dt.Rows[0]["UserId"].ToString();
                        Session["UserName"] = txtUserName.Text;
                        Session["Password"] = txtPassword.Text;
                        Session["UserGroupId"] = dt.Rows[0]["UserGroupId"].ToString();
                        Response.Redirect("../About.aspx");

                    }
                    else
                    {
                        lblMessage.Text = "*Invalid LoginID or Password !";
                    }
                }
                else
                {

                    lblMessage.Text = "Sorry! Invalid Date. Enter Correct date !";
                }
            }
        }

    }
}