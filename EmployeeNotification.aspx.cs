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


public partial class EmployeeNotification : System.Web.UI.Page
{
    string TLID = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmployeeID"] != null && Session["EmployeeName"] != null)
        {
            TextBox1.Text = Session["EmployeeID"].ToString();
            TextBox2.Text = Session["EmployeeName"].ToString();
            TLID = Session["TLID"].ToString();
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

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        string a = gvrow.Cells[2].Text;

        string password = null;

        con2.Open();
        cmd = new SqlCommand("select Password from EmployeeDetails where EmployeeID='" + TextBox1.Text + "'", con2);
        dr2 = cmd.ExecuteReader();
        if (dr2.Read())
        {
            password = dr2[0].ToString();
        }
        con2.Close();

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
        string fn = TextBox1.Text +"--"+TextBox2.Text+"--"+ key +"--"+ date;

        using (Stream input = new FileStream(Server.MapPath("~/PDFFiles/" + a + ".pdf"), FileMode.Open, FileAccess.Read, FileShare.Read))
        using (Stream output1 = new FileStream(Server.MapPath("~/PDFFilesP/" + a + ".pdf"), FileMode.Create, FileAccess.Write, FileShare.None))
        {
            PdfReader reader = new PdfReader(input);
            PdfEncryptor.Encrypt(reader, output1, true, password, "secret", PdfWriter.ALLOW_PRINTING);
        }

        Response.ContentType = ".pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fn + ".pdf");
        Response.TransmitFile(Server.MapPath("~/PDFFilesP/" + a + ".pdf"));
        Response.End();

    }
}