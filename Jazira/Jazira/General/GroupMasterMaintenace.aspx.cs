using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Configuration;
using System.Xml;
using JaziraBusinessLayer.BLL.General;
using Jazira.CODE;




namespace Jazira.General
{
    public partial class GroupMasterMaintenace : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        JaziraBusinessLayer.BLL.General.GroupCodeBLL objGroupCodeBLL = new JaziraBusinessLayer.BLL.General.GroupCodeBLL();
        JaziraBusinessLayer.BLL.General.GroupMasterMaintenaceBLL objGroupMasterBLL = new JaziraBusinessLayer.BLL.General.GroupMasterMaintenaceBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //ddlWSection.Attributes.Add("size", "5");
            if (Convert.ToBoolean(Session["edtiAlert"]) == true)
            {
                alert.Visible = true;
                lblMsg.Text = "Data Updated Successfully! ";
                lblMsgType.Text = "Wll done! ";
                alert.Attributes["class"] = "alert alert-success";
                Session["editAlert"] = false;
            }
            if (Convert.ToBoolean(Session["delAlert"]) == true)
            {
                alert.Visible = true;
                lblMsg.Text = "Data Deleted Successfully!";
                lblMsgType.Text = "Wll done! ";
                alert.Attributes["class"] = "alert alert-success";
                Session["delAlert"] = false;
            }
            if (Convert.ToBoolean(Session["addAlert"]) == true)
            {
                alert.Visible = true;
                lblMsg.Text = "Data Saved Successfully!";
                lblMsgType.Text = "Wll done! ";
                alert.Attributes["class"] = "alert alert-success";
                Session["addAlert"] = false;
            }
            string act =Request.QueryString["act"];
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            if (!IsPostBack)
            {
                
                if (act == "search" || act == "list")
                {
                       //BindGridView();
                }
                if (act == "edit" || act == "add")
                {
                    CODE.ddlGeneral.LoadSectionCode(ddlSection, new JaziraBusinessLayer.BLL.General.GroupMasterMaintenaceBLL().GetSectionCode());
                    CODE.ddlGeneral.LoadSalaryType(ddlSalaryType, new JaziraBusinessLayer.BLL.General.GroupMasterMaintenaceBLL().GetSalaryType());
                    CODE.ddlGeneral.LoadWSection(ddlWSection, new JaziraBusinessLayer.BLL.General.GroupMasterMaintenaceBLL().GetWSection());
                   
                    if (act == "edit")
                    {
                        SetDataToField(Id); 
                    }
                      //BindGridView();
                    addFirstGridRow();
                }
                
            }
        }

        #region function

        #region SetDataToField
        private void SetDataToField(int Id)
        {
            try
            {
                string act=Request.QueryString["act"];
                DataTable dt = JaziraBusinessLayer.BLL.General.GroupMasterMaintenaceBLL.SetGroupMaster(Id);
                txtGroupNo.Text = dt.Rows[0]["GroupNo"].ToString();
                txtRelatedGroup.Text = dt.Rows[0]["RelatedGroup"].ToString();
                txtGroupDesc.Text = dt.Rows[0]["GroupName"].ToString();
                ddlSection.SelectedValue = dt.Rows[0]["SectionCode"].ToString();
                ddlSalaryType.SelectedValue = dt.Rows[0]["SalaryTypeCode"].ToString();
                ddlWSection.SelectedValue = dt.Rows[0]["WorkingSectionId"].ToString();
                txtSalary.Text = dt.Rows[0]["Salary"].ToString();
                txtCARAT.Text = dt.Rows[0]["WorkCarat"].ToString();
                string IsActiveGroup = Convert.ToBoolean(dt.Rows[0]["IsActiveGroup"]).ToString();
                if (Convert.ToBoolean(IsActiveGroup) == true)
                {
                    chkDisabledGroup.Checked = true;
                }
                else
                {
                    chkDisabledGroup.Checked = false;
                }
                string IDRequired = Convert.ToBoolean(dt.Rows[0]["IDRequired"]).ToString();
                if (Convert.ToBoolean(IDRequired) == true)
                {
                    chkIDRequired.Checked = true;
                }
                else
                {
                    chkIDRequired.Checked = false;
                }
                string Productive = Convert.ToBoolean(dt.Rows[0]["Productive"]).ToString();
                if (Convert.ToBoolean(Productive) == true)
                {
                    rbProsuctive.Checked = true;
                }
                else
                {
                    rbNonProductive.Checked = true;
                }
                string IsSafe = Convert.ToBoolean(dt.Rows[0]["IsSafe"]).ToString();
                if (Convert.ToBoolean(IsSafe) == true)
                {
                    var div = ListaEmOutrosDocumentos as HtmlGenericControl;
                    div.Style.Clear();
                    div.Style.Add("background-color", "#dce5e0");
                    div.Style.Add("border-radius", "17px 17px 17px 17px");
                    div.Style.Add("-moz-border-radius", "17px 17px 17px 17px");
                    div.Style.Add("-webkit-border-radius", "17px 17px 17px 17px");
                    div.Style.Add("display", "block");
                    chkSafeAcc.Checked = true;
                    txtSerialNo.Text = dt.Rows[0]["SerialNo"].ToString();
                    txtNextMonthSerNo.Text = dt.Rows[0]["NextSerialNo"].ToString();
                    txtFirstLetter.Text = dt.Rows[0]["FirstLetter"].ToString();
                    string IsMainSafe = Convert.ToBoolean(dt.Rows[0]["IsMainSafe"]).ToString();
                    if (Convert.ToBoolean(IsMainSafe) == true)
                    {
                        chkMainSafe.Checked = true;
                        txtUniqueID.Text = dt.Rows[0]["UniqueNo"].ToString();
                    }
                    else
                    {
                        chkMainSafe.Checked = false;
                    }
                }
                else
                {
                    chkSafeAcc.Checked = false;
                }

               DataTable dtt = GroupMasterMaintenaceBLL.GetGroupCode(Id);
               if (dtt.Rows.Count > 0)
               {
                   dgvGroupCodeNew.DataSource = dtt;
                   dgvGroupCodeNew.DataBind();
                   ViewState["CurrentTable"] = dtt;
                   SetPreviouseData();
               }
               else if (act == "add")
               {
                   addFirstGridRow();
                  // btnS=Visible=truew
               }


                    
            }
            catch (SqlException sqlex)
            {

                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh,SetaDatatofieldsql! ";
                alert.Visible = true;
                lblMsg.Text = "sql error";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;  
            }
            catch (Exception ex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh, SetDataToFieldEx! ";
                lblMsg.Text = ex.Message + "" + ex.Source;
                alert.Visible = true; 
            }
        }
        #endregion

        #endregion
        #region btnSave_Click even
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtGroupNo.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Group No. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtGroupNo.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtGroupDesc.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Description. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtGroupDesc.Focus();
                    return;
                }
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                if (GroupMasterMaintenaceBLL.ValidationGroupCode(txtGroupNo.Text,Id) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Code is  Already Exist. Please! Enter Next Code.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtGroupNo.Focus();
                    return;
                }
                if (GroupMasterMaintenaceBLL.ValidationDescription(txtGroupDesc.Text,Id) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Group Name is Already Exist. Please! Enter Next Name.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtGroupDesc.Focus();
                    return;
                }
                if (chkSafeAcc.Checked == true)
                {
                    if (GroupMasterMaintenaceBLL.ValidationUnique(txtUniqueID.Text,Id) == false)
                    {
                        alert.Visible = true;
                        alert.Attributes["class"] = "alert alert-warning";
                        lblMsg.Text = "Unique ID is Already Exist. Please! Enter Next ID.";
                        lblMsgType.Text = "Warning! ";
                        //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                        txtUniqueID.Focus();
                        return;
                    }
                }
                objGroupMasterBLL = SetDataGroupMast();

            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-warning";
                lblMsgType.Text = "Oh!, Save Even sql Error ";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                alert.Visible = true;
            }
            catch (Exception ex)
            {
                alert.Attributes["Class"] = "alert alert-warning";
                lblMsgType.Text = "Oh, Save Even Exception Error ";
                lblMsg.Text = ex.Message + " " + ex.Source;
                alert.Visible = true;
            }
        }

       
        #endregion

        #region SetData function
        private GroupMasterMaintenaceBLL SetDataGroupMast()
        {
            objGroupMasterBLL.GroupCodeId = Convert.ToInt32(Request.QueryString["Id"]);
            objGroupMasterBLL.GroupNo = Convert.ToInt32(txtGroupNo.Text);
            objGroupMasterBLL.RelatedGroup = Convert.ToInt32(txtRelatedGroup.Text);
            objGroupMasterBLL.SectionCode = Convert.ToInt32(ddlSection.SelectedValue);
            objGroupMasterBLL.WorkingSectionId = Convert.ToInt32(ddlWSection.SelectedValue);
            objGroupMasterBLL.SalaryTypeCode = Convert.ToInt32(ddlSalaryType.SelectedValue);
            return objGroupMasterBLL;


        }
        
        #endregion

        #region assfirstgridrow funtion
        private void addFirstGridRow()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("GroupCodeId");
                dt.Columns.Add("SafeNo");
                dt.Columns.Add("DelCode");
                dt.Columns.Add("RecCode");
                System.Data.DataRow row = dt.NewRow();
                row[0] = 0;
                row[1] = 0;
                row[2] = 0;
                dt.Rows.Add(row);
                dgvGroupCodeNew.DataSource = dt;
                dgvGroupCodeNew.DataBind();
                ViewState["CurrentTable"] = dt;
                SetPreviouseData();

            }
            catch (Exception e)
            { 
            
            }
        }
        #endregion

        #region addgridrow
        protected void addGridRow(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((Button)(sender)).Parent.Parent;
            if (ValidationGridVoew(row.RowIndex))
                addNewRow(row.RowIndex);
        }

        private bool ValidationGridVoew(int index)
        {
            TextBox txtSafeNo = (TextBox)dgvGroupCodeNew.Rows[index].FindControl("txtSafeNo");
            TextBox txtRecCode = (TextBox)dgvGroupCodeNew.Rows[index].FindControl("txtRecCode");
            TextBox txtDelCode = (TextBox)dgvGroupCodeNew.Rows[index].FindControl("txtDelCode");
            if (txtSafeNo.Text == "")
            {
                lblGridMessage.Text = "Enter Safe No";
            }
            if (txtDelCode.Text == "")
            {
                lblGridMessage.Text = "Enter Del Code";
            }
            if (txtRecCode.Text == "")
            {
                lblGridMessage.Text = "Enter Rec code";
            }
            return true;
        }
        #endregion

        #region addnewrow
        private void addNewRow(int rowindex)
        {
            UpdateCurrentTabble();
            if (ViewState["CurrentTable"] != null)
            {
                System.Data.DataTable dt = (DataTable)ViewState["CurrentTable"];
                System.Data.DataRow row = dt.NewRow();
                row[0] = 0;
                row[1] = 0;
                row[2] = 0;
                dt.Rows.InsertAt(row, rowindex + 1);
                dgvGroupCodeNew.DataSource = dt;
                dgvGroupCodeNew.DataBind();
                ViewState["CurrentTable"] = dt;
                SetPreviouseData();
            }
        }

        #endregion 

        #region dgvdeleting function
        protected void dgvGroupCodeNew_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (dgvGroupCodeNew.Rows.Count <= 1) return;
                   DeleteRow(e.RowIndex);
        }

        private void DeleteRow(int rowIndex)
        {
            try
            {
                UpdateCurrentTabble();
                if (ViewState["CurrentTavle"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    dt.Rows.RemoveAt(rowIndex);
                    dgvGroupCodeNew.DataSource = dt;
                    dgvGroupCodeNew.DataBind();
                    ViewState["CurrentTable"] = dt;
                    SetPreviouseData();
                }
                else
                {
                    addFirstGridRow();
                }
                //btnSearch
            }
            catch (Exception e)
            { 
            
            }
        }
        #endregion

        #region setpreviousdata funtion
        private void SetPreviouseData()
        {
            try
            {
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    foreach (DataRow row in dt.Rows)
                    {
                        int index = dt.Rows.IndexOf(row);
                        TextBox txtSafeNo = (TextBox)dgvGroupCodeNew.Rows[index].FindControl("txtSafeNo");
                        TextBox txtRecCode = (TextBox)dgvGroupCodeNew.Rows[index].FindControl("txtRecCode");
                        TextBox txtDelCode = (TextBox)dgvGroupCodeNew.Rows[index].FindControl("txtDelCode");
                        txtSafeNo.Text = row[1].ToString();
                        txtRecCode.Text = row[2].ToString();
                        txtDelCode.Text = row[3].ToString();
                    }
                }
            }
            catch (Exception e)
            { 
            
            }
        }
        #endregion

        #region updatecurrenttable funtion

        private void UpdateCurrentTabble()
        {
            try
            {
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    for (int index = 0; index < dgvGroupCodeNew.Rows.Count; index++)
                    {
                        TextBox txtSafeNo = (TextBox)dgvGroupCodeNew.Rows[index].FindControl("txtSafeNo");
                        TextBox txtRecCode = (TextBox)dgvGroupCodeNew.Rows[index].FindControl("txtRecCode");
                        TextBox txtDelCode = (TextBox)dgvGroupCodeNew.Rows[index].FindControl("txtDelCode");
                        dt.Rows[index][0] = txtSafeNo;
                        dt.Rows[index][1] = txtRecCode;
                        dt.Rows[index][2] = txtDelCode;
                    }
                    ViewState["CurrentTable"] = dt;
                }
            }
            catch (Exception e)
            { 
            
            }

        }
        #endregion

        #region this is working GridViewOld

        //private void BindGridView()
        //{
        //    using(SqlConnection sqlconn=new SqlConnection(conn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
                       
        //                cmd.CommandText = "Select *from Tbl_GroupCode";
        //                cmd.Connection = sqlconn;
        //                sqlconn.Open();
        //                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
        //                DataTable dt = new DataTable();
        //                sqlda.Fill(dt);
        //                if (dt.Rows.Count>0)
        //                {
        //                    dgvGroupCode.DataSource = dt;
        //                    dgvGroupCode.DataBind();
        //                }
        //                else
        //                {
        //                    DataRow dr = dt.NewRow();
        //                    dt.Rows.Add(dr);
        //                    dgvGroupCode.DataSource = dt;
        //                    dgvGroupCode.DataBind();
        //                    dgvGroupCode.Rows[0].Visible = false;
        //                }
        //                sqlconn.Close();
        //        }
        //    }
        //}
        //protected void dgvGroupCode_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    dgvGroupCode.EditIndex = -1;
        //    BindGridView();
        //}
        //protected void dgvGroupCode_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    dgvGroupCode.EditIndex = e.NewEditIndex;
        //    BindGridView();
        //}
        //protected void dgvGroupCode_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "New")
        //    {
        //        bool IsNew = false;
                
        //        TextBox GroupCodeId = ((TextBox)dgvGroupCode.FooterRow.FindControl("txtGroupCodeId"));
               
        //        TextBox SafeNo = ((TextBox)dgvGroupCode.FooterRow.FindControl("txtSafeNo"));
        //        TextBox RecCode = ((TextBox)dgvGroupCode.FooterRow.FindControl("txtRecCode"));
        //        TextBox DelCode = ((TextBox)dgvGroupCode.FooterRow.FindControl("txtDelCode"));

        //        using (SqlConnection sqlconn = new SqlConnection(conn))
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "INSERT INTO Tbl_GroupCode(SafeNo, RecCode, DelCode)VALUES(@SafeNo,@RecCode,@DelCode)";
        //                cmd.Parameters.AddWithValue("@SafeNo", SafeNo.Text);
        //                cmd.Parameters.AddWithValue("@RecCode", RecCode.Text);
        //                cmd.Parameters.AddWithValue("@DelCode", DelCode.Text);
                        
        //                cmd.Connection = sqlconn;
        //                sqlconn.Open();
        //                IsNew = cmd.ExecuteNonQuery() > 0;
        //                sqlconn.Close();
        //            }
        //            if (IsNew == true)
        //            {
        //                lblMessage.Text = "'" + SafeNo.Text + "'Safe Has been Added Successfully!";
        //                lblMessage.ForeColor = System.Drawing.Color.Red;
        //            }
        //            else
        //            {
        //                lblMessage.Text = "Error !'" + SafeNo.Text + "' Safe Detail";
        //                lblMessage.ForeColor = System.Drawing.Color.Red;
        //            }
        //        }
        //    }
        //}

       


        //protected void dgvGroupCode_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    bool IsUpdate = false;
        //    int GroupCodeId = Convert.ToInt32(dgvGroupCode.DataKeys[e.RowIndex].Value.ToString());
        //    TextBox SafeNo = (TextBox)dgvGroupCode.Rows[e.RowIndex].FindControl("txtSafeNo");
        //    TextBox RecCode = (TextBox)dgvGroupCode.Rows[e.RowIndex].FindControl("txtRecCode");
        //    TextBox DelCode = (TextBox)dgvGroupCode.Rows[e.RowIndex].FindControl("txtDelCode");
        //    using (SqlConnection sqlconn = new SqlConnection(conn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandText = "UPDATE Tbl_GroupCode SET SafeNo=@SafeNo, RecCode=@RecCode, DelCode=@DelCode where GroupCodeId=@GroupCodeId";
        //            cmd.Parameters.AddWithValue("@GroupCodeId", GroupCodeId);
        //            cmd.Parameters.AddWithValue("@SafeNo", SafeNo.Text);
        //            cmd.Parameters.AddWithValue("@RecCode", RecCode.Text);
        //            cmd.Parameters.AddWithValue("@DelCode", DelCode.Text);
        //            cmd.Connection = sqlconn;
        //            sqlconn.Open();
        //            IsUpdate = cmd.ExecuteNonQuery() > 0;
        //            sqlconn.Close();

        //        }

        //        if (IsUpdate)
        //        {
        //            lblMessage.Text = "'" + SafeNo.Text + "' Update Successfully!";
        //            lblMessage.ForeColor = System.Drawing.Color.Green;
        //            dgvGroupCode.EditIndex = -1;
        //            BindGridView();
        //        }
        //        else
        //        {
        //            lblMessage.Text = "Wrong!'" + SafeNo.Text + "'Safe Detail";
        //            lblMessage.ForeColor = System.Drawing.Color.Red;
        //        }
        //        dgvGroupCode.EditIndex = -1;
        //        BindGridView();
        //    }
        //}
        //protected void dgvGroupCode_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    bool IsDelete = false;
            
        //    int GroupCodeId = Convert.ToInt32(dgvGroupCode.DataKeys[e.RowIndex].Values["GroupCodeId"].ToString());
        //    Label RecCode = (Label)dgvGroupCode.Rows[e.RowIndex].FindControl("lblRecCode");
        //    using (SqlConnection sqlconn = new SqlConnection(conn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandText = "DELETE FROM Tbl_GroupCode WHERE GroupCodeId=@GroupCodeId";
        //            cmd.Parameters.AddWithValue("@GroupCodeId", GroupCodeId);
        //            cmd.Connection = sqlconn;
        //             sqlconn.Open();
        //            IsDelete = cmd.ExecuteNonQuery() > 0;
        //            sqlconn.Close();
        //        }
        //        if (IsDelete)
        //        {
        //            lblMessage.Text = "'" + RecCode.Text + "'Safe No has been Deleted successfully!";
        //            lblMessage.ForeColor = System.Drawing.Color.Green;
        //            BindGridView();
        //        }
        //        else
        //        {
        //            lblMessage.Text = "Wrong!'" + RecCode.Text + "'Safe Detai";
        //            lblMessage.ForeColor = System.Drawing.Color.Red;
        //        }
        //    }
           
        //}
        //protected void dgvGroupCode_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgvGroupCode.PageIndex = e.NewPageIndex;
        //    BindGridView();
        //}

        #endregion

        #region not working code for sample
        //private void BindGridView()
        //{
        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        conn.Open();
        //        SqlDataAdapter sqlda = new SqlDataAdapter("select GroupCodeId, SafeNo, RecCode, DelCode from Tbl_GroupCode", conn);
        //        DataSet ds = new DataSet();
        //        sqlda.Fill(ds);
        //        conn.Close();
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            dgvGroupCode.DataSource = ds;
        //            dgvGroupCode.DataBind();
        //        }
        //        else
        //        {
        //            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        //            dgvGroupCode.DataSource = ds;
        //            dgvGroupCode.DataBind();
        //            int ColCount = dgvGroupCode.Rows.Count;
        //            dgvGroupCode.Rows[0].Cells.Clear();
        //            dgvGroupCode.Rows[0].Cells.Add(new TableCell());
        //            dgvGroupCode.Rows[0].Cells[0].ColumnSpan = ColCount;
        //            dgvGroupCode.Rows[0].Cells[0].Text = "No Record Found!";
        //        }
        //    }
        //}
        //protected void dgvGroupCode_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    dgvGroupCode.EditIndex = e.NewEditIndex;
        //    BindGridView();
        //}
        //protected void dgvGroupCode_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    dgvGroupCode.EditIndex = -1;
        //    BindGridView();

        //}
        //protected void dgvGroupCode_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgvGroupCode.PageIndex = e.NewPageIndex;
        //    BindGridView();
        //}
        //protected void dgvGroupCode_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "New")
        //    {
        //        TextBox GroupCodeId = ((TextBox)dgvGroupCode.FooterRow.FindControl("txtGroupCodeId"));
        //        TextBox SafeNo = ((TextBox)dgvGroupCode.FooterRow.FindControl("txtSafeNo"));
        //        TextBox RecCode = ((TextBox)dgvGroupCode.FooterRow.FindControl("txtRecCode"));
        //        TextBox DelCode = ((TextBox)dgvGroupCode.FooterRow.FindControl("txtDelCode"));
        //        conn.Open();
        //        SqlDataAdapter sqlda = new SqlDataAdapter("insert into Tbl_GroupCode values('" + Convert.ToInt32(GroupCodeId.Text) + "','" + Convert.ToInt32(SafeNo.Text) + "','" + RecCode.Text + "','" + DelCode.Text + "')", conn);
        //        DataSet ds = new DataSet();
        //        sqlda.Fill(ds);
        //        conn.Close();
        //        BindGridView();

        //    }
        //}
        //protected void dgvGroupCode_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    Label ll = ((Label)dgvGroupCode.Rows[e.RowIndex].FindControl("lblGroupCodeId"));
        //    SqlDataAdapter sqlda = new SqlDataAdapter(@"delete from Tbl_GroupCode where GroupCodeId='" + Convert.ToInt32(ll.Text) + "'", conn);
        //    DataSet ds = new DataSet();
        //    sqlda.Fill(ds);
        //    BindGridView();
        //}
        //protected void dgvGroupCode_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    Label ll = (Label)dgvGroupCode.Rows[e.RowIndex].FindControl("lblGroupCode");
        //    TextBox SafeNo = (TextBox)dgvGroupCode.Rows[e.RowIndex].FindControl("txtSafeNo");
        //    TextBox RecCode = (TextBox)dgvGroupCode.Rows[e.RowIndex].FindControl("txtRecCode");
        //    TextBox DelCode = (TextBox)dgvGroupCode.Rows[e.RowIndex].FindControl("txtDelCode");
        //    dgvGroupCode.EditIndex = -1;
        //    SqlDataAdapter sqldaa = new SqlDataAdapter("update Tbl_GroupCode set SafeNo='" + Convert.ToInt32(txtSafeNo.Text) + "',RecCode='" + txtRecCode.Text + "',DelCode='" + txtDelCode.Text + "' where GroupCodeId='" + Convert.ToInt32(ll.Text) + "'", conn);
        //    DataSet ds = new DataSet();
        //    sqldaa.Fill(ds);
        //    BindGridView();
        //}
        //protected void dgvGroupCode_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        int GroupCodeId = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "GroupCodeId"));
        //        LinkButton lkbtn = (LinkButton)e.Row.FindControl("lblDelete");
        //        if (lkbtn != null)
        //        {
        //            lkbtn.Attributes.Add("onclick", "javascript:return confirmAction('GroupCodeId=" + GroupCodeId + "')");
        //        }
        //    }
        //}
        

        //private void DGVFlexShow()
        //{
        //    //string strquery = "Select GroupCodeId, SafeNo, RecCode, SelCode" + "from Tbl_GroupCode";
        //    //SqlCommand cmd = new SqlCommand(strquery);
        //    DataTable dt = objGroupCodeBLL.GetFlexGroupCode();
        //    dgvGroupCode.DataSource =dt;
        //    dgvGroupCode.DataBind();

        //}
        //protected void AddNewGroupCode(object sender, EventArgs e)
        //{
            
        //    int GroupCodeId =Convert.ToInt32 ((TextBox)dgvGroupCode.FooterRow.FindControl("txtGroupCodeId"));
        //    int GroupNo = Convert.ToInt32((TextBox)dgvGroupCode.FooterRow.FindControl("txtGroupNo"));
        //    string RecCode = ((TextBox)dgvGroupCode.FooterRow.FindControl("txtRecCode")).Text;
        //    string DelCode = ((TextBox)dgvGroupCode.FooterRow.FindControl("txtDelCode")).Text;
        //    DataTable dt = objGroupCodeBLL.AddGroupCode(objGroupCodeBLL);
        //    dgvGroupCode.DataSource = dt;
        //    dgvGroupCode.DataBind();
        //}

        //protected void EditGroupCode(object sender, GridViewEditEventArgs e)
        //{
        //    dgvGroupCode.EditIndex = e.NewEditIndex;
        //    DataBind();
        //}

        //protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    dgvGroupCode.EditIndex = -1;
        //    DataBind();
        //}

        //protected void UpdateGroupCode(object sender, GridViewUpdateEventArgs e)
        //{
            
        //    int GroupCodeId =Convert.ToInt32 ((Label)dgvGroupCode.Rows[e.RowIndex].FindControl("GroupCodeId"));
        //    int GroupNo = Convert.ToInt32((TextBox)dgvGroupCode.Rows[e.RowIndex].FindControl("GroupNo"));
        //    string SafeNo = ((TextBox)dgvGroupCode.Rows[e.RowIndex].FindControl("SafeNo")).Text;
        //    string RecCode = ((TextBox)dgvGroupCode.Rows[e.RowIndex].FindControl("RecCode")).Text;
        //    string DelCode = ((TextBox)dgvGroupCode.Rows[e.RowIndex].FindControl("DelCode")).Text;
        //    DataTable dt = objGroupCodeBLL.UpdateGrid(objGroupCodeBLL);
        //    dgvGroupCode.EditIndex = -1;
        //    dgvGroupCode.DataSource = dt;
        //    dgvGroupCode.DataBind();
        //}
        //protected void DeleteGroupCode(object sender, EventArgs e)
        //{
        //    LinkButton lnkRemove = (LinkButton)sender;
        //    int Id = Convert.ToInt32(Request.QueryString["Id"]);
        //    objGroupCodeBLL.Delete(Id);
        //    dgvGroupCode.DataSource = Id;
        //    dgvGroupCode.DataBind();
        //}

        //protected void OnPaging(object sender, GridViewPageEventArgs e)
        //{
        //    DGVFlexShow();
        //    dgvGroupCode.PageIndex = e.NewPageIndex;
        //    DataBind();
        //}
        #endregion

        #region showhide function
        public void chkSafe(object sender, System.EventArgs e)
        {
            var div = ListaEmOutrosDocumentos as HtmlGenericControl;
            var CheckBox = sender as CheckBox;
            if (CheckBox.Checked == true)
            {
                div.Style.Clear();
                div.Style.Add("background-color", "#dce5e0");
                div.Style.Add("border-radius", "17px 17px 17px 17px");
                div.Style.Add("-moz-border-radius", "17px 17px 17px 17px");
                div.Style.Add("-webkit-border-radius", "17px 17px 17px 17px");
                div.Style.Add("display", "block");
                txtSerialNo.Text = "";
                txtNextMonthSerNo.Text = "";
                txtFirstLetter.Text = "";
                chkMainSafe.Checked = false;
                txtUniqueID.Text = "";

            }
            else
            {
                div.Style.Clear();
                div.Style.Add("display", "none");
            }
        }
        #endregion

    }
}