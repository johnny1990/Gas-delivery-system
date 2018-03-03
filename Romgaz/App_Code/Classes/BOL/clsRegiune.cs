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

public class clsRegiune
{
    public clsRegiune()
    {
       
    }
    public int Id_regiune{ get; set; }
    public string Nume_regiune { get; set; }
    public string Descriere { get; set; }
    public int Id_judet { get; set; }
    public string Nume_judet { get; set; }
    public string Nume_oras { get; set; }
    public int Id_oras { get; set; }

    public string Insereaza_regiune()
    {
        SqlParameter[] p = new SqlParameter[3];
        p[0] = new SqlParameter("@Nume_regiune", Nume_regiune);
        p[1] = new SqlParameter("@Descriere", Descriere);
        p[2] = new SqlParameter("@Mesaj", SqlDbType.VarChar, 100);
        p[2].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "Insereaza_regiune", p);
        return p[2].Value.ToString();

    }
    public DataSet Afiseaza_regiune()
    {
        string SqlStat = "select * from Regiuni";
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, SqlStat);
    }
    public string Insereaza_judet()
    {
        SqlParameter[] p = new SqlParameter[4];
        p[0] = new SqlParameter("@Nume_judet", Nume_judet);
        p[1] = new SqlParameter("@Descriere", Descriere);
        p[2] = new SqlParameter("@Id_regiune", Id_regiune);
        p[3] = new SqlParameter("@Mesaj", SqlDbType.VarChar, 100);
        p[3].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "Insereaza_judet", p);
        return p[3].Value.ToString();

    }
    public string Insereaza_oras()
    {
        SqlParameter[] p = new SqlParameter[4];
        p[0] = new SqlParameter("@Nume_oras", Nume_oras);
        p[1] = new SqlParameter("@Descriere", Descriere);
        p[2] = new SqlParameter("@Id_judet", Id_judet);
        p[3] = new SqlParameter("@Mesaj", SqlDbType.VarChar, 100);
        p[3].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "Insereaza_oras", p);
        return p[3].Value.ToString();

    }
    public DataSet Afiseaza_judet()
    {
        string SqlStat = "select * from Judete";
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, SqlStat);
    }
    public DataSet Afiseaza_toate_orasele()
    {
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Afiseaza_toate_orasele");
    }
    public DataSet Afiseaza_toate_judetele()
    {
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "Afiseaza_toate_judetele");
    }
    public DataSet Afiseaza_judet_dupa_id_regiune()
    {
        string SqlStat = "select * from Judete where Id_regiune=" + Id_regiune;
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, SqlStat);
    }
    public DataSet Afiseaza_oras_dupa_id_judet()
    {
        string SqlStat = "select * from Orase where Id_judet=" + Id_judet;
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, SqlStat);
    }
    public DataSet Afiseaza_nume_agentie()
    {
        string SqlStat = "select Id_utilizator, Nume_agentie from Inregistrare_utilizatori where Oras="+Id_oras+" and Regula='Distribuitor'";
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, SqlStat);
    }
}
