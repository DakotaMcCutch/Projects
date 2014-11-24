using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dataTest2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //bind and display
        GridView1.DataSource = SqlDataSource1;
        GridView1.DataBind();
    }
}