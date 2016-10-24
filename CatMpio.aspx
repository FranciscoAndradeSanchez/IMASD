<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="CatMpio.aspx.vb" Inherits="CatMpio" title="Catalogo de Municipios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">

<script type="text/javascript" src="js/fnayuda.js"></script>

<asp:SiteMapPath ID="SiteMapPath2" runat="server"></asp:SiteMapPath>
<br /><br /><br />


    <asp:Label ID="lbTitulo" runat="server" CssClass="thtablaComun" Text="Catálogo de Municipios"></asp:Label><br />
    <br />
    <asp:Label ID="lb_Error" runat="server" Text=""
        CssClass="mesajeError" Visible="false"></asp:Label>
    <center>
    <table class="tablaHeaderTemplate" border="0">
        <tr>
            <th style="text-align: right; height: 63px;">
                Estado:&nbsp;
            </th>
            <td style="height: 63px">
            <asp:DropDownList ID="lst_CveEstado" runat="server" AutoPostBack="True" 
                DataSourceID="ods_Estados"
                DataTextField="DesEstado" 
                DataValueField="CveEstadoInt">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ods_Estados" runat="server" OldValuesParameterFormatString="original_{0}"
                 SelectMethod="GetData" TypeName="dsAppTableAdapters.spEstadoDDLTableAdapter"></asp:ObjectDataSource>
            
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <asp:GridView ID="Grid_Mpio" runat="server" AutoGenerateColumns="False" ShowFooter="True"
             BorderWidth="0px">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table border="0" class="tablaHeaderTemplate" width="100%">
                                <tr><td style="width:110px;"></td><td style="width:20px" align="center">Clave</td><td>Municipio</td><td></td></tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table border="0" class="tablaItemTemplate" width="100%">
                                <tr>
                                    <td style="width:110px;"><asp:ImageButton ID="cmdEditar" runat="server" ImageUrl="~/images/aplicacion/btnEditar.gif" CommandName="edit" CausesValidation="false" /></td>
                                    <td style="width:50px">
                                        <asp:Label ID="lb_CveMpio" runat="server" Text='<%#Bind("CveMpio") %>'></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lb_DesMpio" runat="server" Text='<%#Bind("DesMpio") %>'></asp:Label><br />
                                        <asp:Label ID="lb_Error" runat="server" Text=""
                                            CssClass="mesajeError" Visible="false"></asp:Label>
                                    </td>
                                    <td style="width:110px;"><asp:ImageButton ID="cmdEliminar" runat="server" ImageUrl="~/images/aplicacion/btnEliminar.gif" CommandName="delete" CausesValidation="false" /></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <table border="0" class="tablaAlternatigTemplate" width="100%">
                                <tr>
                                    <td style="width:110px;"><asp:ImageButton ID="cmdEditar" runat="server" ImageUrl="~/images/aplicacion/btnEditar.gif" CommandName="edit" CausesValidation="false" /></td>
                                    <td style="width:50px">
                                        <asp:Label ID="lb_CveMpio" runat="server" Text='<%#Bind("CveMpio") %>'></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lb_DesMpio" runat="server" Text='<%#Bind("DesMpio") %>'></asp:Label><br />
                                        <asp:Label ID="lb_Error" runat="server" Text=""
                                            CssClass="mesajeError" Visible="false"></asp:Label>
                                    </td>
                                    <td style="width:110px;"><asp:ImageButton ID="cmdEliminar" runat="server" ImageUrl="~/images/aplicacion/btnEliminar.gif" CommandName="delete" CausesValidation="false" /></td>
                                </tr>
                            </table>
                        </AlternatingItemTemplate>
                        <EditItemTemplate>
                            <table border="0" class="tablaEditarTemplate" width="100%">
                                <tr>
                                    <td style="width:110px;"></td>
                                    <th colspan="2">Editando...</th>
                                    <td style="width:110px;"></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="width:50px">
                                        <asp:TextBox ID="txt_CveMpio" runat="server" Text='<%#Bind("CveMpio") %>' MaxLength="5" Columns="5"></asp:TextBox>
                                        <asp:RequiredFieldValidator
                                            ID="rfv_CveMpio" runat="server" ControlToValidate="txt_CveMpio"
                                            ErrorMessage="La clave del municipio es requerida"
                                            ToolTip="La clave del municipio es requerida" CssClass="mesajeError" 
                                            ForeColor="black">La clave del municipio es requerida</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="rev_CveMpio" runat="server" ControlToValidate="txt_CveMpio"
                                            ToolTip="La clave del municipio tiene caracteres no permitidos o no es de 5 dígitos"
                                            ErrorMessage="La clave del municipio tiene caracteres no permitidos o no es de 5 dígitos" 
                                            ValidationExpression="^[0-9]{5}$"  CssClass="mesajeError" 
                                            ForeColor="black">La clave del municipio tiene caracteres no permitidos o no es de 5 dígitos
                                            <a href="javascript:MostrarAyuda('Ayuda_CveMpio')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_CveMpio" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_CveMpio')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                                    Caracteres -> 5 exactos<br />
                                                </td>
                                            </table>
                                        </span>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txt_DesMpio" runat="server" Text='<%#Bind("DesMpio") %>' MaxLength="100" Columns="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator
                                            ID="rfv_DesMpio" runat="server" ControlToValidate="txt_DesMpio"
                                            ErrorMessage="La Descripción del municipio es requerida"
                                            ToolTip="La descripción del municipio es requerida" CssClass="mesajeError" 
                                            ForeColor="black">La descripción del municipio es requerida</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="rev_DesMpio" runat="server" ControlToValidate="txt_DesMpio"
                                            ToolTip="La descripción del municipio tiene caracteres no permitidos"
                                            ErrorMessage="La descripción del municipio tiene caracteres no permitidos" 
                                            ValidationExpression="^[a-zA-Z.'áéíóúÁÉÍÓÚñÑüÜ\s\x22-]{1,100}$"  CssClass="mesajeError" 
                                            ForeColor="black">La descripción del municipio tiene caracteres no permitidos
                                            <a href="javascript:MostrarAyuda('Ayuda_DesMpio')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_DesMpio" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_DesMpio')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Minusculas -> (a-z)<br />
                                                    Mayusculas -> (A-Z)<br />
                                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                    Especiales ->&nbsp;&nbsp;  - ' . "<br />
                                                    Máximo de caracteres -> 100<br />
                                                </td>
                                            </table>
                                        </span>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2">
                                        <asp:ImageButton ID="cmdGuardar" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" CommandName="update" CausesValidation="true" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:ImageButton ID="cmdCancelar" runat="server" ImageUrl="~/images/aplicacion/btnCancelar.gif" CommandName="cancel" CausesValidation="false" />
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <table border="0" class="tablaItemTemplate" width="100%">
                                <tr>
                                    <td style="width:110px"></td>
                                    <td style="width:50px"><asp:TextBox ID="txt_CveMpio_ADD" runat="server" Text="" MaxLength="5" Columns="5"></asp:TextBox></td>
                                    <td><asp:TextBox ID="txt_DesMpio_ADD" runat="server" Text="" MaxLength="100" Columns="20"></asp:TextBox></td>
                                    <td style="width:110px"><asp:ImageButton ID="cmdAddMpio" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" CommandName="ADD" CausesValidation="true" /></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="3">
                                        <asp:RequiredFieldValidator
                                            ID="rfv_CveMpio_ADD" runat="server" ControlToValidate="txt_CveMpio_ADD"
                                            ErrorMessage="La clave del municipio es requerida"
                                            ToolTip="La clave del municipio es requerida" CssClass="mesajeError" 
                                            ForeColor="black">La clave del municipio es requerida</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="rev_CveMpio_ADD" runat="server" ControlToValidate="txt_CveMpio_ADD"
                                            ToolTip="La clave del municipio tiene caracteres no permitidos o no es de 5 dígitos"
                                            ErrorMessage="La clave del municipio tiene caracteres no permitidos o no es de 5 dígitos" 
                                            ValidationExpression="^[0-9]{5}$"  CssClass="mesajeError" 
                                            ForeColor="black">La clave del municipio tiene caracteres no permitidos o no es de 5 dígitos
                                            <a href="javascript:MostrarAyuda('Ayuda_CveMpio_ADD')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_CveMpio_ADD" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_CveMpio_ADD')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                                    Caracteres -> 5 exactos<br />
                                                </td>
                                            </table>
                                        </span>
                                        <asp:RequiredFieldValidator
                                            ID="rfv_DesMpio_ADD" runat="server" ControlToValidate="txt_DesMpio_ADD"
                                            ErrorMessage="La Descripción del municipio es requerida"
                                            ToolTip="La descripción del municipio es requerida" CssClass="mesajeError" 
                                            ForeColor="black">La descripción del municipio es requerida</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="rev_DesMpio_ADD" runat="server" ControlToValidate="txt_DesMpio_ADD"
                                            ToolTip="La descripción del municipio tiene caracteres no permitidos"
                                            ErrorMessage="La descripción del municipio tiene caracteres no permitidos" 
                                            ValidationExpression="^[a-zA-Z.'áéíóúÁÉÍÓÚñÑüÜ\s\x22-]{1,100}$"  CssClass="mesajeError" 
                                            ForeColor="black">La descripción del municipio tiene caracteres no permitidos
                                            <a href="javascript:MostrarAyuda('Ayuda_DesMpio_ADD')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_DesMpio_ADD" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_DesMpio_ADD')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Minusculas -> (a-z)<br />
                                                    Mayusculas -> (A-Z)<br />
                                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                    Especiales ->&nbsp;&nbsp;  - ' . "<br />
                                                    Máximo de caracteres -> 100<br />
                                                </td>
                                            </table>
                                        </span>
                                        <asp:Label ID="lb_Error" runat="server" Text=""
                                            CssClass="mesajeError" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table border="0" class="tablaItemTemplate" width="100%">
                        <tr>
                            <td style="width:110px"></td>
                            <td style="width:50px"><asp:TextBox ID="txt_CveMpio_ADD_empty" runat="server" Text="" MaxLength="5" Columns="5"></asp:TextBox></td>
                            <td><asp:TextBox ID="txt_DesMpio_ADD_empty" runat="server" Text="" MaxLength="100" Columns="30"></asp:TextBox></td>
                            <td style="width:110px"><asp:ImageButton ID="cmdAddMpio" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" CommandName="ADD_empty" CausesValidation="true" /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="3">
                                <asp:RequiredFieldValidator
                                    ID="rfv_CveMpio_ADD_empty" runat="server" ControlToValidate="txt_CveMpio_ADD_empty"
                                    ErrorMessage="La clave del municipio es requerida"
                                    ToolTip="La clave del municipio es requerida" CssClass="mesajeError" 
                                    ForeColor="black">La clave del municipio es requerida</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator
                                    ID="rev_CveMpio_ADD_empty" runat="server" ControlToValidate="txt_CveMpio_ADD_empty"
                                    ToolTip="La clave del municipio tiene caracteres no permitidos o no es de 5 dígitos"
                                    ErrorMessage="La clave del municipio tiene caracteres no permitidos o no es de 5 dígitos" 
                                    ValidationExpression="^[0-9]{5}$"  CssClass="mesajeError" 
                                    ForeColor="black">La clave del municipio tiene caracteres no permitidos o no es de 5 dígitos
                                    <a href="javascript:MostrarAyuda('Ayuda_CveMpio_ADD_empty')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                    </asp:RegularExpressionValidator>
                                    
                                <span id="Ayuda_CveMpio_ADD_empty" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_CveMpio_ADD_empty')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Caracteres -> 5 exactos<br />
                                        </td>
                                    </table>
                                </span>
                                <asp:RequiredFieldValidator
                                    ID="rfv_DesMpio_ADD_empty" runat="server" ControlToValidate="txt_DesMPio_ADD_empty"
                                    ErrorMessage="La Descripción del municipio es requerida"
                                    ToolTip="La descripción del municipio es requerida" CssClass="mesajeError" 
                                    ForeColor="black">La descripción del municipio es requerida</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator
                                    ID="rev_DesMpio_ADD_empty" runat="server" ControlToValidate="txt_DesMpio_ADD_empty"
                                    ToolTip="La descripción del municipio tiene caracteres no permitidos"
                                    ErrorMessage="La descripción del municipio tiene caracteres no permitidos" 
                                    ValidationExpression="^[a-zA-Z.'áéíóúÁÉÍÓÚñÑüÜ\s\x22-]{1,100}$"  CssClass="mesajeError" 
                                    ForeColor="black">La descripción del municipio tiene caracteres no permitidos
                                    <a href="javascript:MostrarAyuda('Ayuda_DesMpio_ADD_empty')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                    </asp:RegularExpressionValidator>
                                    
                                <span id="Ayuda_DesMpio_ADD_empty" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_DesMpio_ADD_empty')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Minusculas -> (a-z)<br />
                                            Mayusculas -> (A-Z)<br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                            Especiales ->&nbsp;&nbsp;  - ' . "<br />
                                            Máximo de caracteres -> 100<br />
                                        </td>
                                    </table>
                                </span>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
                &nbsp; &nbsp;
            
            </td>
        </tr>
    </table>
    </center>

<br />
<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>


</asp:Content>

