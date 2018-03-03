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

public partial class Administrator_Rapoarte_agentie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Afiseaza_rapoarte_agentie();
    }
    clsAdministrator objAdministrator = new clsAdministrator();
    public void Afiseaza_rapoarte_agentie()
    {
        DataSet ds = objAdministrator.Afiseaza_raport_distribuitori();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvRapoarteAgentie.DataSource = ds.Tables[0];
            gvRapoarteAgentie.DataBind();
        }
        else
        {
            gvRapoarteAgentie.EmptyDataText = "Date nedisponibile";
            gvRapoarteAgentie.DataBind();
        }
    }
}
