<%@ Page Language="C#" MasterPageFile="~/Consumator/Consumator.master" AutoEventWireup="true" CodeFile="Detalii conexiune consumator.aspx.cs" Inherits="Consumator_Detalii_conexiune_consumator" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<center> 
<fieldset style="width:500px;border-style:groove;border-color:Blue" >
<legend>Detalii conexiune gaz</legend> 
<table width="400px" border="1" 
        style="background-color: #FFFFCC; font-weight: bold; color: #0000FF;">
<tr><td colspan="2" style="color: #FF0000; font-weight: bold;">Detalii consum gaz</td></tr>
<tr><td>Nr consumator:</td><td align="left"><asp:Label ID="lblNrConsumator" runat="server" ></asp:Label> </td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td style="height: 26px">Nume consumator:</td><td style="height: 26px" 
        align="left"><asp:Label ID="lblNumeConsumator" runat="server"></asp:Label>  </td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>Tip conexiune:</td><td align="left"><asp:Label ID="lblNumeConexiune" runat="server"></asp:Label>  </td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>Data aplicare</td><td align="left"><asp:Label ID="lblData" runat="server"></asp:Label>  </td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>Data emitere:</td><td align="left"><asp:Label ID="lblDataEmitere" runat="server"></asp:Label>  </td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>Nume agentie:</td><td align="left"><asp:Label ID="lblNumeAgentie" runat="server"></asp:Label>  </td></tr>
<tr><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>Adresa agentie:</td><td align="left"><asp:Label ID="lblAdresa" runat="server"></asp:Label>  </td></tr>


<tr><td colspan="2"><asp:Button ID="btnRezerva" Text="Rezerva gaz"  runat="server" 
        onclick="btnRezerva_Click" />
 </td><td>&nbsp;</td></tr>


<tr><td colspan="2">
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
 </td><td>&nbsp;</td></tr>
</table>
</fieldset> 
<fieldset id="fs1" style="width:500px"  runat="server">
<table><tr><td>&nbsp;</td><td>&nbsp;</td></tr></table> 
</fieldset> 
</center>
</div>
</asp:Content>

