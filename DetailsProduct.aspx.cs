using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DetailsProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int productID = 0;
            string Id = Request.QueryString["ID"];
            if (!string.IsNullOrEmpty(Id))
            {
                productID = Convert.ToInt16(Id);
            }
            if (productID > 0)
            {
                LoadData(productID);
            }
        }
    }
    public void LoadData(int productID)
    {
        Product product = Product.GetProductBYID(productID);
        lblName.Text = product.ProductName;
        hdnID.Value = (product.ProductID).ToString();

        List<string> imageUrl = product.ImageUrl.Split(',').ToList();

        List<ImageHelper> imageHelper = new List<ImageHelper>();

        foreach (string imageurl in imageUrl)
        {
            imageHelper.Add(new ImageHelper(imageurl,productID));
        }
        datList.DataSource = imageHelper;
        datList.DataBind();
        lblPrice.Text="Price:"+ product.price;
        ltrDescription.Text = product.ProductDescription;
        Page.Title = product.ProductName;

    }
    protected void Product_Command(object sender, CommandEventArgs e)
    {
      
        LinkButton lkProduct = sender as LinkButton;
        HiddenField hdnImage = lkProduct.FindControl("hdnImage") as HiddenField;
        TextBox txtQuantity = lkProduct.FindControl("txtQuantity") as TextBox;
        int Id = Convert.ToInt32(e.CommandArgument);
        string ImageUrl = hdnImage.Value;
     
        int quantity=Convert.ToInt32(txtQuantity.Text);
        ShoppingCart.Instance.AddItem(Id,quantity, ImageUrl);
        txtQuantity.Text = string.Empty;
    }
    protected void btnCart_Click(object sender, EventArgs e)
    {
        try
        {
            // LinkButton lkProduct = sender as LinkButton;
            // HiddenField hdnImage = lkProduct.FindControl("hdnImage") as HiddenField;
            // txtQuantity = lkProduct.FindControl("txtQuantity") as TextBox;
            int Id = Convert.ToInt32(hdnID.Value);
            // string ImageUrl = hdnImage.Value;

            int quantity = Convert.ToInt32(txtQuantity.Text);
            ShoppingCart.Instance.AddItem(Id, quantity, "asd");
            txtQuantity.Text = string.Empty;
        }
        catch
        { }
    }
}
