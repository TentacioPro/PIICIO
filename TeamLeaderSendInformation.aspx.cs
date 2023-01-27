using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;
using System.Net;
using System.Net.Mail;

public partial class TeamLeaderSendInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TeamLeaderID"] != null && Session["TeamLeaderName"] != null)
        {
            TextBox1.Text = Session["TeamLeaderID"].ToString();
            TextBox2.Text = Session["TeamLeaderName"].ToString();
        }
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CO"].ConnectionString.ToString());
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["CO"].ConnectionString.ToString());
    SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["CO"].ConnectionString.ToString());
    SqlConnection con3 = new SqlConnection(ConfigurationManager.ConnectionStrings["CO"].ConnectionString.ToString());
    SqlConnection con4 = new SqlConnection(ConfigurationManager.ConnectionStrings["CO"].ConnectionString.ToString());
    SqlCommand cmd;
    SqlDataAdapter da;
    DataTable dt = new DataTable();
    SqlDataReader dr;
    SqlDataReader dr1;
    SqlDataReader dr2;
    SqlDataReader dr3;
    DataSet ds = new DataSet();

    protected void Button1_Click(object sender, EventArgs e)
    {
        string date = DateTime.Now.ToString("dd-MM-yyyy");
        char[] chararr = "QWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
        string aes = string.Empty;
        Random obj = new Random();
        int noofcharacters = Convert.ToInt32(8);
        for (int i = 0; i < noofcharacters; i++)
        {
            int pos = obj.Next(1, chararr.Length);
            if (!aes.Contains(chararr.GetValue(pos).ToString()))
            {
                aes += chararr.GetValue(pos);
            }
            else
            {
                i--;
            }
        }
        string key = aes;
        string fn = TextBox1.Text + " " + key + " " + date;

        con4.Open();
        cmd = new SqlCommand("insert into SendInformation values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + fn + "','Manager','" + date + "')", con4);
        cmd.ExecuteNonQuery();
        con4.Close();

        var document = new Document(PageSize.A4, 25, 10, 25, 10);
        var output = new FileStream(Server.MapPath("~/PDFFiles/" + fn + ".pdf"), FileMode.Create);
        var writer = PdfWriter.GetInstance(document, output);
        document.Open();
        var welcomeParagraph = new Paragraph("TeamLeader ID : : " + TextBox1.Text + "\n" + "\n" + "TeamLeader Name : : " + TextBox2.Text + "\n" + "\n" + "Details : : " + "\n" + TextBox3.Text);
        document.Add(welcomeParagraph);
        document.Close();

        Response.Write("<script>alert('Information Sent')</script>");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if(TextBox4.Text=="")
        {
            Response.Write("<script>alert('Please Enter Employee ID')</script>");
        }
        else
        {
            con2.Open();
            cmd = new SqlCommand("select * from EmployeeDetails where EmployeeID='" + TextBox4.Text + "'", con2);
            dr2 = cmd.ExecuteReader();
            if (dr2.Read())
            {
                string date = DateTime.Now.ToString("dd-MM-yyyy");
                char[] chararr = "QWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
                string aes = string.Empty;
                Random obj = new Random();
                int noofcharacters = Convert.ToInt32(8);
                for (int i = 0; i < noofcharacters; i++)
                {
                    int pos = obj.Next(1, chararr.Length);
                    if (!aes.Contains(chararr.GetValue(pos).ToString()))
                    {
                        aes += chararr.GetValue(pos);
                    }
                    else
                    {
                        i--;
                    }
                }
                string key = aes;
                string fn = TextBox1.Text + " " + key + " " + date;

                con4.Open();
                cmd = new SqlCommand("insert into SendInformation values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + fn + "','" + TextBox4.Text + "','" + date + "')", con4);
                cmd.ExecuteNonQuery();
                con4.Close();

                var document = new Document(PageSize.A4, 25, 10, 25, 10);
                var output = new FileStream(Server.MapPath("~/PDFFiles/" + fn + ".pdf"), FileMode.Create);
                var writer = PdfWriter.GetInstance(document, output);
                document.Open();
                var welcomeParagraph = new Paragraph("TeamLeader ID : : " + TextBox1.Text + "\n" + "\n" + "TeamLeader Name : : " + TextBox2.Text + "\n" + "\n" + "Details : : " + "\n" + TextBox3.Text);
                document.Add(welcomeParagraph);
                document.Close();

                Response.Write("<script>alert('Information Sent')</script>");
            }
            else
            {
                Response.Write("<script>alert('Invalid EmployeeID')</script>");
            }

            con2.Close();
        }
    }
}