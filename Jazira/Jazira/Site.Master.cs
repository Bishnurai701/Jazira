using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using JaziraBusinessLayer.BLL.Admin;
using JaziraDatabaseLayer;

namespace Jazira
{
    public partial class Site : System.Web.UI.MasterPage
    {
        JaziraBusinessLayer.BLL.Admin.LoginBLL objLogin = new JaziraBusinessLayer.BLL.Admin.LoginBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }
}