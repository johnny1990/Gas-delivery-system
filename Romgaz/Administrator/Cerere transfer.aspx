<%@ Page Language="C#" MasterPageFile="~/Administrator/Administrator.master" AutoEventWireup="true" CodeFile="~/Administrator/Cerere transfer.aspx.cs" Inherits="Administrator_Cerere_transfer" Title="Untitled Page" %>

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
<tr><td>
    <asp:GridView ID="gvCereriTransfer" runat="server" 
        AutoGenerateColumns="False" CellPadding="4" 
        ForeColor="#333333" GridLines="None" 
        onrowediting="gvCereriTransfer_RowEditing" Width="611px">
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#EFF3FB" />
    <Columns>
    <asp:BoundField DataField="Id_nr" HeaderText="Nr cerere"   /> 
        <asp:BoundField DataField="Nr_consumator" HeaderText="Nr consumator" 
            SortExpression="Nr_consumator" />
        <asp:BoundField DataField="CatreOras" Visible="false"   HeaderText="Catre orasul" 
            SortExpression="CatreOras" />
        <asp:BoundField DataField="DeLaOras" Visible="false"  HeaderText="De la orasul" 
            SortExpression="DeLaOras" />
        <asp:BoundField DataField="CatreNumeOras" HeaderText="Catre orasul" 
            SortExpression="CatreOras1" />
        <asp:BoundField DataField="DeLaIdAgent" Visible="false"   HeaderText="De la id agent" 
            SortExpression="DeLaIdAgent" />
        <asp:BoundField DataField="Catre nume agentie" Visible="false"   HeaderText="Catre nume agentie" 
            SortExpression="CatreNumeAgentie" />
        <asp:BoundField DataField="Catre id agent" Visible="false"   HeaderText="Catre id agent" 
            SortExpression="CatreIdAgent" />
        <asp:BoundField DataField="Catre nume agentie" HeaderText="Catre nume agentie" 
            SortExpression="CatreNumeAgentie" />
        <asp:BoundField DataField="Data cerere" HeaderText="Data ecrere" 
            ReadOnly="True" SortExpression="DataCerere" />
        <asp:BoundField DataField="Stare" HeaderText="Stare" 
            SortExpression="Stare" />
            <asp:CommandField EditText="Accepta" ShowEditButton="true"    />  
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

