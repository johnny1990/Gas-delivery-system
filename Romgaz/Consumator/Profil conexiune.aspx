<%@ Page Language="C#" MasterPageFile="~/Consumator/Consumator.master" AutoEventWireup="true" CodeFile="Profil conexiune.aspx.cs" Inherits="Consumator_Profil_conexiune" Title="Untitled Page" %>

<%@ Register src="../Controale utilizatori/Alege imagine.ascx" tagname="AlegeImagine" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <center>
            <br />
            <br />
            <br />
            <asp:UpdatePanel ID="panel1" runat="server">
               <Triggers>               
              <asp:AsyncPostBackTrigger ControlID="btnActualizare" EventName="Click" />
                
              <asp:AsyncPostBackTrigger ControlID="btnActualizareParola" EventName="Click" />
         
               <asp:AsyncPostBackTrigger ControlID="btnAnuleazaParola" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnAnuleaza" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="lbSchimbaParola" EventName="Click" />  
               </Triggers>
                <ContentTemplate>
                   
            
                    <table style="border: thin solid #5D7B9D; background-color: Window;  width: 670px;">
                        <tr>
                        <td colspan="6" align="center" style=" background-color:#5D7B9D" >
                            <b>Actualizeaza profilul meu </b>
                        </td>
                        </tr>
                       
                        
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td>
                            Imagine</td>
                        <td> 
                            <uc1:AlegeImagine ID="AlegeImagine1" runat="server" />
                            </td>
                        <td>
                            &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                       </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td >
                            Email</td>
                        <td align="left" >
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                        <td >
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="*" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>   
                        </td>
                        <td rowspan="2" >
                            Adresa
                        </td>
                        <td rowspan="2" >
                            <asp:TextBox ID="txtAdresa" TextMode="MultiLine" runat="server" Height="80px" 
                                Width="176px"></asp:TextBox>
                            </td>
                        <td rowspan="2" >
                            &nbsp;</td>
                        </tr>
                        <tr>
                        <td>Nr telefon</td>
                        <td align="left">
                            <asp:TextBox ID="txtTelefon" runat="server" ></asp:TextBox>
                                                         <asp:RegularExpressionValidator ID="regTelefon" ControlToValidate="txtTelefon" runat="server" 
                                    ErrorMessage="*" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>

                            </td>
                        <td>
                            &nbsp;</td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td colspan="3">
                            &nbsp;</td>
                        <td colspan="3">
                         <asp:Button ID="btnActualizare" runat="server"  Text="Actualizeaza" 
                                ForeColor="White" BorderColor="MediumSeaGreen" BackColor="#797A80" 
                                onclick="btnActualizare_Click" />
                          &nbsp;
                        <asp:Button ID="btnAnuleaza" runat="server" CausesValidation="false" Text="Anuleaza" ForeColor="White" 
                                BorderColor="red" BackColor="#797A80" onclick="btnAnuleaza_Click" />
                        </td>
                        </tr>
                         <tr>
                <td colspan="3">
                    </td>
                    <td colspan="3" align="right">Apasa aici pentru!<asp:LinkButton ID="lbSchimbaParola" 
                            runat="server" onclick="lbSchimbaParola_Click" CausesValidation="False">Schimba parola</asp:LinkButton> </td>
                </tr>
                        <tr>
                        <td colspan="6" style="background-color:#5D7B9D"></td>
                        </tr>
                        
               
                        </table>
                       <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

            
        </center>
   
    
<div id="divChangePss" visible="false"   runat="server">
               
                   
            
                    <table style="border: thin solid #5D7B9D; background-color:window;  width: 400px;">
                        <tr>
                        <td colspan="3" align="center" style=" background-color:#5D7B9D" >
                            <b style="text-decoration: underline">Schimba parola </b>
                        </td>
                        </tr>                    
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td >
                            Parola veche</td>
                        <td >
                        <asp:TextBox ID="txtVeche" TextMode="Password" runat="server"></asp:TextBox>
                        </td>
                        <td >
                           <asp:RequiredFieldValidator ID="rfvVeche" runat="server" ErrorMessage="*" ControlToValidate="txtVeche"></asp:RequiredFieldValidator> 
                        </td>                        
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>                        
                        <td >
                            Parola noua</td>
                        <td >
                        <asp:TextBox ID="txtNou" TextMode="Password" runat="server"></asp:TextBox>
                        </td>
                        <td >
                           <asp:RequiredFieldValidator ID="rfvNoua" runat="server" ErrorMessage="*" ControlToValidate="txtNoua"></asp:RequiredFieldValidator> 
                        </td>    
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>                        
                        <td >
                            Confirma parola</td>
                        <td >
                        <asp:TextBox ID="txtConfirma" TextMode="Password" runat="server"></asp:TextBox>
                        </td>
                        <td >
                           <asp:RequiredFieldValidator ID="rfvConfirma" runat="server" ErrorMessage="*" ControlToValidate="txtConfirma"></asp:RequiredFieldValidator> 
                        </td>    
                        </tr>
                        
                        <tr>
                        <td colspan="3" >
                            </td>
                        </tr>
                        <tr>
                        <td >
                            </td>
                        <td colspan="2">
                         <asp:Button ID="btnActualizareParola" runat="server"  Text="Actualizare" ForeColor="White"
                                 BorderColor="MediumSeaGreen" BackColor="#797A80" onclick="btnActualizareParola_Click" 
                                 />
                          &nbsp;
                        <asp:Button ID="btnAnuleazaParola" runat="server" ForeColor="White" 
                                CausesValidation="false" Text="Anuleaza"  
                                BorderColor="red" BackColor="#797A80" onclick="btnAnuleazaParola_Click" />
                        </td>
                        </tr>
                         <tr>
                <td colspan="3">
                    </td>
                </tr>
                        <tr>
                        <td colspan="3" style="background-color:#5D7B9D"></td>
                        </tr>                       
                        </table>
                        <br />
                       <asp:Label ID="lblMsg1" runat="server" ForeColor="Red"></asp:Label>

              
           
        
        
    </div>
    </ContentTemplate>
      </asp:UpdatePanel>
      </center>
       </div>
</asp:Content>
