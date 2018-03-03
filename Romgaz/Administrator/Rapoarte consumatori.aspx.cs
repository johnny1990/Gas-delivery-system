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

public partial class Administrator_Rapoarte_consumatori : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Afiseaza_rapoarte_consumator();

    }
    clsAdministrator objAdministrator = new clsAdministrator();
    public void Afiseaza_rapoarte_consumator()
    {
        DataSet ds = objAdministrator.Afiseaza_raport_consumatori();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvRapoarteConsumatori.DataSource = ds.Tables[0];
            gvRapoarteConsumatori.DataBind();
        }
        else
        {
            gvRapoarteConsumatori.EmptyDataText = "Date nedisponibile";
            gvRapoarteConsumatori.DataBind();
        }
    }

}
