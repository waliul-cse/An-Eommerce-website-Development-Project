<%@ Page Title="" Language="C#" EnableEventValidation="false" ValidateRequest="false"
    MasterPageFile="~/MasterPages/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Admin_Catagory_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="filter">
        <table width="100%" cellspacing="5" cellpadding="5">
            <tr align="left">
                <td>
                    <table>
                        <tr>
                            <td>
                                Name
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="tbxSearch" runat="server" CssClass="text_control" OnTextChanged="tbxSearch_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr align="right">
                <td style="height: 31px">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="admin_button" OnClick="btnSearch_Click" />
                    <asp:Button ID="btnClearSearch" runat="server" Text="Clear Search" CssClass="admin_button"
                        OnClick="btnClearSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
  
       <div ID="divMessage" runat="server"  visible="false"  style="background-color: #F0F0F0; border: 1px solid #B2B2B2;  margin-top: 20px;
        height: 50px;">
        <h3 style="margin-left:20px; margin-top: 20px;">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </h3>

    </div>
    <div id="list">
        <div class="row">
            <asp:GridView Width="100%" ID="grvList" AutoGenerateColumns="false" runat="server"
                AllowPaging="True" OnPageIndexChanging="grvList_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            ID
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("CatagoryID")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Name
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("CatagoryName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                 
                    <asp:TemplateField>
                        <ItemStyle Width="50" HorizontalAlign="Center" />
                        <HeaderTemplate>
                            Edit
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnCommand="Edit_Command" CommandArgument='<%# Eval("CatagoryID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemStyle Width="50" HorizontalAlign="Center" />
                        <HeaderTemplate>
                            Delete
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" OnClientClick="javascript:return confirm('Warning: This will remove your Product under this Catagory. ');"
                                runat="server" Text="Delete" OnCommand="Delete_Command" CommandArgument='<%# Eval("CatagoryID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
