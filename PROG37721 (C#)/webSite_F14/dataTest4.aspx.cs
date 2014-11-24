using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class dataTest4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\NWIND.MDB";
        OleDbConnection conn = new OleDbConnection(connStr);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conn;
        cmd.CommandText = " SELECT * FROM [Suppliers]";
        OleDbDataReader dr = cmd.ExecuteReader();
        if(dr.HasRows)
        {
            Response.Write("<table border='2'>");
            Response.Write("<tr>");
            for (int i=0;i<dr.FieldCount; i++)
            {
                Response.Write("<th>" + dr.GetName(i) + "</th>");
            }
            Response.Write("</tr>");
            while (dr.Read())
            {
                Response.Write("<tr>");
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    if (dr.GetValue(i) != DBNull.Value)
                    {
                        Response.Write("<td>" + dr.GetValue(i) + "</td>");
                    }
                    else
                    {
                        Response.Write("<td>&nbsp;</td>");
                    }
                }
                Response.Write("</tr>");
            }
            Response.Write("</table>");
        }
    }
}