using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Contact";
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {

        if (Page.IsValid)
        {
            string fileName = Server.MapPath("~/App_Data/comment.txt");
            string mailBody = System.IO.File.ReadAllText(fileName);

            mailBody = mailBody.Replace("##Name##", txtName.Text);
            mailBody = mailBody.Replace("##Email##", txtEmailAddress.Text);
            mailBody = mailBody.Replace("##Phone##", txtPhone.Text);

            mailBody = mailBody.Replace("##Query##", txtComments.Text);

            MailMessage myMessage = new MailMessage();
            myMessage.Subject = "Response from web site";
            myMessage.Body = mailBody;

            myMessage.From = new MailAddress("librarymanageme@librarymanagementsystem.co.cc", "website");
            myMessage.To.Add(new MailAddress("amir@ahmed.com", "Amir Ahmed"));

           // myMessage.To.Add(new MailAddress("mobasshirice@gmail.com", "mobasshir Ahmad"));

            SmtpClient mySmtpClient = new SmtpClient();
            mySmtpClient.Send(myMessage);

            lblMessage.Visible = true;
            FormTable.Visible = false;

        }
    }
}
