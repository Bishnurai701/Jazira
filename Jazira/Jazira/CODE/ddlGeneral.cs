using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using Jazira;
using JaziraBusinessLayer;




namespace Jazira.CODE
{
    public class ddlGeneral
    {
        public static string SchoolDetailId = "";
        public static string CompanyName = "";
        public static string CorrespondenceName = "";
        public static string CompanyAddress = "";
        public static string EstdYear = "";
        public static string AffiliatedFrom = "";
        public static string Country = "";
        public static string State = "";
        public static string District = "";
        public static string City = "";
        public static string WordNo = "";
        public static string HouseNo = "";
        public static string vdc = "";
        public static string PinNo = "";
        public static string PhoneNo = "";
        public static string EmailId = "";
        public static string Website = "";
        public static string IsBranch = "";
        public static string Image = "";

        //added by Bishnu Khaling  for the case of image
        public static string logoImage = "../img/logo.jpg";

        public static string[] AcceptedImageFileTypes = new string[] { ".jpg", ".jpeg", ".gif", ".png" };


        public static void LoadDropDownList(DropDownList paramDDL, DataTable paramSource)
        {
            paramDDL.DataTextField = "NAME";
            paramDDL.DataValueField = "ID";
            paramDDL.DataSource = paramSource;
            paramDDL.DataBind();

        }
        public static void LoadDropDownList(DropDownList paramDDL, DataTable paramSource, string emptyMessage)
        {
            paramDDL.DataTextField = "NAME";
            paramDDL.DataValueField = "ID";
            if (paramSource.Rows.Count > 0)
            {
                paramDDL.DataSource = paramSource;
            }
            else
            {
                DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = emptyMessage;
                paramSource.Rows.InsertAt(row, 0);
                paramDDL.DataSource = paramSource;
            }
            paramDDL.DataBind();
        }
        public static void LoadDropDownList(DropDownList paramDDL, DataTable paramSource, string emptyMessage, string displayString)
        {
            paramDDL.DataTextField = "NAME";
            paramDDL.DataValueField = "ID";
            if (paramSource.Rows.Count > 0)
            {
                DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = displayString;
                paramSource.Rows.InsertAt(row, 0);
                paramDDL.DataSource = paramSource;
            }
            else
            {
                DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = emptyMessage;
                paramSource.Rows.InsertAt(row, 0);
                paramDDL.DataSource = paramSource;
            }
            paramDDL.DataBind();
        }
        public static void LoadDropDownList_WithNA(DropDownList ddl, DataTable dt)
        {
            System.Data.DataRow datarow = dt.NewRow();
            datarow["Id"] = 0;
            datarow["Name"] = "-- N/A --";
            dt.Rows.InsertAt(datarow, 0);

            ddl.DataTextField = "NAME";
            ddl.DataValueField = "ID";
            ddl.DataSource = dt;
            ddl.DataBind();
            ddl.SelectedValue = "0";
        }
        public static void LoadDropDownList_id(DropDownList paramDDL, DataTable paramSource)
        {
            paramDDL.DataTextField = "id";
            paramDDL.DataValueField = "id";
            paramDDL.DataSource = paramSource;
            paramDDL.DataBind();
        }
        public static void LoadDropDownList_withAll(DropDownList paramDDL, DataTable paramSource)
        {
            if (paramSource.Rows.Count > 0)
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "-- All --";
                paramSource.Rows.InsertAt(row, 0);
            }
            else
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "-- No Data --";
                paramSource.Rows.InsertAt(row, 0);
            }
            paramDDL.DataTextField = "NAME";
            paramDDL.DataValueField = "ID";
            paramDDL.DataSource = paramSource;
            paramDDL.DataBind();
            paramDDL.SelectedValue = "0";
        }
        public static void LoadStoneCUT(DropDownList paramDDL, DataTable paramSource)
        {
            if (paramSource.Rows.Count > 0)
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "--SELECT Stone CUT--";
                paramSource.Rows.InsertAt(row, 0);
            }
            else
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0]="0";
                row[1] = "--NO DATA--";
                paramSource.Rows.InsertAt(row, 0);
            }
            paramDDL.DataTextField = "Name";
            paramDDL.DataValueField = "ID";
            paramDDL.DataSource = paramSource;
            paramDDL.DataBind();
            //paramDDL.SelectedValue = "0";
        }

        public static void LoadSroneClearity(DropDownList paramDDL, DataTable paramSource)
        {
            if (paramSource.Rows.Count > 0)
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "--SELECT CLEARITY--";
                paramSource.Rows.InsertAt(row, 0);
            }
            else
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "--NO DATA--";
                paramSource.Rows.InsertAt(row, 0);
            }
            paramDDL.DataTextField = "Name";
            paramDDL.DataValueField = "ID";
            paramDDL.DataSource = paramSource;
            paramDDL.DataBind(); 
        }
        public static void LoadColor(DropDownList paramDDL, DataTable paramSource)
        {
            if (paramSource.Rows.Count > 0)
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "--SELECT COLOR--";
                paramSource.Rows.InsertAt(row, 0);
            }
            else
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "--NO DATA--";
                paramSource.Rows.InsertAt(row, 0);
            }
            paramDDL.DataTextField = "Name";
            paramDDL.DataValueField = "ID";
            paramDDL.DataSource = paramSource;
            paramDDL.DataBind();   
        }

        public static void LoadStoneShape(DropDownList paramDDL, DataTable paramSource)
        {
            if (paramSource.Rows.Count > 0)
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "--SELECT SHAPE--";
                paramSource.Rows.InsertAt(row, 0);
            }
            else
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "--NO DATA--";
                paramSource.Rows.InsertAt(row, 0);
            }
            paramDDL.DataTextField = "Name";
            paramDDL.DataValueField = "ID";
            paramDDL.DataSource = paramSource;
            paramDDL.DataBind();   
        }
        public static void LoadUserGroup(DropDownList paramDDL, DataTable paramSource)
        {
            if (paramSource.Rows.Count > 0)
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "--SELECT USER GROUP--";
                paramSource.Rows.InsertAt(row, 0);
            }
            else
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "--NO DATA--";
                paramSource.Rows.InsertAt(row, 0);
            }
            paramDDL.DataTextField = "Name";
            paramDDL.DataValueField = "ID";
            paramDDL.DataSource = paramSource;
            paramDDL.DataBind();

        }
        public static void LoadSectionCode(DropDownList paramDLL, DataTable paramSource)
        {
            if (paramSource.Rows.Count > 0)
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "--SELECT SECTION--";
                paramSource.Rows.InsertAt(row, 0);
            }
            else
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "--NO DATA--";
                paramSource.Rows.InsertAt(row, 0);
            }
            paramDLL.DataTextField = "Name";
            paramDLL.DataValueField = "ID";
            paramDLL.DataSource = paramSource;
            paramDLL.DataBind();
        }
        public static void LoadSalaryType(DropDownList paramDLL, DataTable paramSource)
        {
            if (paramSource.Rows.Count > 0)
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "--SELECT SALARY--";
                paramSource.Rows.InsertAt(row, 0);
            }
            else
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "--NO DATA--";
                paramSource.Rows.InsertAt(row, 0);
            }
            paramDLL.DataTextField = "Name";
            paramDLL.DataValueField = "ID";
            paramDLL.DataSource = paramSource;
            paramDLL.DataBind();
        }
        public static void LoadWSection(DropDownList paramDLL, DataTable paramSource)
        {
            if (paramSource.Rows.Count > 0)
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "--SELECT WORKING SECTION--";
                paramSource.Rows.InsertAt(row, 0);
            }
            else
            {
                System.Data.DataRow row = paramSource.NewRow();
                row[0] = "0";
                row[1] = "--NO DATA--";
                paramSource.Rows.InsertAt(row, 0);
            }
            paramDLL.DataTextField = "Name";
            paramDLL.DataValueField = "ID";
            paramDLL.DataSource = paramSource;
            paramDLL.DataBind();
        }

        public static void LoadDropDownList_withSelect(DropDownList paramDDL, DataTable paramSource)
        {
            System.Data.DataRow row = paramSource.NewRow();
            row[0] = "0";
            if (paramSource.Rows.Count > 0)
                row[1] = "-- SELECT --";
            else
                row[1] = "-- NO DATA --";
            paramSource.Rows.InsertAt(row, 0);
            paramDDL.DataTextField = "NAME";
            paramDDL.DataValueField = "ID";
            paramDDL.DataSource = paramSource;
            paramDDL.DataBind();
        }
        public static void LoadDropDownList_Primary(DropDownList paramDDL, DataTable paramSource)
        {
            if (paramSource.Rows.Count > 0)
                paramSource.Rows.Add(new object[] { "0", "Primary" });
            else
                paramSource.Rows.Add(new object[] { "0", "-- No Data --" });
            paramDDL.DataTextField = "NAME";
            paramDDL.DataValueField = "ID";
            paramDDL.DataSource = paramSource;
            paramDDL.DataBind();
        }
        public static void LoadDropDownList_NameOnly(DropDownList paramDDL, DataTable paramSource)
        {
            paramDDL.DataTextField = "NAME";
            paramDDL.DataValueField = "NAME";
            paramDDL.DataSource = paramSource;
            paramDDL.DataBind();


        }

        // for fine policy( reason for inactive)



        internal static void LoadDropDownList(DropDownList ddl_formtype, object p)
        {
            ddl_formtype.DataTextField = "FormType";
            ddl_formtype.DataValueField = "ID";
            ddl_formtype.DataSource = p;
            ddl_formtype.DataBind();
            //throw new NotImplementedException();
        }


        internal static void LoadDropDownList1(DropDownList ddl_form, object p)
        {
            ddl_form.DataTextField = "NAME";
            ddl_form.DataValueField = "ID";
            ddl_form.DataSource = p;
            ddl_form.DataBind();
            //throw new NotImplementedException();
        }

        internal static void LoadDropDownList_withSelect(DropDownList ddl_district, object p)
        {

            //throw new NotImplementedException();
        }

        public static string prepareDialogMsg(string str_msg)
        {
            return str_msg.Replace(" ", "&nbsp;");
        }
        //Security user permission


        public static DataTable dt;


        public static bool getFormPermission(string formname)
        {
            if (dt != null)
            {
                object obj = dt.Compute("count(PageName)", "PageName='" + formname + "'");
                if (Convert.ToInt32(obj) > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        #region Image Convertion To Byte[]


        # region Converting Image to Byte
        public static byte[] ReadImage(string p_postedImageFileName)
        {
            try
            {
                if (System.IO.File.Exists(p_postedImageFileName))
                {
                    bool isValidFileType = true;
                    System.IO.FileInfo file = new System.IO.FileInfo(p_postedImageFileName);
                    if (isValidFileType)
                    {
                        System.IO.FileStream fs = new System.IO.FileStream(p_postedImageFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                        byte[] image = br.ReadBytes((int)fs.Length);
                        br.Close();
                        fs.Close();
                        return image;
                    }
                    return null;

                }
                else
                    return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Converting Byte to Image
        public static string byteArrayToImage(byte[] byteArrayIn, string location, int width, int height)
        {
            try
            {
                System.Drawing.Image newImage;
                string fname = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "_");
                string strFileName = location + "\\" + fname + ".jpg";
                if (byteArrayIn != null)
                {
                    using (System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArrayIn))
                    {
                        newImage = System.Drawing.Image.FromStream(stream);
                        System.Drawing.Bitmap resizedImage = new System.Drawing.Bitmap(width, height);
                        System.Drawing.Graphics.FromImage((System.Drawing.Image)resizedImage).DrawImage(newImage, 0, 0, width, height);
                        resizedImage.Save(strFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return "../Temp/" + fname + ".jpg";
                    }
                }
                else
                {
                    return "No image data found!";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static string byteArrayToImage(byte[] byteArrayIn, string location)
        {
            return byteArrayToImage(byteArrayIn, location, 150, 160);
        }
        #endregion

        #region Deleting Images
        internal static void RemoveTemporaryImages(string location)
        {
            foreach (string file in System.IO.Directory.GetFiles(location))
            {
                DateTime createdate = System.IO.File.GetCreationTime(file);
                if (createdate.Date < DateTime.Now.Date)
                {
                    System.IO.File.Delete(file);
                }
            }
        }
        internal static void RemoveImage(string path)
        {
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }
        #endregion

        #endregion

        internal static void LoadDropDownList_withAll(DropDownList ddlUserGroupType, DataTable dataTable, string p)
        {
            throw new NotImplementedException();
        }

    }

    public static class GetControlId
    {
        public static string GetPostBackControlId(this Page page)
        {
            if (!page.IsPostBack)
                return string.Empty;

            Control control = null;
            // first we will check the "__EVENTTARGET" because if post back made by the controls
            // which used "_doPostBack" function also available in Request.Form collection.
            string controlName = page.Request.Params["__EVENTTARGET"];
            if (!String.IsNullOrEmpty(controlName))
            {
                control = page.FindControl(controlName);
            }
            else
            {
                // if __EVENTTARGET is null, the control is a button type and we need to
                // iterate over the form collection to find it

                // ReSharper disable TooWideLocalVariableScope
                string controlId;
                Control foundControl;
                // ReSharper restore TooWideLocalVariableScope

                foreach (string ctl in page.Request.Form)
                {
                    // handle ImageButton they having an additional "quasi-property" 
                    // in their Id which identifies mouse x and y coordinates
                    if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                    {
                        controlId = ctl.Substring(0, ctl.Length - 2);
                        foundControl = page.FindControl(controlId);
                    }
                    else
                    {
                        foundControl = page.FindControl(ctl);
                    }

                    if (!(foundControl is Button || foundControl is ImageButton)) continue;

                    control = foundControl;
                    break;
                }
            }

            return control == null ? String.Empty : control.ID;
        }
    }
}