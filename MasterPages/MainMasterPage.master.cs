using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPages_MainMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        rptMenu.DataSource = Catagory.GetCatagoryBySearch("");
        rptMenu.DataBind();
    }

    protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lblCatagory = e.Item.FindControl("lblCatagory") as Label;
        HyperLink hplMenu = e.Item.FindControl("hplMenu") as HyperLink;
        hplMenu.NavigateUrl = "~/Default.aspx?id=" + lblCatagory.Text;
     
    }
}
