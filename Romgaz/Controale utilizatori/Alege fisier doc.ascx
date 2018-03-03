<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Alege fisier doc.ascx.cs" Inherits="Controale_Utilizatori_Alege_fisier_doc" %>
<table style="width: 216px; height: 46px;">
    <tr>
        <td valign="bottom" >
            <asp:FileUpload ID="Upload1" runat="server" Font-Names="Verdana" Font-Size="10px"
                Height="18px" Width="191px" />
        </td>
        <td valign="bottom">
            <asp:Button ID="btnAfisImag" CausesValidation="false" runat="server" Text="Ataseaza fisier"
                OnClick="btnAfisImag_Click" Height="21px" Font-Names="Verdana" 
                Font-Size="10px" Width="89px" />
        </td>
    </tr>
    <tr>
        <td valign="bottom" colspan="2">
            <asp:Label ID="lblMesaj" Height="20px" runat="server" Font-Names="Verdana" Font-Size="10px"
                ForeColor="Red"></asp:Label>
        </td>
        
    </tr>
</table>
