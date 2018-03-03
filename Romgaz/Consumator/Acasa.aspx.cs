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

public partial class Consumator_Acasa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsDistribuitor objDistribuitor = new clsDistribuitor();
        objDistribuitor.Id_utilizator = Convert.ToInt32(Session["Id_utilizator"]);
        DataSet ds = objDistribuitor.Afiseaza_detalii_conexiune_de_catre_utilizator();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            Session["Id_agent"] = dr["Id_agent"].ToString();
        }
        lblNumeUtilizator.Text = Session["Nume_utilizator"].ToString();
    }
}
