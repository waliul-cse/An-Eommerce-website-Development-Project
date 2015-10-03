<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMasterPage.master"
    AutoEventWireup="true" CodeFile="faq.aspx.cs" enableEventValidation="false" Inherits="Admin_faq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h3 style="margin-left: 30px; margin-top: 20px">
            Add/Edit Faq</h3>
        <div id="divMessage" runat="server" visible="false" style="background-color: #F0F0F0;
            border: 1px solid #B2B2B2; margin-left: 30px; margin-top: 20px; height: 50px;">
            <h3 style="margin-left: 20px; margin-top: 20px;">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </h3>
        </div>
    </div>
    <table style="margin-left: 30px">
        <tr>
            <td>
                Question
            </td>
            <td>
                :<asp:TextBox ID="txtQuestion" runat="server" Height="71px" Width="565px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtQuestion"
                    runat="server" ErrorMessage="*" ValidationGroup="vGFaq"></asp:RequiredFieldValidator>
            </td>
            <td align="left">
            </td>
        </tr>
         <tr>
            <td>
                Answer
            </td>
            <td>
                :<asp:TextBox ID="txtAnswer" runat="server" Height="71px" Width="565px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtAnswer"
                    runat="server" ErrorMessage="*" ValidationGroup="vGFaq"></asp:RequiredFieldValidator>
            </td>
            <td align="left">
            </td>
        </tr>
           <tr>
            <td>
                IsVisible
            </td>
            <td>
                :<asp:CheckBox ID="chkIsVisible" Checked="true" runat="server" />
             
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <div>
                    <asp:Button ID="btnSave" CausesValidation="true" ValidationGroup="vGFaq" runat="server"
                        Text="Save" onclick="btnSave_Click" /></div>
            </td>
        </tr>
    </table> 
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
                            <%# Eval("FaqID")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            IsVisible
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("IsVisible")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField>
                        <HeaderTemplate>
                            Question
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Question")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                        <HeaderTemplate>
                            Answer
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("Answer")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemStyle Width="50" HorizontalAlign="Center" />
                        <HeaderTemplate>
                            Edit
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnCommand="Edit_Command" CommandArgument='<%# Eval("FaqID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemStyle Width="50" HorizontalAlign="Center" />
                        <HeaderTemplate>
                            Delete
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" OnClientClick="javascript:return confirm('Warning: Are you sure? ');"
                                runat="server" Text="Delete" OnCommand="Delete_Command" CommandArgument='<%# Eval("FaqID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
       
</asp:Content>
