using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class TeamLeaderLogin : System.Web.UI.Page
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        con.Open();
        cmd = new SqlCommand("select * from TeamLeaderDetails where EmployeeID='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'", con);
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            con1.Open();
            cmd = new SqlCommand("select * from TeamLeaderDetails where EmployeeID='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "' and Status='Accept'", con1);
            dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                Session["TeamLeaderID"] = TextBox1.Text;
                Session["TeamLeaderName"] = dr1[3].ToString();
                string EID = TextBox1.Text;
                String EName = dr1[3].ToString();
               // string TLID = dr1[6].ToString();

                con2.Open();
                cmd = new SqlCommand("select * from TLAttendanceDetails where TeamLeaderID='" + TextBox1.Text + "' and Date='" + date + "'", con2);
                dr2 = cmd.ExecuteReader();
                if (dr2.Read())
                {
                    Response.Redirect("TeamLeaderHome.aspx");
                }
                else
                {
                    con4.Open();
                    cmd = new SqlCommand("insert into TLAttendanceDetails values('" + TextBox1.Text + "','" + EName + "','" + date + "')", con4);
                    cmd.ExecuteNonQuery();
                    con4.Close();

                    Response.Redirect("TeamLeaderHome.aspx");
                }

                con2.Close();

            }
            else
            {
                Response.Write("<script>alert('Your Details are Not Verified')</script>");
            }
            con1.Close();
        }
        else
        {
            Response.Write("<script>alert('Invalid Data')</script>");
        }
        con.Close();
    }
}