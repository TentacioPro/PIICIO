using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class HRManagerTLDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CO"].ConnectionString.ToString());
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["CO"].ConnectionString.ToString());
    SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["CO"].ConnectionString.ToString());
    SqlConnection con3 = new SqlConnection(ConfigurationManager.ConnectionStrings["CO"].ConnectionString.ToString());
    SqlCommand cmd;
    SqlDataAdapter da;
    DataTable dt = new DataTable();
    SqlDataReader dr;
    SqlDataReader dr1;
    SqlDataReader dr2;
    SqlDataReader dr3;
    DataSet ds = new DataSet();
    SqlConnection con4 = new SqlConnection(ConfigurationManager.ConnectionStrings["CO"].ConnectionString.ToString());
    SqlCommand cmd4;

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;

        string a = gvrow.Cells[0].Text;

        // string date = DateTime.Now.ToString("dd/MM/yyyy");
        con3.Open();
        cmd = new SqlCommand("update TeamLeaderDetails set Status='Accept' where EmployeeID='" + a + "'", con3);
        cmd.ExecuteNonQuery();
        con3.Close();
        Response.Write("<script>alert('Accepted Successfully')</script>");
        Response.Redirect("HRManagerTLDetails.aspx");
        Response.Write("<script>alert('Accepted Successfully')</script>");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;

        string a = gvrow.Cells[0].Text;

        // string date = DateTime.Now.ToString("dd/MM/yyyy");
        con3.Open();
        cmd = new SqlCommand("update TeamLeaderDetails set Status='Reject' where EmployeeID='" + a + "'", con3);
        cmd.ExecuteNonQuery();
        con3.Close();
        Response.Write("<script>alert('Rejected Successfully')</script>");
        Response.Redirect("HRManagerTLDetails.aspx");
        Response.Write("<script>alert('Rejected Successfully')</script>");
    }
}