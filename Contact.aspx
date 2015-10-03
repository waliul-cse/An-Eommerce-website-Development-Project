<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMasterPage.master"
    AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table runat="server" id="FormTable">
        <tr>
            <td colspan="3">
                <p >
                    Send your comments using the form below. Thank you</p>
            </td>
        </tr>
          <tr>
            <td colspan="3">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please correct the following errors before you press the Send button" />
            </td>
        </tr>
        <tr>
            <td >
               
            </td>
        </tr>
        <tr>
            <td >
            
            </td>
        </tr>
        <tr>
            <td >
               
            </td>
        </tr>
        <tr>
            <td>
                Your name
            </td>
            <td >
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                    ErrorMessage="Please enter your name">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td >
                Your e-mail address
            </td>
            <td >
                <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter an e-mail address"
                    ControlToValidate="txtEmailAddress" Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid e-mail address"
                    ControlToValidate="txtEmailAddress" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td >
                Your phone number&nbsp;
            </td>
            <td >
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName"
                    ErrorMessage="Please enter phone number">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td >
                Comment
            </td>
            <td>
                <asp:TextBox ID="txtComments" runat="server" Height="142px" TextMode="MultiLine"
                    Width="598px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter your query"
                    ControlToValidate="txtComments" Display="Dynamic">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td c>
           
            </td>
        </tr>
        <tr>
            <td >
               
            </td>
            <td >
                <asp:Button ID="btnSend" runat="server" Text="Send" onclick="btnSend_Click" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
      
    </table>
    <asp:Label ID="lblMessage" runat="server" Text="Message Sent" Visible="false"></asp:Label>
</asp:Content>
