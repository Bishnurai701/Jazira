using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Jazira.GoldInventory;
using JaziraBusinessLayer.BLL;
using System.Data.SqlClient;



namespace Jazira.GoldInventory
{
    public partial class UserType : System.Web.UI.Page
    {
        UserTypeBLL objUserTypeBLL = new UserTypeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string act = Request.QueryString["act"];
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            if (!IsPostBack)
            {
                if (Session["msgInfo"] != null)
                {
                    messaging_alert.Visible = true;
                    button_close.Visible = true;
                    messaging_alert.Attributes.Add("class", Session["msgCss"].ToString());
                    Session["msgCss"] = "";

                }
                messaging_alert.Visible = false;
                if  (act == "edit")
                {
                    //DataTable dt = UserTypeBLL.GetUserTypeById(Id);
                    //txtUserType.Text = dt.Rows[0]["UserTypeName"].ToString();
                    //tbnSave.Text = "Update";
                    SetDataToField();
                    //UserTypeBLL data = new UserTypeBLL();
                    //DataTable dt = new DataTable();
                    //int id = Convert.ToInt32(Request.QueryString["id"]);
                    //DataTable dt=UserTypeBLL.GetUserTypeById(id);
                    //txtUserType.Text = dt.Rows[0]["UserTypeName"].ToString();
                    //tbnSave.Text = "Update";
                }
                if (act == "del")
                {
                    if (UserTypeBLL.Delete(Id))
                    {
                        setSessionMsg("alert-sucess alert col-md-6", "Record has Successfully Deleted", false);
                        DGVUserType();
                        Response.Redirect("UserType.aspx?act=list");
                    }
                   
                }
                if ((act == "list")||(act=="search"))
                {
                    DGVUserType();
                }
            }
        }

        private void SetDataToField()
        {


            DataTable dt = new DataTable();
            //int Id = 0;
            string act = Request.QueryString["act"];
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            UserTypeBLL data = new UserTypeBLL();
            dt = data.GetUserTypeById(Id);
            foreach (DataRow dr in dt.Rows)
            {
                txtUserType.Text = dr["UserTypeName"].ToString();
                break;
            }
            tbnSave.Text = "Update";

        }


#region gridview function working fine
        private void DGVUserType()
        {
            try
            {
                //string UserTypeName = txtUserType.Text.Trim().Replace("'", "''");
                System.Data.DataTable dt = objUserTypeBLL.GetUserTypeByUserTyneName(txtTypeNameSearch.Text);
                dgvUserType.DataSource = dt;
                dgvUserType.DataBind();
                if (dt.Rows.Count == 0)
                    divNoDaa.Visible = true;
                else
                    divNoDaa.Visible = false;
            }
            catch (System.Data.SqlClient.SqlException sql)
            {
                setSessionMsg("alert-error alert col-md-6", sql.Message + "" + sql.Source, true);
            }
            catch (Exception ex)
            {
                setSessionMsg("alert-error alert col-md-6", ex.Message + "" + ex.Source, true);

            }
        }

        #endregion


#region gridview function command
        protected void dgvUserType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvUserType.PageIndex = e.NewPageIndex;
            DGVUserType();
        }
        
#endregion
#region Save even
        protected void tbnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUserType.Text)==true)
                {
                    setSessionMsg("alert-error alert col-md-6", "Please Enter User Type", true);
                    txtUserType.Focus();
                    return;
                }
               
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                if (UserTypeBLL.ValidationUserType(txtUserType.Text, Id) == false)
                {
                    setSessionMsg("alert-error alert col-md-6", "Duplicate User Type Name !", true);
                    txtUserType.Focus();
                    return;
                }
                objUserTypeBLL = SetData();
                if (objUserTypeBLL.Save(objUserTypeBLL))
                    {
                    Clear();
                    setSessionMsg("alert-success alert col-md-6", "Data has been Saved Successfully", true);
                    //Response.Redirect("usertype.aspx?act=search", true);
                    }
              }
            
             catch (System.Data.SqlClient.SqlException ex)
              {
              setSessionMsg("alert-success alert col-md-6", "" + ex + "", true);
              }
             catch (Exception sex)
              {
               setSessionMsg("alert-success alert col-md-6", "" + sex + "", true);
              }
        }

              //else
            //{
            //  objUserTypeBLL = SetData();
            //  try
            //  {
            //      if (objUserTypeBLL.Save(objUserTypeBLL))
            //      {
            //          Clear();
            //          setSessionMsg("alert-success alert col-md-6", "Record Save Successfully.", false);
            //          Response.Redirect("UserType.aspx?act=search");
            //      }
            //      else
            //      {
            //          Clear();
            //          setSessionMsg("alert-error alert col-md-6", "Record not saved Name already created.", false);
            //          Response.Redirect("UserType.aspx?act=search");
            //      }
            //  }

              //  catch (System.Data.SqlClient.SqlException ex)
            //  {
            //      if (ex.Number == 2627)
            //      {
            //          setSessionMsg("alert-error alert col-md-6", "Type Name must be unique", true);

              //          return;
            //      }
            //      else
            //      {
            //          setSessionMsg("alert-error alert col-md-6", ex.Message, true);

              //          return;
            //      }
            //  }
           
       

        private void Clear()
        {
            txtUserType.Text = "";
        }

        private  UserTypeBLL SetData()
        {
            //string act = Request.QueryString["act"];
            //if(act=="edit")
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            objUserTypeBLL.UserTypeName = txtUserType.Text.Trim().Replace("'", "''");
            objUserTypeBLL.UserTypeId = Id; //Convert.ToInt32(Request.QueryString["UserTypeId"]);
            objUserTypeBLL.Status = 'A';
            objUserTypeBLL.LoginId = 1;
            objUserTypeBLL.LogDateTime = DateTime.Now;
            return objUserTypeBLL;
        }
#endregion 
#region alert messaging fuction
        private void setSessionMsg(string msgClass,string msgMessage,bool msgStatus)
            {
 	          Session ["msgInfo"]=msgMessage ;
              Session ["msgCss"]=msgClass ;
             messaging_alert.Visible=msgStatus ;
             button_close.Visible = msgStatus;
              if (msgStatus == true)
              {
                  lblAlertMessage.Text = Session["msgInfo"].ToString();
                  messaging_alert.Attributes.Add("class", Session["msgCss"].ToString());
              }

            }
        #endregion 
#region serch even
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DGVUserType();
        }
#endregion
    //  private string GetAction(String id)
    //  {
    //      return @"<a href='UserType.aspx?act=edit&Id=" + id + @"'><img src='../style/icon/pencil.png' title='Edit'/></a>
    //              <a href=javascript:confirmAction('UserType.aspx?act=delete&Id=" + id + @"','UserType.aspx?act=search')>
    //              <img src='../style/icon/delete.png' title='Delete'/></a>";
    //  }
    }
}