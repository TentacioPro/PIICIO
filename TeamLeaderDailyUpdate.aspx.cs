using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZXing;
using System.Net;
using System.Net.Mail;

public partial class TeamLeaderDailyUpdate : System.Web.UI.Page
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
    SqlConnection con5 = new SqlConnection(ConfigurationManager.ConnectionStrings["CO"].ConnectionString.ToString());
    SqlCommand cmd;
    SqlDataAdapter da;
    DataTable dt = new DataTable();
    SqlDataReader dr;
    SqlDataReader dr1;
    SqlDataReader dr2;
    SqlDataReader dr3;
    DataSet ds = new DataSet();

    private void TDU()
    {
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        con2.Open();
        cmd = new SqlCommand("select * from TLDailyUpdates where TeamLeaderID='" + TextBox1.Text + "' and Date='" + date + "'", con2);
        dr2 = cmd.ExecuteReader();
        if (dr2.Read())
        {
            Response.Write("<script>alert('Already Updated')</script>");
        }
        else
        {
            con4.Open();
            cmd = new SqlCommand("insert into TLDailyUpdates values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + date + "')", con4);
            cmd.ExecuteNonQuery();
            con4.Close();
            file();
            Response.Write("<script>alert('Submitted Successfully')</script>");
        }
        con2.Close();
    }
    private void file()
    {
        string date = DateTime.Now.ToString("dd-MM-yyyy");
        string fn = TextBox1.Text + " " + date;
        string filePath = Server.MapPath("~/Files/" + fn + ".doc");
        string existfile = null;

        FileInfo file = new FileInfo(filePath);
        if (file.Exists)//check file exsit or not
        {
            StreamReader sr = new StreamReader(Server.MapPath("~/Files/" + fn + ".doc"));
            string read = sr.ReadToEnd();
            existfile = read;
            sr.Close();

            file.Delete();

            FileStream fStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter sWriter = new StreamWriter(fStream);
            sWriter.WriteLine(existfile);
            sWriter.WriteLine();
            sWriter.WriteLine();
            sWriter.WriteLine();
            sWriter.WriteLine("TeamLeader ID : : : " + TextBox1.Text);
            sWriter.WriteLine();
            sWriter.WriteLine("TeamLeader Name : : : " + TextBox2.Text);
            sWriter.WriteLine();
            sWriter.WriteLine("Work Details : :");
            sWriter.WriteLine(TextBox3.Text);
            sWriter.WriteLine();
            sWriter.WriteLine();
            sWriter.WriteLine("!!!**************************!!!");
            sWriter.WriteLine();
            sWriter.WriteLine();

            sWriter.Close();
            fStream.Close();

        }
        else
        {
            FileStream fStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter sWriter = new StreamWriter(fStream);
            sWriter.WriteLine("TeamLeader ID : : : " + TextBox1.Text);
            sWriter.WriteLine();
            sWriter.WriteLine("TeamLeader Name : : : " + TextBox2.Text);
            sWriter.WriteLine();
            sWriter.WriteLine("Work Details : :");
            sWriter.WriteLine(TextBox3.Text);
            sWriter.WriteLine();
            sWriter.WriteLine();
            sWriter.WriteLine("!!!**************************!!!");
            sWriter.WriteLine();
            sWriter.WriteLine();

            sWriter.Close();
            fStream.Close();
        }

    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        TDU();
    }
}