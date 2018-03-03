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

public partial class Administrator_Inregistrare_agentie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Afiseaza_regiune();
            Afiseaza_tip_conexiune();
        }
    }
    clsRegiune objRegiune = new clsRegiune();
    clsUtilizator objUtilizator = new clsUtilizator();
    protected void btnInregistreaza_Click(object sender, EventArgs e)
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
            objUtilizator.Nume_fisier = Convert.ToString(Session["Nume fisier"]);
            objUtilizator.Data_nasterii = Convert.ToDateTime(txtDataNasterii.Text);
            objUtilizator.Data_inregistrarii = Convert.ToDateTime(System.DateTime.Now.ToLongDateString().ToString());
            objUtilizator.Regula = ddlRegula.SelectedItem.Text;
            objUtilizator.Sex = ddlSex.SelectedItem.Text;
            objUtilizator.Conexiune = Convert.ToInt32(ddlTipConexiune.SelectedItem.Value);
            objUtilizator.Id_regiune = Convert.ToInt32(ddlNumeRegiune.SelectedItem.Value);
            objUtilizator.Id_judet = Convert.ToInt32(ddlJudet.SelectedItem.Value);
            objUtilizator.Id_oras = Convert.ToInt32(ddlOras.SelectedItem.Value);
            objUtilizator.Nume_agentie = txtNumeAgentie.Text;
            lblMesaj.Text = objUtilizator.Insereaza_inregistrare_utilizator();
            ClearData();
        }
        catch (Exception ex)
        {
            lblMesaj.Text = ex.Message;
        }

    }

    void ClearData()
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

    }
    protected void btnAnuleaza_Click(object sender, EventArgs e)
    {
        ClearData();
    }
    public void Afiseaza_regiune()
    {
        ddlNumeRegiune.Items.Clear();
        ddlJudet.Items.Clear();
        ddlOras.Items.Clear();
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
    public void Afiseaza_judet()
    {
        ddlJudet.Items.Clear();
        ddlOras.Items.Clear();
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
    public void Afiseaza_oras()
    {
        ddlOras.Items.Clear();
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

    clsAdministrator objAdministrator = new clsAdministrator();
    public void Afiseaza_tip_conexiune()
    {
        DataSet ds = objAdministrator.Afiseaza_tip_conexiune();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlTipConexiune.DataTextField = "Nume_conexiune";
            ddlTipConexiune.DataValueField = "Id_tip_conexiune";
            ddlTipConexiune.DataSource = ds;
            ddlTipConexiune.DataBind();
            ddlTipConexiune.Items.Insert(0, "selecteaza");
        }
    }
    protected void ddlNumeRegiune_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNumeRegiune.SelectedIndex != 0)
        {
            objRegiune.Id_regiune = Convert.ToInt32(ddlNumeRegiune.SelectedItem.Value);
            Afiseaza_judet();

        }
        else
        {
            lblMesaj.Text = "Selecteaza nume regiune";
        }
    }
    protected void ddlJudet_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJudet.SelectedIndex != 0)
        {
            objRegiune.Id_judet = Convert.ToInt32(ddlJudet.SelectedItem.Value);
            Afiseaza_oras();
        }
        else
        {
            lblMesaj.Text = "Selecteaza nume judet";
        }
    }
}
