using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class dataTest3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = Server.MapPath("/");
        //string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + path + "\\App_Data\\NWIND.MDB;Persist Security Info= true";
        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=|DataDirectory|\\NWIND.MDB;Persist Security Info= true";
        OleDbConnection conn = new OleDbConnection(connStr);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM [Suppliers]";
        OleDbDataReader dr = cmd.ExecuteReader();
        GridView1.DataSource = dr;
        GridView1.DataBind();
        dr.Close();
        conn.Close();
    }
}