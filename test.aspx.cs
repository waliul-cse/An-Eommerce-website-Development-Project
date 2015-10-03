using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Product> products = Product.GetProductBySearch("", 9);
        List<ImageHelper> imageHelper = new List<ImageHelper>();
        foreach (Product product in products)
        {
            foreach (ImageHelper imageurl in product.TotalUrl)
            {
              //  imageHelper.Add(new ImageHelper(product.ProductName, imageurl.ImageUrl));
            }

        }
        Repeater1.DataSource = imageHelper;
        Repeater1.DataBind();

        List<Paypal_information> paypal_informations = Paypal_information.GetCountItem_id("1");

        int count = paypal_informations.Count;
    }

 
    protected void Repeater1_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        Label lblImage = e.Item.FindControl("lblImage") as Label;
        Image imgPicture = e.Item.FindControl("imgPicture") as Image;

        imgPicture.ImageUrl = "~/Uploads/" + lblImage.Text;
    }
  
}
