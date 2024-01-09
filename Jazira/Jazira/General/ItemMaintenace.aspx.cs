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
using JaziraBusinessLayer.BLL.General;
using Jazira.CODE;

namespace Jazira.General
{
    public partial class ItemMaintenace : System.Web.UI.Page
    {
        JaziraBusinessLayer.BLL.General.ItemMaintenanceBLL objItemMaintenanceBLL = new JaziraBusinessLayer.BLL.General.ItemMaintenanceBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["editAlert"]) == true)
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
            #region IsPostback
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            string act = Request.QueryString["act"];
            if (!IsPostBack)
            {
                if (act == "edit" || act == "add")
                {
                     CODE.ddlGeneral.LoadStoneCUT(ddlStoneCUT, new JaziraBusinessLayer.BLL.General.ItemMaintenanceBLL().GetStoneCUT());
                     CODE.ddlGeneral.LoadSroneClearity(ddlStoneClearity,new JaziraBusinessLayer.BLL.General.ItemMaintenanceBLL().GetStoneClearity());
                     CODE.ddlGeneral.LoadColor(ddlColor,new JaziraBusinessLayer.BLL.General.ItemMaintenanceBLL().GetColor());
                     CODE.ddlGeneral.LoadStoneShape(ddlShape, new JaziraBusinessLayer.BLL.General.ItemMaintenanceBLL().GetStoneShape());

                    if (act == "edit")
                    {
                        SetDataToField(Id);
                    }
                }
                if (act == "del")
                {
                    try
                    {
                        if (objItemMaintenanceBLL.Delete(Id))
                        {
                            alert.Visible = true;
                            lblMsgType.Text = "Data Deleted Successfully";
                            lblMsg.Text = "Well Done! ";
                            alert.Attributes["class"] = "alert alert-success";
                            Session["delAlert"] = true;
                            //setSessionMsg("alert-success alert col-md-6", "Deleted Successfully", false);
                            Response.Redirect("ItemMaintenace.aspx?act=add", false);
                        }
                    }
                    catch (SqlException sqlex)
                    {
                        alert.Attributes["class"] = "alert alert-error";
                        lblMsgType.Text = "Oh,DeletesqlEx! ";
                        alert.Visible = true;
                        lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                    }
                    catch (Exception ex)
                    {
                        alert.Attributes["class"] = "alert alert-error";
                        lblMsgType.Text = "Oh, delete errorEx! ";
                        lblMsg.Text = ex.Message + "" + ex.Source;
                        alert.Visible = true;   
                    }
                }
                if (act == "search" || act == "list")
                {
                    DGVTypeMaster();
                }
            }
            #endregion
        }

       

        #region SetDataToField 
        private void SetDataToField(int Id)
        {
            try
            {
                    txtItemCode.Enabled = false;
                    DataTable dt = JaziraBusinessLayer.BLL.General.ItemMaintenanceBLL.SetMasterMaintenance(Id);
                    txtItemCode.Text = dt.Rows[0]["TypeCodee"].ToString();
                    txtItemDescription.Text = dt.Rows[0]["TypeDescription"].ToString();
                    txtPrice.Text = dt.Rows[0]["TypePricePC"].ToString();
                    txtCARAT.Text = dt.Rows[0]["TypeCarat"].ToString();
                    ddlDelvColm.SelectedValue = dt.Rows[0]["RPTColumnD"].ToString();
                    ddlRecvColm.SelectedValue = dt.Rows[0]["RPTColumnR"].ToString();
                    //Boolean TypeDWL = Convert.ToBoolean(Convert.ToInt16(dt.Rows[0]["TypeDWL"]));
                    //chkDelvWrkLoss.Checked =Convert.ToBoolean( dt.Rows[0]["TypeDWL"].ToString());
                    string TypeDWL = Convert.ToBoolean(dt.Rows[0]["TypeDWL"]).ToString();
                    //string TypeDWL = dt.Rows[0]["TypeDWL"].ToString();
                    if (Convert.ToBoolean(TypeDWL) ==true)
                    {
                        chkDelvWrkLoss.Checked = true;
                    }
                    else
                    {
                        chkDelvWrkLoss.Checked = false;
                    }
                    //if (TypeDWL == "Y")
                    //    chkDelvWrkLoss.Checked = true;
                    //else
                    //    chkDelvWrkLoss.Checked = false;
                    string TypeRWL = Convert.ToBoolean(dt.Rows[0]["TypeRWL"]).ToString();
                    //string TypeRWL = dt.Rows[0]["TypeRWL"].ToString();
                    if (Convert.ToBoolean(TypeRWL) == true)
                    {
                        chkRecvWrkLoss.Checked = true;
                    }
                    else
                    {
                        chkRecvWrkLoss.Checked = false;
                    }
                    string TypeDelCharge = Convert.ToBoolean(dt.Rows[0]["TypeDelCharge"]).ToString();
                    //string TypeDelCharge = dt.Rows[0]["TypeDelCharge"].ToString();
                    if (Convert.ToBoolean(TypeDelCharge) == true)
                    {
                       chkDelvWthChrg.Checked = true;
                    }
                    else
                    {
                        chkDelvWthChrg.Checked = false;
                    }
                    string TypeRecChage = Convert.ToBoolean(dt.Rows[0]["TypeRecChage"]).ToString();
                    //string TypeRecChage = dt.Rows[0]["TypeRecChage"].ToString();
                    if (Convert.ToBoolean(TypeRecChage) == true)
                    {
                        chkRecvWthChrg.Checked = true;
                    }
                    else
                    {
                        chkRecvWthChrg.Checked = false;
                    }

                    string TypeStone = Convert.ToBoolean(dt.Rows[0]["TypeStone"]).ToString();
                    //string TypeStone = dt.Rows[0]["TypeStone"].ToString();
                    if (Convert.ToBoolean(TypeStone)==true)
                    {
                        var div = ListaEmOutrosDocumentos as HtmlGenericControl;
                        div.Style.Clear();
                        div.Style.Add("background-color", "#dce5e0");
                        div.Style.Add("border-radius", "10px 10px 10px 10px");
                        div.Style.Add("-moz-border-radius", "10px 10px 10px 10px");
                        div.Style.Add("-webkit-border-radius", "10px 10px 10px 10px");
                        div.Style.Add("display", "block");
                        chkStoneItem.Checked = true;
                        
                        txtSize.Text = dt.Rows[0]["TypeSize"].ToString();
                        txtWeight.Text = dt.Rows[0]["WeightPC"].ToString();
                        lblDate.Text = Convert.ToDateTime(dt.Rows[0]["TypeEntryDate"]).ToShortDateString();
                        txtROL.Text = dt.Rows[0]["ROL"].ToString();
                        ddlStoneCUT.SelectedValue = dt.Rows[0]["StoneCUTId"].ToString();
                        ddlStoneClearity.SelectedValue = dt.Rows[0]["StoneClearityId"].ToString();
                        ddlColor.SelectedValue = dt.Rows[0]["StoneColorId"].ToString();
                        ddlShape.SelectedValue = dt.Rows[0]["StoneShapeId"].ToString();
                    }
                    else
                    {
                        //var div = ListaEmOutrosDocumentos as HtmlGenericControl;
                        //div.Style.Add("display", "block");
                        chkStoneItem.Checked = false;
                        ddlColor.SelectedValue = null;
                        ddlShape.SelectedValue = null;
                        ddlStoneClearity.SelectedValue = null;
                        ddlStoneCUT.SelectedValue = null;
                        txtSize.Text = "";
                        txtWeight.Text = "";
                        lblDate.Text = "";
                        txtROL.Text = "";
                    }
                    btnSave.Text = "Update";
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

        #region ShowHide option
        public void chkItemChecked(object sender, System.EventArgs e)
        {
            var div = ListaEmOutrosDocumentos as HtmlGenericControl;
            var CheckBox = sender as CheckBox;
            if (CheckBox.Checked == true)
            {
                div.Style.Clear();
                div.Style.Add("background-color", "#dce5e0");
                div.Style.Add("border-radius", "10px 10px 10px 10px");
                div.Style.Add("-moz-border-radius", "10px 10px 10px 10px");
                div.Style.Add("-webkit-border-radius", "10px 10px 10px 10px");
                div.Style.Add("display", "block");
                //txtSize.Text = "";
                //txtWeight.Text = "";
                ////txtDate.Text = "";
                //txtROL.Text = "";
                //ddlStoneCUT.SelectedValue = null;
                //ddlStoneClearity.SelectedValue = null;
                //ddlColor.SelectedValue = null;
                //ddlShape.SelectedValue = null;
            }
            else
            {
                div.Style.Clear();
                div.Style.Add("Display", "none");
            }

        }
        #endregion

        #region Save even
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtItemCode.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Item Code. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtItemCode.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtItemDescription.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Item Description. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtItemDescription.Focus();
                    return;
                }
                #region if requered whether leave whitespace or not
                if (string.IsNullOrWhiteSpace(txtPrice.Text) == true)
                {
                    //alert.Visible = true;
                    //alert.Attributes["class"] = "alert alert-warning";
                    //lblMsg.Text = "Plz! Type Item Price. Not Allowed Blanks!";
                    //lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtPrice.Text = "00.00";
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCARAT.Text) == true)
                {
                    //alert.Visible = true;
                    //alert.Attributes["class"] = "alert alert-warning";
                    //lblMsg.Text = "Plz! Type CARAT. Not Allowed Blanks!";
                    //lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtCARAT.Text = "875";
                    return;
                }

                if (chkStoneItem.Checked == true)
                {
                    if (string.IsNullOrWhiteSpace(txtSize.Text) == true)
                    {
                        //alert.Visible = true;
                        //alert.Attributes["class"] = "alert alert-warning";
                        //lblMsg.Text = "Plz! Type Size. Not Allowed Blanks!";
                        //lblMsgType.Text = "Warning! ";
                        //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                        txtSize.Text = "00.00";
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtWeight.Text) == true)
                    {
                        alert.Visible = true;
                        alert.Attributes["class"] = "alert alert-warning";
                        lblMsg.Text = "Plz! Type Weight. Not Allowed Blanks!";
                        lblMsgType.Text = "Warning! ";
                        //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                        txtWeight.Focus();
                        return;
                    }
                }
                #endregion

                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                if (ItemMaintenanceBLL.ValidationItemCode(txtItemCode.Text, Id) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Item Code is Already Exist. Please! Enter Next Name.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtItemCode.Focus();
                    return;
                }
                if (ItemMaintenanceBLL.ValidationItemDescription(txtItemDescription.Text, Id) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Item Description is Already Exist. Please! Enter Next Name.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtItemDescription.Focus();
                    return;
                }
                objItemMaintenanceBLL = SetDataItemMaster();
                if (chkStoneItem.Checked == true)
                {
                    if (objItemMaintenanceBLL.Save(objItemMaintenanceBLL))
                    {
                        Clear();
                        alert.Attributes["class"] = "alert alert-success";
                        lblMsgType.Text = "Well Done! ";
                        lblMsg.Text = "Data Saved Successfully.";
                        alert.Visible = true;
                        if (objItemMaintenanceBLL.TypeMastId > 0)
                        {
                            Session["editAlert"] = true;
                            Response.Redirect("ItemMaintenace.aspx?act=add", false);
                        }
                        //setSessionMsg("alert-success alert col-md-6", "Saved", true);
                        Response.Redirect("ItemMaintenace.aspx?act=add", false);
                    }
                }
                else
                {
                    if (objItemMaintenanceBLL.SaveUnchked(objItemMaintenanceBLL))
                    {
                        Clear();
                        alert.Attributes["class"] = "alert alert-success";
                        lblMsgType.Text = "Well Done! ";
                        lblMsg.Text = "Data Saved Successfully.";
                        alert.Visible = true;
                        if (objItemMaintenanceBLL.TypeMastId > 0)
                        {
                            Session["editAlert"] = true;
                            Response.Redirect("ItemMaintenace.aspx?act=add", false);
                        }
                        //setSessionMsg("alert-success alert col-md-6", "Saved", true);
                        Response.Redirect("ItemMaintenace.aspx?act=add", false);
                    }
                }


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
                //setSessionMsg("alert-success alert col-md-6", "" + ex + "", true);
            }
        }
        #endregion

        #region Clear even
        private void Clear()
        {
            txtItemCode.Text = "";
            txtItemDescription.Text = "";
            txtPrice.Text = "";
            txtCARAT.Text = "";
            ddlDelvColm.SelectedValue = null;
            ddlRecvColm.SelectedValue = null;
            chkDelvWrkLoss.Checked = false;
            chkRecvWrkLoss.Checked = false;
            chkDelvWthChrg.Checked = false;
            chkRecvWthChrg.Checked = false;
            ddlColor.SelectedValue = null;
            ddlShape.SelectedValue = null;
            ddlStoneClearity.SelectedValue = null;
            ddlStoneCUT.SelectedValue = null;
            chkStoneItem.Checked = false;
        }
        #endregion

        #region SetData Function
        private ItemMaintenanceBLL SetDataItemMaster()
        {
           
            objItemMaintenanceBLL.TypeMastId = Convert.ToInt32(Request.QueryString["Id"]);
            objItemMaintenanceBLL.TypeCodee = txtItemCode.Text.Trim().Replace("'", "''");
            objItemMaintenanceBLL.TypeDescription = txtItemDescription.Text.Trim().Replace("'","''");
            objItemMaintenanceBLL.TypePricePC = Convert.ToDecimal(txtPrice.Text);
            objItemMaintenanceBLL.TypeCarat = Convert.ToDecimal(txtCARAT.Text);
            objItemMaintenanceBLL.RPTColumnD =Convert.ToInt32( ddlDelvColm.SelectedValue).ToString();
            objItemMaintenanceBLL.RPTColumnR = Convert.ToInt32(ddlRecvColm.SelectedValue).ToString();

            //objItemMaintenanceBLL.TypeDWL = Convert.ToBoolean(chkDelvWrkLoss.Checked);

            if (chkDelvWrkLoss.Checked)
            {
                objItemMaintenanceBLL.TypeDWL = true;
            }
            else
            {
                objItemMaintenanceBLL.TypeDWL = false;
            }

            //objItemMaintenanceBLL.TypeRWL = Convert.ToBoolean(chkRecvWrkLoss.Checked);
            if (chkRecvWrkLoss.Checked)
            {
                objItemMaintenanceBLL.TypeRWL = true;
            }
            else
            {
                objItemMaintenanceBLL.TypeRWL = false;
            }

            //objItemMaintenanceBLL.TypeDelCharge = Convert.ToBoolean(chkDelvWthChrg.Checked);
            if (chkDelvWthChrg.Checked)
            {
                objItemMaintenanceBLL.TypeDelCharge = true;
            }
            else
            {
                objItemMaintenanceBLL.TypeDelCharge = false;
            }

            //objItemMaintenanceBLL.TypeRecChage = Convert.ToBoolean(chkRecvWthChrg.Checked);
            if (chkRecvWthChrg.Checked)
            {
                objItemMaintenanceBLL.TypeRecChage = true;
            }
            else
            {
                objItemMaintenanceBLL.TypeRecChage = false;
            }
            objItemMaintenanceBLL.Status = 'A';
            objItemMaintenanceBLL.LoginId = 1;
            objItemMaintenanceBLL.LogDateTime = DateTime.Now;

            objItemMaintenanceBLL.TypeStone = Convert.ToBoolean(chkStoneItem.Checked);
            if (chkStoneItem.Checked==true)
            {
                //var div = ListaEmOutrosDocumentos as HtmlGenericControl;
                //div.Style.Add("display", "block");
                objItemMaintenanceBLL.TypeStone = true;

                objItemMaintenanceBLL.StoneCUTId = Convert.ToInt32(ddlStoneCUT.SelectedValue);
                objItemMaintenanceBLL.StoneColorId = Convert.ToInt32(ddlColor.SelectedValue);
                objItemMaintenanceBLL.StoneClearityId = Convert.ToInt32(ddlStoneClearity.SelectedValue);
                objItemMaintenanceBLL.StoneShapeId = Convert.ToInt32(ddlShape.SelectedValue);
                objItemMaintenanceBLL.TypeSize = txtSize.Text.Trim().Replace("'", "''");
                objItemMaintenanceBLL.WeightPC = Convert.ToDecimal(txtWeight.Text);
                objItemMaintenanceBLL.TypeEntryDate = DateTime.Now; //DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/mm/yyyy", CultureInfo.InvariantCulture);
                //string farmat = "dd/mm/yyyy";
                //string TypeEntryDate =Convert.ToDateTime (lblDate.Text).ToString(farmat);
                objItemMaintenanceBLL.ROL = Convert.ToDecimal(txtROL.Text);

            }
            else
            {
                objItemMaintenanceBLL.TypeStone = false;
                objItemMaintenanceBLL.TypeEntryDate = DateTime.Now; //DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/mm/yyyy", CultureInfo.InvariantCulture);
               
                ddlColor.SelectedValue = null;
                ddlShape.SelectedValue = null;
                ddlStoneClearity.SelectedValue = null;
                ddlStoneCUT.SelectedValue = null;
                txtSize.Text = "";
                txtWeight.Text = "";
                txtROL.Text = "";
            }
            return objItemMaintenanceBLL;
        }
        #endregion

        #region GridViewPageEven
        protected void dgvTypeMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvTypeMaster.PageIndex = e.NewPageIndex;
            DGVTypeMaster();
        }
        #endregion

        #region DGVGridView function
        private void DGVTypeMaster()
        {
            try
            {
                string ItemCode = txtSearchItemCode.Text.Trim().Replace("'", "''");
                int TypeMastId = Convert.ToInt32(Request.QueryString["TypeMastId"]);
                ItemMaintenanceBLL data = new ItemMaintenanceBLL();
                System.Data.DataTable dt = JaziraBusinessLayer.BLL.General.ItemMaintenanceBLL.GetItemCode(ItemCode);
                dgvTypeMaster.DataSource = dt;
                dgvTypeMaster.DataBind();
                if (dt.Rows.Count == 0)
                    divNoDaa.Visible = true;
                else
                    divNoDaa.Visible = false;
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = "Unexpected SQL Error. Please contact Administrator";
                alert.Visible = true;
                lblMsg.Text = sqlex.Message + " " + sqlex.Source;
            }
            catch (Exception ex)
            {
                alert.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh! GridView Exception! ";
                lblMsg.Text = ex.Message + " " + ex.Source;
                alert.Visible = true;
            }
        }
        #endregion

        #region Search even
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DGVTypeMaster();
        }
        #endregion
    }
}