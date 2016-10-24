<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="CatParticipante.aspx.vb" Inherits="CatParticipante" title="Catálogo de Participantes" StylesheetTheme="skin" Theme="skin" EnableEventValidation="true"  %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">

<script type="text/javascript" src="js/fnayuda.js"></script>

    <table border="0" align="center" cellpadding="3" cellspacing="0" class="tablaComun" width="90%">
        <tr>
            <td><asp:ScriptManager runat="server" ID="scrmInfoGeneral"></asp:ScriptManager>
               &nbsp;<asp:SiteMapPath ID="SiteMapPath2" runat="server"></asp:SiteMapPath>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <th align="left" class="thtablaComun">Catálogo de participantes</th>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:TextBox ID="txtBuscar" runat="server" MaxLength="100"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revBuscar" runat="server" ControlToValidate="txtBuscar"
                    CssClass="mesajeError" ErrorMessage="Nombre del participante tiene carácteres no permitidos"
                    ForeColor="" ToolTip="Nombre del participante tiene carácteres no permitidos"
                    ValidationExpression="[a-zA-Z.'ñÑÁáÉéÍíÓóÚúÜü\s]{1,100}$">x</asp:RegularExpressionValidator>
                <asp:ImageButton ID="ibtnBuscar" runat="server" ImageUrl="~/images/aplicacion/btnBuscar.gif" /></td>
        </tr>
        <tr>
            <td>
        <asp:UpdatePanel ID="updpNuevoCatPart" runat="server">
            <ContentTemplate>
                <asp:ImageButton ID="ibtnNuevoCatPart" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" CausesValidation="False" OnClick="ibtnNuevoCatPart_Click" /><asp:Panel
                    ID="pnlNuevoCatPart" runat="server" Height="100%" Width="100%" Visible="False">
                    <table border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate" width="100%">
                        <tr>
                            <td style="width: 30%">
                                Nombre(s)</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtNombreCatPartAdd" runat="server" Width="400px"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="rfvNombreCatPartAdd" runat="server" ErrorMessage="Nombre del participante es un dato requerido" ControlToValidate="txtNombreCatPartAdd" ForeColor="" ToolTip="Nombre del participante es un dato requerido" CssClass="mesajeError">Nombre del participante es un dato requerido</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                        ID="revNombreCatPartAdd" runat="server" ErrorMessage="Nombre del participante tiene carácteres no permitidos" ControlToValidate="txtNombreCatPartAdd" ForeColor="" ToolTip="Nombre del participante tiene carácteres no permitidos" ValidationExpression="[a-zA-Z.'ñÑÁáÉéÍíÓóÚúÜü\s]{1,50}$" CssClass="mesajeError">El Nombre del participante tiene caracteres no permitidos
                                                <a href="javascript:MostrarAyuda('Ayuda_NombreAdd')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" /></a></asp:RegularExpressionValidator><asp:CustomValidator
                                    ID="cuvApaternoCatPartAdd" runat="server" ControlToValidate="txtNombreCatPartAdd"
                                    ForeColor="">x</asp:CustomValidator>
                                <span id="Ayuda_NombreAdd" class="msgAyuda" style="visibility:hidden">
                                                <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                    <th><a href="javascript:MostrarAyuda('Ayuda_NombreAdd')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" /></a></th></tr>
                                                    <td>
                                                        Caracteres permitidos:<br /><br />
                                                        Minusculas -> (a-z)<br />
                                                        Mayusculas -> (A-Z)<br />
                                                        Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                        Especiales ->&nbsp;&nbsp;  ' . <br />
                                                        Máximo de caracteres -> 50<br />
                                                    </td>
                                                </table>
                                            </span>
            
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                                Apellido paterno</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtAPaternoCatPartAdd" runat="server" Width="400px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvApaternoCatPartAdd" runat="server" ErrorMessage="Apellido paterno es un dato requerido" ControlToValidate="txtAPaternoCatPartAdd" ForeColor="" ToolTip="Apellido paterno es un dato requerido" CssClass="mesajeError">Apellido paterno es un dato requerido" ControlToValidate="txtAPaternoCatPartAdd" ForeColor="" ToolTip="Apellido paterno es un dato requerido</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Apellido paterno tiene caracteres no válidos" ControlToValidate="txtAPaternoCatPartAdd" ForeColor="" ToolTip="Apellido paterno tiene caracteres no válidos" ValidationExpression="[a-zA-Z.'ñÑÁáÉéÍíÓóÚúÜü\s]{1,50}$" CssClass="mesajeError">El apellido paterno del participante tiene caracteres no permitidos
                                                <a href="javascript:MostrarAyuda('Ayuda_APaternoAdd')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" /></a></asp:RegularExpressionValidator>
                                            <span id="Ayuda_APaternoAdd" class="msgAyuda" style="visibility:hidden">
                                                <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                    <th><a href="javascript:MostrarAyuda('Ayuda_APaternoAdd')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" /></a></th></tr>
                                                    <td>
                                                        Caracteres permitidos:<br /><br />
                                                        Minusculas -> (a-z)<br />
                                                        Mayusculas -> (A-Z)<br />
                                                        Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                        Especiales ->&nbsp;&nbsp;  ' . <br />
                                                        Máximo de caracteres -> 50<br />
                                                    </td>
                                                </table>
                                            </span>                                
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                                Apellido materno</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtAmaternoCatPartAdd" runat="server" Width="400px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Apellido materno tiene carácteres no válidos" ControlToValidate="txtAmaternoCatPartAdd" ForeColor="" ToolTip="Apellido materno tiene carácteres no válidos" ValidationExpression="[a-zA-Z.'ñÑÁáÉéÍíÓóÚúÜü\s]{0,50}$" CssClass="mesajeError">El apellido materno del participante tiene caracteres no permitidos
                                                <a href="javascript:MostrarAyuda('Ayuda_AMaternoAdd')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" /></a></asp:RegularExpressionValidator>
                                                
                                            <span id="Ayuda_AMaternoAdd" class="msgAyuda" style="visibility:hidden">
                                                <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                    <th><a href="javascript:MostrarAyuda('Ayuda_AMaternoAdd')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" /></a></th></tr>
                                                    <td>
                                                        Caracteres permitidos:<br /><br />
                                                        Minusculas -> (a-z)<br />
                                                        Mayusculas -> (A-Z)<br />
                                                        Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                        Especiales ->&nbsp;&nbsp;  ' . <br />
                                                        Máximo de caracteres -> 50<br />
                                                    </td>
                                                </table>
                                            </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                                Institución</td>
                            <td style="width: 70%">
                                <asp:DropDownList ID="ddlInstitucionCatPartAdd" runat="server" DataSourceID="odsInstitucionCatPart"
                                    DataTextField="DesInstitucion" DataValueField="CveInstitucion" Width="400px">
                                </asp:DropDownList>
                                <asp:RangeValidator ID="ravInstitucionCatPartAdd" runat="server" ErrorMessage="Seleccione una institución" ControlToValidate="ddlInstitucionCatPartAdd" ForeColor="" MaximumValue="10000" MinimumValue="0" ToolTip="Seleccione una institución" CssClass="mesajeError" Type="Integer">Seleccione una institución</asp:RangeValidator>
                                <asp:ObjectDataSource ID="odsInstitucionCatPart" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetData" TypeName="dsAppTableAdapters.spInstitucionDDLTableAdapter">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                                Departamento</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtDepartamentoCatPartAdd" runat="server" Width="400px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revDepartamentoCatPartAdd" runat="server" ErrorMessage="Departamento tiene carácteres no permitidos" ControlToValidate="txtDepartamentoCatPartAdd" ForeColor="" ToolTip="Departamento tiene carácteres no permitidos" ValidationExpression="[a-zA-Z0-9.',ñÑÁáÉéÍíÓóÚúÜü\p{P}\(\)\s-]{1,150}$" CssClass="mesajeError">El departamento tiene caracteres no permitidos
                                    <a href="javascript:MostrarAyuda('Ayuda_DepartamentoAdd')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" /></asp:RegularExpressionValidator>
                                <span id="Ayuda_DepartamentoAdd" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_DepartamentoAdd')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" /></a></th></tr><tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Minusculas -> (a-z)<br />
                                            Mayusculas -> (A-Z)<br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                            Especiales ->&nbsp;&nbsp;  - ' . ( ) , { }<br />
                                            Máximo de caracteres -> 150<br />
                                        </td></tr>
                                    </table>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                                Escolaridad</td>
                            <td style="width: 70%">
                                <asp:DropDownList ID="ddlEscolaridadCatPartAdd" runat="server" DataSourceID="odsEscolaridadCatPartAdd"
                                    DataTextField="DesEscolaridad" DataValueField="CveEscolaridad" Width="400px">
                                </asp:DropDownList>
                                <asp:RangeValidator ID="ravEscolaridadCatPartAdd" runat="server" ErrorMessage="Seleccione una escolaridad" ControlToValidate="ddlEscolaridadCatPartAdd" ForeColor="" MaximumValue="10000" MinimumValue="0"  CssClass="mesajeError" Type="Integer">Seleccione una escolaridad</asp:RangeValidator>
                                <asp:ObjectDataSource ID="odsEscolaridadCatPartAdd" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetData" TypeName="dsAppTableAdapters.spEscolaridadDDLTableAdapter">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                                Especialidad</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtEspecialidadCatPartAdd" runat="server" Width="400px" MaxLength="250"></asp:TextBox><asp:RegularExpressionValidator
                                        ID="revEspecialidadCatPartAdd" runat="server" ErrorMessage="Especialidad tiene carácteres no permitidos" ControlToValidate="txtEspecialidadCatPartAdd" ForeColor="" ToolTip="Especialidad tiene carácteres no permitidos" ValidationExpression="[a-zA-Z0-9.',ñÑÁáÉéÍíÓóÚúÜü\p{P}\(\)\s-]{1,250}$" CssClass="mesajeError">La especialidad tiene caracteres no permitidos o exceden de 250 caracteres
                                    <a href="javascript:MostrarAyuda('Ayuda_Especialidad')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" /></a></asp:RegularExpressionValidator>
                                <span id="Ayuda_EspecialidadAdd" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_EspecialidadAdd')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" /></a></th></tr><tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Minusculas -> (a-z)<br />
                                            Mayusculas -> (A-Z)<br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                            Especiales ->&nbsp;&nbsp;  - ' . ( ) , { }<br />
                                            Máximo de caracteres -> 250<br />
                                        </td></tr>
                                    </table>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                                Teléfono (Trabajo)</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtTelTrabajoCatPartAdd" runat="server" Width="200px"></asp:TextBox><asp:RegularExpressionValidator
                                    ID="revTelTrabajoCatPartAdd" runat="server" ErrorMessage="El teléfono del trabajo tiene carácteres no permitidos"
                                    ValidationExpression="([0-9-\s\(\)]|(ext)|(ext.)){1,30}$" ControlToValidate="txtTelTrabajoCatPartAdd" ForeColor="" ToolTip="El teléfono del trabajo tiene carácteres no permitidos" CssClass="mesajeError">El teléfono del trabajo tiene carácteres no permitidos
                                    <a href="javascript:MostrarAyuda('Ayuda_TelTrabajoAdd')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" /></a></asp:RegularExpressionValidator>
                                <span id="Ayuda_TelTrabajoAdd" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_TelTrabajoAdd')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" /></a></th></tr><tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Especiales ->&nbsp;&nbsp;  - ( )<br />
                                            Abreviaturas ->&nbsp;&nbsp; ext &nbsp;&nbsp; ext.<br />
                                            Máximo de caracteres -> 30<br />
                                        </td></tr>
                                    </table>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                                Teléfono (Particular)</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtTelParticularCatPartAdd" runat="server" Width="200px"></asp:TextBox><asp:RegularExpressionValidator
                                    ID="revTelPartCatPartAdd" runat="server" ControlToValidate="txtTelParticularCatPartAdd"
                                    ErrorMessage="El teléfono particular tiene carácteres no permitidos" ForeColor=""
                                    ToolTip="El teléfono particular tiene carácteres no permitidos" ValidationExpression="([0-9-\s\(\)]|(ext)|(ext.)){1,30}$" CssClass="mesajeError">El telefono particular tiene carácteres no permitidos
                                    <a href="javascript:MostrarAyuda('Ayuda_TelParticularAdd')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" /></a></asp:RegularExpressionValidator>
                                <span id="Ayuda_TelParticularAdd" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_TelParticularAdd')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" /></a></th></tr><tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Especiales ->&nbsp;&nbsp;  - ( )<br />
                                            Máximo de caracteres -> 30<br />
                                        </td></tr>
                                    </table>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                                Correo electrónico</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtCorreoCatPartAdd" runat="server" Width="400px"></asp:TextBox>
                                <asp:RegularExpressionValidator
                                    ID="revCorreoCatPartAdd" runat="server" ControlToValidate="txtCorreoCatPartAdd"
                                    ErrorMessage="No es una correo electrónico válido" ForeColor="" ValidationExpression="(^[\w.]{3,}@[\w./]{2,}\x2E[\w]{2,3})" ToolTip="No es una correo electrónico válido" CssClass="mesajeError">No es una correo electrónico válido</asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                            </td>
                            <td style="width: 70%">
                                <asp:ValidationSummary ID="vsCatPartAdd" runat="server" DisplayMode="List" ForeColor=""
                                    HeaderText="Se econtraron los siguientes errores:" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                            </td>
                            <td style="width: 70%">
                                <asp:ImageButton ID="ibtnGuardarCatPartAdd" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" OnClick="ibtnGuardarCatPartAdd_Click" />
                                <asp:ImageButton ID="ibtnCancelarCatPartAdd" runat="server" ImageUrl="~/images/aplicacion/btnCancelar.gif" CausesValidation="False" OnClick="ibtnCancelarCatPartAdd_Click" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress id="UpdateProgress1" runat="server" 
             DisplayAfter="1" AssociatedUpdatePanelID="updpNuevoCatPart">
             <ProgressTemplate>
                <img class="mensajeFlotante" src="images/aplicacion/relojAreana.gif" alt=""/>
             </ProgressTemplate>
        </asp:UpdateProgress>
             </td>
        </tr>
        <tr>
            <td align="right">
        Páginas: <asp:Label ID="lb_paginas" runat="server" Text=""></asp:Label>/<asp:Label ID="lb_paginas_total" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="lb_Error" runat="server" Text=""
        CssClass="mesajeError" Visible="false"></asp:Label>
    <center>
    <asp:GridView ID="Grid_Participantes" runat="server" AutoGenerateColumns="false"
     BorderWidth="0px" AllowPaging="True" PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-FirstPageText="&lt;&lt; Primer Página" PagerSettings-LastPageText="Última Página &gt;&gt;" PagerSettings-NextPageText="Siguiente &gt;" PagerSettings-PreviousPageText="Anterior &lt;" PagerSettings-Position="TopAndBottom">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table border="0" class="tablaItemTemplate" width="100%">
                        <tr>
                            <td style="width:110px;" rowspan="3">
                                <asp:ImageButton ID="cmdEditar" runat="server" ImageUrl="~/images/aplicacion/btnEditar.gif" CommandName="edit" CausesValidation="false" />
                            </td>
                            
                            <th style="width: 50px">Clave:</th>
                            <td align="center" style="width:50px"><asp:Label ID="lb_CveParticipante" runat="server" Text='<%#Bind("CveParticipante") %>'></asp:Label></td>
                            
                            <th style="width: 70px">Nombre:</th>
                            <td align="left">
                                <asp:Label ID="lb_Nombre" runat="server" Text='<%#Bind("Nombre") %>'></asp:Label>
                                <asp:Label ID="lb_APaterno" runat="server" Text='<%#Bind("APaterno") %>'></asp:Label>
                                <asp:Label ID="lb_AMaterno" runat="server" Text='<%#Bind("AMaterno") %>'></asp:Label>
                            </td>
                            
                            <td style="width:110px;" rowspan="3">
                                <asp:ImageButton ID="cmdEliminar" runat="server" ImageUrl="~/images/aplicacion/btnEliminar.gif" CommandName="delete" CausesValidation="false" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            <asp:Label ID="lb_Error" runat="server" Text=""
                                    CssClass="mesajeError" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="left">
                                <asp:UpdatePanel id="updp_InfoInstitucion" runat="server">
                                    <contenttemplate>
                                        <asp:ImageButton id="imgExpandirInfoInst" runat="server" ImageUrl="~/images/aplicacion/expandir.gif" CausesValidation="False" CommandName="cmdMas"></asp:ImageButton> 
                                        <asp:Label id="lblMasInfoInst" runat="server" Text="Más..."></asp:Label>
<%--                                    <asp:UpdateProgress id="uppr_InfoInstitucionItm" runat="server" 
                                            DisplayAfter="1" 
                                            AssociatedUpdatePanelID="updp_InfoInstitucion">
                                            <ProgressTemplate>
                                                <img class="mensajeFlotante" src="images/aplicacion/relojAreana.gif" alt=""/>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>--%>                                        
                                        <asp:Panel id="pnlExpandirInfoInst" runat="server" Visible="false" Width="100%">
                                            <table style="FONT-SIZE: 10px"><tbody>
                                                <tr>
                                                    <th style="WIDTH: 90px" align="right">Insititucion:</th>
                                                    <td><asp:Label id="lb_DesInstitucion" runat="server" Text='<%# Bind("Institucion") %>'></asp:Label></td>
                                                    <th align="right">Depto.:</th>
                                                    <td><asp:Label id="lb_Departamento" runat="server" Text='<%# Bind("Departamento") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <th style="WIDTH: 90px" align="right">Escolaridad:</th>
                                                    <td><asp:Label id="lb_DesEscolaridad" runat="server" text='<%#Bind("Escolaridad") %>'></asp:Label></td>
                                                    <th align="right">Especialidad:</th>
                                                    <td><asp:Label id="lb_Especialidad" runat="server" text='<%#Bind("Especialidad") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <th style="WIDTH: 90px" align="right">Tel. Trabajo:</th>
                                                    <td><asp:Label id="lb_TelTrabajo" runat="server" text='<%#Bind("TelTrabajo") %>'></asp:Label></td>
                                                    <th align="right">Tel. Particular:</th>
                                                    <td><asp:Label id="lb_TelParticular" runat="server" text='<%#Bind("TelParticular") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <th style="WIDTH: 90px" align="right">Correo:</th>
                                                    <td><asp:Label id="lb_Correo" runat="server" text='<%#Bind("Correo") %>'></asp:Label></td>
                                                </tr>
                                            </tbody></table>
                                        </asp:Panel> 
                                    </contenttemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <table border="0" class="tablaAlternatigTemplate" width="100%">
                        <tr>
                            <td style="width:110px;" rowspan="3">
                                <asp:ImageButton ID="cmdEditar" runat="server" ImageUrl="~/images/aplicacion/btnEditar.gif" CommandName="edit" CausesValidation="false" />
                            </td>
                            
                            <th style="width: 50px">Clave:</th>
                            <td align="center" style="width:50px"><asp:Label ID="lb_CveParticipante" runat="server" Text='<%#Bind("CveParticipante") %>'></asp:Label></td>
                            
                            <th style="width: 70px">Nombre:</th>
                            <td align="left">
                                <asp:Label ID="lb_Nombre" runat="server" Text='<%#Bind("Nombre") %>'></asp:Label>
                                <asp:Label ID="lb_APaterno" runat="server" Text='<%#Bind("APaterno") %>'></asp:Label>
                                <asp:Label ID="lb_AMaterno" runat="server" Text='<%#Bind("AMaterno") %>'></asp:Label>
                            </td>
                            
                            <td style="width:110px;" rowspan="3">
                                <asp:ImageButton ID="cmdEliminar" runat="server" ImageUrl="~/images/aplicacion/btnEliminar.gif" CommandName="delete" CausesValidation="false" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            <asp:Label ID="lb_Error" runat="server" Text=""
                                    CssClass="mesajeError" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="left">
                                <asp:UpdatePanel id="updp_InfoInstitucion_alter" runat="server">
                                    <contenttemplate>
                                        <asp:ImageButton id="imgExpandirInfoInst_alter" runat="server" ImageUrl="~/images/aplicacion/expandir.gif" CausesValidation="False" CommandName="cmdMas" ></asp:ImageButton> 
                                        <asp:Label id="lblMasInfoInst_alter" runat="server" Text="Más..." ></asp:Label>
<%--                                    <asp:UpdateProgress ID="uppr_InfoInstitucionItm" runat="server" AssociatedUpdatePanelID="updp_InfoInstitucion_alter" DisplayAfter="1">
                                            <ProgressTemplate>
                                                <img src="images/aplicacion/relojAreana.gif" alt=""/>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>--%>       
                                        <br />
 
                                        <asp:Panel id="pnlExpandirInfoInst_alter" runat="server" Visible="false" Width="100%">
                                            <table style="FONT-SIZE: 10px"><tbody>
                                                <tr>
                                                    <th style="WIDTH: 90px" align="right">Insititucion:</th>
                                                    <td><asp:Label id="lb_DesInstitucion_alter" runat="server" Text='<%# Bind("Institucion") %>'></asp:Label></td>
                                                    <th align="right">Depto.:</th>
                                                    <td><asp:Label id="lb_Departamento_alter" runat="server" Text='<%# Bind("Departamento") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <th style="WIDTH: 90px" align="right">Escolaridad:</th>
                                                    <td><asp:Label id="lb_DesEscolaridad_alter" runat="server" text='<%#Bind("Escolaridad") %>'></asp:Label></td>
                                                    <th align="right">Especialidad:</th>
                                                    <td><asp:Label id="lb_Especialidad_alter" runat="server" text='<%#Bind("Especialidad") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <th style="WIDTH: 90px" align="right">Tel. Trabajo:</th>
                                                    <td><asp:Label id="lb_TelTrabajo_alter" runat="server" text='<%#Bind("TelTrabajo") %>'></asp:Label></td>
                                                    <th align="right">Tel. Particular:</th>
                                                    <td><asp:Label id="lb_TelParticular_alter" runat="server" text='<%#Bind("TelParticular") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <th style="WIDTH: 90px" align="right">Correo:</th>
                                                    <td><asp:Label id="lb_Correo_alter" runat="server" text='<%#Bind("Correo") %>'></asp:Label></td>
                                                </tr>
                                            </tbody></table>
                                        </asp:Panel> 
                                    </contenttemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <table border="0" class="tablaEditarTemplate" width="100%">
                        <tr>
                            <td style="width:110px;" rowspan="8"></td>
                            
                            <th style="width: 110px" align="right">Clave: </th>
                            <td align="left" colspan="3">
                                <asp:Label ID="lb_CveParticipante" runat="server" Text='<%#Bind("CveParticipante") %>' Font-Bold="true"></asp:Label>
                                <asp:Label ID="lb_Error" runat="server" Text=""
                                    CssClass="mesajeError" Visible="false"></asp:Label>
                            </td>
                            
                            <td style="width:200px;" rowspan="8" align="center">
                                <asp:ImageButton ID="cmdGuardar" CommandName="UPDATE" runat="server" ImageUrl="images/aplicacion/btnGuardar.gif" />
                                <br /><br /><br />
                                <asp:ImageButton ID="cmdCancelar" CommandName="CANCEL" runat="server" ImageUrl="images/aplicacion/btnCancelar.gif" CausesValidation="false" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="3">
                                <table border="0" width="100%">
                                    <tr>
                                        <th align="center">Nombre</th>
                                        <th align="center">Paterno</th>
                                        <th align="center">Materno</th>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:TextBox ID="txt_Nombre" runat="server" MaxLength="50" Columns="25" Text='<%#Bind("Nombre") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="rfv_Nombre" runat="server" ControlToValidate="txt_Nombre"
                                                ErrorMessage="El Nombre del participante es requerido"
                                                ToolTip="El Nombre del participante es requerido" CssClass="mesajeError" 
                                                ForeColor="black">El Nombre del participante es requerido</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator
                                                ID="rev_Nombre" runat="server" ControlToValidate="txt_Nombre"
                                                ToolTip="El Nombre del participante tiene caracteres no permitidos"
                                                ErrorMessage="El Nombre del participante tiene caracteres no permitidos" 
                                                ValidationExpression="[a-zA-Z.'ñÑÁáÉéÍíÓóÚúÜü\s]{1,50}$"  CssClass="mesajeError" 
                                                ForeColor="black">El Nombre del participante tiene caracteres no permitidos
                                                <a href="javascript:MostrarAyuda('Ayuda_Nombre')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" /></a>
                                                </asp:RegularExpressionValidator>
                                                
                                            <span id="Ayuda_Nombre" class="msgAyuda" style="visibility:hidden">
                                                <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                    <th><a href="javascript:MostrarAyuda('Ayuda_Nombre')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" /></a></th></tr>
                                                    <tr>
                                                    <td>
                                                        Caracteres permitidos:<br /><br />
                                                        Minusculas -> (a-z)<br />
                                                        Mayusculas -> (A-Z)<br />
                                                        Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                        Especiales ->&nbsp;&nbsp;  ' . <br />
                                                        Máximo de caracteres -> 50<br />
                                                    </td>
                                                    </tr>
                                                </table>
                                            </span>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_APaterno" runat="server" MaxLength="50" Columns="25" Text='<%#Bind("APaterno") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="rfv_APaterno" runat="server" ControlToValidate="txt_APaterno"
                                                ErrorMessage="El apellido paterno del participante es requerido"
                                                ToolTip="El apellido paterno del participante es requerido" CssClass="mesajeError" 
                                                ForeColor="black">El apellido paterno del participante es requerido</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator
                                                ID="rev_APaterno" runat="server" ControlToValidate="txt_APaterno"
                                                ToolTip="El apellido paterno del participante tiene caracteres no permitidos"
                                                ErrorMessage="El apellido paterno del participante tiene caracteres no permitidos" 
                                                ValidationExpression="[a-zA-Z.'ñÑÁáÉéÍíÓóÚúÜü\s]{1,50}$"  CssClass="mesajeError" 
                                                ForeColor="black">El apellido paterno del participante tiene caracteres no permitidos
                                                <a href="javascript:MostrarAyuda('Ayuda_APaterno')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" /></a>
                                                </asp:RegularExpressionValidator>
                                                
                                            <span id="Ayuda_APaterno" class="msgAyuda" style="visibility:hidden">
                                                <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                    <th><a href="javascript:MostrarAyuda('Ayuda_APaterno')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" /></a></th></tr>
                                                    <tr>
                                                    <td>
                                                        Caracteres permitidos:<br /><br />
                                                        Minusculas -> (a-z)<br />
                                                        Mayusculas -> (A-Z)<br />
                                                        Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                        Especiales ->&nbsp;&nbsp;  ' . <br />
                                                        Máximo de caracteres -> 50<br />
                                                    </td>
                                                    </tr>
                                                </table>
                                            </span>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txt_AMaterno" runat="server" MaxLength="50" Columns="25" Text='<%#Bind("AMaterno") %>'></asp:TextBox>
                                            <asp:RegularExpressionValidator
                                                ID="rev_AMaterno" runat="server" ControlToValidate="txt_AMaterno"
                                                ToolTip="El apellido materno del participante tiene caracteres no permitidos"
                                                ErrorMessage="El apellido materno del participante tiene caracteres no permitidos" 
                                                ValidationExpression="[a-zA-Z.'ñÑÁáÉéÍíÓóÚúÜü\s]{1,50}$"  CssClass="mesajeError" 
                                                ForeColor="black">El apellido materno del participante tiene caracteres no permitidos
                                                <a href="javascript:MostrarAyuda('Ayuda_AMaterno')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" /></a>
                                                </asp:RegularExpressionValidator>
                                                
                                            <span id="Ayuda_AMaterno" class="msgAyuda" style="visibility:hidden">
                                                <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                    <th><a href="javascript:MostrarAyuda('Ayuda_AMaterno')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" /></a></th></tr>
                                                    <tr>
                                                    <td>
                                                        Caracteres permitidos:<br /><br />
                                                        Minusculas -> (a-z)<br />
                                                        Mayusculas -> (A-Z)<br />
                                                        Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                        Especiales ->&nbsp;&nbsp;  ' . <br />
                                                        Máximo de caracteres -> 50<br />
                                                    </td>
                                                    </tr>
                                                </table>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">Institución:</th>
                            <td align="left">
                                <asp:DropDownList ID="lst_CveInstitucion" runat="server"
                                 DataSourceID="ods_CatInstitucion"
                                 DataTextField="DesInstitucion"
                                 DataValueField="CveInstitucion"
                                 SelectedValue='<%#Bind("CveInstitucion") %>'>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods_CatInstitucion" runat="server"
                                   OldValuesParameterFormatString="original_{0}" 
                                   SelectMethod="GetData" 
                                   TypeName="dsAppTableAdapters.spInstitucionDDLTableAdapter"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">Departamento:</th>
                            <td align="left">
                                <asp:TextBox ID="txt_Departamento" runat="server" MaxLength="150" Columns="60" Text='<%#Bind("Departamento") %>'></asp:TextBox>
                                <asp:RegularExpressionValidator
                                    ID="rev_Departamento" runat="server" ControlToValidate="txt_Departamento"
                                    ToolTip="El departamento tiene caracteres no permitidos"
                                    ErrorMessage="El departamento tiene caracteres no permitidos" 
                                    ValidationExpression="[a-zA-Z0-9.',ñÑÁáÉéÍíÓóÚúÜü\p{P}\(\)\s-]{1,150}$"  CssClass="mesajeError" 
                                    ForeColor="black">El departamento tiene caracteres no permitidos
                                    <a href="javascript:MostrarAyuda('Ayuda_Departamento')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" /></a>
                                    </asp:RegularExpressionValidator>
                                    
                                <span id="Ayuda_Departamento" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_Departamento')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" /></a></th></tr><tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Minusculas -> (a-z)<br />
                                            Mayusculas -> (A-Z)<br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                            Especiales ->&nbsp;&nbsp;  - ' . ( ) , { }<br />
                                            Máximo de caracteres -> 150<br />
                                        </td></tr>
                                    </table>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">Escolaridad:</th>
                            <td align="left">
                                <asp:DropDownList ID="lst_CveEscolaridad" runat="server"
                                 DataSourceID="ods_CatEscolaridad"
                                 DataTextField="DesEscolaridad"
                                 DataValueField="CveEscolaridad"
                                 SelectedValue='<%#Bind("CveEscolaridad") %>'>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods_CatEscolaridad" runat="server"
                                   OldValuesParameterFormatString="original_{0}" 
                                   SelectMethod="GetData" 
                                   TypeName="dsAppTableAdapters.spEscolaridadDDLTableAdapter"></asp:ObjectDataSource>
                            </td>
                            <th align="right">Especialidad:</th>
                            <td align="left">
                                <asp:TextBox ID="txt_Especialidad" runat="server" Columns="20" Text='<%#Bind("Especialidad") %>' Rows="3" TextMode="MultiLine"></asp:TextBox>
                                <asp:RegularExpressionValidator
                                    ID="rev_Especialidad" runat="server" ControlToValidate="txt_Especialidad"
                                    ToolTip="La especialidad tiene caracteres no permitidos o exceden de 250 caracteres"
                                    ErrorMessage="La especialidad tiene caracteres no permitidos o exceden de 250 caracteres" 
                                    ValidationExpression="[a-zA-Z0-9.',ñÑÁáÉéÍíÓóÚúÜü\p{P}\(\)\s-]{1,250}$"  CssClass="mesajeError" 
                                    ForeColor="black">La especialidad tiene caracteres no permitidos o exceden de 250 caracteres
                                    <a href="javascript:MostrarAyuda('Ayuda_Especialidad')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" /></a>
                                    </asp:RegularExpressionValidator>
                                    
                                <span id="Ayuda_Especialidad" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_Especialidad')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" /></a></th></tr><tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Minusculas -> (a-z)<br />
                                            Mayusculas -> (A-Z)<br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                            Especiales ->&nbsp;&nbsp;  - ' . ( ) , { }<br />
                                            Máximo de caracteres -> 250<br />
                                        </td></tr>
                                    </table>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">Telefono Trabajo:</th>
                            <td align="left">
                                <asp:TextBox ID="txt_TelTrabajo" runat="server" Text='<% #Bind("TelTrabajo") %>' MaxLength="30" Columns="15"></asp:TextBox>
                                <asp:RegularExpressionValidator
                                    ID="rev_TelTrabajo" runat="server" ControlToValidate="txt_TelTrabajo"
                                    ToolTip="El telefono tiene caracteres no permitidos"
                                    ErrorMessage="El telefono tiene caracteres no permitidos" 
                                    ValidationExpression="([0-9-\s\(\)]|(ext)|(ext.)){1,30}$"  CssClass="mesajeError" 
                                    ForeColor="black">El telefono tiene caracteres no permitidos
                                    <a href="javascript:MostrarAyuda('Ayuda_TelTrabajo')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" /></a>
                                    </asp:RegularExpressionValidator>
                                    
                                <span id="Ayuda_TelTrabajo" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_TelTrabajo')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" /></a></th></tr><tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Especiales ->&nbsp;&nbsp;  - ( )<br />
                                            Abreviaturas ->&nbsp;&nbsp; ext &nbsp;&nbsp; ext.<br />
                                            Máximo de caracteres -> 30<br />
                                        </td></tr>
                                    </table>
                                </span>
                            </td>
                            <th align="right">Telefono Particular:</th>
                            <td align="left">
                                <asp:TextBox ID="txt_TelParticular" runat="server" Text='<% #Bind("TelParticular") %>' MaxLength="30" Columns="15"></asp:TextBox>
                                <asp:RegularExpressionValidator
                                    ID="rev_TelParticular" runat="server" ControlToValidate="txt_TelParticular"
                                    ToolTip="El telefono tiene caracteres no permitidos"
                                    ErrorMessage="El telefono tiene caracteres no permitidos" 
                                    ValidationExpression="([0-9-\s\(\)]){1,30}$"  CssClass="mesajeError" 
                                    ForeColor="black">El telefono tiene caracteres no permitidos
                                    <a href="javascript:MostrarAyuda('Ayuda_TelParticular')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" /></a>
                                    </asp:RegularExpressionValidator>
                                    
                                <span id="Ayuda_TelParticular" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_TelParticular')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" /></a></th></tr><tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Especiales ->&nbsp;&nbsp;  - ( )<br />
                                            Máximo de caracteres -> 30<br />
                                        </td></tr>
                                    </table>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">Correo:</th>
                            <td align="left">
                                <asp:TextBox ID="txt_Correo" runat="server" Text='<% #Bind("Correo") %>' MaxLength="100" Columns="20"></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator
                                    ID="rev_Correo" runat="server" ControlToValidate="txt_Correo"
                                    ToolTip="No es una correo electrónico válido"
                                    ErrorMessage="No es una correo electrónico válido" 
                                    ValidationExpression="(^[\w.]{3,}@[\w./]{2,}\x2E[\w]{2,3})"  CssClass="mesajeError" 
                                    ForeColor="black">No es una correo electrónico válido
                                    </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                </EditItemTemplate>
               </asp:TemplateField>
           </Columns>     
        <PagerSettings FirstPageText="&amp;lt;&amp;lt; Primer P&#225;gina" LastPageText="Ultima P&#225;gina &amp;gt;&amp;gt;"
            Mode="NextPrevious" NextPageText="Siguiente &amp;gt;" Position="TopAndBottom"
            PreviousPageText="&amp;lt; Anterior" />
    </asp:GridView>
        &nbsp;</center></td>
        </tr>
        <tr>
            <td align="right">
        Páginas: <asp:Label ID="lb_paginasDown" runat="server" Text=""></asp:Label>/<asp:Label ID="lb_paginas_totalDown" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
            </td>
        </tr>
        <tr>
            <td align="left">
<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
            </td>
        </tr>
    </table>
</asp:Content>

