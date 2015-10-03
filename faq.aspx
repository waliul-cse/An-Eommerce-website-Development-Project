<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMasterPage.master"
    AutoEventWireup="true" CodeFile="faq.aspx.cs" Inherits="faq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin-left:40px; margin-top:30px;">
        <asp:DataList ID="datList" runat="server">
            <ItemTemplate>
                <table>
                    <tr>
                        <td valign="top">
                            <b>Q.</b><%# Container.ItemIndex + 1 %>
                        </td>
                        <td>
                            <%# Eval("Question")%>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <b>Ans.</b>
                        </td>
                        <td>
                            <%# Eval("Answer")%>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
