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

public partial class Distribuitor_Feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    clsUtilizator objUtilizator = new clsUtilizator();
    protected void btnTrimite_Click(object sender, EventArgs e)
    {
        objUtilizator.Id_utilizator = Convert.ToInt32(Session["Id_distribuitor"]);
        objUtilizator.Subiect = txtSubiect.Text;
        objUtilizator.Descriere = txtDescriere.Text;
        int a = objUtilizator.Insereaza_feedback();
        if (a > 0)
        {
            Label1.Text = "Feedback trimis catre administrator";
            txtSubiect.Text = "";
            txtDescriere.Text = "";

        }

    }
}
