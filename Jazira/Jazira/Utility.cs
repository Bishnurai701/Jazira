using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xaml;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.WebControls.WebParts;
using System.Text;

namespace Jazira
{
    public class Utility
    {
        //added by Bishnu Khaling for the case of image
        public static string logoImage = "../img/logo.jpg";
        public static string[] AcceptedImageFileTypes = new string[] { ".jpg", ".jpeg", ".png",".gif" };
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
        public static string prepareDialogMsg(string str_msg)
        {
            return str_msg.Replace(" ", "&nbsp;");
        }
        //Security user permission
        public static void LoadDay(DropDownList ddl)
        {
            ddl.Items.Clear();
            for (int i = 0; i <= 32; i++)
            {

                if (i == 0)
                { ddl.Items.Add(new ListItem("Day", i.ToString())); ddl.SelectedValue = i.ToString(); }
                else
                { ddl.Items.Add(new ListItem(i.ToString(), i.ToString())); }
            }
        }
        public static void LoadMonth(DropDownList ddl)
        {
            ddl.Items.Clear();
            for (int i = 0; i <= 12; i++)
            {
                if (i == 0)
                { ddl.Items.Add(new ListItem("Month", i.ToString())); ddl.SelectedValue = i.ToString(); }
                else
                { ddl.Items.Add(new ListItem(i.ToString(), i.ToString())); }
            }
        }
        public static void LoadYear(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("Year", "0"));
            for (int i = 1970; i <= 2090; i++)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

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


        # region Converting Image to Byte[]
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
                return ex.Message + " " + ex.Source;
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

        //Resize Image And Save
        public static void ResizeSaveImage(byte[] imageByte, string path, int width, int height)
        {
            try
            {
                MemoryStream mstream = new MemoryStream();
                mstream.Write(imageByte, 0, imageByte.Length);
                Stream stream = mstream;
                var image = System.Drawing.Image.FromStream(stream, true, true);

                var newImage = new System.Drawing.Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                using (System.Drawing.Graphics graphics = Graphics.FromImage(newImage))
                {
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.DrawImage(image, 0, 0, width, height);
                }
                newImage.Save(path);
            }
            catch (Exception ex)
            { return; }
        }
        //Send Mail
        //public static bool SendMail(string to, string from, string subject, string body, out string message)
        //{
        //    try
        //    {
        //         Initialize WebMail helper
        //        System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
        //        mail.To.Add(to);
        //        mail.From = new MailAddress(from);
        //        mail.Subject = subject;
        //        mail.IsBodyHtml = true;
        //        mail.Body += body;
        //        SmtpClient client = new SmtpClient();
        //        client.EnableSsl = true;
        //        client.Send(mail);
        //        message = "Message Send Successfully!";
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        message = "Error occured while sending message.";
        //        return false;
        //    }
        //}

        //File Compare Code

    }

    public class NepaliDateTime
    {
        #region DateTimeMembers
        int day, month, year;
        public static string filepath;
        #endregion


        #region Properties
        public int Day
        {
            get { return day; }
            private set { day = value; }
        }

        public int Month
        {
            get { return month; }
            private set { month = value; }
        }

        public int Year
        {
            get { return year; }
            private set { year = value; }
        }

        #endregion

        public override string ToString()
        {
            return Year + "-" + Month + "-" + Day;
        }

        #region Constructors
        public NepaliDateTime()
        {
            day = 0;
            month = 0;
            year = 0;
        }

        public NepaliDateTime(DateTime engdate)
        {
            NepaliDateTime ndt = NepaliDateTime.ConvertToNepali(engdate);

            Day = ndt.Day;
            Month = ndt.Month;
            Year = ndt.Year;
        }

        public NepaliDateTime(int yy, int mm, int dd)
        {
            year = yy;
            month = mm;
            day = dd;

        }

        #endregion

        #region DateConverters Nepali->English English->Nepali
        public static NepaliDateTime ConvertToNepali(DateTime engdate)
        {
            NepaliDateTime nepali;
            DateTime[] dates;
            TimeSpan ts = new TimeSpan();
            int day, month, year;

            year = engdate.Year + 56;
            month = engdate.Month + 8;
            if (month > 12)
            {
                month -= 12;
                year++;
            }
            dates = GetMonth(year, month);
            ts = dates[1].Subtract(dates[0]);
            ts = ts.Add(new TimeSpan(1, 0, 0, 0));
            day = 1;
            for (; dates[0] != engdate; dates[0] = dates[0].AddDays(1))
            {
                day++;
            }
            if (day > ts.Days)
            {
                day -= ts.Days;
                month++;
                if (month > 12)
                {
                    month -= 12;
                    year++;
                }
            }

            nepali = new NepaliDateTime(year, month, day);
            return nepali;
        }

