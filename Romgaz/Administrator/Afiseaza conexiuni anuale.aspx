<%@ Page Language="C#" MasterPageFile="~/Administrator/Administrator.master" AutoEventWireup="true" CodeFile="Afiseaza conexiuni anuale.aspx.cs" Inherits="Administrator_Afiseaza_conexiuni_anuale" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>Rapoarte conexiuni anuale</h3>
<center>
<table>
<tr><td align="left" >Selecteaza anul</td><td align="left" >
    <asp:DropDownList ID="ddlAn" runat ="server" AutoPostBack="True" >

    <asp:ListItem>2010</asp:ListItem>
    <asp:ListItem>2011</asp:ListItem>
    <asp:ListItem>2012</asp:ListItem>
    <asp:ListItem>2013</asp:ListItem>
    <asp:ListItem>2014</asp:ListItem>
    <asp:ListItem>2015</asp:ListItem>
    </asp:DropDownList></td></tr>
</table>
<fieldset style="width:750px;border-style:groove;border-color:Blue">
<table>
<tr>
<td align="left" ><asp:GridView ID="grvAn" runat ="server" 
        AutoGenerateColumns="False" DataKeyNames="Id_nr" DataSourceID="SqlDataSource1" >
    <Columns>
        <asp:BoundField DataField="Id_nr" HeaderText="Id nr" InsertVisible="False" 
            ReadOnly="True" SortExpression="Id_nr" />
        <asp:BoundField DataField="Nr_consumator" HeaderText="Nr consumator" 
            SortExpression="Nr_consumator" />
        <asp:BoundField DataField="Nume_consumator" HeaderText="Nume consumator" 
            SortExpression="Nume_consumator" />
        
        <asp:BoundField DataField="Nume_conexiune" HeaderText="Nume conexiune" 
            SortExpression="Nume_conexiune" />
        
        <asp:BoundField DataField="Data_alocare" HeaderText="Data alocare" 
            SortExpression="Data_alocare" />
       
        <asp:BoundField DataField="Incarcare_conexiune" HeaderText="Incarcare conexiune" 
            SortExpression="Incarcare_conexiune" />
        <asp:BoundField DataField="Nr_butelie" HeaderText="Nr butelie" 
            SortExpression="Nr_butelie" />
       
        <asp:BoundField DataField="Nume_agentie" HeaderText="Nume agentie" 
            SortExpression="Nume_agentie" />
    </Columns>
    <EmptyDataTemplate>
    <asp:Label ID="lbl1" runat ="server" Text="Nici o conexiune realizata"></asp:Label>
    </EmptyDataTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConStr %>" 
        SelectCommand="Actualizare_cerere_transfer_de_catre_administrator" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlAn" Name="An" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    </td>
</tr>
</table>
</fieldset> 
</center>
</asp:Content>

