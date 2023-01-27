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


public partial class EmployeeDailyUpdate : System.Web.UI.Page
{
    string TLID = null;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmployeeID"] != null && Session["EmployeeName"] != null)
        {
            TextBox1.Text = Session["EmployeeID"].ToString();
            TextBox2.Text = Session["EmployeeName"].ToString();
            TLID= Session["TLID"].ToString();
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


    private void EDU()
    {
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        con2.Open();
        cmd = new SqlCommand("select * from EDailyUpdates where EmployeeID='" + TextBox1.Text + "' and Date='" + date + "'", con2);
        dr2 = cmd.ExecuteReader();
        if (dr2.Read())
        {
            Response.Write("<script>alert('Already Updated')</script>");
        }
        else
        {
            con4.Open();
            cmd = new SqlCommand("insert into EDailyUpdates values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','"+TLID+"','" + date + "')", con4);
            cmd.ExecuteNonQuery();
            con4.Close();
            file();
            QRC();
            Response.Write("<script>alert('Submitted Successfully')</script>");
        }
        con2.Close();
    }

    
    private void QRC()
    {
        string date = DateTime.Now.ToString("dd-MM-yyyy");
        string fn = TLID + " " + date;

        char[] chararr = "0123456789786575342543365475927836465391827493687692748267500876987986564231343436576980996768645623".ToCharArray();
        string aes = string.Empty;
        Random obj = new Random();
        int noofcharacters = Convert.ToInt32(6);
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

        con5.Open();
        cmd = new SqlCommand("select * from QRCode where Name='" + fn + "'", con5);
        dr2 = cmd.ExecuteReader();
        if (dr2.Read())
        {
            
        }
        else
        {
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            var result = writer.Write(key);
            string path = Server.MapPath("~/QRCode/" + fn + ".jpg");
            var barcodeBitmap = new Bitmap(result);
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);

                    using (SqlCommand cmd0 = new SqlCommand())
                    {
                        cmd0.CommandText = "insert into QRCode(Name, ContentType, Data, FileKey) values (@Name, @ContentType, @Data, @Key)";
                        cmd0.Parameters.AddWithValue("@Name", fn);
                        cmd0.Parameters.AddWithValue("@ContentType", "image / jpg");
                        cmd0.Parameters.AddWithValue("@Data", bytes);
                        cmd0.Parameters.AddWithValue("@Key", key);
                        cmd0.Connection = con;
                        con.Open();
                        cmd0.ExecuteNonQuery();
                        con.Close();

                        con4.Open();
                        cmd = new SqlCommand("insert into Files values('" + fn + "','" + key + "','" + TLID + "','" + date + "')", con4);
                        cmd.ExecuteNonQuery();
                        con4.Close();
                    }
                }
            }
        }
        con5.Close();

              
    }
    private void file()
    {
        string date = DateTime.Now.ToString("dd-MM-yyyy");
        string fn = TLID + " " + date;
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
            sWriter.WriteLine("Employee ID : : : " + TextBox1.Text);
            sWriter.WriteLine();
            sWriter.WriteLine("Employee Name : : : " + TextBox2.Text);
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
            sWriter.WriteLine("Employee ID : : : " + TextBox1.Text);
            sWriter.WriteLine();
            sWriter.WriteLine("Employee Name : : : " + TextBox2.Text);
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
        EDU();
        
    }
}