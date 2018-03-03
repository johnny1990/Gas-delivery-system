<%@ Page Language="C#" MasterPageFile="~/Distribuitor/Distribuitor.master" AutoEventWireup="true" CodeFile="Adresa cereri transfer.aspx.cs" Inherits="Distribuitor_Adresa_cereri_transfer" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center> 
<div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

<fieldset style="width:700px;border-style:groove;border-color:Blue">
<legend>
Adresa cereri transfer
</legend>
<table>
<tr><td><asp:GridView ID="gvCereriTransfer" runat="server" 
        AutoGenerateColumns="False" CellPadding="4" 
        ForeColor="#333333" GridLines="None" 
        onrowediting="gvCereriTransfer_RowEditing">
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#EFF3FB" />
    <Columns>
    <asp:BoundField DataField="Id_nr" HeaderText="Nr cerere"   /> 
        <asp:BoundField DataField="Nr_consumator" HeaderText="Nr consumator" 
            SortExpression="NrConsumator" />
        <asp:BoundField DataField="Catre oras" Visible="false"   HeaderText="Catre oras" 
            SortExpression="CatreOras" />
        <asp:BoundField DataField="De la oras" Visible="false"  HeaderText="De la oras" 
            SortExpression="DeLaOras" />
        <asp:BoundField DataField="Catre_nume_oras" HeaderText="Catre nume oras" 
            SortExpression="CatreOras1" />
        <asp:BoundField DataField="De la id agent" Visible="false"   HeaderText="De la id agent" 
            SortExpression="DeLaIdAgent" />
        <asp:BoundField DataField="DeLaNumeAgentie" Visible="false"   HeaderText="De la nume agentie" 
            SortExpression="DeLaNumeAgentie" />
        <asp:BoundField DataField="CatreIdAgent" Visible="false"   HeaderText="Catre agentul cu id" 
            SortExpression="CatreIdAgent" />
        <asp:BoundField DataField="CatreNumeAgentie" HeaderText="Catre agentia cu numele" 
            SortExpression="CatreNumeAgentie" />
        <asp:BoundField DataField="Data cerere" HeaderText="Data cerere" 
            ReadOnly="True" SortExpression="DataCerere" />
        <asp:BoundField DataField="Stare" HeaderText="Stare" 
            SortExpression="Stare" />
            <asp:CommandField EditText="Trimis catre administrator" ShowEditButton="true"    />  
    </Columns>
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView> 
   
    </td></tr>
    <tr><td><asp:Label ID="lblMsg" runat="server"></asp:Label>  </td></tr>
</table> 
<br />
</fieldset> 
<br />
</ContentTemplate> 
</asp:UpdatePanel> 
<br /> 
</div>
</center>
</asp:Content>

