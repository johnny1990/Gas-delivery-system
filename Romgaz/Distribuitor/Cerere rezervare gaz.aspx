<%@ Page Language="C#" MasterPageFile="~/Distribuitor/Distribuitor.master" AutoEventWireup="true" CodeFile="Cerere rezervare gaz.aspx.cs" Inherits="Distribuitor_Cerere_rezervare_gaz" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<center>
<fieldset style="width:500px;border-style:groove;border-color:Blue">
<legend>Cereri rezervare gaz</legend> 
<table>
<tr><td>
    <asp:GridView ID="gvCerereRezervare" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
        onrowediting="gvCerereRezervare_RowEditing" >
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#EFF3FB" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
            <Columns>
            
            <asp:TemplateField HeaderText="Id utilizator" Visible="true">
              <ItemTemplate>
                <asp:Label  ID="lblIdUtilizator" runat="server" Text='<%# Eval("Id_nr")%>' ></asp:Label>
              </ItemTemplate>          
            </asp:TemplateField>
            <asp:BoundField DataField="IdNr" HeaderText="Id nr" />
            <asp:BoundField DataField="NumeConsumator" HeaderText="Nume consumator" />
            <asp:BoundField DataField="NrConsumator" HeaderText="Nr consumator" />     
            <asp:BoundField DataField="DataRezervare" HeaderText="Data rezervare" />     
            <asp:BoundField DataField="Stare" HeaderText="Stare" />                
            <asp:CommandField ShowEditButton="true" EditText="Accept" CausesValidation="false" />
            </Columns>
            <EmptyDataTemplate>
                Tabelul nu contine date
            </EmptyDataTemplate>
    </asp:GridView> </td></tr></table>
    <br />
   
</fieldset>  
</center> 
</div>
</asp:Content>

