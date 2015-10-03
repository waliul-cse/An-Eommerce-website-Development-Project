using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
        int firstCatagory = 0;
        List<Catagory> catagories= Catagory.GetCatagoryBySearch("");
        if (catagories.Count > 0)
        {
            firstCatagory = catagories.FirstOrDefault().CatagoryID;
        }
        List<Product> products = null;
        if (Request.QueryString["ID"] == null)
        {
            Page.Title = "Home";
            datListGeneral.DataSource = Product.GetProductByfeature().Take(9);
            datListGeneral.DataBind();
        }
        else
        {
            string productID = Request.QueryString["ID"];
            products = Product.GetProductByCatagoryID(Convert.ToInt32(productID));
            if (products.Count > 0)
            {
                Page.Title = products.FirstOrDefault().CatagoryName;
            }
        }

        datList.DataSource = products;
        datList.DataBind();

    }
    protected void datList_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        Label lblImage = e.Item.FindControl("lblImage") as Label;
        Image imgPicture = e.Item.FindControl("imgPicture") as Image;

        imgPicture.ImageUrl = "~/Uploads/" + lblImage.Text;

        Label lblID = e.Item.FindControl("lblID") as Label;
        
        HyperLink hplPID = e.Item.FindControl("hplPID") as HyperLink;
        HyperLink hplImage = e.Item.FindControl("hplImage") as HyperLink;
        hplPID.NavigateUrl = "~/DetailsProduct.aspx?ID=" + lblID.Text;
        hplImage.NavigateUrl = "~/DetailsProduct.aspx?ID=" + lblID.Text;
    }
    protected void datListGeneral_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        Label lblImage = e.Item.FindControl("lblImage") as Label;
        Image imgPicture = e.Item.FindControl("imgPicture") as Image;

        imgPicture.ImageUrl = "~/Uploads/" + lblImage.Text;
    }
}
