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

public partial class Consumator_Transfer_conexiune : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Afiseaza_regiune();
            Afiseaza_conexiune_utilizator();
        }
    }


    clsDistribuitor objDistribuitor = new clsDistribuitor();
    public void ShowConnectionDetails()
    {
        objDistribuitor.Id_utilizator = Convert.ToInt32(Session["Id_consumator"]);
        DataSet ds = objDistribuitor.Afiseaza_detalii_conexiune_de_catre_utilizator();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            Session["Id_agent"] = dr["Id_agent"].ToString();
        }
    }




    clsRegiune objRegiune = new clsRegiune(); 
    public void Afiseaza_regiune()
    {
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
            ddlNumeAgentie.Items.Clear();
            ddlOras.Items.Clear();
            ddlJudet.Items.Clear();
            ddlNumeAgentie.Enabled = false;   
            ddlOras.Enabled=false;
            ddlJudet.Enabled  = false;
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
    protected void ddlOras_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOras.SelectedIndex != 0)
        {
            ddlNumeAgentie.Enabled = true;
            objRegiune.Id_oras = Convert.ToInt32(ddlOras.SelectedItem.Value);
            NumeAgentie();
        }
        else
        {
            ddlNumeAgentie.Enabled = false;
        }
    }
    public void NumeAgentie()
    {
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
    clsUtilizator objUtilizator = new clsUtilizator();
 
    protected void btnTrimite_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlOras.SelectedIndex != 0)
            {
                objUtilizator.Id_utilizator =Convert.ToInt32(Session["Id_consumator"]);
                objUtilizator.Id_oras= Convert.ToInt32(ViewState["Catre_orasul"] );
                objUtilizator.Id_agent =Convert.ToInt32(Session["Id_Agent"]);
                objUtilizator.Nume_agentie = txtDeLaAgentia.Text; 
                objUtilizator.Catre_nume_agentie=  ddlNumeAgentie.SelectedItem.Text;
                objUtilizator.Catre_id_agent = Convert.ToInt32(ddlNumeAgentie.SelectedItem.Value);
                objUtilizator.Catre_oras = Convert.ToInt32(ddlOras.SelectedItem.Value);    
                string s=objUtilizator.Insereaza_cerere_transfer();
                lblMsg.Text = s; 
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();    
        }
    }
    public void Afiseaza_conexiune_utilizator()
    {
        objUtilizator.Id_utilizator =Convert.ToInt32( Session["Id_consumator"]);
        DataSet ds= objUtilizator.Afiseaza_conexiune_utilizatori();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            txtNrConsumator.Text = dr["Nr_consumator"].ToString();
            txtDeLaAgentia.Text = dr["Nume_agentie"].ToString();
            txtCatreOras.Text = dr["Nume_oras"].ToString();
            ViewState["Catre_orasul"] = dr["Oras"].ToString();  
        }
    }

    }
