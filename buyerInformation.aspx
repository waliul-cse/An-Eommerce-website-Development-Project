<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMasterPage.master"
    AutoEventWireup="true" CodeFile="buyerInformation.aspx.cs" Inherits="buyerInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <b>Billing Info:</b>
    <table>
        <tr>
            <td style="width: 148px">
                Your FULL Name *
            </td>
            <td>
                <asp:TextBox ID="txtBillingName" runat="server" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" ErrorMessage="Your FULL Name  is REQUIRED"
                    ControlToValidate="txtBillingName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 148px">
                Phone *
            </td>
            <td>
                <asp:TextBox ID="txtBillingPhone" runat="server" MaxLength="25"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqPhone" runat="server" ErrorMessage="Billing Phone # is REQUIRED"
                    ControlToValidate="txtBillingPhone"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 148px">
                Email *
            </td>
            <td>
                <asp:TextBox ID="txtBillingEmail" runat="server" MaxLength="255" Width="222px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqEmail" runat="server" ErrorMessage="Billing Email  is REQUIRED"
                    ControlToValidate="txtBillingEmail"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ErrorMessage="Billing Email doesn't look right."
                    ControlToValidate="txtBillingEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*[ ]*$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 148px">
                Address *
            </td>
            <td>
                <asp:TextBox ID="txtBillingAddress1" Width="300px" runat="server" Height="52px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="server" ErrorMessage="Billing Address is REQUIRED"
                    ControlToValidate="txtBillingAddress1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnCheck" runat="server" Text="Place order manually" OnClick="btnCheck_Click" />
            </td>
            <td>
                <asp:Button ID="btnPaypalCheckout"  CausesValidation="false" runat="server" Text="Pay Pal Checkout >>" OnClick="btnPaypalCheckout_Click">
                </asp:Button>
            </td>
        </tr>
        <tr><td><asp:Label ForeColor="Red" ID="lblmessage" runat="server" Text=""></asp:Label></td><td><h3></h3></td></tr>
    </table>
</asp:Content>
