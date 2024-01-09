using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jazira.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string act = Request.QueryString["act"];
                if (!(string.IsNullOrEmpty(act)))
                {
                    if (act == "unauthorised")
                    {
                        lblMessage.Text = "Unauthorised Access Attempt";
                        lblMessage.CssClass = "error";
                    }
                    if (act == "logfail")
                    {
                        lblMessage.Text = "Invalit User Name or Password";
                        lblMessage.CssClass = "error";
                    }
                    if (act == "logout")
                    { 
                        
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}