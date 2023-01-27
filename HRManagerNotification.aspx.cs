using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;
using System.Net;
using System.Net.Mail;

public partial class HRManagerNotification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        string a = gvrow.Cells[2].Text;

        string password = "manager";

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
        string fn = "HRManager" + "--" + key + "--" + date;

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