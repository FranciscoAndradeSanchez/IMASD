<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="CatTipoApoyo.aspx.vb" Inherits="CatTipoApoyo" title="Catalogo de Tipos de Apoyo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">

<script type="text/javascript" src="js/fnayuda.js"></script>

<asp:SiteMapPath ID="SiteMapPath2" runat="server"></asp:SiteMapPath>
<br /><br /><br />

<asp:Label ID="lbTitulo" runat="server" CssClass="thtablaComun" Text="Catálogo Tipo Apoyos"></asp:Label><br />
    <br />
    <asp:Label ID="lb_Error" runat="server" Text=""
        CssClass="mesajeError" Visible="false"></asp:Label>
    <center>
    <table class="tablaHeaderTemplate" border="0">
        <tr>
            <td colspan="2">
            <asp:GridView ID="Grid_TipoApoyo" runat="server" AutoGenerateColumns="False" ShowFooter="True"
             BorderWidth="0px">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table border="0" class="tablaHeaderTemplate" width="100%">
                                <tr><td style="width:110px;"></td><td style="width:20px" align="center">Clave</td><td>Descripción</td><td></td></tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table border="0" class="tablaItemTemplate" width="100%">
                                <tr>
                                    <td style="width:110px;"><asp:ImageButton ID="cmdEditar" runat="server" ImageUrl="~/images/aplicacion/btnEditar.gif" CommandName="edit" CausesValidation="false" /></td>
                                    <td style="width:50px">
                                        <asp:Label ID="lb_CveTipoApoyo" runat="server" Text='<%#Bind("CveTipoApoyo") %>'></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lb_DesTipoApoyo" runat="server" Text='<%#Bind("DesTipoApoyo") %>'></asp:Label><br />
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
                                        <asp:Label ID="lb_CveTipoApoyo" runat="server" Text='<%#Bind("CveTipoApoyo") %>'></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lb_DesTipoApoyo" runat="server" Text='<%#Bind("DesTipoApoyo") %>'></asp:Label><br />
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
                                        <asp:Label ID="lb_CveTipoApoyo" runat="server" Text='<%#Bind("CveTipoApoyo") %>'></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txt_DesTipoApoyo" runat="server" Text='<%#Bind("DesTipoApoyo") %>' MaxLength="100" Columns="40"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator
                                            ID="rfv_DesTipoApoyo" runat="server" ControlToValidate="txt_DesTipoApoyo"
                                            ErrorMessage="La descripción del apoyo es requerida"
                                            ToolTip="La descripción del apoyo es requerida" CssClass="mesajeError" 
                                            ForeColor="black">La descripción del apoyo es requerida</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="rev_DesTipoApoyo" runat="server" ControlToValidate="txt_DesTipoApoyo"
                                            ToolTip="La descripción del apoyo tiene caracteres no permitidos"
                                            ErrorMessage="La descripción del apoyo tiene caracteres no permitidos" 
                                            ValidationExpression="^[a-zA-Z.,\sñÑÁáÉéÍíÓóÚúÜü\(\)-]{1,100}$"  CssClass="mesajeError" 
                                            ForeColor="black">La descripción del apoyo tiene caracteres no permitidos
                                            <a href="javascript:MostrarAyuda('Ayuda_DesTipoApoyo')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_DesTipoApoyo" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_DesTipoApoyo')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Minusculas -> (a-z)<br />
                                                    Mayusculas -> (A-Z)<br />
                                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                    Especiales ->&nbsp;&nbsp;  - ' . ( ) , <br />
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
                                    <td style="width:50px"><asp:TextBox ID="txt_CveTipoApoyo_ADD" runat="server" Text="" MaxLength="2" Columns="2"></asp:TextBox></td>
                                    <td><asp:TextBox ID="txt_DesTipoApoyo_ADD" runat="server" Text="" MaxLength="100" Columns="40"></asp:TextBox></td>
                                    <td style="width:110px"><asp:ImageButton ID="cmdAdd" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" CommandName="ADD" CausesValidation="true" /></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="3">
                                        <asp:RequiredFieldValidator
                                            ID="rfv_CveTipoApoyo_ADD" runat="server" ControlToValidate="txt_CveTipoApoyo_ADD"
                                            ErrorMessage="La clave del apoyo es requerida"
                                            ToolTip="La clave del apoyo es requerida" CssClass="mesajeError" 
                                            ForeColor="black" >La clave del apoyo es requerida</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="rev_CveTipoApoyo_ADD" runat="server" ControlToValidate="txt_CveTipoApoyo_ADD"
                                            ToolTip="La clave del apoyo tiene caracteres no permitidos o no es de 2 dígitos"
                                            ErrorMessage="La clave del apoyo tiene caracteres no permitidos o no es de 2 dígitos" 
                                            ValidationExpression="^[a-zA-Z0-9]{2}$"  CssClass="mesajeError" 
                                            ForeColor="black">La clave del apoyo tiene caracteres no permitidos o no es de 2 dígitos
                                            <a href="javascript:MostrarAyuda('Ayuda_CveTipoApoyo_ADD')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_CveTipoApoyo_ADD" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_CveTipoApoyo_ADD')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Minusculas -> (a-z)<br />
                                                    Mayusculas -> (A-Z)<br />
                                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                                    Caracteres -> 2 exactos<br />
                                                </td></tr>
                                            </table>
                                        </span>
                                        <asp:RequiredFieldValidator
                                            ID="rfv_DesTipoApoyo_ADD" runat="server" ControlToValidate="txt_DesTipoApoyo_ADD"
                                            ErrorMessage="La descripción del apoyo es requerida"
                                            ToolTip="La descripción del apoyo es requerida" CssClass="mesajeError" 
                                            ForeColor="black">La descripción del apoyo es requerida</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="rev_DesTipoApoyo_ADD" runat="server" ControlToValidate="txt_DesTipoApoyo_ADD"
                                            ToolTip="La descripción del apoyo tiene caracteres no permitidos"
                                            ErrorMessage="La descripción del apoyo tiene caracteres no permitidos" 
                                            ValidationExpression="^[a-zA-Z.,\sñÑÁáÉéÍíÓóÚúÜü\(\)-]{1,100}$"  CssClass="mesajeError" 
                                            ForeColor="black">La descripción del apoyo tiene caracteres no permitidos
                                            <a href="javascript:MostrarAyuda('Ayuda_DesTipoApoyo_ADD')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_DesTipoApoyo_ADD" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_DesTipoApoyo_ADD')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Minusculas -> (a-z)<br />
                                                    Mayusculas -> (A-Z)<br />
                                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                    Especiales ->&nbsp;&nbsp;  - ' . ( ) , <br />
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
                            <td style="width:50px"><asp:TextBox ID="txt_CveTipoApoyo_ADD_empty" runat="server" Text="" MaxLength="2" Columns="2"></asp:TextBox></td>
                            <td><asp:TextBox ID="txt_DesTipoApoyo_ADD_empty" runat="server" Text="" MaxLength="100" Columns="40"></asp:TextBox></td>
                            <td style="width:110px"><asp:ImageButton ID="cmdAdd" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" CommandName="ADD_empty" CausesValidation="true" /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="3">
                                <asp:RequiredFieldValidator
                                    ID="rfv_CveTipoApoyo_ADD_empty" runat="server" ControlToValidate="txt_CveTipoApoyo_ADD_empty"
                                    ErrorMessage="La clave del apoyo es requerida"
                                    ToolTip="La clave del apoyo es requerida" CssClass="mesajeError" 
                                    ForeColor="black">La clave del apoyo es requerida</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator
                                    ID="rev_CveTipoApoyo_ADD_empty" runat="server" ControlToValidate="txt_CveTipoApoyo_ADD_empty"
                                    ToolTip="La clave del apoyo tiene caracteres no permitidos o no es de 2 dígitos"
                                    ErrorMessage="La clave del apoyo tiene caracteres no permitidos o no es de 2 dígitos" 
                                    ValidationExpression="^[a-zA-Z0-9]{2}$"  CssClass="mesajeError" 
                                    ForeColor="black">La clave del apoyo tiene caracteres no permitidos o no es de 2 dígitos
                                    <a href="javascript:MostrarAyuda('Ayuda_CveTipoApoyo_ADD_empty')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                    </asp:RegularExpressionValidator>
                                    
                                <span id="Ayuda_CveTipoApoyo_ADD_empty" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_CveTipoApoyo_ADD_empty')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Minusculas -> (a-z)<br />
                                            Mayusculas -> (A-Z)<br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Caracteres -> 2 exactos<br />
                                        </td></tr>
                                    </table>
                                </span>
                                <asp:RequiredFieldValidator
                                    ID="rfv_DesTipoApoyo_ADD_empty" runat="server" ControlToValidate="txt_DesTipoApoyo_ADD_empty"
                                    ErrorMessage="La descripción del apoyo es requerida"
                                    ToolTip="La descripción del apoyo es requerida" CssClass="mesajeError" 
                                    ForeColor="black">La descripción del apoyo es requerida</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator
                                    ID="rev_DesTipoApoyo_ADD_empty" runat="server" ControlToValidate="txt_DesTipoApoyo_ADD_empty"
                                    ToolTip="La descripción del apoyo tiene caracteres no permitidos"
                                    ErrorMessage="La descripción del apoyo tiene caracteres no permitidos" 
                                    ValidationExpression="^[a-zA-Z.,\sñÑÁáÉéÍíÓóÚúÜü\(\)-]{1,100}$"  CssClass="mesajeError" 
                                    ForeColor="black">La descripción del apoyo tiene caracteres no permitidos
                                    <a href="javascript:MostrarAyuda('Ayuda_DesTipoApoyo_ADD')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                    </asp:RegularExpressionValidator>
                                    
                                <span id="Ayuda_DesTipoApoyo_ADD" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_DesTipoApoyo_ADD')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Minusculas -> (a-z)<br />
                                            Mayusculas -> (A-Z)<br />
                                            Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                            Especiales ->&nbsp;&nbsp;  - ' . ( ) , <br />
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

