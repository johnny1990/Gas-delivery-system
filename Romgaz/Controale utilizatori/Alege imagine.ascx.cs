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
public partial class Alege_imagine : System.Web.UI.UserControl
{
    #region for privte fields
    string strImageType = string.Empty;
    byte[] imageData = null;
    private static byte[] NoImage;

   
    private byte[] _strLaodImageByte;
    private string _strLoadFileName;
    private string _strDefaultImageUrl;

   

    #endregion


    #region properties for private fields

    public string DefaultImageUrl
    {
        get { return _strDefaultImageUrl; }
        set { _strDefaultImageUrl = value; }
    }
    
    public byte[] LaodImageByte
    {
        get { return _strLaodImageByte; }
        set { _strLaodImageByte = value; }
    }
    public string LoadFileName
    {
        get { return _strLoadFileName; }
        set { _strLoadFileName = value; }
    }
    #endregion

    public void loadimage()
    {
        try
        {
            if (!string.IsNullOrEmpty(_strLoadFileName) && _strLaodImageByte != null)
            {
                Session["Nume_fisier"] = _strLoadFileName;
                Session["Imagine"] = _strLaodImageByte;
                imgMyPhoto.Attributes.Add("Src", UIUtilities.LoadImage(_strLaodImageByte, _strLoadFileName));
            }
        }
        catch (Exception ex)
        { 
        
        }
    }

    public void BindImage(string FileName, byte[] FileContent)
    {
        try
        {
            Session["Nume_fisier"] = FileName;
            Session["Imagine"] = FileContent;
            imgMyPhoto.Attributes.Clear();
            imgMyPhoto.Attributes.Add("Src", UIUtilities.LoadImage(FileContent, FileName));
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public void Clearimage()
    {
        try
        { 
                imgMyPhoto.ImageUrl = this._strDefaultImageUrl;
                Session["Imagine"] = UIUtilities.ReadImageFile(Server.MapPath(this._strDefaultImageUrl), new string[] { ".jpg", ".gif" });
                Session["Nume_fisier"] = "Nu este imagine.jpg";
                imgMyPhoto.Attributes.Add("Src", Server.MapPath(this._strDefaultImageUrl));
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    #region  for page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(_strLoadFileName) && _strLaodImageByte != null)
            {
                Session["Nume_fisier"] = _strLoadFileName;
                Session["Imagine"] = _strLaodImageByte;
                imgMyPhoto.Attributes.Add("Src", UIUtilities.LoadImage(_strLaodImageByte, _strLoadFileName));
            }
            else
            {
                imgMyPhoto.ImageUrl = this._strDefaultImageUrl;
                Session["Imagine"] = UIUtilities.ReadImageFile(Server.MapPath(this._strDefaultImageUrl), new string[] { ".jpg", ".gif" });
                Session["Nume_fisier"] = "Nu este imagine.jpg";
            }
        }
        lblMesaj.Text = "";
    }
    #endregion

    #region for public utility class
    public  class UIUtilities
    {
        static DbProviderFactory ProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
        static DbConnection con = null;

        #region ReadImageFile to Convert Binary
        
        public static byte[] ReadImageFile(string PostedFileName, string[] filetype)
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

                   

                    byte[] image = br.ReadBytes((int)fs.Length);

                  

                    br.Close();

                   

                    fs.Close();

                    return image;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Fisier nesuportat ca imagine" + ex);
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
            string strFileName=null;
            if (photoByte != null && photoByte.Length > 1)
            {
                System.Drawing.Image newImage;

                
                 strFileName = UIUtilities.GetTempFolderName() + "Alege_imagine" + FileName;    

                 
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
        HttpPostedFile postFile = this.Upload1.PostedFile;
        string strFileName = this.Upload1.FileName;
        try
        {
            if (this.Upload1.PostedFile != null)
            {
               
                
                if (string.IsNullOrEmpty(postFile.FileName))
                    lblMesaj.Text = "Selecteaza o imagine pentru a fi vizualizata";
                else
                {
                    
                    imageData = UIUtilities.ReadImageFile(postFile.FileName, new string[] { ".gif", ".jpg", ".bmp", ".jpeg" });
                    if (imageData == null)
                    {
                        lblMesaj.Text = "Seelecteaza un fisier cu formatul gif, jpg or bmp.";
                        imgMyPhoto.Attributes.Add("Src", "");
                    }
                    else
                    {
                        
                        Session["Nume_fisier"] = strFileName;
                        if (Session["Imagine"] == null)
                            Session.Add("Imagine", imageData);
                        else
                            Session["Imagine"] = imageData;
                        imgMyPhoto.Attributes.Add("Src",Upload1.PostedFile.FileName);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMesaj.Text =ex.Message ;
        }
    }
    #endregion

    
}
