<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="CatResponsableTecnico.aspx.vb" Inherits="CatResponsableTecnico" title="Responsables Tecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">


<script type="text/javascript" src="js/fnayuda.js"></script>

<asp:SiteMapPath ID="SiteMapPath2" runat="server"></asp:SiteMapPath>
<br />
<br />
<asp:Label ID="lbTitulo" runat="server" CssClass="thtablaComun" Text="Catálogo de Responsables Técnicos"></asp:Label><br />
<br />
<asp:Label ID="lbError" runat="server" Text="" CssClass="mesajeError" Visible="false"></asp:Label>&nbsp;<br />
    <asp:MultiView ID="MultiViewRespTecnico" runat="server">
        <asp:View ID="ViewAdd" runat="server">
        <table border="0" class="tablaItemTemplate">
        <tr>
            <th>Nombre:</th>
            <td>
                <asp:TextBox ID="txtNombreAdd" runat="server" Text="" MaxLength="150" Columns="70" ></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvNombreAdd" runat="server" ControlToValidate="txtNombreAdd"
                    ErrorMessage="El nombre de responsable es requerida"
                    ToolTip="El nombre de responsable es requerida" CssClass="mesajeError" 
                    ForeColor="Black">El nombre de responsable es requerida</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ID="revNombreAdd" runat="server" ControlToValidate="txtNombreAdd"
                    ToolTip="El nombre del responsable tiene caracteres no permitidos ó es mayor a 150 caracteres"
                    ErrorMessage="El nombre del responsable tiene caracteres no permitidos ó es mayor a 150 caracteres" 
                    ValidationExpression="^[0-9.a-zA-Z'ñÑÁáÉéÍíÓóÚúÜü\s-]{1,150}$"  CssClass="mesajeError" 
                    ForeColor="Black">El nombre del responsable tiene caracteres no permitidos ó es mayor a 150 caracteres
                    <a href="javascript:MostrarAyuda('Ayuda_NombreAdd')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                    </asp:RegularExpressionValidator>
                    
                <span id="Ayuda_NombreAdd" class="msgAyuda" style="visibility:hidden">
                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                        <th><a href="javascript:MostrarAyuda('Ayuda_NombreAdd')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                        <tr>
                        <td>
                            Caracteres permitidos:<br /><br />
                            Minusculas -> (a-z)<br />
                            Mayusculas -> (A-Z)<br />
                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                            Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                            Especiales -> (-, ,',.)<br />
                            Máximo de caracteres -> 150<br />
                        </td>
                        </tr>
                    </table>
                </span>
            </td>
        </tr>
        <tr>
            <th>Ubicación:</th>
            <td>
                <asp:TextBox ID="txtUbicacionAdd" runat="server" Text="" MaxLength="100" Columns="70" ></asp:TextBox>
                
                <asp:RegularExpressionValidator
                    ID="revUbicacionAdd" runat="server" ControlToValidate="txtUbicacionAdd"
                    ToolTip="La ubicacion tiene caracteres no permitidos ó es mayor a 100 caracteres"
                    ErrorMessage="La ubicacion tiene caracteres no permitidos ó es mayor a 100 caracteres"
                    ValidationExpression="^[0-9.a-zA-Z'ñÑÁáÉéÍíÓóÚúÜü\s-]{1,100}$"  CssClass="mesajeError" 
                    ForeColor="Black">La ubicacion tiene caracteres no permitidos ó es mayor a 100 caracteres
                    <a href="javascript:MostrarAyuda('Ayuda_UbicacionAdd')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                    </asp:RegularExpressionValidator>
                    
                <span id="Ayuda_UbicacionAdd" class="msgAyuda" style="visibility:hidden">
                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                        <th><a href="javascript:MostrarAyuda('Ayuda_UbicacionAdd')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
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
            <th>Información general:</th>
            <td>
                <asp:TextBox ID="txtInfoAdd" runat="server" Text="" MaxLength="500" Columns="50" Rows="4" TextMode="MultiLine" ></asp:TextBox>
                
                <asp:RegularExpressionValidator
                    ID="revInfo" runat="server" ControlToValidate="txtInfoAdd"
                    ToolTip="La información tiene caracteres no permitidos ó es mayor a 100 caracteres"
                    ErrorMessage="La información tiene caracteres no permitidos ó es mayor a 100 caracteres"
                    ValidationExpression="^[0-9.a-zA-Z'ñÑÁáÉéÍíÓóÚúÜü\s-]{1,500}$"  CssClass="mesajeError" 
                    ForeColor="Black">La información tiene caracteres no permitidos ó es mayor a 100 caracteres
                    <a href="javascript:MostrarAyuda('Ayuda_InfoAdd')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                    </asp:RegularExpressionValidator>
                    
                <span id="Ayuda_InfoAdd" class="msgAyuda" style="visibility:hidden">
                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                        <th><a href="javascript:MostrarAyuda('Ayuda_InfoAdd')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                        <tr>
                        <td>
                            Caracteres permitidos:<br /><br />
                            Minusculas -> (a-z)<br />
                            Mayusculas -> (A-Z)<br />
                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                            Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                            Especiales -> (-, ,',.)<br />
                            Máximo de caracteres -> 500<br />
                        </td>
                        </tr>
                    </table>
                </span>
            </td>
        </tr>
        </table>
        
        <asp:ImageButton ID="imgbGuardarAdd" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" ImageAlign="Left" /><asp:ImageButton ID="imgbCancelarAdd" runat="server" ImageUrl="~/images/aplicacion/btnCancelar.gif" CausesValidation="False" /></asp:View>
        <asp:View ID="ViewLista" runat="server" EnableTheming="True">
    <asp:ImageButton ID="imgbNuevoRespTecnico" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" /><br />
            <br />
            <asp:ObjectDataSource ID="odsRespTecnico" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="dsAppTableAdapters.CatResponsableTecnicoTableAdapter"
                UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_CveResponsableTecnico" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Nombre" Type="String" />
                    <asp:Parameter Name="Ubicacion" Type="String" />
                    <asp:Parameter DefaultValue="" Name="Info" Type="String" />
                    <asp:Parameter DefaultValue="" Name="Original_CveResponsableTecnico" Type="Int32" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="Nombre" Type="String" />
                    <asp:Parameter Name="Ubicacion" Type="String" />
                    <asp:Parameter Name="Info" Type="String" />
                </InsertParameters>
            </asp:ObjectDataSource>
            <asp:Panel ID="pnlBusqueda" runat="server" DefaultButton="imgbBuscar" HorizontalAlign="Center">
                <asp:TextBox ID="txtBusqueda" runat="server" Width="245px"></asp:TextBox><asp:ImageButton
                    ID="imgbBuscar" runat="server" ImageAlign="AbsBottom" ImageUrl="~/images/aplicacion/btnBuscar.gif" /><br />
                <asp:LinkButton ID="lnkMostrarTodos" runat="server">Mostrar todos</asp:LinkButton></asp:Panel>
            &nbsp;
            <br />
            <br />
            <asp:GridView ID="GridViewRespTecnico" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" BorderStyle="None" BorderWidth="0px" DataKeyNames="CveResponsableTecnico"
                DataSourceID="odsRespTecnico">
                <PagerSettings Mode="NumericFirstLast" PageButtonCount="20" Position="TopAndBottom" />
                <RowStyle CssClass="tablaItemTemplate" />
                <EmptyDataRowStyle CssClass="tablaHeaderTemplate" />
                <Columns>
                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                        <EditItemTemplate>
                            &nbsp;
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbEditar" runat="server" CausesValidation="False" CommandArgument='<%# Eval("CveResponsableTecnico") %>'
                                CommandName="edit" ImageUrl="~/images/aplicacion/btnEditar.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CveResponsableTecnico" HeaderText="id" InsertVisible="False"
                        ReadOnly="True" SortExpression="CveResponsableTecnico">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="Ubicacion" HeaderText="Ubicacion" SortExpression="Ubicacion" />
                    <asp:TemplateField HeaderText="Informacion" SortExpression="Info">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Columns="30" Rows="4" Text='<%# Bind("Info") %>'
                                TextMode="MultiLine"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Info") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:ImageButton ID="imgbGuardarEdt" runat="server" CommandArgument='<%# Eval("CveResponsableTecnico") %>'
                                CommandName="update" ImageUrl="~/images/aplicacion/btnGuardar.gif" /><br />
                            <br />
                            <asp:ImageButton ID="imgbCancelarEdt" runat="server" CausesValidation="False" CommandArgument='<%# Eval("CveResponsableTecnico") %>'
                                CommandName="cancel" ImageUrl="~/images/aplicacion/btnCancelar.gif" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbEliminar" runat="server" CommandArgument='<%# Eval("CveResponsableTecnico") %>'
                                CommandName="delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" OnClientClick="<%# Eval(&quot;Nombre&quot;,&quot;return confirm('Esta seguro de eliminar al Resopnsable {0}')&quot;) %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="tablaEditarTemplate" />
                <EmptyDataTemplate>
                    No hay nigun reponsable técnico en el catalgo.
                </EmptyDataTemplate>
                <HeaderStyle CssClass="tablaHeaderTemplate tablaListaTemplate" />
                <EditRowStyle CssClass="tablaEditarTemplate" />
                <AlternatingRowStyle CssClass="tablaAlternatigTemplate" />
            </asp:GridView>
        </asp:View>
    </asp:MultiView><br />
    <br />
    <br />
    
</asp:Content>

