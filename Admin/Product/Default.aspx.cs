using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Product_Default : System.Web.UI.Page
{
    public int catgoryID
    {
        get;
        set;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDatainGrid();
    }

    public void LoadDatainGrid()
    {
        if (catgoryID == -1)
        {
            catgoryID = 0;
        }
        grvList.DataSource = Product.GetProductBySearch(tbxSearch.Text.Trim(),catgoryID);
        grvList.DataBind();
    }
     protected void btnClearSearch_Click(object sender, EventArgs e)
    {
        tbxSearch.Text = string.Empty;
        ddlCatagroy.SelectedValue = "-1";
        LoadDatainGrid();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
     {
        catgoryID = Convert.ToInt32(ddlCatagroy.SelectedValue);
        LoadDatainGrid();

    }
    protected void grvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {


        
        grvList.PageIndex = e.NewPageIndex;
        grvList.DataSource = Product.GetProductBySearch(tbxSearch.Text.Trim(), catgoryID);
        grvList.DataBind();
    }
    protected void Edit_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("Item.aspx?id=" + e.CommandArgument.ToString());
    }
    protected void Delete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            int affectedRow = Product.DeletebyID(Convert.ToInt16(e.CommandArgument));
            if (affectedRow > 0)
            {
                divMessage.Visible = true;
                lblMessage.Text = "Delate successfull";
                LoadDatainGrid();
            }
        }
        catch
        {
            divMessage.Visible = true;
            lblMessage.Text = "Delate failed";

        }
    }
    protected void grvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
        {

            Label lblImageUrl = e.Row.FindControl("lblImageUrl") as Label;
            Image imgProduct1 = e.Row.FindControl("imgProduct1") as Image;
            Image imgProduct2 = e.Row.FindControl("imgProduct2") as Image;
            Image imgProduct3 = e.Row.FindControl("imgProduct3") as Image;
            Image imgProduct4 = e.Row.FindControl("imgProduct4") as Image;
            Image imgProduct5 = e.Row.FindControl("imgProduct5") as Image;

            string imageUrl = lblImageUrl.Text;
            string[] allImage = imageUrl.Split(',');

            int count = 0;
            foreach (string imageSource in allImage)
            {
                count++;
                if (count == 1)
                {
                    imgProduct1.ImageUrl = "~/Uploads/" + imageSource;
                }
               
                if (count == 2)
                {
                    imgProduct2.ImageUrl = "~/Uploads/" + imageSource;
                }
                if (count == 3)
                {
                    imgProduct3.ImageUrl = "~/Uploads/" + imageSource;
                }
            
                if (count == 4)
                {
                    imgProduct4.ImageUrl = "~/Uploads/" + imageSource;
                }
                if (count == 5)
                {
                    imgProduct5.ImageUrl = "~/Uploads/" + imageSource;
                }
            }
        }
    }
}
