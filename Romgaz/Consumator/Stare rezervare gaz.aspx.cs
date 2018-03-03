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

public partial class Consumator_Stare_rezervare_gaz : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Afiseaza_stare_rezervare();
        }

    }
    clsUtilizator objUtilizator = new clsUtilizator();
    public void Afiseaza_stare_rezervare()
    {
        objUtilizator.Id_utilizator = Convert.ToInt32(Session["Id_consumator"]);
        DataSet ds = objUtilizator.Stare_rezervare_gaz();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvAfiseazaStareRezervare.DataSource = ds.Tables[0];
            gvAfiseazaStareRezervare.DataBind();
        }
        else
        {
            gvAfiseazaStareRezervare.EmptyDataText = "Date nedisponibile";
            gvAfiseazaStareRezervare.DataBind();
        }
    }
}
