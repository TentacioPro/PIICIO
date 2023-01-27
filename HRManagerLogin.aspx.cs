using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HRManagerLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "manager" && TextBox2.Text == "manager")
        {
            Response.Redirect("HRManagerHome.aspx");
        }
        else
        {
            Response.Write("<script>alert('Invalid Username or Password')</script>");
        }
    }
}