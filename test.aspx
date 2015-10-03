<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.master"
    AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <asp:DataList ID="Repeater1" runat="server"   
        onitemdatabound="Repeater1_ItemDataBound" RepeatColumns="3">
      <ItemTemplate>
        <table> <tr><td><%# Eval("Productname")%></td></tr>
        <tr><td>
            <asp:Label ID="lblImage" runat="server" Visible="false" Text='<%# Eval("ImageUrl")%>'></asp:Label>
            <asp:Image ID="imgPicture" runat="server" Height="160px" Width="200px" /></td></tr>
        </table>         
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
