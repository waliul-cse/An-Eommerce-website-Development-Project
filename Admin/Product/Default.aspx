<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPages/AdminMasterPage.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Product_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="filter">
        <table width="100%" cellspacing="5" cellpadding="5">
            <tr align="left">
                <td>
                    <table>
                        <tr>
                            <td>
                                Catagory
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <mobasshir:CatgoryDropdown runat="server" ID="ddlCatagroy" UseFirstItem="true">
                                </mobasshir:CatgoryDropdown>
                            </td>
                            <td>
                                Name
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="tbxSearch" runat="server" CssClass="text_control"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr align="right">
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="admin_button" OnClick="btnSearch_Click" />
                    <asp:Button ID="btnClearSearch" runat="server" Text="Clear Search" CssClass="admin_button"
                        OnClick="btnClearSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div id="divMessage" runat="server" visible="false" style="background-color: #F0F0F0;
        border: 1px solid #B2B2B2; margin-top: 20px; height: 50px;">
        <h3 style="margin-left: 20px; margin-top: 20px;">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </h3>
    </div>
    <div id="list">
        <div class="row">
            <asp:GridView Width="100%" ID="grvList" AutoGenerateColumns="false" runat="server"
                AllowPaging="True" OnPageIndexChanging="grvList_PageIndexChanging" OnRowDataBound="grvList_RowDataBound">
                <Columns>
                    <asp:TemplateField Visible="false">
                        <HeaderTemplate>
                            ID
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblImageUrl" Visible="false" runat="server" Text='<%# Eval("ImageUrl")%>'></asp:Label>
                            <%# Eval("ProductID")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                            Name
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("ProductName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                            price
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("UnitPrice")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                      <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                           Quantity
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Quantity")%>
                        </ItemTemplate>
                    </asp:TemplateField>                   
                        <asp:TemplateField>
                      <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                           Saleprice
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Saleprice")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField>
                      <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                           featured
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Isfeatured")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField>
                      <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                           New
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Isnewproduct")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField>
                      <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                           On sale
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("IsOnsell")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField>
                      <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                            Image1
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Image AlternateText="Image" Width="70px" Height="60px" ID="imgProduct1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                            Image2
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Image AlternateText="Image" Width="70px" Height="60px" ID="imgProduct2" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                            Image3
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Image AlternateText="Image" Width="70px" Height="60px" ID="imgProduct3" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField >
                      <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                            Image4
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Image AlternateText="Image" Width="70px" Height="60px" ID="imgProduct4" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField >
                      <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                            Image5
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Image AlternateText="Image" Width="70px" Height="60px" ID="imgProduct5" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Visible
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("IsVisible")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                            Edit
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnCommand="Edit_Command" CommandArgument='<%# Eval("ProductID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                            Delete
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" OnClientClick="javascript:return confirm('Warning: Are you sure? ');"
                                runat="server" Text="Delete" OnCommand="Delete_Command" CommandArgument='<%# Eval("ProductID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
