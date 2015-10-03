using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_faq : System.Web.UI.Page
{

    public int faqID
    {
        get
        {
            int faqID = Convert.ToInt32(ViewState["faqID"]);
            return faqID;
        }
        set
        {
            ViewState["faqID"] = value;
        }
    }
  
    protected void Page_Load(object sender, EventArgs e)
    {
        
            Page.Title = "Faq";
            LoadData();
          
        
    }
    public void LoadData()
    {
        grvList.DataSource = Faq.GetAllFaq();
        grvList.DataBind();
    
    }
    public void LoadFaqData()
    {
        Faq faq = Faq.GetFaqBYID(faqID);
        grvList.DataBind();

        txtQuestion.Text = faq.Question;
        txtAnswer.Text = faq.Answer;
        chkIsVisible.Checked = faq.IsVisible;

    }

    private void resetFields()
    {
        txtQuestion.Text = string.Empty;
        txtAnswer.Text = string.Empty;
        chkIsVisible.Checked=true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Faq faq = new Faq();
        faq.FaqID = faqID;
        faq.IsVisible = true;
        faq.Question = txtQuestion.Text;
        faq.Answer = txtAnswer.Text;
        faq.IsVisible = chkIsVisible.Checked;
       int affected= Faq.Save(faq);
       if (affected > 0)
       {
           divMessage.Visible = true;
           lblMessage.Text = "Save successfull";
           resetFields();
           LoadData();
       }

    }
    protected void grvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvList.PageIndex = e.NewPageIndex;
        LoadData();
    }
    protected void Edit_Command(object sender, CommandEventArgs e)
    {
       faqID=Convert.ToInt32 (e.CommandArgument);
       LoadFaqData();
    }
    protected void Delete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            int affectedRow = Faq.DeletebyID(Convert.ToInt16(e.CommandArgument));
            if (affectedRow > 0)
            {
                divMessage.Visible = true;
                lblMessage.Text = "Delate successfull";
                LoadData();
            }
        }
        catch
        {
            divMessage.Visible = true;
            lblMessage.Text = "Delate failed";

        }

    }
}
