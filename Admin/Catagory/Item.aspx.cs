using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Catagory_Item : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                Loaddata();
            }
        }
    }

    public void Loaddata()
    {
        string catagoryID = Request.QueryString["ID"];
        Catagory catagorybyid = Catagory.GetCatagoryBYID(Convert.ToInt16(catagoryID));
        this.txtName.Text = catagorybyid.CatagoryName;
       // this.ftbDescription.Text = catagorybyid.Description;

    }
    private void resetFields()
    {
        this.txtName.Text = string.Empty;
       // this.ftbDescription.Text = string.Empty;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Catagory catagory = new Catagory();
            catagory.CatagoryName = txtName.Text;
            catagory.Description = " ";
            List<Catagory> catagories = Catagory.GetCatagoryByName(txtName.Text.Trim());
           
            string catagoryID = Request.QueryString["ID"];
            if (string.IsNullOrEmpty(catagoryID))
            {
                if (catagories.Count==0)
                {
                    int rowAfected = Catagory.Save(catagory);
                    if (rowAfected > 0)
                    {
                        divMessage.Visible = true;
                        lblMeessage.Text = "Save Success";
                        resetFields();
                    }
                }
                else
                {
                    divMessage.Visible = true;
                    lblMeessage.Text = "Duplicate catagory";
                }
            }
            else
            {
                int id = Convert.ToInt16(catagoryID);
                Catagory catagorybyid = Catagory.GetCatagoryBYID(id);
                if (catagorybyid.CatagoryName == txtName.Text.Trim())
                {
                    catagory.CatagoryID = id;
                    int rowAfected = Catagory.Save(catagory);
                    if (rowAfected > 0)
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
                else
                {
                    if (catagories.Count == 0)
                    {
                        catagory.CatagoryID = id;
                        int rowAfected = Catagory.Save(catagory);
                        if (rowAfected > 0)
                        {
                            Response.Redirect("Default.aspx");
                        }
                    }
                    else
                    {
                        divMessage.Visible = true;
                        lblMeessage.Text = "Duplicate catagory";
                    }
                
                }
            }
        }
        catch(Exception ex)

        {
            divMessage.Visible = true;
            lblMeessage.Text = "Save failed"+ex.Message;
        }
    }
}
