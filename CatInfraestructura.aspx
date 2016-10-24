<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="CatInfraestructura.aspx.vb" Inherits="CatInfraestructura" title="Catálogo de infraestructura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">

<script type="text/javascript" src="js/fnayuda.js"></script>

<asp:SiteMapPath ID="SiteMapPath2" runat="server"></asp:SiteMapPath>
<br /><br /><br />


    <asp:Label ID="lbTitulo" runat="server" CssClass="thtablaComun" Text="Catálogo de Infraestructura"></asp:Label><br />
    <br />
    <center>
    <asp:GridView ID="Grid_Infraestructura" runat="server" AutoGenerateColumns="false" ShowFooter="true"
     BorderWidth="0px">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <table border="0" class="tablaHeaderTemplate" width="100%">
                        <tr>
                            <td style="width:110px;"></td>
                            <td style="width:50px" align="center">Clave</td>
                            <td style="width:120px" align="center">Tipo de Infraestructura</td>
                            <td>Descripción</td>
                            <td></td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table border="0" class="tablaItemTemplate" width="100%">
                        <tr>
                            <td style="width:110px;"><asp:ImageButton ID="cmdEditar" runat="server" ImageUrl="~/images/aplicacion/btnEditar.gif" CommandName="edit" CausesValidation="false" /></td>
                            <td style="width:50px">
                                <asp:Label ID="lb_CveInfraestructura" runat="server" Text='<%#Bind("CveInfraestructura") %>'></asp:Label>
                            </td>
                            <td style="width:120px">
                                <asp:Label ID="lb_TipoInfraestructura" runat="server" Text='<%#Bind("TipoInfraestructura") %>'></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lb_Infraestructura" runat="server" Text='<%#Bind("Infraestructura") %>'></asp:Label><br />
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
                                <asp:Label ID="lb_CveInfraestructura" runat="server" Text='<%#Bind("CveInfraestructura") %>'></asp:Label>
                            </td>
                            <td style="width:120px">
                                <asp:Label ID="lb_TipoInfraestructura" runat="server" Text='<%#Bind("TipoInfraestructura") %>'></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lb_Infraestructura" runat="server" Text='<%#Bind("Infraestructura") %>'></asp:Label><br />
                                <asp:Label ID="lb_Error" runat="server" Text=""
                                    CssClass="mesajeError" Visible="false"></asp:Label>
                            </td>
                            <td style="width:110px;"><asp:ImageButton ID="cmdEliminar" runat="server" ImageUrl="~/images/aplicacion/btnEliminar.gif" CommandName="delete" CausesValidation="false" /></td>
                        </tr>
                    </table>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <table border="0" class="tablaItemTemplate" width="80%">
                        <tr>
                            <th colspan="2" class="tablaEditarTemplate">Editando...</th>
                        </tr>
                        <tr>
                            <th>Clave:</th>
                            <td align="left">
                                <asp:Label ID="lb_CveInfraestructura" runat="server" Text='<%#Bind("CveInfraestructura") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>Tipo Infraestructura:</th>
                            <td align="left">
                                <asp:DropDownList ID="lst_CveTipoInfraestructura" runat="server"
                                 DataSourceID="odsCatTipoInfraestructura"
                                 DataTextField="TipoInfraestructura"
                                 DataValueField="CveTipoInfraestructura"
                                 SelectedValue='<%#Bind("CveTipoInfraestructura") %>'>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsCatTipoInfraestructura" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetDataTipoInfraestructuraDDL" TypeName="dsAppTableAdapters.spTipoInfraestructura_SelectDDLTableAdapter">
                                </asp:ObjectDataSource>
                            </td>
                         </tr>
                         <tr>
                            <td colspan="2">
                                <asp:Label ID="lb_Error" runat="server" Text=""
                                    CssClass="mesajeError" Visible="false"></asp:Label>
                                <asp:RequiredFieldValidator
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
                                    </asp:RegularExpressionValidator>
                                    
                                <span id="Ayuda_Infraestructura" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_Infraestructura')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Minusculas -> (a-z)<br />
                                            Mayusculas -> (A-Z)<br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                            Especiales -> (-, ,',.)<br />
                                            Máximo de caracteres -> 100<br />
                                        </td>
                                    </table>
                                </span>
                                
                            </td>
                         </tr>
                         <tr>
                            <th>Descripción:</th>
                            <td align="left">
                                <asp:TextBox ID="txt_Infraestructura" runat="server" Text='<%#Bind("Infraestructura") %>' MaxLength="100" Columns="50" Rows="4" TextMode="MultiLine"></asp:TextBox>
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
                            <th>Tipo de Infraestructura:</th>
                            <td align="left">
                                <asp:DropDownList ID="lst_CveTipoInfraestructura_ADD" runat="server"
                                 DataSourceID="odsCatTipoInfraestructura_ADD"
                                 DataTextField="TipoInfraestructura"
                                 DataValueField="CveTipoInfraestructura">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsCatTipoInfraestructura_ADD" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetDataTipoInfraestructuraDDL" TypeName="dsAppTableAdapters.spTipoInfraestructura_SelectDDLTableAdapter">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lb_Error" runat="server" Text=""
                                    CssClass="mesajeError" Visible="false"></asp:Label>
                                <asp:RequiredFieldValidator
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
                                    </asp:RegularExpressionValidator>
                                    
                                <span id="Ayuda_Infraestructura_ADD" class="msgAyuda" style="visibility:hidden">
                                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                        <th><a href="javascript:MostrarAyuda('Ayuda_Infraestructura_ADD')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                                        <td>
                                            Caracteres permitidos:<br /><br />
                                            Minusculas -> (a-z)<br />
                                            Mayusculas -> (A-Z)<br />
                                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                            Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                            Especiales -> (-, ,',.)<br />
                                            Máximo de caracteres -> 100<br />
                                        </td>
                                    </table>
                                </span>
                                
                                
                            </td>
                        </tr>
                        <tr>
                            <th>Descripción:</th>
                            <td align="left">
                                <asp:TextBox ID="txt_Infraestructura_ADD" runat="server" Text="" MaxLength="100" Rows="4" Columns="60" TextMode="MultiLine"></asp:TextBox>
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
        <EmptyDataTemplate>
            <table border="0" class="tablaItemTemplate">
                <tr>
                    <th>Tipo de Infraestructura:</th>
                    <td align="left">
                        <asp:DropDownList ID="lst_CveTipoInfraestructura_ADD_empty" runat="server"
                         DataSourceID="odsCatTipoInfraestructura_ADD_empty"
                         DataTextField="TipoInfraestructura"
                         DataValueField="CveTipoInfraestructura">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="odsCatTipoInfraestructura_ADD_empty" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetDataTipoInfraestructuraDDL" TypeName="dsAppTableAdapters.spTipoInfraestructura_SelectDDLTableAdapter">
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lb_Error" runat="server" Text=""
                            CssClass="mesajeError" Visible="false"></asp:Label>
                        <asp:RequiredFieldValidator
                            ID="rfv_Infraestructura_ADD_empty" runat="server" ControlToValidate="txt_Infraestructura_ADD_empty"
                            ErrorMessage="La Descripción de la infraestructura es requerida"
                            ToolTip="La descripción de la infraestructura es requerida" CssClass="mesajeError" 
                            ForeColor="Black">La descripción de la infraestructura es requerida</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            ID="rev_Infraestructura_ADD_empty" runat="server" ControlToValidate="txt_Infraestructura_ADD_empty"
                            ToolTip="La descripción de la infraestructura tiene caracteres no permitidos ó es mayor a 100 caracteres"
                            ErrorMessage="La descripción de la infraestructura tiene caracteres no permitidos ó es mayor a 100 caracteres" 
                            ValidationExpression="^[0-9.a-zA-Z'ñÑÁáÉéÍíÓóÚúÜü\s-]{1,100}$"  CssClass="mesajeError" 
                            ForeColor="Black">La descripción de la infraestructura tiene caracteres no permitidos ó es mayor a 100 caracteres
                            <a href="javascript:MostrarAyuda('Ayuda_Infraestructura_ADD_empty')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                            </asp:RegularExpressionValidator>
                            
                        <span id="Ayuda_Infraestructura_ADD_empty" class="msgAyuda" style="visibility:hidden">
                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                <th><a href="javascript:MostrarAyuda('Ayuda_Infraestructura_ADD_empty')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                                <td>
                                    Caracteres permitidos:<br /><br />
                                    Minusculas -> (a-z)<br />
                                    Mayusculas -> (A-Z)<br />
                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                    Especiales -> (-, ,',.)<br />
                                    Máximo de caracteres -> 100<br />
                                </td>
                            </table>
                        </span>
                        
                    </td>
                </tr>
                <tr>
                    <th>Descripción:</th>
                    <td align="left">
                        <asp:TextBox ID="txt_Infraestructura_ADD_empty" runat="server" Text="" MaxLength="100" Rows="4" Columns="20" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:ImageButton ID="cmdAddInfraestructura" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" CommandName="ADD_empty" CausesValidation="true" />
                    </td>
                </tr>
                
            </table>
        </EmptyDataTemplate>
    </asp:GridView>
            
    </center>

<br />
<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>


</asp:Content>

