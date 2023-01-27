using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class TeamLeaderEmployeeUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TeamLeaderID"] != null && Session["TeamLeaderName"] != null)
        {
            TextBox1.Text = Session["TeamLeaderID"].ToString();
            TextBox2.Text = Session["TeamLeaderName"].ToString();
        }
        if(!Page.IsPostBack)
        {
            captcha();
            dl();
        }
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

    private void captcha()
    {
        try
        {
            Random random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
            Session["captcha"] = captcha.ToString();
            imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {
            throw;
        }
    }

    private void dl()
    {
        con.Open();
        cmd = new SqlCommand("select FileName from Files where TeamLeaderID='"+TextBox1.Text+"' order by ID desc", con);
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
        DropDownList1.DataTextField = "FileName";
        //  DropDownList1.DataValueField = "FileName";
        DropDownList1.DataBind();
        con.Close();
    }

    protected void Refresh_Click(object sender, EventArgs e)
    {
        captcha();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(TextBox3.Text=="")
        {
            Response.Write("<script>alert('Please Enter Captcha')</script>");
        }
        else
        {
            if (Session["captcha"].ToString() != TextBox3.Text)
            {
                Response.Write("<script>alert('Invalid Captcha Code')</script>");
            }
            else
            {
                StreamReader sr = new StreamReader(Server.MapPath("~/Files/" + DropDownList1.Text + ".doc"));
                string read = sr.ReadToEnd();
                TextBox4.Text = read;
                sr.Close();
            }
        }
        
        captcha();
    }
}