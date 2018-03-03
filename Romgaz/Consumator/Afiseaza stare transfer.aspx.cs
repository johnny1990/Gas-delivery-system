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

public partial class Consumator_Afiseaza_stare_transfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Afiseaza_stare_transfer();
        }
    }
    clsUtilizator objUtilizator = new clsUtilizator();
    public void Afiseaza_stare_transfer()
    {
        try
        {
            objUtilizator.Id_utilizator = Convert.ToInt32(Session["Id_consumator"]);
            DataSet ds = objUtilizator.Stare_transfer_gaz();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvAfiseazaStareTransfer.DataSource = ds.Tables[0];
                gvAfiseazaStareTransfer.DataBind();
            }
            else
            {
                gvAfiseazaStareTransfer.EmptyDataText = "Date nedisponibile";
                gvAfiseazaStareTransfer.DataBind();
            }
        }
        catch (Exception ex)
        {

            lblmsg.Text = ex.ToString();
        }
    }
}
