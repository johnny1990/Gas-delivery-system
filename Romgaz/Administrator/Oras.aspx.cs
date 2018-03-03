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

public partial class Administrator_Oras : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Afiseaza_judet();
        }
    }
    protected void btnInainte_Click(object sender, EventArgs e)
    {
        try
        {
            objRegiune.Id_judet = Convert.ToInt32(ddJudet.SelectedItem.Value);
            objRegiune.Nume_oras = txtNumeRegiune.Text;
            objRegiune.Descriere = txtDescriere.Text;
            string s = objRegiune.Insereaza_oras();
            lblMsg.Text = s;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }
    }
    void Clear()
    {
        txtDescriere.Text = "";
        txtNumeRegiune.Text = "";
        ddJudet.SelectedIndex = 0;
    }
    protected void btnAnuleaza_Click(object sender, EventArgs e)
    {
        Clear();
        lblMsg.Text = "";

    }
    protected void btnAfiseaza_Click(object sender, EventArgs e)
    {
        try
        {
            fs1.Visible = true;
            DataSet ds = objRegiune.Afiseaza_toate_orasele();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvShowCity.DataSource = ds.Tables[0];
                gvShowCity.DataBind();
            }
            else
            {
                gvShowCity.EmptyDataText = "Date nedisponibile";
                gvShowCity.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }

    }
    clsRegiune objRegiune = new clsRegiune();
    public void Afiseaza_judet()
    {
        DataSet ds = objRegiune.Afiseaza_judet();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddJudet.DataTextField = "Nume_judet";
            ddJudet.DataValueField = "Id_judet";
            ddJudet.DataSource = ds.Tables[0];
            ddJudet.DataBind();
            ddJudet.Items.Insert(0, "Selecteaza");
        }

    }
    protected void btnInchide_Click(object sender, EventArgs e)
    {
        fs1.Visible = false;
    }
}
