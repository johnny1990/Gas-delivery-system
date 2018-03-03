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

public partial class Distribuitor_Cerere_rezervare_gaz : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Afiseaza_cerere_rezervari();
        }

    }
    clsDistribuitor objDistribuitor = new clsDistribuitor();

    public void Afiseaza_cerere_rezervari()
    {
        objDistribuitor.Id_utilizator = Convert.ToInt32(Session["Id_utilizator"]);
        DataSet ds = objDistribuitor.Afiseaza_detalii_rezervare_gaz();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvCerereRezervare.DataSource = ds.Tables[0];
            gvCerereRezervare.DataBind();
        }
        else
        {
            gvCerereRezervare.EmptyDataText = "Nu exista nici o cerere aici";
            gvCerereRezervare.DataBind();
        }
    }
    static int Id_nr;
    protected void gvCerereRezervare_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Label tb = (Label)(gvCerereRezervare.Rows[e.NewEditIndex].FindControl("lblIdUtilizator"));
            Id_nr = Convert.ToInt32(tb.Text);
            objDistribuitor.Acceptare_rezervare_conexiune_gaz(Id_nr);
            Page.RegisterClientScriptBlock("Raghuveer", "<script>alert('Livrat cu succes....')</script>");
            Afiseaza_cerere_rezervari();
        }
        catch (Exception ex)
        {

        }
    }
}