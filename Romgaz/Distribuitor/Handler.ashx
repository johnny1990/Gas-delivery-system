<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;  
public class Handler : IHttpHandler {
    
     public void ProcessRequest(HttpContext context)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();
        int PID = Convert.ToInt32(context.Request.QueryString["CID"].ToString());
        string sql = "Select Imagine from Inregistrare_utilizator where Id_utilizator=" + PID;
        SqlCommand cmd = new SqlCommand(sql, myConnection);
         
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();

       
        context.Response.BinaryWrite((byte[])dr["Imagine"]);
        dr.Close();
        myConnection.Close();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}