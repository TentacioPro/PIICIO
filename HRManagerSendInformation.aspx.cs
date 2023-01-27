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


public partial class HRManagerSendInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
        if (TextBox2.Text == "")
        {
            Response.Write("<script>alert('Please Enter TeamLeaderID')</script>");
        }
        else
        {
            con2.Open();
            cmd = new SqlCommand("select * from TeamLeaderDetails where EmployeeID='" + TextBox2.Text + "'", con2);
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
                string fn = "HRManager" + " " + key + " " + date;

                con4.Open();
                cmd = new SqlCommand("insert into SendInformation values('HRManager','HRManager','" + TextBox1.Text + "','" + fn + "','" + TextBox2.Text + "','" + date + "')", con4);
                cmd.ExecuteNonQuery();
                con4.Close();

                var document = new Document(PageSize.A4, 25, 10, 25, 10);
                var output = new FileStream(Server.MapPath("~/PDFFiles/" + fn + ".pdf"), FileMode.Create);
                var writer = PdfWriter.GetInstance(document, output);
                document.Open();
                var welcomeParagraph = new Paragraph("Name : : " + "HR Manager" + "\n" + "\n" + "Details : : " + "\n" + TextBox1.Text);
                document.Add(welcomeParagraph);
                document.Close();

                Response.Write("<script>alert('Information Sent')</script>");
            }
            else
            {
                Response.Write("<script>alert('Invalid TeamLeaderID')</script>");
            }

            con2.Close();
        }
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text == "")
        {
            Response.Write("<script>alert('Please Enter EmployeeID')</script>");
        }
        else
        {
            con2.Open();
            cmd = new SqlCommand("select * from EmployeeDetails where EmployeeID='" + TextBox3.Text + "'", con2);
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
                string fn = "HRManager" + " " + key + " " + date;

                con4.Open();
                cmd = new SqlCommand("insert into SendInformation values('HRManager','HRManager','" + TextBox1.Text + "','" + fn + "','" + TextBox3.Text + "','" + date + "')", con4);
                cmd.ExecuteNonQuery();
                con4.Close();

                var document = new Document(PageSize.A4, 25, 10, 25, 10);
                var output = new FileStream(Server.MapPath("~/PDFFiles/" + fn + ".pdf"), FileMode.Create);
                var writer = PdfWriter.GetInstance(document, output);
                document.Open();
                var welcomeParagraph = new Paragraph("Name : : " + "HR Manager" + "\n" + "\n" + "Details : : " + "\n" + TextBox1.Text);
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