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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Net;
using System.Net.Mail;



public partial class HRManagerDailyUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
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
    private void dl()
    {
        con.Open();
        cmd = new SqlCommand("select FileName from Files order by ID desc", con);
        da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
        DropDownList1.DataTextField = "FileName";
        //  DropDownList1.DataValueField = "FileName";
        DropDownList1.DataBind();
        con.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Image1.ImageUrl = @"~/QRCode/" + DropDownList1.Text + ".jpg";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if(TextBox1.Text=="")
        {
            Response.Write("<script>alert('Please Enter Code')</script>");
        }
        else
        {
            con.Open();
            cmd = new SqlCommand("select * from QRCode where Name='"+DropDownList1.Text+"' and FileKey='"+TextBox1.Text+"'", con);
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                StreamReader sr = new StreamReader(Server.MapPath("~/Files/" + DropDownList1.Text + ".doc"));
                string read = sr.ReadToEnd();
               // TextBox4.Text = read;
                sr.Close();

                var document = new Document(PageSize.A4, 25, 10, 25, 10);
                var output = new FileStream(Server.MapPath("~/PDFFilesHR/" + DropDownList1.Text + ".pdf"), FileMode.Create);
                var writer = PdfWriter.GetInstance(document, output);
                document.Open();
                var welcomeParagraph = new Paragraph(read);
                document.Add(welcomeParagraph);
                document.Close();

                string date = DateTime.Now.ToString("dd-MM-yyyy");
                char[] chararr = "1234567890".ToCharArray();
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
                string fnn = "Manager-" + key+"-"+ date;

                Response.ContentType = ".pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fnn + ".pdf");
                Response.TransmitFile(Server.MapPath("~/PDFFilesHR/" + DropDownList1.Text + ".pdf"));
                Response.End();
            }
            else
            {
                Response.Write("<script>alert('Invalid Code')</script>");
            }
            con.Close();
        }
    }
}