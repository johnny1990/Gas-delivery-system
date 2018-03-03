using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Data.Common;

public partial class Alege_fisier_pdf : System.Web.UI.UserControl
{
    #region for privte fields
    string strImageType = string.Empty;
    byte[] FileData = null;

    #endregion

    #region  for page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
        lblMesaj.Text = "";
    }
    #endregion

    #region for public utility class
    public class UIUtilities
    {

        #region ReadFile to Convert Binary
        /// <summary>
        /// Get the Uploaded file and convert to binary for storing in Db
        /// </summary>
        /// <param name="PostedFileName">Uploaded file</param>
        /// <returns>Byte[] object</returns>
        public static byte[] ReadFile(string PostedFileName, string[] filetype)
        {
            bool isAllowedFileType = false;
            try
            {
                FileInfo file = new FileInfo(PostedFileName);

                foreach (string strExtensionType in filetype)
                {
                    if (strExtensionType.ToUpper() == file.Extension.ToUpper())
                    {
                        isAllowedFileType = true;
                        break;
                    }
                }
                if (isAllowedFileType)
                {
                    

                    FileStream fs = new FileStream(PostedFileName, FileMode.Open, FileAccess.Read);

                   

                    BinaryReader br = new BinaryReader(fs);

                   

                    byte[] filecontent = br.ReadBytes((int)fs.Length);

                 

                    br.Close();

                   

                    fs.Close();

                    return filecontent;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Fisierul nu se poate incarca" + ex);
            }

        }
        #endregion

        #region GetTempFolderName
        
        public static string GetTempFolderName()
        {
            string strTempFolderName = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) + @"\";

            if (Directory.Exists(strTempFolderName))
            {
                return strTempFolderName;
            }
            else
            {
                Directory.CreateDirectory(strTempFolderName);
                return strTempFolderName;
            }
        }
        #endregion
        #region Code For Converting Varformat to Image format

        public static string LoadImage(byte[] photoByte, string FileName)
        {
            string strFileName = null;
            if (photoByte != null && photoByte.Length > 1)
            {
                System.Drawing.Image newImage;

                
                strFileName = UIUtilities.GetTempFolderName() + FileName;    

                
                using (MemoryStream stream = new MemoryStream(photoByte))
                {
                    newImage = System.Drawing.Image.FromStream(stream);
                  
                    newImage.Save(strFileName);
                }
            }
            return strFileName;
        }
        #endregion



    }
    #endregion

    #region for btn Show event
    protected void btnAfisImag_Click(object sender, EventArgs e)
    {
        Session["Nume_fisier_pdf"] = null;
        Session["Nume_fisier_pdf"] = null;
        HttpPostedFile postFile = this.Upload1.PostedFile;
        string strFileName = this.Upload1.FileName;
        try
        {
            if (this.Upload1.PostedFile != null)
            {

                
                if (string.IsNullOrEmpty(postFile.FileName))
                    lblMesaj.Text = "Selecteaza un fisier care sa fie atasat";
                else
                {
                    
                    FileData = UIUtilities.ReadFile(postFile.FileName, new string[] { ".pdf" });
                    if (FileData == null)
                    {
                        lblMesaj.Text = " Numai fisiere pdf permise.";
                    }
                    else
                    {
                       
                        if (Session["Nume_fisier_pdf"] == null)
                            Session.Add("Nume_fisier_pdf", strFileName);
                        else
                            Session["Nume_fisier_pdf"] = strFileName;
                        if (Session["Nume_fisier_pdf"] == null)
                            Session.Add("Continut_fisier_pdf", FileData);
                        else
                            Session["Continut_fisier_pdf"] = FileData;
                        lblMesaj.Text = "Fisier atasat";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMesaj.Text = ex.Message;
        }
    }
    #endregion
}
