<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMasterPage.master"
    AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <h1>
            Shopping Cart</h1>
        <a href="Default.aspx">&lt; Back to Products</a>
        <br />
        <br />
        <asp:GridView runat="server" ID="gvShoppingCart" AutoGenerateColumns="false" EmptyDataText="There is nothing in your shopping cart."
            GridLines="None" Width="100%" CellPadding="5" ShowFooter="true" DataKeyNames="ProductId"
            OnRowDataBound="gvShoppingCart_RowDataBound" OnRowCommand="gvShoppingCart_RowCommand">
            <HeaderStyle HorizontalAlign="Left" BackColor="#3D7169" ForeColor="#FFFFFF" />
            <FooterStyle HorizontalAlign="Right" BackColor="#6C6B66" ForeColor="#FFFFFF" />
            <AlternatingRowStyle BackColor="#F8F8F8" />
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Description" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ID="txtQuantity" Columns="5" Text='<%# Eval("Quantity") %>'>1</asp:TextBox><br />
                        <asp:LinkButton runat="server" ID="btnRemove" Text="Remove" CommandName="Remove"
                            CommandArgument='<%# Eval("ProductId") %>' Style="font-size: 12px;"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblImage" Visible="false" runat="server" Text='<%# Eval("imageUrl") %>'></asp:Label>
                        <asp:Image runat="server" id="imgProduct"  AlternateText="" CssClass="thumbNormal" 
                            width="125" height="70" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UnitPrice" HeaderText="Price" ItemStyle-HorizontalAlign="Right"
                    HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:C}" />
                <asp:BoundField DataField="TotalPrice" HeaderText="Total" ItemStyle-HorizontalAlign="Right"
                    HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button runat="server" ID="btnUpdateCart" Text="Update Cart" OnClick="btnUpdateCart_Click" />
        
                <asp:Button runat="server" ID="btnCheckOut" Text="CheckOut" 
            onclick="btnCheckOut_Click" />
    </div>
</asp:Content>
