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

public class clsAdministrator
{
	public clsAdministrator()
	{
	
	}
    public int Id_tip_conexiune { get; set; }
    public string  Nume_conexiune { get; set; }
    public string Descriere { get; set; }
    public decimal Schimba_incarcare { get; set; }
    public decimal Incarcare_conexiune_noua { get; set; }
    public int Id_nr { get; set; }
    public int Butelii_totale { get; set; }
    public int Butelii_disponibile { get; set; }
    public int Id_oras { get; set; }
    public string Nume_agentie { get; set; }
    public int Id_utilizator { get; set; }

    public string Insereaza_conexiune()
    {
        SqlParameter[] p = new SqlParameter[5];
        p[0] = new SqlParameter("@Nume_conexiune", Nume_conexiune);
        p[1] = new SqlParameter("@Descriere", Descriere);
        p[2] = new SqlParameter("@Schimba_incarcare", Schimba_incarcare);
        p[3] = new SqlParameter("@Conexiune_noua_pret", Incarcare_conexiune_noua);
        p[4] = new SqlParameter("@Mesaj", SqlDbType.VarChar, 100);
        p[4].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "Insereaza_tip_conexiune", p);
        return p[4].Value.ToString();  
        
    }
    public DataSet Afiseaza_tip_conexiune()
    {
        string SqlStat = "select Id_tip_conexiune,Nume_conexiune,Descriere,Schimba_incarcare,Pret_conexiune_noua from Tip_conexiune";
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, SqlStat);  
    }
    public string Actualizare_conexiune()
    {
        SqlParameter[] p = new SqlParameter[6];
        p[0] = new SqlParameter("@Nume_conexiune", Nume_conexiune);
        p[1] = new SqlParameter("@Descriere", Descriere);
        p[2] = new SqlParameter("@Schimba_incarcare", Schimba_incarcare);
        p[3] = new SqlParameter("@Pret_conexiune_noua", Incarcare_conexiune_noua);
        p[4] = new SqlParameter("@Mesaj", SqlDbType.VarChar, 100);
        p[4].Direction = ParameterDirection.Output;
        p[5] = new SqlParameter("@Id_tip_conexiune", Id_tip_conexiune);
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "Actualizare_conexiune", p);
        return p[4].Value.ToString();

    }
    public DataSet Afiseaza_locatii_cerere_transfer_utilizatori_catre_Administrator()
    {
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Afiseaza_locatii_cerere_transfer_utilizatori_catre_Administrator");  
    }
    public string Actualizare_cerere_transfer_utilizatori()
    {
        SqlParameter[] p = new SqlParameter[5];
        p[0]=new SqlParameter("@Id_nr",Id_nr);
        p[1]=new SqlParameter("@Id_utilizator",Id_utilizator);
        p[2]=new SqlParameter("@Catre_orasul",Id_oras);
        p[3]=new SqlParameter("@Catre_agentia_cu_numele",Nume_agentie); 
        p[4]=new SqlParameter("@Mesaj",SqlDbType.VarChar,100);
        p[4].Direction =ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(clsConnection.Connection,CommandType.StoredProcedure,"Actualizare cerere transfer de catre administrator",p);  
        return p[4].Value.ToString();  
    }
    public string Adauga_detalii_butelii()
    {
        SqlParameter[] p = new SqlParameter[6];
        p[0] = new SqlParameter("Id_oras", Id_oras);
        p[1] = new SqlParameter("@Id_agent", Id_utilizator);
        p[2] = new SqlParameter("@Nume_agentie", Nume_agentie);
        p[3] = new SqlParameter("@Butelii_totale", Butelii_totale);
        p[4] = new SqlParameter("@Butelii_disponibile", Butelii_disponibile);
        p[5] = new SqlParameter("@Mesaj", SqlDbType.VarChar, 100);
        p[5].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "Insereaza_butelii_gaz", p);
        return p[5].Value.ToString();  
    }
    public DataSet Afiseaza_raport_distribuitori()
    {
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Afiseaza_distribuitori");   
    }
    public DataSet Afiseaza_raport_consumatori()
    {
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Afiseaza_consumatori");
    }
    public DataSet  Afiseaza_stare_butelii()
    {
        SqlParameter[] p = new SqlParameter[2];
        p[0] = new SqlParameter("@Id_oras", Id_oras);
        p[1] = new SqlParameter("@Nume_agentie", Nume_agentie);
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Stare_butelie", p); 
    }
    public DataSet Afiseaza_toate_buteliile()
    {
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Afiseaza_toate_buteliile");  
    }
    public string  Actualizare_butelii()
    {
        SqlParameter[]p=new  SqlParameter[4];
        p[0] = new SqlParameter("@Id_nr", Id_nr);
        p[1] = new SqlParameter("@Butelii_totale", Butelii_totale);
        p[2] = new SqlParameter("@Butelii_disponibile", Butelii_disponibile);
        p[3] = new SqlParameter("@Mesaj", SqlDbType.VarChar, 100);
        p[3].Direction = ParameterDirection.Output;   
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "Actualizare_butelii", p);
        return p[3].Value.ToString();  
         
  
    }
    public DataSet Afiseaza_feedback()
    {
       return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Afiseaza_feedback" );
    }
}
