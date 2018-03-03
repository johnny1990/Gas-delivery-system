using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using EGAS.DAL;  

public class clsAutentificare:clsUtilizator 
{
	public clsAutentificare()
	{
		
	}

    public static string Nume_utilizator { get; set; }
    public static string Parola { get; set; }
    public static string Regula { get; set; }

    public static int Id_angajat { get; set; }
    public static int Id_utilizator { get; set; }

    public int Id_inregistrare_utilizator { get; set; }
    public string Parola_veche { get; set; }
    public string Parola_noua { get; set; }
    public string Confirma_parola { get; set; }
    public string Email { get; set; }
    public string Adresa { get; set; }
    public string Nr_telefon { get; set; }
    public byte[] Imagine { get; set; }
    public string Nume_fisier { get; set; }


    public static string Afiseaza_autentificare_utilizator(out int Id)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[4];

            p[0] = new SqlParameter("@Nume_utilizator", Nume_utilizator);
            p[1] = new SqlParameter("@Parola", Parola);
            p[2] = new SqlParameter("@Regula", SqlDbType.VarChar, 20);
            p[2].Direction = ParameterDirection.Output;
            p[3] = new SqlParameter("@Id_utilizator", SqlDbType.Int);
            p[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Verifica_autentificare", p);
            Id = Convert.ToInt32(p[3].Value);
            return p[2].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string Schimba_parola()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@Id_utilizator", Id_inregistrare_utilizator);
            p[1] = new SqlParameter("@Parola_veche", Parola_veche);
            p[2] = new SqlParameter("@Parola_noua", Parola_noua);
            p[3] = new SqlParameter("@Confirma_parola", Confirma_parola);
            p[4] = new SqlParameter("@Mesaj", SqlDbType.VarChar, 250);
            p[4].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "Schimba_parola", p);
            return p[4].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet Afiseaza_detalii_utilizatori()
    {
        try
        {
            string str = "select * from Inregistrare_utilizatori where Id_utilizator=" + this.Id_inregistrare_utilizator;
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public string Actualizare_profil()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@Id_utilizator", Id_inregistrare_utilizator);
            p[1] = new SqlParameter("@Nr_telefon", Nr_telefon);
            p[2] = new SqlParameter("@Email", Email);
            p[3] = new SqlParameter("@Imagine", Imagine);
            p[4] = new SqlParameter("@Nume_fisier", Nume_fisier);
            p[5] = new SqlParameter("@Mesaj", SqlDbType.VarChar, 250);
            p[5].Direction = ParameterDirection.Output;
            p[6] = new SqlParameter("@Adresa", Adresa);
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "Actualizare_profil", p);
            return p[5].Value.ToString();

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public static int Afiseaza_id_administrator_dupa_id_utilizator(int intId_utilizator)
    {
        try
        {
            string str = "select Id_utilizator as Id_administrator from Inregistrare_utilizatori where Regula='Administrator' and Id_utilizator=" + intId_utilizator;

            int Id = Convert.ToInt32(SqlHelper.ExecuteScalar(clsConnection.Connection, CommandType.Text, str));
            return Id;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public static int Afiseaza_distribuitor_dupa_Id_utilizator(int intId_utilizator)
    {
        try
        {
            string str = "select Id_utilizator as Id_distribuitor from Inregistrare_utilizatori where Regula='Distribuitor' and Id_utilizator=" + intId_utilizator;

            int Id = Convert.ToInt32(SqlHelper.ExecuteScalar(clsConnection.Connection, CommandType.Text, str));
            return Id;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public static int Afiseaza_id_consumator_dupa_id_utilizator(int intId_utilizator)
    {
        try
        {
            string str = "select Id_utilizator as Id_consumator from Inregistrare_utilizatori where Regula='Consumator' and Id_utilizator=" + intId_utilizator;

            int Id = Convert.ToInt32(SqlHelper.ExecuteScalar(clsConnection.Connection, CommandType.Text, str));
            return Id;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
   
}
