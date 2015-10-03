using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Catagory_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
        LoadDatainGrid();
    }
    public void LoadDatainGrid()
    {
        

        grvList.DataSource = Catagory.GetCatagoryBySearch(tbxSearch.Text.Trim());
        grvList.DataBind();
    }
    protected void btnClearSearch_Click(object sender, EventArgs e)
    {
        tbxSearch.Text = string.Empty;
        LoadDatainGrid();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadDatainGrid();

    }
    protected void grvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvList.PageIndex = e.NewPageIndex;
        grvList.DataSource = Catagory.GetCatagoryBySearch(tbxSearch.Text.Trim());
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
            int affectedRow = Catagory.DeletebyID(Convert.ToInt16(e.CommandArgument));
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
    protected void tbxSearch_TextChanged(object sender, EventArgs e)
    {

    }
}
