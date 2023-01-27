using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TeamLeaderEmployeeAttendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TeamLeaderID"] != null && Session["TeamLeaderName"] != null)
        {
            TextBox1.Text = Session["TeamLeaderID"].ToString();
            TextBox2.Text = Session["TeamLeaderName"].ToString();
            TextBox3.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}