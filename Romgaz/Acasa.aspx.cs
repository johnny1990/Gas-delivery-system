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

public partial class Acasa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        FormsAuthentication.SignOut();
        if (!IsPostBack)
        {
            Afiseaza_regiune();
        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
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
    public void Afiseaza_regiune()
    {
        DataSet ds = objRegiune.Afiseaza_regiune();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlNumeRegiune.DataTextField = "Nume_regiune";
            ddlNumeRegiune.DataValueField = "Id_regiune";
            ddlNumeRegiune.DataSource = ds.Tables[0];
            ddlNumeRegiune.DataBind();
            ddlNumeRegiune.Items.Insert(0, "Selecteaza");
        }
    }
    clsRegiune objRegiune = new clsRegiune();
    public void Afiseaza_oras()
    {
        ddlOras.Items.Clear();
        ddlAgentie.Items.Clear();
        DataSet ds = objRegiune.Afiseaza_oras_dupa_id_judet();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlOras.DataTextField = "Nume_oras";
            ddlOras.DataValueField = "Id_oras";
            ddlOras.DataSource = ds.Tables[0];
            ddlOras.DataBind();
            ddlOras.Items.Insert(0, "Selecteaza");
        }
    }
    public void Afiseaza_judet()
    {
        ddlJudet.Items.Clear();
        ddlOras.Items.Clear();
        ddlAgentie.Items.Clear();
        DataSet ds = objRegiune.Afiseaza_judet_dupa_id_regiune();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlJudet.DataTextField = "Nume_judet";
            ddlJudet.DataValueField = "Id_judet";
            ddlJudet.DataSource = ds.Tables[0];
            ddlJudet.DataBind();
            ddlJudet.Items.Insert(0, "Selecteaza");
        }
    }
    protected void ddlNumeRegiune_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNumeRegiune.SelectedIndex != 0)
        {
            lblJudet.Visible = true;
            ddlJudet.Visible = true;
            objRegiune.Id_regiune = Convert.ToInt32(ddlNumeRegiune.SelectedItem.Value);
            Afiseaza_judet();
        }
        else
        {
            ddlAgentie.Visible = false;
            ddlOras.Visible = false;
            lblJudet.Visible = false;
            lblOras.Visible = false;
            lblAgentie.Visible = false;
            ddlJudet.Visible = false;
            gvButelii.Visible = false;
            btnAfiseaza.Enabled = false;
        }
    }
    protected void ddlJudet_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJudet.SelectedIndex != 0)
        {
            ddlOras.Visible = true;
            lblOras.Visible = true;
            objRegiune.Id_judet = Convert.ToInt32(ddlJudet.SelectedItem.Value);
            Afiseaza_oras();
        }
    }
    public void Nume_agentie()
    {
        DataSet ds = objRegiune.Afiseaza_nume_agentie();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlAgentie.Items.Clear();
            ddlAgentie.DataTextField = "Nume_agentie";
            ddlAgentie.DataValueField = "Id_utilizator";
            ddlAgentie.DataSource = ds.Tables[0];
            ddlAgentie.DataBind();
            ddlAgentie.Items.Insert(0, "Selecteaza");

        }
    }
    protected void ddlOras_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOras.SelectedIndex != 0)
        {
            lblAgentie.Visible = true;
            ddlAgentie.Visible = true;
            btnAfiseaza.Enabled = true;
            objRegiune.Id_oras = Convert.ToInt32(ddlOras.SelectedItem.Value);
            Nume_agentie();
        }
        else
        {
            btnAfiseaza.Enabled = false;
        }
    }
    clsAdministrator objAdministrator = new clsAdministrator();
    protected void btnAfiseaza_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlOras.SelectedIndex != 0 && ddlAgentie.SelectedIndex != 0)
            {

                objAdministrator.Id_oras = Convert.ToInt32(ddlOras.SelectedItem.Value);
                objAdministrator.Nume_agentie = ddlAgentie.SelectedItem.Text;
                DataSet ds = objAdministrator.Afiseaza_stare_butelii();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvButelii.Visible = true;
                    gvButelii.DataSource = ds.Tables[0];
                    gvButelii.DataBind();
                }
                else
                {
                    gvButelii.Visible = true;
                    gvButelii.EmptyDataText = "Datele nu sunt disponibile";
                    gvButelii.DataBind();
                }

            }

        }
        catch (Exception ex)
        {

        }
    }
}
