<%@ Page Language="VB" MasterPageFile="~/mpReportes.master" AutoEventWireup="false" CodeFile="Reportes.aspx.vb" Inherits="Reportes" title="Reportes del sistema" UICulture="es-MX" Culture="es-MX" Theme="skin" %>

<%@ Register Assembly="EclipseWebSolutions.DatePicker" Namespace="EclipseWebSolutions.DatePicker"
    TagPrefix="cc1" %>

<%@ Register Assembly="System.Web.Extensions, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%--<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>--%>
<asp:Content ID="cntReportes" ContentPlaceHolderID="cphReportes" Runat="Server">
    <asp:SiteMapPath ID="stmpReportes" runat="server">
        <PathSeparatorStyle ForeColor="DarkOliveGreen" />
        <RootNodeStyle ForeColor="DarkOliveGreen" />
    </asp:SiteMapPath>
    <asp:ScriptManager id="scrmReportes" runat="server">
    </asp:ScriptManager>
    <asp:MultiView ID="mviewReportes" runat="server">
        <asp:View ID="viewFiltrarEstatusProyectos" runat="server">
            <table border="0" cellpadding="3" cellspacing="0" width="100%" style="background-image: url(images/default/fondocontenido.jpg)" class="tablaComun">
                <tr>
                    <th colspan="2" class="thtablaComun">
                        &nbsp;Parámetros del reporte de estatus de los proyectos</th>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 30%;">
                        Año de la convocatoria</td>
                    <td style="width: 70%;">
                        <asp:DropDownList ID="ddlAnioConvocatoriaRepEst" runat="server" DataSourceID="odsAnioConvocatoriaRepEst"
                            DataTextField="AnioDesc" DataValueField="Anio">
                        </asp:DropDownList><asp:ObjectDataSource ID="odsAnioConvocatoriaRepEst" runat="server"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="dsAppTableAdapters.spAnioConvocatoriaDDLBuscarTableAdapter">
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:UpdatePanel id="updpTipoApoyoEstatus" runat="server">
                            <contenttemplate>
<table cellspacing="0" cellpadding="3" width="100%" border="0">
    <tr>
        <td style="WIDTH: 30%">
            Tipo de financiamiento</td>
        <td style="WIDTH: 70%">
            <asp:DropDownList id="ddlTipoApoyoRepEst" runat="server" DataTextField="DesTipoApoyo" DataSourceID="odsTipoApoyoRepEst" DataValueField="CveTipoApoyo" AutoPostBack="True">
            </asp:DropDownList><asp:ObjectDataSource id="odsTipoApoyoRepEst" runat="server" TypeName="dsAppTableAdapters.spTipoApoyoDDLTableAdapter" SelectMethod="GetDataTipoApoyoBuscar" OldValuesParameterFormatString="original_{0}">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td style="WIDTH: 30%">
            Estatus del proyecto</td>
        <td style="WIDTH: 70%">
            <asp:DropDownList id="ddlEstatusRepEst" runat="server" DataTextField="DesEstatus" DataSourceID="odsEstatusRepEst" DataValueField="CveEstatus">
            </asp:DropDownList><asp:ObjectDataSource id="odsEstatusRepEst" runat="server" TypeName="dsAppTableAdapters.spEstatusDDLTableAdapter" SelectMethod="GetDataByTipoApoyoBuscar" OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlTipoApoyoRepEst" Name="CveTipoApoyo" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
