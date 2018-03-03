<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Acasa.aspx.cs" Inherits="Acasa" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <center>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <fieldset>
                        <legend>Cunoastere stare disponibilitate butelii gaz</legend>
                        <table>
                            <tr>
                                <td>
                                    Nume regiune:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlNumeRegiune" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlNumeRegiune_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblJudet" Visible="false"   Text="Judet" runat="server">
                                    </asp:Label>
                                </td>
                                <td><asp:DropDownList ID="ddlJudet" Visible="false"   runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlJudet_SelectedIndexChanged"></asp:DropDownList> </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblOras" Text="Oras" Visible="false"    runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOras" Visible="false"   runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlOras_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblAgentie" Visible="false"   Text="NumeAgentie"  runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAgentie" Visible="false"   runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr><td colspan="4" align="center">
                                <asp:Button ID="btnAfiseaza" Enabled="false"   Text="Click pentru stare"  
                                    runat="server" onclick="btnAfiseaza_Click" Width="105px"  /> </td></tr>
                            <tr><td colspan="4" align="center"><asp:GridView ID="gvButelii" Visible="false"   runat="server" ></asp:GridView> </td></tr>
                        </table>
                    </fieldset>
              </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>
</asp:Content>

