<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="CatEspecies_Nvo.aspx.vb" Inherits="CatEspecies_Nvo" title="Especies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">

<script type="text/javascript" src="js/fnayuda.js"></script>

<asp:SiteMapPath ID="SiteMapPath2" runat="server"></asp:SiteMapPath>
<br /><br /><br />


    <asp:Label ID="lbTitulo" runat="server" CssClass="thtablaComun" Text="Catálogo de Especies"></asp:Label><br />
    <br />
    <asp:Panel ID="pnlBusquedaEspecies" runat="server" DefaultButton="ibtnBuscarEspecies">
    <table class="tablaComun" border="0" width="90%">
        <tr>
            <td style="width: 30%"></td>
            <td align="left" valign="middle" style="width: 54%">
                <asp:TextBox ID="txtBusqueda" runat="server" Width="250px" MaxLength="100"></asp:TextBox>
                <asp:RegularExpressionValidator
                    ID="revNombreProyectoEdt" runat="server" ControlToValidate="txtBusqueda" ErrorMessage="Texto a buscar tiene caracteres no permitidos"
                    ForeColor="" ToolTip="Texto a buscar tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator>
                <asp:ImageButton ID="ibtnBuscarEspecies" runat="server" ImageUrl="~/images/aplicacion/btnBuscar.gif" ImageAlign="AbsBottom" />
            </td>
        </tr>
    </table>
    </asp:Panel>
    <center>
    <asp:ObjectDataSource ID="odsCatEspecieTipo" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="dsAppTableAdapters.CatEspecieTipoTableAdapter"></asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="odsSiNo" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetData" TypeName="dsAppTableAdapters.spSiNoTableAdapter">
                                </asp:ObjectDataSource>
    <asp:GridView ID="Grid_Infraestructura" runat="server" AutoGenerateColumns="false" ShowFooter="true"
     BorderWidth="0px" AllowPaging="True" PageSize="20">
        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <table border="0" class="tablaHeaderTemplate" width="100%">
                        <tr>
                            <td style="width:110px;"></td>
                            <td style="width:50px; text-align:left;">Clave</td>
                            <td style="width:120px; text-align:left;">Especie</td>
                            <td style="width:150px; text-align:left;">Tipo</td>
                            <td style="text-align:left;">¿Es maderable?</td>                     
                            <td style="width:110px;"></td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table border="0" class="tablaItemTemplate" width="100%">
                        <tr>
                            <td style="width:110px;"><asp:ImageButton ID="cmdEditar" runat="server" ImageUrl="~/images/aplicacion/btnEditar.gif" CommandName="edit" CausesValidation="false" /></td>
                            <td style="width:50px">
                                <asp:Label ID="lb_CveEspecie" runat="server" Text='<%#Bind("CveEspecie") %>'></asp:Label>
                            </td>
                            <td style="width:120px">
                                <asp:Label ID="lb_TipoInfraestructura" runat="server" Text='<%#Bind("NomCientifico") %>'></asp:Label>
                            </td>
                            <td style="width:150px">
                                <asp:Label ID="lb_DescTipo" runat="server" Text='<%#Bind("DescTipo") %>'></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lb_Infraestructura" runat="server" Text='<%#Bind("SiNo") %>'></asp:Label><br />
                                <asp:Label ID="lb_Error" runat="server" Text=""
                                    CssClass="mensajeFlotante" ForeColor="black" BackColor="yellow" 
                                    BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Visible="false" 
                                    Font-Size="X-Small"></asp:Label>
                            </td>
                            <td style="width:110px;"><asp:ImageButton ID="cmdEliminar" runat="server" ImageUrl="~/images/aplicacion/btnEliminar.gif" CommandName="delete" CausesValidation="false" /></td>
                        </tr>
                    </table>
                </ItemTemplate>                
                <EditItemTemplate>
                    <table border="0" class="tablaItemTemplate" width="80%">
                        <tr>
                            <th colspan="2" class="tablaEditarTemplate">Editando...</th>
                        </tr>
                        <tr>
                            <th>Clave:</th>
                            <td align="left">
                                <asp:Label ID="lb_CveEspecie" runat="server" Text='<%#Bind("CveEspecie") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>Tipo:</th>
                            <td align="left">
                                <asp:DropDownList ID="ddl_CveEspecieTipoEdt" runat="server" DataSourceID="odsCatEspecieTipo" DataTextField="DescTipo" DataValueField="CveEspecieTipo" SelectedValue='<%# Bind("CveEspecieTipo") %>'></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>Maderable:</th>
                            <td align="left">
                                <asp:DropDownList ID="ddl_EsMaderable" runat="server"
                                 DataSourceID="odsSiNo"
                                 DataTextField="SiNo"
                                 DataValueField="CveSiNo"
                                 SelectedValue='<%#Bind("EsForestal") %>'>
                                </asp:DropDownList>&nbsp;
                            </td>
                         </tr>
                         <tr>
                            <td colspan="2">
                                <asp:Label ID="lb_Error" runat="server" Text=""
                                    CssClass="mesajeError" Visible="false"></asp:Label>
                                <%--<asp:RequiredFieldValidator
                                    ID="rfv_Infraestructura" runat="server" ControlToValidate="txt_Infraestructura"
                                    ErrorMessage="La Descripción de la infraestructura es requerida"
                                    ToolTip="La descripción de la infraestructura es requerida" CssClass="mesajeError" 
                                    ForeColor="Black">La descripción de la infraestructura es requerida</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator
                                    ID="rev_Infraestructura" runat="server" ControlToValidate="txt_Infraestructura"
                                    ToolTip="La descripción de la infraestructura tiene caracteres no permitidos ó es mayor a 100 caracteres"
                                    ErrorMessage="La descripción de la infraestructura tiene caracteres no permitidos ó es mayor a 100 caracteres" 
                                    ValidationExpression="^[0-9.a-zA-Z'ñÑÁáÉéÍíÓóÚúÜü\s-]{1,100}$"  CssClass="mesajeError" 
                                    ForeColor="Black">La descripción de la infraestructura tiene caracteres no permitidos ó es mayor a 100 caracteres
                                    <a href="javascript:MostrarAyuda('Ayuda_Infraestructura')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                    </asp:RegularExpressionValidator>--%>
                                    
                                <span id="Ayuda_Infraestructura" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_Infraestructura')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                                        <tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Minusculas -> (a-z)<br />
                                            Mayusculas -> (A-Z)<br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                            Especiales -> (-, ,',.)<br />
                                            Máximo de caracteres -> 100<br />
                                        </td>
                                        </tr>
                                    </table>
                                </span>
                                
                            </td>
                         </tr>
                         <tr>
                            <th>Nombre Científico:</th>
                            <td align="left">
                                <asp:TextBox ID="txt_NombreCientifico" runat="server" Text='<%#Bind("NomCientifico") %>' MaxLength="100" Columns="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:ImageButton ID="cmdGuardar" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" CommandName="update" CausesValidation="true" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="cmdCancelar" runat="server" ImageUrl="~/images/aplicacion/btnCancelar.gif" CommandName="cancel" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </EditItemTemplate>
                <FooterTemplate>
                    <table border="0" class="tablaItemTemplate">
                        <tr>
                            <th>Tipo:</th>
                            <td align="left">
                                <asp:DropDownList ID="ddl_CveEspecieTipoADD" runat="server" DataSourceID="odsCatEspecieTipo" DataTextField="DescTipo" DataValueField="CveEspecieTipo" ></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Maderable:</th>
                            <td align="left">
                                <asp:DropDownList ID="ddl_EsMaderableADD" runat="server"
                                 DataSourceID="odsSiNo"
                                 DataTextField="SiNo"
                                 DataValueField="CveSiNo">
                                </asp:DropDownList>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lb_Error" runat="server" Text=""
                                    CssClass="mesajeError" Visible="false"></asp:Label>
                                <%--<asp:RequiredFieldValidator
                                    ID="rfv_Infraestructura_ADD" runat="server" ControlToValidate="txt_Infraestructura_ADD"
                                    ErrorMessage="La Descripción de la infraestructura es requerida"
                                    ToolTip="La descripción de la infraestructura es requerida" CssClass="mesajeError" 
                                    ForeColor="Black">La descripción de la infraestructura es requerida</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator
                                    ID="rev_Infraestructura_ADD" runat="server" ControlToValidate="txt_Infraestructura_ADD"
                                    ToolTip="La descripción de la infraestructura tiene caracteres no permitidos ó es mayor a 100 caracteres"
                                    ErrorMessage="La descripción de la infraestructura tiene caracteres no permitidos ó es mayor a 100 caracteres" 
                                    ValidationExpression="^[0-9.a-zA-Z'ñÑÁáÉéÍíÓóÚúÜü\s-]{1,100}$"  CssClass="mesajeError" 
                                    ForeColor="Black">La descripción de la infraestructura tiene caracteres no permitidos ó es mayor a 100 caracteres
                                    <a href="javascript:MostrarAyuda('Ayuda_Infraestructura_ADD')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                    </asp:RegularExpressionValidator>--%>
                                    
                                <span id="Ayuda_Infraestructura_ADD" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_Infraestructura_ADD')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                                        <tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Minusculas -> (a-z)<br />
                                            Mayusculas -> (A-Z)<br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                            Especiales -> (-, ,',.)<br />
                                            Máximo de caracteres -> 100<br />
                                        </td>
                                        </tr>
                                    </table>
                                </span>
                                
                                
                            </td>
                        </tr>
                        <tr>
                            <th>Nombre Científico:</th>
                            <td align="left">
                                <asp:TextBox ID="txt_NombreCientificoADD" runat="server" Text="" MaxLength="100" Columns="60" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:ImageButton ID="cmdAddInfraestructura" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" CommandName="ADD" CausesValidation="true" />
                            </td>
                        </tr>
                        
                    </table>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
        <AlternatingRowStyle CssClass="tablaAlternatigTemplate" />
    </asp:GridView>
            
    </center>

<br />
<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>


</asp:Content>

