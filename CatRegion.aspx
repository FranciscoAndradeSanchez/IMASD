<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="CatRegion.aspx.vb" Inherits="CatRegion" title="Catalogo de Regiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">

<script type="text/javascript" src="js/fnayuda.js"></script>

<asp:SiteMapPath ID="SiteMapPath2" runat="server"></asp:SiteMapPath>
<br /><br /><br />

<asp:Label ID="lbTitulo" runat="server" CssClass="thtablaComun" Text="Catálogo de Regiones"></asp:Label><br />
    <br />
    <asp:Label ID="lb_Error" runat="server" Text=""
        CssClass="mesajeError" Visible="false"></asp:Label>
    <center>
    <table class="tablaHeaderTemplate" border="0">
        <tr>
            <td colspan="2">
            <asp:GridView ID="Grid_Region" runat="server" AutoGenerateColumns="False" ShowFooter="True"
             BorderWidth="0px">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table border="0" class="tablaHeaderTemplate" width="100%">
                                <tr><td style="width:110px;"></td><td style="width:20px" align="center">Clave</td><td>Región</td><td></td></tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table border="0" class="tablaItemTemplate" width="100%">
                                <tr>
                                    <td style="width:110px;"><asp:ImageButton ID="cmdEditar" runat="server" ImageUrl="~/images/aplicacion/btnEditar.gif" CommandName="edit" CausesValidation="false" /></td>
                                    <td style="width:50px">
                                        <asp:Label ID="lb_CveRegion" runat="server" Text='<%#Bind("CveRegion") %>'></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lb_DesRegion" runat="server" Text='<%#Bind("DesRegion") %>'></asp:Label><br />
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
                                        <asp:Label ID="lb_CveRegion" runat="server" Text='<%#Bind("CveRegion") %>'></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lb_DesRegion" runat="server" Text='<%#Bind("DesRegion") %>'></asp:Label><br />
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
                                        <asp:Label ID="lb_CveRegion" runat="server" Text='<%#Bind("CveRegion") %>'></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txt_DesRegion" runat="server" Text='<%#Bind("DesRegion") %>' MaxLength="100" Columns="40"></asp:TextBox>
                                        <asp:RequiredFieldValidator
                                            ID="rfv_DesRegion" runat="server" ControlToValidate="txt_DesRegion"
                                            ErrorMessage="La descripción de la región es requerida"
                                            ToolTip="La descripción de la región es requerida" CssClass="mesajeError" 
                                            ForeColor="black">La descripción de la región es requerida</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="rev_DesRegion" runat="server" ControlToValidate="txt_DesRegion"
                                            ToolTip="La descripción de la región tiene caracteres no permitidos"
                                            ErrorMessage="La descripción de la región tiene caracteres no permitidos" 
                                            ValidationExpression="^([0-9a-zA-Z\sñÑÁáÉéÍíÓóÚúÜü]){1,100}$"  CssClass="mesajeError" 
                                            ForeColor="black">La descripción de la región tiene caracteres no permitidos
                                            <a href="javascript:MostrarAyuda('Ayuda_DesRegion')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_DesRegion" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_DesRegion')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Minusculas -> (a-z)<br />
                                                    Mayusculas -> (A-Z)<br />
                                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                    Máximo de caracteres -> 100<br />
                                                </td></tr>
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
                                    <td style="width:50px"><asp:TextBox ID="txt_CveRegion_ADD" runat="server" Text="" MaxLength="3" Columns="3"></asp:TextBox></td>
                                    <td><asp:TextBox ID="txt_DesRegion_ADD" runat="server" Text="" MaxLength="100" Columns="40"></asp:TextBox></td>
                                    <td style="width:110px"><asp:ImageButton ID="cmdAddRegion" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" CommandName="ADD" CausesValidation="true" /></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="3">
                                        <asp:RequiredFieldValidator
                                            ID="rfv_CveRegion_ADD" runat="server" ControlToValidate="txt_CveRegion_ADD"
                                            ErrorMessage="La clave de la región es requerida"
                                            ToolTip="La clave de la región es requerida" CssClass="mesajeError" 
                                            ForeColor="black">La clave de la región es requerida</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="rev_CveRegion_ADD" runat="server" ControlToValidate="txt_CveRegion_ADD"
                                            ToolTip="La clave de la región tiene caracteres no permitidos o no es de 3 dígitos"
                                            ErrorMessage="La clave de la región tiene caracteres no permitidos o no es de 3 dígitos" 
                                            ValidationExpression="^[a-zA-Z0-9]{3}$"  CssClass="mesajeError" 
                                            ForeColor="black">La clave de la región tiene caracteres no permitidos o no es de 3 dígitos
                                            <a href="javascript:MostrarAyuda('Ayuda_CveRegion_ADD')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_CveRegion_ADD" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_CveRegion_ADD')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Minusculas -> (a-z)<br />
                                                    Mayusculas -> (A-Z)<br />
                                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                                    Caracteres -> 3 exactos<br />
                                                </td></tr>
                                            </table>
                                        </span>
                                        <asp:RequiredFieldValidator
                                            ID="rfv_DesRegion_ADD" runat="server" ControlToValidate="txt_DesRegion_ADD"
                                            ErrorMessage="La descripción de la región es requerida"
                                            ToolTip="La descripción de la región es requerida" CssClass="mesajeError" 
                                            ForeColor="black">La descripción de la región es requerida</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="rev_DesRegion_ADD" runat="server" ControlToValidate="txt_DesRegion_ADD"
                                            ToolTip="La descripción de la región tiene caracteres no permitidos"
                                            ErrorMessage="La descripción de la región tiene caracteres no permitidos" 
                                            ValidationExpression="^([a-zA-Z0-9\sñÑÁáÉéÍíÓóÚúÜü]){1,100}$"  CssClass="mesajeError" 
                                            ForeColor="black">La descripción de la región tiene caracteres no permitidos
                                            <a href="javascript:MostrarAyuda('Ayuda_DesRegion_ADD')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_DesRegion_ADD" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_DesRegion_ADD')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Minusculas -> (a-z)<br />
                                                    Mayusculas -> (A-Z)<br />
                                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                    Máximo de caracteres -> 100<br />
                                                </td></tr>
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
                            <td style="width:50px"><asp:TextBox ID="txt_CveRegion_ADD_empty" runat="server" Text="" MaxLength="3" Columns="3"></asp:TextBox></td>
                            <td><asp:TextBox ID="txt_DesRegion_ADD_empty" runat="server" Text="" MaxLength="100" Columns="40"></asp:TextBox></td>
                            <td style="width:110px"><asp:ImageButton ID="cmdAddRegion" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" CommandName="ADD_empty" CausesValidation="true" /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="3">
                                <asp:RequiredFieldValidator
                                    ID="rfv_CveRegion_ADD_empty" runat="server" ControlToValidate="txt_CveRegion_ADD_empty"
                                    ErrorMessage="La clave de la región es requerida"
                                    ToolTip="La clave de la región es requerida" CssClass="mesajeError" 
                                    ForeColor="black">La clave de la región es requerida</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator
                                    ID="rev_CveRegion_ADD_empty" runat="server" ControlToValidate="txt_CveRegion_ADD_empty"
                                    ToolTip="La clave de la región tiene caracteres no permitidos o no es de 3 dígitos"
                                    ErrorMessage="La clave de la región tiene caracteres no permitidos o no es de 3 dígitos" 
                                    ValidationExpression="^[a-zA-Z0-9]{3}$"  CssClass="mesajeError" 
                                    ForeColor="black">La clave de la región tiene caracteres no permitidos o no es de 3 dígitos
                                    <a href="javascript:MostrarAyuda('Ayuda_CveRegion_ADD_empty')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                    </asp:RegularExpressionValidator>
                                    
                                <span id="Ayuda_CveRegion_ADD_empty" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_CveRegion_ADD_empty')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Minusculas -> (a-z)<br />
                                            Mayusculas -> (A-Z)<br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Caracteres -> 3 exactos<br />
                                        </td></tr>
                                    </table>
                                </span>
                                <asp:RequiredFieldValidator
                                    ID="rfv_DesRegion_ADD_empty" runat="server" ControlToValidate="txt_DesRegion_ADD_empty"
                                    ErrorMessage="La descripción de la región es requerida"
                                    ToolTip="La descripción de la región es requerida" CssClass="mesajeError" 
                                    ForeColor="black">La descripción de la región es requerida</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator
                                    ID="rev_DesRegion_ADD_empty" runat="server" ControlToValidate="txt_DesRegion_ADD_empty"
                                    ToolTip="La descripción de la región tiene caracteres no permitidos"
                                    ErrorMessage="La descripción de la región tiene caracteres no permitidos" 
                                    ValidationExpression="^([0-9a-zA-Z\sñÑÁáÉéÍíÓóÚúÜü]){1,100}$"  CssClass="mesajeError" 
                                    ForeColor="black">La descripción de la región tiene caracteres no permitidos
                                    <a href="javascript:MostrarAyuda('Ayuda_DesRegion_ADD_empty')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                    </asp:RegularExpressionValidator>
                                    
                                <span id="Ayuda_DesRegion_ADD_empty" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_DesRegion_ADD_empty')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Minusculas -> (a-z)<br />
                                            Mayusculas -> (A-Z)<br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                            Máximo de caracteres -> 100<br />
                                        </td></tr>
                                    </table>
                                </span>
                                        
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
            </td>
        </tr>
    </table>        
    </center>

<br />
<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>

</asp:Content>

