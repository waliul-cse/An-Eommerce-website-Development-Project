using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {

        string[] users = { "Scott", "Admin", "anowar" };
        string[] passwords = { "password", "password", "anowar" };

        for (int i = 0; i < users.Length; i++)
        {
            bool validUsername = (string.Compare(txtUserName.Text, users[i],
    true) == 0);
            bool validPassword = (string.Compare(txtPassword.Text,
    passwords[i], false) == 0);

            if (validUsername && validPassword)
            {
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, RememberMe.Checked);
                Session["isMemberLoggedIn"] = true;
                Response.Redirect("~/Admin/Default.aspx");
            }
        }
        lblInvalidCredentialsMessage.Visible = true;
    }
    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {

    }
}
