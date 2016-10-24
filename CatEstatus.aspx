<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="CatEstatus.aspx.vb" Inherits="CatEstatus" title="Catálogo de Estatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">

<script type="text/javascript" src="js/fnayuda.js"></script>

<asp:SiteMapPath ID="SiteMapPath2" runat="server"></asp:SiteMapPath>
<br /><br /><br />


    <asp:Label ID="lbTitulo" runat="server" CssClass="thtablaComun" Text="Catálogo de Estatus"></asp:Label><br />
    <br />
    <center>
    <asp:Label ID="lb_Error" runat="server" Text=""
        CssClass="mensajeFlotante" ForeColor="black" BackColor="yellow" 
        BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Visible="false"
        Font-Size="X-Small"></asp:Label>
    <table class="tablaHeaderTemplate" border="0">
        <tr>
            <th style="text-align: right">
                Objeto:&nbsp;
            </th>
            <td>
            <asp:DropDownList ID="lst_CveObjeto" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <asp:GridView ID="Grid_Estatus" runat="server" AutoGenerateColumns="false" ShowFooter="true"
             BorderWidth="0px">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table border="0" class="tablaHeaderTemplate" width="100%">
                                <tr><td style="width:110px;"></td><td style="width:20px" align="center">Clave</td><td>Estatus</td><td></td></tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table border="0" class="tablaItemTemplate" width="100%">
                                <tr>
                                    <td style="width:110px;"><asp:ImageButton ID="cmdEditar" runat="server" ImageUrl="~/images/aplicacion/btnEditar.gif" CommandName="edit" CausesValidation="false" /></td>
                                    <td style="width:50px">
                                        <asp:Label ID="lb_CveEstatus" runat="server" Text='<%#Bind("CveEstatus") %>'></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lb_DesEstatus" runat="server" Text='<%#Bind("DesEstatus") %>'></asp:Label><br />
                                        <asp:Label ID="lb_Error" runat="server" Text=""
                                            CssClass="mensajeFlotante" ForeColor="black" BackColor="yellow" 
                                            BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Visible="false" 
                                            Font-Size="X-Small"></asp:Label>
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
                                        <asp:Label ID="lb_CveEstatus" runat="server" Text='<%#Bind("CveEstatus") %>'></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lb_DesEstatus" runat="server" Text='<%#Bind("DesEstatus") %>'></asp:Label><br />
                                        <asp:Label ID="lb_Error" runat="server" Text=""
                                            CssClass="mensajeFlotante" ForeColor="black" BackColor="yellow" 
                                            BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Visible="false"
                                            Font-Size="X-Small"></asp:Label>
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
                                        <asp:Label ID="lb_CveEstatus" runat="server" Text='<%#Bind("CveEstatus") %>'></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txt_DesEstatus" runat="server" Text='<%#Bind("DesEstatus") %>' MaxLength="100" Columns="20"></asp:TextBox>
                                        <asp:RequiredFieldValidator
                                            ID="rfv_DesEstatus" runat="server" ControlToValidate="txt_DesEstatus"
                                            ErrorMessage="La Descripción del estatus es requerida"
                                            ToolTip="La descripción del estatus es requerida" CssClass="mensajeFlotante" 
                                            ForeColor="black" BackColor="yellow" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Font-Size="X-Small"
                                            >La descripción del estatus es requerida</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="rev_DesEstatus" runat="server" ControlToValidate="txt_DesEstatus"
                                            ToolTip="La descripción del estatus tiene caracteres no permitidos"
                                            ErrorMessage="La descripción del estatus tiene caracteres no permitidos" 
                                            ValidationExpression="^[a-zA-Z'ñÑÁáÉéÍíÓóÚúÜü\s-]{1,40}$"  CssClass="mensajeFlotante" 
                                            ForeColor="black" BackColor="yellow" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Font-Size="X-Small"
                                            >La descripción del estatus tiene caracteres no permitidos
                                            <a href="javascript:MostrarAyuda('Ayuda_DesEstatus')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_DesEstatus" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_DesEstatus')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Minusculas -> (a-z)<br />
                                                    Mayusculas -> (A-Z)<br />
                                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                    Especiales -> (-, ,')<br />
                                                    Máximo de caracteres -> 40<br />
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
                                    <td><asp:TextBox ID="txt_DesEstatus_ADD" runat="server" Text="" MaxLength="100" Columns="20"></asp:TextBox></td>
                                    <td><asp:ImageButton ID="cmdAddEstatus" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" CommandName="ADD" CausesValidation="true" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RequiredFieldValidator
                                            ID="rfv_DesEstatus_ADD" runat="server" ControlToValidate="txt_DesEstatus_ADD"
                                            ErrorMessage="La Descripción del estatus es requerida"
                                            ToolTip="La descripción del estatus es requerida" CssClass="mensajeFlotante" 
                                            ForeColor="black" BackColor="yellow" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Font-Size="X-Small"
                                            >La descripción del estatus es requerida</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="rev_DesEstatus_ADD" runat="server" ControlToValidate="txt_DesEstatus_ADD"
                                            ToolTip="La descripción del estatus tiene caracteres no permitidos"
                                            ErrorMessage="La descripción del estatus tiene caracteres no permitidos" 
                                            ValidationExpression="^[a-zA-Z'ñÑÁáÉéÍíÓóÚúÜü\s-]{1,40}$"  CssClass="mensajeFlotante" 
                                            ForeColor="black" BackColor="yellow" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Font-Size="X-Small"
                                            >La descripción del estatus tiene caracteres no permitidos
                                            <a href="javascript:MostrarAyuda('Ayuda_DesEstatus_ADD')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_DesEstatus_ADD" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_DesEstatus_ADD')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Minusculas -> (a-z)<br />
                                                    Mayusculas -> (A-Z)<br />
                                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                    Especiales -> (-, ,')<br />
                                                    Máximo de caracteres -> 40<br />
                                                </td>
                                            </table>
                                        </span>
                                        
                                    </td>
                                </tr>
                            </table>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table border="0" class="tablaItemTemplate" width="100%">
                        <tr>
                            <td><asp:TextBox ID="txt_DesEstatus_ADD_empty" runat="server" Text="" MaxLength="100" Columns="30"></asp:TextBox></td>
                            <td><asp:ImageButton ID="cmdAddEstatus" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" CommandName="ADD_empty" CausesValidation="true" /></td>
                        </tr>
                        <tr>
                            <td colspan="">
                                <asp:RequiredFieldValidator
                                    ID="rfv_DesEstatus_ADD_empty" runat="server" ControlToValidate="txt_DesEstatus_ADD_empty"
                                    ErrorMessage="La Descripción del estatus es requerida"
                                    ToolTip="La descripción del estatus es requerida" CssClass="mensajeFlotante" 
                                    ForeColor="black" BackColor="yellow" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Font-Size="X-Small"
                                    >La descripción del estatus es requerida</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator
                                    ID="rev_DesEstatus_ADD_empty" runat="server" ControlToValidate="txt_DesEstatus_ADD_empty"
                                    ToolTip="La descripción del estatus tiene caracteres no permitidos"
                                    ErrorMessage="La descripción del estatus tiene caracteres no permitidos" 
                                    ValidationExpression="^[a-zA-Z'ñÑÁáÉéÍíÓóÚúÜü\s-]{1,40}$"  CssClass="mensajeFlotante" 
                                    ForeColor="black" BackColor="yellow" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Font-Size="X-Small"
                                    >La descripción del estatus tiene caracteres no permitidos
                                    <a href="javascript:MostrarAyuda('Ayuda_DesEstatus_ADD_empty')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                    </asp:RegularExpressionValidator>
                                    
                                <span id="Ayuda_DesEstatus_ADD_empty" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_DesEstatus_ADD_empty')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Minusculas -> (a-z)<br />
                                            Mayusculas -> (A-Z)<br />
                                            Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                            Especiales -> (-, ,')<br />
                                            Máximo de caracteres -> 40<br />
                                        </td>
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

