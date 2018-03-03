<%@ Page Language="C#" MasterPageFile="~/Consumator/Consumator.master" AutoEventWireup="true" CodeFile="Stare rezervare gaz.aspx.cs" Inherits="Consumator_Stare_rezervare_gaz" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<center>
<fieldset style="width:500px">
<legend>
Stare rezervare gaz
</legend> 
<table><tr><td><asp:GridView ID="gvAfiseazaStareRezervare" runat="server"></asp:GridView> </td></tr></table> 
</fieldset> 
</center> 
</div>
</asp:Content>