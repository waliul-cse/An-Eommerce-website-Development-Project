<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMasterPage.master"
    AutoEventWireup="true" CodeFile="DetailsProduct.aspx.cs" Inherits="DetailsProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="JavaScript" type="text/javascript">
        var lastID = 0;
        function SelectImg(id) {
            if (lastID > 0)
                document.getElementById(lastID).className = "thumbNormal";
            document.getElementById(id).className = "thumbSelected";
            regex = /_tn/;
            document.getElementById(0).src = document.getElementById(id).src.replace(regex, '');
            lastID = id;
        }
        function LoadTrigger() {
            SelectImg(1);
        }
        window.onload = LoadTrigger;
    </script>

    <div style="margin-left: 30px">
        <h3>
            <asp:Label ID="lblName" runat="server" Text=""></asp:Label></h3>
        <div>
            <table>
                <tr>
                    <td valign="top" width="70%">
                        <img id="0" alt="" src="" height="300" width="400" />
                    </td>
                    <td>
                        <asp:DataList Width="100%" ID="datList" runat="server" RepeatColumns="2">
                            <ItemTemplate>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="hdnID" Value='<%# Eval("productID")%>' runat="server" />
                                            <asp:HiddenField ID="hdnImage" Value='<%# Eval("ImageUrl")%>' runat="server" />
                                            <img id='<%# Container.ItemIndex + 1 %>' alt="" class="thumbNormal" src='Uploads/<%# Eval("ImageUrl")%>'
                                                width="125" height="70" onclick="SelectImg('<%# Container.ItemIndex + 1 %>')" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                    

                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hdnID" runat="server"></asp:HiddenField>
            	<a  " href="ViewCart.aspx">View Cart</a>
            	     <asp:TextBox ID="txtQuantity" Width="30px" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="cmp" runat="server" SetFocusOnError="true"
                        ControlToValidate="txtQuantity" Display="Dynamic" ErrorMessage="*"
                        ValidationGroup="AddCart"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cmpNumberHourlySalaryRate" runat="server" ErrorMessage="*"
                        ValidationGroup='AddCart' ControlToValidate="txtQuantity"
                        Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>
                         <asp:Button ID="btnCart" ValidationGroup="AddCart" runat="server" 
                Text="Add To Cart" onclick="btnCart_Click" />
                                
            <div>
               
                <h3>
                    <asp:Label ID="lblPrice" runat="server" Text=""></asp:Label></h3>
            </div>
            <p style="text-align: justify">
                <asp:Literal ID="ltrDescription" runat="server"></asp:Literal>
            </p>
        </div>
    </div>
</asp:Content>