</table>
</contenttemplate>
                        </asp:UpdatePanel></td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Región</td>
                    <td style="width: 70%">
                        <asp:DropDownList ID="ddlRegionRepEst" runat="server" DataSourceID="odsRegionRepEst" DataTextField="DesRegion"
                            DataValueField="CveRegion">
                        </asp:DropDownList><asp:ObjectDataSource ID="odsRegionRepEst" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetDataRegionBuscar" TypeName="dsAppTableAdapters.spRegionDDLTableAdapter">
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td >
                    </td>
                    <td>
                        <asp:ImageButton ID="ibtnReporteRepEst" runat="server" ImageUrl="~/images/aplicacion/btnReporte.gif" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewFiltrarFinancieros" runat="server">
            <table border="0" cellpadding="3" cellspacing="0" width="100%" style="background-image: url(images/default/fondocontenido.jpg)" class="tablaComun">
                <tr>
                    <th colspan="2" class="thtablaComun">
                        &nbsp;Parámetros de los reportes financieros</th>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:UpdatePanel id="updpParametros" runat="server">
                            <contenttemplate>
                                <table cellspacing="0" cellpadding="3" width="100%" border="0">
                                    <tr>
                                        <td style="width: 30%">
                                            Tipo de Reporte</td>
                                        <td style="width: 70%">
                                            <asp:DropDownList ID="ddlTipoReporte" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoReporte_SelectedIndexChanged">
                                                <asp:ListItem Selected="True" Value="2">Pagos programados</asp:ListItem>
                                                <asp:ListItem Value="3">Estado de cuenta</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Panel ID="pnlParRepPagosProg" runat="server" Height="100%" Width="100%">
                                                <table border="0" cellpadding="3" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="width: 30%">
                                                            Fecha inicial</td>
                                                        <td style="width: 70%">
                                                            <cc1:DatePicker ID="dtpkFechaInicialRepFin" runat="server" ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" />
                                                            <asp:RequiredFieldValidator ID="rfvFechaInicioRepFin" runat="server" ControlToValidate="dtpkFechaInicialRepFin"
                                                                ErrorMessage="Indique la fecha inicial" ForeColor="" ToolTip="Indique la fecha inicial">x</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 30%">
                                                            Fecha final</td>
                                                        <td style="width: 70%">
                                                            <cc1:DatePicker ID="dtpkFechaFinalRepFin" runat="server" ExpandButtonImage="~/images/aplicacion/show-calendar1.gif" />
                                                            <asp:RequiredFieldValidator ID="rfvFechaFinalRepFin" runat="server" ControlToValidate="dtpkFechaFinalRepFin"
                                                                ErrorMessage="Indique la fecha final" ForeColor="" ToolTip="Indique la fecha final">x</asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 30%">
                                                            Estatus del pago</td>
                                                        <td style="width: 70%">
                                                            <asp:DropDownList ID="ddlEstatusPagoRepFin" runat="server">
                                                                <asp:ListItem Value="-1">- TODOS -</asp:ListItem>
                                                                <asp:ListItem Value="1">Sin pagar</asp:ListItem>
                                                                <asp:ListItem Value="2">Pagados</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Panel ID="pnlEdoCuentaRepFin" runat="server" Height="100%" Width="100%" Visible="False"><table border="0" cellpadding="3" cellspacing="0" width="100%">
                                                <tr>
                                                    <td style="width: 30%">
                                                        Año de la convocatoria</td>
                                                    <td style="width: 70%">
                                                        <asp:DropDownList ID="ddlAnioConvRepFin" runat="server" DataSourceID="odsAnioConvocatoriaRepEst"
                                                            DataTextField="AnioDesc" DataValueField="Anio">
                                                        </asp:DropDownList></td>
                                                </tr>
                                            </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">
                    </td>
                    <td style="width: 70%">
                        <asp:ValidationSummary ID="vsErroresRepFin" runat="server" DisplayMode="List" ForeColor="" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" >
                    </td>
                    <td style="width: 70%">
                        <asp:ImageButton ID="ibtnMostrarReporteRepFin" runat="server" ImageUrl="~/images/aplicacion/btnReporte.gif" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewFiltrarAcumulado" runat="server">
            <table border="0" cellpadding="3" cellspacing="0" width="100%" style="background-image: url(images/default/fondocontenido.jpg)" class="tablaComun">
                <tr>
                    <th colspan="2" class="thtablaComun">
                        &nbsp;Parámetros del reporte acumulado de proyectos</th>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Agrupar por</td>
                    <td style="width: 70%">
                        <asp:CheckBoxList ID="chkblAgruparRepAcu" runat="server" RepeatColumns="4">
                            <asp:ListItem Value="APOYO">Tipo de apoyo</asp:ListItem>
                            <asp:ListItem Value="REGION">Regi&#243;n</asp:ListItem>
                            <asp:ListItem Value="TIPO">Tipo de proyecto</asp:ListItem>
                            <asp:ListItem Value="ESCALA">Escala</asp:ListItem>
                            <asp:ListItem Value="INSTITUCION">Instituci&#243;n</asp:ListItem>
                            <asp:ListItem Value="VEGETACION">Vegetaci&#243;n</asp:ListItem>
                            <asp:ListItem Value="TEMATICA">&#193;rea tem&#225;tica</asp:ListItem>
                            <asp:ListItem Value="ESTATUS">Estatus</asp:ListItem>
                            <asp:ListItem Value="RTECNICO">Responsable Técnico</asp:ListItem>
                        </asp:CheckBoxList>
                        <asp:CustomValidator ID="cuvAgruparPorRepAcu" runat="server" ControlToValidate="ddlAnioConvRepAcu"
                            ErrorMessage="Debe seleccionar al menos un valor de agrupación" ForeColor=""
                            ToolTip="Debe seleccionar al menos un valor de agrupación">x</asp:CustomValidator></td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Año de la convocatoria</td>
                    <td style="width: 70%">
                        <asp:DropDownList ID="ddlAnioConvRepAcu" runat="server" DataSourceID="odsAnioConvocatoriaRepEst"
                                                            DataTextField="AnioDesc" DataValueField="Anio">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Región</td>
                    <td style="width: 70%">
                        <asp:DropDownList ID="ddlRegionRepAcu" runat="server" DataSourceID="odsRegionRepEst" DataTextField="DesRegion"
                            DataValueField="CveRegion">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 30%">
                    </td>
                    <td style="width: 70%">
                        <asp:ValidationSummary ID="vsErroresRepAcu" runat="server" DisplayMode="List" ForeColor="" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" >
                    </td>
                    <td style="width: 70%">
                        <asp:ImageButton ID="ibtnMostrarReporteRepAcu" runat="server" ImageUrl="~/images/aplicacion/btnReporte.gif" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewFiltrarProductos" runat="server">
            <table border="0" cellpadding="3" cellspacing="0" width="100%" style="background-image: url(images/default/fondocontenido.jpg)" class="tablaComun">
                <tr>
                    <th colspan="2" class="thtablaComun">
                        &nbsp;Parámetros del reporte de estatus de los productos</th>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 30%;">
                        Año de la convocatoria</td>
                    <td style="width: 70%;">
                        <asp:DropDownList ID="ddlAnioConvRepPro" runat="server" DataSourceID="odsAnioConvocatoriaRepEst"
                            DataTextField="AnioDesc" DataValueField="Anio">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Tipo de financiamiento</td>
                    <td style="width: 70%">
                        <asp:DropDownList id="ddlTipoApoyoRepPro" runat="server" DataTextField="DesTipoApoyo" DataSourceID="odsTipoApoyoRepPro" DataValueField="CveTipoApoyo">
                        </asp:DropDownList>
                        <asp:ObjectDataSource id="odsTipoApoyoRepPro" runat="server" TypeName="dsAppTableAdapters.spTipoApoyoDDLTableAdapter" SelectMethod="GetDataTipoApoyoBuscar" OldValuesParameterFormatString="original_{0}">
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Area temática</td>
                    <td style="width: 70%">
                        <asp:DropDownList ID="ddlAreaTematicaRepPro" runat="server" DataSourceID="odsAreaTematicaRepPro" DataTextField="AreaTematica"
                            DataValueField="CveAreaTematica">
                        </asp:DropDownList><asp:ObjectDataSource ID="odsAreaTematicaRepPro" runat="server"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataAreaTematicaBuscar"
                            TypeName="dsAppTableAdapters.spAreaTematicaDDLTableAdapter"></asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Estatus</td>
                    <td style="width: 70%">
                        <asp:DropDownList ID="ddlEstatusRepPro" runat="server">
                            <asp:ListItem Value="-1">- TODOS -</asp:ListItem>
                            <asp:ListItem Value="1">Entregados</asp:ListItem>
                            <asp:ListItem Value="0">No entregados</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td >
                    </td>
                    <td>
                        <asp:ImageButton ID="ibtnMostrarReporteRepPro" runat="server" ImageUrl="~/images/aplicacion/btnReporte.gif" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewFiltrarDescargas" runat="server">
            <table border="0" cellpadding="3" cellspacing="0" width="100%" style="background-image: url(images/default/fondocontenido.jpg)" class="tablaComun">
                <tr>
                    <th colspan="2" class="thtablaComun">
                        &nbsp;Reporte de descargas de archivos de productos</th>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <%--<tr>
                    <td style="width: 30%;">
                        Número de productos a mostrar</td>
                    <td style="width: 70%;">
                        &nbsp;<asp:TextBox ID="txtNumProductos" runat="server" MaxLength="10">20</asp:TextBox><asp:RegularExpressionValidator ID="revNumProductos" runat="server" ControlToValidate="txtNumProductos"
                            ErrorMessage="Solo se admite un valor numérico" ForeColor="" ToolTip="Solo se admite un valor numérico" ValidationExpression="^[0-9]{1,10}">Solo se admite un valor numérico</asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>--%>
                <tr>
                    <td >
                    </td>
                    <td>
                        <asp:ImageButton ID="imgbMostrarRepDesc" runat="server" ImageUrl="~/images/aplicacion/btnReporte.gif" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewFiltrarUsuarios" runat="server">
            <table border="0" cellpadding="3" cellspacing="0" width="100%" style="background-image: url(images/default/fondocontenido.jpg)" class="tablaComun">
                <tr>
                    <th colspan="2" class="thtablaComun">
                        &nbsp;Parámetros del reporte de usuarios</th>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Estado</td>
                    <td style="width: 70%">
                        <asp:DropDownList ID="ddlEstadoRepUsr" runat="server" DataSourceID="odsEstado"
                                                            DataTextField="DesEstado" DataValueField="CveEstado">
                        </asp:DropDownList><asp:ObjectDataSource ID="odsEstado" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetDataCatEstadoBusqueda" TypeName="dsAppTableAdapters.CatEstadoTableAdapter">
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Uso de la información</td>
                    <td style="width: 70%">
                        <asp:DropDownList ID="ddlUsoInfoRepUsr" runat="server" DataSourceID="odsUsoInfo" DataTextField="DesUsoInfo"
                            DataValueField="CveUsoInfo">
                        </asp:DropDownList><asp:ObjectDataSource ID="odsUsoInfo" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetDataCatUsoInformacionBusqueda" TypeName="dsAppTableAdapters.spUsoInformacionDDLTableAdapter">
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">
                    </td>
                    <td style="width: 70%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 30%" >
                    </td>
                    <td style="width: 70%">
                        <asp:ImageButton ID="imgbMostrarRepUsr" runat="server" ImageUrl="~/images/aplicacion/btnReporte.gif" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewFiltrarBeneficiarios" runat="server">
            <table border="0" cellpadding="3" cellspacing="0" width="100%" style="background-image: url(images/default/fondocontenido.jpg)" class="tablaComun">
                <tr><th colspan="2" class="thtablaComun">&nbsp;Parámetros del reporte de beneficiarios</th></tr>
                <tr><td colspan="2">&nbsp;</td></tr>
                <tr><td colspan="2">Proyectos con un número de beneficiarios...</td></tr>                
                <tr><td style="width: 10%; text-align:right;">Desde:</td>
                    <td style="width: 90%"><asp:TextBox ID="txtBeneficiariosDesde" runat="server" Width="40px" Text="0" /></td>
                </tr>
                <tr>
                    <td style="width: 10%; text-align:right;">Hasta:</td>
                    <td style="width: 90%"><asp:TextBox ID="txtBeneficiariosHasta" runat="server" Width="40px" Text="130" /></td>
                </tr>
                <tr>
                    <td style="width: 10%" ></td>
                    <td style="width: 90%"><asp:ImageButton ID="imgbMostrarRepBen" runat="server" ImageUrl="~/images/aplicacion/btnReporte.gif" /></td>
                </tr>
            </table>
        </asp:View>        
        <asp:View ID="viewFiltrarInfraestructura" runat="server">
            <table border="0" cellpadding="3" cellspacing="0" width="100%" style="background-image: url(images/default/fondocontenido.jpg)" class="tablaComun">
                <tr>
                    <th colspan="2" class="thtablaComun">
                        &nbsp;Parámetros del reporte de Infraestructura comprada</th>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Nombre del proyecto</td>
                    <td style="width: 70%">
                        <asp:TextBox ID="txtProyectoRepInfra" runat="server" Columns="80" MaxLength="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Institución</td>
                    <td style="width: 70%">
                        <asp:DropDownList ID="ddlInstitucionRepInfra" runat="server" DataSourceID="odsInstitucionRepInfra" DataTextField="DesInstitucion" DataValueField="CveInstitucion">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="odsInstitucionRepInfra" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataInstitucionBuscar" TypeName="dsAppTableAdapters.spInstitucionDDLTableAdapter"></asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Región</td>
                    <td style="width: 70%">
                        <asp:DropDownList ID="ddlRegionRepInfra" runat="server" DataSourceID="odsRegionRepInfra" DataTextField="DesRegion"
                            DataValueField="CveRegion">
                        </asp:DropDownList><asp:ObjectDataSource ID="odsRegionRepInfra" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetDataRegionBuscar" TypeName="dsAppTableAdapters.spRegionDDLTableAdapter">
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td >
                    </td>
                    <td>
                        <asp:ImageButton ID="ibtnReporteRepInfra" runat="server" ImageUrl="~/images/aplicacion/btnReporte.gif" /></td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView><CR:CrystalReportViewer ID="crvwReportes" runat="server" AutoDataBind="true" />
    <CR:CrystalReportSource ID="crsrReportes" runat="server">
    </CR:CrystalReportSource>

</asp:Content>

