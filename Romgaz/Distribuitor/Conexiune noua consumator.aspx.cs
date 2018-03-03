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

public partial class Distribuitor_Conexiune_noua_consumator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Afiseaza_conexiuni_noi();
        }
    }
    clsDistribuitor objDistribuitor = new clsDistribuitor();
    public void Afiseaza_conexiuni_noi()
    {
        try
        {
            objDistribuitor.Id_utilizator = Convert.ToInt32(Session["Id_distribuitor"]);
            DataSet ds = objDistribuitor.Afiseaza_cereri_conexiune_consumatori();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["ds"] = ds;
                gvCereriConsumatori.DataSource = ds.Tables[0];
                gvCereriConsumatori.DataBind();

            }
            else
            {
                gvCereriConsumatori.EmptyDataText = "Nici o cerere gasita";
                gvCereriConsumatori.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }


    protected void gvCereriConsumatori_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int NCO = Convert.ToInt32(gvCereriConsumatori.Rows[e.NewEditIndex].Cells[1].Text);
        fs1.Visible = true;
        DataRow dr = ((DataSet)ViewState["ds"]).Tables[0].Select("Nr_consumator=" + NCO)[0];
        txtNrConsumator.Text = dr["Nr_consumator"].ToString();
        txtNumeConsumator.Text = dr["Nume"].ToString();
        txtAdresa.Text = dr["Adresa"].ToString();
        txtConexiune.Text = dr["Nume_conexiune"].ToString();
        txtReDate.Text = dr["Data_cerere"].ToString();
        ViewState["Nume_agentie"] = dr["Nume_agentie"].ToString();

    }
    protected void btnAccepta_Click(object sender, EventArgs e)
    {
        try
        {
            Insereaza_detalii_conexiune();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();


        }
    }
    public void Insereaza_detalii_conexiune()
    {
        objDistribuitor.Nr_consumator = Convert.ToInt32(txtNrConsumator.Text);
        objDistribuitor.Nume_consumator = txtNumeConsumator.Text;
        objDistribuitor.Adresa_consumator = txtAdresa.Text;
        objDistribuitor.Nume_conexiune = txtConexiune.Text;
        objDistribuitor.Data_cererii= Convert.ToDateTime(txtReDate.Text);
        objDistribuitor.Data_alocare = Convert.ToDateTime(txtDataAlocare.Text);
        objDistribuitor.Nr_butelie = Convert.ToInt32(txtButelie.Text);
        objDistribuitor.Regulator = Convert.ToInt32(txtRegulator.Text);
        objDistribuitor.Nume_agentie = ViewState["Nume_agentie"].ToString();
        objDistribuitor.Valoare_depozit = Convert.ToDecimal(txtValoareDepozit.Text);
        objDistribuitor.Incarca_conexiune = Convert.ToDecimal(txtIncarcaConexiune.Text);
        string s = objDistribuitor.Insereaza_detalii_conexiune();
        lblMsg.Text = s;
        Afiseaza_conexiuni_noi();
    }
    protected void btnInchide_Click(object sender, EventArgs e)
    {
        fs1.Visible = false;
    }
}
