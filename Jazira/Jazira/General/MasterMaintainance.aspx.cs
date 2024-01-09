using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using JaziraBusinessLayer.BLL.General;
using System.Data;
using System.Data.SqlClient;

namespace Jazira.General
{
    public partial class MasterMaintainance : System.Web.UI.Page
    {
        JaziraBusinessLayer.BLL.General.GoldTypeBLL objGoldTypeBLL = new JaziraBusinessLayer.BLL.General.GoldTypeBLL();
        JaziraBusinessLayer.BLL.General.SectionBLL objSectionBLL = new JaziraBusinessLayer.BLL.General.SectionBLL();
        JaziraBusinessLayer.BLL.General.SalaryTypeBLL objSalaryTypeBLL = new JaziraBusinessLayer.BLL.General.SalaryTypeBLL();
        JaziraBusinessLayer.BLL.General.StoneShapeBLL objStoneShapeBLL = new JaziraBusinessLayer.BLL.General.StoneShapeBLL();
        JaziraBusinessLayer.BLL.General.StoneColorBLL objStoneColorBLL = new JaziraBusinessLayer.BLL.General.StoneColorBLL();
        JaziraBusinessLayer.BLL.General.StoneShapeCUTBLL objStoneCUTBLL = new JaziraBusinessLayer.BLL.General.StoneShapeCUTBLL();
        JaziraBusinessLayer.BLL.General.MasterOrnamentBLL objMasterOrnament = new JaziraBusinessLayer.BLL.General.MasterOrnamentBLL();
        JaziraBusinessLayer.BLL.General.StoneClearityBLL objStoneClearityBLL = new JaziraBusinessLayer.BLL.General.StoneClearityBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Page.Master) == null) // I have change this option into null then start to work
            {
                HtmlGenericControl li = (HtmlGenericControl)this.Page.Master.FindControl("list").FindControl("liMasterMaintainance");
                li.Attributes["class"] = "active";
            }
            if (Convert.ToBoolean(Session["editAlert"]) == true)
            {
                alert.Visible = true;
                lblMsg.Text = "Data Updated Successfully.";
                lblMsgType.Text = "Well done! ";
                alert.Attributes["class"] = "alert alert-success";
                Session["editAlert"] = false;
            }
            if (Convert.ToBoolean(Session["delAlert"]) == true)
            {
                alert.Visible = true;
                lblMsg.Text = "Data Deleted Successfully";
                lblMsgType.Text = "Well Done! ";
                alert.Attributes["class"] = "alert alert-success";
                Session["delAlert"] = false;
            }
            //this is alert message jquery function //
            //if (Session["msgInfo"] != null)
            //{
            //    messaging_alert.Visible = true;
            //    button_close.Visible = true;
            //    messaging_alert.Attributes.Add("class", Session["msgCss"].ToString());
            //    Session["msgCss"] = "";
            //}
            //messaging_alert.Visible = false;

           
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
          
            string act = Request.QueryString["act"];
            if (act == "editG" || act == "delG" || act == "GoldType")
            {
                liGoldType.Attributes["class"] = "active";
                increaseid(Id);
            }
            if (act == "editSec" || act == "delSec" || act == "Section")
            {
                liSection.Attributes["class"] = "active";
                increaseSecId(Id);
            }
            if (act == "editSal" || act == "delSal" || act == "SalaryType")
            {
                liSalaryType.Attributes["class"] = "active";
                increaseSalId(Id);
            }
            if (act == "editStoneS" || act == "delStoneS" || act == "StoneShape")
            {
                liStoneShape.Attributes["class"] = "active";
                increaseStoneSId(Id);
            }
            if (act == "editSC" || act == "delSC" || act == "StoneColor")
            {
                liStoneColor.Attributes["class"] = "active";
                increaseSCId(Id);
            }
            if (act == "editSCUT" || act == "delSCUT" || act == "StoneCUT")
            {
                liStoneCUT.Attributes["class"] = "active";
                increaseStoneCUTId(Id);
            }
            if (act == "editMO" || act == "delMO" || act == "MasterOrnament")
            {
                liMasterOrnament.Attributes["class"] = "active";
                increaseMOId(Id);
            }
            if (act == "editSSC" || act == "delSSC" || act == "StoneShapeClearity")
            {
                liStoneShapeClearity.Attributes["class"] = "active";
                increaseSSCId(Id);
            }

            if (!IsPostBack)
            {
              
                #region Gold Type
                if (act == "editG" || act == "addG")
                {
                    
                    if (act == "editG")
                    {
                        SetDataDataToFieldGold(Id);
                    }
                    tbnGSave.Text = "Update";
                }
                if (act == "delG")
                {
                    if (GoldTypeBLL.Delete(Id))
                    {
                        alert.Visible = true;
                        lblMsgType.Text = "Data Deleted Successfully";
                        lblMsg.Text = "Well Done! ";
                        alert.Attributes["class"] = "alert alert-success";
                        Session["delAlert"] = false;
                        //setSessionMsg("alert-success alert col-md-6", "Deleted Successfully", false);
                        Response.Redirect("MasterMaintainance.aspx?act=GoldType",false);
                    }
                }
                if (act == "GoldType" || act == "editG")
                {
                    DGVGoldType();
                }
        #endregion

                #region Section
                if (act == "editSec" || act == "addSec")
                {
                    if (act == "editSec")
                    {
                        SetDataToFieldSection(Id);
                    }
                    btnSecSave.Text = "Update";
                }
                if (act == "delSec")
                {
                    if (SectionBLL.Delete(Id))
                    {
                        alert.Visible = true;
                        lblMsgType.Text = "Data Deleted Successfully";
                        lblMsg.Text = "Well Done! ";
                        alert.Attributes["class"] = "alert alert-success";
                        Session["delAlert"] = false;
                        //setSessionMsg("alert-success alert col-md-6", "Deleted Successfully", false);
                        Response.Redirect("MasterMaintainance.aspx?act=Section", false);
                    }
                }
                if (act == "Section" || act == "editSec")
                {
                    DGVSection();
                }
        #endregion

                #region Salary Type
                if (act == "editSal" || act == "addSal")
                {
                    if (act == "editSal")
                    {
                        SetDataToFieldSalary(Id);
                    }
                    btnSalSave.Text = "Update";
                }
                if (act == "delSal")
                {
                    if (SalaryTypeBLL.Delete(Id))
                    {
                        alert.Visible = true;
                        lblMsgType.Text = "Data Deleted Successfully";
                        lblMsg.Text = "Well Done! ";
                        alert.Attributes["class"] = "alert alert-success";
                        Session["delAlert"] = false;
                        //setSessionMsg("alert-success alert col-md-6", "Deleted Successfully", false);
                        Response.Redirect("MasterMaintainance.aspx?act=SalaryType", false);      
                    }
                }
                if (act == "SalaryType" || act == "editSal")
                {
                    DGVSalaryType();
                }

        #endregion

                #region StoneShape
                if (act == "editStoneS" || act == "addStoneS")
                {
                    if (act == "editStoneS")
                    {
                        SetDataToFieldSS(Id);
                    }
                    btnStoneSSave.Text = "Update";
                }
                if (act == "delStoneS")
                {
                    if (StoneShapeBLL.Delete(Id))
                    {
                        alert.Visible = true;
                        lblMsgType.Text = "Data Deleted Successfully";
                        lblMsg.Text = "Well Done! ";
                        alert.Attributes["class"] = "alert alert-success";
                        Session["delAlert"] = false;
                        //setSessionMsg("alert-success alert col-md-6", "Deleted Successfully", false);
                        Response.Redirect("MasterMaintainance.aspx?act=StoneShape", false);       
                    }
                }
                if (act == "StoneShape" || act == "editStoneS")
                {
                    DGVStoneShape();
                }
        #endregion

                #region StoneColor
                if (act == "editSC" || act == "addSC")
                {
                    if (act == "editSC")
                    {
                        SetDataToFieldSC(Id);
                    }
                    btnSCSave.Text = "Update";
                }
                if (act == "delSC")
                {
                    if (StoneColorBLL.Delete(Id))
                    {
                        alert.Visible = true;
                        lblMsgType.Text = "Data Deleted Successfully";
                        lblMsg.Text = "Well Done! ";
                        alert.Attributes["class"] = "alert alert-success";
                        Session["delAlert"] = false;
                        //setSessionMsg("alert-success alert col-md-6", "Deleted Successfully", false);
                        Response.Redirect("MasterMaintainance.aspx?act=StoneColor", false);            
                    }
                }
                if (act == "StoneColor" || act == "editSC")
                {
                    DGVStoneColor();
                }
                #endregion

                #region StoneCUT
                if (act == "editSCUT" || act == "addSCUT")
                {
                    if (act == "editSCUT")
                    {
                        SetDataToFieldSCUT(Id);
                    }
                    btnSCUTSave.Text = "Update";
                }
                if (act == "delSCUT")
                {
                    if (StoneShapeCUTBLL.Delete(Id))
                    {
                        alert.Visible = true;
                        lblMsgType.Text = "Data Deleted Successfully";
                        lblMsg.Text = "Well Done! ";
                        alert.Attributes["class"] = "alert alert-success";
                        Session["delAlert"] = false;
                        //setSessionMsg("alert-success alert col-md-6", "Deleted Successfully", false);
                        Response.Redirect("MasterMaintainance.aspx?act=StoneCUT", false);        
                    }
                }
                if (act == "StoneCUT" || act == "editSCUT")
                {
                    DGVStoneCUT();
                }

                #endregion

                #region Ornament
                if (act == "editMO" || act == "addMO")
                {
                    if (act == "editMO")
                    {
                        SetDataToFieldMOrnament(Id);
                    }
                    btnOMSave.Text = "Update";
                }
                if (act == "delMO")
                {
                    if (MasterOrnamentBLL.Delete(Id))
                    {
                        alert.Visible = true;
                        lblMsgType.Text = "Data Deleted Successfully";
                        lblMsg.Text = "Well Done! ";
                        alert.Attributes["class"] = "alert alert-success";
                        Session["delAlert"] = false;
                        //setSessionMsg("alert-success alert col-md-6", "Deleted Successfully", false);
                        Response.Redirect("MasterMaintainance.aspx?act=MasterOrnament", false);        
                    }
                }
                if (act == "MasterOrnament" || act == "editMO")
                {
                    DGVMasterOrnament();
                }
                #endregion

                #region StoneClearity
                if (act == "editSSC" || act == "addSSC")
                {
                    if (act == "editSSC")
                    {
                        SetDataToFieldStoneClearirty(Id);
                    }
                    btnSSCSave.Text = "Update";
                }
                if (act == "delSSC")
                {
                    if (StoneClearityBLL.Delete(Id))
                    {
                        alert.Visible = true;
                        lblMsgType.Text = "Data Deleted Successfully";
                        lblMsg.Text = "Well Done! ";
                        alert.Attributes["class"] = "alert alert-success";
                        Session["delAlert"] = false;
                        //setSessionMsg("alert-success alert col-md-6", "Deleted Successfully", false);
                        Response.Redirect("MasterMaintainance.aspx?act=StoneShapeClearity", false);          
                    }
                }
                if (act == "StoneShapeClearity" || act == "editSSC")
                {
                    DGVStoneShapeClearity();
                }
                #endregion
            }
        }

        #region StoneClearity

        #region Even

        #region Search even
        protected void btnSSCSearch_Click(object sender, EventArgs e)
        {
            DGVStoneShapeClearity();
        }
        #endregion

        #region Clear even
        private void ClearSSC()
        {
            txtStoneClearityCode.Text = "";
            txtStoneClearityName.Text = "";
            DGVStoneShapeClearity();
        }
        #endregion

        #region bnt_Save even
        protected void btnSSCSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtStoneClearityName.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Shape Clearity Name. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtStoneClearityName.Focus();
                    return;   
                }
                int SSCId=Convert.ToInt32(Request.QueryString["SSCId"]);
                if (StoneClearityBLL.ValidationStoneShapeClearity(txtStoneClearityName.Text, SSCId) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Clearity Name is Already Exist. Please! Enter Next Name.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtStoneClearityName.Focus();
                    return;   
                }
                objStoneClearityBLL = SetDataStoneClearity();
                if (objStoneClearityBLL.Save(objStoneClearityBLL))
                { 
                    ClearSSC();
                    alert.Attributes["class"] = "alert alert-success";
                    lblMsgType.Text = "Well Done! ";
                    lblMsg.Text = "Data Saved Successfully.";
                    alert.Visible = true;
                    if (objStoneClearityBLL.StoneClearityId > 0)
                    {
                        Session["editAlert"] = true;
                        Response.Redirect("MasterMaintainance.aspx?act=StoneShapeClearity", false);
                    }
                    //setSessionMsg("alert-success alert col-md-6", "Saved", true);
                    Response.Redirect("MasterMaintainance.aspx?act=StoneShapeClearity", false);        
                }

            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-warning";
                lblMsgType.Text = "Oh!, Save Even sql Error ";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                alert.Visible = true;
                //setSessionMsg("alert-success alert col-md-6", "" + exe + "", true);
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

        #endregion

        #region GridView function

        #region GridviewPageIndex function
        protected void dgvStoneClearity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvStoneClearity.PageIndex = e.NewPageIndex;
            DGVStoneShapeClearity();
        }
        #endregion

        #region DGVGridView Function

        private void DGVStoneShapeClearity()
        {
            try
            {
                string SSClearityName = txtStoneClearityName.Text.Trim().Replace("'", "''");
                int SSCGVId = Convert.ToInt32(Request.QueryString["SSCGVId"]);
                DataTable dt = JaziraBusinessLayer.BLL.General.StoneClearityBLL.GetStoneClearityName(SSClearityName);
                dgvStoneClearity.DataSource = dt;
                dgvStoneClearity.DataBind();
                if (dt.Rows.Count == 0)
                    divNoDataSSC.Visible = true;
                else
                    divNoDataSSC.Visible = false;
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = "Unexpected SQL Error. Please contact adminnistrator";
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

        #endregion

        #region Function

        #region IncreaseId function
        private void increaseSSCId(int Id)
        {
            int ClearityId;
            SqlConnection connSSC = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=jaziradb;Persist Security Info=True;User ID=admin;Password=admin");
            if (txtStoneClearityCode.Text == "")
            {
                connSSC.Open();
                string sql = "select StoneClearityCode from Tbl_StoneClearity";
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, connSSC);
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    ClearityId = ds.Tables[0].Rows.Count;
                    ClearityId += 1;
                    txtStoneClearityCode.Text = Convert.ToString(ClearityId);
                    txtStoneClearityName.Focus();
                }
                else
                {
                    txtStoneClearityCode.Text = "1";
                    txtStoneClearityName.Focus();
                }
            }
            connSSC.Close();
        }

        #endregion

        #region SetData funtion
        private StoneClearityBLL SetDataStoneClearity()
        {
            objStoneClearityBLL.StoneClearityId = Convert.ToInt32(Request.QueryString["Id"]);
            objStoneClearityBLL.StoneClearityCode = Convert.ToInt32(txtStoneClearityCode.Text);
            objStoneClearityBLL.StoneClearityName = txtStoneClearityName.Text.Trim().Replace("'", "''");
            objStoneClearityBLL.Status = 'A';
            objStoneClearityBLL.LoginId = 1;
            objStoneClearityBLL.LogDateTime = DateTime.Now;
            return objStoneClearityBLL;
        }
        #endregion

        #region SetDataToField function
        private void SetDataToFieldStoneClearirty(int Id)
        {
            try
            {
                DataTable dt = JaziraBusinessLayer.BLL.General.StoneClearityBLL.SetStoneClearityName(Id);
                txtStoneClearityCode.Text = dt.Rows[0]["StoneClearityCode"].ToString();
                txtStoneClearityName.Text = dt.Rows[0]["StoneClearityName"].ToString();
                btnSSCSave.Text = "Update";

            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh,SetaDatatofieldsql! ";
                alert.Visible = true;
                lblMsg.Text = "sql error";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                //setSessionMsg("alert-error alert", "Unexpected SQl Error. Plz Contact on adminnistrator!", false);
                //alert.Visible = true;
                //lblAlertMessage.Text = exe.Message + "" + exe.Source;
            }
            catch (Exception ex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh, SetDataToFieldEx! ";
                lblMsg.Text = ex.Message + "" + ex.Source;
                alert.Visible = true;
                //lblAlertMessage.Text = ex.Message + "" + ex.Source;
                //alert.Visible = true;
            }
        }
        #endregion

        #endregion

        #endregion

        #region MasterOrnament

        #region Even

        #region Search even
        protected void btnOMSearch_Click(object sender, EventArgs e)
        {
            DGVMasterOrnament();
        }

        #endregion

        #region Clear even
        private void ClearMO()
        {
            txtOrnamentCode.Text = "";
            txtOrnamentName.Text = "";
            DGVMasterOrnament();
        }
        #endregion

        #region btnSave even
        protected void btnOMSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtOrnamentName.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Ornament Name. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtOrnamentName.Focus();
                    return;
                }
                int MOId = Convert.ToInt32(Request.QueryString["MOId"]);
                if (MasterOrnamentBLL.ValidationMasterOrnament(txtOrnamentName.Text, MOId) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Ornament Name is Already Exist. Please! Enter Next Name.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtOrnamentName.Focus();
                    return;
                }
                objMasterOrnament = SetDataMasterOrnament();
                if (objMasterOrnament.Save(objMasterOrnament))
                {
                    ClearMO();
                    alert.Attributes["class"] = "alert alert-success";
                    lblMsgType.Text = "Well Done! ";
                    lblMsg.Text = "Data Saved Successfully.";
                    alert.Visible = true;
                    if (objMasterOrnament.MasterOrnamentId > 0)
                    {
                        Session["editAlert"] = true;
                        Response.Redirect("MasterMaintainance.aspx?act=MasterOrnament", false);
                    }
                    //setSessionMsg("alert-success alert col-md-6", "Saved", true);
                    Response.Redirect("MasterMaintainance.aspx?act=MasterOrnament", false);     
                }
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-warning";
                lblMsgType.Text = "Oh!, Save Even sql Error ";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                alert.Visible = true;
                //setSessionMsg("alert-success alert col-md-6", "" + exe + "", true);
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

        #endregion

        #region GridView Function

        #region GridViewPageIndex function
        protected void dgvMasterOrnament_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMasterOrnament.PageIndex = e.NewPageIndex;
            DGVMasterOrnament();
        }
        #endregion

        #region DGVGridView Function
        private void DGVMasterOrnament()
        {
            try
            {
                string MOName = txtOrnamentName.Text.Trim().Replace("'", "''");
                int MOId = Convert.ToInt32(Request.QueryString["MOId"]);
                DataTable dt = JaziraBusinessLayer.BLL.General.MasterOrnamentBLL.GetMasterOrnament(MOName);
                dgvMasterOrnament.DataSource = dt;
                dgvMasterOrnament.DataBind();
                if (dt.Rows.Count == 0)
                    divNoDataMO.Visible = true;
                else
                    divNoDataMO.Visible = false;
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = "Unexpected SQL Error. Please contact adminnistrator";
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

        #endregion

        #region funtion

        #region IncreaseId function
        private void increaseMOId(int Id)
        {
            int MasterOId;
            SqlConnection connMO = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=jaziradb;Persist Security Info=True;User ID=admin;Password=admin");
            if (txtOrnamentName.Text == "")
            {
                connMO.Open();
                string sql = "select OrnamentCode from Tbl_MasterOrnament";
                SqlDataAdapter sqlda = new SqlDataAdapter(sql,connMO);
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    MasterOId = ds.Tables[0].Rows.Count;
                    MasterOId += 1;
                    txtOrnamentCode.Text = Convert.ToString(MasterOId);
                    txtOrnamentName.Focus();
                }
                else
                {
                    txtOrnamentCode.Text = "1";
                    txtOrnamentName.Focus();
                }
            }
            connMO.Close();
        }
        #endregion

        #region SetData function
        private MasterOrnamentBLL SetDataMasterOrnament()
        {
            objMasterOrnament.MasterOrnamentId = Convert.ToInt32(Request.QueryString["Id"]);
            objMasterOrnament.OrnamentCode = Convert.ToInt32(txtOrnamentCode.Text);
            objMasterOrnament.MasterOrnamentName = txtOrnamentName.Text.Trim().Replace("'", "''");
            objMasterOrnament.Status = 'A';
            objMasterOrnament.LoginId = 1;
            objMasterOrnament.LogDateTime = DateTime.Now;
            return objMasterOrnament;

        }
        #endregion

        #region Setdatatofield funtion
        private void SetDataToFieldMOrnament(int Id)
        {
            try
            {
                DataTable dt = JaziraBusinessLayer.BLL.General.MasterOrnamentBLL.SetOrnamentName(Id);
                txtOrnamentCode.Text = dt.Rows[0]["OrnamentCode"].ToString();
                txtOrnamentName.Text = dt.Rows[0]["MasterOrnamentName"].ToString();
                btnOMSave.Text = "Update";
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh,SetaDatatofieldsql! ";
                alert.Visible = true;
                lblMsg.Text = "sql error";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                //setSessionMsg("alert-error alert", "Unexpected SQl Error. Plz Contact on adminnistrator!", false);
                //alert.Visible = true;
                //lblAlertMessage.Text = exe.Message + "" + exe.Source;
            }
            catch (Exception ex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh, SetDataToFieldEx! ";
                lblMsg.Text = ex.Message + "" + ex.Source;
                alert.Visible = true;
                //lblAlertMessage.Text = ex.Message + "" + ex.Source;
                //alert.Visible = true;
            }
        }
        #endregion

        #endregion

        #endregion

        #region StoneShapeCUT

        #region Even

        #region Search even
        protected void btnSCUTSearch_Click(object sender, EventArgs e)
        {
            DGVStoneCUT();
        }
        #endregion

        #region Clear even
        private void ClearSCUT()
        {
            txtStoneCUTCode.Text = "";
            txtStoneCUTName.Text = "";
            DGVStoneCUT();
        }
        #endregion

        #region btnSave even
        protected void btnSCUTSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtStoneCUTName.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Stone CUT Name. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtStoneCUTName.Focus();
                    return;    
                }
                int SCUTId=Convert.ToInt32(Request.QueryString["SCUTId"]);
                if (StoneShapeCUTBLL.ValidationStoneCUT(txtStoneCUTName.Text, SCUTId) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Stone CUT Name is Already Exist. Please! Enter Next Name.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtStoneCUTName.Focus();
                    return;   
                }
                objStoneCUTBLL = SetDataStoneCUT();
                if (objStoneCUTBLL.Save(objStoneCUTBLL))
                {
                    ClearSCUT();
                    alert.Attributes["class"] = "alert alert-success";
                    lblMsgType.Text = "Well Done! ";
                    lblMsg.Text = "Data Saved Successfully.";
                    alert.Visible = true;
                    if (objStoneCUTBLL.StoneCUTId > 0)
                    {
                        Session["editAlert"] = true;
                        Response.Redirect("MasterMaintainance.aspx?act=StoneCUT", false);
                    }
                    //setSessionMsg("alert-success alert col-md-6", "Saved", true);
                    Response.Redirect("MasterMaintainance.aspx?act=StoneCUT", false);         
                }

            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-warning";
                lblMsgType.Text = "Oh!, Save Even sql Error ";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                alert.Visible = true;
                //setSessionMsg("alert-success alert col-md-6", "" + exe + "", true);
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

        #endregion

        #region GridView function

        #region dgvPageIndex funtion
        protected void dgvStoneCUT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvStoneCUT.PageIndex = e.NewPageIndex;
            DGVStoneCUT();
        }
        #endregion

        #region DGVStoneCUT function
        private void DGVStoneCUT()
        {
            try
            {
                string StoneCUTName = txtStoneCUTName.Text.Trim().Replace("'", "''");
                int SCUTId = Convert.ToInt32(Request.QueryString["SCUTId"]);
                DataTable dt = JaziraBusinessLayer.BLL.General.StoneShapeCUTBLL.GetStoneCUTName(StoneCUTName);
                dgvStoneCUT.DataSource = dt;
                dgvStoneCUT.DataBind();
                if (dt.Rows.Count == 0)
                    divNoDataSCUT.Visible = true;
                else
                    divNoDataSCUT.Visible = false;
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = "Unexpected SQL Error. Please contact adminnistrator";
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

        #endregion

        #region Function

        #region IncreaseId
        private void increaseStoneCUTId(int Id)
        {
            int StoneSCUTId;
            SqlConnection connSCUT = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=jaziradb;Persist Security Info=True;User ID=admin; Password=admin");
            if (txtStoneCUTCode.Text == "")
            {
                connSCUT.Open();
                string sql = "Select StoneCUTCode from Tbl_StoneShapeCUT";
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, connSCUT);
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    StoneSCUTId = ds.Tables[0].Rows.Count;
                    StoneSCUTId += 1;
                    txtStoneCUTCode.Text = Convert.ToString(StoneSCUTId);
                    txtStoneCUTName.Focus();
                }
                else
                {
                    txtStoneCUTCode.Text = "1";
                    txtStoneCUTName.Focus();
                }

            }
            connSCUT.Close();
        }
        #endregion

        #region SetData funtion
        private StoneShapeCUTBLL SetDataStoneCUT()
        {
            objStoneCUTBLL.StoneCUTId = Convert.ToInt32(Request.QueryString["Id"]);
            objStoneCUTBLL.StoneCUTCode = Convert.ToInt32(txtStoneCUTCode.Text);
            objStoneCUTBLL.StoneShapeCUTName = txtStoneCUTName.Text.Trim().Replace("'", "''");
            objStoneCUTBLL.Status = 'A';
            objStoneCUTBLL.LoginId = 1;
            objStoneCUTBLL.LogDateTime = DateTime.Now;
            return objStoneCUTBLL;
        }
        #endregion

        #region SetDataToField function
        private void SetDataToFieldSCUT(int Id)
        {
            try
            {
                DataTable dt = JaziraBusinessLayer.BLL.General.StoneShapeCUTBLL.SetStoneShapeCUTName(Id);
                txtStoneCUTCode.Text = dt.Rows[0]["StoneCUTCode"].ToString();
                txtStoneCUTName.Text = dt.Rows[0]["StoneShapeCUTName"].ToString();
                btnSCUTSave.Text = "Update";
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh,SetaDatatofieldsql! ";
                alert.Visible = true;
                lblMsg.Text = "sql error";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                //setSessionMsg("alert-error alert", "Unexpected SQl Error. Plz Contact on adminnistrator!", false);
                //alert.Visible = true;
                //lblAlertMessage.Text = exe.Message + "" + exe.Source;
            }
            catch (Exception ex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh, SetDataToFieldEx! ";
                lblMsg.Text = ex.Message + "" + ex.Source;
                alert.Visible = true;
                //lblAlertMessage.Text = ex.Message + "" + ex.Source;
                //alert.Visible = true;
            }
        }
        #endregion

        #endregion

        #endregion

        #region StoneColor

        #region Even

        #region Search even
        protected void btnSCSearch_Click(object sender, EventArgs e)
        {
            DGVStoneColor();
        }
        #endregion

        #region Clear even
        private void ClearStoneC()
        {
            txtStoneColorCode.Text = "";
            txtStoneColorName.Text = "";
            DGVStoneColor();
        }
        #endregion

        #region bntSave
        protected void btnSCSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtStoneColorName.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Stone Color Name. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtStoneColorName.Focus();
                    return;     
                }
                int SCId=Convert.ToInt32(Request.QueryString["SCId"]);
                if (StoneColorBLL.ValidationStoneColor(txtStoneColorName.Text, SCId) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Stone Color Name is Already Exist. Please! Enter Next Name.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtStoneColorName.Focus();
                    return;    
                }
                objStoneColorBLL = SetDataStoneColor();
                if (objStoneColorBLL.Save(objStoneColorBLL))
                {
                    ClearStoneC();
                    alert.Attributes["class"] = "alert alert-success";
                    lblMsgType.Text = "Well Done! ";
                    lblMsg.Text = "Data Saved Successfully.";
                    alert.Visible = true;
                    if (objStoneColorBLL.StoneColorId > 0)
                    {
                        Session["editAlert"] = true;
                        Response.Redirect("MasterMaintainance.aspx?act=StoneColor", false);
                    }
                    //setSessionMsg("alert-success alert col-md-6", "Saved", true);
                    Response.Redirect("MasterMaintainance.aspx?act=StoneColor", false);      
                }
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-warning";
                lblMsgType.Text = "Oh!, Save Even sql Error ";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                alert.Visible = true;
                //setSessionMsg("alert-success alert col-md-6", "" + exe + "", true);
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

        #endregion

        #region GridView Function

        #region dgvPageIndex function
        protected void dgvStoneColor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvStoneColor.PageIndex = e.NewPageIndex;
            DGVStoneColor();
        }
        #endregion

        #region DGVStoneColor
        private void DGVStoneColor()
        {
            try
            {
                string StoneCname = txtStoneColorName.Text.Trim().Replace("'", "''");
                int StoneColorId = Convert.ToInt32(Request.QueryString["StoneColorId"]);
                DataTable dt = JaziraBusinessLayer.BLL.General.StoneColorBLL.GetStoneColorName(StoneCname);
                dgvStoneColor.DataSource = dt;
                dgvStoneColor.DataBind();
                if (dt.Rows.Count == 0)
                    divNoDataSC.Visible = true;
                else
                    divNoDataSC.Visible = false;

            }
            catch (SqlException sqlex)
            {
                alert.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = "Unexpected SQL Error. Please contact adminnistrator";
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

        #endregion

        #region Function

        #region increaseId funtion
        private void increaseSCId(int Id)
        {
            int SCId;
            SqlConnection connSC = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=jaziradb;Persist Security Info=True;User ID=admin; Password=admin");
            if (txtStoneColorCode.Text == "")
            {
                connSC.Open();
                string sql = "select StoneColorCode From Tbl_StoneColor";
                SqlDataAdapter sqlda = new SqlDataAdapter(sql,connSC);
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    SCId = ds.Tables[0].Rows.Count;
                    SCId += 1;
                    txtStoneColorCode.Text = Convert.ToString(SCId);
                    txtStoneColorName.Focus();
                }
                else
                {
                    txtStoneColorCode.Text = "1";
                    txtStoneColorName.Focus();
                }
            }
            connSC.Close();
        }
        #endregion

        #region SetData function
        private StoneColorBLL SetDataStoneColor()
        {
            objStoneColorBLL.StoneColorId = Convert.ToInt32(Request.QueryString["Id"]);
            objStoneColorBLL.StoneColorCode = Convert.ToInt32(txtStoneColorCode.Text);
            objStoneColorBLL.StoneColorName = txtStoneColorName.Text.Trim().Replace("'", "''");
            objStoneColorBLL.Status = 'A';
            objStoneColorBLL.LoginId = 1;
            objStoneColorBLL.LogDateTime = DateTime.Now;
            return objStoneColorBLL;
        }
        #endregion

        #region SetDataToField function
        private void SetDataToFieldSC(int Id)
        {
            try
            {
                DataTable dt = JaziraBusinessLayer.BLL.General.StoneColorBLL.SetStoneColorName(Id);
                txtStoneColorCode.Text = dt.Rows[0]["StoneColorCode"].ToString();
                txtStoneColorName.Text = dt.Rows[0]["StoneColorName"].ToString();
                btnSCSave.Text = "Update";
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh,SetaDatatofieldsql! ";
                alert.Visible = true;
                lblMsg.Text = "sql error";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                //setSessionMsg("alert-error alert", "Unexpected SQl Error. Plz Contact on adminnistrator!", false);
                //alert.Visible = true;
                //lblAlertMessage.Text = exe.Message + "" + exe.Source;
            }
            catch (Exception ex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh, SetDataToFieldEx! ";
                lblMsg.Text = ex.Message + "" + ex.Source;
                alert.Visible = true;
                //lblAlertMessage.Text = ex.Message + "" + ex.Source;
                //alert.Visible = true;
            }
        }
        #endregion

        #endregion

        #endregion

        #region StoneShape

        #region Even

        #region Search even
        protected void btnStonaSSearch_Click(object sender, EventArgs e)
        {
            DGVStoneShape();
        }
        #endregion

        #region Clear even
        private void ClearStoneS()
        {
            txtStoneShape.Text = "";
            DGVStoneShape();
        }

        #endregion

        #region btnSave even
        protected void btnStoneSSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtStoneShape.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Stone Shape. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtStoneShape.Focus();
                    return; 
                }
                int SSId = Convert.ToInt32(Request.QueryString["SSId"]);
                if (StoneShapeBLL.ValidationStoneShape(txtStoneShape.Text, SSId) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Stone Shapne is Already Exist. Please! Enter Next Name.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtStoneShape.Focus();
                    return;       
                }
                objStoneShapeBLL = SetDataStoneShape();
                if (objStoneShapeBLL.Save(objStoneShapeBLL))
                {
                    ClearStoneS();
                    alert.Attributes["class"] = "alert alert-success";
                    lblMsgType.Text = "Well Done! ";
                    lblMsg.Text = "Data Saved Successfully.";
                    alert.Visible = true;
                    if (objStoneShapeBLL.StoneShapeId > 0)
                    {
                        Session["editAlert"] = true;
                        Response.Redirect("MasterMaintainance.aspx?act=StoneShape", false);
                    }
                    //setSessionMsg("alert-success alert col-md-6", "Saved", true);
                    Response.Redirect("MasterMaintainance.aspx?act=StoneShape", false);   
                }
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-warning";
                lblMsgType.Text = "Oh!, Save Even sql Error ";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                alert.Visible = true;
                //setSessionMsg("alert-success alert col-md-6", "" + exe + "", true);
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

        #endregion

        #region GridView Function

        #region GridViewPageIndex function
        protected void dgvStoneShape_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvStoneShape.PageIndex = e.NewPageIndex;
            DGVStoneShape();
        }
        #endregion

        #region DGV function
        private void DGVStoneShape()
        {
            try
            {
                string StoneSName = txtStoneShape.Text.Trim().Replace("'", "''");
                int StoneShapeId = Convert.ToInt32(Request.QueryString["StoneShapeId"]);
                DataTable dt = JaziraBusinessLayer.BLL.General.StoneShapeBLL.GetStoneShapeGridView(StoneSName);
                dgvStoneShape.DataSource = dt;
                dgvStoneShape.DataBind();
                if (dt.Rows.Count == 0)
                    divNoStoneSData.Visible = true;
                else
                    divNoStoneSData.Visible = false;
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = "Unexpected SQL Error. Please contact adminnistrator";
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

        #endregion

        #region function

        #region increaseId
        private void increaseStoneSId(int Id)
        {
            int StoneSId;
            SqlConnection connStoneS = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=jaziradb;Persist Security Info=True;User ID=admin; Password=admin");
            if (txtStoneShape.Text == "")
            {
                connStoneS.Open();
                string sql = "Select StoneShapeCode from Tbl_StoneShape";
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, connStoneS);
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    StoneSId = ds.Tables[0].Rows.Count;
                    StoneSId += 1;
                    txtStoneShapeCode.Text = Convert.ToString(StoneSId);
                    txtStoneShape.Focus();

                }
                else
                {
                    txtStoneShapeCode.Text = "1";
                    txtStoneShape.Focus();
                }
            }
        }
        #endregion

        #region SetData function
        private StoneShapeBLL SetDataStoneShape()
        {
            objStoneShapeBLL.StoneShapeId = Convert.ToInt32(Request.QueryString["Id"]);
            objStoneShapeBLL.StoneShapeCode = Convert.ToInt32(txtStoneShapeCode.Text);
            objStoneShapeBLL.StoneShapeName = txtStoneShape.Text.Trim().Replace("'", "''");
            objStoneShapeBLL.Status = 'A';
            objStoneShapeBLL.LoginId = 1;
            objStoneShapeBLL.LogDateTime = DateTime.Now;
            return objStoneShapeBLL;
        }
        #endregion

        #region SetDataToField
        private void SetDataToFieldSS(int Id)
        {
            try
            {
                DataTable dt = JaziraBusinessLayer.BLL.General.StoneShapeBLL.SetStopneShapeName(Id);
                txtStoneShapeCode.Text = dt.Rows[0]["StoneShapeCode"].ToString();
                txtStoneShape.Text = dt.Rows[0]["StoneShapeName"].ToString();
                btnStoneSSave.Text = "Update";
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh,SetaDatatofieldsql! ";
                alert.Visible = true;
                lblMsg.Text = "sql error";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                //setSessionMsg("alert-error alert", "Unexpected SQl Error. Plz Contact on adminnistrator!", false);
                //alert.Visible = true;
                //lblAlertMessage.Text = exe.Message + "" + exe.Source;
            }
            catch (Exception ex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh, SetDataToFieldEx! ";
                lblMsg.Text = ex.Message + "" + ex.Source;
                alert.Visible = true;
                //lblAlertMessage.Text = ex.Message + "" + ex.Source;
                //alert.Visible = true;
            }
        }
        #endregion

        #endregion

        #endregion

        #region Salary Type

        #region even
        #region Clear even
        private void ClearSal()
        {
            txtSalaryCode.Text = "";
            txtSalaryTypeName.Text = "";
            DGVSalaryType();
        }
        #endregion

        #region btnSave even
        protected void btnSalSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSalaryTypeName.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Salary Type Name. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtSalaryTypeName.Focus();
                    return;
                }
                int SalId = Convert.ToInt32(Request.QueryString["SalId"]);
                if (SalaryTypeBLL.ValidationSalaryType(txtSalaryTypeName.Text, SalId) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "SalaryType Name Already Exist. Please! Enter Next Name.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtSalaryTypeName.Focus();
                    return;  
                }
                objSalaryTypeBLL = SetDataSalaryType();
                if (objSalaryTypeBLL.Save(objSalaryTypeBLL))
                {
                    ClearSal();
                    alert.Attributes["class"] = "alert alert-success";
                    lblMsgType.Text = "Well Done! ";
                    lblMsg.Text = "Data Saved Successfully.";
                    alert.Visible = true;
                    if (objSalaryTypeBLL.SalaryTypeId > 0)
                    {
                        Session["editAlert"] = true;
                        Response.Redirect("MasterMaintainance.aspx?act=SalaryType", false);
                    }
                    //setSessionMsg("alert-success alert col-md-6", "Saved", true);
                    Response.Redirect("MasterMaintainance.aspx?act=SalaryType", false);
                }
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-warning";
                lblMsgType.Text = "Oh!, Save Even sql Error ";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                alert.Visible = true;
                //setSessionMsg("alert-success alert col-md-6", "" + exe + "", true);
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

        #region Search even
        protected void btnSalSearch_Click(object sender, EventArgs e)
        {
            DGVSalaryType();
        }
        #endregion

        #endregion

        #region GridView
        #region GridView DGV function
        private void DGVSalaryType()
        {
            try
            {
                string SalName = txtSalaryTypeName.Text.Trim().Replace("'", "''");
                int SalaryTypeId = Convert.ToInt32(Request.QueryString["SalaryTypeId"]);
                DataTable dt = JaziraBusinessLayer.BLL.General.SalaryTypeBLL.GetSalaryTypeNameGridView(SalName);
                dgvSalaryType.DataSource = dt;
                dgvSalaryType.DataBind();
                if (dt.Rows.Count == 0)
                    divNoSalData.Visible = true;
                else
                    divNoSalData.Visible = false;
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = "Unexpected SQL Error. Please contact adminnistrator";
                alert.Visible = true;
                lblMsg.Text = sqlex.Message + " " + sqlex.Source;
            }
            catch(Exception ex)
            {
                alert.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh! GridView Exception! ";
                lblMsg.Text = ex.Message + " " + ex.Source;
                alert.Visible = true;
            }
        }
        #endregion

        #region GridviewPageIndex even
        protected void dgvSalaryType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvSalaryType.PageIndex = e.NewPageIndex;
            DGVSalaryType();
        }
        #endregion
        #endregion

        #region function

        #region SetData function
        private SalaryTypeBLL SetDataSalaryType()
        {
            objSalaryTypeBLL.SalaryTypeId = Convert.ToInt32(Request.QueryString["Id"]);
            objSalaryTypeBLL.SalaryTypeCode = Convert.ToInt32(txtSalaryCode.Text);
            objSalaryTypeBLL.SalaryTypeName = txtSalaryTypeName.Text.Trim().Replace("'", "''");
            objSalaryTypeBLL.Status = 'A';
            objSalaryTypeBLL.LoginId = 1;
            objSalaryTypeBLL.LogDateTime = DateTime.Now;
            return objSalaryTypeBLL;
        }
        #endregion

        #region SetDataToField fucntion
        private void SetDataToFieldSalary(int Id)
        {
            try
            {
                DataTable dt = JaziraBusinessLayer.BLL.General.SalaryTypeBLL.GetSalaryTypeName(Id);
                txtSalaryCode.Text = dt.Rows[0]["SalaryTypeCode"].ToString();
                txtSalaryTypeName.Text = dt.Rows[0]["SalaryTypeName"].ToString();
                btnSalSave.Text = "Update";
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh,SetaDatatofieldsql! ";
                alert.Visible = true;
                lblMsg.Text = "sql error";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                //setSessionMsg("alert-error alert", "Unexpected SQl Error. Plz Contact on adminnistrator!", false);
                //alert.Visible = true;
                //lblAlertMessage.Text = exe.Message + "" + exe.Source;
            }
            catch (Exception ex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh, SetDataToFieldEx! ";
                lblMsg.Text = ex.Message + "" + ex.Source;
                alert.Visible = true;
                //lblAlertMessage.Text = ex.Message + "" + ex.Source;
                //alert.Visible = true;
            }
        }
        #endregion

        #region increaseId function
        private void increaseSalId(int Id)
        {
            int salaId;
            SqlConnection connSal = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=jaziradb;Persist Security Info=True;User ID=admin; Password=admin");
            if (txtSalaryCode.Text == "")
            {
                connSal.Open();
                string sql = "Select SalaryTypeCode from Tbl_SalaryType";
                SqlDataAdapter sqlda = new SqlDataAdapter(sql,connSal);
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    salaId = ds.Tables[0].Rows.Count;
                    salaId += 1;
                    txtSalaryCode.Text = Convert.ToString(salaId);
                    txtSalaryTypeName.Focus();
                }
                else
                {
                    txtSalaryCode.Text = "1";
                    txtSalaryTypeName.Focus();
                }
            }
            connSal.Close();
        }
        #endregion

        #endregion

        #endregion close salary

        #region Section

        #region GridView fucntion
        #region DGVSection function
        private void DGVSection()
        {
            try
            {
                string Secname = txtSectionName.Text.Trim().Replace("'", "''");
                int SectionId = Convert.ToInt32(Request.QueryString["SectionId"]);
                DataTable dt =JaziraBusinessLayer.BLL.General.SectionBLL.GetSectionName(Secname);
                dgvSection.DataSource = dt;
                dgvSection.DataBind();
                if (dt.Rows.Count == 0)
                    divNoSecData.Visible = true;
                else
                    divNoSecData.Visible = false;
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = "Unexpected SQL Error. Please contact adminnistrator";
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

        #region gridview pageindex even
        protected void dgvSection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvSection.PageIndex = e.NewPageIndex;
            DGVSection();
        }
        #endregion
        #endregion

        #region Even
        #region Search even
        protected void btnSecSearch_Click(object sender, EventArgs e)
        {
            DGVSection();
        }
        #endregion

        #region clear section even
        private void ClearSec()
        {
            txtSectionCode.Text = "";
            txtSectionName.Text = "";
            DGVSection();
        }
        #endregion

        #region Section Save even
        protected void btnSecSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSectionName.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Section Name. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtSectionName.Focus();
                    return;
                }
                int SecId = Convert.ToInt32(Request.QueryString["SecId"]);
                if (SectionBLL.ValidationSectionName(txtSectionName.Text, SecId) == false)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Section Name Already Exist. Please! Enter Next Name.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtSectionName.Focus();
                    return;
                }
                objSectionBLL = SetDataSection();
                if (objSectionBLL.Save(objSectionBLL))
                {
                    ClearSec();
                    alert.Attributes["class"] = "alert alert-success";
                    lblMsgType.Text = "Well Done! ";
                    lblMsg.Text = "Data Saved Successfully.";
                    alert.Visible = true;
                    if (objSectionBLL.SectionId> 0)
                    {
                        Session["editAlert"] = true;
                        Response.Redirect("MasterMaintainance.aspx?act=Section", false);
                    }
                    //setSessionMsg("alert-success alert col-md-6", "Saved", true);
                    Response.Redirect("MasterMaintainance.aspx?act=Section", false);
                }
            }

            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-warning";
                lblMsgType.Text = "Oh!, Save Even sql Error ";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                alert.Visible = true;
                //setSessionMsg("alert-success alert col-md-6", "" + exe + "", true);
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
        #endregion

        #region fucntion
        #region SetDataTofield fuction
        private void SetDataToFieldSection(int Id)
        {
            try
            {
                DataTable dt = new JaziraBusinessLayer.BLL.General.SectionBLL().SetSectionName(Id);
                txtSectionCode.Text = dt.Rows[0]["SectionCode"].ToString();
                txtSectionName.Text = dt.Rows[0]["SectionName"].ToString();
                btnSecSave.Text = "Update";
            }
            catch (SqlException sqlex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh,SetaDatatofieldsql! ";
                alert.Visible = true;
                lblMsg.Text = "sql error";
                lblMsg.Text = sqlex.Message + "" + sqlex.Source;
                //setSessionMsg("alert-error alert", "Unexpected SQl Error. Plz Contact on adminnistrator!", false);
                //alert.Visible = true;
                //lblAlertMessage.Text = exe.Message + "" + exe.Source;

            }
            catch (Exception ex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh, SetDataToFieldEx! ";
                lblMsg.Text = ex.Message + "" + ex.Source;
                alert.Visible = true;
                //lblAlertMessage.Text = ex.Message + "" + ex.Source;
                //alert.Visible = true;
            }
        }
        #endregion

        #region SetData fucntion
        private SectionBLL SetDataSection()
        {
            objSectionBLL.SectionId = Convert.ToInt32(Request.QueryString["Id"]);
            objSectionBLL.SectionCode = Convert.ToInt32(txtSectionCode.Text);
            objSectionBLL.SectionName = txtSectionName.Text.Trim().Replace("'", "''");
            objSectionBLL.Status = 'A';
            objSectionBLL.LoginId = 1;
            objSectionBLL.LogDateTime = DateTime.Now;
            return objSectionBLL;
        }
        #endregion

        #region incarease Id function

        private void increaseSecId(int Id)
        {
            int s;
            SqlConnection connSec = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=jaziradb;Persist Security Info=True;User ID=admin; Password=admin");
            if (txtSectionCode.Text == "")
            {
                connSec.Open();
                string sql = "select SectionCode from Tbl_Section";
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, connSec);
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    s = ds.Tables[0].Rows.Count;
                    s += 1;
                    txtSectionCode.Text = Convert.ToString(s);
                    txtSectionName.Focus();
                }
                else
                {
                    txtSectionCode.Text = "1";
                    txtSectionName.Focus();
                }
            }
            connSec.Close();

        }

        #endregion

        #endregion
        #endregion

        #region GoldType
        #region increaseId
        private void increaseid(int Id)
        {
            int a;
            SqlConnection conn = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=jaziradb;Persist Security Info=True;User ID=admin;Password=admin");
           if(txtGoldTypeCode.Text=="")
           {
                conn.Open();
                string Sql = "select GoldTypeCode from Tbl_GoldType";
                SqlDataAdapter sqlda = new SqlDataAdapter(Sql,conn);
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {

                    a = ds.Tables[0].Rows.Count;
                    a += 1;
                    txtGoldTypeCode.Text = Convert.ToString(a);
                    txtGoldTypeName.Focus();
                }
                else
                {
                    txtGoldTypeCode.Text = "1";
                    txtGoldTypeName.Focus();
                }
           }
            conn.Close();
        }
        #endregion

        #region Gridview function goldType
        private void DGVGoldType()
        {
            try
            {
                string GoldName = txtGoldTypeName.Text.Trim().Replace("'", "''");
                int GoldTypeId = Convert.ToInt32(Request.QueryString["GoldTypeId"]);
                GoldTypeBLL data = new GoldTypeBLL();
                System.Data.DataTable dt = JaziraBusinessLayer.BLL.General.GoldTypeBLL.GetGoldType(GoldName);
                dgvGoldType.DataSource = dt;
                dgvGoldType.DataBind();
                if (dt.Rows.Count == 0)
                    divNoDaa.Visible = true;
                else
                    divNoDaa.Visible = false;
                    
                
            }
            catch (System.Data.SqlClient.SqlException sqlex)
            {
                alert.Attributes["Class"] = "alert alert-error";
                lblMsgType.Text = "Oh";
                lblMsg.Text = "Unexpected SQL Error. Please contact adminnistrator";
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

        #region Gold Type fuction 

        #region Setdatatofield fuction
        private void SetDataDataToFieldGold(int Id)
        {
            try
            {
                DataTable dt = new JaziraBusinessLayer.BLL.General.GoldTypeBLL().GetGoldTypeName(Id);
                txtGoldTypeCode.Text = dt.Rows[0]["GoldTypeCode"].ToString();
                txtGoldTypeName.Text = dt.Rows[0]["GoldTypeName"].ToString();
                tbnGSave.Text = "Update";
            }
            catch (SqlException exe)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh,SetaDatatofieldsql! ";
                alert.Visible = true;
                lblMsg.Text = "sql error";
                lblMsg.Text = exe.Message + "" + exe.Source;
                //setSessionMsg("alert-error alert", "Unexpected SQl Error. Plz Contact on adminnistrator!", false);
                //alert.Visible = true;
                //lblAlertMessage.Text = exe.Message + "" + exe.Source;
            }
            catch (Exception ex)
            {
                alert.Attributes["class"] = "alert alert-error";
                lblMsgType.Text = "Oh, SetDataToFieldEx! ";
                lblMsg.Text = ex.Message + "" + ex.Source;
                alert.Visible = true;
                //lblAlertMessage.Text = ex.Message + "" + ex.Source;
                //alert.Visible = true;
            }
        }
        #endregion

        #region SetData function
        private JaziraBusinessLayer.BLL.General.GoldTypeBLL SetData()
        {
                JaziraBusinessLayer.BLL.General.GoldTypeBLL objGoldTypeBLL = new JaziraBusinessLayer.BLL.General.GoldTypeBLL();
                objGoldTypeBLL.GoldTypeId = Convert.ToInt16(Request.QueryString["Id"]);
                objGoldTypeBLL.GoldTypeCode = Convert.ToInt32(txtGoldTypeCode.Text);
                objGoldTypeBLL.GoldTypeName = txtGoldTypeName.Text.Trim().Replace("'", "''");
                objGoldTypeBLL.Status = 'A';
                objGoldTypeBLL.LoginId = 1;
                objGoldTypeBLL.LogDateTime = DateTime.Now;
                return objGoldTypeBLL;
        }
        #endregion

        #region clear even
        private void Clear()
        {
            txtGoldTypeCode.Text = "";
            txtGoldTypeName.Text = "";
            DGVGoldType();
        }
        #endregion


        #region GoldType even
        public void tbnGSave_Click(object sender, EventArgs eArgs)
        {
            try
            {
               
                if (string.IsNullOrWhiteSpace(txtGoldTypeName.Text) == true)
                {
                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Plz! Type Gold Name. Not Allowed Blanks!";
                    lblMsgType.Text = "Warning! ";
                   
                    //setSessionMsg("alert-error alert col-md-6", "Enter value", true);
                    txtGoldTypeName.Focus();
                    return;
                }
               
                int Id = Convert.ToInt32(Request.QueryString["Id"]);
                if (GoldTypeBLL.ValidationGOldType(txtGoldTypeName.Text, Id) == false)
                {

                    alert.Visible = true;
                    alert.Attributes["class"] = "alert alert-warning";
                    lblMsg.Text = "Gold Type Name Already Exist. Please! Enter Next Name.";
                    lblMsgType.Text = "Warning! ";
                    //setSessionMsg("alert-error alert col-md-6", "Duplicate", true);
                    txtGoldTypeName.Focus();
                    return;
                }
               
                objGoldTypeBLL = SetData();
                if (objGoldTypeBLL.Save(objGoldTypeBLL))
                {
                    Clear();
                    alert.Attributes["class"] = "alert alert-success";
                    lblMsgType.Text = "Well Done! ";
                    lblMsg.Text = "Data Saved Successfully.";
                    alert.Visible = true;
                    if (objGoldTypeBLL.GoldTypeId > 0)
                    {
                        Session["editAlert"] = true;
                        Response.Redirect("MasterMaintainance.aspx?act=GoldType", false);
                    }
                    //setSessionMsg("alert-success alert col-md-6", "Saved", true);
                    Response.Redirect("MasterMaintainance.aspx?act=GoldType", false);
                }
            }
            catch (SqlException exe)
            {
                alert.Attributes["class"] = "alert alert-warning";
                lblMsg.Text = exe.Message + "" + exe.Source;
                alert.Visible = true;
                //setSessionMsg("alert-success alert col-md-6", "" + exe + "", true);
            }
            catch (Exception ex)
            {
                alert.Attributes["Class"] = "alert alert-warning";
                lblMsgType.Text = "Oh";
                lblMsg.Text = ex.Message + " " + ex.Source;
                alert.Visible = true;
                //setSessionMsg("alert-success alert col-md-6", "" + ex + "", true);
            }
        }
        #endregion


        #region Gridview even GoldType
        protected void dgvGoldType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvGoldType.PageIndex = e.NewPageIndex;
            DGVGoldType();
        }
        #endregion


        #region serch even
        protected void btnGSearch_Click(object sender, EventArgs e)
        {
            DGVGoldType();
        }
        #endregion

        #endregion

        #endregion
    }
}