using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_Product_Item : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                rqrFuimage1.Visible = false;
                Loaddata();
            }
        }
    }
    public void Loaddata()
    {
        string productID = Request.QueryString["ID"];
        Product productbyid = Product.GetProductBYID(Convert.ToInt16(productID));
        ddlCatagory.SelectedValue = (productbyid.CatagoryID).ToString();
        txtName.Text = productbyid.ProductName;
        txtUnitPrice.Text = (productbyid.UnitPrice).ToString();
        chkVisible.Checked = (productbyid.IsVisible);
        Chkfeatured.Checked = productbyid.Isfeatured;
        chkOnsell.Checked = productbyid.IsOnsell;
        ChkNewProduct.Checked=productbyid.Isnewproduct;
        txtSaleprice.Text =( productbyid.Saleprice).ToString() ;
        txtQuantity.Text = (productbyid.Quantity).ToString();
        ftbDescription.Text = productbyid.ProductDescription;

        string imageUrl = productbyid.ImageUrl;
        string[] allImage = imageUrl.Split(',');

        int count = 0;
        foreach (string imageSource in allImage)
        {
            count++;
            if (count == 1)
            {
                imgProduct1.Visible = true;
                hdnImage1.Value = imageSource;
                imgProduct1.ImageUrl = "~/Uploads/" + imageSource;
            }

            if (count == 2)
            {
                imgProduct2.Visible = true;
                hdnImage2.Value = imageSource;
                imgProduct2.ImageUrl = "~/Uploads/" + imageSource;
            }
            if (count == 3)
            {
                imgProduct3.Visible = true;
                hdnImage3.Value = imageSource;
                imgProduct3.ImageUrl = "~/Uploads/" + imageSource;
            }

            if (count == 4)
            {
                imgProduct4.Visible = true;
                hdnImage4.Value = imageSource;
                imgProduct4.ImageUrl = "~/Uploads/" + imageSource;
            }
            if (count == 5)
            {
                imgProduct5.Visible = true;
                hdnImage5.Value = imageSource;
                imgProduct5.ImageUrl = "~/Uploads/" + imageSource;
            }
        }

    }
    private void resetFields()
    {
        ddlCatagory.SelectedValue = "-1";
        txtName.Text = string.Empty;
        txtUnitPrice.Text = string.Empty;
        chkVisible.Checked = true;
        txtQuantity.Text = string.Empty;
        ftbDescription.Text = string.Empty;
        Chkfeatured.Checked = false;
        chkOnsell.Checked = false;
        ChkNewProduct.Checked = false;
        txtSaleprice.Text = string.Empty;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int inValidCount = 0;
            if (fuImage1.HasFile)
            {
                int count = ImageUpload.imageUpload(fuImage1.PostedFile);
                inValidCount = inValidCount + count;
            }
            if (fuImage2.HasFile)
            {
                int count = ImageUpload.imageUpload(fuImage2.PostedFile);
                inValidCount = inValidCount + count;
            }
            if (fuImage3.HasFile)
            {
                int count = ImageUpload.imageUpload(fuImage3.PostedFile);
                inValidCount = inValidCount + count;
            }
            if (fuImage4.HasFile)
            {
                int count = ImageUpload.imageUpload(fuImage4.PostedFile);
                inValidCount = inValidCount + count;
            }
            if (fuImage5.HasFile)
            {
                int count = ImageUpload.imageUpload(fuImage5.PostedFile);
                inValidCount = inValidCount + count;
            }
            List<Product> products = Product.GetProductBYCatagoryIDAndProductName(txtName.Text.Trim(), Convert.ToInt32(ddlCatagory.SelectedValue));
            string productID = Request.QueryString["ID"];
            Product product = new Product();
            product.ProductName = txtName.Text.Trim();
            product.CatagoryID = Convert.ToInt16(ddlCatagory.SelectedValue);
            product.Quantity = Convert.ToInt32(txtQuantity.Text);
            product.UnitPrice = Convert.ToInt32(txtUnitPrice.Text);
            product.IsVisible = chkVisible.Checked;
            product.ProductDescription = ftbDescription.Text;
            if (!string.IsNullOrEmpty(txtSaleprice.Text))
            {
                product.Saleprice = Convert.ToInt32(txtSaleprice.Text);
            }
            product.Isnewproduct = ChkNewProduct.Checked;
            product.IsOnsell = chkOnsell.Checked;
            product.Isfeatured = Chkfeatured.Checked;
            if (inValidCount == 0)
            {
                if (string.IsNullOrEmpty(productID))
                {
                    if (products.Count == 0)
                    {

                        product.ImageUrl = imageUpload();
                        int rowaffected = Product.Save(product);
                        if (rowaffected > 0)
                        {
                            divMessage.Visible = true;
                            lblMeessage.Text = "Save success";
                            resetFields();
                        }

                    }
                    if (products.Count > 0)
                    {
                        divMessage.Visible = true;
                        lblMeessage.Text = "Duplicate record";
                    }
                  
                }
                else
                {
                    int id = Convert.ToInt16(productID);
                    Product productbyid = Product.GetProductBYID(id);
                    product.ImageUrl = productbyid.ImageUrl;
                    if (productbyid.ProductName == txtName.Text.Trim())
                    {
                        product.ProductID = id;
                        product.ImageUrl = imageUpload();
                        int rowAfected = Product.Save(product);
                        if (rowAfected > 0)
                        {
                            Response.Redirect("Default.aspx");
                        }
                    }
                    else
                    {
                        if (products.Count == 0)
                        {
                            product.ImageUrl = imageUpload();
                            product.ProductID = id;
                            int rowAfected = Product.Save(product);
                            if (rowAfected > 0)
                            {
                                Response.Redirect("Default.aspx");
                            }
                        }
                        else
                        {
                            divMessage.Visible = true;
                            lblMeessage.Text = "Duplicate Product";
                        }

                    }
                }
            }
            else
            {
                divMessage.Visible = true;

                lblMeessage.Text = "Invalid image or  small";
            }
        }

        catch { }
    }
    public string imageUpload()
    {
        string path = null;
        if (fuImage1.HasFile)
        {
            string filename = HttpUtility.HtmlEncode(fuImage1.FileName.ToLower());
            string extension = Path.GetExtension(filename);

            string filePath = Path.Combine(Server.MapPath("~/Uploads"),
                                           Path.GetFileName(ddlCatagory.SelectedValue + txtName.Text + "1" + extension));
            fuImage1.SaveAs(filePath);
            path = ddlCatagory.SelectedValue + txtName.Text + "1" + extension;
        }
        else if (!string.IsNullOrEmpty(hdnImage1.Value))
        {
            path = hdnImage1.Value;
        }
        if (fuImage2.HasFile)
        {
            string filename = HttpUtility.HtmlEncode(fuImage2.FileName.ToLower());
            string extension = Path.GetExtension(filename);

            string filePath = Path.Combine(Server.MapPath("~/Uploads"),
                                           Path.GetFileName(ddlCatagory.SelectedValue + txtName.Text + "2" + extension));
            fuImage2.SaveAs(filePath);
            path = path + "," + ddlCatagory.SelectedValue + txtName.Text + "2" + extension;
        }
        else if (!string.IsNullOrEmpty(hdnImage2.Value))
        {
            path = path + "," + hdnImage2.Value;
        }
        if (fuImage3.HasFile)
        {
            string filename = HttpUtility.HtmlEncode(fuImage3.FileName.ToLower());
            string extension = Path.GetExtension(filename);

            string filePath = Path.Combine(Server.MapPath("~/Uploads"),
                                           Path.GetFileName(ddlCatagory.SelectedValue + txtName.Text + "3" + extension));
            fuImage3.SaveAs(filePath);
            path = path + "," + ddlCatagory.SelectedValue + txtName.Text + "3" + extension;
        }
        else if (!string.IsNullOrEmpty(hdnImage3.Value))
        {
            path = path + "," + hdnImage3.Value;
        }
        if (fuImage4.HasFile)
        {
            string filename = HttpUtility.HtmlEncode(fuImage4.FileName.ToLower());
            string extension = Path.GetExtension(filename);

            string filePath = Path.Combine(Server.MapPath("~/Uploads"),
                                           Path.GetFileName(ddlCatagory.SelectedValue + txtName.Text + "4" + extension));
            fuImage4.SaveAs(filePath);
            path = path + "," + ddlCatagory.SelectedValue + txtName.Text + "4" + extension;
        }
        else if (!string.IsNullOrEmpty(hdnImage4.Value))
        {
            path = path + "," + hdnImage4.Value;
        }
        if (fuImage5.HasFile)
        {
            string filename = HttpUtility.HtmlEncode(fuImage5.FileName.ToLower());
            string extension = Path.GetExtension(filename);

            string filePath = Path.Combine(Server.MapPath("~/Uploads"),
                                           Path.GetFileName(ddlCatagory.SelectedValue + txtName.Text + "5" + extension));
            fuImage5.SaveAs(filePath);
            path = path + "," + ddlCatagory.SelectedValue + txtName.Text + "5" + extension;
        }
        else if (!string.IsNullOrEmpty(hdnImage5.Value))
        {
            path = path + "," + hdnImage5.Value;
        }

        return path;
    }
}
