using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Order : System.Web.UI.Page
{

    protected String return_url = ConfigurationManager.AppSettings["ReturnUrl"];
    protected String cancel_url = ConfigurationManager.AppSettings["CancelPurchaseUrl"];

    public List<CartItem> SelectedInvoice
    {
        get
        {
            List<CartItem> c = null;
             try
                {
                     c= ShoppingCart.Instance.Items;
                }
                catch { }
         
            return c;
        }
    }
  
    protected void Page_Load(object sender, EventArgs e)
    {
       // List<ShoppingCart.Items> c = (ShoppingCart.Instance.Items)HttpContext.Current.Session["ASPNETShoppingCart"];
        //Session["st"] = _selectedInvoice.Items;
    }

}
