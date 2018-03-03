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

public partial class Distribuitor_Adresa_cereri_transfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Afiseaza_cereri_transfer();
        }
    }
    clsDistribuitor objDist = new clsDistribuitor();
    public void Afiseaza_cereri_transfer()
    {
        objDist.Id_utilizator = Convert.ToInt32(Session["Id_utilizator"]);
        DataSet ds = objDist.Cerere_transfer();
        if (ds.Tables[0].Rows.Count > 0)
        {
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
        int Id_nr = Convert.ToInt32(gvCereriTransfer.Rows[e.NewEditIndex].Cells[0].Text);
        objDist.Id_nr = Id_nr;
        int a = objDist.Trimite_cerere_transfer_catre_administrator();
        if (a > 0)
        {
            lblMsg.Text = "Cerere trimisa catre administrator";
            Afiseaza_cereri_transfer();
        }
    }
}
