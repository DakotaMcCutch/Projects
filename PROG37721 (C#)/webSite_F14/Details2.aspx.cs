using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

public partial class Details2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NameValueCollection qsData = Request.QueryString;
        if(qsData.Get("SupplierID") !=null)
        {
            int sID = Convert.ToInt32(qsData.Get("SupplierID"));
            string sql = "SELECT * FROM [Suppliers] WHERE [SupplierID] = " + sID;
            SqlDataSource1.SelectCommand = sql;


        }
        else
        {
            Response.Redirect("details1.aspx");
        }
    }
}