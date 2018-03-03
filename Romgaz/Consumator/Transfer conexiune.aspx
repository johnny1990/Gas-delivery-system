<%@ Page Language="C#" MasterPageFile="~/Consumator/Consumator.master" AutoEventWireup="true" CodeFile="Transfer conexiune.aspx.cs" Inherits="Consumator_Transfer_conexiune" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<center>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<fieldset style="width:600px;border-style:groove;border-color:Blue">
<legend>
Adresa transfer
</legend> 
<br />
<table width="550px" bgcolor="#99CCFF"><tr><td>&nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        Regiune:</td>
    <td align="left"><asp:DropDownList ID="ddlRegiune" runat="server" 
                                                                                    onselectedindexchanged="ddlRegiune_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>  </td></tr>
<tr><td>Nr consumator</td>
    <td>
        <asp:TextBox ID="txtNrConsumator" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
    <td>
        Judet:</td>
    <td align="left"><asp:DropDownList ID="ddlJudet" 
        runat="server" onselectedindexchanged="ddlJudet_SelectedIndexChanged" 
        Enabled="False" AutoPostBack="True"></asp:DropDownList>  </td></tr>
<tr><td>De la orasul</td>
    <td>
        <asp:TextBox ID="txtCatreOras" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
    <td>
        Catre orasul:</td>
    <td align="left"><asp:DropDownList ID="ddlOras" runat="server" 
        onselectedindexchanged="ddlOras_SelectedIndexChanged" Enabled="False" AutoPostBack="True"></asp:DropDownList> </td></tr>
<tr><td>De la agentia cu numele</td>
    <td>
        <asp:TextBox ID="txtDeLaAgentia" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
    <td>
        Nume agentie:</td>
    <td align="left"><asp:DropDownList ID="ddlNumeAgentie" 
        runat="server" Enabled="False"></asp:DropDownList>  </td></tr>
        <tr><td colspan="4">
            <asp:Button ID="btnTrimite" runat="server" onclick="btnTrimite_Click" 
                Text="Trimite cerere" />
            </td>
    </tr>
        <tr><td colspan="4">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
    </tr>
</table> 
<br />
</fieldset> 
        <br />
</ContentTemplate> 
    </asp:UpdatePanel>
</center> 
</div>
</asp:Content>

