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

public partial class Administrator_Administrare_butelii : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Afiseaza_regiune();
        }

    }
    clsRegiune objRegiune = new clsRegiune();
    public void Afiseaza_regiune()
    {
        ddlRegiune.Items.Clear();
        ddlJudet.Items.Clear();
        ddlOras.Items.Clear();
        ddlNumeAgentie.Items.Clear();
        DataSet ds = objRegiune.Afiseaza_regiune();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlRegiune.DataTextField = "Nume_regiune";
            ddlRegiune.DataValueField = "Id_regiune";
            ddlRegiune.DataSource = ds.Tables[0];
            ddlRegiune.DataBind();
            ddlRegiune.Items.Insert(0, "Selecteaza");
        }
    }
    protected void ddlRegiune_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRegiune.SelectedIndex != 0)
        {
            ddlJudet.Enabled = true;
            objRegiune.Id_regiune = Convert.ToInt32(ddlRegiune.SelectedItem.Value);
            Afiseaza_judet();
        }
        else
        {
            ddlJudet.Enabled = false;
            ddlOras.Enabled = false;
            ddlNumeAgentie.Enabled = false;
        }

    }
    public void Afiseaza_oras()
    {
        ddlOras.Items.Clear();
        ddlNumeAgentie.Items.Clear();
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
        ddlNumeAgentie.Items.Clear();
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
            ddlOras.Enabled = true;
            objRegiune.Id_judet = Convert.ToInt32(ddlJudet.SelectedItem.Value);
            Afiseaza_oras();
        }
        else
        {
            ddlOras.Enabled = false;
            ddlNumeAgentie.Enabled = false;
        }
    }
    public void Nume_agentie()
    {
        ddlNumeAgentie.Items.Clear();
        DataSet ds = objRegiune.Afiseaza_nume_agentie();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlNumeAgentie.Items.Clear();
            ddlNumeAgentie.DataTextField = "Nume_agentie";
            ddlNumeAgentie.DataValueField = "Id_utilizator";
            ddlNumeAgentie.DataSource = ds.Tables[0];
            ddlNumeAgentie.DataBind();
            ddlNumeAgentie.Items.Insert(0, "Selecteaza");

        }
    }

    protected void ddlOras_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOras.SelectedIndex != 0)
        {
            ddlNumeAgentie.Enabled = true;
            objRegiune.Id_oras = Convert.ToInt32(ddlOras.SelectedItem.Value);
            Nume_agentie();
        }
        else
        {
            ddlNumeAgentie.Enabled = false;
        }
    }
    clsAdministrator objAdministrator = new clsAdministrator();
    protected void btnInainte_Click(object sender, EventArgs e)
    {
        try
        {
            objAdministrator.Id_oras = Convert.ToInt32(ddlOras.SelectedItem.Value.ToString());
            objAdministrator.Id_utilizator = Convert.ToInt32(ddlNumeAgentie.SelectedItem.Value.ToString());
            objAdministrator.Nume_agentie = ddlNumeAgentie.SelectedItem.Text;
            objAdministrator.Butelii_disponibile = Convert.ToInt32(txtButeliiDisponibile.Text);
            objAdministrator.Butelii_totale = Convert.ToInt32(txtTotalButelii.Text);
            string s = objAdministrator.Adauga_detalii_butelii();
            lblMsg.Text = s;


        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }
    }
    protected void btnAfiseaza_Click(object sender, EventArgs e)
    {
        DataSet ds = objAdministrator.Afiseaza_toate_buteliile();
        if (ds.Tables[0].Rows.Count > 0)
        {
            fs1.Visible = true;
            ViewState["ds"] = ds;
            gvButelii.DataSource = ds.Tables[0];
            gvButelii.DataBind();
        }
        else
        {
            gvButelii.EmptyDataText = "Date nedisponibile";
            gvButelii.DataBind();
        }
    }
    protected void btnActualizare_Click(object sender, EventArgs e)
    {
        try
        {
            objAdministrator.Id_nr = Convert.ToInt32(ViewState["Id_nr"]);
            objAdministrator.Butelii_totale = Convert.ToInt32(txtTotalButelii1.Text);
            objAdministrator.Butelii_disponibile = Convert.ToInt32(txtButeliiDisponibile1.Text);
            string s = objAdministrator.Actualizare_butelii();
            lblMsg1.Text = s;
            btnAfiseaza_Click(sender, e);
        }
        catch (Exception ex)
        {

        }
    }
    protected void gvButelii_RowEditing(object sender, GridViewEditEventArgs e)
    {
        div1.Visible = true;
        int SNO = Convert.ToInt32(gvButelii.Rows[e.NewEditIndex].Cells[0].Text);
        DataRow dr = ((DataSet)ViewState["ds"]).Tables[0].Select("SNO=" + SNO)[0];
        txtNumeAgentie.Text = dr["Nume_agentie"].ToString();
        ViewState["Id_nr"] = dr["Id_nr"].ToString();
        txtButeliiDisponibile1.Text = dr["Butelii_disponibile"].ToString();
        txtTotalButelii1.Text = dr["Butelii_totale"].ToString();

    }
}
