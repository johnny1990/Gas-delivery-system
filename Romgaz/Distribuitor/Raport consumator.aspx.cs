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

public partial class Distribuitor_Raport_consumator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Afiseaza_rapoarte_consumatori();
    }
    clsDistribuitor objDist = new clsDistribuitor();
    public void Afiseaza_rapoarte_consumatori()
    {
        objDist.Id_utilizator = Convert.ToInt32(Session["Id_distribuitor"]);
        DataSet ds = objDist.Afiseaza_rapoarte_consumatori();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvRaportConsumator.DataSource = ds.Tables[0];
            gvRaportConsumator.DataBind();
        }
        else
        {
            gvRaportConsumator.EmptyDataText = "Date nedisponibile";
            gvRaportConsumator.DataBind();
        }
    }
}
