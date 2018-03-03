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

public partial class Administrator_Tip_conexiune : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    clsAdministrator objAdministrator = new clsAdministrator();
    protected void btnContinua_Click(object sender, EventArgs e)
    {
        try
        {
            objAdministrator.Nume_conexiune = txtNumeConexiune.Text;
            objAdministrator.Descriere = txtDescriere.Text;
            objAdministrator.Schimba_incarcare = Convert.ToDecimal(txtReincarca.Text);
            objAdministrator.Incarcare_conexiune_noua = Convert.ToDecimal(txtPretNou.Text);
            string s = objAdministrator.Insereaza_conexiune();
            lblMsg.Text = s;

        }
        catch (Exception ex)
        {

            lblMsg.Text = ex.Message.ToString();
        }
    }
    protected void btnAnuleaza_Click(object sender, EventArgs e)
    {
        txtPretNou.Text = "";
        txtReincarca.Text = "";
        txtPretNou.Text = "";
        txtDescriere.Text = "";


    }
    protected void btnAfiseaza_Click(object sender, EventArgs e)
    {
        try
        {
            Afiseaza_tip_conexiune();
        }
        catch (Exception ex)
        {

        }



    }
    protected void btnInchide_Click(object sender, EventArgs e)
    {
        fs1.Visible = false;

    }
    public void Afiseaza_tip_conexiune()
    {
        fs1.Visible = true;
        DataSet ds = objAdministrator.Afiseaza_tip_conexiune();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvDetaliiConexiune.DataSource = ds.Tables[0];
            gvDetaliiConexiune.DataBind();
        }
        else
        {
            gvDetaliiConexiune.EmptyDataText = "Date nedisponibile";
            gvDetaliiConexiune.DataBind();
        }
    }
}
