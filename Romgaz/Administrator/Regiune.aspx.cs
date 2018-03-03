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

public partial class Administrator_Regiune : System.Web.UI.Page
{
    clsRegiune objRegiune = new clsRegiune();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnInainte_Click(object sender, EventArgs e)
    {
        try
        {
            objRegiune.Nume_regiune = txtNumeRegiune.Text;
            objRegiune.Descriere = txtDescriere.Text;
            string s = objRegiune.Insereaza_regiune();
            lblMsg.Text = s;
            Clear();

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }

    }
    public void Clear()
    {
        txtNumeRegiune.Text = "";
        txtDescriere.Text = "";

    }


    protected void btnAfiseaza_Click(object sender, EventArgs e)
    {
        try
        {
            fs1.Visible = true;
            DataSet ds = objRegiune.Afiseaza_regiune();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetaliiRegiune.DataSource = ds.Tables[0];
                gvDetaliiRegiune.DataBind();
            }
            else
            {
                gvDetaliiRegiune.EmptyDataText = "Date nedisponibile";
                gvDetaliiRegiune.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }
    }
    protected void btnInchide_Click(object sender, EventArgs e)
    {
        fs1.Visible = false;
    }
}
