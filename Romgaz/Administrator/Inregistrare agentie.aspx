<%@ Page Language="C#" MasterPageFile="~/Administrator/Administrator.master" AutoEventWireup="true" CodeFile="Inregistrare agentie.aspx.cs" Inherits="Administrator_Inregistrare_agentie" Title="Untitled Page" %>

<%@ Register src="../Controale utilizatori/Alege imagine.ascx" tagname="AfisImag" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div >
        <center>           
           
            <br />
            <asp:UpdatePanel ID="panel1" runat="server">
               <Triggers>               
               <asp:AsyncPostBackTrigger ControlID="btnInregistreaza" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnAnuleaza" EventName="Click" />
               </Triggers>
                <ContentTemplate>
                   
            
                    <table style="border: thin solid #5D7B9D; background-color: Window; width: 500px; ">
                        <tr>
                        <td colspan="6" align="center" style="background-color:#C1312F" >
                            <b style="color:White">&nbsp;Formular inregistrare agentie </b>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td >Nume</td>
                        <td><asp:TextBox ID="txtNume" runat="server"></asp:TextBox></td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvNume" runat="server" ErrorMessage="*" ControlToValidate="txtNume" ></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="3" rowspan="4">
                            
                                              
                          
                            
                         
                                                      <uc1:AfisImag ID="AfisImag1" runat="server" />
                            
                         
                                                    
                            
                         
                            
                        </td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                            <td >Prenume</td>
                            <td><asp:TextBox ID="txtPrenume" runat="server"></asp:TextBox></td>
                        <td>
                        
                        </td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td >Prenume2</td>
                        <td><asp:TextBox ID="txtPrenume2" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td> 
                        <td>Sex</td>                       
                        <td align="left">
                            <asp:DropDownList ID="ddlSex" runat="server">
                            <asp:ListItem>--Selecteaza unul--</asp:ListItem>
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>F</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvSex" runat="server" ErrorMessage="*" ControlToValidate="ddlSex" ></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td>
                            Data nasterii
                        </td>
                        <td><asp:TextBox ID="txtDataNasterii" runat="server"></asp:TextBox>
                           
                            </cc1:CalendarExtender>
                            
                        </td>
                        <td>
                       <asp:RequiredFieldValidator ID="rfvDataNasterii" runat="server" ErrorMessage="*" ControlToValidate="txtDataNasterii" ></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            Regula
                        </td>
                        <td valign="middle" align="left">
                            <asp:DropDownList ID="ddlRegula" runat="server" 
                                AutoPostBack="True">
                            <asp:ListItem>--Selecteaza--</asp:ListItem>
                            <asp:ListItem>Distribuitor</asp:ListItem> 
                            
                            </asp:DropDownList> &nbsp;

                            </td>
                        <td>
                        
                       <asp:RequiredFieldValidator ID="rfvRegula" runat="server" ErrorMessage="*" ControlToValidate="ddlRegula" ></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td align="left" valign="middle">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                        <td>Nume regiune</td>
                        <td><asp:DropDownList ID="ddlNumeRegiune" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlNumeRegiune_SelectedIndexChanged"></asp:DropDownList></td>
                        <td>&nbsp;</td>
                        <td>Judet</td><td align="left"><asp:DropDownList ID="ddlJudet" runat="server" 
                                AutoPostBack="True" onselectedindexchanged="ddlJudet_SelectedIndexChanged"></asp:DropDownList> </td>
                        <td><asp:RequiredFieldValidator ID="rfv1" ControlToValidate="ddlJudet"  
                                runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>  </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                Nume agentie</td>
                            <td>
                                <asp:TextBox ID="txtNumeAgentie" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvagentie" runat="server" 
                                    ControlToValidate="txtNumeAgentie" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                Oras</td>
                            <td align="left">
                                <asp:DropDownList ID="ddlOras" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvoras" runat="server" 
                                    ControlToValidate="ddlOras" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                Tip conexiune</td>
                            <td>
                                <asp:DropDownList ID="ddlTipConexiune" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                        <td>
                        Email
                        </td>
                        <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="*" ControlToValidate="txtEmail"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                            <td>Nr telefon</td>
                            <td align="left"><asp:TextBox ID="txtTelefon" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvTelefon" runat="server" 
                                    ControlToValidate="txttelefon" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    
                                                          <asp:RegularExpressionValidator ID="regTelefon" ControlToValidate="txtTelefon" runat="server" 
                                    ErrorMessage="*" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
       
                            </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td >
                            Nume utilizator</td>
                        <td >
                        <asp:TextBox ID="txtNumeUtilizator" runat="server"></asp:TextBox>
                            
                        </td>
                        <td >
                      <asp:RequiredFieldValidator ID="rfvNumeUtilizator" runat="server" ErrorMessage="*" ControlToValidate="txtNumeUtilizator" ></asp:RequiredFieldValidator>
                        </td>
                        <td rowspan="2" >
                        Adresa
                        </td>
                        <td rowspan="2" align="left" >
                            <asp:TextBox ID="txtAdresa" TextMode="MultiLine" runat="server" Height="80px" 
                                Width="176px"></asp:TextBox>
                            </td>
                        <td rowspan="2" >
                            <asp:RequiredFieldValidator ID="rfvAdresa" runat="server" 
                                ControlToValidate="txtAdresa" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td>Parola</td>
                        <td>
                            <asp:TextBox ID="txtParola" runat="server" TextMode="Password"></asp:TextBox>
                            
                            </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvParola" runat="server" 
                                ControlToValidate="txtParola" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td colspan="3">
                            &nbsp;</td>
                        <td colspan="3">
                         <asp:Button ID="btnInregistreaza" runat="server"  Text="Inregistreaza" 
                                ForeColor="White" BorderColor="MediumSeaGreen" BackColor="#797A80" 
                                onclick="btnInregistreaza_Click" />
                          &nbsp;
                        <asp:Button ID="btnAnuleaza" runat="server" CausesValidation="false" Text="Anuleaza" ForeColor="White" 
                                BorderColor="red" BackColor="#797A80" onclick="btnAnuleaza_Click" />
                        </td>
                        </tr>
                         
                        <tr>
                        <td colspan="6" style="background-color:#C1312F"></td>
                        </tr>
                        
               
                        </table>
                       <br />
                       <asp:Label ID="lblMesaj" runat="server" ForeColor="Red"></asp:Label>

                    <br />
                    <br />

                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>

</asp:Content>

