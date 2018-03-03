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

public class clsUtilizator:clsRegiune 
{
	public clsUtilizator()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string Nume { get; set; }
    public string Prenume { get; set; }
    public string Prenume_2 { get; set; }
    public string Email { get; set; }
    public string Adresa { get; set; }
    public string Nr_telefon { get; set; }
    public int Id_utilizator { get; set; }
    public string Nume_utilizator { get; set; }
    public string Parola{ get; set; }
    public DateTime Data_nasterii { get; set; }
    public byte[] Imagine { get; set; }
    public string Nume_fisier { get; set; }
    public DateTime Data_inregistrarii { get; set; }
    public string Regula { get; set; }
    public string Sex { get; set; }
    public string  Nume_agentie { get; set; }
    public int Conexiune { get; set; }
    public int Id_agent { get; set; }
    public int Catre_oras { get; set; }
    public string Catre_nume_agentie { get; set; }
    public int Catre_id_agent { get; set; }
    public string Subiect { get; set; }
    public string Descriere { get; set; }



    public string Insereaza_inregistrare_utilizator()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[20];
            p[0] = new SqlParameter("@Nume_utilizator", Nume_utilizator);
            p[1] = new SqlParameter("@Parola", Parola);
            p[2] = new SqlParameter("@Nume", Nume);
            p[3] = new SqlParameter("@Prenume", Prenume);
            p[4] = new SqlParameter("@Prenume_2", Prenume_2);
            p[5] = new SqlParameter("@Email", Email);
            p[6] = new SqlParameter("@Adresa", Adresa);
            p[7] = new SqlParameter("@Nr_telefon", Nr_telefon);
            p[8] = new SqlParameter("@Data_nasterii", Data_nasterii);
            p[9] = new SqlParameter("@Data_inregistrarii", Data_inregistrarii);
            p[10] = new SqlParameter("@Imagine",Imagine);
            p[11] = new SqlParameter("@Nume_fisier", Nume_fisier);
            p[12] = new SqlParameter("@Mesaj", SqlDbType.VarChar, 250);
            p[12].Direction = ParameterDirection.Output;
            p[13] = new SqlParameter("@Regula", Regula);            
            p[14] = new SqlParameter("@Sex", Sex);
            p[15] = new SqlParameter("@Regiune", Id_regiune);
            p[16] = new SqlParameter("@Judet", Id_judet);
            p[17] = new SqlParameter("@Oras", Id_oras);
            p[18] = new SqlParameter("@Nume_agentie", Nume_agentie);
            p[19] = new SqlParameter("@Tip_conexiune", Conexiune);
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "Insereaza_inregistrare_utilizator", p);
            return p[12].Value.ToString();
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
            p[0] = new SqlParameter("@Id_utilizator",Id_utilizator);
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
    public DataSet Afiseaza_detalii_conexiune_de_catre_utilizator()
    {
        SqlParameter p = new SqlParameter("@Id_utilizator", @Id_utilizator);
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Selecteaza_stare_conexiune", p);
    }

    public string Rezervare_gaz_utilizator()
    {
        SqlParameter[] p = new SqlParameter[4];
        p[0] = new SqlParameter("@Id_utilizator", Id_utilizator);
        p[1] = new SqlParameter("@Nume_agentie", Nume_agentie);
        p[2] = new SqlParameter("@Mesaj", SqlDbType.VarChar, 1000);
        p[2].Direction = ParameterDirection.Output;
        p[3]=new SqlParameter("@Id_agent",Id_agent);

        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "Insereaza_detalii_rezervare_gaz", p);
        return p[2].Value.ToString();  
    }
    public DataSet Stare_rezervare_gaz()
    {
            SqlParameter p = new SqlParameter("@Id_utilizator", Id_utilizator);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Stare_rezervare_gaz", p);
    }

    public string Insereaza_cerere_transfer()
    {
        SqlParameter[] p = new SqlParameter[8];
        p[0] = new SqlParameter("@Id_utilizator", Id_utilizator);
        p[1] = new SqlParameter("@De_la_orasul", Id_oras);
        p[2] = new SqlParameter("@De_la_agentia_cu_numele", Nume_agentie);
        p[3] = new SqlParameter("@Mesaj", SqlDbType.VarChar, 100);
        p[3].Direction = ParameterDirection.Output;
        p[4] = new SqlParameter("@De_la_Id_agent", Id_agent); 
        p[5]=new SqlParameter("@Catre_orasul",Catre_oras) ;
        p[6] = new SqlParameter("@Catre_agentia_cu_numele", Catre_nume_agentie);
        p[7] = new SqlParameter("@Catre_id_agent", Catre_id_agent);
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "Insereaza adresa cerere transfer", p);
        return p[3].Value.ToString();  
 
    }
    public DataSet  Afiseaza_conexiune_utilizatori()
    {
        SqlParameter p = new SqlParameter("@Id_utilizator", Id_utilizator);
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Afiseaza_agentie_utilizator",p); 
    }
    public int Insereaza_feedback()
    {
        SqlParameter[] p = new SqlParameter[3];
        p[0] = new SqlParameter("@Subiect", Subiect);
        p[1] = new SqlParameter("@Descriere", Descriere);
        p[2] = new SqlParameter("@Feedback_de_la", Id_utilizator);
       int a= SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "Insereaza_feedback", p);
       return a;
    }

    public int Insereaza_feedback_invitat()
    {
        SqlParameter[] p = new SqlParameter[3];
        p[0] = new SqlParameter("@Subiect", Subiect);
        p[1] = new SqlParameter("@Descriere", Descriere);
        p[2] = new SqlParameter("@Feedback_de_la", Id_utilizator);
        int a = SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.Text, "Insereaza feedback invitat", p);
        return a;
    }

    public DataSet Stare_transfer_gaz()
    {
            SqlParameter p = new SqlParameter("@Id_utilizator", Id_utilizator);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Stare_transfer_gaz", p);
    }
}
