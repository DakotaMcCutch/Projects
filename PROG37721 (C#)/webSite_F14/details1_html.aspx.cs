using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;

public partial class details1_html : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connStr = ConfigurationManager.ConnectionStrings["connStr_nWind"].ToString();
        OleDbConnection conn = new OleDbConnection(connStr);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT [SupplierID],[CompanyName],[City],[Country] FROM [Suppliers]";
        OleDbDataReader dr = cmd.ExecuteReader();

        if (dr.HasRows)
        {
            Response.Write("<table border='2'>");
            Response.Write("<tr>");
            for (int i = 1; i < dr.FieldCount; i++)
            {
                Response.Write("<th>" + dr.GetName(i) + "</th>");
            }
            Response.Write("<th>Details</th></tr>");
            while(dr.Read())
            {
                Response.Write("<tr>");
                for (int i = 1; i < dr.FieldCount; i++)
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
                Response.Write("<td><a href='details2.aspx?SupplierId=" + dr.GetValue(0) + "'>...select</td>");
                Response.Write("</tr>");
            }
            Response.Write("</table>");

        }
        dr.Close();
        conn.Close();
    }
}