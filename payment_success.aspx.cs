using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Net;
using System.Text;
using System.Net.Mail;

public partial class payment_success : System.Web.UI.Page
{
    public void Save()
    {
     
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        //Post back to either sandbox or live
        string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
        //string strLive = "https://www.paypal.com/cgi-bin/webscr";
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strSandbox);

        //Set values for the request back
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";
        byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
        string strRequest = Encoding.ASCII.GetString(param);
        strRequest += "&cmd=_notify-validate";
        req.ContentLength = strRequest.Length;

        //Send the request to PayPal and get the response
        StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
        streamOut.Write(strRequest);
        streamOut.Close();
        StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
        string strResponse = streamIn.ReadToEnd();
        streamIn.Close();

        if (strResponse == "VERIFIED")
        {
            string txn_id = Request.Form["txn_id"];
            //check the payment_status is Completed
            //check that txn_id has not been previously processed
            //check that receiver_email is your Primary PayPal email
            //check that payment_amount/payment_currency are correct
            //process payment

            List<Paypal_information> paypal_informations = Paypal_information.GetCountItem_id(txn_id);
            if (paypal_informations.Count == 0)
            {

                int count = paypal_informations.Count;
                string payment_status = Request.Form["payment_status"];
                string business = Request.Form["business"];
                String paypalAccount = ConfigurationManager.AppSettings["paypalAccount"];
                if (payment_status == "Completed" && paypalAccount == business)
                {

                   
                    string payment_date = Request.Form["payment_date"];
                    string payer_email = Request.Form["payer_email"];

                    string item_number = Request.Form["item_number"];
                    string item_name = Request.Form["item_name"];

                    string mc_gross = Request.Form["mc_gross"];
                    string first_name = Request.Form["first_name"];
                    string last_name = Request.Form["last_name"];
                    string address_street = Request.Form["address_street"];
                    string address_city = Request.Form["address_city"];
                    string address_state = Request.Form["address_state"];
                    string address_zip = Request.Form["address_zip"];
                    string address_country = Request.Form["address_country"];




                    string table = "<table border=1><tr><td>txn_id</td><td>payment_date</td><td>payer_email</td><td>mc_gross</td></tr><tr><td>" + txn_id + "</td><td>" + payment_date + "</td><td>" + payer_email + "</td><td>" + mc_gross + "</td></tr></table>";
                    string address = "first name:" + first_name + "last name:" + last_name + ",address street" + address_street + ",address city" + address_city + ",address_state" + address_state + ",Zipcode=" + address_zip + ",address_country=" + address_country;




                    MailMessage myMessage1 = new MailMessage();
                    SmtpClient mySmtpClient = new SmtpClient();
                    myMessage1.Subject = "A online  order has been placed. ";
                    myMessage1.Body = table + "<h3>address</h3><br />" + address;
                    myMessage1.IsBodyHtml = true;

                    myMessage1.From = new MailAddress("vuaaddress@gmail.com");
                    mySmtpClient.EnableSsl = true;
                    myMessage1.To.Add(new MailAddress("amir@ahmed.com"));
                    mySmtpClient.Send(myMessage1);

                    MailMessage myMessage2 = new MailMessage();
                    SmtpClient mySmtpClient2 = new SmtpClient();
                    myMessage2.Subject = "your order  has been successfully placed. ";
                    myMessage2.Body = "<h3>Your order summery</h3><br />" + table;
                    myMessage2.IsBodyHtml = true;

                    myMessage2.From = new MailAddress("vuaaddress@gmail.com");
                    myMessage2.To.Add(new MailAddress("mobasshirice@gmail.com"));
                    mySmtpClient2.EnableSsl = true;
                    mySmtpClient2.Send(myMessage2);



                    //save to db

                    Paypal_information paypal = new Paypal_information();
                    paypal.txn_id = txn_id;
                    paypal.payment_date = DateTime.Now;
                    paypal.payer_email = payer_email;
                    paypal.item_number = 1;
                    paypal.item_name = "g";
                    paypal.mc_gross = 123;// gross problem
                    paypal.Address = address;
                    Paypal_information.Save(paypal);

                    //

                    List<CartItem> cartItems = ShoppingCart.Instance.Items;
                    foreach (CartItem cartItem in cartItems)
                    {
                        ShoppingCart.Instance.RemoveItem(cartItem.ProductId, cartItem.imageUrl);
                    }
                }
            }
        }
        else if (strResponse == "INVALID")
        {
    

            MailMessage myMessage1 = new MailMessage();
            SmtpClient mySmtpClient = new SmtpClient();
            myMessage1.Subject = "invalid ";
            myMessage1.Body = "ipn test invalid";
            myMessage1.IsBodyHtml = true;

            myMessage1.From = new MailAddress("vuaaddress@gmail.com");
            myMessage1.To.Add(new MailAddress("mobasshirice@gmail.com"));
            mySmtpClient.EnableSsl = true;
            mySmtpClient.Send(myMessage1);

        }
        else
        {
            //log response/ipn data for manual investigation
        }

    }
}

