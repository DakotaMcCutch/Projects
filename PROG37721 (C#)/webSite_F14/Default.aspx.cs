using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            Response.Write("PostBack = " + true);
        }
        else
        {

        }
    }
    protected void cmdHello_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Length > 0)
        {
            lblHello.Text = "Hello " + txtName.Text;
        }
        else
        {
            lblHello.Text = "Please Enter Your Name";
        }
        txtName.Focus();
    }
}