<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Processing Paypal ...</title>
</head>
<body onload="document.Paypal.submit();">
    <!-- item_number should get passed back -->
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

 <%--   <input type="hidden" name="return" value="<%Response.Write(return_url);%>" />--%>
    <input type="hidden" name="cancel_return" value="<%Response.Write(cancel_url);%>" />
    <input type="hidden" name="shopping_url" value="<%Response.Write(return_url);%>" />
    <input type="hidden" name="notify_url" value="<%Response.Write(return_url);%>" />
    <input type="hidden" name="business" value="<%=System.Web.Configuration.WebConfigurationManager.AppSettings["paypalAccount"] %>" />
<%--    <input type="hidden" name="return" value="<%=System.Web.Configuration.WebConfigurationManager.AppSettings["websiteUrl"] %>/payment_success.aspx" />--%>
    <input type="hidden" name="cancel_return" value="<%=System.Web.Configuration.WebConfigurationManager.AppSettings["websiteUrl"] %>" />
    <input type="hidden" name="email" value="<%=System.Web.Configuration.WebConfigurationManager.AppSettings["paypalAccount"] %>" />
    <input type="hidden" name="cn" value="How did you hear about us?" />
    <input type="submit" value="Submit Payment Info" />
    </form>
 
</body>
</html>
