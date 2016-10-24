<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="True" CodeFile="RegistroProyectos.aspx.vb" Inherits="RegistroProyectos" title="Proyectos" Culture="es-MX" UICulture="es-MX" Theme ="skin" EnableSessionState="True" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="EclipseWebSolutions.DatePicker" Namespace="EclipseWebSolutions.DatePicker"
    TagPrefix="ews" %>
<asp:Content ID="cntAltaProyectos" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">
<asp:ScriptManager ID="scrmInfoGeneral" runat="server"></asp:ScriptManager>
<asp:MultiView ID="mviewProyectos" runat="server">
    <asp:View ID="viewLista" runat="server">
    <table width="100%" align="center">
        <tr>
            <td>
                <asp:Panel ID="pnlBusqueda" runat="server" Visible="True" Width="100%">
                    <table width="90%" align="center" class="tablaComun">
                            <tr>
                                <td style="width: 30%"></td>
                                <td align="left" valign="middle" style="width: 54%">
                                    <asp:TextBox ID="txtBusqueda" runat="server" Width="250px" MaxLength="100"></asp:TextBox><asp:RegularExpressionValidator
                                        ID="revNombreProyectoEdt" runat="server" ControlToValidate="txtBusqueda" ErrorMessage="Texto a buscar tiene caracteres no permitidos"
                                        ForeColor="" ToolTip="Texto a buscar tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><asp:ImageButton
                                        ID="ibtnBuscarProyectos" runat="server" ImageUrl="~/images/aplicacion/btnBuscar.gif" /></td>
                                    <td style="width: 16%"><asp:LinkButton ID="lnkbMasOpciones" runat="server" OnClick="lnkbMasOpciones_Click">+ más opciones ...</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td align="left" colspan="3" valign="middle">
                                    <asp:Panel ID="pnlMasOpcionesBusqueda" runat="server" Visible="False" Width="100%">
                                        <table cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
                                            <tr>
                                                <td align="left" style="width: 30%">
                                                    <%--Clave CONACYT--%></td>
                                                <td align="left" style="width: 70%">
                                                    <asp:TextBox ID="txtCveCONACYTBuscar" runat="server" MaxLength="20" Visible="False" Enabled="False"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="revCveCONACYTBuscar" runat="server" ControlToValidate="txtCveCONACYTBuscar"
                                                        ErrorMessage="Clave CONACYT tiene caracteres no permitidos" ForeColor="" ToolTip="Clave CONACYT tiene caracteres no permitidos"
                                                        ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    <asp:UpdatePanel ID="updpTipoApoyoEstatus" runat="server">
                                                        <ContentTemplate>
                                                        
                                                            <table width="100%" border="0" cellpadding="3" cellspacing="0">
                                                                <tr>
                                                                    <td style="width: 30%">Tipo de apoyo</td>
                                                                    <td style="width: 70%">
                                                                        <asp:DropDownList ID="ddlTipoApoyoBuscar" runat="server" AutoPostBack="True" DataSourceID="odsTipoApoyoBuscar" DataTextField="DesTipoApoyo" DataValueField="CveTipoApoyo" Width="300px">
                                                                        </asp:DropDownList><asp:ObjectDataSource ID="odsTipoApoyoBuscar" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                            SelectMethod="GetDataTipoApoyoBuscar" TypeName="dsAppTableAdapters.spTipoApoyoDDLTableAdapter">
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 30%">Estatus</td>
                                                                    <td style="width: 70%">
                                                                        <asp:DropDownList ID="ddlEstatusBuscar" runat="server" DataSourceID="odsEstatusBuscar" DataTextField="DesEstatus" DataValueField="CveEstatus" Width="300px">
                                                                        </asp:DropDownList>&nbsp;(elegir <i>Tipo de Apoyo</i> primero)
                                                                        
                                                                        <asp:ObjectDataSource ID="odsEstatusBuscar" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                            SelectMethod="GetDataByTipoApoyoBuscar" TypeName="dsAppTableAdapters.spEstatusDDLTableAdapter">
                                                                            <SelectParameters>
                                                                                <asp:ControlParameter ControlID="ddlTipoApoyoBuscar" Name="CveTipoApoyo" PropertyName="SelectedValue"
                                                                                    Type="String" />
                                                                            </SelectParameters>                                                                            
                                                                        </asp:ObjectDataSource>
                                                                        <%--Entra el Polo--%>
                                                                        <%--<asp:ObjectDataSource ID="odsEstatusBuscar" runat="server" OldValuesParameterFormatString="original_{0}"
                                                                            SelectMethod="GetData" TypeName="dsAppTableAdapters.spEstatusLVCTableAdapter" />--%>
                                                                        <%--Sale el Polo--%>                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 30%">
                                                    Región de seguimiento</td>
                                                <td align="left" style="width: 70%">
                                                    <asp:DropDownList ID="ddlRegionSegBuscar" runat="server" DataSourceID="odsRegionBuscar" DataTextField="DesRegion" DataValueField="CveRegion" Width="300px">
                                                    </asp:DropDownList><asp:ObjectDataSource ID="odsRegionBuscar" runat="server" OldValuesParameterFormatString="original_{0}"
                                                        SelectMethod="GetDataRegionBuscar" TypeName="dsAppTableAdapters.spRegionDDLTableAdapter">
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 30%">
                                                    Año de la convocatoria</td>
                                                <td align="left" style="width: 70%">
                                                    <asp:DropDownList ID="ddlAnioProyectoBuscar" runat="server" DataSourceID="odsAnioConvocatoriaBuscar" DataTextField="AnioDesc" DataValueField="Anio" Width="100px">
                                                    </asp:DropDownList><asp:ObjectDataSource ID="odsAnioConvocatoriaBuscar" runat="server"
                                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="dsAppTableAdapters.spAnioConvocatoriaDDLBuscarTableAdapter">
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 30%">
                                                    Institución</td>
                                                <td align="left" style="width: 70%">
                                                    <asp:DropDownList ID="ddlInstitucionBuscar" runat="server" DataSourceID="odsInstitucionBuscar" DataTextField="DesInstitucion" DataValueField="CveInstitucion" Width="300px">
                                                    </asp:DropDownList><asp:ObjectDataSource ID="odsInstitucionBuscar" runat="server"
                                                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataInstitucionBuscar"
                                                        TypeName="dsAppTableAdapters.spInstitucionDDLTableAdapter"></asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 30%">
                                                </td>
                                                <td align="left" style="width: 70%">
                                                    <asp:ImageButton
                                        ID="ibtnBuscarProyectosMas" runat="server" ImageUrl="~/images/aplicacion/btnBuscar.gif" /></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlNavegacionUp" runat="server" Visible="True" Width ="100%">
                    <table width="90%" align="center" class="tablaComun">
                    <tr>
                        <td align="left" colspan="3">
                            <asp:Label ID="lblTotalProyectosUP" runat="server" Text="0 Proyectos encontrados"></asp:Label></td>
                            <td style="width:25%; text-align:right;"><asp:Label ID="lblPaginaActualUP" runat="server" Text="Página 0 de 0"></asp:Label>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 25%">&nbsp;</td>
                        <td style="width: 25%; text-align: left">
                            <asp:LinkButton ID="lnkbPrimeraUp" runat="server">|<< Primera</asp:LinkButton>
                            <asp:LinkButton ID="lnkbAnteriorUp" runat="server"><< Anterior</asp:LinkButton></td>
                        <td style="width: 25%; text-align: right">
                            <asp:LinkButton ID="lnkbSiguienteUp" runat="server">Siguiente >></asp:LinkButton>
                            <asp:LinkButton ID="lnkbUltimaUp" runat="server">Última >>|</asp:LinkButton></td>
                        <td style="width: 25%" align="right">
                            <%-- entra el Polo --%>
                            <asp:DropDownList ID="ddlPaginadorLVC" runat="server" OnSelectedIndexChanged="directoPagina" AutoPostBack="True"/>
                            <%-- sale el Polo --%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:25%;"><asp:ImageButton ID="ibtnNuevoUp" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" CommandName="New" /></td>
                        <td style="width:25%;"></td>
                        <td style="width:25%;"></td>
                        <td style="width:25%; text-align:right;"><asp:Label ID="lblPaginaActualUP_LVC" runat="server" Text=""></asp:Label>&nbsp;</td>
                    </tr>
                </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="dtlProyectos" runat="server" DataKeyField="CveProyecto" DataSourceID="odsProyecto" HorizontalAlign="Center" Width="100%">
                <AlternatingItemStyle CssClass="tablaAlternatigTemplate" />
                <ItemStyle CssClass="tablaItemTemplate" />
                <ItemTemplate>
                    <table width="90%" align="center" border="0" cellpadding="3" cellspacing="0">
                        <tr>
                            <th style="width: 25%">
                                Clave CONACYT</th>
                            <th style="width: 75%">
                                <asp:LinkButton ID="lnkbCveProyecto" runat="server" CommandName="Select" Text='<%# Eval("CveProyecto") %>'></asp:LinkButton></th>
                        </tr>
                        <tr>
                            <td style="width: 25%">
                                Nombre del proyecto:
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblNombreProyecto" runat="server" Text='<%# Eval("NombreProyecto") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 25%">
                                Año de la convocatoria:
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblAnioConvocatoria" runat="server" Text='<%# Eval("AnioConvocatoria") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 25%">
                                Región seguimiento:
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblRegionSeguimiento" runat="server" Text='<%# Eval("RegionSeguimiento") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 25%">
                                Institución:
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblInstitucion" runat="server" Text='<%# Eval("Institucion") %>'></asp:Label></td>
                        </tr>
                        <tr  class="xxxs" style="display:none;">
                            <td style="width: 25%">
                                <asp:TextBox ID="txtVal" runat="server" MaxLength="1" ReadOnly="True" Width="1px"></asp:TextBox>
                                </td>
                            <td style="width: 75%">
                                &nbsp;<asp:CustomValidator ID="cuvEliminar" runat="server" ControlToValidate="txtVal" ForeColor=""></asp:CustomValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 25%">&nbsp;
                            </td>
                            <td style="width: 75%">
                                <asp:ImageButton ID="ibtnEditarIT" runat="server" ImageUrl="~/images/aplicacion/btnEditar.gif" CommandArgument='<%# Eval("cveProyecto") %>' CommandName="Edit" />
                                <asp:ImageButton ID="ibtnEliminarIT" runat="server" ImageUrl="~/images/aplicacion/btnEliminar.gif" CommandName="Delete" CommandArgument='<%# Eval("CveProyecto") %>' /></td>
                        </tr>
                    </table>
                </ItemTemplate>
		    <EditItemTemplate>
		        <table align="center" border="0" cellpadding="0" cellspacing="0" class="tablaComun" width="100%">
		            <tr>
		                <td style="border-top-style: double; border-top-color: white; height: 30px;">
		                    &nbsp;
		                    </td>
		            </tr>
		            <tr>
		                <td>
		                    <div>
		                        <asp:ImageButton ID="ibtnDatosGeneralesEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_dg_sel.gif"  OnClick="ibtnDatosGeneralesEdt_Click" CssClass="pestana" />
		                        <asp:ImageButton ID="ibtnInfraestructuraEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_in_rep.gif" OnClick="ibtnInfraestructuraEdt_Click" CssClass="pestana" />    
		                    </div>
		                </td>
		            </tr>
		            <tr>
		                <td>
		                    <div>
		                        <asp:ImageButton ID="ibtnDetalleMontoEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_dm_rep.gif" OnClick="ibtnDetalleMontoEdt_Click"  CssClass="pestana"/>
		                        <asp:ImageButton ID="ibtnDifusionDivulgaEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_dd_rep.gif" OnClick="ibtnDifusionDivulgaEdt_Click"  CssClass="pestana"/>
		                        <asp:ImageButton ID="ibtnVisitasTecnicasEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_vt_rep.gif" OnClick="ibtnVisitasTecnicasEdt_Click"  CssClass="pestana"/>
		                        <asp:ImageButton ID="ibtnSeguimientoEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_sg_rep.gif" OnClick="ibtnSeguimientoEdt_Click"  CssClass="pestana"/>
		                        <asp:ImageButton ID="ibtnAdministrativoEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_ad_rep.gif" OnClick="ibtnAdministrativoEdt_Click"  CssClass="pestana"/>
		                    </div>
		                </td>
		            </tr>
		            <tr>
		                <td>
		                    <div>
		                        <asp:ImageButton ID="ibtnEtapasEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_et_rep.gif" OnClick="ibtnEtapasEdt_Click" CssClass="pestana"/>
		                        <%-- ELIMINADO ***<asp:ImageButton ID="ibtnProblematicasEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_pr_rep.gif" OnClick="ibtnProblematicasEdt_Click" CssClass="pestana"/>--%>
		                        <asp:ImageButton ID="ibtnParticipantesEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_pa_rep.gif" OnClick="ibtnParticipantesEdt_Click" CssClass="pestana"/>
		                        <asp:ImageButton ID="ibtnEspeciesEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_es_rep.gif" OnClick="ibtnEspeciesEdt_Click" CssClass="pestana"/>
		                        <asp:ImageButton ID="ibtnEstadosEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_st_rep.gif"  OnClick="ibtnEstadosEdt_Click" CssClass="pestana"/>
		                    </div>
		                </td>
		            </tr>
		            <tr>
		                <td>
		                    <asp:MultiView ID="mviewProyectosEdt" runat="server" ActiveViewIndex="0">
		                        <asp:View ID="viewDatosGeneralesEdt" runat="server">
		                            <table align="center" border="0" cellpadding="3" cellspacing="0" width="90%">
		                                <tr>
		                                    <td colspan="2">
		                                        &nbsp;&nbsp;
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <th class="thtablaComun" colspan="2">
		                                        Datos Generales del proyecto</th>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%; height: 15px">&nbsp;
		                                        </td>
		                                    <td style="width: 70%; height: 15px">&nbsp;
		                                        </td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Clave CONACYT</td>
		                                    <td style="width: 70%">
		                                        <asp:Label ID="lblCveCONACYTEdt" runat="server" Text='<%# Eval("CveProyecto") %>'></asp:Label>
		                                        <asp:HiddenField ID="hdnfFechaCapturaEdt" runat="server" Value='<%# Eval("FechaCaptura", "{0:d}") %>' />
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Nombre del proyecto</td>
		                                    <td style="width: 70%">
		                                        <asp:TextBox ID="txtNombreEdt" runat="server" MaxLength="300" Rows="4" Text='<%# Eval("NombreProyecto") %>'
		                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvNombreProyectoEdt"
		                                                runat="server" ControlToValidate="txtNombreEdt" ErrorMessage="Nombre del proyecto es un valor requerido"
		                                                ForeColor="" ToolTip="Nombre del proyecto es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                    ID="revNombreProyectoEdt" runat="server" ControlToValidate="txtNombreEdt" ErrorMessage="Nombre del proyecto tiene caracteres no permitidos"
		                                                    ForeColor="" ToolTip="Nombre del proyecto tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><asp:CustomValidator
		                                                    ID="cuvExcepcionesEdt" runat="server" ErrorMessage="Error al intentar guardar los datos"
		                                                    ForeColor="" ToolTip="Error al intentar guardar los datos" ControlToValidate="txtNombreEdt">x</asp:CustomValidator></td>
		                                </tr>
		                                <tr>
                                            <td>Responsable Técnico</td>
                                            <td>
                                                <asp:DropDownList ID="ddlResponsableTecnicoEdt" runat="server"
                                                    DataSourceID="odsResponsableTecnicoEdt"
                                                    DataTextField="Nombre"
                                                    DataValueField="CveResponsableTecnico"
                                                    SelectedValue='<%# Eval("CveResponsableTecnico") %>'>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsResponsableTecnicoEdt" runat="server"
                                                    OldValuesParameterFormatString="original_{0}"
                                                    SelectMethod="GetData"
                                                    TypeName="dsAppTableAdapters.spResponsableTecnicoDDLTableAdapter">
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Resumen</td>
		                                    <td style="width: 70%">
		                                        <asp:TextBox ID="txtResumenEdt" runat="server" MaxLength="1073741823" Rows="4" Text='<%# Eval("Resumen") %>'
		                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvResumenEdt"
		                                                runat="server" ControlToValidate="txtResumenEdt" ErrorMessage="Resumen del proyecto es un valor requerido"
		                                                ForeColor="" ToolTip="Resumen del proyecto es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                    ID="revResumenEdt" runat="server" ControlToValidate="txtResumenEdt" ErrorMessage="Resumen del proyecto tiene caracteres no permitidos"
		                                                    ForeColor="" ToolTip="Resumen del proyecto tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Objetivo general</td>
		                                    <td style="width: 70%">
		                                        <asp:TextBox ID="txtObjetivoGralEdt" runat="server" MaxLength="1000" Rows="4" Text='<%# Eval("ObjetivoGeneral") %>'
		                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvObjetivoGralEdt"
		                                                runat="server" ControlToValidate="txtObjetivoGralEdt" ErrorMessage="Objetivo general es un valor requerido"
		                                                ForeColor="" ToolTip="Objetivo general es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                    ID="revObjetivoGralEdt" runat="server" ControlToValidate="txtObjetivoGralEdt"
		                                                    ErrorMessage="Objetivo general tiene caracteres no permitidos" ForeColor="" ToolTip="Objetivo general tiene caracteres no permitidos"
		                                                    ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Objetivos específicos</td>
		                                    <td style="width: 70%">
		                                        <asp:TextBox ID="txtObjetivosEspEdt" runat="server" MaxLength="4000" Rows="4" Text='<%# Eval("ObjetivosEspecificos") %>'
		                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="revObetivosEspEdt"
		                                                runat="server" ControlToValidate="txtObjetivosEspEdt" ErrorMessage="Objetivos específicos es un valor requerido"
		                                                ForeColor="" ToolTip="Objetivos específicos es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                    ID="revObjetivosEspEdt" runat="server" ControlToValidate="txtObjetivosEspEdt"
		                                                    ErrorMessage="Objetivos específicos tiene caracteres no permitidos" ForeColor=""
		                                                    ToolTip="Objetivos específicos tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Tipo de proyecto</td>
		                                    <td style="width: 70%">
		                                        <asp:DropDownList ID="ddlTipoProyectoEdt" runat="server" DataSourceID="odsTipoProyectoDDLEdt"
		                                            DataTextField="DesTipoProy" DataValueField="CveTipoProy" SelectedValue='<%# Eval("CveTipoProy") %>'
		                                            Width="400px">
		                                        </asp:DropDownList><asp:RangeValidator ID="ravTipoProyectoEdt" runat="server" ControlToValidate="ddlTipoProyectoEdt"
		                                            ErrorMessage="Indique el tipo de proyecto" ForeColor="" MaximumValue="1000" MinimumValue="1"
		                                            ToolTip="Indique el tipo de proyecto" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
		                                                ID="odsTipoProyectoDDLEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                SelectMethod="GetData" TypeName="dsAppTableAdapters.spTipoProyectoDDLTableAdapter">
		                                            </asp:ObjectDataSource>
		                                        &nbsp;&nbsp;
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Tipo de apoyo</td>
		                                    <td style="width: 70%">
		                                        <asp:DropDownList ID="ddlTipoApoyoEdt" runat="server" DataSourceID="odsTipoApoyoDDLEdt"
		                                            DataTextField="DesTipoApoyo" DataValueField="CveTipoApoyo" SelectedValue='<%# Eval("CveTipoApoyo") %>'
		                                            Width="400px">
		                                        </asp:DropDownList><asp:RegularExpressionValidator ID="revTipoApoyo" runat="server"
		                                            ControlToValidate="ddlTipoApoyoEdt" ErrorMessage="Indique el tipo de apoyo" ForeColor=""
		                                            ToolTip="Indique el tipo de apoyo" ValidationExpression="<%#ValExpTipoApoyo()%>">x</asp:RegularExpressionValidator>
		                                        <asp:ObjectDataSource ID="odsTipoApoyoDDLEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                            SelectMethod="GetData" TypeName="dsAppTableAdapters.spTipoApoyoDDLTableAdapter">
		                                        </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Área temática</td>
		                                    <td style="width: 70%">
		                                        <asp:DropDownList ID="ddlAreaTematicaEdt" runat="server" DataSourceID="odsAreaTematicaDDLEdt"
		                                            DataTextField="AreaTematica" DataValueField="CveAreaTematica" Width="400px" SelectedValue='<%# Eval("CveAreaTematica") %>'>
		                                        </asp:DropDownList><asp:RangeValidator ID="ravAreaTematicaEdt" runat="server" ControlToValidate="ddlAreaTematicaEdt"
		                                            ErrorMessage="Indique el área temática" ForeColor="" MaximumValue="1000" MinimumValue="1"
		                                            ToolTip="Indique el área temática" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
		                                                ID="odsAreaTematicaDDLEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                SelectMethod="GetData" TypeName="dsAppTableAdapters.spAreaTematicaDDLTableAdapter">
		                                            </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Institución</td>
		                                    <td style="width: 70%">
		                                        <asp:DropDownList ID="ddlInstitucionEdt" runat="server" DataSourceID="odsInstitucionDDLEdt"
		                                            DataTextField="DesInstitucion" DataValueField="CveInstitucion" SelectedValue='<%# Eval("CveInstitucion") %>'
		                                            Width="400px">
		                                        </asp:DropDownList><asp:RangeValidator ID="ravInstitucionEdt" runat="server" ControlToValidate="ddlInstitucionEdt"
		                                            ErrorMessage="Indique la institución" ForeColor="" MaximumValue="1000" MinimumValue="1"
		                                            ToolTip="Indique la institución" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
		                                                ID="odsInstitucionDDLEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                SelectMethod="GetData" TypeName="dsAppTableAdapters.spInstitucionDDLTableAdapter">
		                                            </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
                                            <td>Costo TOTAL del proyecto</td>
                                            <td>
                                                $<asp:TextBox ID="txtCostoTotalProyectoEdt" runat="server" Columns="12" MaxLength="10" Text='<%# Eval("CostoTotalProyecto","{0:F2}") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvCostoTotalProyectoEdt"
                                                    runat="server" ControlToValidate="txtCostoTotalProyectoEdt" ForeColor="" 
                                                    ErrorMessage="Costo total del proyecto es un valor requerido"
                                                    ToolTip="Costo total del proyecto es un valor requerido">x</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revCostoTotalProyectoEdt"
                                                    runat="server" ControlToValidate="txtCostoTotalProyectoEdt"
                                                    ErrorMessage="Costo total del proyecto tiene caracteres no permitidos" ForeColor=""
                                                    ToolTip="Costo total del proyecto tiene caracteres no permitidos" 
                                                    ValidationExpression="^([0-9]{1,}|[0-9]{0,}\.[0-9]{0,})$">x</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table border="0" width="100%">
                                                    <tr>
                                                        <td style="width: 30%">Aportacion Apoyo Institucional</td>
                                                        <td style="width: 30%">Aportacion Institucion Ejecutora</td>
                                                        <td>Otras Aportaciones</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            $<asp:TextBox ID="txtAportacionApoyoInstitucionalEdt" runat="server" Columns="12" MaxLength="10" Text='<%# Eval("AportacionApoyoInstitucional","{0:F2}") %>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAportacionApoyoInstitucionalEdt"
                                                                runat="server" ControlToValidate="txtAportacionApoyoInstitucionalEdt" ForeColor="" 
                                                                ErrorMessage="La aportacion de apoyo institucional es un valor requerido"
                                                                ToolTip="La aportacion de apoyo institucional es un valor requerido">x</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="revAportacionApoyoInstitucionalEdt"
                                                                runat="server" ControlToValidate="txtAportacionApoyoInstitucionalEdt"
                                                                ErrorMessage="La aportacion de apoyo institucional tiene caracteres no permitidos" ForeColor=""
                                                                ToolTip="La aportacion de apoyo institucional tiene caracteres no permitidos" 
                                                                ValidationExpression="^([0-9]{1,}|[0-9]{0,}\.[0-9]{0,})$">x</asp:RegularExpressionValidator>
                                                        </td>
                                                        <td>
                                                            $<asp:TextBox ID="txtAportacionInstitucionEjecutoraEdt" runat="server" Columns="12" MaxLength="10" Text='<%# Eval("AportacionInstitucionEjecutora","{0:F2}") %>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAportacionInstitucionEjecutoraEdt"
                                                                runat="server" ControlToValidate="txtAportacionInstitucionEjecutoraEdt" ForeColor="" 
                                                                ErrorMessage="La aportacion de la institucional ejecutora es un valor requerido"
                                                                ToolTip="La aportacion de la institucional ejecutora es un valor requerido">x</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="revAportacionInstitucionEjecutoraEdt"
                                                                runat="server" ControlToValidate="txtAportacionInstitucionEjecutoraEdt"
                                                                ErrorMessage="La aportacion de la institucional ejecutora tiene caracteres no permitidos" ForeColor=""
                                                                ToolTip="La aportacion de la institucional ejecutora tiene caracteres no permitidos" 
                                                                ValidationExpression="^([0-9]{1,}|[0-9]{0,}\.[0-9]{0,})$">x</asp:RegularExpressionValidator>
                                                        </td>
                                                        <td>
                                                            $<asp:TextBox ID="txtAportacionesOtrasEdt" runat="server" Columns="12" MaxLength="10" Text='<%# Eval("AportacionesOtras","{0:F2}") %>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvAportacionesOtrasEdt"
                                                                runat="server" ControlToValidate="txtAportacionesOtrasEdt" ForeColor="" 
                                                                ErrorMessage="Otras aportaciones es un valor requerido"
                                                                ToolTip="Otras aportaciones es un valor requerido">x</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="revAportacionesOtrasEdt"
                                                                runat="server" ControlToValidate="txtAportacionesOtrasEdt"
                                                                ErrorMessage="Otras aportaciones tiene caracteres no permitidos" ForeColor=""
                                                                ToolTip="Otras aportaciones tiene caracteres no permitidos" 
                                                                ValidationExpression="^([0-9]{1,}|[0-9]{0,}\.[0-9]{0,})$">x</asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Año de la convocatoria</td>
		                                    <td style="width: 70%">
		                                        <asp:DropDownList ID="ddlAnioConvEdt" runat="server" DataSourceID="odsAnioConvocatoriaEdt"
		                                            DataTextField="Anio" DataValueField="Anio" SelectedValue='<%# Eval("AnioConvocatoria") %>'
		                                            Width="400px">
		                                        </asp:DropDownList><asp:RangeValidator ID="ravAnioConvEdt" runat="server" ControlToValidate="ddlAnioConvEdt"
		                                            ErrorMessage="Indique el año de la convocatoria" ForeColor="" MaximumValue="2020"
		                                            MinimumValue="2001" ToolTip="Indique el año de la convocatoria" Type="Integer">x</asp:RangeValidator>
		                                        <asp:ObjectDataSource ID="odsAnioConvocatoriaEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                            SelectMethod="GetData" TypeName="dsAppTableAdapters.spAnioConvocatoriaDDLTableAdapter">
		                                        </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Gerencia regional de seguimiento</td>
		                                    <td style="width: 70%">
		                                        <asp:DropDownList ID="ddlRegionSegEdt" runat="server" DataSourceID="odsRegionDDLEdt"
		                                            DataTextField="DesRegion" DataValueField="CveRegion" SelectedValue='<%# Eval("CveRegion") %>'
		                                            Width="400px">
		                                        </asp:DropDownList><asp:RegularExpressionValidator ID="revRegionSegEdt" runat="server"
		                                            ControlToValidate="ddlRegionSegEdt" ErrorMessage="Indique la gerencia regional de sequimiento"
		                                            ForeColor="" ToolTip="Indique la gerencia regional de sequimiento" ValidationExpression="<%# ValExpRegion() %>">x</asp:RegularExpressionValidator>
		                                        <asp:ObjectDataSource ID="odsRegionDDLEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                            SelectMethod="GetData" TypeName="dsAppTableAdapters.spRegionDDLTableAdapter"></asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Escala</td>
		                                    <td style="width: 70%">
		                                        <asp:DropDownList ID="ddlEscalaEdt" runat="server" DataSourceID="odsEscalaDDLEdt"
		                                            DataTextField="DesEscala" DataValueField="CveEscala" SelectedValue='<%# Eval("CveEscala") %>'
		                                            Width="400px">
		                                        </asp:DropDownList><asp:RangeValidator ID="ravEscalaEdt" runat="server" ControlToValidate="ddlEscalaEdt"
		                                            ErrorMessage="Indique la escala" ForeColor="" MaximumValue="1000" MinimumValue="1"
		                                            ToolTip="Indique la escala" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
		                                                ID="odsEscalaDDLEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                SelectMethod="GetData" TypeName="dsAppTableAdapters.spEscalaDDLTableAdapter"></asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Vegetación</td>
		                                    <td style="width: 70%">
		                                        <asp:DropDownList ID="ddlVegetacionEdt" runat="server" DataSourceID="odsVegetacionDDLEdt"
		                                            DataTextField="DesVegetacion" DataValueField="CveVegetacion" SelectedValue='<%# Eval("CveVegetacion") %>'
		                                            Width="400px">
		                                        </asp:DropDownList><asp:RangeValidator ID="ravVegetacionEdt" runat="server" ControlToValidate="ddlVegetacionEdt"
		                                            ErrorMessage="Indique el tipo de vegetación" ForeColor="" MaximumValue="1000"
		                                            MinimumValue="1" ToolTip="Indique el tipo de vegetación" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
		                                                ID="odsVegetacionDDLEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                SelectMethod="GetData" TypeName="dsAppTableAdapters.spVegetacionDDLTableAdapter">
		                                            </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Ecosistema</td>
		                                    <td style="width: 70%">
		                                        <asp:DropDownList ID="ddlEcosistemaEdt" runat="server" DataSourceID="odsEcosistemaDDLEdt"
		                                            DataTextField="Descripcion" DataValueField="CveEcosistema" SelectedValue='<%# Eval("CveEcosistema") %>'
		                                            Width="400px">
		                                        </asp:DropDownList><asp:RangeValidator ID="ravEcosistemaEdt" runat="server" ControlToValidate="ddlEcosistemaEdt"
		                                            ErrorMessage="Indique el ecosistema" ForeColor="" MaximumValue="1000" MinimumValue="1"
		                                            ToolTip="Indique el ecosistema" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
		                                                ID="odsEcosistemaDDLEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                SelectMethod="GetData" TypeName="dsAppTableAdapters.spEcosistemaDDLTableAdapter">
		                                            </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Metodología</td>
		                                    <td style="width: 70%">
		                                        <asp:TextBox ID="txtMetodologiaEdt" runat="server" MaxLength="1073741823" Rows="4"
		                                            Text='<%# Eval("Metodologia") %>' TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator
		                                                ID="refMetodologiaEdt" runat="server" ControlToValidate="txtMetodologiaEdt" ErrorMessage="Metodología es un valor requerido"
		                                                ForeColor="" ToolTip="Metodología es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                    ID="revMetodologiaEdt" runat="server" ControlToValidate="txtMetodologiaEdt" ErrorMessage="Metodología tiene caracteres no permitidos"
		                                                    ForeColor="" ToolTip="Metodología tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Demanda</td>
		                                    <td style="width: 70%">
		                                        <asp:TextBox ID="txtDemandaEdt" runat="server" MaxLength="1000" Rows="4" Text='<%# Eval("Demanda") %>'
		                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
		                                                ID="revDemandaEdt" runat="server" ControlToValidate="txtDemandaEdt" ErrorMessage="Demanda tiene caracteres no permitidos"
		                                                ForeColor="" ToolTip="Demanda tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Demandante</td>
		                                    <td style="width: 70%">
		                                        <asp:TextBox ID="txtDemandanteEdt" runat="server" MaxLength="1000" Rows="4" Text='<%# Eval("Demandante") %>'
		                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
		                                                ID="revDemandanteEdt" runat="server" ControlToValidate="txtDemandanteEdt" ErrorMessage="Demandante tiene caracteres no permitidos"
		                                                ForeColor="" ToolTip="Demandante tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Resultados esperados</td>
		                                    <td style="width: 70%">
		                                        <asp:TextBox ID="txtResEsperadosEdt" runat="server" MaxLength="1000" Rows="4" Text='<%# Eval("ResultadosEsp") %>'
		                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvResEsperadosEdt"
		                                                runat="server" ControlToValidate="txtResEsperadosEdt" ErrorMessage="Resultados esperados es un valor requerido"
		                                                ForeColor="" ToolTip="Resultados esperados es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                    ID="revResEsperadosEdt" runat="server" ControlToValidate="txtResEsperadosEdt"
		                                                    ErrorMessage="Resultados esperados tiene caracteres no permitidos" ForeColor=""
		                                                    ToolTip="Resultados esperados tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Impactos esperados</td>
		                                    <td style="width: 70%">
		                                        <asp:TextBox ID="txtImpactosEsperadosEdt" runat="server" Rows="4"
		                                            Text='<%# Eval("ImpactosEsperados") %>' TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
		                                                ID="revImpactosEsperadosEdt" runat="server" ControlToValidate="txtImpactosEsperadosEdt"
		                                                ErrorMessage="Impactos esperados tiene caracteres no permitidos" ForeColor=""
		                                                ToolTip="Impactos esperados esperados tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Identificación del problema</td>
		                                    <td style="width: 70%">
		                                        <asp:TextBox ID="txtIdentProblemaEdt" runat="server" MaxLength="1000" Rows="4" Text='<%# Eval("IdentProblema") %>'
		                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
		                                                ID="revIdentProblemaEdt" runat="server" ControlToValidate="txtIdentProblemaEdt"
		                                                ErrorMessage="Identificación del problema tiene caracteres no permitidos" ForeColor=""
		                                                ToolTip="Identificación del problema tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                </tr>
		                                <%--el Polo ocultando esto--%>
		                                <tr style="display:none;">
		                                    <td style="width: 30%">
		                                        Cobertura operativa</td>
		                                    <td style="width: 70%">
		                                        <asp:TextBox ID="txtCoberturaOperativaEdt" runat="server" MaxLength="500" Rows="4"
		                                            Text='<%# Eval("CoberturaOperativa") %>' TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator ID="revCoberturaOperativaEdt" runat="server" ControlToValidate="txtCoberturaOperativaEdt"
		                                            ErrorMessage="Cobertura operativatiene caracteres no permitidos" ForeColor=""
		                                            ToolTip="Cobertura operativatiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Fecha convenio-acuerdo</td>
		                                    <td style="width: 70%">
		                                        <div id="Calendario">
		                                            &nbsp;<asp:UpdatePanel ID="uppaFechaConvenioAcuerdoEdt" runat="server">
		                                                <ContentTemplate>
		                                                    <ews:DatePicker ID="dpkrFechaConvAcueEdt" runat="server" CalendarPosition="DisplayRight"
		                                                        DateValue='<%# Eval("FechaConvAcue") %>' ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" />
		                                                    <asp:CustomValidator ID="cmvFechaConvAcueEdt" runat="server" ControlToValidate="dpkrFechaConvAcueEdt"
		                                                        ErrorMessage="Revise la fecha del convenio-acuerdo" ForeColor="" ToolTip="Revise la fecha del convenio-acuerdo">x</asp:CustomValidator>
		                                                    <asp:RegularExpressionValidator ID="revFechaConvAcueEdt" runat="server" ControlToValidate="dpkrFechaConvAcueEdt"
		                                                        ErrorMessage="Formato de fecha convenio-acuerdo debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                        ToolTip="Formato de fecha convenio-acuerdo debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
		                                                </ContentTemplate>
		                                            </asp:UpdatePanel>
		                                        </div>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Estatus del proyecto</td>
		                                    <td style="width: 70%">
		                                        <asp:DropDownList ID="ddlEstatusEdt" runat="server" DataSourceID="odsEstatusDDLEdt"
		                                            DataTextField="DesEstatus" DataValueField="CveEstatus" SelectedValue='<%# Eval("CveEstatus") %>'
		                                            Width="400px">
		                                        </asp:DropDownList><asp:RangeValidator ID="ravEstatusEdt" runat="server" ControlToValidate="ddlEstatusEdt"
		                                            ErrorMessage="Indique el estatus del proyecto" ForeColor="" MaximumValue="1000"
		                                            MinimumValue="1" ToolTip="Indique el estatus del proyecto" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
		                                                ID="odsEstatusDDLEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                SelectMethod="GetDataByTipoApoyo" TypeName="dsAppTableAdapters.spEstatusDDLTableAdapter">
		                                                <SelectParameters>
		                                                    <asp:FormParameter DefaultValue="" FormField="ddlTipoApoyoEdt" Name="CveTipoApoyo"
		                                                        Type="String" />
		                                                </SelectParameters>
		                                            </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <th class="thtablaComun" colspan="2">
		                                        Información para transferencia de tecnología</th>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Usuario destino</td>
		                                    <td style="width: 70%">
		                                        <asp:TextBox ID="txtUsuarioTTEdt" runat="server" MaxLength="1000" Rows="4" Text='<%# Eval("Usuario") %>'
		                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
		                                                ID="revUsuarioTTEdt" runat="server" ControlToValidate="txtUsuarioTTEdt" ErrorMessage="Usuario destino tiene caracteres no permitidos"
		                                                ForeColor="" ToolTip="Usuario destino esperados tiene caracteres no permitidos"
		                                                ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Sector</td>
		                                    <td style="width: 70%">
		                                        <asp:DropDownList ID="ddlSectorUsuarioTTEdt" runat="server" DataSourceID="odsSectorUsuarioDDLEdt"
		                                            DataTextField="DescSectorUsuario" DataValueField="CveSectorUsuario" SelectedValue='<%# Eval("CveSectorUsuario") %>'
		                                            Width="400px">
		                                        </asp:DropDownList><asp:RangeValidator ID="ravSectorEdt" runat="server" ControlToValidate="ddlSectorUsuarioTTEdt"
		                                            ErrorMessage="Indique el sector" ForeColor="" MaximumValue="1000" MinimumValue="-1"
		                                            ToolTip="Indique el sector del usuario destino" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
		                                                ID="odsSectorUsuarioDDLEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                SelectMethod="GetData" TypeName="dsAppTableAdapters.spSectorUsuarioDDLTableAdapter">
		                                            </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Materiales</td>
		                                    <td style="width: 70%">
		                                        <asp:TextBox ID="txtMaterialesTTEdt" runat="server" MaxLength="1000" Rows="4" Text='<%# Eval("Materiales") %>'
		                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
		                                                ID="revMaterialesEdt" runat="server" ControlToValidate="txtMaterialesTTEdt" ErrorMessage="Materiales tiene caracteres no permitidos"
		                                                ForeColor="" ToolTip="Materiales tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Requisitos</td>
		                                    <td style="width: 70%">
		                                        <asp:TextBox ID="txtRequisitosTTEdt" runat="server" MaxLength="1000" Rows="4" Text='<%# Eval("RequisitosTT") %>'
		                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
		                                                ID="revRequisitosTTEdt" runat="server" ControlToValidate="txtRequisitosTTEdt"
		                                                ErrorMessage="Requisitos tiene caracteres no permitidos" ForeColor="" ToolTip="Requisitos tiene caracteres no permitidos"
		                                                ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                </tr>
		                                <tr>
		                                    <td style="width: 30%">
		                                        Actividades</td>
		                                    <td style="width: 70%">
		                                        <asp:TextBox ID="txtActividadesTTEdt" runat="server" MaxLength="1000" Rows="4" Text='<%# Eval("ActividadesTT") %>'
		                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
		                                                ID="revActividadesTTEdt" runat="server" ControlToValidate="txtActividadesTTEdt"
		                                                ErrorMessage="Actividades tiene caracteres no permitidos" ForeColor="" ToolTip="Actividades tiene caracteres no permitidos"
		                                                ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="1">
		                                    </td>
		                                    <td>
		                                        <asp:ValidationSummary ID="vsValidacionEdt" runat="server" DisplayMode="List" ForeColor=""
		                                            HeaderText="Se encontraron los siguientes errores:" />
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="1">
		                                    </td>
		                                    <td>
		                                        <asp:ImageButton ID="ibtnActualizarEdt" runat="server" CommandName="Update" ImageUrl="~/images/aplicacion/btnGuardar.gif" />
		                                        <asp:ImageButton ID="ibtnCancelarEdt" runat="server" CommandName="Cancel" ImageUrl="~/images/aplicacion/btnCancelar.gif" CausesValidation="False" /></td>
		                                </tr>
		                            </table>
		                        </asp:View>
		                        <%-- ***ELIMINAR **<asp:View ID="viewProblematicasEdt" runat="server">
		                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
		                                <tr>
		                                    <td colspan="2">&nbsp;
		                                        </td>
		                                </tr>
		                                <tr>
		                                    <th class="thtablaComun" colspan="2" style="height: 19px">
		                                        Problemáticas relacionadas</th>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2" style="height: 15px"><asp:ImageButton ID="ibtnNuevoPBAdd" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" OnClick="ibtnNuevoPBAdd_Click" /></td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2" style="height: 15px">
		                                        <asp:Panel ID="pnlProblematicaPBAdd" runat="server" Width="100%" Visible="False">
		                                            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Problematica</td>
		                                                    <td style="width: 70%">
		                                                        <asp:DropDownList ID="ddlProblematicaPBAdd" runat="server" DataSourceID="odsProblematicaPBAdd"
		                                                                    DataTextField="DesProblematica" DataValueField="CveProblematica">
		                                                        </asp:DropDownList><asp:RangeValidator ID="ravProblematicaPBAdd" runat="server" ControlToValidate="ddlProblematicaPBAdd"
		                                                            ErrorMessage="Debe seleccionar una problemática" ForeColor="" MaximumValue="1000000"
		                                                            MinimumValue="1" ToolTip="Debe seleccionar una problemática" Type="Integer">x</asp:RangeValidator><asp:CustomValidator
		                                                                ID="cuvProblematicaPBAdd" runat="server" ControlToValidate="ddlProblematicaPBAdd"
		                                                                ForeColor="">x</asp:CustomValidator><asp:ObjectDataSource
		                                                                    ID="odsProblematicaPBAdd" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                    SelectMethod="GetData" TypeName="dsAppTableAdapters.spProblematicaDLLTableAdapter"></asp:ObjectDataSource>
		                                                        </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ForeColor="" />
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ImageButton ID="ibtnGuardarPBAdd" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" OnClick="ibtnGuardarPBAdd_Click" />
		                                                        <asp:ImageButton ID="ibtnCancelarPBAdd" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" OnClick="ibtnCancelarPBAdd_Click" /></td>
		                                                </tr>
		                                            </table></asp:Panel>
		                                        </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2" style="height: 15px">
		                                        <asp:DataList ID="dtlProblematicaPB" runat="server" DataKeyField="CveProblematica" DataSourceID="odsProblematicasPB"
		                                            OnCancelCommand="dtlProblematicaPB_CancelCommand" OnDeleteCommand="dtlProblematicaPB_DeleteCommand" OnItemDataBound="dtlProblematicaPB_ItemDataBound" Width="100%">
		                                            <ItemTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
		                                                    <tr>
		                                                        <td style="width: 16%">&nbsp;
		                                                            </td>
		                                                        <td style="width: 68%" colspan="2">
		                                                            <asp:Label ID="lblProblematicaPBItm" runat="server" Text='<%# Eval("Problematica") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEliminarPBItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                    </tr>
		                                                </table>
		                                            </ItemTemplate>
		                                            <AlternatingItemTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaAlternatigTemplate" width="100%">
		                                                    <tr>
		                                                        <td style="width: 16%">&nbsp;
		                                                            </td>
		                                                        <td style="width: 68%" colspan="2">
		                                                            <asp:Label ID="lblProblematicaPBItm" runat="server" Text='<%# Eval("Problematica") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEliminarPBItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                    </tr>
		                                                </table>
		                                            </AlternatingItemTemplate>
		                                            <HeaderTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaHeaderTemplate" width="100%">
		                                                    <tr>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                        <th colspan="2" style="width: 68%">
		                                                            Problemática</th>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                    </tr>
		                                                </table>
		                                            </HeaderTemplate>
		                                        </asp:DataList><asp:ObjectDataSource ID="odsProblematicasPB" runat="server" OldValuesParameterFormatString="original_{0}"
		                                            SelectMethod="GetDataByCveProyecto" TypeName="dsAppTableAdapters.ProyectoProblematicaTableAdapter">
		                                            <SelectParameters>
		                                                <asp:ControlParameter ControlID="lblCveCONACYTEdt" Name="CveProyecto" PropertyName="Text"
		                                                    Type="String" />
		                                            </SelectParameters>
		                                        </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">&nbsp;
		                                        </td>
		                                </tr>
		                            </table>
		                        </asp:View>--%>
		                        <asp:View ID="viewParticipantesEdt" runat="server">
		                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
		                                <tr>
		                                    <td colspan="2">&nbsp;
		                                        
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <th class="thtablaComun" colspan="2" style="height: 19px">
		                                        Participantes</th>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">&nbsp;
		                                        </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                        &nbsp;<asp:ImageButton ID="ibtnAgregarPP" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif"
		                                                    OnClick="ibtnAgregarPP_Click" /><asp:Panel ID="pnlParticipantesPPAdd" runat="server" Width="100%" Visible="False">
		                                                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                        <tr>
		                                                            <td style="width: 30%">
		                                                                Participante</td>
		                                                            <td style="width: 70%">
		                                                                <asp:DropDownList ID="ddlParticipantePPAdd" runat="server" DataSourceID="odsParticipantesPPAdd"
		                                                                    DataTextField="NombreCompleto" DataValueField="CveParticipante" Width="400px">
		                                                                </asp:DropDownList>
		                                                                <asp:RangeValidator ID="ravParticipantePPAdd" runat="server" ControlToValidate="ddlParticipantePPAdd"
		                                                                    ErrorMessage="Debe seleccionar un participante" ForeColor="" MaximumValue="1000000"
		                                                                    MinimumValue="1" ToolTip="Debe seleccionar un participante" Type="Integer">x</asp:RangeValidator>
		                                                                <asp:CustomValidator ID="cuvParticipantesPPAdd" runat="server" ControlToValidate="ddlParticipantePPAdd"
		                                                                    ForeColor="">x</asp:CustomValidator>
		                                                                <asp:ObjectDataSource ID="odsParticipantesPPAdd" runat="server"
		                                                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="dsAppTableAdapters.spParticipanteDDLTableAdapter">
		                                                                </asp:ObjectDataSource>
		                                                            </td>
		                                                        </tr>
		                                                        <tr>
		                                                            <td style="width: 30%">
		                                                                Tipo de participante</td>
		                                                            <td style="width: 70%">
		                                                                <asp:DropDownList ID="ddlTipoParticipantePPAdd" runat="server" DataSourceID="odsTipoParticipanteDDL_PPAdd"
		                                                                    DataTextField="DesTipoParticipante" DataValueField="CveTipoParticipante" Width="400px">
		                                                                </asp:DropDownList>
		                                                                <asp:RangeValidator ID="ravTipoParticipantePPAdd" runat="server" ControlToValidate="ddlTipoParticipantePPAdd"
		                                                                    ErrorMessage="Debe seleccionar uno de los  tipos de participante" ForeColor=""
		                                                                    MaximumValue="1000000" MinimumValue="1" ToolTip="Debe seleccionar uno de los  tipos de participante" Type="Integer">x</asp:RangeValidator>
		                                                                <asp:ObjectDataSource ID="odsTipoParticipanteDDL_PPAdd" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                    SelectMethod="GetDataTipoParticipante" TypeName="dsAppTableAdapters.spTipoParticipante_DDLTableAdapter">
		                                                                </asp:ObjectDataSource>
		                                                            </td>
		                                                        </tr>
		                                                        <tr>
		                                                            <td style="width: 30%">
		                                                            </td>
		                                                            <td style="width: 70%">
		                                                                <asp:ValidationSummary ID="vsValidacionPPAdd" runat="server" DisplayMode="List" ForeColor="" />
		                                                            </td>
		                                                        </tr>
		                                                        <tr>
		                                                            <td style="width: 30%">
		                                                            </td>
		                                                            <td style="width: 70%">
		                                                                <asp:ImageButton ID="ibtnInsertarPPAdd" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" OnClick="ibtnInsertarPPAdd_Click" />
		                                                                <asp:ImageButton ID="ibtnCancelarPPAdd" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" OnClick="ibtnCancelarPPAdd_Click" /></td>
		                                                        </tr>
		                                                    </table>
		                                                        &nbsp;</asp:Panel>
		                                        <asp:DataList ID="dtlParticipantesPP" runat="server" DataKeyField="CveParticipante" DataSourceID="odsProyectoParticipante" Width="100%" OnCancelCommand="dtlParticipantesPP_CancelCommand" OnDeleteCommand="dtlParticipantesPP_DeleteCommand" OnEditCommand="dtlParticipantesPP_EditCommand" OnItemDataBound="dtlParticipantesPP_ItemDataBound" OnUpdateCommand="dtlParticipantesPP_UpdateCommand">
		                                            <ItemTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
		                                                    <tr>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEditarPP" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                        <td style="width: 34%">
		                                                            <asp:Label ID="lblParticipantePP" runat="server" Text='<%# Eval("Participante") %>'></asp:Label></td>
		                                                        <td style="width: 34%">
		                                                            <asp:Label ID="lblTipoParticipantePP" runat="server" Text='<%# Eval("TipoParticipante") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEliminarPP" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                    </tr>
		                                                </table>
		                                            </ItemTemplate>
		                                            <HeaderTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaHeaderTemplate" width="100%">
		                                                    <tr>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                        <th style="width: 34%">
		                                                            Participante
		                                                        </th>
		                                                        <th style="width: 34%">
		                                                            Tipo de participante
		                                                        </th>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                    </tr>
		                                                </table>
		                                            </HeaderTemplate>
		                                            <AlternatingItemTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaAlternatigTemplate" width="100%">
		                                                    <tr>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEditarPP" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                        <td style="width: 34%">
		                                                            <asp:Label ID="lblParticipantePP" runat="server" Text='<%# Eval("Participante") %>'></asp:Label></td>
		                                                        <td style="width: 34%">
		                                                            <asp:Label ID="lblTipoParticipantePP" runat="server" Text='<%# Eval("TipoParticipante") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEliminarPP" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                    </tr>
		                                                </table>
		                                            </AlternatingItemTemplate>
		                                            <EditItemTemplate>
		                                                <table width="100%" class="tablaEditarTemplate">
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Participante</td>
		                                                        <td style="width: 70%">
		                                                            <asp:Label ID="lblParticipantePPEdt" runat="server" Text='<%# Eval("Participante") %>'></asp:Label>
		                                                            <asp:CustomValidator ID="cuvParticipantePPEdt" runat="server" ForeColor="" ControlToValidate="ddlTipoParticipantePPEdt">x</asp:CustomValidator></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Tipo de participante</td>
		                                                        <td style="width: 70%">
		                                                            <asp:DropDownList ID="ddlTipoParticipantePPEdt" runat="server" DataSourceID="odsTipoParticipanteDDL_PPEdt"
		                                                                    DataTextField="DesTipoParticipante" DataValueField="CveTipoParticipante" SelectedValue='<%# Eval("CveTipoParticipante") %>'>
		                                                            </asp:DropDownList>
		                                                            <asp:RangeValidator ID="ravTipoParticipantePPEdt" runat="server" ControlToValidate="ddlTipoParticipantePPEdt"
		                                                                ErrorMessage="Debe seleccionar uno de los  tipos de participante" ForeColor=""
		                                                                MaximumValue="1000000" MinimumValue="1" ToolTip="Debe seleccionar uno de los  tipos de participante"
		                                                                Type="Integer">x</asp:RangeValidator>
		                                                            <asp:ObjectDataSource ID="odsTipoParticipanteDDL_PPEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                    SelectMethod="GetDataTipoParticipante" TypeName="dsAppTableAdapters.spTipoParticipante_DDLTableAdapter">
		                                                            </asp:ObjectDataSource>
		                                                        </td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                        </td>
		                                                        <td style="width: 70%">
		                                                            <asp:ValidationSummary ID="vsValidacionPPEdt" runat="server" DisplayMode="List" ForeColor="" />
		                                                        </td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                        </td>
		                                                        <td style="width: 70%">
		                                                            <asp:ImageButton ID="ibtnInsertarPPEdt" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" CommandName="Update" />
		                                                            <asp:ImageButton ID="ibtnCancelarPPEdt" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" OnClick="ibtnCancelarPPAdd_Click" CommandName="Cancel" /></td>
		                                                    </tr>
		                                                </table>
		                                            </EditItemTemplate>
		                                        </asp:DataList><asp:ObjectDataSource ID="odsProyectoParticipante" runat="server" OldValuesParameterFormatString="original_{0}"
		                                            SelectMethod="GetDataByCveProyecto" TypeName="dsAppTableAdapters.ProyectoParticipanteTableAdapter">
		                                            <SelectParameters>
		                                                <asp:ControlParameter ControlID="lblCveCONACYTEdt" DefaultValue="" Name="CveProyecto"
		                                                    PropertyName="Text" Type="String" />
		                                            </SelectParameters>
		                                        </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                    </td>
		                                </tr>
		                            </table>
		                        </asp:View>
		                        <asp:View ID="viewEspeciesEdt" runat="server">
		                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
		                                <tr>
		                                    <td colspan="2">&nbsp;
		                                        
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <th class="thtablaComun" colspan="2" style="height: 19px">
		                                        Especies</th>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                        <asp:ImageButton ID="ibtnNuevoProyectoEspeciesAdd" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif"
		                                                    OnClick="ibtnNuevoProyectoEspeciesAdd_Click" />&nbsp;
		                                        <asp:Panel ID="pnlEspeciesPEAdd" runat="server" Width="100%" Visible="False">
		                                            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Especie</td>
		                                                    <td style="width: 70%">
		                                                        <asp:DropDownList ID="ddlEspeciePEAdd" runat="server" DataSourceID="odsEspeciesPEAdd"
		                                                                    DataTextField="NomCientifico" DataValueField="CveEspecie">
		                                                        </asp:DropDownList><asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="ddlEspeciePEAdd"
		                                                            ErrorMessage="Debe seleccionar una especie" ForeColor="" MaximumValue="1000000"
		                                                            MinimumValue="1" ToolTip="Debe seleccionar una especie" Type="Integer">x</asp:RangeValidator><asp:CustomValidator
		                                                                ID="cuvEspeciePEAdd" runat="server" ControlToValidate="ddlEspeciePEAdd" ForeColor="">x</asp:CustomValidator><asp:ObjectDataSource
		                                                                    ID="odsEspeciesPEAdd" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                    SelectMethod="GetData" TypeName="dsAppTableAdapters.spEspecie_SelectDDLTableAdapter">
		                                                                </asp:ObjectDataSource>
		                                                        &nbsp;&nbsp;</td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Nombre común</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtNombreComunPEAdd" runat="server" MaxLength="100" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
		                                                            ID="revNombreComunPEAdd" runat="server" ControlToValidate="txtNombreComunPEAdd"
		                                                            ErrorMessage="Nombre del proyecto tiene caracteres no permitidos" ForeColor=""
		                                                            ToolTip="Nombre común tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ValidationSummary ID="vsProyectoEspeciesAdd" runat="server" DisplayMode="List" ForeColor="" />
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ImageButton ID="ibtnGuardarPEAdd" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" OnClick="ibtnGuardarPEAdd_Click" />
		                                                        <asp:ImageButton ID="ibtnCancelarPEAdd" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" OnClick="ibtnCancelarPEAdd_Click" /></td>
		                                                </tr>
		                                            </table>
		                                            &nbsp;</asp:Panel>
		                                        <asp:DataList ID="dtlEspeciesPE" runat="server" DataKeyField="CveEspecie" DataSourceID="odsEspeciePE"
		                                            OnCancelCommand="dtlEspeciesPE_CancelCommand" OnDeleteCommand="dtlEspeciesPE_DeleteCommand"
		                                            OnEditCommand="dtlEspeciesPE_EditCommand" OnItemDataBound="dtlEspeciesPE_ItemDataBound"
		                                            OnUpdateCommand="dtlEspeciesPE_UpdateCommand" Width="100%">
		                                            <ItemTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
		                                                    <tr>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEditarPE" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                        <td style="width: 34%">
		                                                            <asp:Label ID="NombreCientificoLabel" runat="server" Font-Italic="True" Text='<%# Eval("NombreCientifico") %>'></asp:Label></td>
		                                                        <td style="width: 34%">
		                                                            <asp:Label ID="NombreComunLabel" runat="server" Text='<%# Eval("NombreComun") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEliminarPE" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                    </tr>
		                                                </table>
		                                            </ItemTemplate>
		                                            <AlternatingItemTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaAlternatigTemplate" width="100%">
		                                                    <tr>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEditarPE" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                        <td style="width: 34%">
		                                                            <asp:Label ID="NombreCientificoLabel" runat="server" Text='<%# Eval("NombreCientifico") %>' Font-Italic="True"></asp:Label></td>
		                                                        <td style="width: 34%">
		                                                            <asp:Label ID="NombreComunLabel" runat="server" Text='<%# Eval("NombreComun") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEliminarPE" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                    </tr>
		                                                </table>
		                                            </AlternatingItemTemplate>
		                                            <EditItemTemplate>
		                                                <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                    <tr>
		                                                        <td style="width: 30%">&nbsp;
		                                                            </td>
		                                                        <td style="width: 70%">&nbsp;
		                                                            </td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Especie</td>
		                                                        <td style="width: 70%">
		                                                            <asp:Label ID="lblNombreCientificoPEEdt" runat="server" Text='<%# Eval("NombreCientifico") %>' Font-Italic="True"></asp:Label>
		                                                            <asp:CustomValidator ID="cuvEspeciePEEdt" runat="server" ControlToValidate="txtNombreComunPEEdt"
		                                                                ForeColor="">x</asp:CustomValidator></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Nombre común</td>
		                                                        <td style="width: 70%">
		                                                            <asp:TextBox ID="txtNombreComunPEEdt" runat="server" MaxLength="100" Text='<%# Eval("NombreComun") %>'
		                                                                Width="400px"></asp:TextBox>
		                                                            <asp:RegularExpressionValidator ID="revNombreComunPEEdt" runat="server" ControlToValidate="txtNombreComunPEEdt"
		                                                                ErrorMessage="Nombre del proyecto tiene caracteres no permitidos" ForeColor=""
		                                                                ToolTip="Nombre común tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                        </td>
		                                                        <td style="width: 70%">
		                                                            <asp:ValidationSummary ID="vsProyectoEspeciesPEEdt" runat="server" DisplayMode="List" ForeColor="" />
		                                                        </td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                        </td>
		                                                        <td style="width: 70%">
		                                                            <asp:ImageButton ID="ibtnGuardarPEEdt" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" CommandName="Update" />
		                                                            <asp:ImageButton ID="ibtnCancelarPEEdt" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" CommandName="Cancel" /></td>
		                                                    </tr>
		                                                </table>
		                                            </EditItemTemplate>
		                                            <HeaderTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaHeaderTemplate" width="100%">
		                                                    <tr>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                        <th style="width: 34%">
		                                                            Nombre científico&nbsp;</th>
		                                                        <th style="width: 34%">
		                                                            Nombre común</th>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                    </tr>
		                                                </table>
		                                            </HeaderTemplate>
		                                        </asp:DataList><asp:ObjectDataSource ID="odsEspeciePE" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCveProyecto"
		                                            TypeName="dsAppTableAdapters.ProyectoEspecieTableAdapter">
		                                            <SelectParameters>
		                                                <asp:ControlParameter ControlID="lblCveCONACYTEdt" Name="CveProyecto" PropertyName="Text"
		                                                    Type="String" />
		                                            </SelectParameters>
		                                        </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                    </td>
		                                </tr>
		                            </table>
		                        </asp:View>
		                        <asp:View ID="viewEstadosEdt" runat="server">
		                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
		                                <tr>
		                                    <th class="thtablaComun" colspan="2" style="height: 19px">
		                                        Estados que impacta el proyecto</th>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">&nbsp;
		                                        </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2" style="height: 15px"><asp:ImageButton ID="ibtnNuevoPSAdd" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" OnClick="ibtnNuevoPSAdd_Click" /></td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2" style="height: 15px">
		                                        <asp:Panel ID="pnlEstadoPSAdd" runat="server" Width="100%" Visible="False">
		                                            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Estado</td>
		                                                    <td style="width: 70%">
		                                                        <asp:DropDownList ID="ddlEstadoPSAdd" runat="server" DataSourceID="odsEstadosPSAdd"
		                                                                    DataTextField="DesEstado" DataValueField="CveEstadoInt">
		                                                        </asp:DropDownList><asp:RangeValidator ID="ravEstadoPSAdd" runat="server" ControlToValidate="ddlEstadoPSAdd"
		                                                            ErrorMessage="Debe seleccionar un estado" ForeColor="" MaximumValue="33"
		                                                            MinimumValue="1" ToolTip="Debe seleccionar un estado" Type="Integer">x</asp:RangeValidator><asp:CustomValidator
		                                                                ID="cuvEstadoPSAdd" runat="server" ControlToValidate="ddlEstadoPSAdd"
		                                                                ForeColor="">x</asp:CustomValidator><asp:ObjectDataSource
		                                                                    ID="odsEstadosPSAdd" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                    SelectMethod="GetData" TypeName="dsAppTableAdapters.spEstadoDDLTableAdapter"></asp:ObjectDataSource>
		                                                        </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ValidationSummary ID="vsEstadoPSAdd" runat="server" DisplayMode="List" ForeColor="" />
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ImageButton ID="ibtnGuardarPSAdd" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" OnClick="ibtnGuardarPSAdd_Click" />
		                                                        <asp:ImageButton ID="ibtnCancelarPSAdd" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" OnClick="ibtnCancelarPSAdd_Click" /></td>
		                                                </tr>
		                                            </table>
		                                            &nbsp;</asp:Panel>
		                                        &nbsp;</td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2" style="height: 15px">
		                                        <asp:DataList ID="dtlProyectoEstadosPS" runat="server" DataKeyField="CveEstado" DataSourceID="odsProyectoEstadoPS"
		                                            OnCancelCommand="dtlProyectoEstadosPS_CancelCommand" OnDeleteCommand="dtlProyectoEstadosPS_DeleteCommand" OnItemDataBound="dtlProyectoEstadosPS_ItemDataBound" Width="100%">
		                                            <ItemTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
		                                                    <tr>
		                                                        <td style="width: 16%">&nbsp;
		                                                            </td>
		                                                        <td style="width: 68%" colspan="2">
		                                                            <asp:Label ID="lblEstadoPSItm" runat="server" Text='<%# Eval("Estado") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEliminarPSItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                    </tr>
		                                                </table>
		                                            </ItemTemplate>
		                                            <AlternatingItemTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaAlternatigTemplate" width="100%">
		                                                    <tr>
		                                                        <td style="width: 16%">&nbsp;
		                                                            </td>
		                                                        <td style="width: 68%" colspan="2">
		                                                            <asp:Label ID="lblEstadoPSItm" runat="server" Text='<%# Eval("Estado") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEliminarPSItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                    </tr>
		                                                </table>
		                                            </AlternatingItemTemplate>
		                                            <HeaderTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaHeaderTemplate" width="100%">
		                                                    <tr>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                        <th colspan="2" style="width: 68%">
		                                                            Estado</th>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                    </tr>
		                                                </table>
		                                            </HeaderTemplate>
		                                        </asp:DataList><asp:ObjectDataSource ID="odsProyectoEstadoPS" runat="server" OldValuesParameterFormatString="original_{0}"
		                                            SelectMethod="GetDataByCveProyecto" TypeName="dsAppTableAdapters.ProyectoEstadoTableAdapter">
		                                            <SelectParameters>
		                                                <asp:ControlParameter ControlID="lblCveCONACYTEdt" Name="CveProyecto" PropertyName="Text"
		                                                    Type="String" />
		                                            </SelectParameters>
		                                        </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">&nbsp;
		                                        </td>
		                                </tr>
		                            </table>
		                        </asp:View>
		                        <asp:View ID="viewDetalleMontoEdt" runat="server">
		                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
		                                <tr>
		                                    <td colspan="2">&nbsp;
		                                        
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <th class="thtablaComun" colspan="2" style="height: 19px">
		                                        Detalle del monto</th>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2" style="height: 24px"><asp:ImageButton ID="ibtnNuevoPMAdd" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" OnClick="ibtnNuevoPMAdd_Click" /></td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                        <asp:Panel ID="pnlDetMontoAdd" runat="server" Width="100%" Visible="False">
		                                            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Concepto</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtConceptoPMAdd" runat="server" MaxLength="100" Width="400px"></asp:TextBox>
		                                                        <asp:RequiredFieldValidator ID="rfvConceptoPMAdd" runat="server" ControlToValidate="txtConceptoPMAdd"
		                                                            ErrorMessage="Concepto es un dato requerido" ForeColor="" ToolTip="Concepto es un dato requerido">x</asp:RequiredFieldValidator>
		                                                        <asp:RegularExpressionValidator ID="revConceptoPMAdd" runat="server" ControlToValidate="txtConceptoPMAdd"
		                                                            ErrorMessage="Concepto tiene caracteres no permitidos" ForeColor="" ToolTip="Concepto tiene caracteres no permitidos"
		                                                            ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator>
		                                                        <asp:CustomValidator ID="cuvDetalleMontoPMAdd" runat="server" ControlToValidate="txtConceptoPMAdd"
		                                                            ForeColor="">x</asp:CustomValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Cantidad</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtCantidadPMAdd" runat="server"></asp:TextBox>
		                                                        <asp:RequiredFieldValidator ID="rfvCantidadPMAdd" runat="server" ControlToValidate="txtCantidadPMAdd"
		                                                            ErrorMessage="Cantidad es un dato requerido" ForeColor="" ToolTip="Cantidad es un dato requerido">x</asp:RequiredFieldValidator>
		                                                        <asp:RegularExpressionValidator ID="revCantidadPMEdt" runat="server" ControlToValidate="txtCantidadPMAdd"
		                                                            ErrorMessage="Cantidad tiene caracteres no permitidos" ForeColor="" ToolTip="Cantidad tiene caracteres no permitidos"
		                                                            ValidationExpression="^[0-9]{0,}[.]{0,}[0-9]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ValidationSummary ID="vsDetalleMontoPMAdd" runat="server" DisplayMode="List" ForeColor="" />
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ImageButton ID="ibtnGuardarPMAdd" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" CommandName="Insert" OnClick="ibtnGuardarPMAdd_Click" />
		                                                        <asp:ImageButton ID="ibtnCancelarPMAdd" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" OnClick="ibtnCancelarPMAdd_Click" /></td>
		                                                </tr>
		                                            </table>
		                                            &nbsp;</asp:Panel><asp:DataList ID="dtlProyectoDetalleMonto" runat="server" DataKeyField="CveConcepto" DataSourceID="odsProyectoDetalleMonto"
		                                            OnCancelCommand="dtlProyectoDetalleMonto_CancelCommand" OnDeleteCommand="dtlProyectoDetalleMonto_DeleteCommand"
		                                            OnEditCommand="dtlProyectoDetalleMonto_EditCommand" OnItemDataBound="dtlProyectoDetalleMonto_ItemDataBound"
		                                            OnUpdateCommand="dtlProyectoDetalleMonto_UpdateCommand" Width="100%" OnSelectedIndexChanged="dtlProyectoDetalleMonto_SelectedIndexChanged">
		                                            <ItemTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
		                                                    <tr>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEditarPM" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                        <td style="width: 52%">
		                                                            <asp:Label ID="lblConceptoPMEdt" runat="server" Text='<%# Eval("Concepto") %>'></asp:Label><asp:HiddenField ID="hdnConsecutivoPMEdt" runat="server" Value='<%# Eval("CveConcepto") %>' />
		                                                        </td>
		                                                        <td style="width: 16%" align="right">
		                                                            <asp:Label ID="lblCantidadPMEdt" runat="server" Text='<%# Eval("Cantidad", "{0:C}") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEliminarPM" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                    </tr>
		                                                </table>
		                                            </ItemTemplate>
		                                            <AlternatingItemTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaAlternatigTemplate" width="100%">
		                                                    <tr>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEditarPM" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                        <td style="width: 52%">
		                                                            <asp:Label ID="lblConceptoPMEdt" runat="server" Text='<%# Eval("Concepto") %>'></asp:Label><asp:HiddenField ID="hdnConsecutivoPMEdt" runat="server" Value='<%# Eval("CveConcepto") %>' />
		                                                        </td>
		                                                        <td style="width: 16%" align="right">
		                                                            <asp:Label ID="lblCantidadPMEdt" runat="server" Text='<%# Eval("Cantidad", "{0:C}") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEliminarPM" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                    </tr>
		                                                </table>
		                                            </AlternatingItemTemplate>
		                                            <EditItemTemplate>
		                                                <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Concepto</td>
		                                                        <td style="width: 70%">
		                                                            <asp:TextBox ID="txtConceptoPMEdt" runat="server" MaxLength="100" Text='<%# Eval("Concepto") %>'
		                                                                Width="400px"></asp:TextBox>
		                                                            <asp:RequiredFieldValidator ID="rfvConceptoPMEdt" runat="server" ControlToValidate="txtConceptoPMEdt"
		                                                                ErrorMessage="Concepto es un dato requerido" ForeColor="" ToolTip="Concepto es un dato requerido">x</asp:RequiredFieldValidator>
		                                                            <asp:RegularExpressionValidator ID="revConceptoPMEdt" runat="server" ControlToValidate="txtConceptoPMEdt"
		                                                                ErrorMessage="Concepto tiene caracteres no permitidos" ForeColor="" ToolTip="Concepto tiene caracteres no permitidos"
		                                                                ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator>
		                                                            <asp:CustomValidator ID="cuvDetalleMontoPMEdt" runat="server" ControlToValidate="txtConceptoPMEdt"
		                                                                ForeColor="">x</asp:CustomValidator>
		                                                            <asp:HiddenField ID="hdnConsecutivoPMEdt" runat="server" Value='<%# Eval("CveConcepto") %>' />
		                                                        </td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Cantidad</td>
		                                                        <td style="width: 70%">
		                                                            <asp:TextBox ID="txtCantidadPMEdt" runat="server" Text='<%# Eval("Cantidad") %>'></asp:TextBox>
		                                                            <asp:RequiredFieldValidator ID="rfvCantidadPMEdt" runat="server" ControlToValidate="txtCantidadPMEdt"
		                                                                ErrorMessage="Cantidad es un dato requerido" ForeColor="" ToolTip="Cantidad es un dato requerido">x</asp:RequiredFieldValidator>
		                                                            <asp:RegularExpressionValidator ID="revCantidadPMEdt" runat="server" ControlToValidate="txtCantidadPMEdt"
		                                                                ErrorMessage="Cantidad tiene caracteres no permitidos" ForeColor="" ToolTip="Cantidad tiene caracteres no permitidos"
		                                                                ValidationExpression="^[0-9]{0,}[.]{0,}[0-9]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                        </td>
		                                                        <td style="width: 70%">
		                                                            <asp:ValidationSummary ID="vsDetalleMontoPMEdt" runat="server" DisplayMode="List" ForeColor="" />
		                                                        </td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                        </td>
		                                                        <td style="width: 70%">
		                                                            <asp:ImageButton ID="ibtnGuardarPMEdt" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" CommandName="Update" />
		                                                            <asp:ImageButton ID="ibtnCancelarPMAdd" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" CommandName="Cancel" /></td>
		                                                    </tr>
		                                                </table>
		                                            </EditItemTemplate>
		                                            <HeaderTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaHeaderTemplate" width="100%">
		                                                    <tr>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                        <th style="width: 52%">
		                                                            Concepto</th>
		                                                        <th style="width: 16%">
		                                                            Cantidad</th>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                    </tr>
		                                                </table>
		                                            </HeaderTemplate>
		                                        </asp:DataList><asp:ObjectDataSource ID="odsProyectoDetalleMonto" runat="server" OldValuesParameterFormatString="original_{0}"
		                                            SelectMethod="GetDataByCveProyecto" TypeName="dsAppTableAdapters.ProyectoDetalleMontoTableAdapter">
		                                            <SelectParameters>
		                                                <asp:ControlParameter ControlID="lblCveCONACYTEdt" Name="CveProyecto" PropertyName="Text"
		                                                    Type="String" />
		                                            </SelectParameters>
		                                        </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                    </td>
		                                </tr>
		                            </table>
		                        </asp:View>
		                        <asp:View ID="viewDifusionDivulgaEdt" runat="server">
		                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
		                                <tr>
		                                    <td colspan="2">&nbsp;
		                                        
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <th class="thtablaComun" colspan="2" style="height: 19px">
		                                        Transferencia de tecnología</th>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                        &nbsp;<asp:ImageButton ID="ibtnNuevoDDAdd" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" OnClick="ibtnNuevoDDAdd_Click" /></td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                        <asp:Panel ID="pnlDifDivAdd" runat="server" Width="100%" Visible="False">
		                                            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Medio de difusión o transferencia de tecnología</td>
		                                                    <td style="width: 70%">
		                                                        <asp:DropDownList ID="ddlTipoDifusionDDAdd" runat="server" DataSourceID="odsTipoDifusionDDAdd"
		                                                                    DataTextField="DesDifDiv" DataValueField="CveDifDiv">
		                                                        </asp:DropDownList><asp:RangeValidator ID="ravTipoDifusionDDAdd" runat="server" ControlToValidate="ddlTipoDifusionDDAdd"
		                                                            ErrorMessage="Debe seleccionar una especie" ForeColor="" MaximumValue="1000000"
		                                                            MinimumValue="1" ToolTip="Debe seleccionar una especie" Type="Integer">x</asp:RangeValidator><asp:CustomValidator
		                                                                ID="cuvDifDivDDAdd" runat="server" ControlToValidate="ddlTipoDifusionDDAdd" ForeColor="">x</asp:CustomValidator>&nbsp;
		                                                        <asp:ObjectDataSource
		                                                                    ID="odsTipoDifusionDDAdd" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                    SelectMethod="GetData" TypeName="dsAppTableAdapters.spDifusionDivulgacion_SelectDDLTableAdapter">
		                                                                </asp:ObjectDataSource>
		                                                        &nbsp; &nbsp;&nbsp;
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Fecha de inicio</td>
		                                                    <td style="width: 70%">
		                                                        <asp:UpdatePanel ID="updpFechaInicioDDAdd" runat="server">
		                                                            <ContentTemplate>
		                                                                <ews:DatePicker ID="dtpkFechaInicioDDAdd" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif"  />
		                                                                <asp:RequiredFieldValidator ID="rfvFechaInicioDDAdd" runat="server" ControlToValidate="dtpkFechaInicioDDAdd"
		                                                                    ErrorMessage="Fecha de inicio es requerida" ForeColor="" ToolTip="Fecha de inicio es requerida">x</asp:RequiredFieldValidator>
		                                                                <asp:RegularExpressionValidator ID="revFechaInicioDDAdd" runat="server" ControlToValidate="dtpkFechaInicioDDAdd"
		                                                                    ErrorMessage="Formato de fecha de inicio debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                    ToolTip="Formato de fecha de inicio debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
		                                                            </ContentTemplate>
		                                                        </asp:UpdatePanel>
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Fecha de terminación</td>
		                                                    <td style="width: 70%">
		                                                        <asp:UpdatePanel ID="updpFechaFinDDAdd" runat="server">
		                                                            <ContentTemplate>
		                                                                <ews:DatePicker ID="dtpkFechaFinDDAdd" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif"  />
		                                                                <asp:RequiredFieldValidator ID="rfvFechaFinDDAdd" runat="server" ControlToValidate="dtpkFechaFinDDAdd"
		                                                                    ErrorMessage="Fecha de terminación es requerida" ForeColor="" ToolTip="Fecha de terminación es requerida">x</asp:RequiredFieldValidator>
		                                                                <asp:RegularExpressionValidator ID="revFechaFinDDAdd" runat="server" ControlToValidate="dtpkFechaFinDDAdd"
		                                                                    ErrorMessage="Formato de fecha de terminación debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                    ToolTip="Formato de fecha de terminación debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
		                                                            </ContentTemplate>
		                                                        </asp:UpdatePanel>
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Descripción</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtDescripcionDDAdd" runat="server" MaxLength="255" Rows="5" TextMode="MultiLine"
		                                                            Width="400px"></asp:TextBox>
		                                                        <asp:RegularExpressionValidator ID="revDescActDDAdd" runat="server" ControlToValidate="txtDescripcionDDAdd"
		                                                            ErrorMessage="Descripción tiene caracteres no permitidos" ForeColor=""
		                                                            ToolTip="Descripción tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><br /><i>Tipo, Lugar y Objetivos</i></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Número exacto de beneficiarios</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtNumeroBeneficiariosAdd" runat="server" MaxLength="1000"
		                                                            Width="40px"></asp:TextBox>
		                                                        <asp:RegularExpressionValidator ID="revNumeroBeneficiariosAdd"
		                                                                runat="server" ControlToValidate="txtNumeroBeneficiariosAdd" ErrorMessage="Número exacto de beneficiarios tiene caracteres no permitidos"
		                                                                ForeColor="" ToolTip="Número exacto de beneficiarios tiene caracteres no permitidos" ValidationExpression="^[0-9]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                </tr>                                           
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Segmento poblacional</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtSegmentoPobDDAdd" runat="server" MaxLength="1000" Rows="5" TextMode="MultiLine"
		                                                            Width="400px"></asp:TextBox>
		                                                        <asp:RegularExpressionValidator ID="revSegmentoPobDDAdd"
		                                                                runat="server" ControlToValidate="txtSegmentoPobDDAdd" ErrorMessage="Segmento poblacional tiene caracteres no permitidos"
		                                                                ForeColor="" ToolTip="Segmento poblacional tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ValidationSummary ID="vsInsertarDDAdd" runat="server" DisplayMode="List" ForeColor="" />
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ImageButton ID="ibtnInsertarDD" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" OnClick="ibtnInsertarDD_Click" />
		                                                        <asp:ImageButton ID="ibtnCancelarDD" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" OnClick="ibtnCancelarDD_Click" /></td>
		                                                </tr>
		                                            </table>
		                                            &nbsp;</asp:Panel>
		                                        <asp:DataList ID="dtlActividadesDD" runat="server" DataKeyField="CveDifDiv" DataSourceID="odsActividadesDD"
		                                            OnCancelCommand="dtlActividadesDD_CancelCommand" OnDeleteCommand="dtlActividadesDD_DeleteCommand"
		                                            OnEditCommand="dtlActividadesDD_EditCommand" OnItemDataBound="dtlActividadesDD_ItemDataBound"
		                                            OnUpdateCommand="dtlActividadesDD_UpdateCommand" Width="100%" OnSelectedIndexChanged="dtlActividadesDD_SelectedIndexChanged">
		                                            <ItemTemplate><table border="0" cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
		                                                <tr>
		                                                    <td style="width: 16%">
		                                                        <asp:ImageButton ID="ibtnEditarDD" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                    <td style="width: 34%">
		                                                        <asp:LinkButton ID="lnkbMedioDDEdt" runat="server" CommandName="Select" Text='<%# Eval("DifusionDivulgacion") %>'></asp:LinkButton>
		                                                        <asp:HiddenField ID="hdnConsecutivoDDEdt" runat="server" Value='<%# Eval("Consec") %>' />
		                                                    </td>
		                                                    <td style="width: 34%">
		                                                        <asp:Label ID="lblDescripcionDDEdt" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label></td>
		                                                    <td style="width: 16%">
		                                                        <asp:ImageButton ID="ibtnEliminarDD" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                </tr>
		                                            </table>
		                                            </ItemTemplate>
		                                            <AlternatingItemTemplate><table border="0" cellpadding="3" cellspacing="0" class="tablaAlternatigTemplate" width="100%">
		                                                <tr>
		                                                    <td style="width: 16%">
		                                                        <asp:ImageButton ID="ibtnEditarDD" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                    <td style="width: 34%">
		                                                        <asp:LinkButton ID="lnkbMedioDDEdt" runat="server" CommandName="Select" Text='<%# Eval("DifusionDivulgacion") %>'></asp:LinkButton>
		                                                        <asp:HiddenField ID="hdnConsecutivoDDEdt" runat="server" Value='<%# Eval("Consec") %>' />
		                                                    </td>
		                                                    <td style="width: 34%">
		                                                        <asp:Label ID="lblDescripcionDDEdt" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label></td>
		                                                    <td style="width: 16%">
		                                                        <asp:ImageButton ID="ibtnEliminarDD" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                </tr>
		                                            </table>
		                                            </AlternatingItemTemplate>
		                                            <EditItemTemplate><table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Medio de difusión o transferencia de tecnología</td>
		                                                    <td style="width: 70%">
		                                                        <asp:DropDownList ID="ddlTipoDifusionDDEdt" runat="server" DataSourceID="odsTipoDifusionDDEdt"
		                                                                    DataTextField="DesDifDiv" DataValueField="CveDifDiv" SelectedValue='<%# Eval("CveDifDiv") %>'>
		                                                        </asp:DropDownList><asp:RangeValidator ID="ravTipoDifusionDDEdt" runat="server" ControlToValidate="ddlTipoDifusionDDEdt"
		                                                            ErrorMessage="Debe seleccionar una especie" ForeColor="" MaximumValue="1000000"
		                                                            MinimumValue="1" ToolTip="Debe seleccionar una especie" Type="Integer">x</asp:RangeValidator><asp:CustomValidator
		                                                                ID="cuvDifDivDDEdt" runat="server" ControlToValidate="ddlTipoDifusionDDEdt" ForeColor="">x</asp:CustomValidator>
		                                                        <asp:HiddenField ID="hdnConsecutivoDDEdt" runat="server" Value='<%# Eval("Consec") %>' />
		                                                        <asp:ObjectDataSource
		                                                                    ID="odsTipoDifusionDDEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                    SelectMethod="GetData" TypeName="dsAppTableAdapters.spDifusionDivulgacion_SelectDDLTableAdapter">
		                                                        </asp:ObjectDataSource>
		                                                        &nbsp; &nbsp;&nbsp;
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Fecha de inicio</td>
		                                                    <td style="width: 70%">
		                                                        <asp:UpdatePanel ID="updpFechaInicioDDEdt" runat="server">
		                                                            <ContentTemplate>
		                                                                <ews:DatePicker ID="dtpkFechaInicioDDEdt" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" DateValue='<%# Eval("FechaInicio") %>'  />
		                                                                <asp:RequiredFieldValidator ID="rfvFechaInicioDDEdt" runat="server" ControlToValidate="dtpkFechaInicioDDEdt"
		                                                                    ErrorMessage="Fecha de inicio es requerida" ForeColor="" ToolTip="Fecha de inicio es requerida">x</asp:RequiredFieldValidator>
		                                                                <asp:RegularExpressionValidator ID="revFechaInicioDDEdt" runat="server" ControlToValidate="dtpkFechaInicioDDEdt"
		                                                                    ErrorMessage="Formato de fecha de inicio debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                    ToolTip="Formato de fecha de inicio debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
		                                                            </ContentTemplate>
		                                                        </asp:UpdatePanel>
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Fecha de terminación</td>
		                                                    <td style="width: 70%">
		                                                <asp:UpdatePanel ID="updpFechaFinDDEdt" runat="server">
		                                                            <ContentTemplate>
		                                                                <ews:DatePicker ID="dtpkFechaFinDDEdt" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" DateValue='<%# Eval("FechaFinal") %>'  />
		                                                                <asp:RequiredFieldValidator ID="rfvFechaFinDDEdt" runat="server" ControlToValidate="dtpkFechaFinDDEdt"
		                                                                    ErrorMessage="Fecha de terminación es requerida" ForeColor="" ToolTip="Fecha de terminación es requerida">x</asp:RequiredFieldValidator>
		                                                                <asp:RegularExpressionValidator ID="revFechaFinDDEdt" runat="server" ControlToValidate="dtpkFechaFinDDEdt"
		                                                                    ErrorMessage="Formato de fecha de terminación debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                    ToolTip="Formato de fecha de terminación debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
		                                                            </ContentTemplate>
		                                                        </asp:UpdatePanel>
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Descripción</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtDescripcionDDEdt" runat="server" MaxLength="255" Rows="5" TextMode="MultiLine"
		                                                            Width="400px" Text='<%# Eval("Descripcion") %>'></asp:TextBox>
		                                                        <asp:RegularExpressionValidator ID="revDescripcionDDEdt" runat="server" ControlToValidate="txtDescripcionDDEdt"
		                                                            ErrorMessage="Descripción tiene caracteres no permitidos" ForeColor=""
		                                                            ToolTip="Descripción tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><br /><i>Tipo, Lugar y Objetivos</i></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Número exacto de beneficiarios</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtNumeroBeneficiariosEdt" runat="server" MaxLength="1000"
		                                                            Width="40px" Text='<%# Eval("NumeroBeneficiarios") %>'></asp:TextBox>
		                                                        <asp:RegularExpressionValidator ID="revNumeroBeneficiariosEdt"
		                                                                runat="server" ControlToValidate="txtNumeroBeneficiariosEdt" ErrorMessage="Número exacto de beneficiarios tiene caracteres no permitidos"
		                                                                ForeColor="" ToolTip="Número exacto de beneficiarios tiene caracteres no permitidos" ValidationExpression="^[0-9]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                </tr>                                             
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Segmento poblacional</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtSegmentoPobDDEdt" runat="server" MaxLength="1000" Rows="5" TextMode="MultiLine"
		                                                            Width="400px" Text='<%# Eval("SegmentoPobla") %>'></asp:TextBox>
		                                                        <asp:RegularExpressionValidator ID="revSegmentoPobDDEdt" runat="server" ControlToValidate="txtSegmentoPobDDEdt"
		                                                            ErrorMessage="Nombre del proyecto tiene caracteres no permitidos" ForeColor=""
		                                                            ToolTip="Nombre común tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ValidationSummary ID="vsDifDivDDEdt" runat="server" DisplayMode="List" ForeColor="" />
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ImageButton ID="ibtnGuardarDDEdt" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" OnClick="ibtnGuardarPEAdd_Click" CommandName="Update" />
		                                                        <asp:ImageButton ID="ibtnCancelarDDEdt" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" OnClick="ibtnCancelarPEAdd_Click" CommandName="Cancel" /></td>
		                                                </tr>
		                                            </table>
		                                            </EditItemTemplate>
		                                            <HeaderTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaHeaderTemplate" width="100%">
		                                                    <tr>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                        <th style="width: 34%">
		                                                            Medio&nbsp;</th>
		                                                        <th style="width: 34%">
		                                                            Actividad</th>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                    </tr>
		                                                </table>
		                                            </HeaderTemplate>
		                                            <SelectedItemTemplate>
		                                                <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Medio de difusión o transferencia de tecnología</td>
		                                                        <td style="width: 70%">
		                                                            <asp:Label ID="lblMedioDDSIT" runat="server" Text='<%# Eval("DifusionDivulgacion") %>'></asp:Label></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Fecha de inicio</td>
		                                                        <td style="width: 70%">
		                                                            <asp:Label ID="lblFechaInicioDDSIT" runat="server" Text='<%# Eval("FechaInicio", "{0:d}") %>'></asp:Label></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Fecha de terminación</td>
		                                                        <td style="width: 70%">
		                                                            <asp:Label ID="lblFechaFinalDDSIT" runat="server" Text='<%# Eval("FechaFinal", "{0:d}") %>'></asp:Label></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Descripción</td>
		                                                        <td style="width: 70%">
		                                                            <asp:Label ID="lblDescripcionDDSIT" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Número exacto de beneficiarios</td>
		                                                        <td style="width: 70%">
		                                                            <asp:Label ID="lblNumberoBeneficiariosR" runat="server" Text='<%# Eval("NumeroBeneficiarios") %>'></asp:Label></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Segmento poblacional</td>
		                                                        <td style="width: 70%">
		                                                            <asp:Label ID="lblSegmentoDDSIT" runat="server" Text='<%# Eval("SegmentoPobla") %>'></asp:Label></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                        </td>
		                                                        <td style="width: 70%">
		                                                        </td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                        </td>
		                                                        <td style="width: 70%">
		                                                            <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/images/aplicacion/btnRegresar.gif" CommandName="Cancel" />
		                                                        </td>
		                                                    </tr>
		                                                </table>
		                                            </SelectedItemTemplate>
		                                        </asp:DataList><asp:ObjectDataSource ID="odsActividadesDD" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCveProyecto"
		                                            TypeName="dsAppTableAdapters.ProyectoDifDivTableAdapter">
		                                            <SelectParameters>
		                                                <asp:ControlParameter ControlID="lblCveCONACYTEdt" Name="CveProyecto" PropertyName="Text"
		                                                    Type="String" />
		                                            </SelectParameters>
		                                        </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">&nbsp;
		                                        </td>
		                                </tr>
		                            </table>
		                        </asp:View>
		                        <asp:View ID="viewVisitasTecnicasEdt" runat="server">
		                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
		                                <tr>
		                                    <td colspan="2">&nbsp;
		                                        
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <th class="thtablaComun" colspan="2" style="height: 15px">
		                                        Visitas técnicas</th>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                        <asp:ImageButton ID="ibtnNuevoPVAdd" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" OnClick="ibtnNuevoPVAdd_Click" /></td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                        <asp:Panel ID="pnlProyectoVisitasPVAdd" runat="server" Width="100%" Visible="False">
		                                            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Instalaciones</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtInstalacionesPVAdd" runat="server" MaxLength="500" Rows="5" TextMode="MultiLine"
		                                                            Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvInstalacionesPVAdd"
		                                                                runat="server" ControlToValidate="txtInstalacionesPVAdd" ErrorMessage="Instalaciones es un dato requerido"
		                                                                ForeColor="" ToolTip="Instalaciones es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                    ID="revInstalacionesPVAdd" runat="server" ControlToValidate="txtInstalacionesPVAdd"
		                                                                    ErrorMessage="Instalaciones tiene caracteres no permitidos" ForeColor="" ToolTip="Instalaciones tiene caracteres no permitidos"
		                                                                    ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><asp:CustomValidator
		                                                                        ID="cuvInstalacionesPVAdd" runat="server" ControlToValidate="txtInstalacionesPVAdd"
		                                                                        ForeColor="">x</asp:CustomValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td colspan="2">
		                                                        <asp:UpdatePanel ID="updpEdoMpioPVAdd" runat="server">
		                                                            <ContentTemplate>
		                                                                <table border="0" cellpadding="3" cellspacing="0" width="100%">
		                                                                    <tr>
		                                                                        <td style="width: 30%">
		                                                                            Estado</td>
		                                                                        <td style="width: 70%">
		                                                                            <asp:DropDownList ID="ddlEstadoPVAdd" runat="server" DataSourceID="odsEstadoPVAdd"
		                                                                    DataTextField="DesEstado" DataValueField="CveEstadoInt" AutoPostBack="True">
		                                                                            </asp:DropDownList><asp:RangeValidator ID="ravEstadoPVAdd" runat="server" ControlToValidate="ddlEstadoPVAdd"
		                                                                                ErrorMessage="Indique el estado" ForeColor="" MaximumValue="33" MinimumValue="1"
		                                                                                ToolTip="Indique el estado" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
		                                                                    ID="odsEstadoPVAdd" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                    SelectMethod="GetData" TypeName="dsAppTableAdapters.spEstadoDDLTableAdapter"></asp:ObjectDataSource>
		                                                                        </td>
		                                                                    </tr>
		                                                                    <tr>
		                                                                        <td style="width: 30%">
		                                                                            Municipio</td>
		                                                                        <td style="width: 70%">
		                                                                            <asp:DropDownList ID="ddlMpioPVAdd" runat="server" DataSourceID="odsMunicipioPVAdd"
		                                                                    DataTextField="DesMpio" DataValueField="CveMpio">
		                                                                            </asp:DropDownList><asp:RangeValidator ID="ravMunicipioPVAdd" runat="server" ControlToValidate="ddlMpioPVAdd"
		                                                                                ErrorMessage="Indique el municipio" ForeColor="" MaximumValue="33999" MinimumValue="1"
		                                                                                ToolTip="Indique el municipio" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
		                                                                                    ID="odsMunicipioPVAdd" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                                    SelectMethod="GetDataByCveEstado" TypeName="dsAppTableAdapters.spMunicipioDDLPorEstadoTableAdapter">
		                                                                                    <SelectParameters>
		                                                                                        <asp:ControlParameter ControlID="ddlEstadoPVAdd" DefaultValue="00" Name="CveEstado"
		                                                                                            PropertyName="SelectedValue" Type="Int32" />
		                                                                                    </SelectParameters>
		                                                                                </asp:ObjectDataSource>
		                                                                        </td>
		                                                                    </tr>
		                                                                </table>
		                                                            </ContentTemplate>
		                                                        </asp:UpdatePanel>
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Fecha de la visita</td>
		                                                    <td style="width: 70%">
		                                                        <asp:UpdatePanel ID="updpFechaVisPVAdd" runat="server">
		                                                            <ContentTemplate>
		                                                                <ews:DatePicker ID="dtpkFechaVisPVAdd" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif"  />
		                                                                <asp:RequiredFieldValidator ID="rfvFechaVisPVAdd" runat="server" ControlToValidate="dtpkFechaVisPVAdd"
		                                                                    ErrorMessage="Fecha de la visita es requerida" ForeColor="" ToolTip="Fecha de la visita es requerida">x</asp:RequiredFieldValidator>
		                                                                <asp:RegularExpressionValidator ID="revFechaVisPVAdd" runat="server" ControlToValidate="dtpkFechaVisPVAdd"
		                                                                    ErrorMessage="Formato de fecha de la visita debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                    ToolTip="Formato de fecha de la visita debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
		                                                            </ContentTemplate>
		                                                        </asp:UpdatePanel>
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Asistentes</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtAsistentesPVAdd" runat="server" MaxLength="500" Rows="5" TextMode="MultiLine"
		                                                            Width="400px"></asp:TextBox><asp:RegularExpressionValidator ID="revAsistentesPVAdd"
		                                                                runat="server" ControlToValidate="txtAsistentesPVAdd" ErrorMessage="Asistentes tiene caracteres no permitidos"
		                                                                ForeColor="" ToolTip="Asistentes tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Avance general</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtAvanceGralPVAdd" runat="server"></asp:TextBox><asp:RequiredFieldValidator
		                                                            ID="rfvAvanceGralPVAdd" runat="server" ControlToValidate="txtAvanceGralPVAdd"
		                                                            ErrorMessage="Avance general es requerido" ForeColor="">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAvanceGralPVAdd"
		                                                                ErrorMessage="Avance general tiene caracteres no permitidos" ForeColor="" ToolTip="Avance general tiene caracteres no permitidos"
		                                                                ValidationExpression="^[0-9]{0,}[.]{0,}[0-9]{0,}$">x</asp:RegularExpressionValidator><asp:RangeValidator
		                                                                    ID="ravAvanceGralPVAdd" runat="server" ErrorMessage="Avance general debe ser un número entre 0 y 100"
		                                                                    ForeColor="" MaximumValue="100" MinimumValue="0" Type="Double" ControlToValidate="txtAvanceGralPVAdd">x</asp:RangeValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        ¿Se entregaron productos?</td>
		                                                    <td style="width: 70%">
		                                                        <asp:CheckBox ID="chkbEntregaProdsPVAdd" runat="server" /></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Observaciones</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtObservacionesPVAdd" runat="server" MaxLength="1000" Rows="5" TextMode="MultiLine"
		                                                            Width="400px"></asp:TextBox><asp:RegularExpressionValidator ID="revObservacionesPVAdd"
		                                                                runat="server" ControlToValidate="txtObservacionesPVAdd" ErrorMessage="Observaciones tiene caracteres no permitidos"
		                                                                ForeColor="" ToolTip="Observaciones tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ValidationSummary ID="vsProyectoVisitasPVAdd" runat="server" DisplayMode="List" ForeColor="" />
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ImageButton ID="ibtnGuardarPVAdd" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" OnClick="ibtnGuardarPVAdd_Click" />
		                                                        <asp:ImageButton ID="ibtnCancelarPVAdd" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" OnClick="ibtnCancelarPVAdd_Click" /></td>
		                                                </tr>
		                                            </table>
		                                            &nbsp;</asp:Panel>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                        <asp:DataList ID="dtlProyectoVisitasPV" runat="server" DataKeyField="NumVisita" DataSourceID="odsProyectoVisitasPV"
		                                            OnCancelCommand="dtlProyectoVisitasPV_CancelCommand" OnDeleteCommand="dtlProyectoVisitasPV_DeleteCommand"
		                                            OnEditCommand="dtlProyectoVisitasPV_EditCommand"
		                                            OnUpdateCommand="dtlProyectoVisitasPV_UpdateCommand" Width="100%" OnSelectedIndexChanged="dtlProyectoVisitasPV_SelectedIndexChanged" OnItemDataBound="dtlProyectoVisitasPV_ItemDataBound">
		                                            <ItemTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
		                                                    <tr>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEditarPVItm" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                        <td style="width: 52%">
		                                                            &nbsp;<asp:LinkButton ID="lnkbInstalacionesPVItm" runat="server" CommandName="Select"
		                                                                Text='<%# Eval("Instalaciones") %>'></asp:LinkButton>
		                                                        </td>
		                                                        <td style="width: 16%" align="right">
		                                                            <asp:Label ID="lblFechaVisitaPVItm" runat="server" Text='<%# Eval("FechaVisita", "{0:d}") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEliminarPVItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                    </tr>
		                                                </table>
		                                            </ItemTemplate>
		                                            <AlternatingItemTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaAlternatigTemplate" width="100%">
		                                                    <tr>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEditarPVItm" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                        <td style="width: 52%">
		                                                            <asp:LinkButton ID="lnkbInstalacionesPVItm" runat="server" CommandName="Select" Text='<%# Eval("Instalaciones") %>'></asp:LinkButton>&nbsp;
		                                                        </td>
		                                                        <td style="width: 16%" align="right">
		                                                            <asp:Label ID="lblFechaVisitaPVItm" runat="server" Text='<%# Eval("FechaVisita", "{0:d}") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEliminarPVItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                    </tr>
		                                                </table>
		                                            </AlternatingItemTemplate>
		                                            <EditItemTemplate>
		                    <table cellpadding="0" cellspacing="0" class="seccionPestanas" style="width: 100%">
		                        <tr>
		                            <td style="width: 144px; height: 24px">
		                                <asp:ImageButton ID="ibtnProyectoVisitasPVEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_vt_sel.gif"
		                                    PostBackUrl="~/RegistroProyectos.aspx" OnClick="ibtnProyectoVisitasPVEdt_Click" /></td>
		                            <td style="width: 144px; height: 24px">
		                                <asp:ImageButton ID="ibtnProyVisitasAcuerdosPVEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_va_rep.gif"
		                                    PostBackUrl="~/RegistroProyectos.aspx" OnClick="ibtnProyVisitasAcuerdosPVEdt_Click" /></td>
		                            <td style="width: 144px; height: 24px">&nbsp;
		                                </td>
		                            <td style="width: 144px; height: 24px">&nbsp;
		                                </td>
		                            <td align="left" style="width: 224px; height: 24px">&nbsp;
		                                </td>
		                        </tr>
		                    </table>                                             
		                                                <asp:MultiView ID="mviewVisitasAcuerdos" runat="server" ActiveViewIndex="0" EnableTheming="True">
		                                                    <asp:View ID="viewVisitas" runat="server">
		                                                        <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                            <tr>
		                                                                <td style="width: 30%">
		                                                                    Instalaciones</td>
		                                                                <td style="width: 70%">
		                                                                    <asp:TextBox ID="txtInstalacionesPVEdt" runat="server" MaxLength="500" Rows="5" TextMode="MultiLine"
		                                                                        Width="400px" Text='<%# Eval("Instalaciones") %>' EnableTheming="True"></asp:TextBox><asp:RequiredFieldValidator ID="rfvInstalacionesPVEdt"
		                                                                            runat="server" ControlToValidate="txtInstalacionesPVEdt" ErrorMessage="Instalaciones es un dato requerido"
		                                                                            ForeColor="" ToolTip="Instalaciones es un dato requerido" EnableTheming="True">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                                ID="revInstalacionesPVEdt" runat="server" ControlToValidate="txtInstalacionesPVEdt"
		                                                                                ErrorMessage="Instalaciones tiene caracteres no permitidos" ForeColor="" ToolTip="Instalaciones tiene caracteres no permitidos"
		                                                                                ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$" EnableTheming="True">x</asp:RegularExpressionValidator><asp:CustomValidator
		                                                                                    ID="cuvInstalacionesPVEdt" runat="server" ControlToValidate="txtInstalacionesPVEdt"
		                                                                                    ForeColor="" EnableTheming="True">x</asp:CustomValidator>
		                                                                    <asp:HiddenField ID="hdnfNumVisitaPVEdt" runat="server" Value='<%# Eval("NumVisita") %>' />
		                                                                </td>
		                                                            </tr>
		                                                            <tr>
		                                                                <td colspan="2">
		                                                                    <asp:UpdatePanel ID="updpEdoMpioPVEdt" runat="server" OnPreRender="updpEdoMpioPVEdt_PreRender">
		                                                                        <ContentTemplate>
		                                                                            <table border="0" cellpadding="3" cellspacing="0" width="100%">
		                                                                                <tr>
		                                                                                    <td style="width: 30%">
		                                                                                        Estado</td>
		                                                                                    <td style="width: 70%">
		                                                                                        <asp:DropDownList ID="ddlEstadoPVEdt" runat="server" SelectedValue='<%# Eval("CveEstado").ToString().Trim() %>' DataSourceID="odsEstadoPVEdt"
		                                                                            DataTextField="DesEstado" DataValueField="CveEstadoInt" AutoPostBack="True"  OnSelectedIndexChanged="ddlEstadoPVEdt_SelectedIndexChanged">
		                                                                                        </asp:DropDownList><asp:RangeValidator ID="ravEstadoPVEdt" runat="server" ControlToValidate="ddlEstadoPVEdt"
		                                                                                            ErrorMessage="Indique el estado" ForeColor="" MaximumValue="33" MinimumValue="1"
		                                                                                            Type="Integer">x</asp:RangeValidator>
		                                                                                        <asp:HiddenField ID="hdnEstadoPVEdt" runat="server" Value='<%# Eval("CveEstado").ToString().Trim() %>' />
		                                                                                        <asp:ObjectDataSource
		                                                                            ID="odsEstadoPVEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                            SelectMethod="GetData" TypeName="dsAppTableAdapters.spEstadoDDLTableAdapter"></asp:ObjectDataSource>
		                                                                                    </td>
		                                                                                </tr>
		                                                                                <tr>
		                                                                                    <td style="width: 30%">
		                                                                                        Municipio</td>
		                                                                                    <td style="width: 70%">
		                                                                                        <asp:DropDownList ID="ddlMpioPVEdt" runat="server" DataSourceID="odsMunicipioPVEdt"
		                                                                            DataTextField="DesMpio" DataValueField="CveMpio"  >
		                                                                                        </asp:DropDownList><asp:RangeValidator ID="ravMunicipioPVEdt" runat="server" ControlToValidate="ddlMpioPVEdt"
		                                                                                            ErrorMessage="Indique el municipio" ForeColor="" MaximumValue="33999" MinimumValue="1"
		                                                                                            ToolTip="Indique el municipio" Type="Integer">x</asp:RangeValidator>
		                                                                                        <asp:HiddenField ID="hdnMpioPVEdt" runat="server" Value='<%# Convert.ToInt32(Eval("CveMunicipio")) %>' />
		                                                                                        <asp:ObjectDataSource
		                                                                                            ID="odsMunicipioPVEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                                            SelectMethod="GetDataByCveEstado" TypeName="dsAppTableAdapters.spMunicipioDDLPorEstadoTableAdapter">
		                                                                                            <SelectParameters>
		                                                                                                <asp:ControlParameter ControlID="ddlEstadoPVEdt" Name="CveEstado" PropertyName="SelectedValue"
		                                                                                                    Type="Int32" />
		                                                                                            </SelectParameters>
		                                                                                        </asp:ObjectDataSource>
		                                                                                    </td>
		                                                                                </tr>
		                                                                            </table>
		                                                                        </ContentTemplate>
		                                                                    </asp:UpdatePanel>
		                                                                </td>
		                                                            </tr>
		                                                            <tr>
		                                                                <td style="width: 30%">
		                                                                    Fecha de la visita</td>
		                                                                <td style="width: 70%">
		                                                                    <asp:UpdatePanel ID="updpFechaVisitaPVEdt" runat="server">
		                                                                        <ContentTemplate>
		                                                                            <ews:DatePicker ID="dtpkFechaVisitaPVEdt" runat="server" CalendarPosition="DisplayRight"
		                                                                ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" DateValue='<%# Eval("FechaVisita") %>'  />
		                                                                            <asp:RequiredFieldValidator ID="rfvFechaVisitaPVEdt" runat="server" ControlToValidate="dtpkFechaVisitaPVEdt"
		                                                                                ErrorMessage="Fecha de inicio es requerida" ForeColor="" ToolTip="Fecha programada de pago es requerida">x</asp:RequiredFieldValidator>
		                                                                            <asp:RegularExpressionValidator ID="revFechaVisPVEdt" runat="server" ControlToValidate="dtpkFechaVisitaPVEdt"
		                                                                                ErrorMessage="Formato de fecha de la visita debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                                ToolTip="Formato de fecha de la visita debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
		                                                                        </ContentTemplate>
		                                                                    </asp:UpdatePanel>
		                                                                </td>
		                                                            </tr>
		                                                            <tr>
		                                                                <td style="width: 30%">
		                                                                    Asistentes</td>
		                                                                <td style="width: 70%">
		                                                                    <asp:TextBox ID="txtAsistentesPVEdt" runat="server" MaxLength="500" Rows="5" Text='<%# Eval("Asistentes") %>'
		                                                                        TextMode="MultiLine" Width="400px" EnableTheming="True"></asp:TextBox><asp:RegularExpressionValidator
		                                                                            ID="revAsistentesPVEdt" runat="server" ControlToValidate="txtAsistentesPVEdt"
		                                                                            ErrorMessage="Asistentes tiene caracteres no permitidos" ForeColor="" ToolTip="Asistentes tiene caracteres no permitidos"
		                                                                            ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$" EnableTheming="True">x</asp:RegularExpressionValidator></td>
		                                                            </tr>
		                                                            <tr>
		                                                                <td style="width: 30%">
		                                                                    Avance general</td>
		                                                                <td style="width: 70%">
		                                                                    <asp:TextBox ID="txtAvanceGralPVEdt" runat="server" Text='<%# Eval("AvanceGral", "{0:N}") %>' EnableTheming="True"></asp:TextBox><asp:RequiredFieldValidator
		                                                                        ID="rfvAvanceGralPVEdt" runat="server" ControlToValidate="txtAvanceGralPVEdt"
		                                                                        ErrorMessage="Avance general es requerido" ForeColor="" EnableTheming="True">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                            ID="revAvanceGralPVEdt" runat="server" ControlToValidate="txtAvanceGralPVEdt"
		                                                                            ErrorMessage="Avance general tiene caracteres no permitidos" ForeColor="" ToolTip="Avance general tiene caracteres no permitidos"
		                                                                            ValidationExpression="^[0-9]{0,}[.]{0,}[0-9]{0,}$" EnableTheming="True">x</asp:RegularExpressionValidator><asp:RangeValidator
		                                                                                ID="ravAvanceGralPVEdt" runat="server" ControlToValidate="txtAvanceGralPVEdt"
		                                                                                ErrorMessage="Avance general debe ser un número entre 0 y 100" ForeColor="" MaximumValue="100"
		                                                                                MinimumValue="0" ToolTip="Avance general debe ser un número entre 0 y 100" Type="Double" EnableTheming="True">x</asp:RangeValidator></td>
		                                                            </tr>
		                                                            <tr>
		                                                                <td style="width: 30%">
		                                                                    ¿Se entregaron productos?</td>
		                                                                <td style="width: 70%">
		                                                                    <asp:CheckBox ID="chkbEntregaProdsPVEdt" runat="server" Checked='<%# Eval("EntregaProductos") %>' EnableTheming="True" /></td>
		                                                            </tr>
		                                                            <tr>
		                                                                <td style="width: 30%">
		                                                                    Observaciones</td>
		                                                                <td style="width: 70%">
		                                                                    <asp:TextBox ID="txtObservacionesPVEdt" runat="server" MaxLength="1000" Rows="5"
		                                                                        Text='<%# Eval("Observaciones") %>' TextMode="MultiLine" Width="400px" EnableTheming="True"></asp:TextBox><asp:RegularExpressionValidator
		                                                                            ID="revObservacionesPVEdt" runat="server" ControlToValidate="txtObservacionesPVEdt"
		                                                                            ErrorMessage="Observaciones tiene caracteres no permitidos" ForeColor="" ToolTip="Observaciones tiene caracteres no permitidos"
		                                                                            ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$" EnableTheming="True">x</asp:RegularExpressionValidator></td>
		                                                            </tr>
		                                                            <tr>
		                                                                <td style="width: 30%">
		                                                                </td>
		                                                                <td style="width: 70%">
		                                                                    <asp:ValidationSummary ID="vsProyectoVisitaPVEdt" runat="server" DisplayMode="List" ForeColor="" EnableTheming="True" />
		                                                                </td>
		                                                            </tr>
		                                                            <tr>
		                                                                <td style="width: 30%">
		                                                                </td>
		                                                                <td style="width: 70%">
		                                                                    <asp:ImageButton ID="ibtnGuardarPVEdt" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" CommandName="Update" />
		                                                                    <asp:ImageButton ID="ibtnCancelarPVEdt" runat="server" CausesValidation="False"
		                                                                            ImageUrl="~/images/aplicacion/btnCancelar.gif" CommandName="Cancel" /></td>
		                                                            </tr>
		                                                        </table>
		                                                    </asp:View>
		                                                    <asp:View ID="viewAcuerdos" runat="server"><table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
		                                                        <tr>
		                                                            <td colspan="2">&nbsp;
		                                                                
		                                                            </td>
		                                                        </tr>
		                                                        <tr>
		                                                            <th class="thtablaComun" colspan="2" style="height: 19px">
		                                                                Acuerdos</th>
		                                                        </tr>
		                                                        <tr>
		                                                            <td colspan="2">
		                                                                <asp:ImageButton ID="ibtnNuevoPVAAdd" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" OnClick="ibtnNuevoPVAAdd_Click" /></td>
		                                                        </tr>
		                                                        <tr>
		                                                            <td colspan="2">
		                                                                <asp:Panel ID="pnlProyectoVisitaAcuerdoAdd" runat="server" Width="100%" Visible="False">
		                                                                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Descripción del acuerdo</td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:TextBox ID="txtDescAcuerdoPVAAdd" runat="server" EnableTheming="True" MaxLength="500"
		                                                                                    Rows="5" TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator
		                                                                                        ID="rfvDescAcuerdoPVAAdd" runat="server" ControlToValidate="txtDescAcuerdoPVAAdd"
		                                                                                        EnableTheming="True" ErrorMessage="Descripción del acuerdo es un dato requerido"
		                                                                                        ForeColor="" ToolTip="Descripción del acuerdo es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                                            ID="revDescAcuerdoPVAAdd" runat="server" ControlToValidate="txtDescAcuerdoPVAAdd"
		                                                                                            ErrorMessage="Descripción del acuerdo tiene caracteres no permitidos" ForeColor=""
		                                                                                            ToolTip="Descripción del acuerdo tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><asp:CustomValidator
		                                                                                                ID="cuvDescAcuerdoPVAAdd" runat="server" ControlToValidate="txtDescAcuerdoPVAAdd"
		                                                                                                EnableTheming="True" ForeColor="">x</asp:CustomValidator></td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Fecha de vencimiento</td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:UpdatePanel ID="updpFechaVenPVAAdd" runat="server">
		                                                                                    <ContentTemplate>
		                                                                                        <ews:DatePicker ID="dtpkFechaVenPVAAdd" runat="server" ExpandButtonImage="~/images/aplicacion/show-calendar1.gif"/>
		                                                                                        <asp:RequiredFieldValidator ID="rfvFechaVenPVAAdd" runat="server" ControlToValidate="dtpkFechaVenPVAAdd"
		                                                                                            EnableTheming="True" ErrorMessage="Fecha de vencimiento es un dato requerido"
		                                                                                            ForeColor="" ToolTip="Fecha de vencimiento es un dato requerido">x</asp:RequiredFieldValidator>
		                                                                                        <asp:RegularExpressionValidator ID="revFechaVenPVAAdd" runat="server" ControlToValidate="dtpkFechaVenPVAAdd"
		                                                                                            ErrorMessage="Formato de fecha de vencimiento debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                                            ToolTip="Formato de fecha de vencimiento debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
		                                                                                    </ContentTemplate>
		                                                                                </asp:UpdatePanel>
		                                                                                &nbsp;
		                                                                            </td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Cumplido</td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:CheckBox ID="chkbCumplidoPVAAdd" runat="server" /></td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                            </td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:ValidationSummary ID="vsAcuerdosPVAAdd" runat="server" DisplayMode="List" ForeColor="" />
		                                                                            </td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                            </td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:ImageButton ID="ibtnGuardarPVAAdd" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" OnClick="ibtnGuardarPVAAdd_Click" />
		                                                                                <asp:ImageButton ID="ibtnCancelarPVAAdd" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" OnClick="ibtnCancelarPVAAdd_Click" /></td>
		                                                                        </tr>
		                                                                    </table>
		                                                                    &nbsp;</asp:Panel>
		                                                            </td>
		                                                        </tr>
		                                                        <tr>
		                                                            <td colspan="2">
		                                                                <asp:DataList ID="dtlProyVisitaAcuerdoPVA" runat="server" DataKeyField="CveAcuerdo" DataSourceID="odsProyVisitaAcuerdoPVA"
		                                            OnCancelCommand="dtlProyVisitaAcuerdoPVA_CancelCommand" OnDeleteCommand="dtlProyVisitaAcuerdoPVA_DeleteCommand"
		                                            OnEditCommand="dtlProyVisitaAcuerdoPVA_EditCommand" OnItemDataBound="dtlProyVisitaAcuerdoPVA_ItemDataBound"
		                                            OnUpdateCommand="dtlProyVisitaAcuerdoPVA_UpdateCommand" Width="100%" EnableTheming="True">
		                                                                    <ItemTemplate>
		                                                                        <table border="0" cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
		                                                                            <tr>
		                                                                                <td style="width: 16%">
		                                                                                    <asp:ImageButton ID="ibtnEditarPVAItm" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                                                <td style="width: 52%">
		                                                                                    <asp:CheckBox ID="chkbCumplidoPVAItm" runat="server" Checked='<%# Eval("Cumplido") %>'
		                                                                                        Enabled="False" />
		                                                                                    <asp:Label ID="lblDescAcuerdoPVAItm" runat="server" Text='<%# Eval("DescAcuerdo") %>'></asp:Label></td>
		                                                                                <td style="width: 16%" align="right">
		                                                                                    <asp:Label ID="lblFechaVenPVAItm" runat="server" Text='<%# Eval("FechaVencimiento", "{0:d}") %>'></asp:Label></td>
		                                                                                <td style="width: 16%">
		                                                                                    <asp:ImageButton ID="ibtnEliminarPVAItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                                            </tr>
		                                                                        </table>
		                                                                    </ItemTemplate>
		                                                                    <AlternatingItemTemplate>
		                                                                        <table border="0" cellpadding="3" cellspacing="0" class="tablaAlternatigTemplate" width="100%">
		                                                                            <tr>
		                                                                                <td style="width: 16%">
		                                                                                    <asp:ImageButton ID="ibtnEditarPVAItm" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                                                <td style="width: 52%">
		                                                                                    <asp:CheckBox ID="chkbCumplidoPVAItm" runat="server" Checked='<%# Eval("Cumplido") %>'
		                                                                                        Enabled="False" />
		                                                                                    <asp:Label ID="lblDescAcuerdoPVAItm" runat="server" Text='<%# Eval("DescAcuerdo") %>'></asp:Label>
		                                                                                </td>
		                                                                                <td style="width: 16%" align="right">
		                                                                                    <asp:Label ID="lblFechaVenPVAItm" runat="server" Text='<%# Eval("FechaVencimiento", "{0:d}") %>'></asp:Label></td>
		                                                                                <td style="width: 16%">
		                                                                                    <asp:ImageButton ID="ibtnEliminarPVAItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                                            </tr>
		                                                                        </table>
		                                                                    </AlternatingItemTemplate>
		                                                                    <EditItemTemplate><table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Descripción del acuerdo</td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:TextBox ID="txtDescAcuerdoPVAEdt" runat="server" EnableTheming="True" MaxLength="500"
		                                                                                    Rows="5" Text='<%# Eval("DescAcuerdo") %>' TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator
		                                                                                        ID="rfvDescAcuerdoPVAEdt" runat="server" ControlToValidate="txtDescAcuerdoPVAEdt"
		                                                                                        EnableTheming="True" ErrorMessage="Descripción del acuerdo es un dato requerido"
		                                                                                        ForeColor="" ToolTip="Descripción del acuerdo es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                                            ID="revDescAcuerdoPVAEdt" runat="server" ControlToValidate="txtDescAcuerdoPVAEdt"
		                                                                                            ErrorMessage="Descripción del acuerdo tiene caracteres no permitidos" ForeColor=""
		                                                                                            ToolTip="Descripción del acuerdo tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><asp:CustomValidator
		                                                                                                ID="cuvDescAcuerdoPVAEdt" runat="server" ControlToValidate="txtDescAcuerdoPVAEdt"
		                                                                                                EnableTheming="True" ForeColor="">x</asp:CustomValidator></td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Fecha de vencimiento</td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:UpdatePanel ID="updpFechaVenPVAEdt" runat="server">
		                                                                                    <ContentTemplate>
		                                                                                        <ews:DatePicker ID="dtpkFechaVenPVAEdt" runat="server" ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" CalendarPosition="DisplayRight" DateValue='<%# Eval("FechaVencimiento") %>'/>
		                                                                                        <asp:RequiredFieldValidator ID="rfvFechaVenPVAEdt" runat="server" ControlToValidate="dtpkFechaVenPVAEdt"
		                                                                                            EnableTheming="True" ErrorMessage="Fecha de vencimiento es un dato requerido"
		                                                                                            ForeColor="" ToolTip="Fecha de vencimiento es un dato requerido">x</asp:RequiredFieldValidator>
		                                                                                        <asp:RegularExpressionValidator ID="revFechaVenPVAEdt" runat="server" ControlToValidate="dtpkFechaVenPVAEdt"
		                                                                                            ErrorMessage="Formato de fecha de vencimiento debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                                            ToolTip="Formato de fecha de vencimiento debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
		                                                                                    </ContentTemplate>
		                                                                                </asp:UpdatePanel>
		                                                                                &nbsp;
		                                                                            </td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Cumplido</td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:CheckBox ID="chkbCumplidoPVAEdt" runat="server" Checked='<%# Eval("Cumplido") %>' /></td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                            </td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:ValidationSummary ID="vsAcuerdosPVAEdt" runat="server" DisplayMode="List" ForeColor="" />
		                                                                            </td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                            </td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:ImageButton ID="ibtnGuardarPVAEdt" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" CommandName="Update" />
		                                                                                <asp:ImageButton ID="ibtnCancelarPVAEdt" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" CommandName="Cancel" /></td>
		                                                                        </tr>
		                                                                    </table>
		                                                                    </EditItemTemplate>
		                                                                    <HeaderTemplate>
		                                                                        <table border="0" cellpadding="3" cellspacing="0" class="tablaHeaderTemplate" width="100%">
		                                                                            <tr>
		                                                                                <th style="width: 16%">&nbsp;
		                                                                                    </th>
		                                                                                <th style="width: 52%">
		                                                                                    Descripción</th>
		                                                                                <th style="width: 16%">
		                                                                                    Fecha vencimiento</th>
		                                                                                <th style="width: 16%">&nbsp;
		                                                                                    </th>
		                                                                            </tr>
		                                                                        </table>
		                                                                    </HeaderTemplate>
		                                                                </asp:DataList><asp:ObjectDataSource ID="odsProyVisitaAcuerdoPVA" runat="server" OldValuesParameterFormatString="original_{0}"
		                                            SelectMethod="GetDataByCveProyectoCveVisita" TypeName="dsAppTableAdapters.AcuerdosVisitasTableAdapter" OnSelecting="odsProyVisitaAcuerdoPVA_Selecting">
		                                                                </asp:ObjectDataSource>
		                                                            </td>
		                                                        </tr>
		                                                        <tr>
		                                                            <td colspan="2">
		                                                            </td>
		                                                        </tr>
		                                                    </table>
		                                                    </asp:View>
		                                                </asp:MultiView>
		                                            </EditItemTemplate>
		                                            <HeaderTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaHeaderTemplate" width="100%">
		                                                    <tr>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                        <th style="width: 52%">
		                                                            Instalaciones</th>
		                                                        <th style="width: 16%">
		                                                            Fecha</th>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                    </tr>
		                                                </table>
		                                            </HeaderTemplate>
		                                            <SelectedItemTemplate>
		                                                <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                    <tr>
		                                                        <td colspan="2">&nbsp;
		                                                            </td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Instalaciones</td>
		                                                        <td style="width: 70%">
		                                                            <asp:Label ID="lblInstalacionesPVSel" runat="server" Text='<%# Eval("Instalaciones") %>'></asp:Label></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Estado</td>
		                                                        <td style="width: 70%">
		                                                            <asp:Label ID="lblEstadoPVSel" runat="server" Text='<%# Eval("Estado") %>'></asp:Label></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Municipio</td>
		                                                        <td style="width: 70%">
		                                                            <asp:Label ID="lblMunicipioPVSel" runat="server" Text='<%# Eval("Municipio") %>'></asp:Label></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Fecha de la visita</td>
		                                                        <td style="width: 70%">
		                                                            <asp:Label ID="lblFechaVisitaPVSel" runat="server" Text='<%# Eval("FechaVisita", "{0:d}") %>'></asp:Label></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Asistentes</td>
		                                                        <td style="width: 70%">
		                                                            <asp:Label ID="lblAsistentesPVSel" runat="server" Text='<%# Eval("Asistentes") %>'></asp:Label></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Avance general</td>
		                                                        <td style="width: 70%">
		                                                            <asp:Label ID="lblAvanceGralPVSel" runat="server" Text='<%# Eval("AvanceGral", "{0:N}") %>'></asp:Label></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            ¿Se entregaron productos?</td>
		                                                        <td style="width: 70%">
		                                                            <asp:CheckBox ID="chkbEntregaProdsPVSel" runat="server" Checked='<%# Eval("EntregaProductos") %>'
		                                                                Enabled="False" /></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Observaciones</td>
		                                                        <td style="width: 70%">
		                                                            <asp:Label ID="lblObservacionesPVSel" runat="server" Text='<%# Eval("Observaciones") %>'></asp:Label></td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                        </td>
		                                                        <td style="width: 70%">
		                                                        </td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                        </td>
		                                                        <td style="width: 70%">
		                                                            <asp:ImageButton ID="ibtnRegresarPVSel" runat="server" ImageUrl="~/images/aplicacion/btnRegresar.gif" CommandName="Cancel" />
		                                                        </td>
		                                                    </tr>
		                                                </table>
		                                            </SelectedItemTemplate>
		                                        </asp:DataList>
		                                        <asp:ObjectDataSource ID="odsProyectoVisitasPV" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCveProyecto"
		                                            TypeName="dsAppTableAdapters.ProyectoVisitasTecnicasTableAdapter">
		                                            <SelectParameters>
		                                                <asp:ControlParameter ControlID="lblCveCONACYTEdt" Name="CveProyecto" PropertyName="Text"
		                                                    Type="String" />
		                                            </SelectParameters>
		                                        </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                    </td>
		                                </tr>
		                            </table>
		                        </asp:View>
		                        <asp:View ID="viewSeguimientoEdt" runat="server">
		                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
		                                <tr>
		                                    <td colspan="2">&nbsp;
		                                        
		                                    </td>
		                                </tr>
		
		                                <tr>
		                                    <th class="thtablaComun" colspan="2" style="height: 19px">
		                                        Asuntos relacionados al proyecto</th>
		                                </tr>
		                                <%--entra Polo--%>
		                                <%--espaciado poco elegante--%>
		                                <tr><td colspan="2">&nbsp;</td></tr>                            
		                                <tr>
		                                    <td colspan="2" style="width: 30%">
		                                        Clave CONACYT:&nbsp;<%# Eval("CveProyecto") %></td>                                
		                                </tr>
		                                <tr>
		                                    <td colspan="2" style="width: 30%">
		                                        Estatus:&nbsp;<%#Eval("Estatus")%></td>                                
		                                </tr>
		                                <%--espaciado poco elegante--%>
		                                <tr><td colspan="2">&nbsp;</td></tr>                                                        
		                                <%--sale Polo--%>                            
		                                <tr><td colspan="2"><asp:ImageButton ID="ibtnNuevoPTAdd" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" OnClick="ibtnNuevoPTAdd_Click" /></td></tr>
		                                <tr>
		                                    <td colspan="2">
		                                        <asp:Panel ID="pnlProyectoAsuntoPTAdd" runat="server" Width="100%" Visible="False"><table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate"><tr><td style="width: 30%">Descripción del asunto</td><td style="width: 70%"><asp:TextBox ID="txtDescAsuntoPTAdd" runat="server" MaxLength="100" Width="400px"></asp:TextBox><asp:RequiredFieldValidator
		                                                        ID="rfvDescAsuntoPTAdd" runat="server" ControlToValidate="txtDescAsuntoPTAdd"
		                                                        ErrorMessage="Descripción del asunto es un valor requerido" ForeColor="" ToolTip="Descripción del asunto es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                        ID="revDescAsuntoPTAdd" runat="server" ControlToValidate="txtDescAsuntoPTAdd"
		                                                        ErrorMessage="Descripción del asunto tiene caracteres no permitidos" ForeColor=""
		                                                        ToolTip="Descripción del asunto tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><asp:CustomValidator
		                                                            ID="cuvDescAsuntoPTAdd" runat="server" ControlToValidate="txtDescAsuntoPTAdd"
		                                                            ForeColor="">x</asp:CustomValidator></td></tr><tr><td style="width: 30%">Estatus</td><td style="width: 70%"><asp:DropDownList ID="ddlEstatusAsuntoPTAdd" runat="server" DataSourceID="odsEstatusAsuntoPTAdd"
		                                                                    DataTextField="DesEstatus" DataValueField="CveEstatus">
		                                                    </asp:DropDownList><asp:RangeValidator ID="ravEstatusAsuntoPTAdd" runat="server"
		                                                        ControlToValidate="ddlEstatusAsuntoPTAdd" ErrorMessage="Debe seleccionar un estatus"
		                                                        ForeColor="" MaximumValue="1000000" MinimumValue="1" ToolTip="Debe seleccionar un estatus"
		                                                        Type="Integer">x</asp:RangeValidator> <asp:ObjectDataSource
		                                                                    ID="odsEstatusAsuntoPTAdd" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                    SelectMethod="GetData" TypeName="dsAppTableAdapters.spEstatusDDLTableAdapter">
		                                                        <SelectParameters>
		                                                            <asp:Parameter DefaultValue="1" Name="CveObjeto" Type="Int32" />
		                                                        </SelectParameters>
		                                                    </asp:ObjectDataSource> </td></tr><tr><td style="width: 30%"></td><td style="width: 70%"><asp:ValidationSummary ID="vsAsuntosPTAdd" runat="server" DisplayMode="List" ForeColor="" /> </td></tr><tr><td style="width: 30%"></td><td style="width: 70%"><asp:ImageButton ID="ibtnGuardarPTAdd" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" OnClick="ibtnGuardarPTAdd_Click" /> <asp:ImageButton ID="ibtnCancelarPTAdd" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" OnClick="ibtnCancelarPTAdd_Click" /></td></tr></table>&nbsp;</asp:Panel>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                        <asp:DataList ID="dtlProyectoAsuntosPT" runat="server" DataKeyField="CveAsunto" DataSourceID="odsProyectoAsuntosPT"
		                                            OnCancelCommand="dtlProyectoAsuntosPT_CancelCommand" OnDeleteCommand="dtlProyectoAsuntosPT_DeleteCommand"
		                                            OnEditCommand="dtlProyectoAsuntosPT_EditCommand" OnItemDataBound="dtlProyectoAsuntosPT_ItemDataBound"
		                                            OnUpdateCommand="dtlProyectoAsuntosPT_UpdateCommand" Width="100%">
		                                            <ItemTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
		                                                    <tr>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEditarPTItm" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                        <td style="width: 52%">
		                                                            <asp:Label ID="lblDescAsuntoPTItm" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
		                                                        </td>
		                                                        <td style="width: 16%" align="right">
		                                                            <asp:Label ID="lblEstatusPTItm" runat="server" Text='<%# Eval("DesEstatus") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEliminarPTItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                    </tr>
		                                                </table>
		                                            </ItemTemplate>
		                                            <AlternatingItemTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaAlternatigTemplate" width="100%">
		                                                    <tr>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEditarPTItm" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                        <td style="width: 52%">
		                                                            <asp:Label ID="lblDescAsuntoPTItm" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
		                                                        </td>
		                                                        <td style="width: 16%" align="right">
		                                                            <asp:Label ID="lblEstatusPTItm" runat="server" Text='<%# Eval("DesEstatus") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEliminarPTItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                    </tr>
		                                                </table>
		                                            </AlternatingItemTemplate>
		                                            <EditItemTemplate><table cellpadding="0" cellspacing="0" class="seccionPestanas" style="width: 100%">
		                                                <tr>
		                                                    <td style="width: 144px; height: 24px">
		                                                        <asp:ImageButton ID="ibtnProyectoAsuntoPAOEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_as_sel.gif"
		                                    PostBackUrl="~/RegistroProyectos.aspx" OnClick="ibtnProyectoAsuntoPAOEdt_Click" /></td>
		                                                    <td style="width: 144px; height: 24px">
		                                                        <asp:ImageButton ID="ibtnProyectAsuntoOficioPAOEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_ao_rep.gif"
		                                    PostBackUrl="~/RegistroProyectos.aspx" OnClick="ibtnProyectAsuntoOficioPAOEdt_Click" /></td>
		                                                    <td style="width: 144px; height: 24px">&nbsp;
		                                                        </td>
		                                                    <td style="width: 144px; height: 24px">&nbsp;
		                                                        </td>
		                                                    <td align="left" style="width: 224px; height: 24px">&nbsp;
		                                                        </td>
		                                                </tr>
		                                            </table>
		                                                <asp:MultiView ID="mviewAsuntosOficiosPAO" runat="server" ActiveViewIndex="0">
		                                                    <asp:View ID="viewAsuntoPAO" runat="server">
		                                                <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Descripción del asunto</td>
		                                                        <td style="width: 70%">
		                                                            <asp:TextBox ID="txtDescAsuntoPTEdt" runat="server" MaxLength="100" Text='<%# Eval("Descripcion") %>'
		                                                                Width="400px"></asp:TextBox>
		                                                            <asp:RequiredFieldValidator ID="rfvDescAsuntoPTEdt" runat="server" ControlToValidate="txtDescAsuntoPTEdt"
		                                                                ErrorMessage="Descripción del asunto es un valor requerido" ForeColor="" ToolTip="Descripción del asunto es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="revDescAsuntoPTEdt"
		                                                                    runat="server" ControlToValidate="txtDescAsuntoPTEdt" ErrorMessage="Descripción del asunto tiene caracteres no permitidos"
		                                                                    ForeColor="" ToolTip="Descripción del asunto tiene caracteres no permitidos"
		                                                                    ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><asp:CustomValidator
		                                                                        ID="cuvDescAsuntoPTEdt" runat="server" ControlToValidate="txtDescAsuntoPTEdt"
		                                                                        ForeColor="">x</asp:CustomValidator><asp:HiddenField ID="hdnfCveAsuntoPTEdt" runat="server" Value='<%# Eval("CveAsunto") %>' />
		                                                        </td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                            Estatus</td>
		                                                        <td style="width: 70%">
		                                                            <asp:DropDownList ID="ddlEstatusAsuntoPTEdt" runat="server" DataSourceID="odsEstatusAsuntoPTEdt"
		                                                                    DataTextField="DesEstatus" DataValueField="CveEstatus" SelectedValue='<%# Eval("Estatus") %>'>
		                                                            </asp:DropDownList><asp:RangeValidator ID="ravEstatusAsuntoPTEdt" runat="server"
		                                                                ControlToValidate="ddlEstatusAsuntoPTEdt" ErrorMessage="Debe seleccionar un estatus"
		                                                                ForeColor="" MaximumValue="1000000" MinimumValue="1" ToolTip="Debe seleccionar un estatus"
		                                                                Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
		                                                                    ID="odsEstatusAsuntoPTEdt" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                    SelectMethod="GetData" TypeName="dsAppTableAdapters.spEstatusDDLTableAdapter">
		                                                                    <SelectParameters>
		                                                                        <asp:Parameter DefaultValue="1" Name="CveObjeto" Type="Int32" />
		                                                                    </SelectParameters>
		                                                                </asp:ObjectDataSource>
		                                                        </td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                        </td>
		                                                        <td style="width: 70%">
		                                                            <asp:ValidationSummary ID="vsAsuntosPTEdt" runat="server" DisplayMode="List" ForeColor="" />
		                                                        </td>
		                                                    </tr>
		                                                    <tr>
		                                                        <td style="width: 30%">
		                                                        </td>
		                                                        <td style="width: 70%">
		                                                            <asp:ImageButton ID="ibtnGuardarPTEdt" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" CommandName="Update" />
		                                                            <asp:ImageButton ID="ibtnCancelarPTEdt" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" CommandName="Cancel" /></td>
		                                                    </tr>
		                                                </table>
		                                                    </asp:View>
		                                                    <asp:View ID="viewOficiosPAO" runat="server">
		                                                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
		                                                            <tr>
		                                                                <td colspan="2">&nbsp;
		                                                                    
		                                                                </td>
		                                                            </tr>
		                                                            <tr>
		                                                                <th class="thtablaComun" colspan="2" style="height: 19px">
		                                                                    Oficios</th>
		                                                            </tr>
		                                                            <tr>
		                                                                <td colspan="2">
		                                                                    <asp:ImageButton ID="ibtnNuevoPAOAdd" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" OnClick="ibtnNuevoPAOAdd_Click" /></td>
		                                                            </tr>
		                                                            <tr>
		                                                                <td colspan="2">
		                                                                    <asp:Panel ID="pnlProyectoAsuntoOficioAdd" runat="server" Width="100%" Visible="False">
		                                                                        <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                                            <tr>
		                                                                                <td style="width: 30%">
		                                                                                    Fecha del oficio</td>
		                                                                                <td style="width: 70%">
		                                                                                    <asp:UpdatePanel ID="updpFechaOficPAOAdd" runat="server">
		                                                                                        <ContentTemplate>
		                                                                                            <ews:DatePicker ID="dtpkFechaOficPAOAdd" runat="server" ExpandButtonImage="~/images/aplicacion/show-calendar1.gif"/>
		                                                                                            <asp:RequiredFieldValidator ID="rfvFechaOficPAOAdd" runat="server" ControlToValidate="dtpkFechaOficPAOAdd"
		                                                                                                EnableTheming="True" ErrorMessage="Fecha del oficio es un dato requerido" ForeColor=""
		                                                                                                ToolTip="Fecha del oficio es un dato requerido">x</asp:RequiredFieldValidator><asp:CustomValidator
		                                                                                                    ID="cuvFechaOficPAOAdd" runat="server" ControlToValidate="dtpkFechaOficPAOAdd"
		                                                                                                    EnableTheming="True" ForeColor="">x</asp:CustomValidator>
		                                                                                        </ContentTemplate>
		                                                                                    </asp:UpdatePanel>
		                                                                                </td>
		                                                                            </tr>
		                                                                            <tr>
		                                                                                <td style="width: 30%">
		                                                                                    Número de oficio</td>
		                                                                                <td style="width: 70%">
		                                                                                    <asp:TextBox ID="txtNumOficioPAOAdd" runat="server" MaxLength="30"></asp:TextBox><asp:RequiredFieldValidator
		                                                                                        ID="rfvNumOficioPAOAdd" runat="server" ControlToValidate="txtNumOficioPAOAdd"
		                                                                                        EnableTheming="True" ErrorMessage="Número de oficio es un dato requerido" ForeColor=""
		                                                                                        ToolTip="Número de oficio es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                                            ID="revNumOficioPAOAdd" runat="server" ControlToValidate="txtNumOficioPAOAdd"
		                                                                                            ErrorMessage="Número de oficio tiene caracteres no permitidos" ForeColor="" ToolTip="Número de oficio tiene caracteres no permitidos"
		                                                                                            ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                                            </tr>
		                                                                            <tr>
		                                                                                <td style="width: 30%">
		                                                                                    Remitente</td>
		                                                                                <td style="width: 70%">
		                                                                                    <asp:TextBox ID="txtRemitentePAOAdd" runat="server" MaxLength="100" Width="400px"></asp:TextBox><asp:RequiredFieldValidator
		                                                                                        ID="rfvRemitentePAOAdd" runat="server" ControlToValidate="txtRemitentePAOAdd"
		                                                                                        EnableTheming="True" ErrorMessage="Remitente es un dato requerido" ForeColor=""
		                                                                                        ToolTip="Remitente es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                                            ID="revRemitentePAOAdd" runat="server" ControlToValidate="txtRemitentePAOAdd"
		                                                                                            ErrorMessage="Remitente tiene caracteres no permitidos" ForeColor="" ToolTip="Remitente tiene caracteres no permitidos"
		                                                                                            ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                                            </tr>
		                                                                            <tr>
		                                                                                <td style="width: 30%">
		                                                                                    Destinatario</td>
		                                                                                <td style="width: 70%">
		                                                                                    <asp:TextBox ID="txtDestinatarioPAOAdd" runat="server" MaxLength="100" Width="400px"></asp:TextBox><asp:RequiredFieldValidator
		                                                                                        ID="rfvDestinatarioPAOAdd" runat="server" ControlToValidate="txtDestinatarioPAOAdd"
		                                                                                        EnableTheming="True" ErrorMessage="Destinatario es un dato requerido" ForeColor=""
		                                                                                        ToolTip="Destinatario es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                                            ID="revDestinatarioPAOAdd" runat="server" ControlToValidate="txtDestinatarioPAOAdd"
		                                                                                            ErrorMessage="Destinatario tiene caracteres no permitidos" ForeColor="" ToolTip="Destinatario tiene caracteres no permitidos"
		                                                                                            ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                                            </tr>
		                                                                            <tr>
		                                                                                <td style="width: 30%">
		                                                                                    Descripción del oficio (opcional)</td>
		                                                                                <td style="width: 70%">
		                                                                                    <asp:TextBox ID="txtDescOficioPAOAdd" runat="server" EnableTheming="True" MaxLength="1000"
		                                                                                        Rows="5" TextMode="MultiLine" Width="400px"></asp:TextBox><%--comentado por Polo--%><%--<asp:RequiredFieldValidator
		                                                                                            ID="rfvDescOficioPAOAdd" runat="server" ControlToValidate="txtDescOficioPAOAdd"
		                                                                                            EnableTheming="True" ErrorMessage="Descripción del oficio es un dato requerido"
		                                                                                            ForeColor="" ToolTip="Descripción del oficio es un dato requerido">x</asp:RequiredFieldValidator>--%><asp:RegularExpressionValidator
		                                                                                                ID="revDescOficioPAOAdd" runat="server" ControlToValidate="txtDescOficioPAOAdd"
		                                                                                                ErrorMessage="Descripción del oficio tiene caracteres no permitidos" ForeColor=""
		                                                                                                ToolTip="Descripción del oficio tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                                            </tr>
		                                                                            <tr>
		                                                                                <td style="width: 30%">
		                                                                                </td>
		                                                                                <td style="width: 70%">
		                                                                                    <asp:ValidationSummary ID="vsOficiosPAOAdd" runat="server" DisplayMode="List" ForeColor="" />
		                                                                                </td>
		                                                                            </tr>
		                                                                            <tr>
		                                                                                <td style="width: 30%">
		                                                                                </td>
		                                                                                <td style="width: 70%">
		                                                                                    <asp:ImageButton ID="ibtnGuardarPAOAdd" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" OnClick="ibtnGuardarPAOAdd_Click" />
		                                                                                    <asp:ImageButton ID="ibtnCancelarPAOAdd" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" OnClick="ibtnCancelarPAOAdd_Click" /></td>
		                                                                            </tr>
		                                                                        </table>
		                                                                        &nbsp;</asp:Panel>
		                                                                </td>
		                                                            </tr>
		                                                            <tr>
		                                                                <td colspan="2">
		                                                                    <asp:DataList ID="dtlProyAsuntoOficioPAO" runat="server" DataKeyField="CveOficio" DataSourceID="odsProyAsuntoOficioPAO" Width="100%" EnableTheming="True" OnCancelCommand="dtlProyAsuntoOficioPAO_CancelCommand" OnDeleteCommand="dtlProyAsuntoOficioPAO_DeleteCommand" OnEditCommand="dtlProyAsuntoOficioPAO_EditCommand" OnItemDataBound="dtlProyAsuntoOficioPAO_ItemDataBound" OnSelectedIndexChanged="dtlProyAsuntoOficioPAO_SelectedIndexChanged" OnUpdateCommand="dtlProyAsuntoOficioPAO_UpdateCommand">
		                                                                        <ItemTemplate>
		                                                                            <table border="0" cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
		                                                                                <tr>
		                                                                                    <td style="width: 16%">
		                                                                                        <asp:ImageButton ID="ibtnEditarPAOItm" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                                                    <td style="width: 16%" align="right">
		                                                                                        &nbsp;<asp:Label ID="lblNumOficioPAOItm" runat="server" Text='<%# Eval("NumOficio") %>'></asp:Label></td>
		                                                                                    <td style="width: 52%">
		                                                                                        <asp:Label ID="lblDescOficPAOItm" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label></td>
		                                                                                    <td style="width: 16%">
		                                                                                        <asp:ImageButton ID="ibtnEliminarPAOItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                                                </tr>
		                                                                            </table>
		                                                                        </ItemTemplate>
		                                                                        <AlternatingItemTemplate>
		                                                                            <table border="0" cellpadding="3" cellspacing="0" class="tablaAlternatigTemplate" width="100%">
		                                                                                <tr>
		                                                                                    <td style="width: 16%">
		                                                                                        <asp:ImageButton ID="ibtnEditarPAOItm" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                                                    <td style="width: 16%" align="right">
		                                                                                        &nbsp;<asp:Label ID="lblNumOficioPAOItm" runat="server" Text='<%# Eval("NumOficio") %>'></asp:Label>
		                                                                                    </td>
		                                                                                    <td style="width: 52%">
		                                                                                        <asp:Label ID="lblDescOficPAOItm" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label></td>
		                                                                                    <td style="width: 16%">
		                                                                                        <asp:ImageButton ID="ibtnEliminarPAOItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                                                </tr>
		                                                                            </table>
		                                                                        </AlternatingItemTemplate>
		                                                                        <EditItemTemplate>
		                                                                            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                                                <tr>
		                                                                                    <td style="width: 30%">
		                                                                                        Fecha del oficio</td>
		                                                                                    <td style="width: 70%">
		                                                                                        <asp:UpdatePanel ID="updpFechaOficPAOEdt" runat="server">
		                                                                                            <ContentTemplate>
		                                                                                                <ews:DatePicker ID="dtpkFechaOficPAOEdt" runat="server" ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" CalendarPosition="DisplayRight" DateValue='<%# Eval("Fecha") %>'/>
		                                                                                                <asp:RequiredFieldValidator ID="rfvFechaOficPAOEdt" runat="server" ControlToValidate="dtpkFechaOficPAOEdt"
		                                                                                                    EnableTheming="True" ErrorMessage="Fecha del oficio es un dato requerido" ForeColor=""
		                                                                                                    ToolTip="Fecha del oficio es un dato requerido">x</asp:RequiredFieldValidator><asp:CustomValidator
		                                                                                                        ID="cuvFechaOficPAOEdt" runat="server" ControlToValidate="dtpkFechaOficPAOEdt"
		                                                                                                        EnableTheming="True" ForeColor="">x</asp:CustomValidator>
		                                                                                            </ContentTemplate>
		                                                                                        </asp:UpdatePanel>
		                                                                                    </td>
		                                                                                </tr>
		                                                                                <tr>
		                                                                                    <td style="width: 30%">
		                                                                                        Número de oficio</td>
		                                                                                    <td style="width: 70%">
		                                                                                        <asp:TextBox ID="txtNumOficioPAOEdt" runat="server" MaxLength="30" Text='<%# Eval("NumOficio") %>'></asp:TextBox><asp:RequiredFieldValidator
		                                                                                            ID="rfvNumOficioPAOEdt" runat="server" ControlToValidate="txtNumOficioPAOEdt"
		                                                                                            EnableTheming="True" ErrorMessage="Número de oficio es un dato requerido" ForeColor=""
		                                                                                            ToolTip="Número de oficio es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                                                ID="revNumOficioPAOEdt" runat="server" ControlToValidate="txtNumOficioPAOEdt"
		                                                                                                ErrorMessage="Número de oficio tiene caracteres no permitidos" ForeColor="" ToolTip="Número de oficio tiene caracteres no permitidos"
		                                                                                                ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                                                </tr>
		                                                                                <tr>
		                                                                                    <td style="width: 30%">
		                                                                                        Remitente</td>
		                                                                                    <td style="width: 70%">
		                                                                                        <asp:TextBox ID="txtRemitentePAOEdt" runat="server" MaxLength="100" Text='<%# Eval("Remitente") %>'
		                                                                                            Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvRemitentePAOEdt" runat="server"
		                                                                                                ControlToValidate="txtRemitentePAOEdt" EnableTheming="True" ErrorMessage="Remitente es un dato requerido"
		                                                                                                ForeColor="" ToolTip="Remitente es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                                                    ID="revRemitentePAOEdt" runat="server" ControlToValidate="txtRemitentePAOEdt"
		                                                                                                    ErrorMessage="Remitente tiene caracteres no permitidos" ForeColor="" ToolTip="Remitente tiene caracteres no permitidos"
		                                                                                                    ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                                                </tr>
		                                                                                <tr>
		                                                                                    <td style="width: 30%">
		                                                                                        Destinatario</td>
		                                                                                    <td style="width: 70%">
		                                                                                        <asp:TextBox ID="txtDestinatarioPAOEdt" runat="server" MaxLength="100" Text='<%# Eval("Destinatario") %>'
		                                                                                            Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvDestinatarioPAOEdt"
		                                                                                                runat="server" ControlToValidate="txtDestinatarioPAOEdt" EnableTheming="True"
		                                                                                                ErrorMessage="Destinatario es un dato requerido" ForeColor="" ToolTip="Destinatario es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                                                    ID="revDestinatarioPAOEdt" runat="server" ControlToValidate="txtDestinatarioPAOEdt"
		                                                                                                    ErrorMessage="Destinatario tiene caracteres no permitidos" ForeColor="" ToolTip="Destinatario tiene caracteres no permitidos"
		                                                                                                    ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                                                </tr>
		                                                                                <tr>
		                                                                                    <td style="width: 30%">
		                                                                                        Descripción del oficio (opcional)</td>
		                                                                                    <td style="width: 70%">
		                                                                                        <asp:TextBox ID="txtDescOficioPAOEdt" runat="server" EnableTheming="True" MaxLength="1000"
		                                                                                            Rows="5" Text='<%# Eval("Descripcion") %>' TextMode="MultiLine" Width="400px"></asp:TextBox><%--comentado por Polo--%><%--<asp:RequiredFieldValidator
		                                                                                                ID="rfvDescOficioPAOEdt" runat="server" ControlToValidate="txtDescOficioPAOEdt"
		                                                                                                EnableTheming="True" ErrorMessage="Descripción del oficio es un dato requerido"
		                                                                                                ForeColor="" ToolTip="Descripción del oficio es un dato requerido">x</asp:RequiredFieldValidator>--%><asp:RegularExpressionValidator
		                                                                                                    ID="revDescOficioPAOEdt" runat="server" ControlToValidate="txtDescOficioPAOEdt"
		                                                                                                    ErrorMessage="Descripción del oficio tiene caracteres no permitidos" ForeColor=""
		                                                                                                    ToolTip="Descripción del oficio tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                                                </tr>
		                                                                                <tr>
		                                                                                    <td style="width: 30%">
		                                                                                    </td>
		                                                                                    <td style="width: 70%">
		                                                                                        <asp:ValidationSummary ID="vsOficiosPAOEdt" runat="server" DisplayMode="List" ForeColor="" />
		                                                                                    </td>
		                                                                                </tr>
		                                                                                <tr>
		                                                                                    <td style="width: 30%">
		                                                                                    </td>
		                                                                                    <td style="width: 70%">
		                                                                                        <asp:ImageButton ID="ibtnGuardarPAOEdt" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" CommandName="Update" />
		                                                                                        <asp:ImageButton ID="ibtnCancelarPAOEdt" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" CommandName="Cancel" /></td>
		                                                                                </tr>
		                                                                            </table>
		                                                                        </EditItemTemplate>
		                                                                        <HeaderTemplate>
		                                                                            <table border="0" cellpadding="3" cellspacing="0" class="tablaHeaderTemplate" width="100%">
		                                                                                <tr>
		                                                                                    <th style="width: 16%">&nbsp;
		                                                                                        </th>
		                                                                                    <th style="width: 16%">
		                                                                                        Número&nbsp; de Oficio</th>
		                                                                                    <th style="width: 52%">
		                                                                                        Descripción</th>
		                                                                                    <th style="width: 16%">&nbsp;
		                                                                                        </th>
		                                                                                </tr>
		                                                                            </table>
		                                                                        </HeaderTemplate>
		                                                                        <SelectedItemTemplate>
		                                                                            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                                                <tr>
		                                                                                    <td style="width: 30%">
		                                                                                        Fecha del oficio</td>
		                                                                                    <td style="width: 70%">
		                                                                                        <asp:Label ID="lblFechaOficPAOSel" runat="server" Text='<%# Eval("Fecha", "{0:d}") %>'></asp:Label></td>
		                                                                                </tr>
		                                                                                <tr>
		                                                                                    <td style="width: 30%">
		                                                                                        Número de oficio</td>
		                                                                                    <td style="width: 70%">
		                                                                                        <asp:Label ID="lblNumOficioPAOSel" runat="server" Text='<%# Eval("NumOficio") %>'></asp:Label></td>
		                                                                                </tr>
		                                                                                <tr>
		                                                                                    <td style="width: 30%">
		                                                                                        Remitente</td>
		                                                                                    <td style="width: 70%">
		                                                                                        <asp:Label ID="lblRemitentePAOSel" runat="server" Text='<%# Eval("Remitente") %>'></asp:Label></td>
		                                                                                </tr>
		                                                                                <tr>
		                                                                                    <td style="width: 30%">
		                                                                                        Destinatario</td>
		                                                                                    <td style="width: 70%">
		                                                                                        <asp:Label ID="lblDestinatarioPAOSel" runat="server" Text='<%# Eval("Destinatario") %>'></asp:Label></td>
		                                                                                </tr>
		                                                                                <tr>
		                                                                                    <td style="width: 30%">
		                                                                                        Descripción del oficio</td>
		                                                                                    <td style="width: 70%">
		                                                                                        <asp:Label ID="lblDescOficioPAOSel" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label></td>
		                                                                                </tr>
		                                                                                <tr>
		                                                                                    <td colspan="2">&nbsp;
		                                                                                        </td>
		                                                                                </tr>
		                                                                                <tr>
		                                                                                    <td style="width: 30%">
		                                                                                    </td>
		                                                                                    <td style="width: 70%">
		                                                                                        <asp:ImageButton ID="ibtnRegresarPAOSel" runat="server" ImageUrl="~/images/aplicacion/btnRegresar.gif" CommandName="Cancel" />
		                                                                                    </td>
		                                                                                </tr>
		                                                                            </table>
		                                                                        </SelectedItemTemplate>
		                                                                    </asp:DataList><asp:ObjectDataSource ID="odsProyAsuntoOficioPAO" runat="server" OldValuesParameterFormatString="original_{0}"
		                                            SelectMethod="GetDataByCveProyectoCveAsunto" TypeName="dsAppTableAdapters.AsuntosOficiosTableAdapter" OnSelecting="odsProyAsuntoOficioPAO_Selecting">
		                                                                    </asp:ObjectDataSource>
		                                                                </td>
		                                                            </tr>
		                                                            <tr>
		                                                                <td colspan="2">
		                                                                </td>
		                                                            </tr>
		                                                        </table>
		                                                    </asp:View>
		                                                </asp:MultiView>
		                                            </EditItemTemplate>
		                                            <HeaderTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaHeaderTemplate" width="100%">
		                                                    <tr>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                        <th style="width: 52%">
		                                                            Descripción</th>
		                                                        <th style="width: 16%">
		                                                            Estatus</th>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                    </tr>
		                                                </table>
		                                            </HeaderTemplate>
		                                        </asp:DataList><asp:ObjectDataSource ID="odsProyectoAsuntosPT" runat="server" OldValuesParameterFormatString="original_{0}"
		                                            SelectMethod="GetDataByCveProyecto" TypeName="dsAppTableAdapters.ProyectoAsuntosTableAdapter" DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
		                                            <SelectParameters>
		                                                <asp:ControlParameter ControlID="lblCveCONACYTEdt" Name="CveProyecto" PropertyName="Text"
		                                                    Type="String" />
		                                            </SelectParameters>
                                                    <DeleteParameters>
                                                        <asp:Parameter Name="Original_CveProyecto" Type="String" />
                                                        <asp:Parameter Name="Original_CveAsunto" Type="Int32" />
                                                    </DeleteParameters>
                                                    <UpdateParameters>
                                                        <asp:Parameter Name="Descripcion" Type="String" />
                                                        <asp:Parameter Name="Estatus" Type="Int32" />
                                                        <asp:Parameter Name="Original_CveProyecto" Type="String" />
                                                        <asp:Parameter Name="Original_CveAsunto" Type="Int32" />
                                                    </UpdateParameters>
                                                    <InsertParameters>
                                                        <asp:Parameter Name="CveProyecto" Type="String" />
                                                        <asp:Parameter Name="CveAsunto" Type="Int32" />
                                                        <asp:Parameter Name="Descripcion" Type="String" />
                                                        <asp:Parameter Name="Estatus" Type="Int32" />
                                                    </InsertParameters>
		                                        </asp:ObjectDataSource>
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                    </td>
		                                </tr>
		                            </table>
		                        </asp:View>
		                        <asp:View ID="viewAdministrativoEdt" runat="server">
		                           <asp:HiddenField ID="hdCveProyectoAdmEdt" Value='<%# Eval("CveProyecto") %>' runat="server" />
		                           <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
		                                <tr>
		                                    <td colspan="2">&nbsp;
		                                        
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <th class="thtablaComun" colspan="2" style="height: 19px">
		                                        Esquema de pagos</th>
		                                </tr>
		                                <tr>
		                                    <td colspan="2"><asp:ImageButton ID="ibtnNuevoPG" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" OnClick="ibtnNuevoPG_Click" /></td>
		                                </tr>                                                       
		                                <tr>
		                                    <td colspan="2">
		    <%--Entra el Polo--%>                                
		                                    <asp:Panel ID="pnlProgramaPagoPPAdd" runat="server" Width="100%" Visible="False">
		                                        <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                            <tr>
		                                                <td style="width: 30%">
		                                                    Etapa</td>
		                                                <td style="width: 70%">
                                                            <asp:ObjectDataSource ID="odsEtapasDLLAdd" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="dsAppTableAdapters.spProyectoEtapa_DLL_ByCveProyectoTableAdapter">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdCveProyectoAdmEdt" Name="CveProyecto" PropertyName="Value"
                                                                        Type="String" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                            <asp:DropDownList ID="ddlCveEtapaAdd" runat="server" DataSourceID="odsEtapasDLLAdd"
                                                                DataTextField="DescEtapa" DataValueField="CveEtapa">
                                                            </asp:DropDownList>&nbsp;
		                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="rfvCveEtapaAdd" ControlToValidate="ddlCveEtapaAdd" ErrorMessage="Etapa es un campo obligatorio" />&nbsp;
                                                            <asp:RangeValidator ID="rvCveEtapaAdd" runat="server" ControlToValidate="ddlCveEtapaAdd"
                                                                ErrorMessage="Seccione una etapa válida" MinimumValue="0" MaximumValue="99"></asp:RangeValidator></td>
		                                            </tr>
		                                            <tr>
		                                                <td style="width: 30%">
		                                                    Título</td>
		                                                <td style="width: 70%">
		                                                    <asp:TextBox ID="txtTituloAdd" runat="server" EnableViewState="false" Columns="60" ></asp:TextBox>
		                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="rfvTituloAdd" ControlToValidate="txtTituloAdd" ErrorMessage="Título es un campo obligatorio" />
		                                                </td>
		                                            </tr>
		                                            <tr>
		                                                <td style="width: 30%">
		                                                    Documento</td>
		                                                <td style="width: 70%">
		                                                <asp:FileUpload ID="flupPagosAdd" runat="server" EnableViewState="false" /><br />
		                                                <asp:RequiredFieldValidator runat="server" Display="dynamic" ID="rfvflupPagosAdd" ControlToValidate="flupPagosAdd" ErrorMessage="El documento es obligatorio" />
		                                                <asp:RegularExpressionValidator runat="server" Display="dynamic" ID="revflupPagosAdd" ControlToValidate="flupPagosAdd" ErrorMessage="El nombre del archivo tiene espacios o caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü\x22\#\$%\x26'()*\+,\-.?¡:;_\\\d\n]{0,}$" />                
		                                                    </td>
		                                            </tr>        
		                                            <tr>
		                                                <td style="width: 30%">
		                                                </td>
		                                                <td style="width: 70%">
		                                                    <asp:ImageButton ID="ibtnGuardarPGAdd" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" OnClick="ibtnGuardarPGAdd_Click" />                
		                                                    <asp:ImageButton ID="ibtnAdministrativoCancelar" runat="server" ImageUrl="~/images/aplicacion/btnCancelar.gif" CausesValidation="false" OnClick="ibtnCancelarPGAdd_Click" />
		                                                </td>
		                                            </tr>
		                                        </table>
		                                    </asp:Panel>
		                                    <asp:DataList ID="dtlProyectoProgPagoPG" runat="server" DataKeyField="CveDocumento" DataSourceID="odsPoryectoProgPagoPG" 
		                                     OnDeleteCommand="dtlProyectoProgPagoPG_DeleteCommand"
		                                     OnCancelCommand="dtlProyectoProgPagoPG_CancelCommand"
		                                     OnSelectedIndexChanged="dtlProyectoProgPagoPG_SelectedIndexChanged"
		                                     OnEditCommand="dtlProyectoProgPagoPG_EditCommand"
		                                     OnItemCommand="dtlMeloinvente"
		                                     OnUpdateCommand="dtlProyectoProgPagoPG_UpdateCommand"
		                                     Width="100%">
		                                    <HeaderTemplate>
		                                        <table border="0" cellpadding="3" cellspacing="0" class="tablaHeaderTemplate" width="100%">
		                                            <tr>
		                                                <th style="width: 16%">&nbsp;
		                                                    </th>
		                                                <th style="width: 34%">
		                                                    Documento</th>
		                                                <th style="width: 34%">
		                                                    Etapa</th>
		                                                <th style="width: 16%">&nbsp;
		                                                    </th>
		                                            </tr>
		                                        </table>
		                                    </HeaderTemplate>
		                                    <ItemTemplate>
		                                        <table border="0" cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
		                                            <tr>
		                                                <td style="width: 16%">
		                                                    <asp:ImageButton ID="ibtnEditarPGItm" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" CausesValidation="false" /></td>
		                                                <td style="width: 34%">
		                                                    &nbsp;
		                                                    <asp:LinkButton ID="lnkbAdminPago" runat="server" CommandArgument='<%# Eval("Ubicacion") %>' Text='<%# Eval("Titulo") %>' CommandName="Bajalo"></asp:LinkButton>                
		                                                </td>
		                                                <td style="width: 34%" align="left">
		                                                    <asp:Label ID="lblDescEtapa" runat="server" Text='<%# Eval("DescEtapa") %>'></asp:Label></td>
		                                                <td style="width: 16%">
		                                                    <asp:ImageButton ID="ibtnEliminarPGItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" CausesValidation="false" />
		                                                    <asp:CustomValidator ID="cuvPGILista" runat="server" ForeColor="">x</asp:CustomValidator>
		                                                    </td>
		                                            </tr>
		                                        </table>
		                                    </ItemTemplate>
		                                    <EditItemTemplate>
		                                        <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                            <tr>
		                                                <td style="width: 30%">
		                                                    Etapa</td>
		                                                <td style="width: 70%">
		                                                    <asp:DropDownList ID="ddlCveEtapaEdt" runat="server" DataSourceID="odsEtapasDLLAdd"
                                                                DataTextField="DescEtapa" DataValueField="CveEtapa" selectedValue='<%# Eval("CveEtapa") %>'>
                                                            </asp:DropDownList>
		                                                
		                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="rfvCveEtapaEdt" ControlToValidate="ddlCveEtapaEdt" ErrorMessage="Etapa es un campo obligatorio" />
		                                                    <asp:RangeValidator ID="rvCveEtapaEdt" runat="server" ControlToValidate="ddlCveEtapaEdt"
                                                                ErrorMessage="Seccione una etapa válida" MinimumValue="0" MaximumValue="99"></asp:RangeValidator>
		                                                </td>
		                                            </tr>
		                                            <tr>
		                                                <td style="width: 30%">
		                                                    Título</td>
		                                                <td style="width: 70%">
		                                                    <asp:TextBox ID="txtTitulo" runat="server" Text='<%# Eval("Titulo") %>' Columns="60"></asp:TextBox>
		                                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="rfvTituloEdt" ControlToValidate="txtTitulo" ErrorMessage="Título es un campo obligatorio" />
		                                                </td>
		                                            </tr>
		                                            <tr>
		                                                <td style="width: 30%">
		                                                    Documento</td>
		                                                <td style="width: 70%">                
		                                                    <asp:Label ID="lblUbicacion" runat="server" Text='<%# Eval("Ubicacion") %>'></asp:Label></td>
		                                            </tr>        
		                                            <tr>
		                                                <td style="width: 30%; visibility:hidden">
		                                                <asp:Label ID="lblCveDocumento" runat="server" Text='<%# Eval("CveDocumento") %>'></asp:Label></td>
		                                                </td>
		                                                <td style="width: 70%">
		                                                    <asp:ImageButton ID="ibtnGuardarPGEdt" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" CommandName="Update" />
		                                                    <asp:ImageButton ID="ibtnRegresarPGSel" runat="server" ImageUrl="~/images/aplicacion/btnRegresar.gif" CommandName="Cancel" CausesValidation="false" />
		                                                </td>
		                                            </tr>
		                                        </table>
		                                    </EditItemTemplate>
		                                    <AlternatingItemStyle CssClass="tablaAlternatigTemplate" />
		                                    </asp:DataList>                                        
		                                    <asp:ObjectDataSource ID="odsPoryectoProgPagoPG" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCveProyecto" TypeName="dsAppTableAdapters.spAdministrativoPagosTableAdapter">
		                                        <SelectParameters>
		                                        <asp:ControlParameter ControlID="hdCveProyectoAdmEdt" Name="CveProyecto" PropertyName="Value" Type="String" />
		                                        </SelectParameters>
		                                    </asp:ObjectDataSource>                                
		    <%--Sale el Polo--%>                                    
		                                    </td>
		                                </tr>
		                           </table>
		                        </asp:View>
		                        <asp:View ID="viewEtapasEdt" runat="server">
		                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
		                            <tr>
		                                <td colspan="2">&nbsp;
		                                    
		                                </td>
		                            </tr>
		                            <tr>
		                                <th class="thtablaComun" colspan="2" style="height: 19px">
		                                    Etapas del proyecto</th>
		                            </tr>
		                            <tr>
		                                <td colspan="2">
		                                    <asp:ImageButton ID="ibtnNuevoPETAdd" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" OnClick="ibtnNuevoPETAdd_Click" /></td>
		                            </tr>
		                            <tr>
		                                <td colspan="2">
		                                    <asp:Panel ID="pnlProyectoEtapasPETAdd" runat="server" Width="100%" Visible="False">
		                                        <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                            <tr>
		                                                <td style="width: 30%">
		                                                    Etapa número</td>
		                                                <td style="width: 70%">
		                                                    <asp:TextBox ID="txtNumEtapaPETAdd" runat="server"></asp:TextBox><asp:RequiredFieldValidator
		                                                        ID="rfvNumEtapaPETAdd" runat="server" ControlToValidate="txtNumEtapaPETAdd" ErrorMessage="Etapa número es un dato requerido"
		                                                        ForeColor="" ToolTip="Etapa número es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                            ID="revNumEtapaPETAdd" runat="server" ControlToValidate="txtNumEtapaPETAdd" ErrorMessage="Etapa número tiene caracteres no permitidos"
		                                                            ForeColor="" ToolTip="Etapa número tiene caracteres no permitidos" ValidationExpression="^[0-9]{1,}$">x</asp:RegularExpressionValidator><asp:CustomValidator
		                                                                ID="cuvNumEtapaPETAdd" runat="server" ControlToValidate="txtNumEtapaPETAdd" ForeColor="">x</asp:CustomValidator></td>
		                                            </tr>
		                                            <tr>
		                                                <td style="width: 30%">
		                                                    Descripción de la etapa</td>
		                                                <td style="width: 70%">
		                                                    <asp:TextBox ID="txtDescEtapaPETAdd" runat="server" MaxLength="255" Rows="5" TextMode="MultiLine"
		                                                        Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvDescEtapaPETAdd" runat="server"
		                                                            ControlToValidate="txtDescEtapaPETAdd" ErrorMessage="Descripción de la etapa es un dato requerido"
		                                                            ForeColor="" ToolTip="Descripción de la etapa es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                ID="revDescEtapaPETAdd" runat="server" ControlToValidate="txtDescEtapaPETAdd"
		                                                                ErrorMessage="Descripción de la etapa tiene caracteres no permitidos" ForeColor=""
		                                                                ToolTip="Descripción de la etapa tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                            </tr>
		                                            <%--el Polo oculta--%>
		                                            <tr style="display:none;">
		                                                <td style="width: 30%">
		                                                    Descripción de la meta</td>
		                                                <td style="width: 70%">
		                                                    <asp:TextBox ID="txtDescMetaPETAdd" runat="server" MaxLength="255" Rows="5" TextMode="MultiLine"
		                                                        Width="400px"></asp:TextBox><asp:RegularExpressionValidator ID="revDescMetaPETAdd"
		                                                            runat="server" ControlToValidate="txtDescMetaPETAdd" ErrorMessage="Descripción de la meta tiene caracteres no permitidos"
		                                                            ForeColor="" ToolTip="Descripción de la meta tiene caracteres no permitidos"
		                                                            ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                            </tr>
		                                            <tr>
		                                                <td style="width: 30%">
		                                                    Descripción de las actividades</td>
		                                                <td style="width: 70%">
		                                                    <asp:TextBox ID="txtActividadesPETAdd" runat="server" MaxLength="1000" Rows="5" TextMode="MultiLine"
		                                                        Width="400px"></asp:TextBox><asp:RegularExpressionValidator ID="revActividadesPETAdd"
		                                                            runat="server" ControlToValidate="txtActividadesPETAdd" ErrorMessage="Actividades de la meta tiene caracteres no permitidos"
		                                                            ForeColor="" ToolTip="Actividades tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                            </tr>
		                                            <tr>
		                                                <td style="width: 30%">
		                                                    Fecha de inicio</td>
		                                                <td style="width: 70%">
		                                                    <asp:UpdatePanel ID="updpFechaInicioPETAdd" runat="server">
		                                                        <ContentTemplate>
		                                                            <ews:DatePicker ID="dtpkFechaInicioPETAdd" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif"  />
		                                                            <asp:RequiredFieldValidator ID="rfvFechaInicioPETAdd" runat="server" ControlToValidate="dtpkFechaInicioPETAdd"
		                                                                ErrorMessage="Fecha de inicio es requerida" ForeColor="" ToolTip="Fecha de inicio es requerida">x</asp:RequiredFieldValidator>
		                                                            <asp:RegularExpressionValidator ID="revFechaInicioPETAdd" runat="server" ControlToValidate="dtpkFechaInicioPETAdd"
		                                                                ErrorMessage="Formato de fecha de inicio debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                ToolTip="Formato de fecha de inicio debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
		                                                        </ContentTemplate>
		                                                    </asp:UpdatePanel>
		                                                </td>
		                                            </tr>
		                                            <tr>
		                                                <td style="width: 30%">
		                                                    Fecha de terminación</td>
		                                                <td style="width: 70%">
		                                                    <asp:UpdatePanel ID="updpFechaTermPETAdd" runat="server">
		                                                        <ContentTemplate>
		                                                            <ews:DatePicker ID="dtpkFechaTermPETAdd" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif"  />
		                                                            <asp:RequiredFieldValidator ID="rfvFechaTermPETAdd" runat="server" ControlToValidate="dtpkFechaTermPETAdd"
		                                                                ErrorMessage="Fecha de terminación es requerida" ForeColor="" ToolTip="Fecha de terminación es requerida">x</asp:RequiredFieldValidator>
		                                                            <asp:RegularExpressionValidator ID="revFechaTermPETAdd" runat="server" ControlToValidate="dtpkFechaTermPETAdd"
		                                                                ErrorMessage="Formato de fecha de terminación debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                ToolTip="Formato de fecha de terminación debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
		                                                        </ContentTemplate>
		                                                    </asp:UpdatePanel>
		                                                </td>
		                                            </tr>
		                                            <tr style="display:none;">
		                                                <td style="width: 30%">
		                                                    Fecha de entrega del informe financiero</td>
		                                                <td style="width: 70%">
		                                                    <asp:UpdatePanel ID="updpFechaInfFinPETAdd" runat="server">
		                                                        <ContentTemplate>
		                                                            <ews:DatePicker ID="dtpkFechaInfFinPETAdd" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" DateValue="01/01/1900"  />
		                                                            <%--<asp:RequiredFieldValidator ID="rfvFechaInfFinPETAdd" runat="server" ControlToValidate="dtpkFechaInfFinPETAdd"
		                                                                ErrorMessage="Fecha de entrega del informe financiero es requerida" ForeColor=""
		                                                                ToolTip="Fecha de entrega del informe financiero es requerida">x</asp:RequiredFieldValidator>
		                                                            <asp:RegularExpressionValidator ID="revFechaInfFinPETAdd" runat="server" ControlToValidate="dtpkFechaInfFinPETAdd"
		                                                                ErrorMessage="Formato de fecha de entrega del informe financiero debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                ToolTip="Formato de fecha de entrega del informe financiero debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>--%>
		                                                        </ContentTemplate>
		                                                    </asp:UpdatePanel>
		                                                </td>
		                                            </tr>
		                                            <tr>
		                                                <td style="width: 30%">
		                                                    Monto por etapa</td>
		                                                <td style="width: 70%">
		                                                    <asp:TextBox ID="txtMontoMinPETAdd" runat="server">0.00</asp:TextBox><asp:RequiredFieldValidator
		                                                        ID="rfvMontoMinPETAdd" runat="server" ControlToValidate="txtMontoMinPETAdd" ErrorMessage="Monto por etapa es un dato requerido"
		                                                        ForeColor="" ToolTip="Monto por etapa es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                            ID="revMontoMinPETAdd" runat="server" ControlToValidate="txtMontoMinPETAdd" ErrorMessage="Monto por etapa tiene caracteres no permitidos"
		                                                            ForeColor="" ToolTip="Monto por etapa tiene caracteres no permitidos"
		                                                            ValidationExpression="^[0-9]{0,}[.]{0,}[0-9]{0,}$">x</asp:RegularExpressionValidator></td>
		                                            </tr>
		                                            <tr style="display:none;">
		                                                <td style="width: 30%">
		                                                    Fecha programada de pago</td>
		                                                <td style="width: 70%">
		                                                    <asp:UpdatePanel ID="updpFechaProgPETAdd" runat="server">
		                                                        <ContentTemplate>
		                                                            <ews:DatePicker ID="dtpkFechaProgPETAdd" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif"  DateValue="01/01/1900" />
		                                                            <%--<asp:RequiredFieldValidator ID="rfvFechaProgPETAdd" runat="server" ControlToValidate="dtpkFechaProgPETAdd"
		                                                                ErrorMessage="Fecha programada de pago es requerida" ForeColor="" ToolTip="Fecha programada de pago es requerida">x</asp:RequiredFieldValidator>
		                                                            <asp:RegularExpressionValidator ID="revFechaProgPETAdd" runat="server" ControlToValidate="dtpkFechaProgPETAdd"
		                                                                ErrorMessage="Formato de fecha programada de pago debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                ToolTip="Formato de fecha programada de pago debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>--%>
		                                                        </ContentTemplate>
		                                                    </asp:UpdatePanel>
		                                                </td>
		                                            </tr>
		                                            <tr style="display:none;">
		                                                <td style="width: 30%">
		                                                    Fecha de la factura</td>
		                                                <td style="width: 70%">
		                                                    <asp:UpdatePanel ID="updpFechaFactPETAdd" runat="server">
		                                                        <ContentTemplate>
		                                                            <ews:DatePicker ID="dtpkFechaFactPETAdd" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif"  DateValue="01/01/1900" />
		                                                            <%--<asp:RequiredFieldValidator ID="rfvFechaFactPETAdd" runat="server" ControlToValidate="dtpkFechaFactPETAdd"
		                                                                ErrorMessage="Fecha de la factura es requerida" ForeColor="" ToolTip="Fecha de la factura es requerida">x</asp:RequiredFieldValidator>
		                                                            <asp:RegularExpressionValidator ID="revFechaFactPETAdd" runat="server" ControlToValidate="dtpkFechaFactPETAdd"
		                                                                ErrorMessage="Formato de fecha de la factura debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                ToolTip="Formato de fecha de la factura debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>--%>
		                                                        </ContentTemplate>
		                                                    </asp:UpdatePanel>
		                                                </td>
		                                            </tr>
		                                            <tr style="display:none;">
		                                                <td style="width: 30%">
		                                                    Fecha real de pago</td>
		                                                <td style="width: 70%">
		                                                    <asp:UpdatePanel ID="updpFechaRealPETAdd" runat="server">
		                                                        <ContentTemplate>
		                                                            <ews:DatePicker ID="dtpkFechaRealPETAdd" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif"  DateValue="01/01/1900" />
		                                                            <%--<asp:RequiredFieldValidator ID="rfvFechaRealPETAdd" runat="server" ControlToValidate="dtpkFechaRealPETAdd"
		                                                                ErrorMessage="Fecha real de pago es requerida" ForeColor="" ToolTip="Fecha real de pago es requerida">x</asp:RequiredFieldValidator>
		                                                            <asp:RegularExpressionValidator ID="revFechaRealPETAdd" runat="server" ControlToValidate="dtpkFechaRealPETAdd"
		                                                                ErrorMessage="Formato de fecha real de pago debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                ToolTip="Formato de fecha real de pago debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>--%>
		                                                        </ContentTemplate>
		                                                    </asp:UpdatePanel>
		                                                </td>
		                                            </tr>
		                                            <tr style="display:none;">
		                                                <td style="width: 30%">
		                                                    Fecha del informe técnico</td>
		                                                <td style="width: 70%">
		                                                    <asp:UpdatePanel ID="updpFechaInfTecPETAdd" runat="server">
		                                                        <ContentTemplate>
		                                                            <ews:DatePicker ID="dtpkFechaInfTecPETAdd" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif"  DateValue="01/01/1900" />
		                                                            <%--<asp:RequiredFieldValidator ID="rfvFechaInfTecPETAdd" runat="server" ControlToValidate="dtpkFechaInfTecPETAdd"
		                                                                ErrorMessage="Fecha del informe técnico es requerida" ForeColor="" ToolTip="Fecha del informe técnico es requerida">x</asp:RequiredFieldValidator>
		                                                            <asp:RegularExpressionValidator ID="revFechaInfTecPETAdd" runat="server" ControlToValidate="dtpkFechaInfTecPETAdd"
		                                                                ErrorMessage="Formato de fecha del informe técnico debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                ToolTip="Formato de fecha del informe técnico debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>--%>
		                                                        </ContentTemplate>
		                                                    </asp:UpdatePanel>
		                                                </td>
		                                            </tr>
		                                            <tr>
		                                                <td style="width: 30%">
		                                                    Porcentaje de avance (%)</td>
		                                                <td style="width: 70%">
		                                                    <asp:TextBox ID="txtNumProrrogaPETAdd" runat="server">0</asp:TextBox><asp:RequiredFieldValidator
		                                                        ID="rfvNumProrrogaPETAdd" runat="server" ControlToValidate="txtNumProrrogaPETAdd"
		                                                        ErrorMessage="Número de proroga es un dato requerido" ForeColor="" ToolTip="Número de proroga es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                        ID="revNumProrrogaPETAdd" runat="server" ControlToValidate="txtNumProrrogaPETAdd"
		                                                        ErrorMessage="Porcentaje de avance tiene caracteres no permitidos" ForeColor=""
		                                                        ToolTip="Porcentaje de avance tiene caracteres no permitidos" ValidationExpression="^[0-9]{0,}[.]{0,}[0-9]{0,}$">x</asp:RegularExpressionValidator>
		                                                </td>
		                                            </tr>
		                                            <tr>
		                                                <td style="width: 30%">
		                                                    Observaciones</td>
		                                                <td style="width: 70%">
		                                                    <asp:TextBox ID="txtObservacionesPETAdd" runat="server" MaxLength="1000" Rows="5"
		                                                        TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
		                                                            ID="revObservacionesPETAdd" runat="server" ControlToValidate="txtObservacionesPETAdd"
		                                                            ErrorMessage="Observaciones tiene caracteres no permitidos" ForeColor="" ToolTip="Observaciones tiene caracteres no permitidos"
		                                                            ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                            </tr>
		                                            <tr>
		                                                <td style="width: 30%">
		                                                </td>
		                                                <td style="width: 70%">
		                                                    <asp:ValidationSummary ID="vsEtapasPETAdd" runat="server" DisplayMode="List" ForeColor="" />
		                                                </td>
		                                            </tr>
		                                            <tr>
		                                                <td style="width: 30%">
		                                                </td>
		                                                <td style="width: 70%">
		                                                    <asp:ImageButton ID="ibtnGuardarPETAdd" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" OnClick="ibtnGuardarPETAdd_Click" />
		                                                    <asp:ImageButton ID="ibtnCancelarPETAdd" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" OnClick="ibtnCancelarPETAdd_Click" /></td>
		                                            </tr>
		                                        </table>
		                                    </asp:Panel>
		                                    
		                                    <asp:DataList ID="dtlEtapasPET" runat="server" DataKeyField="CveEtapa" DataSourceID="odsEtapasPET" Width="100%" OnCancelCommand="dtlEtapasPET_CancelCommand" OnDeleteCommand="dtlEtapasPET_DeleteCommand" OnEditCommand="dtlEtapasPET_EditCommand" OnSelectedIndexChanged="dtlEtapasPET_SelectedIndexChanged" OnUpdateCommand="dtlEtapasPET_UpdateCommand" OnItemDataBound="dtlEtapasPET_ItemDataBound">
		                                        <ItemStyle CssClass="tablaComun" />
		                                        <AlternatingItemStyle CssClass="tablaAlternatigTemplate" />
		                                        <ItemTemplate>
		                                            <table border="0" cellpadding="3" cellspacing="0" width="100%">
		                                                <tr>
		                                                    <td style="width: 16%">
		                                                        <asp:ImageButton ID="ibtnEditarPETItm" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                    <td style="width: 16%" align="right">
		                                                        &nbsp;<asp:LinkButton ID="lnkbNumEtapaPETItm" runat="server" CommandName="Select"
		                                                            Text='<%# Eval("NumEtapa") %>'></asp:LinkButton></td>
		                                                    <td style="width: 52%">
		                                                        <asp:Label ID="lblDescripcionPETItm" runat="server" Text='<%# Eval("DescEtapa") %>'></asp:Label></td>
		                                                    <td style="width: 16%">
		                                                        <asp:ImageButton ID="ibtnEliminarPETItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                </tr>
		                                            </table>
		                                        </ItemTemplate>
		                                        <EditItemTemplate>
		                                            <table cellpadding="0" cellspacing="0" class="seccionPestanas" style="width: 100%">
		                                            <tr>
		                                                <td style="width: 144px; height: 24px">
		                                                    <asp:ImageButton ID="ibtnProyectoEtapaPEPEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_et_sel.gif"
		                                                        PostBackUrl="~/RegistroProyectos.aspx" OnClick="ibtnProyectoEtapaPEPEdt_Click" /></td>
		                                                <td style="width: 144px; height: 24px">
		                                                    <asp:ImageButton ID="ibtnProyectoEtapaProductoPEPEdt" runat="server" ImageUrl="~/images/aplicacion/pestana_ep_rep.gif"
		                                                        PostBackUrl="~/RegistroProyectos.aspx" OnClick="ibtnProyectoEtapaProductoPEPEdt_Click" /></td>
		                                                <td style="width: 144px; height: 24px">&nbsp;
		                                                    </td>
		                                                <td style="width: 144px; height: 24px">&nbsp;
		                                                    </td>
		                                                <td align="left" style="width: 224px; height: 24px">&nbsp;
		                                                    </td>
		                                            </tr>
		                                            </table>
		                                            <asp:MultiView ID="mviewEtapaProductoPEP" runat="server" ActiveViewIndex="0">
		                                                <asp:View ID="viewEtapaPEP" runat="server">
		                                            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Etapa número</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtNumEtapaPETEdt" runat="server" Text='<%# Eval("NumEtapa") %>'></asp:TextBox><asp:RequiredFieldValidator
		                                                            ID="rfvNumEtapaPETEdt" runat="server" ControlToValidate="txtNumEtapaPETEdt" ErrorMessage="Etapa número es un dato requerido"
		                                                            ForeColor="" ToolTip="Etapa número es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                ID="revNumEtapaPETEdt" runat="server" ControlToValidate="txtNumEtapaPETEdt" ErrorMessage="Etapa número tiene caracteres no permitidos"
		                                                                ForeColor="" ToolTip="Etapa número tiene caracteres no permitidos" ValidationExpression="^[0-9]{1,}$">x</asp:RegularExpressionValidator><asp:CustomValidator
		                                                                    ID="cuvNumEtapaPETEdt" runat="server" ControlToValidate="txtNumEtapaPETEdt" ForeColor="">x</asp:CustomValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Descripción de la etapa</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtDescEtapaPETEdt" runat="server" MaxLength="255" Rows="5" Text='<%# Eval("DescEtapa") %>'
		                                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvDescEtapaPETEdt"
		                                                                runat="server" ControlToValidate="txtDescEtapaPETEdt" ErrorMessage="Descripción de la etapa es un dato requerido"
		                                                                ForeColor="" ToolTip="Descripción de la etapa es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                    ID="revDescEtapaPETEdt" runat="server" ControlToValidate="txtDescEtapaPETEdt"
		                                                                    ErrorMessage="Descripción de la etapa tiene caracteres no permitidos" ForeColor=""
		                                                                    ToolTip="Descripción de la etapa tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                </tr>
		                                                <%--el Polo oculta--%>
		                                                <tr style="display:none;">
		                                                    <td style="width: 30%">
		                                                        Descripción de la meta</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtDescMetaPETEdt" runat="server" MaxLength="255" Rows="5" Text='<%# Eval("DescMeta") %>'
		                                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
		                                                                ID="revDescMetaPETEdt" runat="server" ControlToValidate="txtDescMetaPETEdt" ErrorMessage="Descripción de la meta tiene caracteres no permitidos"
		                                                                ForeColor="" ToolTip="Descripción de la meta tiene caracteres no permitidos"
		                                                                ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Descripción de las actividades</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtActividadesPETEdt" runat="server" MaxLength="1000" Rows="5" Text='<%# Eval("Actividades") %>'
		                                                            TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
		                                                                ID="revActividadesPETEdt" runat="server" ControlToValidate="txtActividadesPETEdt"
		                                                                ErrorMessage="Actividades de la meta tiene caracteres no permitidos" ForeColor=""
		                                                                ToolTip="Actividades tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Fecha de inicio</td>
		                                                    <td style="width: 70%">
		                                                        <asp:UpdatePanel ID="updpFechaInicioPETEdt" runat="server">
		                                                            <ContentTemplate>
		                                                                <ews:DatePicker ID="dtpkFechaInicioPETEdt" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" DateValue='<%# Eval("FechaInicio") %>'  />
		                                                                <asp:RequiredFieldValidator ID="rfvFechaInicioPETEdt" runat="server" ControlToValidate="dtpkFechaInicioPETEdt"
		                                                                    ErrorMessage="Fecha de inicio es requerida" ForeColor="" ToolTip="Fecha de inicio es requerida">x</asp:RequiredFieldValidator>
		                                                                <asp:RegularExpressionValidator ID="revFechaInicioPETEdt" runat="server" ControlToValidate="dtpkFechaInicioPETEdt"
		                                                                    ErrorMessage="Formato de fecha de inicio debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                    ToolTip="Formato de fecha de inicio debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
		                                                            </ContentTemplate>
		                                                        </asp:UpdatePanel>
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Fecha de terminación</td>
		                                                    <td style="width: 70%">
		                                                        <asp:UpdatePanel ID="updpFechaTermPETEdt" runat="server">
		                                                            <ContentTemplate>
		                                                                <ews:DatePicker ID="dtpkFechaTermPETEdt" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" DateValue='<%# Eval("FechaTermino") %>'  />
		                                                                <asp:RequiredFieldValidator ID="rfvFechaTermPETEdt" runat="server" ControlToValidate="dtpkFechaTermPETEdt"
		                                                                    ErrorMessage="Fecha de terminación es requerida" ForeColor="" ToolTip="Fecha de terminación es requerida">x</asp:RequiredFieldValidator>
		                                                                <asp:RegularExpressionValidator ID="revFechaTermPETEdt" runat="server" ControlToValidate="dtpkFechaTermPETEdt"
		                                                                    ErrorMessage="Formato de fecha de terminación debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                    ToolTip="Formato de fecha de terminación debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
		                                                            </ContentTemplate>
		                                                        </asp:UpdatePanel>
		                                                    </td>
		                                                </tr>
		                                                <tr style="display:none;">
		                                                    <td style="width: 30%">
		                                                        Fecha de entrega del informe financiero (editar)</td>
		                                                    <td style="width: 70%">
		                                                        <asp:UpdatePanel ID="updpFechaInfFinPETEdt" runat="server">
		                                                            <ContentTemplate>
		                                                                <ews:DatePicker ID="dtpkFechaInfFinPETEdt" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" DateValue='<%# Eval("FechaEntInfFinan") %>'  />
		                                                                <%--<asp:RequiredFieldValidator ID="rfvFechaInfFinPETEdt" runat="server" ControlToValidate="dtpkFechaInfFinPETEdt"
		                                                                    ErrorMessage="Fecha de entrega del informe financiero es requerida" ForeColor=""
		                                                                    ToolTip="Fecha de entrega del informe financiero es requerida">x</asp:RequiredFieldValidator>
		                                                                <asp:RegularExpressionValidator ID="revFechaInfFinPETEdt" runat="server" ControlToValidate="dtpkFechaInfFinPETEdt"
		                                                                    ErrorMessage="Formato de fecha de entrega del informe financiero debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                    ToolTip="Formato de fecha de entrega del informe financiero debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>--%>
		                                                            </ContentTemplate>
		                                                        </asp:UpdatePanel>
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Monto por etapa</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtMontoMinPETEdt" runat="server" Text='<%# Eval("MontoMinistraciones", "{0}") %>'></asp:TextBox><asp:RequiredFieldValidator
		                                                            ID="rfvMontoMinPETEdt" runat="server" ControlToValidate="txtMontoMinPETEdt" ErrorMessage="Monto por etapa es un dato requerido"
		                                                            ForeColor="" ToolTip="Monto por etapa es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                ID="revMontoMinPETEdt" runat="server" ControlToValidate="txtMontoMinPETEdt" ErrorMessage="Monto por etapa tiene caracteres no permitidos"
		                                                                ForeColor="" ToolTip="Monto por etapa tiene caracteres no permitidos"
		                                                                ValidationExpression="^[0-9.]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                </tr>
		                                                <tr style="display:none;">
		                                                    <td style="width: 30%">
		                                                        Fecha programada de pago</td>
		                                                    <td style="width: 70%">
		                                                        <asp:UpdatePanel ID="updpFechaProgPETEdt" runat="server">
		                                                            <ContentTemplate>
		                                                                <ews:DatePicker ID="dtpkFechaProgPETEdt" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" DateValue='<%# Eval("FechaProgPago") %>'  />
		                                                                <%--<asp:RequiredFieldValidator ID="rfvFechaProgPETEdt" runat="server" ControlToValidate="dtpkFechaProgPETEdt"
		                                                                    ErrorMessage="Fecha programada de pago es requerida" ForeColor="" ToolTip="Fecha programada de pago es requerida">x</asp:RequiredFieldValidator>
		                                                                <asp:RegularExpressionValidator ID="revFechaProgPETEdt" runat="server" ControlToValidate="dtpkFechaProgPETEdt"
		                                                                    ErrorMessage="Formato de fecha programada de pago debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                    ToolTip="Formato de fecha programada de pago debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>--%>
		                                                            </ContentTemplate>
		                                                        </asp:UpdatePanel>
		                                                    </td>
		                                                </tr>
		                                                <tr style="display:none;">
		                                                    <td style="width: 30%">
		                                                        Fecha de la factura</td>
		                                                    <td style="width: 70%">
		                                                        <asp:UpdatePanel ID="updpFechaFactPETEdt" runat="server">
		                                                            <ContentTemplate>
		                                                                <ews:DatePicker ID="dtpkFechaFactPETEdt" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" DateValue='<%# Eval("FechaFactura") %>'  />
		                                                                <%--<asp:RequiredFieldValidator ID="rfvFechaFactPETEdt" runat="server" ControlToValidate="dtpkFechaFactPETEdt"
		                                                                    ErrorMessage="Fecha de la factura es requerida" ForeColor="" ToolTip="Fecha de la factura es requerida">x</asp:RequiredFieldValidator>
		                                                                <asp:RegularExpressionValidator ID="revFechaFactPETEdt" runat="server" ControlToValidate="dtpkFechaFactPETEdt"
		                                                                    ErrorMessage="Formato de fecha de la factura debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                    ToolTip="Formato de fecha de la factura debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>--%>
		                                                            </ContentTemplate>
		                                                        </asp:UpdatePanel>
		                                                    </td>
		                                                </tr>
		                                                <tr style="display:none;">
		                                                    <td style="width: 30%">
		                                                        Fecha real de pago</td>
		                                                    <td style="width: 70%">
		                                                        <asp:UpdatePanel ID="updpFechaRealPETEdt" runat="server">
		                                                            <ContentTemplate>
		                                                                <ews:DatePicker ID="dtpkFechaRealPETEdt" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" DateValue='<%# Eval("FechaRealPago") %>'  />
		                                                                <%--<asp:RequiredFieldValidator ID="rfvFechaRealPETEdt" runat="server" ControlToValidate="dtpkFechaRealPETEdt"
		                                                                    ErrorMessage="Fecha real de pago es requerida" ForeColor="" ToolTip="Fecha real de pago es requerida">x</asp:RequiredFieldValidator>
		                                                                <asp:RegularExpressionValidator ID="revFechaRealPETEdt" runat="server" ControlToValidate="dtpkFechaRealPETEdt"
		                                                                    ErrorMessage="Formato de fecha real de pago debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                    ToolTip="Formato de fecha real de pago debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>--%>
		                                                            </ContentTemplate>
		                                                        </asp:UpdatePanel>
		                                                    </td>
		                                                </tr>
		                                                <tr style="display:none;">
		                                                    <td style="width: 30%">
		                                                        Fecha del informe técnico</td>
		                                                    <td style="width: 70%">
		                                                        <asp:UpdatePanel ID="updpFechaInfTecPETEdt" runat="server">
		                                                            <ContentTemplate>
		                                                                <ews:DatePicker ID="dtpkFechaInfTecPETEdt" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" DateValue='<%# Eval("FechaInfoTecnico") %>'  />
		                                                                <%--<asp:RequiredFieldValidator ID="rfvFechaInfTecPETEdt" runat="server" ControlToValidate="dtpkFechaInfTecPETEdt"
		                                                                    ErrorMessage="Fecha del informe técnico es requerida" ForeColor="" ToolTip="Fecha del informe técnico es requerida">x</asp:RequiredFieldValidator>
		                                                                <asp:RegularExpressionValidator ID="revFechaInfTecPETEdt" runat="server" ControlToValidate="dtpkFechaInfTecPETEdt"
		                                                                    ErrorMessage="Formato de fecha del informe técnico debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                    ToolTip="Formato de fecha del informe técnico debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>--%>
		                                                            </ContentTemplate>
		                                                        </asp:UpdatePanel>
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Porcentaje de avance (%)</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtNumProrrogaPETEdt" runat="server" Text='<%# Eval("NumProrroga") %>'></asp:TextBox><asp:RequiredFieldValidator
		                                                            ID="rfvNumProrrogaPETEdt" runat="server" ControlToValidate="txtNumProrrogaPETEdt"
		                                                            ErrorMessage="Porcentaje de avance es un dato requerido" ForeColor="" ToolTip="Número de proroga es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                            ID="revNumProrrogaPETEdt" runat="server" ControlToValidate="txtNumProrrogaPETEdt"
		                                                            ErrorMessage="Porcentaje de avance tiene caracteres no permitidos" ForeColor=""
		                                                            ToolTip="Porcentaje de avance tiene caracteres no permitidos" ValidationExpression="^[0-9]{0,}[.]{0,}[0-9]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Observaciones</td>
		                                                    <td style="width: 70%">
		                                                        <asp:TextBox ID="txtObservacionesPETEdt" runat="server" MaxLength="1000" Rows="5"
		                                                            Text='<%# Eval("Observaciones") %>' TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
		                                                                ID="revObservacionesPETEdt" runat="server" ControlToValidate="txtObservacionesPETEdt"
		                                                                ErrorMessage="Observaciones tiene caracteres no permitidos" ForeColor="" ToolTip="Observaciones tiene caracteres no permitidos"
		                                                                ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ValidationSummary ID="vsEtapasPETEdt" runat="server" DisplayMode="List" ForeColor="" />
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ImageButton ID="ibtnGuardarPETEdt" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" CommandName="Update" />
		                                                        <asp:ImageButton ID="ibtnCancelarPETEdt" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" CommandName="Cancel" /></td>
		                                                </tr>
		                                            </table>
		                                                </asp:View>
		                                                <asp:View ID="viewProductoPEP" runat="server">
		                                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
		                                                        <tr>
		                                                            <td colspan="2">&nbsp;
		                                                                
		                                                            </td>
		                                                        </tr>
		                                                        <tr>
		                                                            <th class="thtablaComun" colspan="2" style="height: 19px">
		                                                                Productos</th>
		                                                        </tr>
		                                                        <tr>
		                                                            <td colspan="2">
		                                                                <asp:ImageButton ID="ibtnNuevoPEPAdd" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" OnClick="ibtnNuevoPEPAdd_Click" /></td>
		                                                        </tr>
		                                                        <tr>
		                                                            <td colspan="2">
		                                                                <asp:Panel ID="pnlProyectoEtapaProductoPEPAdd" runat="server" Width="100%" Visible="False">
		                                                                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                                        <%--entra el polo--%>
		                                                                        <%--creando un renglón que muestre el proyecto y etapa, con el fin de detectar errores --%>
		                                                                        <%--MODIFICA EL BORA PARA MOSTRAR LOS DATOS MAS FACILES DE LEER --%>
		                                                                        <tr>
		                                                                            <th colspan="2">
		                                                                                <table>
		                                                                                    <tr>
		                                                                                        <td>Proyecto:</td>
		                                                                                        <td><asp:Label ID="boraCveProyecto" runat="server" Text='<%# Eval("CveProyecto") %>'></asp:Label></td>
		                                                                                    </tr>
		                                                                                    <tr>
		                                                                                        <td>Etapa:</td>
		                                                                                        <td>
		                                                                                            <asp:hiddenfield ID="hdboraCveEtapa" runat="server" value='<%# Eval("CveEtapa") %>'></asp:hiddenfield>
		                                                                                            <asp:Label ID="boraNumEtapa" runat="server" Text='<%# Eval("NumEtapa") %>'></asp:Label><br />
		                                                                                            <asp:Label ID="boraDescEtapa" runat="server" Text='<%# Eval("DescEtapa") %>'></asp:Label>
		                                                                                        </td>
		                                                                                    </tr>
		                                                                                </table>
		                                                                            </th>
		                                                                        </tr>
		                                                                        
		                                                                        <%-- NO ES NECESARIO ,  LUIS RANGEL 2008/02/06
		                                                                        <tr>
		                                                                        <td>&nbsp;</td>
		                                                                        <td>                                                                        
		                                                                            <asp:Label ID="poloCveProyecto" runat="server"></asp:Label> (<asp:Label ID="poloCveEtapa" runat="server"></asp:Label>) 
		                                                                        </td>
		                                                                        </tr>--%>
		                                                                        <%-- Sale el BORA --%>
		                                                                        <%--sale el polo--%>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Producto *
		                                                                            </td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:TextBox ID="txtProductoPEPAdd" runat="server" MaxLength="255" Width="400px"></asp:TextBox><asp:RequiredFieldValidator
		                                                                                    ID="rfvProductoPEPAdd" runat="server" ControlToValidate="txtProductoPEPAdd" EnableTheming="True"
		                                                                                    ErrorMessage="Producto es un dato requerido" ForeColor="" ToolTip="Producto es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                                        ID="revRemitentePAOAdd" runat="server" ControlToValidate="txtProductoPEPAdd"
		                                                                                        ErrorMessage="Producto tiene caracteres no permitidos" ForeColor="" ToolTip="Producto tiene caracteres no permitidos"
		                                                                                        ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><asp:CustomValidator
		                                                                                            ID="cuvProductoPEPAdd" runat="server" ControlToValidate="txtProductoPEPAdd" ForeColor="">x</asp:CustomValidator></td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Tipo de producto *</td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:DropDownList ID="ddlTipoProductoPEPAdd" runat="server" DataSourceID="odsTipoProductoDLL" DataTextField="DesTipoProducto" DataValueField="CveTipoProducto" Width="400px">
		                                                                                </asp:DropDownList>
																					    <!-- entra el Polo -->
																					    <asp:RegularExpressionValidator
		                                                                                    ID="revTipoProductoPEPAdd" 
																						    runat="server" 
																						    ControlToValidate="ddlTipoProductoPEPAdd" 
																						    ErrorMessage="Tipo de Producto es un dato requerido"
		                                                                                    ForeColor="" 
																						    ToolTip="Tipo de Producto es un dato requerido" 
																						    ValidationExpression="^[^\-]*">x
																					    </asp:RegularExpressionValidator><!-- la expresión regular busca que el valor no contenga "-" (LVC) -->
																					    <!-- sale el Polo -->												
																					    <asp:ObjectDataSource ID="odsTipoProductoDLL" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                                    SelectMethod="GetDataTipoProductoDLL" TypeName="dsAppTableAdapters.spTipoProducto_SelectDLLTableAdapter">
		                                                                                </asp:ObjectDataSource>
		                                                                            </td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Título *</td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:TextBox ID="txtTituloPEPAdd" runat="server" MaxLength="255" Width="400px"></asp:TextBox><asp:RequiredFieldValidator
		                                                                                    ID="rfvTituloPEPAdd" runat="server" ControlToValidate="txtTituloPEPAdd" EnableTheming="True"
		                                                                                    ErrorMessage="Título es un dato requerido" ForeColor="" ToolTip="Título es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                                        ID="revTituloPEPAdd" runat="server" ControlToValidate="txtTituloPEPAdd" ErrorMessage="Título tiene caracteres no permitidos"
		                                                                                        ForeColor="" ToolTip="Título tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%; height: 46px;">
		                                                                                Entregado</td>
		                                                                            <td style="width: 70%; height: 46px;">
		                                                                                <asp:CheckBox ID="chkbEntregadoPEPAdd" runat="server" /></td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Fecha de entrega *</td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:UpdatePanel ID="updpFechaEntPEPAdd" runat="server">
		                                                                                    <ContentTemplate>
		                                                                                        <ews:DatePicker ID="dtpkFechaEntPEPAdd" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif"  />
		                                                                                        <asp:RequiredFieldValidator ID="rfvFechaEntPEPAdd" runat="server" ControlToValidate="dtpkFechaEntPEPAdd"
		                                                                                            ErrorMessage="Fecha de entrega es requerida" ForeColor="" ToolTip="Fecha de entrega es requerida">x</asp:RequiredFieldValidator>
		                                                                                        <asp:RegularExpressionValidator ID="revFechaEntPEPAdd" runat="server" ControlToValidate="dtpkFechaEntPEPAdd"
		                                                                                            ErrorMessage="Formato de fecha de entrega debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                                            ToolTip="Formato de fecha de entrega debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
		                                                                                    </ContentTemplate>
		                                                                                </asp:UpdatePanel>
		                                                                            </td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Archivo *</td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:FileUpload ID="flupArchivoPEPAdd_1" runat="server" Width="350px" /><asp:RegularExpressionValidator
		                                                                                    ID="revArchivoPEPAdd_1" runat="server" ControlToValidate="flupArchivoPEPAdd_1" ErrorMessage="Archivo tiene caracteres no permitidos"
		                                                                                    ForeColor="" ToolTip="Archivo tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><asp:CustomValidator
		                                                                                        ID="cuvArchivoPEPAdd_1" runat="server" ControlToValidate="flupArchivoPEPAdd_1" ForeColor="">x</asp:CustomValidator>
		                                                                                <br />
		                                                                                <asp:FileUpload ID="flupArchivoPEPAdd_2" runat="server" Width="350px" />
		                                                                                <asp:RegularExpressionValidator
		                                                                                    ID="revArchivoPEPAdd_2" runat="server" ControlToValidate="flupArchivoPEPAdd_2" ErrorMessage="Archivo tiene caracteres no permitidos"
		                                                                                    ForeColor="" ToolTip="Archivo tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator>
		                                                                                <asp:CustomValidator
		                                                                                    ID="cuvArchivoPEPAdd_2" runat="server" ControlToValidate="flupArchivoPEPAdd_2" ForeColor="">x</asp:CustomValidator>
		                                                                                <br />
		                                                                                <asp:FileUpload ID="flupArchivoPEPAdd_3" runat="server" Width="350px" />
		                                                                                <asp:RegularExpressionValidator
		                                                                                    ID="revArchivoPEPAdd_3" runat="server" ControlToValidate="flupArchivoPEPAdd_3" ErrorMessage="Archivo tiene caracteres no permitidos"
		                                                                                    ForeColor="" ToolTip="Archivo tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator>
		                                                                                <asp:CustomValidator
		                                                                                    ID="cuvArchivoPEPAdd_3" runat="server" ControlToValidate="flupArchivoPEPAdd_3" ForeColor="">x</asp:CustomValidator>
		                                                                                <br />
		                                                                                <br />
		                                                                                <asp:FileUpload ID="flupArchivoPEPAdd_4" runat="server" Width="350px" />
		                                                                                <asp:RegularExpressionValidator
		                                                                                    ID="revArchivoPEPAdd_4" runat="server" ControlToValidate="flupArchivoPEPAdd_4" ErrorMessage="Archivo tiene caracteres no permitidos"
		                                                                                    ForeColor="" ToolTip="Archivo tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator>
		                                                                                <asp:CustomValidator
		                                                                                    ID="cuvArchivoPEPAdd_4" runat="server" ControlToValidate="flupArchivoPEPAdd_4" ForeColor="">x</asp:CustomValidator>
		                                                                                <br />
		                                                                                <br />
		                                                                                <asp:FileUpload ID="flupArchivoPEPAdd_5" runat="server" Width="350px" />
		                                                                                <asp:RegularExpressionValidator
		                                                                                    ID="revArchivoPEPAdd_5" runat="server" ControlToValidate="flupArchivoPEPAdd_5" ErrorMessage="Archivo tiene caracteres no permitidos"
		                                                                                    ForeColor="" ToolTip="Archivo tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator>
		                                                                                <asp:CustomValidator
		                                                                                    ID="cuvArchivoPEPAdd_5" runat="server" ControlToValidate="flupArchivoPEPAdd_5" ForeColor="">x</asp:CustomValidator>
		                                                                                <br />
		                                                                            </td>
		                                                                        </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%">
                                                                                        Palabras Clave</td>
                                                                                    <td style="width: 70%">
                                                                                        <asp:TextBox ID="txtPalabrasClavePEPAdd" runat="server" MaxLength="150" Width="400px"></asp:TextBox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30%">
                                                                                        Descripción Corta:</td>
                                                                                    <td style="width: 70%">
                                                                                        <asp:TextBox ID="txtDescripcionCortaPEPAdd" runat="server" Rows="4" TextMode="MultiLine"
                                                                                            Width="400px"></asp:TextBox></td>
                                                                                </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                            </td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:ValidationSummary ID="vsProductosPEPAdd" runat="server" DisplayMode="List" ForeColor="" />
		                                                                            </td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                            </td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:ImageButton ID="ibtnGuardarPEPAdd" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" OnClick="ibtnGuardarPEPAdd_Click" />
		                                                                                <asp:ImageButton ID="ibtnCancelarPEPAdd" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" OnClick="ibtnCancelarPEPAdd_Click" /></td>
		                                                                        </tr>
		                                                                    </table>
		                                                                </asp:Panel>
		                                                            </td>
		                                                        </tr>
		                                                        <tr>
		                                                            <td colspan="2">
		                                                                <%-- ***** LUIS RANGEL 2008/02/06 ******
		                                                                      Agregamos la clave del proyecto y la 
		                                                                      clave de la Etapa para seguirlas
		                                                                --%>
                                                                        <asp:hiddenfield ID="hdfCveProyecto" runat="server" value='<%# Bind("CveProyecto") %>' />
                                                                        <asp:hiddenfield ID="hdfCveEtapa" runat="server" value='<%# Bind("CveEtapa") %>' />
                                                                        <%-- ******** Fin de LUIS RANGEL ******** --%>
                                                                        
		                                                                <asp:DataList ID="dtlProyectoEtapaProductoPEP" runat="server" DataKeyField="CveProducto" 
		                                                                    DataSourceID="odsProyEtapaProductoPEP" Width="100%" EnableTheming="True" 
		                                                                    OnCancelCommand="dtlProyectoEtapaProductoPEP_CancelCommand" 
		                                                                    OnDeleteCommand="dtlProyectoEtapaProductoPEP_DeleteCommand" 
		                                                                    OnEditCommand="dtlProyectoEtapaProductoPEP_EditCommand" 
		                                                                    OnItemDataBound="dtlProyectoEtapaProductoPEP_ItemDataBound" 
		                                                                    OnSelectedIndexChanged="dtlProyectoEtapaProductoPEP_SelectedIndexChanged" 
		                                                                    OnUpdateCommand="dtlProyectoEtapaProductoPEP_UpdateCommand">
		                                                                    <ItemStyle CssClass="tablaComun" />
		                                                                    <AlternatingItemStyle CssClass="tablaAlternatigTemplate" />
		                                                                    <ItemTemplate>
		                                                                        <table border="0" cellpadding="3" cellspacing="0" width="100%">
		                                                                            <tr>
		                                                                                <td style="width: 16%">
		                                                                                    <asp:ImageButton ID="ibtnEditarPEPItm" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                                                <td style="width: 22%">
		                                                                                    &nbsp;<asp:Label ID="lblTituloPEPItm" runat="server" Text='<%# Eval("Titulo") %>'></asp:Label></td>
		                                                                                <td style="width: 22%">
		                                                                                    <asp:Label ID="lblTipoProductoPEPItm" runat="server" Text='<%# Eval("TipoProducto") %>'></asp:Label></td>
		                                                                                <td style="width: 22%">
		                                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Mid(Eval("DescripcionCorta"),1,40) %>'></asp:Label></td>
		                                                                                <td style="width: 16%">
		                                                                                    <asp:ImageButton ID="ibtnEliminarPEPItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                                            </tr>
		                                                                        </table>
		                                                                    </ItemTemplate>
		                                                                    <EditItemTemplate>
		                                                                        <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Producto</td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:TextBox ID="txtProductoPEPEdt" runat="server" MaxLength="255" Text='<%# Eval("Producto") %>'
		                                                                                    Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvProductoPEPEdt" runat="server"
		                                                                                        ControlToValidate="txtProductoPEPEdt" EnableTheming="True" ErrorMessage="Producto es un dato requerido"
		                                                                                        ForeColor="" ToolTip="Producto es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                                            ID="revProductoPEPEdt" runat="server" ControlToValidate="txtProductoPEPEdt" ErrorMessage="Producto tiene caracteres no permitidos"
		                                                                                            ForeColor="" ToolTip="Producto tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><asp:CustomValidator
		                                                                                                ID="cuvProductoPEPEdt" runat="server" ControlToValidate="txtProductoPEPEdt" ForeColor="">x</asp:CustomValidator></td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Tipo de producto</td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:DropDownList ID="ddlTipoProductoPEPAdd" runat="server" DataSourceID="odsTipoProductoPEPEdt" DataTextField="DesTipoProducto" DataValueField="CveTipoProducto" SelectedValue='<%# Eval("CveTipoProducto") %>'>
		                                                                                </asp:DropDownList><asp:ObjectDataSource ID="odsTipoProductoPEPEdt" runat="server"
		                                                                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataTipoProductoDLL"
		                                                                                    TypeName="dsAppTableAdapters.spTipoProducto_SelectDLLTableAdapter"></asp:ObjectDataSource>
		                                                                            </td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Título</td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:TextBox ID="txtTituloPEPEdt" runat="server" MaxLength="255" Text='<%# Eval("Titulo") %>'
		                                                                                    Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvTituloPEPEdt" runat="server"
		                                                                                        ControlToValidate="txtTituloPEPEdt" EnableTheming="True" ErrorMessage="Título es un dato requerido"
		                                                                                        ForeColor="" ToolTip="Título es un dato requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
		                                                                                            ID="revTituloPEPEdt" runat="server" ControlToValidate="txtTituloPEPEdt" ErrorMessage="Título tiene caracteres no permitidos"
		                                                                                            ForeColor="" ToolTip="Título tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%; height: 46px;">
		                                                                                Entregado</td>
		                                                                            <td style="width: 70%; height: 46px;">
		                                                                                <asp:CheckBox ID="chkbEntregadoPEPEdt" runat="server" Checked='<%# Eval("Entregado") %>' /></td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Fecha de entrega</td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:UpdatePanel ID="updpFechaEntPEPEdt" runat="server">
		                                                                                    <ContentTemplate>
		                                                                                        <ews:DatePicker ID="dtpkFechaEntPEPEdt" runat="server" CalendarPosition="DisplayRight"
		                                                        ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" DateValue='<%# Eval("FechaEntrega") %>'  />
		                                                                                        <asp:RequiredFieldValidator ID="rfvFechaEntPEPEdt" runat="server" ControlToValidate="dtpkFechaEntPEPEdt"
		                                                                                            ErrorMessage="Fecha de entrega es requerida" ForeColor="" ToolTip="Fecha de entrega es requerida">x</asp:RequiredFieldValidator>
		                                                                                        <asp:RegularExpressionValidator ID="revFechaEntPEPEdt" runat="server" ControlToValidate="dtpkFechaEntPEPEdt"
		                                                                                            ErrorMessage="Formato de fecha de entrega debe ser 'dd/mm/aaaa'" ForeColor=""
		                                                                                            ToolTip="Formato de fecha de entrega debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
		                                                                                    </ContentTemplate>
		                                                                                </asp:UpdatePanel>
		                                                                            </td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                                Archivo</td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:Label ID="lblArchivoPEPEdt" runat="server" Text='<%# Eval("Ubicacion") %>'></asp:Label></td>
		                                                                        </tr>
                                                                                    <tr>
                                                                                        <td style="width: 30%">
                                                                                            Palabras Clave</td>
                                                                                        <td style="width: 70%">
                                                                                            <asp:TextBox ID="txtPalabrasClavePEPEdt" runat="server" MaxLength="150" Text='<%# Eval("PalabrasClave") %>'
                                                                                                Width="400px"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 30%">
                                                                                            Descripción corta</td>
                                                                                        <td style="width: 70%">
                                                                                            <asp:TextBox ID="txtDescripcionCortaPEPEdt" runat="server" Rows="4" Text='<%# Eval("DescripcionCorta") %>'
                                                                                                TextMode="MultiLine" Width="400px"></asp:TextBox></td>
                                                                                    </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                            </td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:ValidationSummary ID="vsProductosPEPEdt" runat="server" DisplayMode="List" ForeColor="" />
		                                                                            </td>
		                                                                        </tr>
		                                                                        <tr>
		                                                                            <td style="width: 30%">
		                                                                            </td>
		                                                                            <td style="width: 70%">
		                                                                                <asp:ImageButton ID="ibtnGuardarPEPEdt" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" CommandName="Update" />
		                                                                                <asp:ImageButton ID="ibtnCancelarPEPEdt" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" CommandName="Cancel" /></td>
		                                                                        </tr>
		                                                                    </table>
		                                                                    </EditItemTemplate>
		                                                                    <HeaderTemplate>
		                                                                        <table border="0" cellpadding="3" cellspacing="0" class="tablaHeaderTemplate" width="100%">
		                                                                            <tr>
		                                                                                <th style="width: 16%">&nbsp;</th>
		                                                                                <th style="width: 22%">Título</th>
		                                                                                <th style="width: 22%">Tipo de producto</th>
		                                                                                <th style="width: 22%">Descripción corta</th>
		                                                                                <th style="width: 16%">&nbsp;</th>
		                                                                            </tr>
		                                                                        </table>
		                                                                    </HeaderTemplate>
		                                                                    <SelectedItemTemplate>
		                                                                        <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                                            <tr>
		                                                                                <td style="width: 30%">
		                                                                                    Producto</td>
		                                                                                <td style="width: 70%">
		                                                                                    <asp:Label ID="lblProductoPEPSel" runat="server" Text='<%# Eval("Producto") %>'></asp:Label></td>
		                                                                            </tr>
		                                                                            <tr>
		                                                                                <td style="width: 30%">
		                                                                                    Tipo de producto</td>
		                                                                                <td style="width: 70%">
		                                                                                    <asp:Label ID="lblTipoProductoPEPSel" runat="server" Text='<%# Eval("TipoProducto") %>'></asp:Label></td>
		                                                                            </tr>
		                                                                            <tr>
		                                                                                <td style="width: 30%">
		                                                                                    Título</td>
		                                                                                <td style="width: 70%">
		                                                                                    <asp:Label ID="lblTituloPEPSel" runat="server" Text='<%# Eval("Titulo") %>'></asp:Label></td>
		                                                                            </tr>
		                                                                            <tr>
		                                                                                <td style="width: 30%">
		                                                                                    Entregado</td>
		                                                                                <td style="width: 70%">
		                                                                                    <asp:CheckBox ID="chkbEntregadoPEPSel" runat="server" Checked='<%# Eval("Entregado") %>'
		                                                                                        Enabled="False" /></td>
		                                                                            </tr>
		                                                                            <tr>
		                                                                                <td style="width: 30%">
		                                                                                    Fecha de entrega</td>
		                                                                                <td style="width: 70%">
		                                                                                    <asp:Label ID="lblFechaEntregaPEPSel" runat="server" Text='<%# Eval("FechaEntrega", "{0:d}") %>'></asp:Label></td>
		                                                                            </tr>
		                                                                            <tr>
		                                                                                <td style="width: 30%">
		                                                                                    Archivo</td>
		                                                                                <td style="width: 70%">
		                                                                                    <asp:Label ID="lblArchivoPEPSel" runat="server" Text='<%# Eval("Ubicacion") %>'></asp:Label></td>
		                                                                            </tr>
		                                                                            <tr>
		                                                                                <td colspan="2">&nbsp;
		                                                                                    </td>
		                                                                            </tr>
		                                                                            <tr>
		                                                                                <td style="width: 30%">
		                                                                                </td>
		                                                                                <td style="width: 70%">
		                                                                                    <asp:ImageButton ID="ibtnRegresarPEPSel" runat="server" ImageUrl="~/images/aplicacion/btnRegresar.gif" CommandName="Cancel" />
		                                                                                </td>
		                                                                            </tr>
		                                                                        </table>
		                                                                    </SelectedItemTemplate>
		                                                                </asp:DataList>
		                                                                <asp:ObjectDataSource ID="odsProyEtapaProductoPEP" runat="server" OldValuesParameterFormatString="original_{0}"
		                                            SelectMethod="GetDataByCveProyectoYCveEtapa" TypeName="dsAppTableAdapters.EtapaProductosTableAdapter" DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
		                                                                    <SelectParameters>
                                                                                <asp:ControlParameter ControlID="hdfCveProyecto" Name="CveProyecto" PropertyName="Value"
                                                                                    Type="String" />
                                                                                <asp:ControlParameter ControlID="hdfCveEtapa" Name="CveEtapa" PropertyName="Value"
                                                                                    Type="Int32" />
		                                                                    </SelectParameters>
                                                                            <DeleteParameters>
                                                                                <asp:Parameter Name="Original_CveEtapa" Type="Int32" />
                                                                                <asp:Parameter Name="Original_CveProyecto" Type="String" />
                                                                                <asp:Parameter Name="Original_CveProducto" Type="Int32" />
                                                                            </DeleteParameters>
                                                                            <UpdateParameters>
                                                                                <asp:Parameter Name="Producto" Type="String" />
                                                                                <asp:Parameter Name="Titulo" Type="String" />
                                                                                <asp:Parameter Name="Entregado" Type="Boolean" />
                                                                                <asp:Parameter Name="FechaEntrega" Type="DateTime" />
                                                                                <asp:Parameter Name="CveTipoProducto" Type="Int32" />
                                                                                <asp:Parameter Name="Ubicacion" Type="String" />
                                                                                <asp:Parameter Name="Original_CveEtapa" Type="Int32" />
                                                                                <asp:Parameter Name="Original_CveProyecto" Type="String" />
                                                                                <asp:Parameter Name="Original_CveProducto" Type="Int32" />
                                                                            </UpdateParameters>
                                                                            <InsertParameters>
                                                                                <asp:Parameter Name="CveEtapa" Type="Int32" />
                                                                                <asp:Parameter Name="CveProyecto" Type="String" />
                                                                                <asp:Parameter Name="CveProducto" Type="Int32" />
                                                                                <asp:Parameter Name="Producto" Type="String" />
                                                                                <asp:Parameter Name="Titulo" Type="String" />
                                                                                <asp:Parameter Name="Entregado" Type="Boolean" />
                                                                                <asp:Parameter Name="FechaEntrega" Type="DateTime" />
                                                                                <asp:Parameter Name="CveTipoProducto" Type="Int32" />
                                                                                <asp:Parameter Name="Ubicacion" Type="String" />
                                                                            </InsertParameters>
		                                                                </asp:ObjectDataSource>
		                                                            </td>
		                                                        </tr>
		                                                        <tr>
		                                                            <td colspan="2">
		                                                            </td>
		                                                        </tr>
		                                                    </table>
		                                                </asp:View>
		                                            </asp:MultiView>
		                                        </EditItemTemplate>
		                                        <HeaderTemplate>
		                                            <table border="0" cellpadding="3" cellspacing="0" class="tablaHeaderTemplate" width="100%">
		                                                <tr>
		                                                    <th style="width: 16%">&nbsp;
		                                                        </th>
		                                                    <th style="width: 16%">
		                                                        Etapa número</th>
		                                                    <th style="width: 52%">
		                                                        Descripción</th>
		                                                    <th style="width: 16%">&nbsp;
		                                                        </th>
		                                                </tr>
		                                            </table>
		                                        </HeaderTemplate>
		                                        <SelectedItemTemplate>
		                                            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Etapa número</td>
		                                                    <td style="width: 70%">
		                                                        <asp:Label ID="lblNumEtapaPETSel" runat="server" Text='<%# Eval("NumEtapa") %>'></asp:Label></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Descripción de la etapa</td>
		                                                    <td style="width: 70%">
		                                                        <asp:Label ID="lblDescEtapaPETSel" runat="server" Text='<%# Eval("DescEtapa") %>'></asp:Label></td>
		                                                </tr>
		                                                <%--el Polo oculta--%>
		                                                <tr style="display:none;">
		                                                    <td style="width: 30%">
		                                                        Descripción de la meta</td>
		                                                    <td style="width: 70%">
		                                                        <asp:Label ID="lblDescMetaPETSel" runat="server" Text='<%# Eval("DescMeta") %>'></asp:Label></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Descripción de las actividades</td>
		                                                    <td style="width: 70%">
		                                                        <asp:Label ID="lblActividadesPETSel" runat="server" Text='<%# Eval("Actividades") %>'></asp:Label></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Fecha de inicio</td>
		                                                    <td style="width: 70%">
		                                                        <asp:Label ID="lblFechaInicioPETSel" runat="server" Text='<%# Eval("FechaInicio", "{0:d}") %>'></asp:Label></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Fecha de terminación</td>
		                                                    <td style="width: 70%">
		                                                        <asp:Label ID="lblFechaTermPETSel" runat="server" Text='<%# Eval("FechaTermino", "{0:d}") %>'></asp:Label></td>
		                                                </tr>
		                                                <tr style="display:none;">
		                                                    <td style="width: 30%">
		                                                        Fecha de entrega del informe financiero</td>
		                                                    <td style="width: 70%">
		                                                        <asp:Label ID="lblFechaInfFinPETSel" runat="server" Text='<%# Eval("FechaEntInfFinan", "{0:d}") %>'></asp:Label></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Monto por etapa</td>
		                                                    <td style="width: 70%">
		                                                        <asp:Label ID="lblMontoMinPETSel" runat="server" Text='<%# Eval("MontoMinistraciones", "{0:C}") %>'></asp:Label></td>
		                                                </tr>
		                                                <tr style="display:none;">
		                                                    <td style="width: 30%">
		                                                        Fecha programada de pago</td>
		                                                    <td style="width: 70%">
		                                                        <asp:Label ID="lblFechaProgPETSel" runat="server" Text='<%# Eval("FechaProgPago", "{0:d}") %>'></asp:Label></td>
		                                                </tr>
		                                                <tr style="display:none;">
		                                                    <td style="width: 30%">
		                                                        Fecha de la factura</td>
		                                                    <td style="width: 70%">
		                                                        <asp:Label ID="lblFechaFactPETSel" runat="server" Text='<%# Eval("FechaFactura", "{0:d}") %>'></asp:Label></td>
		                                                </tr>
		                                                <tr style="display:none;">
		                                                    <td style="width: 30%">
		                                                        Fecha real de pago</td>
		                                                    <td style="width: 70%">
		                                                        <asp:Label ID="lblFechaRealPETSet" runat="server" Text='<%# Eval("FechaRealPago", "{0:d}") %>'></asp:Label></td>
		                                                </tr>
		                                                <tr style="display:none;">
		                                                    <td style="width: 30%">
		                                                        Fecha del informe técnico</td>
		                                                    <td style="width: 70%">
		                                                        <asp:Label ID="lblFechaInfTecPETSel" runat="server" Text='<%# Eval("FechaInfoTecnico", "{0:d}") %>'></asp:Label></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Porcentaje de avance (%)</td>
		                                                    <td style="width: 70%">
		                                                        <asp:Label ID="lblNumProrrogaPETSel" runat="server" Text='<%# Eval("NumProrroga") %>'></asp:Label></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                        Observaciones</td>
		                                                    <td style="width: 70%">
		                                                        <asp:Label ID="lblObservacionesPETSel" runat="server" Text='<%# Eval("Observaciones") %>'></asp:Label></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ImageButton ID="ibtnRegresarPETSel" runat="server" ImageUrl="~/images/aplicacion/btnRegresar.gif" CommandName="Cancel" />
		                                                    </td>
		                                                </tr>
		                                            </table>
		                                        </SelectedItemTemplate>
		                                    </asp:DataList>
		                                    <asp:ObjectDataSource ID="odsEtapasPET" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCveProyecto"
		                                            TypeName="dsAppTableAdapters.ProyectoEtapaTableAdapter">
		                                        <SelectParameters>
		                                            <asp:ControlParameter ControlID="lblCveCONACYTEdt" Name="CveProyecto" PropertyName="Text"
		                                                Type="String" />
		                                        </SelectParameters>
		                                    </asp:ObjectDataSource>
		                                </td>
		                            </tr>
		                            <tr>
		                                <td colspan="2">
		                                </td>
		                            </tr>
		                            <tr>
		                                <td style="width: 30%">
		                                </td>
		                                <td style="width: 70%">
		                                </td>
		                            </tr>
		                        </table>
		                        </asp:View>
		                        <asp:View ID="viewInfraestructuraEdt" runat="server">
		                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
		                                <tr>
		                                    <td colspan="2">&nbsp;
		                                        
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <th class="thtablaComun" colspan="2" style="height: 19px">
		                                        Infraestructura</th>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                        <asp:ImageButton ID="ibtnNuevoPIAdd" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" OnClick="ibtnNuevoPIAdd_Click" />&nbsp;
		                                        <asp:Panel ID="pnlInfraestructuraPIAdd" runat="server" Width="100%" Visible="False">
		                                            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                <tr>
		                                                    <td colspan="2">
		                                                        <asp:UpdatePanel ID="updpTipoInfraestructuraPIAdd" runat="server">
		                                                            <ContentTemplate>
		                                                                <table width="100%">
		                                                                    <tr>
		                                                                        <td style="width: 30%">
		                                                                            Tipo de Infraestructura</td>
		                                                                        <td style="width: 70%">
		                                                                            <asp:DropDownList ID="ddlTipoInfraestructuraPIAdd" runat="server" DataSourceID="odsTipoInfraestructuraPIAdd"
		                                                                    DataTextField="TipoInfraestructura" DataValueField="CveTipoInfraestructura" AutoPostBack="True">
		                                                                            </asp:DropDownList><asp:RangeValidator ID="ravTipoInfraestructuraPIAdd" runat="server"
		                                                                                ControlToValidate="ddlTipoInfraestructuraPIAdd" ErrorMessage="Debe seleccionar un tipo de infraestructura"
		                                                                                ForeColor="" MaximumValue="1000000" MinimumValue="1" ToolTip="Debe seleccionar un tipo de infraestructura"
		                                                                                Type="Integer">x</asp:RangeValidator><asp:CustomValidator ID="cuvTipoInfraestructuraPIAdd"
		                                                                                    runat="server" ControlToValidate="ddlTipoInfraestructuraPIAdd" ForeColor="">x</asp:CustomValidator><asp:ObjectDataSource
		                                                                    ID="odsTipoInfraestructuraPIAdd" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                    SelectMethod="GetDataTipoInfraestructuraDDL" TypeName="dsAppTableAdapters.spTipoInfraestructura_SelectDDLTableAdapter">
		                                                                                    </asp:ObjectDataSource>
		                                                                        </td>
		                                                                    </tr>
		                                                                    <tr>
		                                                                        <td style="width: 30%">
		                                                                            Infraestrucura</td>
		                                                                        <td style="width: 70%">
		                                                                            <asp:DropDownList ID="ddlInfraestructuraPIAdd" runat="server" DataSourceID="odsInfraestructuraPIAdd"
		                                                                    DataTextField="Infraestructura" DataValueField="CveInfraestructura">
		                                                                            </asp:DropDownList><asp:RangeValidator ID="ravInfraestructuraPIAdd" runat="server"
		                                                                                ControlToValidate="ddlTipoInfraestructuraPIAdd" ErrorMessage="Debe seleccionar una infraestructura"
		                                                                                ForeColor="" MaximumValue="1000000" MinimumValue="1" ToolTip="Debe seleccionar una infraestructura"
		                                                                                Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
		                                                                    ID="odsInfraestructuraPIAdd" runat="server" OldValuesParameterFormatString="original_{0}"
		                                                                    SelectMethod="GetDataByTipoInfraestructura" TypeName="dsAppTableAdapters.spInfraestructura_SelectDDLTableAdapter">
		                                                                                    <SelectParameters>
		                                                                                        <asp:ControlParameter ControlID="ddlTipoInfraestructuraPIAdd" Name="CveTipoInfraestructura"
		                                                                                            PropertyName="SelectedValue" Type="Int32" />
		                                                                                    </SelectParameters>
		                                                                                </asp:ObjectDataSource>
		                                                                        </td>
		                                                                    </tr>
		                                                                </table>
		                                                            </ContentTemplate>
		                                                        </asp:UpdatePanel>
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%; height: 30px;">
		                                                        Monto</td>
		                                                    <td style="width: 70%; height: 30px;">
		                                                        <asp:TextBox ID="txtMontoInfraPIAdd" runat="server" MaxLength="100" Width="150px"></asp:TextBox>
		                                                        <asp:RegularExpressionValidator
		                                                            ID="revMontoPIAdd" runat="server" 
		                                                            ControlToValidate="txtMontoInfraPIAdd" 
		                                                            ErrorMessage="Nombre del proyecto tiene caracteres no permitidos"
		                                                            ForeColor="" ToolTip="Nombre común tiene caracteres no permitidos" 
		                                                            ValidationExpression="^([0-9]{0,}|[0-9]{0,}[.][0-9]{0,})$">x</asp:RegularExpressionValidator>
		                                                        <asp:RequiredFieldValidator
		                                                                ID="rfvMontoPIEdt" runat="server" 
		                                                                ControlToValidate="txtMontoInfraPIAdd" 
		                                                                ErrorMessage="El monto de infraestructura es un valor requerido"
		                                                                ForeColor="">x</asp:RequiredFieldValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ValidationSummary ID="vsInfraestructuraPIAdd" runat="server" DisplayMode="List" ForeColor="" />
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ImageButton ID="ibtnGuardarPIAdd" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" OnClick="ibtnGuardarPIAdd_Click" />
		                                                        <asp:ImageButton ID="ibtnCancelarPIAdd" runat="server" CausesValidation="False"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" OnClick="ibtnCancelarPIAdd_Click" /></td>
		                                                </tr>
		                                            </table>
		                                            &nbsp;</asp:Panel>
		                                        <asp:DataList ID="dtlInfraestructuraPI" runat="server" DataKeyField="CveInfraestructura" DataSourceID="odsInfraestructuraPI" Width="100%" OnCancelCommand="dtlInfraestructuraPI_CancelCommand" OnDeleteCommand="dtlInfraestructuraPI_DeleteCommand" OnEditCommand="dtlInfraestructuraPI_EditCommand" OnItemDataBound="dtlInfraestructuraPI_ItemDataBound" OnUpdateCommand="dtlInfraestructuraPI_UpdateCommand">
		                                            <AlternatingItemStyle CssClass="tablaAlternatigTemplate" />
		                                            <ItemTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaComun" width="100%">
		                                                    <tr>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEditarPIItm" runat="server" CommandName="Edit" ImageUrl="~/images/aplicacion/btnEditar.gif" /></td>
		                                                        <td style="width: 52%">
		                                                            <asp:Label ID="lblInfraestructuraPIItm" runat="server" Text='<%# Eval("Infraestructura") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:Label ID="lblMontoPIItm" runat="server" Text='<%# Eval("Monto", "{0:C}") %>'></asp:Label></td>
		                                                        <td style="width: 16%">
		                                                            <asp:ImageButton ID="ibtnEliminarPIItm" runat="server" CommandName="Delete" ImageUrl="~/images/aplicacion/btnEliminar.gif" /></td>
		                                                    </tr>
		                                                </table>
		                                            </ItemTemplate>
		                                            <EditItemTemplate><table width="100%" border="0" cellpadding="3" cellspacing="0" class="tablaEditarTemplate">
		                                                <tr>
		                                                    <td>Tipo</td>
		                                                    <td><asp:Label ID="lbTipoInfraestructuraPIEdt" runat="server" Text='<%# Eval("TipoInfraestructura") %>'></asp:Label></td>
		                                                </tr>
		                                                <tr>
		                                                    <td>Infraestructura</td>
		                                                    <td><asp:Label ID="lbInfraestructuraPIEdt" runat="server" Text='<%# Eval("Infraestructura") %>'></asp:Label></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%; height: 30px;">
		                                                        Monto</td>
		                                                    <td style="width: 70%; height: 30px;">
		                                                        <asp:TextBox ID="txtMontoInfraPIEdt" runat="server" MaxLength="100" Text='<%# Eval("Monto") %>'
		                                                            Width="150px"></asp:TextBox><asp:RegularExpressionValidator ID="revMontoPIEdt" runat="server"
		                                                                ControlToValidate="txtMontoInfraPIEdt" ErrorMessage="Nombre del proyecto tiene caracteres no permitidos"
		                                                                ForeColor="" ToolTip="Nombre común tiene caracteres no permitidos" ValidationExpression="^[0-9]{0,}[.][0-9]{0,}$">x</asp:RegularExpressionValidator><asp:RequiredFieldValidator
		                                                                    ID="rfvMontoPIEdt" runat="server" ControlToValidate="txtMontoInfraPIEdt" ErrorMessage="El monto de infraestructura es un valor requerido"
		                                                                    ForeColor="">x</asp:RequiredFieldValidator></td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ValidationSummary ID="vsInfraestructuraPIEdt" runat="server" DisplayMode="List" ForeColor="" />
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td style="width: 30%">
		                                                    </td>
		                                                    <td style="width: 70%">
		                                                        <asp:ImageButton ID="ibtnGuardarPIEdt" runat="server" ImageUrl="~/images/aplicacion/btnGuardar.gif" CommandName="update" />
		                                                        <asp:ImageButton ID="ibtnCancelarPIEdt" runat="server" CausesValidation="False" CommandName="cancel"
		                                                                    ImageUrl="~/images/aplicacion/btnCancelar.gif" /></td>
		                                                </tr>
		                                            </table>
		                                            </EditItemTemplate>
		                                            <HeaderTemplate>
		                                                <table border="0" cellpadding="3" cellspacing="0" class="tablaHeaderTemplate" width="100%">
		                                                    <tr>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                        <th style="width: 52%">
		                                                            Infraestructura</th>
		                                                        <th style="width: 16%">
		                                                            Monto</th>
		                                                        <th style="width: 16%">&nbsp;
		                                                            </th>
		                                                    </tr>
		                                                </table>
		                                            </HeaderTemplate>
		                                        </asp:DataList>
                                                <asp:ObjectDataSource
                                                    ID="odsTipoInfraestructuraPIEdt" runat="server" OldValuesParameterFormatString="original_{0}"
                                                    SelectMethod="GetDataTipoInfraestructuraDDL" TypeName="dsAppTableAdapters.spTipoInfraestructura_SelectDDLTableAdapter">
                                                </asp:ObjectDataSource>
                                                
		                                        <asp:ObjectDataSource ID="odsInfraestructuraPI" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCveProyecto"
		                                            TypeName="dsAppTableAdapters.ProyectoInfraestructuraTableAdapter">
		                                            <SelectParameters>
		                                                <asp:ControlParameter ControlID="lblCveCONACYTEdt" Name="CveProyecto" PropertyName="Text"
		                                                    Type="String" />
		                                            </SelectParameters>
		                                        </asp:ObjectDataSource>
                                                &nbsp;
		                                    </td>
		                                </tr>
		                                <tr>
		                                    <td colspan="2">
		                                    </td>
		                                </tr>
		                            </table>
		                        </asp:View>
		                    </asp:MultiView></td>
		            </tr>
		            <tr>
		                <td style="border-top-style: double; border-top-color: white; height: 30px; width: 720px;">&nbsp;
		                    
		                </td>
		            </tr>
		        </table>
		    </EditItemTemplate>

                <SelectedItemTemplate>
                    <table cellpadding="3" cellspacing="0" class="tablaComun" width="90%" align="center" border="0">
                        <tr>
                            <td colspan="2" class="thtablaComun">
                                Datos Generales</td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                                Clave CONACYT&nbsp;</td>
                            <td style="width: 70%">
                                <asp:Label ID="lblCveProyectoST" runat="server" Text='<%# Eval("CveProyecto") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                                Nombre del proyecto</td>
                            <td style="width: 70%">
                                <asp:Label ID="lblNombreProyectoST" runat="server" Text='<%# Bind("NombreProyecto") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Responsable Técnico</td>
                            <td>
                                <asp:Label ID="lbResponsableTecnicoST" runat="server" Text='<%# Bind("ResponsableTecnico") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                                Año de la convocatoria
                            </td>
                            <td style="width: 70%">
                                <asp:Label ID="lblAnioConvocatoriaST" runat="server" Text='<%# Bind("AnioConvocatoria") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                                Institución</td>
                            <td style="width: 70%">
                                <asp:Label ID="lblInstitucionST" runat="server" Text='<%# Bind("Institucion") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 30%; height: 36px">
                                Objetivo general</td>
                            <td style="width: 70%; height: 36px">
                                <asp:Label ID="lblObjetivoGeneralST" runat="server" Text='<%# Bind("ObjetivoGeneral") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Costo Total del proyecto:</td>
                            <td><asp:Label ID="lbCostoTotalProyectoST" runat="server" Text='<%# Bind("CostoTotalProyecto","{0:C2}") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Aportacion Apoyo Institucional: <asp:Label ID="lbAportacionApoyoInstitucionalST" runat="server" Text='<%# Bind("AportacionApoyoInstitucional","{0:C2}") %>'></asp:Label>
                                Aportacion Institucional Ejecutora: <asp:Label ID="lbAportacionInstitucionEjecutoraST" runat="server" Text='<%# Bind("AportacionInstitucionEjecutora","{0:C2}") %>'></asp:Label>
                                Otras Aportaciones: <asp:Label ID="lbAportacionesOtrasST" runat="server" Text='<%# Bind("AportacionesOtras","{0:C2}") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:UpdatePanel ID="updpMasObjetivosST" runat="server">
                                    <ContentTemplate>
                                        <asp:ImageButton ID="ibtnExpandirObjetivosST" runat="server" ImageUrl="~/images/aplicacion/expandir.gif" OnClick="ibtnExpandirObjetivosST_Click" />
                                        <asp:Label ID="lblMasInfoObjetivosST" runat="server" Text="Más ..."></asp:Label>
                                        <asp:Panel ID="pnlExpandirObjetivosST" runat="server" Width="100%" Visible="False">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 30%">
                                                        Objetivos específicos</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="lblObjetivosEspecificosST" runat="server" Text='<%# Bind("ObjetivosEspecificos") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                                        Metodología</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="lblMetodologiaST" runat="server" Text='<%# Bind("Metodologia") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                                        Resultados esperados</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="lblResultadosEspST" runat="server" Text='<%# Bind("ResultadosEsp") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                                        Impactos esperados</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="lblImpactosEsperadosST" runat="server" Text='<%# Bind("ImpactosEsperados") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                                        Ecosistema
                                                    </td>
                                                    <td style="width: 70%">
                                <asp:Label ID="lblEcosistemaST" runat="server" Text='<%# Bind("Ecosistema") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">Vegetación</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="lblVegetacionST" runat="server" Text='<%# Bind("Vegetacion") %>'></asp:Label></td>
                                                </tr>
                                            </table>
                                            </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                                Demanda</td>
                            <td style="width: 70%">
                                <asp:Label ID="lblDemandaST" runat="server" Text='<%# Bind("Demanda") %>'></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:UpdatePanel ID="updpMasInfoGralST" runat="server">
                                    <ContentTemplate>
                                        <asp:ImageButton ID="ibtnMasInfoGralST" runat="server" ImageUrl="~/images/aplicacion/expandir.gif"
                                            OnClick="ibtnMasInfoGralST_Click" />
                                        <asp:Label ID="lblMasInfoGralST" runat="server" Text="Más ..."></asp:Label>
                                        <asp:Panel ID="pnlMasInfoGralST" runat="server" Visible="False" Width="100%">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 30%">
                                                        Demandante</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="DemandanteLabel" runat="server" Text='<%# Bind("Demandante") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                                        Identificación del problema</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="IdentProblemaLabel" runat="server" Text='<%# Bind("IdentProblema") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                                        Resumen</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="ResumenLabel" runat="server" Text='<%# Bind("Resumen") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                Fecha del convenio o acuerdo</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="FechaConvAcueLabel" runat="server" Text='<%# Bind("FechaConvAcue", "{0:d}") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                Área temática
                                                    </td>
                                                    <td style="width: 70%">
                                <asp:Label ID="AreaTematicaLabel" runat="server" Text='<%# Bind("AreaTematica") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                Tipo de proyecto
                                                    </td>
                                                    <td style="width: 70%">
                                <asp:Label ID="TipoProyectoLabel" runat="server" Text='<%# Bind("TipoProyecto") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                Tipo de apoyo</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="TipoApoyoLabel" runat="server" Text='<%# Bind("TipoApoyo") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                Región de seguimiento
                                                    </td>
                                                    <td style="width: 70%">
                                <asp:Label ID="RegionSeguimientoLabel" runat="server" Text='<%# Bind("RegionSeguimiento") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                Lugar del proyecto
                                                    </td>
                                                    <td style="width: 70%">
                                <asp:Label ID="CoberturaOperativaLabel" runat="server" Text='<%# Bind("CoberturaOperativa") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                Escala</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="EscalaLabel" runat="server" Text='<%# Bind("Escala") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                Estatus</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="EstatusLabel" runat="server" Text='<%# Bind("Estatus") %>'></asp:Label></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <%-- ocultado por Polo --%>
                        <tr style="display:none;">
                            <td colspan="2" class="thtablaComun">
                                Transferencia de tecnología</td>
                        </tr>
                        <%-- ocultado por Polo --%>
                        <tr style="display:none;">
                            <td style="width: 30%">
                                Sector</td>
                            <td style="width: 70%">
                                <asp:Label ID="lblSectorUsuarioTTST" runat="server" Text='<%# Bind("SectorUsuario") %>'></asp:Label></td>
                        </tr>
                        <%-- ocultado por Polo --%>
                        <tr style="display:none;">
                            <td colspan="2">
                                <asp:UpdatePanel ID="updpInfoTTST" runat="server">
                                    <ContentTemplate>
                                        <asp:ImageButton ID="ibtnExpandirTTST" runat="server" ImageUrl="~/images/aplicacion/expandir.gif"
                                            OnClick="ibtnExpandirTT_Click"/>
                                        <asp:Label ID="lblMasInfoTTST" runat="server" Text="Más ..."></asp:Label><br />
                                        <asp:Panel ID="pnlExpandirTT" runat="server" Visible="False" Width="100%">
                                            <table cellpadding="3" cellspacing="0" width="100%">
                                                <tr>
                                                    <td style="width: 30%">
                                                        Usuario destino</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="lblUsuarioTTST" runat="server" Text='<%# Bind("Usuario") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                                        Materiales</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="lblMaterialesTTST" runat="server" Text='<%# Bind("Materiales") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                                        Requisitos</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="lblRequisitosTTST" runat="server" Text='<%# Bind("RequisitosTT") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%">
                                                        Actividades</td>
                                                    <td style="width: 70%">
                                <asp:Label ID="lblActividadesTTST" runat="server" Text='<%# Bind("ActividadesTT") %>'></asp:Label></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;
                                </td>
                        </tr>
                        <tr>
                            <td class="thtablaComun" colspan="2">
                                Participantes</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="GridView1" 
                                    runat="server" 
                                    AutoGenerateColumns="False" 
                                    DataKeyNames="CveParticipante,CveProyecto"
                                    DataSourceID="odsParticipantesST" 
                                    Width="90%">                                       
                                    <Columns>
                                        <asp:BoundField DataField="Participante" HeaderText="Participante" ReadOnly="True"
                                            SortExpression="Participante">
                                            <ItemStyle Width="50%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TipoParticipante" HeaderText="Tipo de participante" ReadOnly="True"
                                            SortExpression="TipoParticipante">
                                            <ItemStyle Width="50%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No existen registros de participantes para este proyecto
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsParticipantesST" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetDataByCveProyecto" TypeName="dsAppTableAdapters.ProyectoParticipanteTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lblCveProyectoST" Name="CveProyecto" PropertyName="Text"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;
                                </td>
                        </tr>
                        <tr>
                            <td class="thtablaComun" colspan="2">
                                Especies involucradas</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="grvwEspeciesST" runat="server" AutoGenerateColumns="False"
                                    DataSourceID="odsProyectoEspeciesST" Width="90%" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="NombreCientifico" HeaderText="Nombre cient&#237;fico"
                                            SortExpression="NombreCientifico" >
                                            <ItemStyle Width="50%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NombreComun" HeaderText="Nombre com&#250;n" SortExpression="NombreComun" >
                                            <ItemStyle Width="50%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No existen registros de especies para este proyecto
                                    </EmptyDataTemplate>
                                    <RowStyle CssClass="tablaComun" />
                                    <AlternatingRowStyle CssClass="tablaAlternatigTemplate" />
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsProyectoEspeciesST" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetDataByCveProyecto" TypeName="dsAppTableAdapters.ProyectoEspecieTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lblCveProyectoST" Name="CveProyecto" PropertyName="Text" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;
                                </td>
                        </tr>
                        <tr>
                            <td class="thtablaComun" colspan="2">
                                Seguimiento</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="grvwSeguimiento" runat="server" GridLines="None" Width="90%" AutoGenerateColumns="False" DataKeyNames="CveProyecto,CveAsunto" DataSourceID="odsProyectoSeguimiento">
                                    <EmptyDataTemplate>
                                        No existen seguimiento para este proyecto
                                    </EmptyDataTemplate>
                                    <RowStyle CssClass="tablaComun" />
                                    <AlternatingRowStyle CssClass="tablaAlternatigTemplate" />
                                    <Columns>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                        <asp:BoundField DataField="DesEstatus" HeaderText="Estatus" ReadOnly="True" SortExpression="DesEstatus" />
                                    </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsProyectoSeguimiento" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCveProyecto" TypeName="dsAppTableAdapters.ProyectoAsuntosTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lblCveProyectoST" Name="CveProyecto" PropertyName="Text"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;
                                </td>
                        </tr>
                        <tr>
                            <td class="thtablaComun" colspan="2">
                                Productos</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:DataList ID="dtlProductosST" runat="server" DataKeyField="CveProducto"
                                    DataSourceID="odsProductosST" Width="90%" 
                                    OnItemCommand="dtlProductosST_ItemCommand" 
                                    OnItemDataBound="dtlProductosST_ItemDataBound" >
                                    <ItemStyle CssClass="tablaItemTemplate" />
                                    <AlternatingItemStyle CssClass="tablaAlternatigTemplate" />
                                    <HeaderTemplate>
                                        <table width="100%" border="0" cellpadding="3" cellspacing="0" align="center">
                                            <tr>
                                                <th style="width: 50%">
                                                    Producto</th>
                                                <th style="width: 50%">
                                                    Título</th>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table id="qoLVC" width="100%" border="0" cellpadding="3" cellspacing="0"  align="center">
                                            <tr>
                                                <td width="50%">
                                                    <asp:Label ID="lblProductoItm" runat="server" Text='<%# Eval("Producto") %>'></asp:Label></td>
                                                <td width="50%">
                                                    <asp:LinkButton ID="lnkbTituloItm" runat="server" CommandArgument='<%# Eval("CveProyecto") & "|" & Eval("CveEtapa") & "|" & Eval("CveProducto") & "|0"%>'
                                                        Text='<%# Eval("Titulo") %>' CommandName="Download"></asp:LinkButton></td>
                                            </tr>
                                        </table>
                                        <asp:ImageButton ID="imgbArch0" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch1" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch2" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch3" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch4" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch5" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch6" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch7" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch8" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch9" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch10" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch11" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch12" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch13" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch14" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch15" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch16" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch17" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch18" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch19" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch20" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch21" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch22" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch23" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                        <asp:ImageButton ID="imgbArch24" runat="server" ImageUrl="~/images/aplicacion/pdf.gif" CausesValidation="false" ToolTip="documento #1" Visible="false" CommandName="Download" ImageAlign="Left" />
                                    </ItemTemplate>
                                </asp:DataList>
                                <asp:ObjectDataSource ID="odsProductosST" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetDataByCveProyecto" TypeName="dsAppTableAdapters.EtapaProductosTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lblCveProyectoST" Name="CveProyecto" PropertyName="Text"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 30%">
                            </td>
                            <td style="width: 70%">
                                <asp:ImageButton ID="ibtnRegresar" runat="server" ImageUrl="~/images/aplicacion/btnRegresar.gif" CommandName="Cancel" /></td>
                        </tr>
                    </table>
                </SelectedItemTemplate>

             
                </asp:DataList>
                <asp:ObjectDataSource ID="odsProyecto" runat="server"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataFiltradoYPaginado" TypeName="dsAppTableAdapters.ProyectoTableAdapter" SelectCountMethod="CuentaTotalProyectosFiltrado" ConvertNullToDBNull="True">
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlNavegacionDw" runat ="server" Visible="true" Width="100%">
                       <table width="90%" align="center" class="tablaComun">
                            <tr>
                                <td style="width: 25%"><asp:ImageButton ID="ibtnNuevoDw" runat="server" ImageUrl="~/images/aplicacion/btnNuevo.gif" />

                                </td>
                                <td style="width: 25%; text-align: left">
                                    &nbsp;<asp:LinkButton ID="lnkbPrimeraDw" runat="server">|<< Primera</asp:LinkButton>&nbsp;
                                    <asp:LinkButton ID="lnkbAnteriorDw" runat="server"><< Anterior</asp:LinkButton></td>
                                <td style="width: 25%; text-align: right">
                                    <asp:LinkButton ID="lnkbSiguienteDw" runat="server">Siguiente >></asp:LinkButton>&nbsp;
                                    <asp:LinkButton ID="lnkbUltimaDw" runat="server">Última >>|</asp:LinkButton>
                                    </td>
                                <td style="width: 25%" align="right">
                                    <asp:Label ID="lblPaginaActualDW" runat="server" Text="Página 0 de 0"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" colspan="4">
                                    <asp:Label ID="lblTotalProyectosDW" runat="server" Text="0 proyectos encontrados"></asp:Label></td>
                            </tr>
                        </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    </asp:View>
    <asp:View ID="viewAgregar" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" class="tablaComun" width="100%">
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <table align="center" border="0" cellpadding="3" cellspacing="0" width="90%">
                            <tr>
                                <td colspan="2">
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <th class="thtablaComun" colspan="2">
                                    Datos Generales del proyecto</th>
                            </tr>
                            <tr>
                                <td style="width: 30%; height: 15px">&nbsp;
                                    </td>
                                <td style="width: 70%; height: 15px">
                                    <asp:Label ID="lblEstatusAdd" runat="server" Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Clave CONACYT</td>
                                <td style="width: 70%"><asp:TextBox ID="txtCveCONACYT" runat="server" MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="rfvCveCONACYT" runat="server" ControlToValidate="txtCveCONACYT" ErrorMessage="Clave CONACYT es un valor requerido"
                                        ForeColor="" ToolTip="Clave CONACYT es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                            ID="revCveCONACYT" runat="server" ControlToValidate="txtCveCONACYT" ErrorMessage="Clave CONACYT tiene caracteres no permitidos"
                                            ForeColor="" ToolTip="Clave CONACYT tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator><asp:CustomValidator
                                                ID="cuvExcepcionesAdd" runat="server" ErrorMessage="Error al intentar guardar los datos"
                                                ForeColor="" ToolTip="Error al intentar guardar los datos" ControlToValidate="txtCveCONACYT">x</asp:CustomValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Nombre del proyecto</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtNombreAdd" runat="server" MaxLength="300" Rows="4" TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvNombreProyectoAdd"
                                            runat="server" ControlToValidate="txtNombreAdd" ErrorMessage="Nombre del proyecto es un valor requerido"
                                            ForeColor="" ToolTip="Nombre del proyecto es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                ID="revNombreProyectoAdd" runat="server" ControlToValidate="txtNombreAdd" ErrorMessage="Nombre del proyecto tiene caracteres no permitidos"
                                                ForeColor="" ToolTip="Nombre del proyecto tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td>Responsable Técnico</td>
                                <td>
                                    <asp:DropDownList ID="ddlResponsableTecnicoAdd" runat="server"
                                        DataSourceID="odsResponsableTecnicoAdd"
                                        DataTextField="Nombre"
                                        DataValueField="CveResponsableTecnico">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsResponsableTecnicoAdd" runat="server"
                                        OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetData"
                                        TypeName="dsAppTableAdapters.spResponsableTecnicoDDLTableAdapter">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Resumen</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtResumenAdd" runat="server" MaxLength="1073741823" Rows="4" 
                                        TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvResumenAdd"
                                            runat="server" ControlToValidate="txtResumenAdd" ErrorMessage="Resumen del proyecto es un valor requerido"
                                            ForeColor="" ToolTip="Resumen del proyecto es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                ID="revResumenAdd" runat="server" ControlToValidate="txtResumenAdd" ErrorMessage="Resumen del proyecto tiene caracteres no permitidos"
                                                ForeColor="" ToolTip="Resumen del proyecto tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Objetivo general</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtObjetivoGralAdd" runat="server" MaxLength="1000" Rows="4" 
                                        TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvObjetivoGralAdd"
                                            runat="server" ControlToValidate="txtObjetivoGralAdd" ErrorMessage="Objetivo general es un valor requerido"
                                            ForeColor="" ToolTip="Objetivo general es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                ID="revObjetivoGralAdd" runat="server" ControlToValidate="txtObjetivoGralAdd"
                                                ErrorMessage="Objetivo general tiene caracteres no permitidos" ForeColor="" ToolTip="Objetivo general tiene caracteres no permitidos"
                                                ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Objetivos específicos</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtObjetivosEspAdd" runat="server" MaxLength="4000" Rows="4" 
                                        TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="revObetivosEspAdd"
                                            runat="server" ControlToValidate="txtObjetivosEspAdd" ErrorMessage="Objetivos específicos es un valor requerido"
                                            ForeColor="" ToolTip="Objetivos específicos es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                ID="revObjetivosEspAdd" runat="server" ControlToValidate="txtObjetivosEspAdd"
                                                ErrorMessage="Objetivos específicos tiene caracteres no permitidos" ForeColor=""
                                                ToolTip="Objetivos específicos tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Tipo de proyecto</td>
                                <td style="width: 70%">
                                    <asp:DropDownList ID="ddlTipoProyectoAdd" runat="server" DataSourceID="odsTipoProyectoDDLAdd"
                                        DataTextField="DesTipoProy" DataValueField="CveTipoProy"
                                        Width="400px">
                                    </asp:DropDownList><asp:RangeValidator ID="ravTipoProyectoAdd" runat="server" ControlToValidate="ddlTipoProyectoAdd"
                                        ErrorMessage="Indique el tipo de proyecto" ForeColor="" MaximumValue="1000" MinimumValue="1"
                                        ToolTip="Indique el tipo de proyecto" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
                                            ID="odsTipoProyectoDDLAdd" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetData" TypeName="dsAppTableAdapters.spTipoProyectoDDLTableAdapter">
                                        </asp:ObjectDataSource>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Tipo de apoyo</td>
                                <td style="width: 70%">
                                    <asp:DropDownList ID="ddlTipoApoyoAdd" runat="server" DataSourceID="odsTipoApoyoDDLAdd"
                                        DataTextField="DesTipoApoyo" DataValueField="CveTipoApoyo" Width="400px" AutoPostBack="True">
                                    </asp:DropDownList><asp:RegularExpressionValidator ID="revTipoApoyoAdd" runat="server"
                                        ControlToValidate="ddlTipoApoyoAdd" ErrorMessage="Indique el tipo de apoyo" ForeColor=""
                                        ToolTip="Indique el tipo de apoyo" ValidationExpression="<%#ValExpTipoApoyo()%>">x</asp:RegularExpressionValidator>
                                    <asp:ObjectDataSource ID="odsTipoApoyoDDLAdd" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetData" TypeName="dsAppTableAdapters.spTipoApoyoDDLTableAdapter">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Área temática</td>
                                <td style="width: 70%">
                                    <asp:DropDownList ID="ddlAreaTematicaAdd" runat="server" DataSourceID="odsAreaTematicaDDLAdd"
                                        DataTextField="AreaTematica" DataValueField="CveAreaTematica" Width="400px">
                                    </asp:DropDownList><asp:RangeValidator ID="ravAreaTematicaAdd" runat="server" ControlToValidate="ddlAreaTematicaAdd"
                                        ErrorMessage="Indique el área temática" ForeColor="" MaximumValue="1000" MinimumValue="-1"
                                        ToolTip="Indique el área temática" Type="Integer">x</asp:RangeValidator>
                                        <asp:ObjectDataSource
                                            ID="odsAreaTematicaDDLAdd" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetData" TypeName="dsAppTableAdapters.spAreaTematicaDDLTableAdapter">
                                        </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Institución</td>
                                <td style="width: 70%">
                                    <asp:DropDownList ID="ddlInstitucionAdd" runat="server" DataSourceID="odsInstitucionDDLAdd"
                                        DataTextField="DesInstitucion" DataValueField="CveInstitucion" Width="400px">
                                    </asp:DropDownList><asp:RangeValidator ID="ravInstitucionAdd" runat="server" ControlToValidate="ddlInstitucionAdd"
                                        ErrorMessage="Indique la institución" ForeColor="" MaximumValue="1000" MinimumValue="1"
                                        ToolTip="Indique la institución" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
                                            ID="odsInstitucionDDLAdd" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetData" TypeName="dsAppTableAdapters.spInstitucionDDLTableAdapter">
                                        </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>Costo TOTAL del proyecto</td>
                                <td>
                                    $<asp:TextBox ID="txtCostoTotalProyectoAdd" runat="server" Columns="12" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCostoTotalProyectoAdd"
                                        runat="server" ControlToValidate="txtCostoTotalProyectoAdd" ForeColor="" 
                                        ErrorMessage="Costo total del proyecto es un valor requerido"
                                        ToolTip="Costo total del proyecto es un valor requerido">x</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revCostoTotalProyectoAdd"
                                        runat="server" ControlToValidate="txtCostoTotalProyectoAdd"
                                        ErrorMessage="Costo total del proyecto tiene caracteres no permitidos" ForeColor=""
                                        ToolTip="Costo total del proyecto tiene caracteres no permitidos" 
                                        ValidationExpression="^([0-9]{1,}|[0-9]{0,}\.[0-9]{0,})$">x</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table border="0" width="100%">
                                        <tr>
                                            <td style="width: 30%">Aportacion Apoyo Institucional</td>
                                            <td style="width: 30%">Aportacion Institucion Ejecutora</td>
                                            <td>Otras Aportaciones</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                $<asp:TextBox ID="txtAportacionApoyoInstitucionalAdd" runat="server" Columns="12" MaxLength="10"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvAportacionApoyoInstitucionalAdd"
                                                    runat="server" ControlToValidate="txtAportacionApoyoInstitucionalAdd" ForeColor="" 
                                                    ErrorMessage="La aportacion de apoyo institucional es un valor requerido"
                                                    ToolTip="La aportacion de apoyo institucional es un valor requerido">x</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revAportacionApoyoInstitucionalAdd"
                                                    runat="server" ControlToValidate="txtAportacionApoyoInstitucionalAdd"
                                                    ErrorMessage="La aportacion de apoyo institucional tiene caracteres no permitidos" ForeColor=""
                                                    ToolTip="La aportacion de apoyo institucional tiene caracteres no permitidos" 
                                                    ValidationExpression="^([0-9]{1,}|[0-9]{0,}\.[0-9]{0,})$">x</asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                $<asp:TextBox ID="txtAportacionInstitucionEjecutoraAdd" runat="server" Columns="12" MaxLength="10"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvAportacionInstitucionEjecutoraAdd"
                                                    runat="server" ControlToValidate="txtAportacionInstitucionEjecutoraAdd" ForeColor="" 
                                                    ErrorMessage="La aportacion de la institucional ejecutora es un valor requerido"
                                                    ToolTip="La aportacion de la institucional ejecutora es un valor requerido">x</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revAportacionInstitucionEjecutoraAdd"
                                                    runat="server" ControlToValidate="txtAportacionInstitucionEjecutoraAdd"
                                                    ErrorMessage="La aportacion de la institucional ejecutora tiene caracteres no permitidos" ForeColor=""
                                                    ToolTip="La aportacion de la institucional ejecutora tiene caracteres no permitidos" 
                                                    ValidationExpression="^([0-9]{1,}|[0-9]{0,}\.[0-9]{0,})$">x</asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                $<asp:TextBox ID="txtAportacionesOtrasAdd" runat="server" Columns="12" MaxLength="10"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvAportacionesOtrasAdd"
                                                    runat="server" ControlToValidate="txtAportacionesOtrasAdd" ForeColor="" 
                                                    ErrorMessage="Otras aportaciones es un valor requerido"
                                                    ToolTip="Otras aportaciones es un valor requerido">x</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revAportacionesOtrasAdd"
                                                    runat="server" ControlToValidate="txtAportacionesOtrasAdd"
                                                    ErrorMessage="Otras aportaciones tiene caracteres no permitidos" ForeColor=""
                                                    ToolTip="Otras aportaciones tiene caracteres no permitidos" 
                                                    ValidationExpression="^([0-9]{1,}|[0-9]{0,}\.[0-9]{0,})$">x</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Año de la convocatoria</td>
                                <td style="width: 70%">
                                    <asp:DropDownList ID="ddlAnioConvAdd" runat="server" DataSourceID="odsAnioConvocatoriaAdd"
                                        DataTextField="Anio" DataValueField="Anio"
                                        Width="400px">
                                    </asp:DropDownList><asp:RangeValidator ID="ravAnioConvAdd" runat="server" ControlToValidate="ddlAnioConvAdd"
                                        ErrorMessage="Indique el año de la convocatoria" ForeColor="" MaximumValue="2020"
                                        MinimumValue="2001" ToolTip="Indique el año de la convocatoria" Type="Integer">x</asp:RangeValidator>
                                    <asp:ObjectDataSource ID="odsAnioConvocatoriaAdd" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetData" TypeName="dsAppTableAdapters.spAnioConvocatoriaDDLTableAdapter">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Gerencia regional de seguimiento</td>
                                <td style="width: 70%">
                                    <asp:DropDownList ID="ddlRegionSegAdd" runat="server" DataSourceID="odsRegionDDLAdd"
                                        DataTextField="DesRegion" DataValueField="CveRegion"
                                        Width="400px">
                                    </asp:DropDownList><asp:RegularExpressionValidator ID="revRegionSegAdd" runat="server"
                                        ControlToValidate="ddlRegionSegAdd" ErrorMessage="Indique la gerencia regional de sequimiento"
                                        ForeColor="" ToolTip="Indique la gerencia regional de sequimiento" ValidationExpression="<%#ValExpRegion()%>">x</asp:RegularExpressionValidator>
                                    <asp:ObjectDataSource ID="odsRegionDDLAdd" runat="server" OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="GetData" TypeName="dsAppTableAdapters.spRegionDDLTableAdapter"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Escala</td>
                                <td style="width: 70%">
                                    <asp:DropDownList ID="ddlEscalaAdd" runat="server" DataSourceID="odsEscalaDDLAdd"
                                        DataTextField="DesEscala" DataValueField="CveEscala" 
                                        Width="400px">
                                    </asp:DropDownList><asp:RangeValidator ID="ravEscalaAdd" runat="server" ControlToValidate="ddlEscalaAdd"
                                        ErrorMessage="Indique la escala" ForeColor="" MaximumValue="1000" MinimumValue="1"
                                        ToolTip="Indique la escala" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
                                            ID="odsEscalaDDLAdd" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetData" TypeName="dsAppTableAdapters.spEscalaDDLTableAdapter"></asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Vegetación</td>
                                <td style="width: 70%">
                                    <asp:DropDownList ID="ddlVegetacionAdd" runat="server" DataSourceID="odsVegetacionDDLAdd"
                                        DataTextField="DesVegetacion" DataValueField="CveVegetacion" 
                                        Width="400px">
                                    </asp:DropDownList><asp:RangeValidator ID="ravVegetacionAdd" runat="server" ControlToValidate="ddlVegetacionAdd"
                                        ErrorMessage="Indique el tipo de vegetación" ForeColor="" MaximumValue="1000"
                                        MinimumValue="1" ToolTip="Indique el tipo de vegetación" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
                                            ID="odsVegetacionDDLAdd" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetData" TypeName="dsAppTableAdapters.spVegetacionDDLTableAdapter">
                                        </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Ecosistema</td>
                                <td style="width: 70%">
                                    <asp:DropDownList ID="ddlEcosistemaAdd" runat="server" DataSourceID="odsEcosistemaDDLAdd"
                                        DataTextField="Descripcion" DataValueField="CveEcosistema" 
                                        Width="400px">
                                    </asp:DropDownList><asp:RangeValidator ID="ravEcosistemaAdd" runat="server" ControlToValidate="ddlEcosistemaAdd"
                                        ErrorMessage="Indique el ecosistema" ForeColor="" MaximumValue="1000" MinimumValue="1"
                                        ToolTip="Indique el ecosistema" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
                                            ID="odsEcosistemaDDLAdd" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetData" TypeName="dsAppTableAdapters.spEcosistemaDDLTableAdapter">
                                        </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Metodología</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtMetodologiaAdd" runat="server" MaxLength="1073741823" Rows="4"
                                         TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator
                                            ID="refMetodologiaAdd" runat="server" ControlToValidate="txtMetodologiaAdd" ErrorMessage="Metodología es un valor requerido"
                                            ForeColor="" ToolTip="Metodología es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                ID="revMetodologiaAdd" runat="server" ControlToValidate="txtMetodologiaAdd" ErrorMessage="Metodología tiene caracteres no permitidos"
                                                ForeColor="" ToolTip="Metodología tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Demanda</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtDemandaAdd" runat="server" MaxLength="1000" Rows="4" 
                                        TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
                                            ID="revDemandaAdd" runat="server" ControlToValidate="txtDemandaAdd" ErrorMessage="Demanda tiene caracteres no permitidos"
                                            ForeColor="" ToolTip="Demanda tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Demandante</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtDemandanteAdd" runat="server" MaxLength="1000" Rows="4"
                                        TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
                                            ID="revDemandanteAdd" runat="server" ControlToValidate="txtDemandanteAdd" ErrorMessage="Demandante tiene caracteres no permitidos"
                                            ForeColor="" ToolTip="Demandante tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Resultados esperados</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtResEsperadosAdd" runat="server" MaxLength="1000" Rows="4" 
                                        TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvResEsperadosAdd"
                                            runat="server" ControlToValidate="txtResEsperadosAdd" ErrorMessage="Resultados esperados es un valor requerido"
                                            ForeColor="" ToolTip="Resultados esperados es un valor requerido">x</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                ID="revResEsperadosAdd" runat="server" ControlToValidate="txtResEsperadosAdd"
                                                ErrorMessage="Resultados esperados tiene caracteres no permitidos" ForeColor=""
                                                ToolTip="Resultados esperados tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Impactos esperados</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtImpactosEsperadosAdd" runat="server" MaxLength="4000" Rows="4"
                                        TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
                                            ID="revImpactosEsperadosAdd" runat="server" ControlToValidate="txtImpactosEsperadosAdd"
                                            ErrorMessage="Impactos esperados tiene caracteres no permitidos" ForeColor=""
                                            ToolTip="Impactos esperados esperados tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Identificación del problema</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtIdentProblemaAdd" runat="server" MaxLength="1000" Rows="4" 
                                        TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
                                            ID="revIdentProblemaAdd" runat="server" ControlToValidate="txtIdentProblemaAdd"
                                            ErrorMessage="Identificación del problema tiene caracteres no permitidos" ForeColor=""
                                            ToolTip="Identificación del problema tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                            </tr>
                            <%--el Polo ocultando esto--%>
                            <tr style="display:none;">
                                <td style="width: 30%">
                                    Cobertura operativa</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtCoberturaOperativaAdd" runat="server" MaxLength="500" Rows="4"
                                         TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator ID="revCoberturaOperativaAdd" runat="server" ControlToValidate="txtCoberturaOperativaAdd"
                                        ErrorMessage="Cobertura operativatiene caracteres no permitidos" ForeColor=""
                                        ToolTip="Cobertura operativatiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Fecha convenio-acuerdo</td>
                                <td style="width: 70%">
                                    <div id="Div1">
                                        &nbsp;<asp:UpdatePanel ID="uppaFechaConvenioAcuerdoAdd" runat="server">
                                            <ContentTemplate>
                                                &nbsp;<ews:DatePicker ID="dpkrFechaConvAcueAdd" runat="server" CalendarPosition="DisplayRight"
                                                    ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" />
                                                <asp:CustomValidator ID="cmvFechaConvAcueAdd" runat="server" ControlToValidate="dpkrFechaConvAcueAdd"
                                                    ErrorMessage="Revise la fecha del convenio-acuerdo" ForeColor="" ToolTip="Revise la fecha del convenio-acuerdo">x</asp:CustomValidator>
                                                <asp:RegularExpressionValidator ID="revFechaConvAcueAdd" runat="server" ControlToValidate="dpkrFechaConvAcueAdd"
                                                    ErrorMessage="Formato de fecha convenio-acuerdo debe ser 'dd/mm/aaaa'" ForeColor=""
                                                    ToolTip="Formato de fecha convenio-acuerdo debe ser 'dd/mm/aaaa'" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d">x</asp:RegularExpressionValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Estatus del proyecto</td>
                                <td style="width: 70%">
                                    <asp:DropDownList ID="ddlEstatusAdd" runat="server" DataSourceID="odsEstatusDDLAdd"
                                        DataTextField="DesEstatus" DataValueField="CveEstatus" 
                                        Width="400px">
                                    </asp:DropDownList><asp:RangeValidator ID="ravEstatusAdd" runat="server" ControlToValidate="ddlEstatusAdd"
                                        ErrorMessage="Indique el estatus del proyecto" ForeColor="" MaximumValue="1000"
                                        MinimumValue="1" ToolTip="Indique el estatus del proyecto" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
                                            ID="odsEstatusDDLAdd" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetDataByTipoApoyo" TypeName="dsAppTableAdapters.spEstatusDDLTableAdapter">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlTipoApoyoAdd" DefaultValue="" Name="CveTipoApoyo"
                                                    PropertyName="SelectedValue" Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <th class="thtablaComun" colspan="2">
                                    Información para transferencia de tecnología</th>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Usuario destino</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtUsuarioTTAdd" runat="server" MaxLength="1000" Rows="4" 
                                        TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
                                            ID="revUsuarioTTAdd" runat="server" ControlToValidate="txtUsuarioTTAdd" ErrorMessage="Usuario destino tiene caracteres no permitidos"
                                            ForeColor="" ToolTip="Usuario destino esperados tiene caracteres no permitidos"
                                            ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Sector</td>
                                <td style="width: 70%">
                                    <asp:DropDownList ID="ddlSectorUsuarioTTAdd" runat="server" DataSourceID="odsSectorUsuarioDDLAdd"
                                        DataTextField="DescSectorUsuario" DataValueField="CveSectorUsuario" 
                                        Width="400px">
                                    </asp:DropDownList><asp:RangeValidator ID="ravSectorAdd" runat="server" ControlToValidate="ddlSectorUsuarioTTAdd"
                                        ErrorMessage="Indique el sector" ForeColor="" MaximumValue="1000" MinimumValue="-1"
                                        ToolTip="Indique el sector del usuario destino" Type="Integer">x</asp:RangeValidator><asp:ObjectDataSource
                                            ID="odsSectorUsuarioDDLAdd" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetData" TypeName="dsAppTableAdapters.spSectorUsuarioDDLTableAdapter">
                                        </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Materiales</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtMaterialesTTAdd" runat="server" MaxLength="1000" Rows="4" 
                                        TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
                                            ID="revMaterialesAdd" runat="server" ControlToValidate="txtMaterialesTTAdd" ErrorMessage="Materiales tiene caracteres no permitidos"
                                            ForeColor="" ToolTip="Materiales tiene caracteres no permitidos" ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Requisitos</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtRequisitosTTAdd" runat="server" MaxLength="1000" Rows="4" 
                                        TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
                                            ID="revRequisitosTTAdd" runat="server" ControlToValidate="txtRequisitosTTAdd"
                                            ErrorMessage="Requisitos tiene caracteres no permitidos" ForeColor="" ToolTip="Requisitos tiene caracteres no permitidos"
                                            ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$">x</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 30%">
                                    Actividades</td>
                                <td style="width: 70%">
                                    <asp:TextBox ID="txtActividadesTTAdd" runat="server" MaxLength="1000" Rows="4" 
                                        TextMode="MultiLine" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
                                            ID="revActividadesTTAdd" runat="server" ControlToValidate="txtActividadesTTAdd"
                                            ErrorMessage="Actividades tiene caracteres no permitidos" ForeColor="" ToolTip="Actividades tiene caracteres no permitidos"
                                            ValidationExpression="^[0-9a-zA-ZñÑÁáÉéÍíÓóÚúÜü/°\s!\x22\#\$%\x26'()*\+,\-.¿?¡:;_\\\d\n]{0,}$" SetFocusOnError="True">x</asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1">
                                </td>
                                <td>
                                    <asp:ValidationSummary ID="vsValidacionAdd" runat="server" DisplayMode="List" ForeColor=""
                                        HeaderText="Se encontraron los siguientes errores:" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1">
                                </td>
                                <td>
                                    <asp:ImageButton ID="ibtnActualizarAdd" runat="server" CommandName="Update" ImageUrl="~/images/aplicacion/btnGuardar.gif" />
                                    <asp:ImageButton ID="ibtnCancelarAdd" runat="server" ImageUrl="~/images/aplicacion/btnCancelar.gif" CausesValidation="False" /></td>
                            </tr>
                        </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
    </asp:View>
    </asp:MultiView>
</asp:Content>

