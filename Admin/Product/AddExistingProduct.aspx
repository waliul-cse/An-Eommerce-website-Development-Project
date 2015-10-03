<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.master"
    AutoEventWireup="true" CodeFile="AddExistingProduct.aspx.cs" Inherits="Admin_Product_AddExistingProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h3 style="margin-left: 30px; margin-top: 20px">
            Add/Edit Product</h3>
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
                Select Catagory
            </td>
            <td>
                :<mobasshir:CatgoryDropdown UseFirstItem="true" AutoPostBack="true" ID="ddlCatagory" 
                    runat="server" onselectedindexchanged="ddlCatagory_SelectedIndexChanged">
                </mobasshir:CatgoryDropdown>
                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator1" ControlToValidate="ddlCatagory"
                    runat="server" ErrorMessage="*" ValidationGroup="vGProduct"></asp:RequiredFieldValidator>
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td>
                Select product
            </td>
            <td>
                :<asp:DropDownList ID="ddlproduct" runat="server" >
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlproduct"
                    runat="server" ErrorMessage="*" ValidationGroup="vGProduct"></asp:RequiredFieldValidator>
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td>
                Quantity
            </td>
            <td>
                :<asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtQuantity"
                    runat="server" ErrorMessage="*" ValidationGroup="vGProduct"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cgn" runat="server" ErrorMessage="Invalid" ValidationGroup="vGProduct"
                    ControlToValidate="txtQuantity" Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <div>
                    <asp:Button ID="btnSave" CausesValidation="true" ValidationGroup="vGProduct" runat="server"
                        Text="Save" onclick="btnSave_Click" /></div>
            </td>
        </tr>
    </table>
</asp:Content>
