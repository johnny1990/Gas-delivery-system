<%@ Page Language="C#" MasterPageFile="~/Distribuitor/Distribuitor.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Distribuitor_Feedback" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<div>
<br />
<br />
<fieldset style="width:400px;border-style:groove;border-color:Blue">
<legend style="color: #0066FF; font-weight: bold;">Formular feedback</legend>
<table style="background-color: #66CCFF"><tr><td>Subiect</td><td align="left"><asp:TextBox ID="txtSubiect" runat="server"></asp:TextBox> </td><td align="left">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubiect"  ErrorMessage="*"></asp:RequiredFieldValidator></td></tr>
<tr><td>Descriere:</td><td><asp:TextBox ID="txtDescriere" 
        TextMode="MultiLine"   runat="server" Height="165px" Width="247px"></asp:TextBox>  </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescriere"  ErrorMessage="*"></asp:RequiredFieldValidator>
        </td></tr>
<tr><td colspan="3"><asp:Button ID="btnTrimite" Text="Trimite"  runat="server" 
        onclick="btnTrimite_Click" />  </td><td>&nbsp;</td></tr>
<tr><td colspan="3">
    <asp:Label ID="Label1" runat="server" ></asp:Label>
    </td><td>
        &nbsp;</td></tr>
</table> 
<br />

</fieldset> 
    <br />
    <br />
    <br />
    
</div>
</center> 
</asp:Content>

