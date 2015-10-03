using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Product_AddExistingProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddlCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlproduct.DataSource = Product.GetProductByCatagoryID(Convert.ToInt32(ddlCatagory.SelectedValue));
        ddlproduct.DataValueField = "ProductID";
        ddlproduct.DataTextField = "ProductName";
        ddlproduct.DataBind();
    }
    private void resetFields()
    {
        ddlCatagory.SelectedValue = "-1";
        //ddlproduct.s = string.Empty;
        txtQuantity.Text = string.Empty;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Product products = Product.GetProductBYCatagoryIDAndProductID(Convert.ToInt32(ddlCatagory.SelectedValue), Convert.ToInt32(ddlproduct.SelectedValue));

            Product product = new Product();
            product.ProductID = products.ProductID;
            product.ProductName = products.ProductName;
            product.CatagoryID = Convert.ToInt16(ddlCatagory.SelectedValue);
            product.Quantity = Convert.ToInt32(txtQuantity.Text) + products.Quantity;
            product.UnitPrice = products.UnitPrice;
            product.IsVisible = products.IsVisible;
            product.ImageUrl = products.ImageUrl;
            product.ProductDescription = products.ProductDescription;

            product.Saleprice = products.Saleprice;

            product.Isnewproduct = products.Isnewproduct;
            product.IsOnsell = products.IsOnsell;
            product.Isfeatured = products.Isfeatured;
            Product.Save(product);
            divMessage.Visible = true;
            lblMeessage.Text = "Save success";
            resetFields();
        }
        catch
        {
            divMessage.Visible = true;
            lblMeessage.Text = "Save failed";
        }
    }
}
