<%@ Page Language="C#" MasterPageFile="~/Administrator/Administrator.master" AutoEventWireup="true" CodeFile="Judet.aspx.cs" Inherits="Administrator_Judet" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center> 
<div>
<br />
<br />
   <fieldset style="width:500px; border-color: #0066FF; border-style: groove;">
                <legend style="">Adauga judet </legend>
                <table>
                <tr><td colspan="3" 
                        style="color: #000000; background-color: #99CCFF; font-weight: bold;" 
                        align="center" >Adauga judet</td></tr>
                    <tr>
                        <td>
                            Nume regiune</td>
                        <td>
                            <asp:DropDownList ID="ddlRegiune" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Nume judet:
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
                            <asp:Button ID="btnContinua" Text="Continua"  runat="server" 
                                onclick="btnContinua_Click"  />
                            <asp:Button ID="btnAnuleaza" runat="server" Text="Anuleaza" 
                                CausesValidation="False" onclick="btnAnuleaza_Click"   />
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
            <fieldset id="fs1" runat="server" visible="false"   style="width:500px; border-color: #0066FF; border-style: groove;">
                <legend style="">Afiseaza judet </legend>
                <table>
                <tr><td><asp:GridView ID="gvJudet" runat="server" CellPadding="4" 
                        ForeColor="#333333" GridLines="None">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                    </asp:GridView> </td></tr>
                    <tr><td align="Center">
                        <asp:Button ID="btnInchide" runat="server" Text="Inchide" 
                            onclick="btnInchide_Click" CausesValidation="False"   /> </td> </tr>
                </table> 
            </fieldset>
    <br />
    <br />
</div>
</center>
</asp:Content>

