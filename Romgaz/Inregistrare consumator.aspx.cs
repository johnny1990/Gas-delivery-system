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

public partial class Inregistrare_consumator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Afiseaza_regiune();
            Afiseaza_conexiune();
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
    clsUtilizator objUtilizator = new clsUtilizator();
    protected void btnConfirmat_Click(object sender, EventArgs e)
    {
        try
        {
            objUtilizator.Nume_utilizator = txtNumeUtilizator.Text;
            objUtilizator.Parola = txtParola.Text;
            objUtilizator.Nume = txtNume.Text;
            objUtilizator.Prenume = txtPrenume.Text;
            objUtilizator.Prenume_2 = txtPrenume2.Text;
            objUtilizator.Adresa = txtAdresa.Text;
            objUtilizator.Nr_telefon = txtTelefon.Text;
            objUtilizator.Email = txtEmail.Text;
            objUtilizator.Nume_fisier = Convert.ToString(Session["Nume_fisier"]);
            objUtilizator.Data_nasterii = Convert.ToDateTime(txtDataNasterii.Text);
            objUtilizator.Data_inregistrarii = Convert.ToDateTime(System.DateTime.Now.ToLongDateString().ToString());
            objUtilizator.Regula = "Consumator";
            objUtilizator.Conexiune = Convert.ToInt32(ddlConexiune.SelectedItem.Value);
            objUtilizator.Sex = ddlSex.SelectedItem.Text;
            objUtilizator.Id_regiune = Convert.ToInt32(ddlNumeRegiune.SelectedItem.Value);
            objUtilizator.Id_judet = Convert.ToInt32(ddlJudet.SelectedItem.Value);
            objUtilizator.Id_oras = Convert.ToInt32(ddlOras.SelectedItem.Value);
            objUtilizator.Nume_agentie = ddlNumeAgentie.SelectedItem.Text;
            lblMsg.Text = objUtilizator.Insereaza_inregistrare_utilizator();
            Sterge_date();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void btnAnuleaza_Click(object sender, EventArgs e)
    {
        Sterge_date();
        lblMsg.Text = "";
    }
    void Sterge_date()
    {
        txtNume.Text = "";
        txtPrenume.Text = "";
        txtPrenume2.Text = "";
        txtAdresa.Text = "";
        txtEmail.Text = "";
        txtTelefon.Text = "";
        txtNumeUtilizator.Text = "";
        txtParola.Text = "";
        txtDataNasterii.Text = "";
        ddlJudet.SelectedIndex = 0;
        ddlNumeRegiune.SelectedIndex = 0;
        ddlOras.SelectedIndex = 0;
        AfisImag1.Clearimage();
        ddlNumeAgentie.Visible = false;
        ddlOras.Visible = false;
        lblJudet.Visible = false;
        lblOras.Visible = false;
        lblAgentie.Visible = false;
        ddlJudet.Visible = false;
    }
    public void Afiseaza_regiune()
    {
        ddlNumeRegiune.Items.Clear();
        ddlJudet.Items.Clear();
        ddlOras.Items.Clear();
        ddlNumeAgentie.Items.Clear();
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
            ddlNumeAgentie.Visible = false;
            ddlOras.Visible = false;
            lblJudet.Visible = false;
            lblOras.Visible = false;
            lblAgentie.Visible = false;
            ddlJudet.Visible = false;
        }
    }
    clsRegiune objRegiune = new clsRegiune();

    #region Implementation
    public void Afiseaza_oras()
    {
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
    protected void ddlOras_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOras.SelectedIndex != 0)
        {
            lblAgentie.Visible = true;
            ddlNumeAgentie.Visible = true;
            objRegiune.Id_oras = Convert.ToInt32(ddlOras.SelectedItem.Value);
            NumeAgentie();
        }
    }
    public void NumeAgentie()
    {
        DataSet ds = objRegiune.Afiseaza_nume_agentie();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlNumeAgentie.Items.Clear();
            ddlNumeAgentie.DataTextField = "Nume_agentie";
            ddlNumeAgentie.DataValueField = "Nume_agentie";
            ddlNumeAgentie.DataSource = ds.Tables[0];
            ddlNumeAgentie.DataBind();
            ddlNumeAgentie.Items.Insert(0, "Selecteaza");

        }
    }
    clsAdministrator objAdministrator = new clsAdministrator();
    public void Afiseaza_conexiune()
    {
        DataSet ds = objAdministrator.Afiseaza_tip_conexiune();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlConexiune.DataTextField = "Nume_conexiune";
            ddlConexiune.DataValueField = "Id_tip_conexiune";
            ddlConexiune.DataSource = ds.Tables[0];
            ddlConexiune.DataBind();
            ddlConexiune.Items.Insert(0, "Selecteaza");
        }
    }
    #endregion

}
