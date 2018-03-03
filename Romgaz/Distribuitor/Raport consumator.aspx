<%@ Page Language="C#" MasterPageFile="~/Distribuitor/Distribuitor.master" AutoEventWireup="true" CodeFile="Raport consumator.aspx.cs" Inherits="Distribuitor_Raport_consumator" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<center>
<br />
<fieldset style="width:750px;border-style:groove;border-color:Blue">
<legend style="color: #0000FF; font-weight: bold">Raport consumator</legend>
<table><tr><td><asp:GridView ID="gvRaportConsumator" runat="server" BackColor="White" 
        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
    <RowStyle BackColor="White" ForeColor="#003399" />
    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
    </asp:GridView> </td></tr></table>  
<br />
</fieldset> 
    <br />
    <br />
</center> 
</div>
</asp:Content>

