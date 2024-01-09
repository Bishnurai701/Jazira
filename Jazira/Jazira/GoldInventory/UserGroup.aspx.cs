using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Jazira.GoldInventory
{
    public partial class UserGroup : System.Web.UI.Page
    {
        
        JaziraBusinessLayer.BLL.UserGroupBLL objUserGroupBLL = new JaziraBusinessLayer.BLL.UserGroupBLL();
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
                if (act == "edit" || act == "add")
                { 
                   CODE.ddlGeneral.LoadDropDownList_withAll(ddlUserGroupType,new JaziraBusinessLayer.BLL.UserGroupBLL().GetUserTypeByIdName());
                   if (act == "edit")
                   {
                       SetDataToField(Id);
                   }
                   
                }
                

                if (act == "del")
                {
                    if (objUserGroupBLL.Delete(Id))
                    {
                        setSessionMsg("alert-success alert col-md-6", "Deleted Successfullyyyyy", true);
                        Response.Redirect("UserGroup.aspx?act=add",false);
                    }
                }
                if (act == "search" || act=="list")
                {
                    DGVUserGroup();
                }
            }
        }

        //private void Search()
        //{
        //    System.Data.DataTable dt = objUserGroupBLL.GetUserGroup(txtSearchUserGroup.Text);
        //    dgvUserGroup.DataSource = dt;
        //    dgvUserGroup.DataBind();
        //    if (dt.Rows.Count > 0)
        //        divNoDaa.Visible = false;
        //    else
        //        divNoDaa.Visible = true;
        //}

        private void SetDataToField(int Id)
        {

            DataTable dt = new JaziraBusinessLayer.BLL.UserGroupBLL().GetUserTypeById(Id);
            txtUserGroupName.Text = dt.Rows[0]["UserGroupName"].ToString();
            ddlUserGroupType.SelectedValue = dt.Rows[0]["UserTypeId"].ToString();
            tbnSave.Text = "Update";

        }

        public void SetDDLUserTypeId()
        {
            DataTable dt = objUserGroupBLL.GetUserType();
            int rows = dt.Rows.Count;
            ddlUserGroupType.DataTextField = "UserTypeName";
            ddlUserGroupType.DataValueField = "UserTypeId";
            ddlUserGroupType.DataSource = dt;
            ddlUserGroupType.DataBind();
        }

#region  Save event
        protected void tbnSave_Click(object sender, EventArgs e)
        {
            try
                {
                 if (string.IsNullOrWhiteSpace(txtUserGroupName.Text)==true)
                     {
                        setSessionMsg("alert-error alert col-md-6", "Please! Enter User Group Name.", true);
                        txtUserGroupName.Focus();
                        return;
                      }

                      int Id=Convert.ToInt32(Request.QueryString["Id"]);
                      if(objUserGroupBLL.ValidationUserGroup(txtUserGroupName.Text,Id)==false)
                      {
                          setSessionMsg("alert-error alert col-md-6", "Alerady Exist! User Group",true);
                          txtUserGroupName.Focus();
                          return;
                      }

                   objUserGroupBLL = SetData();
                   if (objUserGroupBLL.Save(objUserGroupBLL))
                    {
                        Clear();                        
                        setSessionMsg("alert-success alert col-md-5", "Record Saved Successfully and Do u want again!", true);
                        Response.Redirect("UserGroup.aspx?act=add", false);
                    }
                }
                catch (System.Data.SqlClient.SqlException sex)
                {
                   setSessionMsg("alert-success alert col-md-6", ""+sex+"", true); 
                }
                catch (Exception ex)
                {
                    setSessionMsg("alert-success alert col-md-6", ""+ex+"", true);
                }
            }

#endregion

        private JaziraBusinessLayer.BLL.UserGroupBLL SetData()
        {
            objUserGroupBLL.UserGroupName = txtUserGroupName.Text;
            objUserGroupBLL.UserTypeId = Convert.ToInt32(ddlUserGroupType.SelectedValue);
            objUserGroupBLL.Status = 'A';
            objUserGroupBLL.LoginId = 1;
            objUserGroupBLL.LogDateTime = DateTime.Now;
            string act = Request.QueryString["act"];
            if (act == "edit")
            {
                int id = 0;
                int.TryParse(Request.QueryString["Id"], out id);
                objUserGroupBLL.UserGroupId = id;
            }
            return objUserGroupBLL;
        }


        private void setSessionMsg(string msgClass, string msgMessage, bool msgStatus)
        {
            Session["msgInfo"] = msgMessage;
            Session["msgCss"] = msgClass;
            messaging_alert.Visible = msgStatus;
            button_close.Visible = msgStatus;
            if (msgStatus == true)
            {
                //lblAlertMessage.Text = Session["msgInfo"].ToString();
                messaging_alert.Attributes.Add("class", Session["msgCss"].ToString());
            }
        }


        private void Clear()
        {
            txtUserGroupName.Text = "";
        }

        //private bool ValidateData()
        //{
            
        //    }
        //    return true;
        //}
 #region  GriedView function
        protected void dgvUserGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvUserGroup.PageIndex = e.NewPageIndex;
            DGVUserGroup();
            
        }
 #endregion
#region Search Event
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DGVUserGroup();
            //dgvUserGroup.DataSource = objUserGroupBLL.GetDataByUserGroupName(txtSearchUserGroup.Text);
            //dgvUserGroup.DataBind();
        }
#endregion
        private void DGVUserGroup()
        {
            try
            {
                System.Data.DataTable dt = objUserGroupBLL.GetUserGroup(txtSearchUserGroup.Text);
                dgvUserGroup.DataSource = dt;
                dgvUserGroup.DataBind();
                if (dt.Rows.Count > 0)
                    divNoDaa.Visible = false;
                else
                    divNoDaa.Visible = true;
                //System.Data.DataTable dt = objUserGroupBLL.GetDataByUserGroupName(txtSearchUserGroup.Text);//GetUserGroupByName
                //int rows = dt.Rows.Count;
                //ddlUserGroupType.DataTextField = "UserTypeName";
                //ddlUserGroupType.DataValueField = "UserTypeId";
                //ddlUserGroupType.DataSource = dt;
                //ddlUserGroupType.DataBind();
            }
            catch (System.Data.SqlClient.SqlException sql)
            {
                setSessionMsg("alert-error alert col-md-6", sql.Message + "" + sql.Source, true);

            }
            catch(Exception ex)
            {
                setSessionMsg("alert-error alert col-md-6", ex.Message + "" + ex.Source, true);
            }
        }
    }
}