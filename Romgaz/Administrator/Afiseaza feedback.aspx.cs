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

public partial class Administrator_Afiseaza_feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Afiseaza_feedback();
    }
    clsAdministrator objAdministrator = new clsAdministrator();
    public void Afiseaza_feedback()
    {
        DataSet ds = objAdministrator.Afiseaza_feedback();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvFeedback.DataSource = ds.Tables[0];
            gvFeedback.DataBind();
        }
        else
        {
            gvFeedback.EmptyDataText = "Date nedisponibile";
            gvFeedback.DataBind();
        }
    }
}
