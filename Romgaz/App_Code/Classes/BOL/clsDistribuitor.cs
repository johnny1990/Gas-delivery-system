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

public class clsDistribuitor:clsUtilizator 
{
	public clsDistribuitor()
	{
		
	}
    public int Nr_consumator { get; set; }
    public string Adresa_consumator { get; set; }
    public string  Nume_conexiune { get; set; }
    public DateTime Data_cererii { get; set; }
    public DateTime Data_alocare { get; set; }
    public int Nr_butelie { get; set; }
    public int Regulator { get; set; }
    public string Nume_consumator { get; set; }
    public decimal Valoare_depozit { get; set; }
    public decimal  Incarca_conexiune { get; set; }
    public int Id_nr { get; set; }
    
    public DataSet Afiseaza_cereri_conexiune_consumatori()
    {
        SqlParameter p = new SqlParameter("@Id_utilizator", Id_utilizator);
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Afiseaza_cereri_conexiune_consumatori", p);  
    }
    public string Insereaza_detalii_conexiune()
    {
        SqlParameter[] p = new SqlParameter[12];
        p[0] = new SqlParameter("@Nr_consumator", Nr_consumator);
        p[1] = new SqlParameter("@Nume_consumator", Nume_consumator);
        p[2] = new SqlParameter("@Adresa_consumator", Adresa_consumator);
        p[3] = new SqlParameter("@Nume_conexiune", Nume_conexiune);
        p[4] = new SqlParameter("@Data_cerere", Data_cererii);
        p[5] = new SqlParameter("@Data_alocare", Data_alocare);
        p[6] = new SqlParameter("@Nr_butelie", Nr_butelie);
        p[7] = new SqlParameter("@Regulator", Regulator);
        p[8] = new SqlParameter("@Nume_agentie", Nume_agentie);
        p[9] = new SqlParameter("@Mesaj", SqlDbType.VarChar, 100);
        p[9].Direction = ParameterDirection.Output;
        p[10]=new SqlParameter("@Valoare_depozit",Valoare_depozit);
        p[11] = new SqlParameter("@Incarcare_conexiune", Incarca_conexiune); 
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "Insereaza_detalii_conexiune_gaz",p);
        return p[9].Value.ToString();  
    }
    public DataSet Afiseaza_detalii_rezervare_gaz()
    {
        SqlParameter p = new SqlParameter("@Id_utilizator", Id_utilizator);
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Afiseaza_detalii_rezervare_gaz", p);  
    }
    public DataSet Cerere_transfer()
    {
        SqlParameter p = new SqlParameter("@Id_utilizator", Id_utilizator);
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Afiseaza_adresa_utilizator_cerere_transfer", p); 
    }
    public int Trimite_cerere_transfer_catre_administrator()
    {
        string SqlStat = "update Adrese_cereri_transfer set Stare='Catre Administrator' where Id_nr=" + Id_nr;
        int a = SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.Text, SqlStat);
        return a;
    }
    public DataSet Afiseaza_rapoarte_consumatori()
    {
        SqlParameter p = new SqlParameter("@Id_utilizator", Id_utilizator); 
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Afiseaza_raport_consumator", p); 
    }
    public DataSet Acceptare_rezervare_conexiune_gaz(int Id_utilizator)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Id_utilizator", Id_utilizator);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Acceptare_rezervare_gaz", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }


}
