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

public partial class Administrator_Judet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Afiseaza_regiune();
        }
    }

    protected void btnContinua_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlRegiune.SelectedItem.Text != "Selecteaza")
            {
                objRegiune.Nume_judet = txtNumeRegiune.Text;
                objRegiune.Descriere = txtDescriere.Text;
                objRegiune.Id_regiune = Convert.ToInt32(ddlRegiune.SelectedItem.Value);
                string s = objRegiune.Insereaza_judet();
                lblMsg.Text = s;
            }
            else
            {
                lblMsg.Text = "Selecteaza nume regiune";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }
    }
    protected void btnAnuleaza_Click(object sender, EventArgs e)
    {
        clear();
        lblMsg.Text = "";
    }
    void clear()
    {

        txtDescriere.Text = "";
        txtNumeRegiune.Text = "";
        ddlRegiune.SelectedIndex = 0;

    }
    protected void btnAfiseaza_Click(object sender, EventArgs e)
    {
        try
        {
            fs1.Visible = true;
            DataSet ds = objRegiune.Afiseaza_toate_judetele();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvJudet.DataSource = ds.Tables[0];
                gvJudet.DataBind();
            }
            else
            {
                gvJudet.EmptyDataText = "Date nedisponibile";
                gvJudet.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }
    clsRegiune objRegiune = new clsRegiune();
    public void Afiseaza_regiune()
    {
        DataSet ds = objRegiune.Afiseaza_regiune();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlRegiune.DataTextField = "Nume_regiune";
            ddlRegiune.DataValueField = "Id_regiune";
            ddlRegiune.DataSource = ds.Tables[0];
            ddlRegiune.DataBind();
            ddlRegiune.Items.Insert(0, "Selecteaza");
        }

    }
    protected void btnInchide_Click(object sender, EventArgs e)
    {
        fs1.Visible = false;
    }
}
