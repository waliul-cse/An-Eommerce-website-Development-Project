<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMasterPage.master" AutoEventWireup="true" CodeFile="OrderOnline.aspx.cs" Inherits="OrderOnline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <form id="Paypal" name="Paypal" action="https://www.sandbox.paypal.com/cgi-bin/webscr"
    method="post">
    <input type="hidden" name="cmd" value="_cart" />
    <input type="hidden" name="upload" value="1" />
    <%
    	
        int m = 0;

        foreach (CartItem c in SelectedInvoice)
        {
            m++;
            Response.Write("<input type=\"hidden\" name=\"item_name_" + m + "\"  value=\"" + c.Name + "\" /> \r\n");
            Response.Write("<input type=\"hidden\" name=\"quantity_" + m + "\"   value=\"" + c.Quantity + "\" /> \r\n");
            Response.Write("<input type=\"hidden\" name=\"amount_" + m + "\"   value=\"" + c.UnitPrice + "\" /> \r\n");

        }

        
    %>

    <input type="hidden" name="return" value="<%Response.Write(return_url);%>" />
    <input type="hidden" name="cancel_return" value="<%Response.Write(cancel_url);%>" />
    <input type="hidden" name="shopping_url" value="<%Response.Write(return_url);%>" />
    <input type="hidden" name="notify_url" value="<%Response.Write(return_url);%>" />
    <input type="hidden" name="business" value="<%=System.Web.Configuration.WebConfigurationManager.AppSettings["paypalAccount"] %>" />
    <input type="hidden" name="return" value="<%=System.Web.Configuration.WebConfigurationManager.AppSettings["websiteUrl"] %>/payment_success.aspx" />
    <input type="hidden" name="cancel_return" value="<%=System.Web.Configuration.WebConfigurationManager.AppSettings["websiteUrl"] %>" />
    <input type="hidden" name="email" value="<%=System.Web.Configuration.WebConfigurationManager.AppSettings["paypalAccount"] %>" />
    <input type="hidden" name="cn" value="How did you hear about us?" />
    <input type="submit" value="Submit Payment Info" />
    </form>
         <script language="javascript" type="text/javascript">
        document.forms[1].submit();
    </script>
</asp:Content>