        public static DateTime ConvertToEnglish(NepaliDateTime nepalidate)
        {
            DateTime english = new DateTime();
            DateTime[] dates;
            int day, year, month, ctr;

            dates = GetMonth(nepalidate.Year, nepalidate.Month);
            year = dates[0].Year;
            month = dates[0].Month;
            day = dates[0].Day;
            TimeSpan diff = dates[1].Subtract(dates[0]);
            diff = diff.Add(new TimeSpan(1, 0, 0, 0));
            if (nepalidate.day > diff.Days)
                throw new Exception("दिएको मिति मिलेन।");
            english = new DateTime(dates[0].Year, dates[0].Month, dates[0].Day);

            for (ctr = 1; ctr < nepalidate.Day; ctr++)
            {
                english = english.AddDays(1);
            }
            return english;
        }

        public static DateTime[] GetMonth(int yy, int mm)
        {
            string s;
            DateTime[] dates = new DateTime[2];
            int year = yy;
            year = year - year % 10;
            string filename = filepath + year.ToString();
            filename += ".xml";
            if (!System.IO.File.Exists(filename))
            {
                throw new Exception("Date must be between 2070(BS) To 2090(BS).");
            }
            //XmlReader xr = XmlReader.Create(filename);

            //while (xr.Read())
            //{
            //    if (xr.NodeType == XmlNodeType.Element && xr.Name == "Year")
            //    {
            //        s = xr.GetAttribute("yearid");
            //        if (Convert.ToInt32(s) == yy)
            //        {
            //            while (xr.Read())
            //            {
            //                if (xr.NodeType == XmlNodeType.Element && xr.Name == "Month")
            //                {
            //                    s = xr.GetAttribute("id");
            //                    if (Convert.ToInt32(s) == ((int)mm))
            //                    {
            //                        while (xr.Read())
            //                        {
            //                            if (xr.NodeType == XmlNodeType.Element && xr.Name == "StartDate")
            //                            {
            //                                xr.Read();
            //                                dates[0] = Convert.ToDateTime(xr.Value);
            //                            }
            //                            if (xr.NodeType == XmlNodeType.Element && xr.Name == "EndDate")
            //                            {
            //                                xr.Read();
            //                                dates[1] = Convert.ToDateTime(xr.Value);
            //                                break;
            //                            }
            //                        }
            //                        xr.Close();
            //                        return dates;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //xr.Close();
            return null;
        }
        #endregion

    }


    ///*'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    /// This is the work of Andreas Knudsen (andreas.knudsen [ at ] gmail.com)
    /// Anyone may use this work freely as it stands, or change it to suit their needs
    /// on one condition: All use is on your own risk. It works for me, but I will not be
    /// liable for any losses incurred by the use of this work. 
    /// 
    /// If you would hold me responsible, you are not to use this work.
    /// ************************************************************************************
    /// 
    /// In order to be truly useful, customizations are needed on lines 120 and 130
    /// (search for CUSTOMIZE HERE! 
    /// 
    /// ************************************************************************************

    /// <summary> 
    /// Base class for web part development. 
    /// All web parts should inherit from this class. 
    /// Exceptions thrown from web parts inheriting from this base 
    /// will not crash the Page the web part is on, but rather do one of two things:
    /// 
    /// 1)If compiled in debug mode: Render the stacktrace of the exception inline in the web page
    /// 2)If compiled in release mode: Render a friendly error message inline in the web page.
    /// 
    /// This behaviour can be overridden by inheritors by overriding the method HandleException
    ///  
    /// HOW THIS WORKS:
    /// -------
    /// In order to wrap each framework call with exception handling, 
    /// we have a two-tiered approach in which 
    /// 1) the first tier (ExceptionHandlingWebPartBase) overrides and seals methods, 
    /// 2) then applies try/catch to a new set of methods, forwarding method parameters
    /// 3) these new methods are overridden in the second tier (BaseWebPart)
    /// 4) where they are sealed and a call is made to new virtual methods that are named the 
    /// same as the framework methods.
    /// 5) These methods (now with a catch-block around them) are then overridden as needed in a 
    /// regular web part that inherits from BaseWebPart. The exception handling is thus 
    /// transparent to the inheritor.
    /// </summary>
    public abstract class BaseWebPart : ExceptionHandlingWebPartBase
    {
        #region temp methods for method piping (overrides and seals methods from ExceptionHandlingWebPartBase)
        /*
         * These methods re part of the plumbing necessary to give inheritors
         * the expected interface.
         */
        public override sealed void RenderWebPart(HtmlTextWriter writer)
        {
            Render(writer);
        }

