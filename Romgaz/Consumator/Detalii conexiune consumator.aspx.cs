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

public partial class Consumator_Detalii_conexiune_consumator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Afiseaza_detalii_conexiune();
        }

    }
    clsDistribuitor objDistribuitor = new clsDistribuitor();
    public void Afiseaza_detalii_conexiune()
    {
        objDistribuitor.Id_utilizator = Convert.ToInt32(Session["Id_consumator"]);
        DataSet ds = objDistribuitor.Afiseaza_detalii_conexiune_de_catre_utilizator();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            lblNrConsumator.Text = dr["Nr_consumator"].ToString();
            lblNumeConsumator.Text = dr["Nume_consumator"].ToString();
            lblNumeConexiune.Text = dr["Nume_conexiune"].ToString();
            lblData.Text = dr["Data_aplicare"].ToString();
            lblDataEmitere.Text = dr["IssuedDate"].ToString();
            lblNumeAgentie.Text = dr["Nume_agentie"].ToString();
            lblAdresa.Text = dr["Adresa"].ToString();
            Session["Id_agent"] = dr["Id_agent"].ToString();
        }
    }
    protected void btnRezerva_Click(object sender, EventArgs e)
    {
        try
        {
            objDistribuitor.Id_utilizator = Convert.ToInt32(lblNrConsumator.Text);
            objDistribuitor.Nume_agentie = lblNumeAgentie.Text;
            objDistribuitor.Id_agent = Convert.ToInt32(Session["Id_agent"]);
            string s = objDistribuitor.Rezervare_gaz_utilizator();
            lblMsg.Text = s;

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }
    }

}
