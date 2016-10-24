<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="Permisos.aspx.vb" Inherits="Permisos" title="Asignación de niveles de acceso" UICulture="es-MX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">
<table width="800" align="center" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td>
    <table align="center" border="0" cellpadding="3" cellspacing="0" width="90%" class="tablaComun">
        <tr>
            <th class="thtablaComun">&nbsp; Asignación de niveles de acceso</th>
        </tr>
        <tr>
            <td>&nbsp;
                <asp:TextBox ID="txtControl" runat="server" Enabled="False" Width="1px"></asp:TextBox>
                <asp:CustomValidator ID="cuvAsignarNivel" runat="server" ForeColor=""></asp:CustomValidator></td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="dtlUsuarios" runat="server" DataKeyField="CveUsuario" DataSourceID="odsNivelesUsuario"
                    Width="100%">
                    <ItemTemplate>
                        <table border="0" cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
                            <tr>
                                <td style="width: 16%">
                                    <asp:ImageButton ID="ibtnEditarPUItm" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
                                <td style="width: 46%">
                                    <asp:LinkButton ID="lnkbUsuarioPUItm" runat="server" CommandName="Select" Text='<%# Eval("CveUsuario") %>'></asp:LinkButton></td>
                                <td style="width: 22%">
                                    <asp:Label ID="lblNivelPUItm" runat="server" Text='<%# Eval("DescripcionNivel") %>'></asp:Label></td>
                                <td style="width: 16%">
                                    <asp:ImageButton ID="ibtnEliminarPUItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <table border="0" cellpadding="3" cellspacing="0" class="tablaAlternatigTemplate"
                            width="100%">
                            <tr>
                                <td style="width: 16%">
                                    <asp:ImageButton ID="ibtnEditarPUItm" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
                                <td style="width: 46%">
                                    <asp:LinkButton ID="lnkbUsuarioPUItm" runat="server" CommandName="Select" Text='<%# Eval("CveUsuario") %>'></asp:LinkButton></td>
                                <td style="width: 22%">
                                    <asp:Label ID="lblNivelPUItm" runat="server" Text='<%# Eval("DescripcionNivel") %>'></asp:Label></td>
                                <td style="width: 16%">
                                    <asp:ImageButton ID="ibtnEliminarPUItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
                            </tr>
                        </table>
                    </AlternatingItemTemplate>
                    <EditItemTemplate>
                        <table border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate" width="100%">
                            <tr>
                                <td style="width: 30%">
                                    Usuario</td>
                                <td style="width: 70%">
                                    <asp:Label ID="lblCveUsuarioPUEdt" runat="server" Text='<%# Eval("CveUsuario") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Nombre</td>
                                <td style="width: 70%">
                                    <asp:Label ID="lblNombrePUEdt" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                    <asp:Label ID="lblAPaternoPUEdt" runat="server" Text='<%# Eval("APaterno") %>'></asp:Label>
                                    <asp:Label ID="lblAmaternoPUEdt" runat="server" Text='<%# Eval("Amaterno") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Institución</td>
                                <td style="width: 70%">
                                    <asp:Label ID="lblInstitucionPUEdt" runat="server" Text='<%# Eval("Institucion") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Correo electrónico</td>
                                <td style="width: 70%">
                                    <asp:Label ID="lblEmailPUEdt" runat="server" Text='<%# Eval("Email") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Nivel de usuario</td>
                                <td style="width: 70%">
                                    <asp:DropDownList ID="ddlNivelPUEdt" runat="server" DataSourceID="odsNivelPUEdt"
                                        DataTextField="DesNivel" DataValueField="Nivel" SelectedValue='<%# Eval("Nivel") %>'>
                                    </asp:DropDownList><asp:RangeValidator ID="ravNivelPUEdt" runat="server" ControlToValidate="ddlNivelPUEdt"
                                        ErrorMessage="Debe seleccionar un nivel de usuario" ForeColor="" MaximumValue="1000000"
                                        MinimumValue="1" ToolTip="Debe seleccionar un nivel de usuario" Type="Integer">x</asp:RangeValidator>
                                    <asp:CustomValidator ID="cuvNivelUsuarioPUEdt" runat="server" ForeColor="">x</asp:CustomValidator>
                                    <asp:ObjectDataSource ID="odsNivelPUEdt" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetDataCatNivelDDL" TypeName="dsAppTableAdapters.CatNivelTableAdapter">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                </td>
                                <td style="width: 70%">
                                    <asp:ValidationSummary ID="vsAsuntosPUEdt" runat="server" DisplayMode="List" ForeColor="" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                </td>
                                <td style="width: 70%">
                                    <asp:ImageButton ID="ibtnGuardarPUEdt" runat="server" CommandName="Update" ImageUrl="~/images/aplicacion/btnGuardar.gif"
                                         />
                                    <asp:ImageButton ID="ibtnCancelarPUEdt" runat="server" CausesValidation="False" CommandName="Cancel"
                                        ImageUrl="~/images/aplicacion/btnCancelar.gif" /></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <table border="0" cellpadding="3" cellspacing="0" class="tablaHeaderTemplate" width="100%">
                            <tr>
                                <th style="width: 16%">
                                    &nbsp;</th>
                                <th style="width: 46%">
                                    Usuario</th>
                                <th style="width: 22%">
                                    Nivel</th>
                                <th style="width: 16%">
                                    &nbsp;</th>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <SelectedItemTemplate>
                        <table border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate" width="100%">
                            <tr>
                                <td style="width: 30%">
                                    Usuario</td>
                                <td style="width: 70%">
                                    <asp:Label ID="lblCveUsuarioPUSel" runat="server" Text='<%# Eval("CveUsuario") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%; height: 22px">
                                    Nombre</td>
                                <td style="width: 70%; height: 22px">
                                    <asp:Label ID="lblNombrePUSel" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                    <asp:Label ID="lblAPaternoPUSel" runat="server" Text='<%# Eval("APaterno") %>'></asp:Label>
                                    <asp:Label ID="lblAmaternoPUSel" runat="server" Text='<%# Eval("Amaterno") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Escolaridad</td>
                                <td style="width: 70%">
                                    <asp:Label ID="lblEscolaridadPUSel" runat="server" Text='<%# Eval("Escolaridad") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Institución</td>
                                <td style="width: 70%">
                                    <asp:Label ID="lblInstitucionPUSel" runat="server" Text='<%# Eval("Institucion") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Departamento</td>
                                <td style="width: 70%">
                                    <asp:Label ID="lblDepartamentoPUSel" runat="server" Text='<%# Eval("Departamento") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Ocupación</td>
                                <td style="width: 70%">
                                    <asp:Label ID="lblOcupacionPUSel" runat="server" Text='<%# Eval("Ocupacion") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Especialidad</td>
                                <td style="width: 70%">
                                    <asp:Label ID="lblEspecialidadPUSel" runat="server" Text='<%# Eval("Especialidad") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Correo electrónico</td>
                                <td style="width: 70%">
                                    <asp:Label ID="lblEmailPUSel" runat="server" Text='<%# Eval("Email") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Estado</td>
                                <td style="width: 70%">
                                    <asp:Label ID="lblEstadoPUSel" runat="server" Text='<%# Eval("Estado") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Nivel de usuario</td>
                                <td style="width: 70%">
                                    <asp:Label ID="lblDescripcionNivelPUSel" runat="server" Text='<%# Eval("DescripcionNivel") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Uso que le dará a la información</td>
                                <td style="width: 70%">
                                    <asp:Label ID="lblUsoInformacionPUSel" runat="server" Text='<%# Eval("UsoInformacion") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    &nbsp;</td>
                                <td style="width: 70%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                </td>
                                <td style="width: 70%">
                                    <asp:ImageButton ID="ibtnRegresarPUSel" runat="server" CommandName="Cancel" ImageUrl="~/images/aplicacion/btnRegresar.gif" /></td>
                            </tr>
                        </table>
                    </SelectedItemTemplate>
                </asp:DataList><asp:ObjectDataSource ID="odsNivelesUsuario" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetUsuarioApp" TypeName="dsAppTableAdapters.CatUsuarioTableAdapter">
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
    </td>
</tr>
</table>
</asp:Content>

