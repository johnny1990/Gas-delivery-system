<%@ Page Language="C#" MasterPageFile="~/Consumator/Consumator.master" AutoEventWireup="true" CodeFile="Afiseaza stare transfer.aspx.cs" Inherits="Consumator_Afiseaza_stare_transfer" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<center>
<fieldset style="width:500px">
<legend>
Stare transfer gaz
</legend> 
<table><tr><td><asp:GridView ID="gvAfiseazaStareTransfer" runat="server"></asp:GridView> 
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <br />
    </td></tr></table> 
</fieldset> 
</center> 
</div>
</asp:Content>

