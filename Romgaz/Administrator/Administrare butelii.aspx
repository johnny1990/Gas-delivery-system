<%@ Page Language="C#" MasterPageFile="~/Administrator/Administrator.master" AutoEventWireup="true"
    CodeFile="Administrare butelii.aspx.cs" Inherits="Administrator_Administrare_butelii" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <div>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <fieldset style="width: 500px; border-style: groove; border-color: Blue">
                <legend>Detalii butelii gaz</legend>
                <br />
                <table style="background-color: #66CCFF">
                    <tr>
                        <td>
                            Nume regiune
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRegiune" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRegiune_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Nume judet
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlJudet" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlJudet_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nume oras:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlOras" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOras_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Nume agentie:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlNumeAgentie" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Total butelii:
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalButelii" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            Butelii disponibile:
                        </td>
                        <td>
                            <asp:TextBox ID="txtButeliiDisponibile" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btnInainte" Text="Inainte" runat="server" OnClick="btnInainte_Click" /><asp:Button
                                ID="btnAfiseaza" Text="Afiseaza tot" runat="server" OnClick="btnAfiseaza_Click" />
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset style="width: 650px" id="fs1" visible="false" runat="server">
                <legend> Detalii butelii agentie</legend>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvButelii" runat="server" CellPadding="4" ForeColor="#333333"
                                GridLines="None" AutoGenerateColumns="False" 
                                onrowediting="gvButelii_RowEditing">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                    <asp:BoundField DataField="Id_nr" HeaderText="Id nr" InsertVisible="False" ReadOnly="True"
                                        SortExpression="Id_nr" />
                                    <asp:BoundField DataField="Id_oras" Visible="false" HeaderText="Id oras" SortExpression="Id_oras" />
                                    <asp:BoundField DataField="Id_agent" Visible="false" HeaderText="Id agent" SortExpression="Id_agent" />
                                    <asp:BoundField DataField="Nume_agentie" HeaderText="Nume agentie" SortExpression="Nume_agentie" />
                                    <asp:BoundField DataField="Total_butelii" HeaderText="Total butelii" SortExpression="Total_butelii" />
                                    <asp:BoundField DataField="Butelii_disponibile" HeaderText="Butelii disponibile" SortExpression="Butelii_disponibile" />
                                    <asp:BoundField DataField="Stare" Visible="false" HeaderText="Stare" SortExpression="Stare" />
                                    <asp:BoundField DataField="Nume_oras" HeaderText="Nume oras" SortExpression="Nume_oras" />
                                    <asp:BoundField DataField="Nume_regiune" HeaderText="Nume regiune" SortExpression="Nume_regiune" />
                                    <asp:CommandField EditText="Edit" ShowEditButton="true" />
                                </Columns>
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <div id="div1" visible="false"   runat="server"  style="width: 500px">
                <fieldset> 
                <legend>Actualizare informatii</legend>
                    <table>
                        <tr>
                            <td>
                                Nume agentie:
                            </td>
                           <td><asp:TextBox ID="txtNumeAgentie" runat="server"></asp:TextBox>  </td>
                        </tr>
                        <tr>
                            <td>
                                Total butelii:
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalButelii1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Butelii disponibile:
                            </td>
                            <td>
                                <asp:TextBox ID="txtButeliiDisponibile1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnActualizare" Text="Actualizeaza" runat="server" 
                                    onclick="btnActualizare_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="lblMsg1" runat="server" ></asp:Label>
                            </td>
                        </tr>
                    </table>
                    </fieldset>
                </div>
            </fieldset>
            <br />
            <br />
            </ContentTemplate> 
            </asp:UpdatePanel>  
            
        </div>
    </center>
</asp:Content>
