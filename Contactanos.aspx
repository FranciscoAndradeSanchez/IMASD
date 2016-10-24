<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="Contactanos.aspx.vb" Inherits="contactanos" title="Contáctanos" StylesheetTheme="skin" Culture="es-MX"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">
  
  <div class="col1"  style="width:58%">
   
    <asp:SiteMapPath ID="smpContactanosSup" runat="server"></asp:SiteMapPath>
  <div class="row">
    <span class="resaltado">Cuenta de Acceso</span>
    <p><a href="Registro.aspx">Quiero registrarme para consultar la información</a></p>
  </div>

  <div class="row">


                          <asp:MultiView ID="mviewContactanos" runat="server">
                            <asp:View ID="viewSugerencia" runat="server">
                                <table align="center" width="100%" border="0" cellpadding="0" cellspacing="0" class="tablaComun">
                                                <tr>
                                                    <th colspan="2" class="left">
                                                        <span class="resaltado">Enviar comentario</span>
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td class="text_SubTitleNormal" colspan="2">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="text_SubTitleNormal">
                                                        Para enviar sus comentarios y sugerencias por favor llene el siguiente formulario:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 22%">
                                                        Nombre del remitente
                                                    </td>
                                                    <td style="width: 78%">
                                                        <asp:TextBox ID="txtNombre" runat="server" MaxLength="100" Width="350px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                                                            ErrorMessage="Nombre del remitente es un valor requerido" ForeColor="" ToolTip="Nombre es un valor requerido">x</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre"
                                                            ErrorMessage="El nombre del remitente tiene caracteres no permitidos" ForeColor=""
                                                            ToolTip="El nombre del remitente tiene caracteres no permitidos" ValidationExpression="^[a-zA-Z''-'ñÑÁáÉéÍíÓóÚúÜü\s]{1,40}$">x</asp:RegularExpressionValidator></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 22%">Correo electrónico</td>
                                                    <td style="width: 78%">
                                                        <asp:TextBox ID="txtEmail" runat="server" Width="350px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                                            ErrorMessage="Correo electrónico es un valor requerido" ForeColor="" ToolTip="Correo electrónico es un valor requerido">x</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                                            ErrorMessage="El correo electrónico esta mal escrito" ForeColor="" ToolTip="El correo electrónico esta mal escrito"
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">x</asp:RegularExpressionValidator></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 22%">
                                                        Tipo de comentario
                                                    </td>
                                                    <td style="width: 78%">
                                                        <asp:DropDownList ID="ddlRazones" runat="server">
                                                            <asp:ListItem>Solicitud de informaci&#243;n</asp:ListItem>
                                                            <asp:ListItem>Problemas con el sistema</asp:ListItem>
                                                            <asp:ListItem>Falta informaci&#243;n en los cat&#225;logos</asp:ListItem>
                                                            <asp:ListItem>Otro</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 22%">
                                                        Sugerencia/Comentario</td>
                                                    <td style="width: 78%; font-weight: bold; text-decoration: underline;">
                                                        <asp:TextBox ID="txtSugerencia" runat="server" MaxLength="500" Rows="5" TextMode="MultiLine"
                                                            Width="350px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvSugerencia" runat="server" ControlToValidate="txtSugerencia"
                                                            ErrorMessage="Sugerencia es en dato requerido" ForeColor="" ToolTip="Sugerencia es en dato requerido">x</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="revSugerencia" runat="server" ControlToValidate="txtSugerencia"
                                                            ErrorMessage="El sugerencia o comentario tiene caracteres no permitidos" ForeColor=""
                                                            ToolTip="El sugerencia o comentario tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{1,500}$">x</asp:RegularExpressionValidator>
                                                        <asp:CustomValidator ID="cmvComentario" runat="server" ErrorMessage="Ocurrio un error al enviar el comentario"
                                                            ToolTip="Ocurrio un error al enviar el comentario" ForeColor="">x</asp:CustomValidator></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 22%">
                                                    </td>
                                                    <td style="width: 78%">
                                                        <asp:ValidationSummary ID="vsSugerencia" runat="server" DisplayMode="List" ForeColor=""
                            HeaderText="Se encontraron los siguientes errores:" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 22%">
                                                    </td>
                                                    <td style="width: 78%">
                                                        <asp:ImageButton ID="ibtnSugerencia" runat="server" ImageUrl="~/images/aplicacion/btnEnviarSugerencia.gif"
                            PostBackUrl="~/Contactanos.aspx" /></td>
                                                </tr>
                                                <tr style="font-size: 9pt">
                                                    <td colspan="2">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                &nbsp;</asp:View>
                            <asp:View ID="viewSugEnviada" runat="server">
                                <table class="tablaComun" style="width: 100%">
                                    <tr>
                                        <td>
                                            Gracias por enviar su comentario o sugerencia para nosotros es muy importante conocer
                                            las inquietudes de nuestros usuarios a fin de mejorar nuestros servicios.</td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="ibtnOtraSugerencia" runat="server" ImageUrl="~/images/aplicacion/btnOtraSugerencia.gif" /></td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
  
  </div>
  </div><!-- /col1 -->

  <div class="col2" style="width:40%">
    <div class="row">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/2014/02.jpg" />
    </div>

    <div class="row">
         
         <div class="col2" style="width:45%">
            <span class="resaltado">Contacto</span>
            <p>Gerencia de Desarrollo y Transferencia de Tecnolog&iacute;a</p>
         </div>

         <div class="col1" style="width:50%">
            <span class="resaltado">Correo</span>
            <p><a href="mailto:eduardo.santiago@conafor.gob.mx">eduardo.santiago@conafor.gob.mx</a></p>
         </div>

    </div>
  </div>



 </asp:Content>

