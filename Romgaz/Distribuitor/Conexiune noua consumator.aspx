<%@ Page Language="C#" MasterPageFile="~/Distribuitor/Distribuitor.master" AutoEventWireup="true" CodeFile="Conexiune noua consumator.aspx.cs" Inherits="Distribuitor_Conexiune_noua_consumator" Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<center>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate> 
<fieldset style="width:500px;border-style: groove; border-color: #0066FF;"> 
<legend style="color: #0000FF; font-weight: bold;">Cereri conexiuni consumatori</legend> 
<table><tr><td>
    <asp:GridView ID="gvCereriConsumatori" runat="server" 
        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="NrConsumator" 
        ForeColor="#333333" GridLines="None" 
        onrowediting="gvCereriConsumatori_RowEditing">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:CommandField EditText="Edit" ShowEditButton="true" />
            <asp:BoundField DataField="NrConsumator" HeaderText="Nr consumator" 
                InsertVisible="False" ReadOnly="True" SortExpression="NrConsumator" />
            <asp:BoundField DataField="Nume" HeaderText="Nume" SortExpression="Nume" />
            <asp:BoundField DataField="Adresa" HeaderText="Adresa" 
                SortExpression="Adresa" />
            <asp:BoundField DataField="DataCerere" HeaderText="Data cerere" 
                ReadOnly="True" SortExpression="DataCerere" />
            <asp:TemplateField HeaderText="Imagine consumator">
                <ItemTemplate>
                    <asp:Image ID="image1" runat="server" Width="100px" Height="75px"  
                        ImageUrl='<%# "Handler.ashx?CID="+ Eval("Nr_consumator") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    
    </td></tr></table> 
</fieldset>
    <br />
 <br />

    <fieldset id="fs1" visible="false"   runat="server" style=" width:600px; border-bottom-style:groove;border-color:Blue" >
    <legend style="color: #0000FF; font-weight: bold">Accepta conexiune consumator</legend> 
    <br />
    
    <table border="1" align="center" 
            style="border-color: #66CCFF; background-color: #99CCFF;">
    <tr><td>Nr consumator:</td><td align="left"><asp:TextBox ID="txtNrConsumator" 
            runat="server" ReadOnly="True"></asp:TextBox> </td>
    <td>Nume consumator:</td><td align="left">
        <asp:TextBox ID="txtNumeConsumator" 
            runat="server" ReadOnly="True"></asp:TextBox>  </td></tr>
    <tr><td>Adresa consumator:</td><td><asp:TextBox ID="txtAdresa" 
            TextMode="MultiLine"  runat="server" ReadOnly="True"></asp:TextBox>  </td>
        
            <td>
                Tip conexiune</td>
            <td align="left">
                <asp:TextBox ID="txtConexiune" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    
        <tr>
            <td>
                Data cerere:</td>
            <td align="left">
                <asp:TextBox ID="txtReDate" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
      <td>Data alocare:</td><td align="left"><asp:TextBox ID="txtDataAlocare" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="txtDataAlocare_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtDataAlocare">
            </cc1:CalendarExtender>
            </td><td>
    <asp:RequiredFieldValidator ID="rfv1" ControlToValidate="txtdataAlocare"  
            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>  </td>  </tr>
    <tr><td>Nr butelie</td><td align="left"><asp:TextBox id="txtButelie" runat="server"></asp:TextBox></td>
        
            <td>
                Valoare depozit</td>
            <td align="left">
                <asp:TextBox ID="txtValoareDepozit" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Incarcare conexiune</td>
            <td align="left">
                <asp:TextBox ID="txtIncarcaConexiune" runat="server" 
                    AutoCompleteType="Disabled"></asp:TextBox>
            </td>
       
            <td>
                Regulator</td>
            <td align="left">
                <asp:TextBox ID="txtRegulator" MaxLength="1"  runat="server" Width="30px"></asp:TextBox>
            </td>
            <td><asp:CompareValidator ID="cv1" ControlToValidate="txtRegulator"  runat="server" 
                    ErrorMessage="*" Type="Integer" ValueToCompare="1"></asp:CompareValidator>  </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Button ID="btnAccepta" runat="server" Text="Accepta" 
                    onclick="btnAccepta_Click" style="height: 26px" />
                <asp:Button ID="btnInchide" runat="server" onclick="btnInchide_Click" 
                    Text="Inchide" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table> 
    <br />
    </fieldset>
    <br />
    <br />
</ContentTemplate>
    </asp:UpdatePanel>
</center> 
</div>
</asp:Content>


