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
public partial class Controale_Utilizatori_Alege_fisier_doc : System.Web.UI.UserControl
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
        
        public static byte[] ReadFile(string PostedNume_fisier, string[] filetype)
        {
            bool isAllowedFileType = false;
            try
            {
                FileInfo file = new FileInfo(PostedNume_fisier);

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
                    

                    FileStream fs = new FileStream(PostedNume_fisier, FileMode.Open, FileAccess.Read);

                    

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
                throw new ArgumentException("Fisier neacceptat pentru incarcare" + ex);
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

        public static string LoadImage(byte[] photoByte, string Nume_fisier)
        {
            string strNume_fisier = null;
            if (photoByte != null && photoByte.Length > 1)
            {
                System.Drawing.Image newImage;

           
                strNume_fisier = UIUtilities.GetTempFolderName() + Nume_fisier;    

               
                using (MemoryStream stream = new MemoryStream(photoByte))
                {
                    newImage = System.Drawing.Image.FromStream(stream);
                  
                    newImage.Save(strNume_fisier);
                }
            }
            return strNume_fisier;
        }
        #endregion



    }
    #endregion

    #region for btn Show event
    protected void btnAfisImag_Click(object sender, EventArgs e)
    {
        Session["Continut_fisier"] = null;
        Session["Nume_fisier"] = null;
        HttpPostedFile postFile = this.Upload1.PostedFile;
        string strNume_fisier = this.Upload1.FileName;
        try
        {
            if (this.Upload1.PostedFile != null)
            {

               
                if (string.IsNullOrEmpty(postFile.FileName))
                    lblMesaj.Text = "Selecteaza un fisier pentru a fi incarcat";
                else
                {
                  
                    FileData = UIUtilities.ReadFile(postFile.FileName, new string[] { ".doc", ".pdf", ".xl", ".xml", ".txt", ".ppt" });
                    if (FileData == null)
                    {
                        lblMesaj.Text = "Formatele de fisiere acceptate sunt: doc, pdf, xl, xml, txt, ppt";
                    }
                    else
                    {
                        if (Session["Nume_fisier"] == null)
                            Session.Add("Nume_fisier", strNume_fisier);
                        else
                            Session["Nume_fisier"] = strNume_fisier;
                        if (Session["Continut_fisier"] == null)
                            Session.Add("Continut_fisier", FileData);
                        else
                            Session["Continut_fisier"] = FileData;
                        lblMesaj.Text = "Fisier incarcat";
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