        public override sealed void CreateWebPartChildControls()
        {
            CreateChildControls();
        }

        public override sealed void InitWebPart(EventArgs e)
        {
            OnInit(e);
        }

        public sealed override void PreRenderWebPart(EventArgs e)
        {
            OnPreRender(e);
        }

        public sealed override void LoadWebPart(EventArgs e)
        {
            OnLoad(e);
        }
        #endregion
        #region Methods in which exceptions are now handled.
        protected new virtual void Render(HtmlTextWriter writer)
        {
            base.RenderWebPart(writer);
        }
        protected new virtual void CreateChildControls()
        {
            base.CreateWebPartChildControls();
        }

        protected new virtual void OnInit(EventArgs e)
        {
            base.InitWebPart(e);
        }

        protected new virtual void OnLoad(EventArgs e)
        {
            base.LoadWebPart(e);
        }

        protected new virtual void OnPreRender(EventArgs e)
        {
            base.PreRenderWebPart(e);
        }
        #endregion
    }


    public abstract class ExceptionHandlingWebPartBase : WebPart
    {

        #region Exception handling section
        private StringBuilder _errorOutput;
        private bool _abortProcessing;
        public virtual bool AbortProcessing
        {
            get { return _abortProcessing; }
            set { _abortProcessing = value; }
        }

        public virtual void HandleException(Exception e, HtmlTextWriter writer)
        {
#if !DEBUG
     // CUSTOMIZE HERE! 
      writer.Write("TODO: Insert helpful error message here");
#else
            writer.Write(e.Message + "<br/>" + e.StackTrace);
#endif

        }

        public void ExceptionHappened(Exception ex)
        {
            AbortProcessing = true;
            //CUSTOMIZE HERE!
            //TODO: use own logging framework here:
            //Logger.Log(Severity.Error, ex.Message + " " + ex.StackTrace);

            HandleException(ex, new HtmlTextWriter(new StringWriter(_errorOutput)));
        }

        #endregion

        #region Override framework methods for method piping
        protected override sealed void CreateChildControls()
        {

            if (!AbortProcessing)
            {
                try
                {
                    CreateWebPartChildControls();
                }
                catch (Exception e)
                {
                    ExceptionHappened(e);
                }
            }
        }

        protected override sealed void OnInit(EventArgs e)
        {
            AbortProcessing = false;

            _errorOutput = new StringBuilder();

            try
            {
                InitWebPart(e);
            }
            catch (Exception ex)
            {
                ExceptionHappened(ex);
            }
        }
        protected override sealed void Render(HtmlTextWriter writer)
        {
            StringBuilder tempOutput = new StringBuilder();
            if (!AbortProcessing)
            {
                HtmlTextWriter tempWriter = new HtmlTextWriter(new StringWriter(tempOutput));

                try
                {
                    RenderWebPart(tempWriter);
                }
                catch (Exception ex)
                {
                    ExceptionHappened(ex);
                }
            }
            if (AbortProcessing)
            {
                writer.Write(_errorOutput.ToString());
            }
            else
            {
                writer.Write(tempOutput.ToString());
            }
        }
        protected override sealed void OnLoad(EventArgs e)
        {
            if (!AbortProcessing)
            {
                try
                {
                    LoadWebPart(e);
                }
                catch (Exception ex)
                {
                    ExceptionHappened(ex);
                }


            }
        }
        protected override sealed void OnPreRender(EventArgs e)
        {
            if (!AbortProcessing)
            {
                try
                {
                    PreRenderWebPart(e);
                }
                catch (Exception ex)
                {
                    ExceptionHappened(ex);
                }

            }
        }
        #endregion

        #region Temp methods for method piping (will be overridden and sealed in subclass)
        public virtual void RenderWebPart(HtmlTextWriter writer)
        {
            EnsureChildControls();
            base.Render(writer);
        }
        public virtual void CreateWebPartChildControls()
        {
            base.CreateChildControls();
        }
        public virtual void InitWebPart(EventArgs e)
        {
            base.OnInit(e);
        }
        public virtual void LoadWebPart(EventArgs e)
        {
            base.OnLoad(e);
        }
        public virtual void PreRenderWebPart(EventArgs e)
        {
            base.OnPreRender(e);
        }
        #endregion
    }
}