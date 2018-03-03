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

public partial class Administrator_Cerere_transfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Afiseaza_cereri_transfer();
        }
    }
    clsAdministrator objAdministrator = new clsAdministrator();
    public void Afiseaza_cereri_transfer()
    {
        DataSet ds = objAdministrator.Afiseaza_locatii_cerere_transfer_utilizatori_catre_Administrator();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ViewState["ds"] = ds;
            gvCereriTransfer.DataSource = ds.Tables[0];
            gvCereriTransfer.DataBind();
        }
        else
        {
            gvCereriTransfer.EmptyDataText = "Nici o cerere gasita";
            gvCereriTransfer.DataBind();
        }
    }
    protected void gvCereriTransfer_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int Id_nr = Convert.ToInt32(gvCereriTransfer.Rows[e.NewEditIndex].Cells[0].Text);
            DataRow dr = ((DataSet)ViewState["ds"]).Tables[0].Select("Id_nr=" + Id_nr)[0];
            objAdministrator.Id_nr = Convert.ToInt32(dr["Id_nr"].ToString());
            objAdministrator.Id_utilizator = Convert.ToInt32(dr["Nr_consumator"].ToString());
            objAdministrator.Id_oras = Convert.ToInt32(dr["Catre_oras"].ToString());
            objAdministrator.Nume_agentie = dr["Catre_nume_agentie"].ToString();
            string s = objAdministrator.Actualizare_cerere_transfer_utilizatori();
            lblMsg.Text = s;
            Afiseaza_cereri_transfer();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
        }
    }
}