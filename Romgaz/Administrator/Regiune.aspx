<%@ Page Language="C#" MasterPageFile="~/Administrator/Administrator.master" AutoEventWireup="true"
    CodeFile="Regiune.aspx.cs" Inherits="Administrator_Regiune" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<br />
<br />

    <div>
        <center>
            <fieldset style="width:500px; border-color: #0066FF; border-style: groove;">
                <legend style="">Adauga regiune </legend>
                <table>
                <tr><td colspan="3" 
                        style="color: #000000; background-color: #99CCFF; font-weight: bold;" 
                        align="center" >Adauga detalii regiune</td></tr>
                    <tr>
                        <td>
                            Nume regiune:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNumeRegiune" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="*"  ControlToValidate="txtNumeRegiune"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                           Descriere:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescriere" TextMode="MultiLine"   runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv2" ErrorMessage="*"  runat="server" 
                                ControlToValidate="txtDescriere"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                   
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="btnInainte" Text="Inainte"  runat="server" 
                                onclick="btnInainte_Click" style="height: 26px"  />
                            <asp:Button ID="btnAnuleaza" runat="server" Text="Anuleaza" 
                                CausesValidation="False"   />
                            <asp:Button ID="btnAfiseaza"  runat="server" Text="Afiseaza" CausesValidation="False" 
                                onclick="btnAfiseaza_Click" />  
                        </td>
                    </tr>
                   
                    <tr>
                        <td colspan="3" style="background-color: #99CCFF;" align="center">
                            &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td colspan="3" align="center">
                        <asp:Label ID="lblMsg" ForeColor="Red"   runat="server"></asp:Label>  
                            </td>
                    </tr>
                   
                </table>
            </fieldset>
            <fieldset id ="fs1" visible="false"   style="width:500px; border-color: #0066FF; border-style: groove;" runat="server">
            <legend >Detalii regiune</legend>
            <table>
            <tr><td><asp:GridView ID ="gvDetaliiRegiune" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                </asp:GridView></td></tr>
                <tr><td align="center"><asp:Button ID="btnInchide" runat="server" Text="inchide" 
                        CausesValidation="False" onclick="btnInchide_Click"  />  </td></tr>
            </table> 
            </fieldset>
            <br />
        </center>
    </div>
</asp:Content>
