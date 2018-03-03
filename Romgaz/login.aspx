<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/login.aspx.cs" Inherits="Login " Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <br />
        <br />
        <br />
        <asp:Label ID="lblAutentificare" runat="server" 
            style="color: #009900; font-weight: 700" ></asp:Label>
        <br />
        <table width="250" border="0" cellspacing="0"  cellpadding="0" style="border: thin solid LightSteelBlue;
            background-color: #186394;">
           
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="2" style="color:White; font-weight: bold;"  align="left" >
                    Nume utilizator
                </td>
                <td >
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtnume_utilizator" runat="server" TabIndex="1" class="log_field" Style="height: 20px;
                        width: 188px;" />
                </td>
                <td >
                    <asp:RequiredFieldValidator ControlToValidate="txtnume_utilizator" ID="RequiredFieldValidator1"
                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="2"  style="color:White; font-weight: bold;"  align="left"  >
                    Parola
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="2">
                    <span class="innertxt">
                        <asp:TextBox TextMode="Password" ID="txtparola" runat="server" TabIndex="1" class="log_field"
                            Style="height: 20px; width: 188px;" /></span>
                </td>
                <td >
                    <asp:RequiredFieldValidator ControlToValidate="txtparola" ID="RequiredFieldValidator2"
                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;
                </td>
                <td >
                    
                </td>
                <td align="right" >
                    <asp:Button runat="server" ID="ImgBtnEmail" TabIndex="3" Text="Autentificare" 
                        Style="border-width: 0px;
                        color: #FFFFFF; font-weight: 700; border-color:#FFFFFF; background-color: Black;" OnClick="ImgBtnEmail_Click"
                        Height="28px" Width="87px" />
                </td>
                <td >
                    &nbsp;
                </td>
            </tr>
        </table>
    <br />
       <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>
        <br />
        <br />
    </center>
</asp:Content>

