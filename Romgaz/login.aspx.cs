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

public partial class Login : System.Web.UI.Page
{
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";

        string url = Request.Url.ToString();
        string[] split = url.Split('/');
        for (int i = 0; i < split.Length; i++)
        {
            if (split[i] == "Administrator")
            {
                lblAutentificare.Text = "Autentificare administrator";
            }
            else if (split[i] == "Distribuitor")
            {
                lblAutentificare.Text = "Autentificare distribuitor";
            }
            else if (split[i] == "Consumator")
            {
                lblAutentificare.Text = "Autentificare consumator";
            }

        }
        if (Session["Nume_utilizator"] != null)
        {
            FormsAuthentication.SignOut();
        }

    }
    protected void ImgBtnEmail_Click(object sender, EventArgs e)
    {
        string str1 = null;
        string[] UserName = null;
        try
        {
            if (txtnume_utilizator.Text.Contains("@"))
            {
                string str = txtnume_utilizator.Text;
                UserName = str.Split('@');
                clsAutentificare.Nume_utilizator = UserName[0].ToString();
                str1 = UserName[0].ToString();
            }
            else
            {
                clsAutentificare.Nume_utilizator = txtnume_utilizator.Text.Trim();
                str1 = txtnume_utilizator.Text.Trim();
                Session["Nume"] = str1;
            }
            clsAutentificare.Parola = txtparola.Text.Trim();
            int id;
            string Role = clsAutentificare.Afiseaza_autentificare_utilizator(out id);

            if (Role == "Neutilizator")
                lblMsg.Text = "Numele de utilizator si parola nu se potrivesc. Incearca din nou.";
            else
            {
                Session["Tip_utilizator"] = Role;

                Session["Id_utilizator"] = id;

                if (Role.ToLower() == "administrator")
                {
                    Session["Id_utilizator"] = clsAutentificare.Afiseaza_id_administrator_dupa_id_utilizator(Convert.ToInt32(Session["Id_utilizator"]));
                    Session["Nume_utilizator"] = str1;

                    FormsAuthentication.RedirectFromLoginPage("Administrator", false);
                }
                else if (Role.ToLower() == "distribuitor")
                {
                    Session["Id_distribuitor"] = clsAutentificare.Afiseaza_distribuitor_dupa_Id_utilizator(Convert.ToInt32(Session["Id_utilizator"]));
                   
                    Session["Nume_utilizator"] = str1;
                    FormsAuthentication.RedirectFromLoginPage("Distribuitor", false);
                }
                else if (Role.ToLower() == "consumator")
                {

                    Session["Id_consumator"] = clsAutentificare.Afiseaza_id_consumator_dupa_id_utilizator(Convert.ToInt32(Session["Id_utilizator"]));
                 
                    Session["Nume_utilizator"] = str1;
                    FormsAuthentication.RedirectFromLoginPage(Role, false);
                }

            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    #endregion

    #region Implementation
    public static AjaxControlToolkit.Slide[] GetSlides(string contextKey)
    {
        AjaxControlToolkit.Slide[] slides = new AjaxControlToolkit.Slide[8];
        slides[0] = new AjaxControlToolkit.Slide("Imagini/gaz1.jpg", "", "Imagine 1");
        slides[1] = new AjaxControlToolkit.Slide("Imagini/gaz2.jpg", "", "Imagine 2");
        slides[2] = new AjaxControlToolkit.Slide("Imagini/gaz3.jpg", "", "Imagine 3");
        slides[3] = new AjaxControlToolkit.Slide("Imagini/gaz4.jpg", "", "Imagine 4");
        slides[4] = new AjaxControlToolkit.Slide("Imagini/gaz5.jpg", "", "Imagine 5");
        slides[5] = new AjaxControlToolkit.Slide("Imagini/gaz6.jpg", "", "Imagine 6");
        slides[6] = new AjaxControlToolkit.Slide("Imagini/gaz7.jpg", "", "Imagine 7");
        slides[7] = new AjaxControlToolkit.Slide("Imagini/gaz8.jpg", "", "Imagine 8");

        return (slides); ;
    }
    #endregion
}
