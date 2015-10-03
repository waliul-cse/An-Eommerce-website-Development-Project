
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;

public partial class buyerInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void save()
    {
        BuyerInfo buyer = new BuyerInfo();
        buyer.Name = txtBillingName.Text;
        buyer.Email = txtBillingEmail.Text;
        buyer.Address = txtBillingAddress1.Text;
        buyer.CreatedDate = DateTime.Now;
        buyer.IsonlinePayment = false;
        buyer.IsSuccessful = false;
        BuyerInfo.Save(buyer);
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {   StringBuilder testmailBody = new StringBuilder("<html><body>");
            testmailBody.Append("<h1>").Append("Success").Append("</h1> </body></html>");


            string msgbody = "<div><h2>order Summery</h2></div>" + "<table border="+1+"><tr><td>Product name</td><td>Product quntity</td>" + "<td>UnitPrice </td><td> TotalPrice </td></tr>";
            int Totalprice = 0;

            List<CartItem> cartItems = ShoppingCart.Instance.Items;

            foreach (CartItem cartItem in cartItems)
            {
                Totalprice = Totalprice + cartItem.Quantity;
                msgbody = msgbody + "<tr><td>" + cartItem.Name + "</td><td>" + cartItem.Quantity + "</td>" + "<td>" + cartItem.UnitPrice + "</td>" + "<td>" + cartItem.TotalPrice + "</td></tr>";
            }
            msgbody = msgbody + "</table> </body></html>";
            StringBuilder mailBody = new StringBuilder(msgbody);
            MailMessage myMessage = new MailMessage();
            myMessage.IsBodyHtml = true;
            myMessage.Subject = "Your order has been placed successfully";
            myMessage.Body = testmailBody.ToString();

            myMessage.From = new MailAddress("vuaaddress@gmail.com");
            myMessage.To.Add(new MailAddress(txtBillingEmail.Text.Trim()));

            MailMessage myMessage1 = new MailMessage();
            SmtpClient mySmtpClient = new SmtpClient();
            myMessage1.Subject = "A manual order has been placed. ";
            myMessage1.Body = msgbody;
            myMessage1.IsBodyHtml = true;

            myMessage1.From = new MailAddress("vuaaddress@gmail.com");
            myMessage1.To.Add(new MailAddress(txtBillingEmail.Text.Trim()));
            mySmtpClient.EnableSsl = true;
            mySmtpClient.Send(myMessage);
            mySmtpClient.Send(myMessage1);
            save();
            Response.Redirect("~/Success.aspx");
       
       
    }
    protected void btnPaypalCheckout_Click(object sender, EventArgs e)
    {
        BuyerInfo buyer = new BuyerInfo();
        buyer.Name = txtBillingName.Text;
        buyer.Email = txtBillingEmail.Text;
        buyer.Address = txtBillingAddress1.Text;
        buyer.CreatedDate = DateTime.Now;
        buyer.IsonlinePayment = true;
        buyer.IsSuccessful = false;
        BuyerInfo.Save(buyer);
        Response.Redirect("~/Order.aspx");
    }
}
