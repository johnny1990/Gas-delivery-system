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

public partial class Consumator_Profil_conexiune : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Afiseaza_detalii_personale();
        }
    }
    protected void btnActualizare_Click(object sender, EventArgs e)
    {
        try
        {
            objUtilizator.Id_inregistrare_utilizator = Convert.ToInt32(Session["Id_consumator"]);
            objUtilizator.Nr_telefon = txtTelefon.Text;
            objUtilizator.Email = txtEmail.Text;
            objUtilizator.Adresa = txtAdresa.Text;
            objUtilizator.Nume_fisier = Convert.ToString(Session["Nume_fisier"]);
            lblMsg.Text = objUtilizator.Actualizare_profil();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    clsAutentificare objUtilizator = new clsAutentificare();

    protected void btnAnuleaza_Click(object sender, EventArgs e)
    {

    }
    protected void lbSchimbaParola_Click(object sender, EventArgs e)
    {
        divChangePss.Visible = true;

    }
    protected void btnActualizareParola_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            objUtilizator.Id_inregistrare_utilizator = Convert.ToInt32(Session["Id_consumator"]);
            objUtilizator.Parola_veche = txtVeche.Text;
            objUtilizator.Parola_noua = txtNou.Text;
            objUtilizator.Confirma_parola = txtConfirma.Text;
            lblMsg1.Text = objUtilizator.Schimba_parola();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }

    }
    protected void btnAnuleazaParola_Click(object sender, EventArgs e)
    {
        divChangePss.Visible = false;
    }
    void ClearData()
    {
        txtAdresa.Text = "";
        txtTelefon.Text = "";
        txtEmail.Text = "";
    }
    void Afiseaza_detalii_personale()
    {
        objUtilizator.Id_inregistrare_utilizator = Convert.ToInt32(Session["Id_consumator"]);
        DataSet ds = objUtilizator.Afiseaza_detalii_utilizatori();
        DataRow dr = ds.Tables[0].Rows[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtEmail.Text = dr["Email"].ToString();
            txtAdresa.Text = dr["Adresa"].ToString();
            txtTelefon.Text = dr["Nr_telefon"].ToString();
            

        }
    }
}
