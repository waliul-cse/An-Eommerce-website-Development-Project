<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/MasterPages/AdminMasterPage.master"
    AutoEventWireup="true" CodeFile="Item.aspx.cs" Inherits="Admin_Product_Item" %>

<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
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
                :<mobasshir:catgorydropdown UseFirstItem="true" ID="ddlCatagory" runat="server">
                </mobasshir:catgorydropdown>
                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator1" ControlToValidate="ddlCatagory"
                    runat="server" ErrorMessage="*" ValidationGroup="vGProduct"></asp:RequiredFieldValidator>
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td>
                Name
            </td>
            <td>
                :<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtName"
                    runat="server" ErrorMessage="*" ValidationGroup="vGProduct"></asp:RequiredFieldValidator>
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td>
                Unit Price
            </td>
            <td>
                :<asp:TextBox ID="txtUnitPrice" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtUnitPrice"
                    runat="server" ErrorMessage="*" ValidationGroup="vGProduct"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cgn" runat="server" ErrorMessage="Invalid" ValidationGroup="vGProduct"
                    ControlToValidate="txtUnitPrice" Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td>
                Is Visible
            </td>
            <td>
                :<asp:CheckBox ID="chkVisible" Checked="true" runat="server" />
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td>
                Is new product
            </td>
            <td>
                :<asp:CheckBox ID="ChkNewProduct" Checked="false" runat="server" />
            </td>
            <td align="left">
            </td>
        </tr>
            <tr>
            <td>
               Is featured
            </td>
            <td>
                :<asp:CheckBox ID="Chkfeatured" Checked="false" runat="server" />
            </td>
            <td align="left">
            </td>
        </tr>
        
           <tr>
            <td>
               Is on sale
            </td>
            <td>
                :<asp:CheckBox ID="chkOnsell" Checked="false" runat="server" />
            </td>
            <td align="left">
            </td>
        </tr>
        
         <tr>
            <td>
               Sale price
            </td>
            <td>
                :<asp:TextBox ID="txtSaleprice" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Invalid" ValidationGroup="vGProduct"
                    ControlToValidate="txtSaleprice" Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>
            </td>
            <td align="left">
            </td>
        </tr>
        
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <tr>
            <td>
                Quantity
            </td>
            <td>
                :<asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtQuantity"
                    runat="server" ErrorMessage="*" ValidationGroup="vGProduct"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cgmjjju" runat="server" ErrorMessage="Invalid" ValidationGroup="vGProduct"
                    ControlToValidate="txtQuantity" Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td valign="middle">
                Image1
            </td>
            <td>
                <table>
                    <tr>
                        <td valign="middle"">
                            <asp:FileUpload ID="fuImage1" runat="server" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rqrFuimage1" ValidationGroup="vGProduct" ControlToValidate="fuImage1"
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:HiddenField ID="hdnImage1" runat="server" />
                            <asp:Image Visible="false" AlternateText="Image" Width="70px" Height="60px" ID="imgProduct1"
                                runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td valign="middle">
                Image2
            </td>
            <td valign="middle">
                <table>
                    <tr>
                        <td valign="middle"">
                            <asp:FileUpload ID="fuImage2" runat="server" />
                        </td>
                        <td>
                            <asp:Image Visible="false" AlternateText="Image" Width="70px" Height="60px" ID="imgProduct2"
                                runat="server" />
                            <asp:HiddenField ID="hdnImage2" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td valign="middle">
                Image3
            </td>
            <td valign="middle">
                <table>
                    <tr>
                        <td valign="middle"">
                            <asp:FileUpload ID="fuImage3" runat="server" />
                        </td>
                        <td>
                            <asp:Image Visible="false" AlternateText="Iamage" Width="70px" Height="60px" ID="imgProduct3"
                                runat="server" />
                            <asp:HiddenField ID="hdnImage3" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td valign="middle">
                Image4
            </td>
            <td valign="middle">
                <table>
                    <tr>
                        <td valign="middle"">
                            <asp:FileUpload ID="fuImage4" runat="server" />
                        </td>
                        <td>
                            <asp:Image Visible="false" AlternateText="Iamage" Width="70px" Height="60px" ID="imgProduct4"
                                runat="server" />
                            <asp:HiddenField ID="hdnImage4" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td valign="middle">
                Image5
            </td>
            <td valign="middle">
                <table>
                    <tr>
                        <td valign="middle"">
                            <asp:FileUpload ID="fuImage5" runat="server" />
                        </td>
                        <td>
                            <asp:Image Visible="false" AlternateText="Iamage" Width="70px" Height="60px" ID="imgProduct5"
                                runat="server" />
                            <asp:HiddenField ID="hdnImage5" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td valign="top">
                Description
            </td>
            <td>
                :</td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div>
                    <FTB:FreeTextBox ID="ftbDescription" width="700px" ToolbarLayout=" ParagraphMenu, FontFacesMenu, FontSizesMenu, FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,
  FontBackColorsMenu,FontBackColorPicker, Bold, Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,StrikeThrough,RemoveFormat, Superscript, Subscript,(|) InsertImageFromGallery,  CreateLink,Unlink,  BulletedList,
 NumberedList, Indent, Outdent, Cut, Copy, Paste, Delete, Undo, Redo, Print, Save,
 ieSpellCheck, StyleMenu, SymbolsMenu, InsertHtmlMenu, InsertRule, InsertDate,
 InsertTime, WordCount, WordClean, InsertImage, InsertTable, InsertTableRowBefore,
 Preview, SelectAll,Preview, EditStyle" runat="Server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ftbDescription"
                    runat="server" ErrorMessage="*Required" ValidationGroup="vGProduct"></asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                    <asp:Button ID="btnSave" CausesValidation="true" ValidationGroup="vGProduct" runat="server"
                        Text="Save" OnClick="btnSave_Click" Height="54px" Width="89px" />
                    <br />
            </td>
        </tr>
    </table>
</asp:Content>
