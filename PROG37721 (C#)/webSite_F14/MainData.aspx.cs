using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

public partial class MainData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //gte data
        string sql = "SELECT * FROM [tUsers]";
        string connStr = ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString;

        SqlConnection conn = null;
        try
        {
            conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();


        }
        catch (SqlException ex)
        {

            if (conn != null)
            {
                conn.Close();
            }
            Response.Write(ex.Message);
        }
        //create container for PrimaryKey Values
        ArrayList uNames = new ArrayList();
        //populate Arraylist .... AKK values LOWER CASE!!!!!
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            uNames.Add(GridView1.Rows[i].Cells[0].Text.ToLower());
        }
        //save Arraylist to Session
        Session["uNames"] = uNames;
        //wire up RowCommand for GridView
        GridView1.RowCommand += GridView1_RowCommand;
    }

    void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("updateRow"))
        {
            //must get row index
            int rowIndex = Convert.ToInt32(e.CommandArgument);
          //  Response.Write("rowIndex = " + rowIndex);
            //generate query string
            Response.Redirect("update.aspx?uName=" + GridView1.Rows[rowIndex].Cells[0].Text + "&pWord=" + GridView1.Rows[rowIndex].Cells[1].Text + "&rowIndex=" + rowIndex);
        }
        else if (e.CommandName.Equals("deleteRow"))
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            Response.Redirect("delete.aspx?uName=" + GridView1.Rows[rowIndex].Cells[0].Text + "&pWord=" + GridView1.Rows[rowIndex].Cells[1].Text + "&rowIndex=" + rowIndex);
        }
    }
}