<%@ Page Title="" Language="C#" EnableEventValidation="false" ValidateRequest="false"
    MasterPageFile="~/MasterPages/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="Item.aspx.cs" Inherits="Admin_Catagory_Item" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h3 style="margin-left: 30px; margin-top:20px">
            Add/Edit Catagory</h3>
        <div id="divMessage" runat="server" visible="false" style="background-color: #F0F0F0;
            border: 1px solid #B2B2B2; margin-left: 30px; margin-top: 20px; height: 50px;">
            <h3 style="margin-left: 20px; margin-top: 20px;">
                <asp:Label ID="lblMeessage" runat="server" Text=""></asp:Label>
            </h3>
        </div>
    </div>
    <table style="margin-left: 30px">
        <tr>
            <td>
                Name
            </td>
            <td>
                :<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName"
                    runat="server" ErrorMessage="*" ValidationGroup="vGCatagory"></asp:RequiredFieldValidator>
            </td>
            <td align="left">
            </td>
        </tr>
       
        <tr>
            <td>
            </td>
            <td>
                <div>
                    <asp:Button ID="btnSave" CausesValidation="true" ValidationGroup="vGCatagory" runat="server"
                        Text="Save" OnClick="btnSave_Click" /></div>
            </td>
        </tr>
    </table>
</asp:Content>
