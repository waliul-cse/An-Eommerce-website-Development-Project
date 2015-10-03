<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMasterPage.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="divFeaturedItem">
        <div style="color: #369DC6">
            featured items</div>
        <div style="width: 100%">
            <asp:DataList Width="100%" ID="datList" runat="server" OnItemDataBound="datList_ItemDataBound"
                RepeatColumns="1">
                <ItemTemplate>
                    <hr class="Datahr" />
                    <table width="100%">
                        <tr>
                            <td valign="top">
                                <div>
                                    <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("ProductID")%>'></asp:Label>
                                    <p style="font-size: larger">
                                        <%# Eval("Productname")%></p>
                                </div>
                                <div>
                                    <%# Eval("MiniMizeDescription")%><asp:HyperLink CssClass="readMore" ID="hplPID" runat="server">read more</asp:HyperLink></div>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblImage" runat="server" Visible="false" Text='<%# Eval("firstImage")%>'></asp:Label>
                                                              <asp:HyperLink  ID="hplImage" runat="server">  <asp:Image ID="imgPicture" runat="server" Height="160px" Width="200px" /></asp:HyperLink>
                                <div style="text-align: right">
                                    Price:<%# Eval("price")%>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <asp:DataList ID="datListGeneral" runat="server" OnItemDataBound="datList_ItemDataBound"
                RepeatColumns="3">
                <ItemTemplate>
             
                    <table border="0">
                        <tr>
                            <td>
                                <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("ProductID")%>'></asp:Label>
                              
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblImage" runat="server" Visible="false" Text='<%# Eval("firstImage")%>'></asp:Label>
                           <div class="product_image_container" style="text-align:center">   <asp:HyperLink  ID="hplImage" runat="server">  <asp:Image ID="imgPicture" runat="server" Height="160px" Width="190px" /></asp:HyperLink>
                           </div> </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    <%# Eval("Productname")%></div>
                            </td>
                        </tr>
                        <tr><td>price:  <%# Eval("price")%>  <asp:HyperLink CssClass="details" ID="hplPID" runat="server">Details</asp:HyperLink></td></tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>

        </div>
        <div class="product">
            <%--    <p class="paragraph">
                <asp:Literal ID="ltrDescription" runat="server"></asp:Literal>
            </p>--%>
        </div>
    </div>
</asp:Content>
