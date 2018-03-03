<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;   
public class Handler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();
        int IDC = Convert.ToInt32(context.Request.QueryString["IDC"].ToString());
        string sql = "Select Imagine from Inregistrare_utilizatori where Id_utilizator=" + IDC;
        SqlCommand cmd = new SqlCommand(sql, myConnection); 
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();

        
        context.Response.BinaryWrite((byte[])dr["Imagine"]);
        dr.Close();
        myConnection.Close();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}