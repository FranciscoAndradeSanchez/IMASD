<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="CatEspecieTipo.aspx.vb" Inherits="CatEspecieTipo" title="Catalogo Tipo de Especie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">

<script type="text/javascript" src="js/fnayuda.js"></script>

<asp:SiteMapPath ID="SiteMapPath2" runat="server"></asp:SiteMapPath>
    <br />
<br />

<asp:Label ID="lbTitulo" runat="server" CssClass="thtablaComun" Text="Catálogo de Tipo de Especie"></asp:Label><br />
    <br />
    <asp:Label ID="lbError" runat="server" Text="" CssClass="mesajeError" Visible="false"></asp:Label>
    <br />
    <asp:ObjectDataSource ID="odsCatEspecieTipo" runat="server" DeleteMethod="Delete"
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData"
        TypeName="dsAppTableAdapters.CatEspecieTipoTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_CveEspecieTipo" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="DescTipo" Type="String" />
            <asp:Parameter Name="Original_CveEspecieTipo" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="CveEspecieTipo" Type="Int32" />
            <asp:Parameter Name="DescTipo" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:GridView ID="GridViewCatEspecieTipo" runat="server" AutoGenerateColumns="False"
        BorderWidth="0px" DataKeyNames="CveEspecieTipo" DataSourceID="odsCatEspecieTipo"
        Width="70%">
        <RowStyle CssClass="tablaItemTemplate" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="cmdEditar" runat="server" CommandArgument='<%# Eval("CveEspecieTipo") %>'
                        CommandName="edit" ImageUrl="~/images/aplicacion/btnEditar.gif"  CausesValidation="false"/>
                </ItemTemplate>
                <EditItemTemplate></EditItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:BoundField DataField="CveEspecieTipo" HeaderText="ID" InsertVisible="False"
                ReadOnly="True" SortExpression="CveEspecieTipo">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="DescTipo" HeaderText="DescTipo" SortExpression="DescTipo" />
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:ImageButton ID="cmdCancelar" runat="server" CommandName="cancel" ImageUrl="~/images/aplicacion/btnCancelar.gif" CausesValidation="false" />
                    <asp:ImageButton ID="cmdGuardar" runat="server" CommandName="update" ImageUrl="~/images/aplicacion/btnGuardar.gif" CausesValidation="false" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="cmdEliminar" runat="server" CommandArgument='<%# Eval("CveEspecieTipo") %>' CausesValidation="false"
                          CommandName="delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" OnClientClick="<%# Eval(DescTipo&quot;, return confirm('Esta seguro de eliminar a {0}?')) %>" />
                       <%-- CommandName="delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" OnClientClick="<%# Eval(&quit;DescTipo&quot;, &quot;return confirm('Esta seguro de eliminar a {0}?')&quot;) %>" />--%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="tablaHeaderTemplate" />
        <EditRowStyle CssClass="tablaItemTemplate" />
        <AlternatingRowStyle CssClass="tablaAlternatigTemplate" />
    </asp:GridView>
    <br />
    <asp:Panel ID="pnlAgregar" runat="server" DefaultButton="cmdAgregar">
        <table border="0" class="tablaItemTemplate">
        <tr>
            <td colspan="2">
                <asp:Label ID="lb_Error" runat="server" Text=""
                    CssClass="mesajeError" Visible="false"></asp:Label>
                <asp:RequiredFieldValidator
                    ID="rfv_EspecieTipoADD" runat="server" ControlToValidate="txt_DescTipo"
                    ErrorMessage="La Descripción del tipo es requerida"
                    ToolTip="La descripción del tipo es requerida" CssClass="mesajeError" 
                    ForeColor="Black">La descripción del tipo es requerida</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ID="rev_EspecieTipoADD" runat="server" ControlToValidate="txt_DescTipo"
                    ToolTip="La descripción tiene caracteres no permitidos ó es mayor a 100 caracteres"
                    ErrorMessage="La descripción tiene caracteres no permitidos ó es mayor a 100 caracteres" 
                    ValidationExpression="^[0-9.a-zA-Z'ñÑÁáÉéÍíÓóÚúÜü\s-]{1,100}$"  CssClass="mesajeError" 
                    ForeColor="Black">La descripción tiene caracteres no permitidos ó es mayor a 100 caracteres
                    <a href="javascript:MostrarAyuda('Ayuda_EspecieTipoADD')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                    </asp:RegularExpressionValidator>
                    
                <span id="Ayuda_EspecieTipoADD" class="msgAyuda" style="visibility:hidden">
                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                        <th><a href="javascript:MostrarAyuda('Ayuda_EspecieTipoADD')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
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
            <th>Descripción:</th>
            <td align="left">
                <asp:TextBox ID="txt_DescTipo" runat="server" Text="" MaxLength="100" Columns="60" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:ImageButton ID="cmdAgregar" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" CausesValidation="true" />
            </td>
        </tr>
        
        </table>
    </asp:Panel>
</asp:Content>

