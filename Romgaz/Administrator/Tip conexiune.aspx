<%@ Page Language="C#" MasterPageFile="~/Administrator/Administrator.master" AutoEventWireup="true" CodeFile="Tip conexiune.aspx.cs" Inherits="Administrator_Tip_conexiune" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
        <center>
            <fieldset style="width:500px; border-color: #0066FF; border-style: groove;">
                <legend style="">Adauga&nbsp; Tip conexiune </legend>
                <table>
                <tr><td colspan="3" 
                        style="color: #000000; background-color: #99CCFF; font-weight: bold;" 
                        align="center" >Adauga detalii tip conexiune</td></tr>
                    <tr>
                        <td>
                            Nume conexiune:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNumeConexiune" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="*"  
                                ControlToValidate="txtNumeConexiune"></asp:RequiredFieldValidator>
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
                        <td>
                            Schimb reincarcare</td>
                        <td>
                            <asp:TextBox ID="txtReincarca" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv3" runat="server" ErrorMessage="*"  
                                ControlToValidate="txtReincarca"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                   
                    <tr>
                        <td style="height: 25px">
                            PretPret coexiune noua</td>
                        <td style="height: 25px">
                            <asp:TextBox ID="txtPretNou" runat="server"></asp:TextBox>
                        </td>
                        <td style="height: 25px">
                            <asp:RequiredFieldValidator ID="rfv4" runat="server" ErrorMessage="*"  
                                ControlToValidate="txtPretNou"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                   
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="btnContinua" Text="Continua"  runat="server" 
                                onclick="btnContinua_Click" style="height: 26px"  />
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
            <fieldset id ="fs1" visible="false"   style="width:500px; border-color: #0066FF; border-style: groove;" runat="server">
            <legend >Tip conexiunegend>
            <table>
            <tr><td><asp:GridView ID ="gvDetaliiConexiune" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                    DataKeyNames="IdTipConexiune">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="Id_tip_conexiune" Visible="false"   HeaderText="Id tip conexiune" 
                        InsertVisible="False" ReadOnly="True" SortExpression="Id_tip_conexiune" />
                    <asp:BoundField DataField="Nume_conexiune" HeaderText="Nume conexiune" 
                        SortExpression="Nume_conexiune" />
                    <asp:BoundField DataField="Descriere" HeaderText="Descriere" 
                        SortExpression="Descriere" />
                    <asp:BoundField DataField="Schimba_reincarcare" HeaderText="Schimba reincarcare" 
                        SortExpression="Schimba_reincarcare" />
                    <asp:BoundField DataField="Conexiune_noua_pret" HeaderText="Pret nou" 
                        SortExpression="Conexiune_noua_pret" />
                </Columns>
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                 </td></tr>
                <tr><td align="center"><asp:Button ID="btnInchide" runat="server" Text="Inchide" 
                        CausesValidation="False" onclick="btnInchide_Click"  />  </td></tr>
            </table> 
            </fieldset>
            <br />
        </center>
    </div>
</asp:Content>

