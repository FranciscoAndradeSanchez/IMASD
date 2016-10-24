Imports System.Data
Partial Class RegistroProyectos
    Inherits System.Web.UI.Page

#Region "Definiciones"
    Private Const PathProducts As String = "~/Productos/"

    Private Property CurrentCveProyecto() As String
        Get
            Dim o As Object = ViewState("CurrentCveProyecto")
            If o Is Nothing Then
                Return "-1"
            Else
                Return CType(o, String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("CurrentCveProyecto") = value
        End Set
    End Property

    Private Property CurrentCveEtapa() As Integer
        Get
            Dim o As Object = ViewState("CurrentCveEtapa")
            If o Is Nothing Then
                Return -1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("CurrentCveEtapa") = value
        End Set
    End Property

    Private Property CurrentCveAsunto() As Integer
        Get
            Dim o As Object = ViewState("CurrentCveAsunto")
            If o Is Nothing Then
                Return -1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("CurrentCveAsunto") = value
        End Set
    End Property

    Private Property CurrentCveVisita() As Integer
        Get
            Dim o As Object = ViewState("CurrentCveVisita")
            If o Is Nothing Then
                Return -1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("CurrentCveVisita") = value
        End Set
    End Property

    Private ReadOnly Property TotalRowCount() As Integer
        Get
            Dim taProyectos As New dsAppTableAdapters.ProyectoTableAdapter
            Return taProyectos.CuentaTotalProyectosFiltrado(textoBusqueda, CveProyectoBuscar, CveTipoApoyoBuscar, CveEstatusBuscar, _
                                                            CveRegionBuscar, AnioConvBuscar, CveInstitucionBuscar)
        End Get
    End Property

    Private Sub ClearFieldAdding()
        txtCveCONACYT.Text = String.Empty
        ddlTipoApoyoAdd.SelectedIndex = -1
        txtNombreAdd.Text = String.Empty
        ddlAnioConvAdd.SelectedIndex = -1
        ddlInstitucionAdd.SelectedIndex = -1
        ddlTipoProyectoAdd.SelectedIndex = -1
        txtResumenAdd.Text = String.Empty
        ddlRegionSegAdd.SelectedIndex = -1
        ddlEscalaAdd.SelectedIndex = -1
        ddlVegetacionAdd.SelectedIndex = -1
        txtMetodologiaAdd.Text = String.Empty
        ddlEstatusAdd.SelectedIndex = -1
        txtDemandaAdd.Text = String.Empty
        CType(uppaFechaConvenioAcuerdoAdd.FindControl("dpkrFechaConvAcueAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        ddlEcosistemaAdd.SelectedIndex = -1
        txtResEsperadosAdd.Text = String.Empty
        txtDemandanteAdd.Text = String.Empty
        txtIdentProblemaAdd.Text = String.Empty
        ddlAreaTematicaAdd.SelectedIndex = -1
        txtCoberturaOperativaAdd.Text = String.Empty
        txtImpactosEsperadosAdd.Text = String.Empty
        ddlSectorUsuarioTTAdd.SelectedIndex = -1
        txtMaterialesTTAdd.Text = String.Empty
        txtUsuarioTTAdd.Text = String.Empty
        txtRequisitosTTAdd.Text = String.Empty
        txtActividadesTTAdd.Text = String.Empty
        txtObjetivoGralAdd.Text = String.Empty
        txtObjetivosEspAdd.Text = String.Empty
        ddlResponsableTecnicoAdd.ClearSelection()
        txtCostoTotalProyectoAdd.Text = "0"
        txtAportacionApoyoInstitucionalAdd.Text = "0"
        txtAportacionInstitucionEjecutoraAdd.Text = "0"
        txtAportacionesOtrasAdd.Text = "0"
    End Sub

    Public ReadOnly Property ValExpTipoApoyo() As String
        Get
            Dim taTipoApoyo As New dsAppTableAdapters.CatTipoApoyoTableAdapter
            Return taTipoApoyo.expRegTipoApoyo
        End Get
    End Property

    Public ReadOnly Property ValExpRegion() As String
        Get
            Dim taRegion As New dsAppTableAdapters.CatRegionTableAdapter
            Return taRegion.ExpRegRegion
        End Get
    End Property

    Public ReadOnly Property ValExpEstado() As String
        Get
            Dim taEstado As New dsAppTableAdapters.spEstadoDDLTableAdapter
            Return taEstado.ExpresionRegularEstado
        End Get
    End Property

    Public ReadOnly Property ValExpMunicipio(ByVal CveEstado As String) As String
        Get
            Dim taMunicipio As New dsAppTableAdapters.spMunicipioDDLPorEstadoTableAdapter
            Return taMunicipio.ExpresionRegularMunicipioPorEstado(CveEstado)
        End Get
    End Property

    Private Sub EstablecerPermisos()
        If (Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) IsNot Nothing) Then
            Select Case CInt(Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoNivel").ToString))
                Case clsAuthentication.AuthorizationLevelList.Administering
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).Visible = True
                    '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).Visible = True
                Case clsAuthentication.AuthorizationLevelList.Financial
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnActualizarEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnInfraestructuraEdt"), ImageButton).Visible = True

                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).Visible = True

                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).Visible = False
                    '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).Visible = False

                    
                Case clsAuthentication.AuthorizationLevelList.LimitedUpdating
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).Visible = True
                    '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).Visible = True
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).Visible = False
                Case clsAuthentication.AuthorizationLevelList.Consulting
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).Visible = False
                    '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).Visible = False
                Case Else
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).Visible = False
                    '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).Visible = False
                    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).Visible = False
            End Select
        End If

    End Sub

#End Region

#Region "EventosPagina"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            If (Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) IsNot Nothing) Then
                Select Case CInt(Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoNivel").ToString))
                    Case clsAuthentication.AuthorizationLevelList.Administering
                        ibtnNuevoDw.Visible = True
                        ibtnNuevoUp.Visible = True
                    Case clsAuthentication.AuthorizationLevelList.Financial
                        ibtnNuevoDw.Visible = False
                        ibtnNuevoUp.Visible = False
                    Case clsAuthentication.AuthorizationLevelList.LimitedUpdating
                        ibtnNuevoDw.Visible = True
                        ibtnNuevoUp.Visible = True
                    Case clsAuthentication.AuthorizationLevelList.Consulting
                        ibtnNuevoDw.Visible = False
                        ibtnNuevoUp.Visible = False
                    Case Else
                        ibtnNuevoDw.Visible = False
                        ibtnNuevoUp.Visible = False
                End Select
            End If
            StartRowIndex = 1
            Me.mviewProyectos.SetActiveView(Me.viewLista)
            revTipoApoyoAdd.ValidationExpression = ValExpTipoApoyo
            revRegionSegAdd.ValidationExpression = ValExpRegion
        End If
    End Sub

#End Region

#Region "Paginacion"

    Private Sub GoToFirstPage()
        StartRowIndex = 1
        PageIndex = 1
        dtlProyectos.SelectedIndex = -1
        dtlProyectos.EditItemIndex = -1
        dtlProyectos.DataBind()
    End Sub

    Private Sub GoToPreviousPage()
        StartRowIndex -= MaximumRows
        PageIndex = (StartRowIndex \ MaximumRows) + 1
        dtlProyectos.SelectedIndex = -1
        dtlProyectos.EditItemIndex = -1
        dtlProyectos.DataBind()
    End Sub

    Private Sub GoToNextPage()
        StartRowIndex += MaximumRows
        PageIndex = (StartRowIndex \ MaximumRows) + 1
        dtlProyectos.SelectedIndex = -1
        dtlProyectos.EditItemIndex = -1
        dtlProyectos.DataBind()
    End Sub

    Private Sub GoToLastPage()
        'Entra el Polo
        'StartRowIndex = ((TotalRowCount - 1) \ MaximumRows) * MaximumRows
        StartRowIndex = ((TotalRowCount - 1) \ MaximumRows) * MaximumRows + 1
        'Sale el Polo
        PageIndex = (StartRowIndex \ MaximumRows) + 1
        dtlProyectos.SelectedIndex = -1
        dtlProyectos.EditItemIndex = -1
        dtlProyectos.DataBind()
    End Sub

    Private Sub EnableNavigation()

        lnkbPrimeraUp.Visible = StartRowIndex > MaximumRows
        lnkbAnteriorUp.Visible = StartRowIndex > MaximumRows
        lnkbPrimeraDw.Visible = StartRowIndex > MaximumRows
        lnkbAnteriorDw.Visible = StartRowIndex > MaximumRows

        Dim LastPageStartRowIndex As Integer = _
            ((TotalRowCount - 1) \ MaximumRows) * MaximumRows
        lnkbSiguienteUp.Visible = (StartRowIndex < LastPageStartRowIndex)
        lnkbUltimaUp.Visible = (StartRowIndex < LastPageStartRowIndex)
        lnkbSiguienteDw.Visible = (StartRowIndex < LastPageStartRowIndex)
        lnkbUltimaDw.Visible = (StartRowIndex < LastPageStartRowIndex)

        lblTotalProyectosUP.Text = String.Format("{0} proyectos encontrados", TotalRowCount)
        lblTotalProyectosDW.Text = String.Format("{0} proyectos encontrados", TotalRowCount)
        lblPaginaActualUP.Text = String.Format("Página {0} de {1}", PageIndex, (TotalRowCount \ MaximumRows) + 1)
        lblPaginaActualDW.Text = String.Format("Página {0} de {1}", PageIndex, (TotalRowCount \ MaximumRows) + 1)

        'Entra el Polo
        Dim cuantasPaginas As Integer = (TotalRowCount \ MaximumRows) + 1
        paginadorLVC(PageIndex, cuantasPaginas)
        'Sale el Polo

    End Sub

    'Entra el Polo
    Private Sub paginadorLVC(ByVal pagi As Integer, ByVal totpagi As Integer)
        Try
            'Limpia el contenido en el DropDownList
            ddlPaginadorLVC.Items.Clear()
            Dim iLVC As Integer
            For iLVC = 1 To totpagi
                'Agrega valores al DropDownList
                ddlPaginadorLVC.Items.Add(iLVC)
            Next
            'Encuentra el valor de la página actual para seleccionarlo en el DropDownList
            ddlPaginadorLVC.SelectedIndex = ddlPaginadorLVC.Items.IndexOf(ddlPaginadorLVC.Items.FindByValue(pagi))
        Catch exLVC As Exception
            'Si hay algun error, que no haga nada... no es importante
            'Response.Write(exLVC.Message)
        End Try
    End Sub
    'Sale el Polo

    Private Property StartRowIndex() As Integer
        Get
            Dim o As Object = ViewState("StartRowIndex")
            If o Is Nothing Then
                Return 1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("StartRowIndex") = value
        End Set
    End Property

    Private Property MaximumRows() As Integer
        Get
            Dim o As Object = ViewState("MaximumRows")
            If o Is Nothing Then
                Return 10
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("MaximumRows") = value
        End Set
    End Property

    Private Property PageIndex() As Integer
        Get
            Dim o As Object = ViewState("PageIndex")
            If o Is Nothing Then
                Return 1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("PageIndex") = value
        End Set
    End Property

    Private Property PagesPerGroup() As Integer
        Get
            Dim o As Object = ViewState("PagesPerGroup")
            If o Is Nothing Then
                Return 15
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("PagesPerGroup") = value
        End Set
    End Property

    Protected Sub lnkbPrimeraUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbPrimeraUp.Click
        GoToFirstPage()
    End Sub

    Protected Sub lnkbAnteriorUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbAnteriorUp.Click
        GoToPreviousPage()
    End Sub

    Protected Sub lnkbSiguienteUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbSiguienteUp.Click
        GoToNextPage()
    End Sub

    Protected Sub lnkbUltimaUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbUltimaUp.Click
        GoToLastPage()
    End Sub

    Protected Sub lnkbPrimeraDw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbPrimeraDw.Click
        GoToFirstPage()
    End Sub

    Protected Sub lnkbAnteriorDw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbAnteriorDw.Click
        GoToPreviousPage()
    End Sub

    Protected Sub lnkbSiguienteDw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbSiguienteDw.Click
        GoToNextPage()
    End Sub

    Protected Sub lnkbUltimaDw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbUltimaDw.Click
        GoToLastPage()
    End Sub

    'Entra el Polo
    Protected Sub directoPagina(ByVal sender As Object, ByVal e As System.EventArgs)
        PageIndex = ddlPaginadorLVC.SelectedItem.Value
        StartRowIndex = PageIndex * MaximumRows - MaximumRows + 1
        dtlProyectos.SelectedIndex = -1
        dtlProyectos.EditItemIndex = -1
        dtlProyectos.DataBind()
    End Sub
    'Sale el Polo

#End Region

#Region "Busqueda"

    Private Property textoBusqueda() As String
        Get
            Dim o As Object = ViewState("textoBusqueda")
            If o Is Nothing Then
                Return String.Empty
            Else
                Return CType(o, String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("textoBusqueda") = value
        End Set
    End Property

    Private Property CveProyectoBuscar() As String
        Get
            Dim o As Object = ViewState("CveProyectoBuscar")
            If o Is Nothing Then
                Return String.Empty
            Else
                Return CType(o, String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("CveProyectoBuscar") = value
        End Set
    End Property

    Private Property CveTipoApoyoBuscar() As String
        Get
            Dim o As Object = ViewState("CveTipoApoyoBuscar")
            If o Is Nothing Then
                Return "--"
            Else
                Return CType(o, String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("CveTipoApoyoBuscar") = value
        End Set
    End Property

    Private Property CveEstatusBuscar() As Integer
        Get
            Dim o As Object = ViewState("CveEstatusBuscar")
            If o Is Nothing Then
                Return -1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("CveEstatusBuscar") = value
        End Set
    End Property

    Private Property CveRegionBuscar() As String
        Get
            Dim o As Object = ViewState("CveRegionBuscar")
            If o Is Nothing Then
                Return "---"
            Else
                Return CType(o, String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("CveRegionBuscar") = value
        End Set
    End Property

    Private Property AnioConvBuscar() As Integer
        Get
            Dim o As Object = ViewState("AnioConvBuscar")
            If o Is Nothing Then
                Return 1900
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("AnioConvBuscar") = value
        End Set
    End Property

    Private Property CveInstitucionBuscar() As Integer
        Get
            Dim o As Object = ViewState("CveInstitucionBuscar")
            If o Is Nothing Then
                Return -1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("CveInstitucionBuscar") = value
        End Set
    End Property

    Protected Sub lnkbMasOpciones_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        pnlMasOpcionesBusqueda.Visible = Not pnlMasOpcionesBusqueda.Visible
        ibtnBuscarProyectos.Visible = Not pnlMasOpcionesBusqueda.Visible
        If pnlMasOpcionesBusqueda.Visible Then
            lnkbMasOpciones.Text = "- ocultar opciones"
        Else
            lnkbMasOpciones.Text = "+ mas opciones ..."
        End If
        txtCveCONACYTBuscar.Text = String.Empty
        ddlTipoApoyoBuscar.SelectedValue = "--"
        ddlEstatusBuscar.SelectedValue = -1
        ddlRegionSegBuscar.SelectedValue = "---"
        ddlAnioProyectoBuscar.SelectedValue = 1900
        ddlInstitucionBuscar.SelectedValue = -1
        textoBusqueda = txtBusqueda.Text
        CveProyectoBuscar = String.Empty
        CveTipoApoyoBuscar = "--"
        CveEstatusBuscar = -1
        CveRegionBuscar = "---"
        AnioConvBuscar = 1900
        CveInstitucionBuscar = -1
        dtlProyectos.DataBind()
    End Sub

    Protected Sub ibtnBuscarProyectos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnBuscarProyectos.Click, ibtnBuscarProyectosMas.Click
        StartRowIndex = 1
        MaximumRows = 10
        textoBusqueda = txtBusqueda.Text
        If Me.pnlMasOpcionesBusqueda.Visible Then
            CveProyectoBuscar = txtCveCONACYTBuscar.Text
            CveTipoApoyoBuscar = ddlTipoApoyoBuscar.SelectedValue
            CveEstatusBuscar = ddlEstatusBuscar.SelectedValue
            CveRegionBuscar = ddlRegionSegBuscar.SelectedValue
            AnioConvBuscar = ddlAnioProyectoBuscar.SelectedValue
            CveInstitucionBuscar = ddlInstitucionBuscar.SelectedValue
            dtlProyectos.SelectedIndex = -1
            dtlProyectos.EditItemIndex = -1
        Else
            CveProyectoBuscar = String.Empty
            CveTipoApoyoBuscar = "--"
            CveEstatusBuscar = -1
            CveRegionBuscar = "---"
            AnioConvBuscar = 1900
            CveInstitucionBuscar = -1

        End If
        dtlProyectos.DataBind()
    End Sub

#End Region

#Region "Proyectos"

    Protected Sub dtlProyectos_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlProyectos.EditCommand
        CurrentCveProyecto = dtlProyectos.DataKeys(e.Item.ItemIndex)
        pnlBusqueda.Visible = False
        pnlNavegacionUp.Visible = False
        pnlNavegacionDw.Visible = False
        odsProyecto.FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(e.Item.ItemIndex).ToString & "'"
        dtlProyectos.EditItemIndex = 0
        dtlProyectos.DataBind()
        EstablecerPermisos()
    End Sub

    Protected Sub dtlProyectos_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlProyectos.CancelCommand
        CurrentCveProyecto = "-1"
        pnlBusqueda.Visible = True
        pnlNavegacionUp.Visible = True
        pnlNavegacionDw.Visible = True
        odsProyecto.FilterExpression = String.Empty
        dtlProyectos.SelectedIndex = -1
        dtlProyectos.EditItemIndex = -1
        dtlProyectos.DataBind()
    End Sub

    Protected Sub dtlProyectos_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlProyectos.UpdateCommand
        Dim taProyecto As New dsAppTableAdapters.ProyectoTableAdapter
        Dim taObjeto As New dsAppTableAdapters.CatObjetoTableAdapter
        Dim dtFehcaCaptura As Date

        Try

            If (IsDBNull(CType(e.Item.FindControl("hdnfFechaCapturaEdt"), HiddenField).Value)) Or _
                (CType(e.Item.FindControl("hdnfFechaCapturaEdt"), HiddenField).Value = String.Empty) Then
                dtFehcaCaptura = Date.Now
            Else
                dtFehcaCaptura = CDate(CType(e.Item.FindControl("hdnfFechaCapturaEdt"), HiddenField).Value)
            End If
            taProyecto.Update( _
                CType(e.Item.FindControl("ddlTipoApoyoEdt"), DropDownList).SelectedValue, _
                Date.Now, _
                dtFehcaCaptura, _
                CType(e.Item.FindControl("txtNombreEdt"), TextBox).Text, _
                CType(e.Item.FindControl("ddlAnioConvEdt"), DropDownList).SelectedValue, _
                CType(e.Item.FindControl("ddlInstitucionEdt"), DropDownList).SelectedValue, _
                CType(e.Item.FindControl("ddlTipoProyectoEdt"), DropDownList).SelectedValue, _
                CType(e.Item.FindControl("txtResumenEdt"), TextBox).Text, _
                CType(e.Item.FindControl("ddlRegionSegEdt"), DropDownList).SelectedValue, _
                CType(e.Item.FindControl("ddlEscalaEdt"), DropDownList).SelectedValue, _
                CType(e.Item.FindControl("ddlVegetacionEdt"), DropDownList).SelectedValue, _
                CType(e.Item.FindControl("txtMetodologiaEdt"), TextBox).Text, _
                CType(e.Item.FindControl("ddlEstatusEdt"), DropDownList).SelectedValue, _
                CInt(taObjeto.GetCveObjetoByCveTipoApoyo(CType(e.Item.FindControl("ddlTipoProyectoEdt"), DropDownList).SelectedValue)), _
                CType(e.Item.FindControl("txtDemandaEdt"), TextBox).Text, _
                CType(e.Item.FindControl("uppaFechaConvenioAcuerdoEdt").FindControl("dpkrFechaConvAcueEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text, _
                CType(e.Item.FindControl("ddlEcosistemaEdt"), DropDownList).SelectedValue, _
                CType(e.Item.FindControl("txtResEsperadosEdt"), TextBox).Text, _
                CType(e.Item.FindControl("txtDemandanteEdt"), TextBox).Text, _
                CType(e.Item.FindControl("txtIdentProblemaEdt"), TextBox).Text, _
                CType(e.Item.FindControl("ddlAreaTematicaEdt"), DropDownList).SelectedValue, _
                CType(e.Item.FindControl("txtCoberturaOperativaEdt"), TextBox).Text, _
                CType(e.Item.FindControl("txtImpactosEsperadosEdt"), TextBox).Text, _
                CType(e.Item.FindControl("ddlSectorUsuarioTTEdt"), DropDownList).SelectedValue, _
                CType(e.Item.FindControl("txtMaterialesTTEdt"), TextBox).Text, _
                CType(e.Item.FindControl("txtUsuarioTTEdt"), TextBox).Text, _
                CType(e.Item.FindControl("txtRequisitosTTEdt"), TextBox).Text, _
                CType(e.Item.FindControl("txtActividadesTTEdt"), TextBox).Text, _
                CType(e.Item.FindControl("txtObjetivoGralEdt"), TextBox).Text, _
                CType(e.Item.FindControl("txtObjetivosEspEdt"), TextBox).Text, _
                CType(e.Item.FindControl("ddlResponsableTecnicoEdt"), DropDownList).SelectedValue, _
                CSng(CType(e.Item.FindControl("txtCostoTotalProyectoEdt"), TextBox).Text), _
                CSng(CType(e.Item.FindControl("txtAportacionApoyoInstitucionalEdt"), TextBox).Text), _
                CSng(CType(e.Item.FindControl("txtAportacionInstitucionEjecutoraEdt"), TextBox).Text), _
                CSng(CType(e.Item.FindControl("txtAportacionesOtrasEdt"), TextBox).Text), _
                dtlProyectos.DataKeys(e.Item.ItemIndex).ToString _
                )
            dtlProyectos.EditItemIndex = -1
            dtlProyectos.DataBind()

        Catch concurrencyEx As DBConcurrencyException
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "Fila no accesible"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "Restricción no válida"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "Expresión no válida"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "Error de datos"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "Error de datos"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(e.Item.FindControl("cuvExcepcionesEdt"), CustomValidator).IsValid = False
        Finally
            taProyecto.Dispose()
            taObjeto.Dispose()
        End Try
    End Sub

    Protected Sub ibtnNuevoUp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnNuevoUp.Click
        mviewProyectos.SetActiveView(viewAgregar)
    End Sub

    Protected Sub ibtnNuevoDw_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnNuevoDw.Click
        mviewProyectos.SetActiveView(viewAgregar)
    End Sub

    Protected Sub ibtnCancelarAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnCancelarAdd.Click
        dtlProyectos.EditItemIndex = -1
        dtlProyectos.DataBind()
        ClearFieldAdding()
        mviewProyectos.SetActiveView(viewLista)
    End Sub

    Protected Sub dtlProyectos_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlProyectos.DeleteCommand
        Dim taProyecto As New dsAppTableAdapters.ProyectoTableAdapter
        Try

            taProyecto.Delete(dtlProyectos.DataKeys(e.Item.ItemIndex))
            dtlProyectos.DataBind()

        Catch concurrencyEx As DBConcurrencyException

            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "Fila no accesible"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "Restricción no válida"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "Expresión no válida"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "Error de datos"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "Error de datos"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(e.Item.FindControl("cuvEliminar"), CustomValidator).IsValid = False
        Finally
            taProyecto.Dispose()
        End Try

    End Sub

    Protected Sub dtlProyectos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dtlProyectos.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse _
   e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim product As dsApp.ProyectoRow = _
                CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                           dsApp.ProyectoRow)

            Dim db As ImageButton = _
                CType(e.Item.FindControl("ibtnEliminarIT"), ImageButton)
            Dim ibtnEditar As ImageButton = _
                CType(e.Item.FindControl("ibtnEditarIT"), ImageButton)
            Dim txtValidar As TextBox = CType(e.Item.FindControl("txtVal"), TextBox)

            If (Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) IsNot Nothing) Then
                Select Case CInt(Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoNivel").ToString))
                    Case clsAuthentication.AuthorizationLevelList.Administering
                        ibtnEditar.Visible = True
                        db.Visible = True
                        txtValidar.Visible = True
                    Case clsAuthentication.AuthorizationLevelList.Financial
                        ibtnEditar.Visible = True
                        db.Visible = False
                        txtValidar.Visible = False
                    Case clsAuthentication.AuthorizationLevelList.LimitedUpdating
                        ibtnEditar.Visible = True
                        db.Visible = False
                        txtValidar.Visible = False
                    Case clsAuthentication.AuthorizationLevelList.Consulting
                        ibtnEditar.Visible = False
                        db.Visible = False
                        txtValidar.Visible = False
                    Case Else
                        ibtnEditar.Visible = False
                        db.Visible = False
                        txtValidar.Visible = False
                End Select
            End If

            db.OnClientClick = String.Format( _
                "return confirm('¿Desea eliminar el proyecto {0}?');", _
                product.CveProyecto.Replace("'", "\'"))
        End If
    End Sub

    Protected Sub ibtnActualizarAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnActualizarAdd.Click
        Dim taProyecto As New dsAppTableAdapters.ProyectoTableAdapter
        Dim taObjeto As New dsAppTableAdapters.CatObjetoTableAdapter

        Try
            taProyecto.Insert( _
                txtCveCONACYT.Text, _
                ddlTipoApoyoAdd.SelectedValue, _
                Date.Now, _
                Date.Now, _
                txtNombreAdd.Text, _
                ddlAnioConvAdd.SelectedValue, _
                ddlInstitucionAdd.SelectedValue, _
                ddlTipoProyectoAdd.SelectedValue, _
                txtResumenAdd.Text, _
                ddlRegionSegAdd.SelectedValue, _
                ddlEscalaAdd.SelectedValue, _
                ddlVegetacionAdd.SelectedValue, _
                txtMetodologiaAdd.Text, _
                ddlEstatusAdd.SelectedValue, _
                CInt(taObjeto.GetCveObjetoByCveTipoApoyo(ddlTipoApoyoAdd.SelectedValue)), _
                txtDemandaAdd.Text, _
                CType(uppaFechaConvenioAcuerdoAdd.FindControl("dpkrFechaConvAcueAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text, _
                ddlEcosistemaAdd.SelectedValue, _
                txtResEsperadosAdd.Text, _
                txtDemandanteAdd.Text, _
                txtIdentProblemaAdd.Text, _
                ddlAreaTematicaAdd.SelectedValue, _
                txtCoberturaOperativaAdd.Text, _
                txtImpactosEsperadosAdd.Text, _
                ddlSectorUsuarioTTAdd.SelectedValue, _
                txtMaterialesTTAdd.Text, _
                txtUsuarioTTAdd.Text, _
                txtRequisitosTTAdd.Text, _
                txtActividadesTTAdd.Text, _
                txtObjetivoGralAdd.Text, _
                txtObjetivosEspAdd.Text, _
                CInt(ddlResponsableTecnicoAdd.SelectedValue), _
                CSng(txtCostoTotalProyectoAdd.Text), _
                CSng(txtAportacionApoyoInstitucionalAdd.Text), _
                CSng(txtAportacionInstitucionEjecutoraAdd.Text), _
                CSng(txtAportacionesOtrasAdd.Text) _
            )

            lblEstatusAdd.Text = "Proyecto ' " & txtCveCONACYT.Text & " ' insertado con éxito"
            lblEstatusAdd.Visible = True
            ClearFieldAdding()

        Catch concurrencyEx As DBConcurrencyException
            cuvExcepcionesAdd.ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            cuvExcepcionesAdd.ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            cuvExcepcionesAdd.IsValid = False
        Catch constraintEx As ConstraintException
            cuvExcepcionesAdd.ErrorMessage = "Error de llaves duplicadas"
            cuvExcepcionesAdd.ToolTip = "Error de llaves duplicadas"
            cuvExcepcionesAdd.IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            cuvExcepcionesAdd.ErrorMessage = "Fila no accesible"
            cuvExcepcionesAdd.ToolTip = "Fila no accesible"
            cuvExcepcionesAdd.IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            cuvExcepcionesAdd.ErrorMessage = "Nombre duplicado"
            cuvExcepcionesAdd.ToolTip = "Nombre duplicado"
            cuvExcepcionesAdd.IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            cuvExcepcionesAdd.ErrorMessage = "Fila esta siendo modificada"
            cuvExcepcionesAdd.ToolTip = "Fila esta siendo modificada"
            cuvExcepcionesAdd.IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            cuvExcepcionesAdd.ErrorMessage = "Restricción no válida"
            cuvExcepcionesAdd.ToolTip = "Restricción no válida"
            cuvExcepcionesAdd.IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            cuvExcepcionesAdd.ErrorMessage = "Expresión no válida"
            cuvExcepcionesAdd.ToolTip = "Expresión no válida"
            cuvExcepcionesAdd.IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            cuvExcepcionesAdd.ErrorMessage = "No se encontró una llave principal"
            cuvExcepcionesAdd.ToolTip = "No se encontró una llave principal"
            cuvExcepcionesAdd.IsValid = False
        Catch noNullEx As NoNullAllowedException
            cuvExcepcionesAdd.ErrorMessage = "Valor nulo no permitido"
            cuvExcepcionesAdd.ToolTip = "Valor nulo no permitido"
            cuvExcepcionesAdd.IsValid = False
        Catch readOnlyEx As ReadOnlyException
            cuvExcepcionesAdd.ErrorMessage = "La base de datos es de solo lectura"
            cuvExcepcionesAdd.ToolTip = "La base de datos es de solo lectura"
            cuvExcepcionesAdd.IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            cuvExcepcionesAdd.ErrorMessage = "La fila solicitada no esta en la base de datos"
            cuvExcepcionesAdd.ToolTip = "La fila solicitada no esta en la base de datos"
            cuvExcepcionesAdd.IsValid = False
        Catch strongTypingEx As StrongTypingException
            cuvExcepcionesAdd.ErrorMessage = "Error en tipos de datos"
            cuvExcepcionesAdd.ToolTip = "Error en tipos de datos"
            cuvExcepcionesAdd.IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            cuvExcepcionesAdd.ErrorMessage = "No fue posible generar el conjunto de datos"
            cuvExcepcionesAdd.ToolTip = "No fue posible generar el conjunto de datos"
            cuvExcepcionesAdd.IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            cuvExcepcionesAdd.ErrorMessage = "Versión no encontrada"
            cuvExcepcionesAdd.ToolTip = "Versión no encontrada"
            cuvExcepcionesAdd.IsValid = False
        Catch dataEx As DataException
            cuvExcepcionesAdd.ErrorMessage = "Error de datos"
            cuvExcepcionesAdd.ToolTip = "Error de datos"
            cuvExcepcionesAdd.IsValid = False
        Catch ex As Exception
            cuvExcepcionesAdd.ErrorMessage = "Ocurrió un error al intentar guardar " & ex.Message
            cuvExcepcionesAdd.ToolTip = "Ocurrió un error al intentar guardar"
            cuvExcepcionesAdd.IsValid = False
        End Try
    End Sub

    Protected Sub dtlProyectos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtlProyectos.SelectedIndexChanged
        odsProyecto.FilterExpression = "CveProyecto = '" & dtlProyectos.DataKeys(dtlProyectos.SelectedIndex).ToString & "'"
        dtlProyectos.SelectedIndex = 0
        dtlProyectos.DataBind()
        CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("ResumenLabel"), Label).Text = CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("ResumenLabel"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblMetodologiaST"), Label).Text = CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblMetodologiaST"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblObjetivosEspecificosST"), Label).Text = CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblObjetivosEspecificosST"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblResultadosEspST"), Label).Text = CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblResultadosEspST"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblObjetivoGeneralST"), Label).Text = CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblObjetivoGeneralST"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblImpactosEsperadosST"), Label).Text = CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblImpactosEsperadosST"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblUsuarioTTST"), Label).Text = CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblUsuarioTTST"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblMaterialesTTST"), Label).Text = CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblMaterialesTTST"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblRequisitosTTST"), Label).Text = CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblRequisitosTTST"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblActividadesTTST"), Label).Text = CType(dtlProyectos.Controls.Item(dtlProyectos.SelectedIndex).FindControl("lblActividadesTTST"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        pnlBusqueda.Visible = False
        pnlNavegacionUp.Visible = False
        pnlNavegacionDw.Visible = False
    End Sub

    Protected Sub ibtnExpandirTT_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        pnlExpandirTT.Visible = Not pnlExpandirTT.Visible
        lblMasInfoTTST.Visible = Not lblMasInfoTTST.Visible
        If pnlExpandirTT.Visible Then
            ibtnExpandirTTST.ImageUrl = "~/images/aplicacion/contraer.gif"
        Else
            ibtnExpandirTTST.ImageUrl = "~/images/aplicacion/expandir.gif"
        End If
    End Sub

    Protected Sub ibtnExpandirObjetivosST_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        pnlExpandirObjetivosST.Visible = Not pnlExpandirObjetivosST.Visible
        lblMasInfoObjetivosST.Visible = Not lblMasInfoObjetivosST.Visible
        If pnlExpandirObjetivosST.Visible Then
            ibtnExpandirObjetivosST.ImageUrl = "~/images/aplicacion/contraer.gif"
        Else
            ibtnExpandirObjetivosST.ImageUrl = "~/images/aplicacion/expandir.gif"
        End If
    End Sub

    Protected Sub ibtnMasInfoGralST_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        pnlMasInfoGralST.Visible = Not pnlMasInfoGralST.Visible
        lblMasInfoGralST.Visible = Not lblMasInfoGralST.Visible
        If pnlMasInfoGralST.Visible Then
            ibtnMasInfoGralST.ImageUrl = "~/images/aplicacion/contraer.gif"
        Else
            ibtnMasInfoGralST.ImageUrl = "~/images/aplicacion/expandir.gif"
        End If
    End Sub

    Protected Sub ibtnDatosGeneralesEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dg_sel.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_rep.gif"
        '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pr_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pa_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_es_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_st_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dm_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dd_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_sg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ad_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("mviewProyectosEdt"), MultiView).SetActiveView(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("viewDatosGeneralesEdt"), View))
        odsProyecto.FilterExpression = dtlProyectos.DataKeyField.ToString + " = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
        dtlProyectos.DataBind()
        EstablecerPermisos()
    End Sub

    Protected Sub odsProyecto_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsProyecto.Selecting
        e.InputParameters("startRowIndex") = StartRowIndex
        e.InputParameters("maximumRows") = MaximumRows
        e.InputParameters("Busqueda") = textoBusqueda
        e.InputParameters("CveProyecto") = CveProyectoBuscar
        e.InputParameters("CveTipoApoyo") = CveTipoApoyoBuscar
        e.InputParameters("CveEstatus") = CveEstatusBuscar
        e.InputParameters("CveRegion") = CveRegionBuscar
        e.InputParameters("AnioConvocatoria") = AnioConvBuscar
        e.InputParameters("CveInstitucion") = CveInstitucionBuscar

        EnableNavigation()
    End Sub

#End Region

#Region "ProyectoParticipante"

    Private Sub LimpiarParticipante()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ddlParticipantePPAdd"), DropDownList).SelectedIndex = -1
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ddlTipoParticipantePPAdd"), DropDownList).SelectedIndex = -1

    End Sub

    Private Sub SelPestaniaParticipantes()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_rep.gif"
        '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pr_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pa_sel.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_es_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_st_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dm_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dd_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_sg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ad_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnInfraestructuraEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_in_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("mviewProyectosEdt"), MultiView).SetActiveView(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("viewParticipantesEdt"), View))
    End Sub

    Protected Sub ibtnParticipantesEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaParticipantes()
    End Sub

    Protected Sub dtlParticipantesPP_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlParticipantesPPAdd"), Panel).Visible = False
        LimpiarParticipante()
        CType(source, DataList).EditItemIndex = -1
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlParticipantesPP_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoParticipante As New dsAppTableAdapters.ProyectoParticipanteTableAdapter

        Try
            taProyectoParticipante.Delete(CType(source, DataList).DataKeys(e.Item.ItemIndex), dtlProyectos.DataKeys(dtlProyectos.EditItemIndex))
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlParticipantesPPAdd"), Panel).Visible = False
            LimpiarParticipante()
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaParticipantes()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:002"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoParticipante.Dispose()
        End Try

    End Sub

    Protected Sub dtlParticipantesPP_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlParticipantesPPAdd"), Panel).Visible = False
        LimpiarParticipante()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("odsProyectoParticipante"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(source, DataList).DataKeyField.ToString & " = " & CType(source, DataList).DataKeys(e.Item.ItemIndex)
        CType(source, DataList).EditItemIndex = 0
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlParticipantesPP_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoParticipante As New dsAppTableAdapters.ProyectoParticipanteTableAdapter

        Try
            taProyectoParticipante.UpdateCveTipoParticipante( _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("ddlTipoParticipantePPEdt"), DropDownList).SelectedValue, _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex))
            CType(source, DataList).EditItemIndex = -1
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaParticipantes()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:003"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvParticipantePPEdt"), CustomValidator).IsValid = False
        Finally
            taProyectoParticipante.Dispose()
        End Try
    End Sub

    Protected Sub dtlParticipantesPP_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse _
           e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim participante As dsApp.ProyectoParticipanteRow = _
                CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                           dsApp.ProyectoParticipanteRow)

            Dim db As ImageButton = _
                CType(e.Item.FindControl("ibtnEliminarPP"), ImageButton)

            db.OnClientClick = String.Format( _
                "return confirm('¿Desea eliminar el participante {0}?');", _
                participante.Participante.Replace("'", "\'"))

        End If
    End Sub

    Protected Sub ibtnAgregarPP_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlParticipantesPPAdd"), Panel).Visible = Not CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlParticipantesPPAdd"), Panel).Visible
    End Sub

    Protected Sub ibtnInsertarPPAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim taProyectoParticipante As New dsAppTableAdapters.ProyectoParticipanteTableAdapter

        Try
            taProyectoParticipante.Insert( _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ddlParticipantePPAdd"), DropDownList).SelectedValue, _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ddlTipoParticipantePPAdd"), DropDownList).SelectedValue)
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlParticipantesPPAdd"), Panel).Visible = False
            LimpiarParticipante()
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlParticipantesPP"), DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaParticipantes()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:004"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvParticipantesPPAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoParticipante.Dispose()
        End Try
    End Sub

    Protected Sub ibtnCancelarPPAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlParticipantesPPAdd"), Panel).Visible = False
        LimpiarParticipante()
    End Sub

#End Region

#Region "ProyectoEspecie"

    Private Sub LimpiarEspecie()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ddlEspeciePEAdd"), DropDownList).SelectedIndex = -1
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtNombreComunPEAdd"), TextBox).Text = String.Empty
    End Sub

    Private Sub SelPestaniaEspecies()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_rep.gif"
        '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pr_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pa_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_es_sel.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_st_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dm_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dd_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_sg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ad_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnInfraestructuraEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_in_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("mviewProyectosEdt"), MultiView).SetActiveView(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("viewEspeciesEdt"), View))
    End Sub

    Protected Sub ibtnEspeciesEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaEspecies()
    End Sub

    Protected Sub dtlEspeciesPE_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlEspeciesPEAdd"), Panel).Visible = False
        LimpiarEspecie()
        CType(source, DataList).EditItemIndex = -1
        CType(source, DataList).DataBind()
        'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
        'dtlProyectos.DataBind()
    End Sub

    Protected Sub dtlEspeciesPE_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoEspecie As New dsAppTableAdapters.ProyectoEspecieTableAdapter

        Try
            taProyectoEspecie.Delete(dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex))
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlEspeciesPEAdd"), Panel).Visible = False
            LimpiarEspecie()
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaEspecies()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:005"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoEspecie.Dispose()
        End Try

    End Sub

    Protected Sub dtlEspeciesPE_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlEspeciesPEAdd"), Panel).Visible = False
        LimpiarEspecie()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("odsEspeciePE"), ObjectDataSource).FilterExpression = "CveProyecto = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND CveEspecie = " & CType(source, DataList).DataKeys(e.Item.ItemIndex)
        CType(source, DataList).EditItemIndex = 0
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlEspeciesPE_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoEspecie As New dsAppTableAdapters.ProyectoEspecieTableAdapter

        Try
            taProyectoEspecie.ActualizarNombreComun( _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtNombreComunPEEdt"), TextBox).Text, _
                 dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex))
            CType(source, DataList).EditItemIndex = -1
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaEspecies()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:006"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvEspeciePEEdt"), CustomValidator).IsValid = False
        Finally
            taProyectoEspecie.Dispose()
        End Try
    End Sub

    Protected Sub dtlEspeciesPE_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse _
            e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim especie As dsApp.ProyectoEspecieRow = _
                CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                           dsApp.ProyectoEspecieRow)

            Dim db As ImageButton = _
                CType(e.Item.FindControl("ibtnEliminarPE"), ImageButton)

            db.OnClientClick = String.Format( _
                "return confirm('¿Desea eliminar la especie {0}?');", _
                especie.NombreCientifico.Replace("'", "\'"))
        End If
    End Sub

    Protected Sub ibtnNuevoProyectoEspeciesAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlEspeciesPEAdd"), Panel).Visible = Not CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlEspeciesPEAdd"), Panel).Visible
    End Sub

    Protected Sub ibtnGuardarPEAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim taProyectoEspecie As New dsAppTableAdapters.ProyectoEspecieTableAdapter

        Try
            taProyectoEspecie.Insert( _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ddlEspeciePEAdd"), DropDownList).SelectedValue, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtNombreComunPEAdd"), TextBox).Text)
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlEspeciesPEAdd"), Panel).Visible = False
            LimpiarEspecie()
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEspeciesPE"), DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaEspecies()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:007"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEspeciePEAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoEspecie.Dispose()
        End Try

    End Sub

    Protected Sub ibtnCancelarPEAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlEspeciesPEAdd"), Panel).Visible = False
        LimpiarEspecie()
    End Sub

#End Region

#Region "ProyectoDifusionDivulgacion"

    Private Sub LimpiarDifusion()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ddlTipoDifusionDDAdd"), DropDownList).SelectedIndex = -1
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaInicioDDAdd"), UpdatePanel).FindControl("dtpkFechaInicioDDAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaInicioDDAdd"), UpdatePanel).FindControl("dtpkFechaFinDDAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtDescripcionDDAdd"), TextBox).Text = String.Empty
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtSegmentoPobDDAdd"), TextBox).Text = String.Empty
    End Sub

    Private Sub SelPestaniaDifusionDivulga()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_rep.gif"
        '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pr_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pa_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_es_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_st_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dm_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dd_sel.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_sg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ad_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnInfraestructuraEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_in_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("mviewProyectosEdt"), MultiView).SetActiveView(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("viewDifusionDivulgaEdt"), View))
    End Sub

    Protected Sub ibtnDifusionDivulgaEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaDifusionDivulga()
    End Sub

    Protected Sub dtlActividadesDD_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDifDivAdd"), Panel).Visible = False
        LimpiarDifusion()
        CType(source, DataList).EditItemIndex = -1
        CType(source, DataList).SelectedIndex = -1
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlActividadesDD_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoDifDiv As New dsAppTableAdapters.ProyectoDifDivTableAdapter

        Try
            taProyectoDifDiv.Delete(dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex), CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("hdnConsecutivoDDEdt"), HiddenField).Value)
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDifDivAdd"), Panel).Visible = False
            LimpiarDifusion()
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaDifusionDivulga()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:008"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoDifDiv.Dispose()
        End Try
    End Sub

    Protected Sub dtlActividadesDD_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDifDivAdd"), Panel).Visible = False
        LimpiarDifusion()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("odsActividadesDD"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(source, DataList).DataKeyField.ToString & " = " & CType(source, DataList).DataKeys(e.Item.ItemIndex)
        CType(source, DataList).EditItemIndex = 0
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlActividadesDD_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDifDivAdd"), Panel).Visible = False
        LimpiarDifusion()
        CType(sender, DataList).DataBind()
        CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblDescripcionDDSIT"), Label).Text = CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblDescripcionDDSIT"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblSegmentoDDSIT"), Label).Text = CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblSegmentoDDSIT"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        'SelPestaniaDifusionDivulga()
    End Sub

    Protected Sub dtlActividadesDD_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoDifDiv As New dsAppTableAdapters.ProyectoDifDivTableAdapter
        Dim dtFechaInicio As New System.Nullable(Of Date)
        Dim dtFechaFin As New System.Nullable(Of Date)
        Dim numBene As Integer
        If CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtNumeroBeneficiariosEdt"), TextBox).Text = "" Then
            numBene = Nothing
        Else
            numBene = Convert.ToInt32(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtNumeroBeneficiariosEdt"), TextBox).Text)
        End If


        Try
            If CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaInicioDDEdt"), UpdatePanel).FindControl("dtpkFechaInicioDDEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty Then dtFechaInicio = Nothing Else dtFechaInicio = CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaInicioDDEdt"), UpdatePanel).FindControl("dtpkFechaInicioDDEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text)
            If CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaFinDDEdt"), UpdatePanel).FindControl("dtpkFechaFinDDEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty Then dtFechaFin = Nothing Else dtFechaFin = CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaFinDDEdt"), UpdatePanel).FindControl("dtpkFechaFinDDEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text)
            taProyectoDifDiv.ActualizarDifusionDivulgacion( _
                dtFechaInicio, _
                dtFechaFin, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtDescripcionDDEdt"), TextBox).Text, _
                numBene, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtSegmentoPobDDEdt"), TextBox).Text, _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex), _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("hdnConsecutivoDDEdt"), HiddenField).Value)
            CType(source, DataList).EditItemIndex = -1
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaDifusionDivulga()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:009" & ex.Message
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDifDivDDEdt"), CustomValidator).IsValid = False
        Finally
            taProyectoDifDiv.Dispose()
        End Try

    End Sub

    Protected Sub dtlActividadesDD_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse _
            e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim DifusionDiv As dsApp.ProyectoDifDivRow = _
                CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                           dsApp.ProyectoDifDivRow)

            Dim db As ImageButton = _
                CType(e.Item.FindControl("ibtnEliminarDD"), ImageButton)

            db.OnClientClick = String.Format( _
                "return confirm('¿Desea eliminar el medio {0}?');", _
                DifusionDiv.DifusionDivulgacion.Replace("'", "\'"))
        End If
    End Sub

    Protected Sub ibtnNuevoDDAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDifDivAdd"), Panel).Visible = Not CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDifDivAdd"), Panel).Visible
    End Sub

    Protected Sub ibtnInsertarDD_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim taProyectoDifDiv As New dsAppTableAdapters.ProyectoDifDivTableAdapter
        Dim dtFechaInicio As New System.Nullable(Of Date)
        Dim dtFechaFin As New System.Nullable(Of Date)
        Dim numBene As Integer
        If CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtNumeroBeneficiariosAdd"), TextBox).Text = "" Then
            numBene = Nothing
        Else
            numBene = Convert.ToInt32(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtNumeroBeneficiariosAdd"), TextBox).Text)
        End If

        Try
            If CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaInicioDDAdd"), UpdatePanel).FindControl("dtpkFechaInicioDDAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty Then dtFechaInicio = Nothing Else dtFechaInicio = CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaInicioDDAdd"), UpdatePanel).FindControl("dtpkFechaInicioDDAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text)
            If CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaInicioDDAdd"), UpdatePanel).FindControl("dtpkFechaFinDDAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty Then dtFechaFin = Nothing Else dtFechaFin = CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaInicioDDAdd"), UpdatePanel).FindControl("dtpkFechaFinDDAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text)
            taProyectoDifDiv.Insert( _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ddlTipoDifusionDDAdd"), DropDownList).SelectedValue, _
                dtFechaInicio, _
                dtFechaFin, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtDescripcionDDAdd"), TextBox).Text, _
                numBene, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtSegmentoPobDDAdd"), TextBox).Text)
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDifDivAdd"), Panel).Visible = False
            LimpiarDifusion()
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlActividadesDD"), DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaDifusionDivulga()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:010"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDifDivDDAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoDifDiv.Dispose()
        End Try

    End Sub

    Protected Sub ibtnCancelarDD_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDifDivAdd"), Panel).Visible = False
        LimpiarDifusion()
    End Sub

#End Region

#Region "ProyectoMontoDetalle"

    Private Sub LimpiarMontoDetalle()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtConceptoPMAdd"), TextBox).Text = String.Empty
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtCantidadPMAdd"), TextBox).Text = String.Empty
    End Sub

    Private Sub SelPestaniaDetalleMonto()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_rep.gif"
        '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pr_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pa_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_es_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_st_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dm_sel.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dd_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_sg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ad_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnInfraestructuraEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_in_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("mviewProyectosEdt"), MultiView).SetActiveView(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("viewDetalleMontoEdt"), View))
    End Sub

    Protected Sub ibtnDetalleMontoEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaDetalleMonto()
    End Sub

    Protected Sub dtlProyectoDetalleMonto_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDetMontoAdd"), Panel).Visible = False
        LimpiarMontoDetalle()
        CType(source, DataList).EditItemIndex = -1
        CType(source, DataList).SelectedIndex = -1
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyectoDetalleMonto_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoMonto As New dsAppTableAdapters.ProyectoDetalleMontoTableAdapter

        Try
            taProyectoMonto.Delete(dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex))
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDetMontoAdd"), Panel).Visible = False
            LimpiarMontoDetalle()
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaDetalleMonto()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:011"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoMonto.Dispose()
        End Try
    End Sub

    Protected Sub dtlProyectoDetalleMonto_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDetMontoAdd"), Panel).Visible = False
        LimpiarMontoDetalle()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("odsProyectoDetalleMonto"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(source, DataList).DataKeyField.ToString & " = " & CType(source, DataList).DataKeys(e.Item.ItemIndex)
        CType(source, DataList).EditItemIndex = 0
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyectoDetalleMonto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDetMontoAdd"), Panel).Visible = False
        LimpiarMontoDetalle()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("odsProyectoDetalleMonto"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(sender, DataList).DataKeyField.ToString & " = " & CType(sender, DataList).DataKeys(CType(sender, DataList).SelectedIndex)
        CType(sender, DataList).SelectedIndex = 0
        CType(sender, DataList).DataBind()
        'SelPestaniaDetalleMonto()
    End Sub

    Protected Sub dtlProyectoDetalleMonto_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoDetMonto As New dsAppTableAdapters.ProyectoDetalleMontoTableAdapter

        Try
            taProyectoDetMonto.ActualizarDetalleMonto( _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtConceptoPMEdt"), TextBox).Text, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtCantidadPMEdt"), TextBox).Text, _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex))
            CType(source, DataList).EditItemIndex = -1
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaDetalleMonto()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:012"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDetalleMontoPMEdt"), CustomValidator).IsValid = False
        Finally
            taProyectoDetMonto.Dispose()
        End Try

    End Sub

    Protected Sub dtlProyectoDetalleMonto_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse _
            e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim DetalleMonto As dsApp.ProyectoDetalleMontoRow = _
                CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                           dsApp.ProyectoDetalleMontoRow)

            Dim db As ImageButton = _
                CType(e.Item.FindControl("ibtnEliminarPM"), ImageButton)

            db.OnClientClick = String.Format( _
                "return confirm('¿Desea eliminar el concepto {0}?');", _
                DetalleMonto.Concepto.Replace("'", "\'"))
        End If
    End Sub

    Protected Sub ibtnNuevoPMAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDetMontoAdd"), Panel).Visible = Not CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDetMontoAdd"), Panel).Visible
    End Sub

    Protected Sub ibtnGuardarPMAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim taDetalleMonto As New dsAppTableAdapters.ProyectoDetalleMontoTableAdapter

        Try
            taDetalleMonto.InsertarConcepto( _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtConceptoPMAdd"), TextBox).Text, _
                CDec(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtCantidadPMAdd"), TextBox).Text))
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDetMontoAdd"), Panel).Visible = False
            LimpiarMontoDetalle()
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoDetalleMonto"), DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaDetalleMonto()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:013"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDetalleMontoPMAdd"), CustomValidator).IsValid = False
        Finally
            taDetalleMonto.Dispose()
        End Try

    End Sub

    Protected Sub ibtnCancelarPMAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlDetMontoAdd"), Panel).Visible = False
        LimpiarMontoDetalle()
    End Sub

#End Region

#Region "ProyectoProgramaPago"

    Private Sub LimpiarProgramaPago()
        'CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtMontoPGAdd"), TextBox).Text = String.Empty
        'CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpGastoPGAdd"), UpdatePanel).FindControl("ddlTipoGastoPGAdd"), DropDownList).SelectedIndex = -1
        'CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpGastoPGAdd"), UpdatePanel).FindControl("ddlGastoPGAdd"), DropDownList).SelectedIndex = -1
        'CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaProgPGAdd"), UpdatePanel).FindControl("dtpkFechaProgPGAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        'CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaRealPGAdd"), UpdatePanel).FindControl("dtpkFechaRealPGAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        'CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaSolPGAdd"), UpdatePanel).FindControl("dtpkFechaSolPGAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        'CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtClabePGAdd"), TextBox).Text = String.Empty
        'CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpEdoMpioPGAdd"), UpdatePanel).FindControl("ddlEstadoPGAdd"), DropDownList).SelectedIndex = -1
        'CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpEdoMpioPGAdd"), UpdatePanel).FindControl("ddlMpioPGAdd"), DropDownList).SelectedIndex = -1
        'CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtNumFacturaPGAdd"), TextBox).Text = String.Empty
        'CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaEntPGAdd"), UpdatePanel).FindControl("dtpkFechaEntPGAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        'CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaConPGAdd"), UpdatePanel).FindControl("dtpkFechaConPGAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        'CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtObservacionesPGAdd"), TextBox).Text = String.Empty
    End Sub

    Private Sub SelPestaniaProgramaPago()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_rep.gif"
        '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pr_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pa_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_es_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_st_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dm_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dd_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_sg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ad_sel.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnInfraestructuraEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_in_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("mviewProyectosEdt"), MultiView).SetActiveView(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("viewAdministrativoEdt"), View))
    End Sub

    Protected Sub ibtnAdministrativoEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaProgramaPago()
    End Sub

    Protected Sub dtlProyectoProgPagoPG_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProgramaPagoPPAdd"), Panel).Visible = False
        LimpiarProgramaPago()
        CType(source, DataList).EditItemIndex = -1
        CType(source, DataList).SelectedIndex = -1
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyectoProgPagoPG_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        'Entra el Polo
        'Dim taProyectoProgPago As New dsAppTableAdapters.ProgramaPagoTableAdapter
        Dim taProyectoProgPago As New dsAppTableAdapters.spAdministrativoPagosTableAdapter
        
        Try
            'Clave del documento
            Dim CveDocumento As Integer = CType(source, DataList).DataKeys(e.Item.ItemIndex)
            Dim rowDocumento As dsApp.spAdministrativoPagosRow = taProyectoProgPago.GetDataByCveDocumento(CveDocumento).Rows(0)
            'Verificar que este registro tenga un archivo relacionado para eliminar
            If System.IO.File.Exists(Server.MapPath(rowDocumento.Ubicacion)) Then
                System.IO.File.Delete(Server.MapPath(rowDocumento.Ubicacion))
            End If

            'ELIMINAR
            taProyectoProgPago.Delete(CveDocumento)

            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProgramaPagoPPAdd"), Panel).Visible = False
            LimpiarProgramaPago()
            CType(source, DataList).DataBind()
        Catch ex As Exception
            CType(e.Item.FindControl("cuvPGILista"), CustomValidator).ErrorMessage = "Ocurrió un error: " & ex.Message
            CType(e.Item.FindControl("cuvPGILista"), CustomValidator).ToolTip = "Ocurrió un error:" & ex.Message
            CType(e.Item.FindControl("cuvPGILista"), CustomValidator).IsValid = False
        Finally
            taProyectoProgPago.Dispose()
        End Try

    End Sub

    Protected Sub dtlProyectoProgPagoPG_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProgramaPagoPPAdd"), Panel).Visible = False
        LimpiarProgramaPago()
        'CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("odsPoryectoProgPagoPG"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(source, DataList).DataKeyField.ToString & " = " & CType(source, DataList).DataKeys(e.Item.ItemIndex)
        'CType(source, DataList).EditItemIndex = 0
        CType(source, DataList).EditItemIndex = e.Item.ItemIndex
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyectoProgPagoPG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProgramaPagoPPAdd"), Panel).Visible = False
        LimpiarProgramaPago()
        'CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("odsPoryectoProgPagoPG"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(sender, DataList).DataKeyField.ToString & " = " & CType(sender, DataList).DataKeys(CType(sender, DataList).SelectedIndex)
        'CType(sender, DataList).SelectedIndex = 0
        CType(sender, DataList).DataBind()
        'CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblObservacionesPGSel"), Label).Text = CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblObservacionesPGSel"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        'SelPestaniaProgramaPago()
    End Sub

    Protected Sub dtlProyectoProgPagoPG_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taAdministrativoPagos As New dsAppTableAdapters.spAdministrativoPagosTableAdapter

        Try
            Dim CveProyecto As String = CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("lblCveDocumento"), Label).Text
            Dim CveEtapa As Integer = Convert.ToInt32(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("ddlCveEtapaEdt"), DropDownList).SelectedValue)
            Dim txtTitulo As String = CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtTitulo"), TextBox).Text
            taAdministrativoPagos.Update( _
                CveProyecto, _
                CveEtapa, _
                txtTitulo)
            'taProyectoProgPago.ActualizaProgPago( _
            '    CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtMontoPGEdt"), TextBox).Text, _
            '    CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpGastoPGEdt"), UpdatePanel).FindControl("ddlGastoPGEdt"), DropDownList).SelectedValue, _
            '    CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaProgPGEdt"), UpdatePanel).FindControl("dtpkFechaProgPGEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaRealPGEdt"), UpdatePanel).FindControl("dtpkFechaRealPGEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaSolPGEdt"), UpdatePanel).FindControl("dtpkFechaSolPGEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtClabePGEdt"), TextBox).Text, _
            '    CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpEdoMpioPGEdt"), UpdatePanel).FindControl("ddlMpioPGEdt"), DropDownList).SelectedValue, _
            '    CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpEdoMpioPGEdt"), UpdatePanel).FindControl("ddlEstadoPGEdt"), DropDownList).SelectedValue, _
            '    CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtNumFacturaPGEdt"), TextBox).Text, _
            '    CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaEntPGEdt"), UpdatePanel).FindControl("dtpkFechaEntPGEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaConPGEdt"), UpdatePanel).FindControl("dtpkFechaConPGEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtObservacionesPGEdt"), TextBox).Text, _
            '    dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex))
            CType(source, DataList).EditItemIndex = -1
            CType(source, DataList).DataBind()

        Catch concurrencyEx As DBConcurrencyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
        Catch ex As Exception
            'CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:015"
            'CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            'CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvMontosPGEdt"), CustomValidator).IsValid = False
            Response.Write(ex.Message)
        Finally
            taAdministrativoPagos.Dispose()
        End Try

    End Sub

    Protected Sub dtlProyectoProgPagoPG_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse _
            e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ProgramaPago As dsApp.ProgramaPagoRow = _
                CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                           dsApp.ProgramaPagoRow)

            Dim db As ImageButton = _
                CType(e.Item.FindControl("ibtnEliminarPGItm"), ImageButton)

            db.OnClientClick = String.Format( _
                "return confirm('¿Desea eliminar el gasto {0}?');", _
                ProgramaPago.Gasto.Replace("'", "\'"))
        End If
    End Sub

    Protected Sub ibtnNuevoPG_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProgramaPagoPPAdd"), Panel).Visible = Not CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProgramaPagoPPAdd"), Panel).Visible
    End Sub

    Protected Sub ibtnGuardarPGAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim taAdmPago As New dsAppTableAdapters.spAdministrativoPagosTableAdapter
        Dim boolAgregarRegistro As Boolean = True
        Dim NewNameArchivo As String = String.Empty
        'Obtener los datos para agregar
        Dim CveProyecto As String = CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("hdCveProyectoAdmEdt"), HiddenField).Value
        Dim CveEtapa As Integer = Convert.ToInt32(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ddlCveEtapaAdd"), DropDownList).SelectedValue)
        Dim txtTitulo As String = CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtTituloAdd"), TextBox).Text
        Dim objChorizoFile_FileUpload As FileUpload = CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("flupPagosAdd"), FileUpload)

        If objChorizoFile_FileUpload.HasFile Then
            'El nombre formado de Proyecto+Etapa+FechaActual
            NewNameArchivo = "Adm_" & CveProyecto & "_" & CveEtapa.ToString("000") & "_" & Now().ToString("yyyy-MM-dd_hhmmss")
            'Extencion de archivo
            NewNameArchivo = NewNameArchivo & objChorizoFile_FileUpload.FileName.Substring(objChorizoFile_FileUpload.FileName.LastIndexOfAny("."))

            'Verificar que no sobrepase el tamaño del archivo permitido
            If objChorizoFile_FileUpload.FileBytes.Length <= CInt(System.Web.Configuration.WebConfigurationManager.AppSettings("MaxBytesArchivo").ToString) Then
                Try
                    objChorizoFile_FileUpload.SaveAs(Server.MapPath(PathProducts) & NewNameArchivo)
                Catch ex As Exception
                    Response.Write("error al intentar guardar el archivo: " & ex.Message)
                End Try
            End If
        End If
        Try

            taAdmPago.Insert( _
            CveProyecto, _
            CveEtapa, _
            txtTitulo, _
            PathProducts & NewNameArchivo)

            'taProgramaPago.AgregarGasto( _
            '    dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString, _
            '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtMontoPGAdd"), TextBox).Text, _
            '    CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpGastoPGAdd"), UpdatePanel).FindControl("ddlGastoPGAdd"), DropDownList).SelectedValue, _
            '    CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaProgPGAdd"), UpdatePanel).FindControl("dtpkFechaProgPGAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaRealPGAdd"), UpdatePanel).FindControl("dtpkFechaRealPGAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaSolPGAdd"), UpdatePanel).FindControl("dtpkFechaSolPGAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtClabePGAdd"), TextBox).Text, _
            '    CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpEdoMpioPGAdd"), UpdatePanel).FindControl("ddlMpioPGAdd"), DropDownList).SelectedValue, _
            '    CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpEdoMpioPGAdd"), UpdatePanel).FindControl("ddlEstadoPGAdd"), DropDownList).SelectedValue, _
            '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtNumFacturaPGAdd"), TextBox).Text, _
            '    CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaEntPGAdd"), UpdatePanel).FindControl("dtpkFechaEntPGAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaConPGAdd"), UpdatePanel).FindControl("dtpkFechaConPGAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtObservacionesPGAdd"), TextBox).Text)
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProgramaPagoPPAdd"), Panel).Visible = False
            LimpiarProgramaPago()
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoProgPagoPG"), DataList).DataBind()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:016"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvMontosPGAdd"), CustomValidator).IsValid = False
        Finally
            taAdmPago.Dispose()
        End Try

    End Sub

    Protected Sub ibtnCancelarPGAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProgramaPagoPPAdd"), Panel).Visible = False
        LimpiarProgramaPago()
    End Sub

    Protected Sub ddlEstadoPGEdt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CType(sender, DropDownList).SelectedValue = _
            CType(CType(sender, DropDownList).Parent.Parent.FindControl("hdnEstadoPGEdt"), HiddenField).Value) Then
            CType(CType(sender, DropDownList).Parent.Parent.FindControl("ddlMpioPGEdt"), DropDownList).DataBind()
            CType(CType(sender, DropDownList).Parent.Parent.FindControl("ddlMpioPGEdt"), DropDownList).SelectedValue = CType(CType(sender, UpdatePanel).FindControl("hdnMpioPGEdt"), HiddenField).Value
        Else
            CType(CType(sender, DropDownList).Parent.Parent.FindControl("ddlMpioPGEdt"), DropDownList).SelectedValue = "-1"
            CType(CType(sender, DropDownList).Parent.Parent.FindControl("hdnMpioPGEdt"), HiddenField).Value = "-1"
        End If
    End Sub

    Protected Sub updpEdoMpioPGEdt_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CType(CType(sender, UpdatePanel).FindControl("ddlEstadoPGEdt"), DropDownList).SelectedValue = _
            CType(CType(sender, UpdatePanel).FindControl("hdnEstadoPGEdt"), HiddenField).Value) Then
            CType(CType(sender, UpdatePanel).FindControl("ddlMpioPGEdt"), DropDownList).DataBind()
            CType(CType(sender, UpdatePanel).FindControl("ddlMpioPGEdt"), DropDownList).SelectedValue = CType(CType(sender, UpdatePanel).FindControl("hdnMpioPGEdt"), HiddenField).Value
        Else
            CType(CType(sender, UpdatePanel).FindControl("ddlMpioPGEdt"), DropDownList).SelectedValue = "-1"
            CType(CType(sender, UpdatePanel).FindControl("hdnMpioPGEdt"), HiddenField).Value = "-1"
        End If
    End Sub

    Protected Sub ddlTipoGastoPGEdt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CType(sender, DropDownList).SelectedValue = _
            CType(CType(sender, DropDownList).Parent.Parent.FindControl("hdnTipoGastoPGEdt"), HiddenField).Value) Then
            CType(CType(sender, DropDownList).Parent.Parent.FindControl("ddlGastoPGEdt"), DropDownList).DataBind()
            CType(CType(sender, DropDownList).Parent.Parent.FindControl("ddlGastoPGEdt"), DropDownList).SelectedValue = CType(CType(sender, UpdatePanel).FindControl("hdnGastoPGEdt"), HiddenField).Value
        Else
            CType(CType(sender, DropDownList).Parent.Parent.FindControl("ddlGastoPGEdt"), DropDownList).SelectedValue = "-1"
            CType(CType(sender, DropDownList).Parent.Parent.FindControl("hdnGastoPGEdt"), HiddenField).Value = "-1"
        End If
    End Sub

    Protected Sub updpGastoPGEdt_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CType(CType(sender, UpdatePanel).FindControl("ddlTipoGastoPGEdt"), DropDownList).SelectedValue = _
            CType(CType(sender, UpdatePanel).FindControl("hdnTipoGastoPGEdt"), HiddenField).Value) Then
            CType(CType(sender, UpdatePanel).FindControl("ddlGastoPGEdt"), DropDownList).DataBind()
            CType(CType(sender, UpdatePanel).FindControl("ddlGastoPGEdt"), DropDownList).SelectedValue = CType(CType(sender, UpdatePanel).FindControl("hdnGastoPGEdt"), HiddenField).Value
        Else
            CType(CType(sender, UpdatePanel).FindControl("ddlGastoPGEdt"), DropDownList).SelectedValue = "-1"
            CType(CType(sender, UpdatePanel).FindControl("hdnGastoPGEdt"), HiddenField).Value = "-1"
        End If
    End Sub

    'Entra el Polo
    Protected Sub dtlMeloinvente(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Select Case e.CommandName
            Case "Bajalo"
                Try
                    Dim nombrechivo As String = e.CommandArgument.ToString
                    Dim nombreal As String = e.CommandArgument.ToString.Substring(e.CommandArgument.ToString.LastIndexOf("/") + 1)
                    Response.AddHeader("content-disposition", "attachment; filename=""" & nombreal & """")
                    Response.TransmitFile(Server.MapPath(nombrechivo))
                    Response.End()
                Catch ex As Exception
                End Try
            Case Else
                Exit Select
        End Select
    End Sub
    'Sale el Polo

#End Region

#Region "ProyectoProblematica"

    '*************ELIMINADO ***************
    'Private Sub LimpiarProblematica()
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ddlProblematicaPBAdd"), DropDownList).SelectedIndex = -1
    'End Sub

    'Private Sub SelPestaniaProblematica()
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dg_rep.gif"
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_rep.gif"
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pr_sel.gif"
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pa_rep.gif"
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_es_rep.gif"
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_st_rep.gif"
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dm_rep.gif"
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dd_rep.gif"
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_rep.gif"
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_sg_rep.gif"
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ad_rep.gif"
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnInfraestructuraEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_in_rep.gif"
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("mviewProyectosEdt"), MultiView).SetActiveView(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("viewProblematicasEdt"), View))
    'End Sub

    'Protected Sub ibtnProblematicasEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    SelPestaniaProblematica()
    'End Sub

    'Protected Sub dtlProblematicaPB_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProblematicaPBAdd"), Panel).Visible = False
    '    LimpiarProblematica()
    '    CType(source, DataList).EditItemIndex = -1
    '    CType(source, DataList).SelectedIndex = -1
    '    CType(source, DataList).DataBind()
    'End Sub

    'Protected Sub dtlProblematicaPB_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
    '    Dim taProyectoProblematica As New dsAppTableAdapters.ProyectoProblematicaTableAdapter

    '    Try
    '        taProyectoProblematica.Delete(dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex))
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProblematicaPBAdd"), Panel).Visible = False
    '        LimpiarProblematica()
    '        CType(source, DataList).DataBind()
    '        'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
    '        'dtlProyectos.DataBind()
    '        'SelPestaniaProblematica()
    '    Catch concurrencyEx As DBConcurrencyException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch constraintEx As ConstraintException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch deletedRowEx As DeletedRowInaccessibleException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Fila no accesible"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch duplicateNameEx As DuplicateNameException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Nombre duplicado"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch inRowChangingEx As InRowChangingEventException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch invalidConstraintEx As InvalidConstraintException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Restricción no válida"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch invalidExpressionEx As InvalidExpressionException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Expresión no válida"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch missingPrimaryEx As MissingPrimaryKeyException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch noNullEx As NoNullAllowedException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch readOnlyEx As ReadOnlyException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch rowNotInTableEx As RowNotInTableException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch strongTypingEx As StrongTypingException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch typedDataSetEx As TypedDataSetGeneratorException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch versionNotFoundEx As VersionNotFoundException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Versión no encontrada"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch dataEx As DataException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Error de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Error de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch ex As Exception
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:017"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Finally
    '        taProyectoProblematica.Dispose()
    '    End Try
    'End Sub

    'Protected Sub dtlProblematicaPB_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
    '    If e.Item.ItemType = ListItemType.Item OrElse _
    '        e.Item.ItemType = ListItemType.AlternatingItem Then
    '        Dim Problematica As dsApp.ProyectoProblematicaRow = _
    '            CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
    '                       dsApp.ProyectoProblematicaRow)

    '        Dim db As ImageButton = _
    '            CType(e.Item.FindControl("ibtnEliminarPBItm"), ImageButton)

    '        db.OnClientClick = String.Format( _
    '            "return confirm('¿Desea eliminar la problematica {0}?');", _
    '            Problematica.Problematica.Replace("'", "\'"))
    '    End If
    'End Sub

    'Protected Sub ibtnNuevoPBAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProblematicaPBAdd"), Panel).Visible = Not CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProblematicaPBAdd"), Panel).Visible
    'End Sub

    'Protected Sub ibtnGuardarPBAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    Dim taProblematica As New dsAppTableAdapters.ProyectoProblematicaTableAdapter

    '    Try
    '        taProblematica.Insert( _
    '            dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString, _
    '            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ddlProblematicaPBAdd"), DropDownList).SelectedValue)
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProblematicaPBAdd"), Panel).Visible = False
    '        LimpiarProblematica()
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProblematicaPB"), DataList).DataBind()
    '        'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
    '        'dtlProyectos.DataBind()
    '        'SelPestaniaProblematica()
    '    Catch concurrencyEx As DBConcurrencyException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch constraintEx As ConstraintException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch deletedRowEx As DeletedRowInaccessibleException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Fila no accesible"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch duplicateNameEx As DuplicateNameException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Nombre duplicado"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch inRowChangingEx As InRowChangingEventException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch invalidConstraintEx As InvalidConstraintException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Restricción no válida"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch invalidExpressionEx As InvalidExpressionException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Expresión no válida"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch missingPrimaryEx As MissingPrimaryKeyException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch noNullEx As NoNullAllowedException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch readOnlyEx As ReadOnlyException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch rowNotInTableEx As RowNotInTableException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch strongTypingEx As StrongTypingException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch typedDataSetEx As TypedDataSetGeneratorException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch versionNotFoundEx As VersionNotFoundException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Versión no encontrada"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch dataEx As DataException
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Error de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Error de datos"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Catch ex As Exception
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:018"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
    '        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvProblematicaPBAdd"), CustomValidator).IsValid = False
    '    Finally
    '        taProblematica.Dispose()
    '    End Try
    'End Sub

    'Protected Sub ibtnCancelarPBAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProblematicaPBAdd"), Panel).Visible = False
    '    LimpiarProblematica()
    'End Sub

#End Region

#Region "ProyectoEstado"

    Private Sub LimpiarEstado()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ddlEstadoPSAdd"), DropDownList).SelectedIndex = -1
    End Sub

    Private Sub SelPestaniaEstado()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_rep.gif"
        '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pr_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pa_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_es_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_st_sel.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dm_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dd_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_sg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ad_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnInfraestructuraEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_in_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("mviewProyectosEdt"), MultiView).SetActiveView(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("viewEstadosEdt"), View))
    End Sub

    Protected Sub ibtnEstadosEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaEstado()
    End Sub

    Protected Sub dtlProyectoEstadosPS_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlEstadoPSAdd"), Panel).Visible = False
        LimpiarEstado()
        CType(source, DataList).EditItemIndex = -1
        CType(source, DataList).SelectedIndex = -1
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyectoEstadosPS_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoEstado As New dsAppTableAdapters.ProyectoEstadoTableAdapter

        Try
            taProyectoEstado.Delete(dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex))
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlEstadoPSAdd"), Panel).Visible = False
            LimpiarEstado()
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaEstado()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:019"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoEstado.Dispose()
        End Try
    End Sub

    Protected Sub dtlProyectoEstadosPS_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse _
            e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Estado As dsApp.ProyectoEstadoRow = _
                CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                           dsApp.ProyectoEstadoRow)

            Dim db As ImageButton = _
                CType(e.Item.FindControl("ibtnEliminarPSItm"), ImageButton)

            db.OnClientClick = String.Format( _
                "return confirm('¿Desea eliminar la estado {0}?');", _
                Estado.Estado.Replace("'", "\'"))
        End If
    End Sub

    Protected Sub ibtnNuevoPSAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlEstadoPSAdd"), Panel).Visible = Not CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlEstadoPSAdd"), Panel).Visible
    End Sub

    Protected Sub ibtnGuardarPSAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim taEstado As New dsAppTableAdapters.ProyectoEstadoTableAdapter

        Try
            taEstado.Insert( _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ddlEstadoPSAdd"), DropDownList).SelectedValue)
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlEstadoPSAdd"), Panel).Visible = False
            LimpiarEstado()
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoEstadosPS"), DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaEstado()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:020"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvEstadoPSAdd"), CustomValidator).IsValid = False
        Finally
            taEstado.Dispose()
        End Try
    End Sub

    Protected Sub ibtnCancelarPSAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlEstadoPSAdd"), Panel).Visible = False
        LimpiarEstado()
    End Sub

#End Region

#Region "ProyectoAsunto"

    Private Sub LimpiarAsunto()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtDescAsuntoPTAdd"), TextBox).Text = String.Empty
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ddlEstatusAsuntoPTAdd"), DropDownList).SelectedIndex = -1
    End Sub

    Private Sub SelPestaniaSeguimiento()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_rep.gif"
        '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pr_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pa_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_es_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_st_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dm_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dd_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_sg_sel.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ad_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnInfraestructuraEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_in_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("mviewProyectosEdt"), MultiView).SetActiveView(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("viewSeguimientoEdt"), View))
    End Sub

    Protected Sub ibtnSeguimientoEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaSeguimiento()
    End Sub

    Protected Sub dtlProyectoAsuntosPT_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoAsuntoPTAdd"), Panel).Visible = False
        CurrentCveAsunto = -1
        LimpiarAsunto()
        CType(source, DataList).SelectedIndex = -1
        CType(source, DataList).EditItemIndex = -1
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyectoAsuntosPT_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoAsunto As New dsAppTableAdapters.ProyectoAsuntosTableAdapter

        Try
            taProyectoAsunto.Delete(dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex))
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoAsuntoPTAdd"), Panel).Visible = False
            LimpiarAsunto()
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaSeguimiento()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:021"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoAsunto.Dispose()
        End Try
    End Sub

    Protected Sub dtlProyectoAsuntosPT_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoAsuntoPTAdd"), Panel).Visible = False
        CurrentCveAsunto = CType(source, DataList).DataKeys(e.Item.ItemIndex)
        LimpiarAsunto()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("odsProyectoAsuntosPT"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(source, DataList).DataKeyField.ToString & " = " & CType(source, DataList).DataKeys(e.Item.ItemIndex)
        CType(source, DataList).EditItemIndex = 0
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyectoAsuntosPT_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoAsunto As New dsAppTableAdapters.ProyectoAsuntosTableAdapter

        Try
            taProyectoAsunto.ActualizarAsunto( _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtDescAsuntoPTEdt"), TextBox).Text, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("ddlEstatusAsuntoPTEdt"), DropDownList).SelectedIndex, _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex))
            CType(source, DataList).EditItemIndex = -1
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaSeguimiento()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:022"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAsuntoPTEdt"), CustomValidator).IsValid = False
        Finally
            taProyectoAsunto.Dispose()
        End Try
    End Sub

    Protected Sub dtlProyectoAsuntosPT_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse _
            e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Asunto As dsApp.ProyectoAsuntosRow = _
                CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                           dsApp.ProyectoAsuntosRow)

            Dim db As ImageButton = _
                CType(e.Item.FindControl("ibtnEliminarPTItm"), ImageButton)

            db.OnClientClick = String.Format( _
                "return confirm('¿Desea eliminar el asunto {0} y los oficios relacionados a este?');", _
                Asunto.Descripcion.Replace("'", "\'"))
        End If
    End Sub

    Protected Sub ibtnNuevoPTAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoAsuntoPTAdd"), Panel).Visible = Not CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoAsuntoPTAdd"), Panel).Visible
    End Sub

    Protected Sub ibtnGuardarPTAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim taProyectoAsunto As New dsAppTableAdapters.ProyectoAsuntosTableAdapter

        Try
            taProyectoAsunto.InsertarAsunto( _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtDescAsuntoPTAdd"), TextBox).Text, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ddlEstatusAsuntoPTAdd"), DropDownList).SelectedValue)
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoAsuntoPTAdd"), Panel).Visible = False
            LimpiarAsunto()
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaSeguimiento()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:023"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvDescAsuntoPTAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoAsunto.Dispose()
        End Try
    End Sub

    Protected Sub ibtnCancelarPTAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoAsuntoPTAdd"), Panel).Visible = False
        LimpiarAsunto()
    End Sub

#End Region

#Region "ProyectoAsuntoOficio"

    Private Sub LimpiarOficio()
        CType(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("updpFechaOficPAOAdd"), UpdatePanel).FindControl("dtpkFechaOficPAOAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("txtNumOficioPAOAdd"), TextBox).Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("txtRemitentePAOAdd"), TextBox).Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("txtDestinatarioPAOAdd"), TextBox).Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("txtDescOficioPAOAdd"), TextBox).Text = String.Empty
    End Sub

    Private Sub SelPestaniaAsuntosAsunto()
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("odsProyAsuntoOficioPAO"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).DataKeyField.ToString & " = " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("ibtnProyectoAsuntoPAOEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_as_sel.gif"
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("ibtnProyectAsuntoOficioPAOEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ao_rep.gif"
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("mviewAsuntosOficiosPAO"), MultiView).SetActiveView(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("viewAsuntoPAO"), View))
    End Sub

    Private Sub SelPestaniaAsuntosOficios()
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("ibtnProyectAsuntoOficioPAOEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ao_sel.gif"
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("ibtnProyectoAsuntoPAOEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_as_rep.gif"
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("mviewAsuntosOficiosPAO"), MultiView).SetActiveView(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("viewOficiosPAO"), View))
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("odsProyAsuntoOficioPAO"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).DataKeyField.ToString & " = " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex)
    End Sub

    Protected Sub ibtnProyectoAsuntoPAOEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaAsuntosAsunto()
    End Sub

    Protected Sub ibtnProyectAsuntoOficioPAOEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaAsuntosOficios()
    End Sub

    Protected Sub dtlProyAsuntoOficioPAO_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("pnlProyectoAsuntoOficioAdd"), Panel).Visible = False
        LimpiarOficio()
        CType(source, DataList).EditItemIndex = -1
        CType(source, DataList).SelectedIndex = -1
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyAsuntoOficioPAO_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoAsuntoOficio As New dsAppTableAdapters.AsuntosOficiosTableAdapter

        Try
            taProyectoAsuntoOficio.Delete( _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex), _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), _
                CType(source, DataList).DataKeys(e.Item.ItemIndex))
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("pnlProyectoAsuntoOficioAdd"), Panel).Visible = False
            LimpiarOficio()
            CType(source, DataList).DataBind()
            ''dtlProyectos.DataBind()
            'CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).DataBind()
            ''SelPestaniaSeguimiento()
            'SelPestaniaAsuntosOficios()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:023"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoAsuntoOficio.Dispose()
        End Try
    End Sub

    Protected Sub dtlProyAsuntoOficioPAO_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("pnlProyectoAsuntoOficioAdd"), Panel).Visible = False
        LimpiarOficio()
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("odsProyAsuntoOficioPAO"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).DataKeyField.ToString & " = " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex) & " AND " & CType(source, DataList).DataKeyField.ToString & " = " & CType(source, DataList).DataKeys(e.Item.ItemIndex)
        CType(source, DataList).EditItemIndex = 0
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyAsuntoOficioPAO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("pnlProyectoAsuntoOficioAdd"), Panel).Visible = False
        LimpiarOficio()
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("odsProyAsuntoOficioPAO"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).DataKeyField.ToString & " = " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex) & " AND " & CType(sender, DataList).DataKeyField.ToString & " = " & CType(sender, DataList).DataKeys(CType(sender, DataList).SelectedIndex)
        CType(sender, DataList).SelectedIndex = 0
        CType(sender, DataList).DataBind()
        CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblDescOficioPAOSel"), Label).Text = CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblDescOficioPAOSel"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
    End Sub

    Protected Sub dtlProyAsuntoOficioPAO_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoAsuntoOficio As New dsAppTableAdapters.AsuntosOficiosTableAdapter

        Try
            taProyectoAsuntoOficio.ActualizarOficio( _
                CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaOficPAOEdt"), UpdatePanel).FindControl("dtpkFechaOficPAOEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtNumOficioPAOEdt"), TextBox).Text, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtRemitentePAOEdt"), TextBox).Text, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtDestinatarioPAOEdt"), TextBox).Text, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtDescOficioPAOEdt"), TextBox).Text, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex), _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), _
                CType(source, DataList).DataKeys(e.Item.ItemIndex))
            CType(source, DataList).EditItemIndex = -1
            CType(source, DataList).DataBind()
            'CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).DataBind()
            'SelPestaniaSeguimiento()
            'SelPestaniaAsuntosOficios()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:024"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvFechaOficPAOEdt"), CustomValidator).IsValid = False
        Finally
            taProyectoAsuntoOficio.Dispose()
        End Try
    End Sub

    Protected Sub dtlProyAsuntoOficioPAO_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse _
            e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Oficio As dsApp.AsuntosOficiosRow = _
                CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                           dsApp.AsuntosOficiosRow)

            Dim db As ImageButton = _
                CType(e.Item.FindControl("ibtnEliminarPAOItm"), ImageButton)

            db.OnClientClick = String.Format( _
                "return confirm('¿Desea eliminar el oficio {0}?');", _
                Oficio.NumOficio.Replace("'", "\'"))
        End If
    End Sub

    Protected Sub ibtnNuevoPAOAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("pnlProyectoAsuntoOficioAdd"), Panel).Visible = Not CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("pnlProyectoAsuntoOficioAdd"), Panel).Visible
    End Sub

    Protected Sub ibtnGuardarPAOAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim taProyectoAsuntoOficio As New dsAppTableAdapters.AsuntosOficiosTableAdapter

        Try
            taProyectoAsuntoOficio.InsertarOficio( _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex), _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString, _
                CDate(CType(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("updpFechaOficPAOAdd"), UpdatePanel).FindControl("dtpkFechaOficPAOAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("txtNumOficioPAOAdd"), TextBox).Text, _
                CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("txtRemitentePAOAdd"), TextBox).Text, _
                CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("txtDestinatarioPAOAdd"), TextBox).Text, _
                CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("txtDescOficioPAOAdd"), TextBox).Text)
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("pnlProyectoAsuntoOficioAdd"), Panel).Visible = False
            LimpiarOficio()
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("dtlProyAsuntoOficioPAO"), DataList).DataBind()
            'SelPestaniaSeguimiento()
            'SelPestaniaAsuntosOficios()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:025"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("cuvFechaOficPAOAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoAsuntoOficio.Dispose()
        End Try
    End Sub

    Protected Sub ibtnCancelarPAOAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoAsuntosPT"), DataList).EditItemIndex + 1).FindControl("pnlProyectoAsuntoOficioAdd"), Panel).Visible = False
        LimpiarOficio()
    End Sub

    Protected Sub odsProyAsuntoOficioPAO_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs)
        e.InputParameters("CveProyecto") = CurrentCveProyecto()
        e.InputParameters("CveAsunto") = CurrentCveAsunto()
    End Sub

#End Region

#Region "ProyectoVisitasTecnicas"

    Private Sub LimpiarVisitaTecnica()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtInstalacionesPVAdd"), TextBox).Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpEdoMpioPVAdd"), UpdatePanel).FindControl("ddlEstadoPVAdd"), DropDownList).SelectedIndex = -1
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpEdoMpioPVAdd"), UpdatePanel).FindControl("ddlMpioPVAdd"), DropDownList).SelectedIndex = -1
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaVisPVAdd"), UpdatePanel).FindControl("dtpkFechaVisPVAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtAsistentesPVAdd"), TextBox).Text = String.Empty
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtAvanceGralPVAdd"), TextBox).Text = String.Empty
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("chkbEntregaProdsPVAdd"), CheckBox).Checked = False
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtObservacionesPVAdd"), TextBox).Text = String.Empty
    End Sub

    Private Sub SelPestaniaVisitas()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_rep.gif"
        '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pr_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pa_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_es_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_st_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dm_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dd_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_sel.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_sg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ad_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnInfraestructuraEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_in_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("mviewProyectosEdt"), MultiView).SetActiveView(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("viewVisitasTecnicasEdt"), View))
    End Sub

    Protected Sub ibtnVisitasTecnicasEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaVisitas()
    End Sub

    Protected Sub dtlProyectoVisitasPV_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CurrentCveVisita = -1
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoVisitasPVAdd"), Panel).Visible = False
        LimpiarVisitaTecnica()
        CType(source, DataList).EditItemIndex = -1
        CType(source, DataList).SelectedIndex = -1
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyectoVisitasPV_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoVisita As New dsAppTableAdapters.ProyectoVisitasTecnicasTableAdapter

        Try
            taProyectoVisita.Delete(dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex))
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoVisitasPVAdd"), Panel).Visible = False
            LimpiarVisitaTecnica()
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaVisitas()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:026"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoVisita.Dispose()
        End Try
    End Sub

    Protected Sub dtlProyectoVisitasPV_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoVisitasPVAdd"), Panel).Visible = False
        CurrentCveVisita = CType(source, DataList).DataKeys(e.Item.ItemIndex)
        LimpiarVisitaTecnica()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("odsProyectoVisitasPV"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(source, DataList).DataKeyField.ToString & " = " & CType(source, DataList).DataKeys(e.Item.ItemIndex)
        CType(source, DataList).EditItemIndex = 0
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyectoVisitasPV_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoVisitasPVAdd"), Panel).Visible = False
        LimpiarVisitaTecnica()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("odsProyectoVisitasPV"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(sender, DataList).DataKeyField.ToString & " = " & CType(sender, DataList).DataKeys(CType(sender, DataList).SelectedIndex)
        CType(sender, DataList).SelectedIndex = 0
        CType(sender, DataList).DataBind()
        CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblInstalacionesPVSel"), Label).Text = CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblInstalacionesPVSel"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblAsistentesPVSel"), Label).Text = CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblAsistentesPVSel"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblObservacionesPVSel"), Label).Text = CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblObservacionesPVSel"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        'SelPestaniaVisitas()
    End Sub

    Protected Sub dtlProyectoVisitasPV_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoVisita As New dsAppTableAdapters.ProyectoVisitasTecnicasTableAdapter

        Try
            taProyectoVisita.ActualizarVisitaTecnica( _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtInstalacionesPVEdt"), TextBox).Text, _
                CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpEdoMpioPVEdt"), UpdatePanel).FindControl("ddlEstadoPVEdt"), DropDownList).SelectedValue, _
                CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpEdoMpioPVEdt"), UpdatePanel).FindControl("ddlMpioPVEdt"), DropDownList).SelectedValue.PadLeft(5, "0"c), _
                CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaVisitaPVEdt"), UpdatePanel).FindControl("dtpkFechaVisitaPVEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtAsistentesPVEdt"), TextBox).Text, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtAvanceGralPVEdt"), TextBox).Text, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("chkbEntregaProdsPVEdt"), CheckBox).Checked, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtObservacionesPVEdt"), TextBox).Text, _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex))
            CType(source, DataList).EditItemIndex = -1
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaVisitas()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:027"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvInstalacionesPVEdt"), CustomValidator).IsValid = False
        Finally
            taProyectoVisita.Dispose()
        End Try
    End Sub

    Protected Sub dtlProyectoVisitasPV_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse _
            e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Visita As dsApp.ProyectoVisitasTecnicasRow = _
                CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                           dsApp.ProyectoVisitasTecnicasRow)

            Dim db As ImageButton = _
                CType(e.Item.FindControl("ibtnEliminarPVItm"), ImageButton)

            db.OnClientClick = String.Format( _
               "return confirm('¿Desea eliminar la visita del {0} y los acuerdos relacionados a esta?');", _
                Format(Visita.FechaVisita, "D").Replace("'", "\'"))
        End If
    End Sub

    Protected Sub ibtnNuevoPVAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoVisitasPVAdd"), Panel).Visible = Not CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoVisitasPVAdd"), Panel).Visible
    End Sub

    Protected Sub ibtnGuardarPVAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim taProyectoVisita As New dsAppTableAdapters.ProyectoVisitasTecnicasTableAdapter

        Try
            taProyectoVisita.InsertarVisitaTecnica( _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtInstalacionesPVAdd"), TextBox).Text, _
                CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpEdoMpioPVAdd"), UpdatePanel).FindControl("ddlEstadoPVAdd"), DropDownList).SelectedValue, _
                CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpEdoMpioPVAdd"), UpdatePanel).FindControl("ddlMpioPVAdd"), DropDownList).SelectedValue.PadLeft(5, "0"c), _
                CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaVisPVAdd"), UpdatePanel).FindControl("dtpkFechaVisPVAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtAsistentesPVAdd"), TextBox).Text, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtAvanceGralPVAdd"), TextBox).Text, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("chkbEntregaProdsPVAdd"), CheckBox).Checked, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtObservacionesPVAdd"), TextBox).Text)
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoVisitasPVAdd"), Panel).Visible = False
            LimpiarVisitaTecnica()
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaVisitas()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:028"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoVisita.Dispose()
        End Try
    End Sub

    Protected Sub ibtnCancelarPVAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoVisitasPVAdd"), Panel).Visible = False
        LimpiarVisitaTecnica()
    End Sub

    Protected Sub updpEdoMpioPVEdt_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CType(CType(sender, UpdatePanel).FindControl("ddlEstadoPVEdt"), DropDownList).SelectedValue = _
            CType(CType(sender, UpdatePanel).FindControl("hdnEstadoPVEdt"), HiddenField).Value) Then
            CType(CType(sender, UpdatePanel).FindControl("ddlMpioPVEdt"), DropDownList).DataBind()
            CType(CType(sender, UpdatePanel).FindControl("ddlMpioPVEdt"), DropDownList).SelectedValue = CType(CType(sender, UpdatePanel).FindControl("hdnMpioPVEdt"), HiddenField).Value
        Else
            CType(CType(sender, UpdatePanel).FindControl("ddlMpioPVEdt"), DropDownList).SelectedValue = "-1"
            CType(CType(sender, UpdatePanel).FindControl("hdnMpioPVEdt"), HiddenField).Value = "-1"
        End If
    End Sub

    Protected Sub ddlEstadoPVEdt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (CType(sender, DropDownList).SelectedValue = _
            CType(CType(sender, DropDownList).Parent.Parent.FindControl("hdnEstadoPVEdt"), HiddenField).Value) Then
            CType(CType(sender, DropDownList).Parent.Parent.FindControl("ddlMpioPVEdt"), DropDownList).DataBind()
            CType(CType(sender, DropDownList).Parent.Parent.FindControl("ddlMpioPVEdt"), DropDownList).SelectedValue = CType(CType(sender, UpdatePanel).FindControl("hdnMpioPVEdt"), HiddenField).Value
        Else
            CType(CType(sender, DropDownList).Parent.Parent.FindControl("ddlMpioPVEdt"), DropDownList).SelectedValue = "-1"
            CType(CType(sender, DropDownList).Parent.Parent.FindControl("hdnMpioPVEdt"), HiddenField).Value = "-1"
        End If

    End Sub

#End Region

#Region "ProyectoVisitaAcuerdo"
    Private Sub LimpiarAcuerdo()
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("txtDescAcuerdoPVAAdd"), TextBox).Text = String.Empty
        CType(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("updpFechaVenPVAAdd"), UpdatePanel).FindControl("dtpkFechaVenPVAAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("chkbCumplidoPVAAdd"), CheckBox).Checked = False
    End Sub

    Private Sub SelPestaniaVisitasVisitas()
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("ibtnProyectoVisitasPVEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_sel.gif"
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("ibtnProyVisitasAcuerdosPVEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_va_rep.gif"
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("mviewVisitasAcuerdos"), MultiView).SetActiveView(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("viewVisitas"), View))
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("odsProyectoVisitasPV"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).DataKeyField.ToString & " = " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).DataBind()
    End Sub

    Private Sub SelPestaniaVisitasAcuerdos()
        'CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("odsProyVisitaAcuerdoPVA"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).DataKeyField.ToString & " = " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("ibtnProyVisitasAcuerdosPVEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_va_sel.gif"
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("ibtnProyectoVisitasPVEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_rep.gif"
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("mviewVisitasAcuerdos"), MultiView).SetActiveView(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("viewAcuerdos"), View))
    End Sub

    Protected Sub ibtnProyectoVisitasPVEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaVisitasVisitas()
    End Sub

    Protected Sub ibtnProyVisitasAcuerdosPVEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaVisitasAcuerdos()
    End Sub

    Protected Sub dtlProyVisitaAcuerdoPVA_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("pnlProyectoVisitaAcuerdoAdd"), Panel).Visible = False
        LimpiarAcuerdo()
        CType(source, DataList).EditItemIndex = -1
        CType(source, DataList).SelectedIndex = -1
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyVisitaAcuerdoPVA_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoVisitaAcuerdo As New dsAppTableAdapters.AcuerdosVisitasTableAdapter

        Try
            taProyectoVisitaAcuerdo.Delete(CType(source, DataList).DataKeys(e.Item.ItemIndex), _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex), _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex))
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("pnlProyectoVisitaAcuerdoAdd"), Panel).Visible = False
            LimpiarAcuerdo()
            CType(source, DataList).DataBind()
            'CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).DataBind()
            'dtlProyectos.DataBind()
            'SelPestaniaVisitas()
            'SelPestaniaVisitasAcuerdos()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:029"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoVisitaAcuerdo.Dispose()
        End Try
    End Sub

    Protected Sub dtlProyVisitaAcuerdoPVA_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("pnlProyectoVisitaAcuerdoAdd"), Panel).Visible = False
        LimpiarAcuerdo()
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("odsProyVisitaAcuerdoPVA"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).DataKeyField.ToString & " = " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex) & " AND " & CType(source, DataList).DataKeyField.ToString & " = " & CType(source, DataList).DataKeys(e.Item.ItemIndex)
        CType(source, DataList).EditItemIndex = 0
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyVisitaAcuerdoPVA_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoVisitaAcuerdo As New dsAppTableAdapters.AcuerdosVisitasTableAdapter

        Try
            taProyectoVisitaAcuerdo.ActualizarAcuerdo( _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtDescAcuerdoPVAEdt"), TextBox).Text, _
                CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaVenPVAEdt"), UpdatePanel).FindControl("dtpkFechaVenPVAEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("chkbCumplidoPVAEdt"), CheckBox).Checked, _
                CType(source, DataList).DataKeys(e.Item.ItemIndex), _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex), _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex))
            CType(source, DataList).EditItemIndex = -1
            CType(source, DataList).DataBind()
            'CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).DataBind()
            'SelPestaniaVisitas()
            'SelPestaniaVisitasAcuerdos()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:030"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvDescAcuerdoPVAEdt"), CustomValidator).IsValid = False
        Finally
            taProyectoVisitaAcuerdo.Dispose()
        End Try
    End Sub

    Protected Sub dtlProyVisitaAcuerdoPVA_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse _
            e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Acuerdo As dsApp.AcuerdosVisitasRow = _
                CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                           dsApp.AcuerdosVisitasRow)

            Dim db As ImageButton = _
                CType(e.Item.FindControl("ibtnEliminarPVAItm"), ImageButton)

            db.OnClientClick = String.Format( _
                "return confirm('¿Desea eliminar el acuerdo {0}?');", _
                Acuerdo.DescAcuerdo.Replace("'", "\'"))
        End If
    End Sub

    Protected Sub ibtnNuevoPVAAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("pnlProyectoVisitaAcuerdoAdd"), Panel).Visible = Not CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("pnlProyectoVisitaAcuerdoAdd"), Panel).Visible
    End Sub

    Protected Sub ibtnGuardarPVAAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim taProyectoVisitaAcuerdo As New dsAppTableAdapters.AcuerdosVisitasTableAdapter

        Try
            taProyectoVisitaAcuerdo.InsertarAcuerdo( _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex), _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString, _
                CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("txtDescAcuerdoPVAAdd"), TextBox).Text, _
                CDate(CType(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("updpFechaVenPVAAdd"), UpdatePanel).FindControl("dtpkFechaVenPVAAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("chkbCumplidoPVAAdd"), CheckBox).Checked)
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("pnlProyectoVisitaAcuerdoAdd"), Panel).Visible = False
            LimpiarAcuerdo()
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("dtlProyVisitaAcuerdoPVA"), DataList).DataBind()
            'SelPestaniaVisitas()
            'SelPestaniaVisitasAcuerdos()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:031"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("cuvDescAcuerdoPVAAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoVisitaAcuerdo.Dispose()
        End Try
    End Sub

    Protected Sub ibtnCancelarPVAAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlProyectoVisitasPV"), DataList).EditItemIndex + 1).FindControl("pnlProyectoVisitaAcuerdoAdd"), Panel).Visible = False
        LimpiarAcuerdo()
    End Sub

    Protected Sub odsProyVisitaAcuerdoPVA_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs)
        e.InputParameters("CveProyecto") = CurrentCveProyecto()
        e.InputParameters("CveVisita") = CurrentCveVisita()
    End Sub

#End Region

#Region "ProyectoEtapa"

    Private Sub LimpiarEtapa()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtNumEtapaPETAdd"), TextBox).Text = String.Empty
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtDescEtapaPETAdd"), TextBox).Text = String.Empty
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtDescMetaPETAdd"), TextBox).Text = String.Empty
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtActividadesPETAdd"), TextBox).Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaInicioPETAdd"), UpdatePanel).FindControl("dtpkFechaInicioPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaTermPETAdd"), UpdatePanel).FindControl("dtpkFechaTermPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaInfFinPETAdd"), UpdatePanel).FindControl("dtpkFechaInfFinPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtMontoMinPETAdd"), TextBox).Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaProgPETAdd"), UpdatePanel).FindControl("dtpkFechaProgPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaFactPETAdd"), UpdatePanel).FindControl("dtpkFechaFactPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtNumProrrogaPETAdd"), TextBox).Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaRealPETAdd"), UpdatePanel).FindControl("dtpkFechaRealPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaInfTecPETAdd"), UpdatePanel).FindControl("dtpkFechaInfTecPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtObservacionesPETAdd"), TextBox).Text = String.Empty
    End Sub

    Private Sub SelPestaniaEtapas()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_sel.gif"
        '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pr_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pa_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_es_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_st_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dm_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dd_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_sg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ad_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnInfraestructuraEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_in_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("mviewProyectosEdt"), MultiView).SetActiveView(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("viewEtapasEdt"), View))
    End Sub

    Protected Sub ibtnEtapasEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaEtapas()
    End Sub

    Protected Sub dtlEtapasPET_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoEtapasPETAdd"), Panel).Visible = False
        CurrentCveEtapa = -1
        LimpiarEtapa()
        CType(source, DataList).EditItemIndex = -1
        CType(source, DataList).SelectedIndex = -1
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlEtapasPET_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoEtapa As New dsAppTableAdapters.ProyectoEtapaTableAdapter
        Dim dtEtapaProductos As New dsApp.EtapaProductosDataTable
        Dim taEtapaProductos As New dsAppTableAdapters.EtapaProductosTableAdapter

        Try
            taEtapaProductos.FillByCveProyectoYCveEtapa(dtEtapaProductos, dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex))
            taProyectoEtapa.Delete(CType(source, DataList).DataKeys(e.Item.ItemIndex), dtlProyectos.DataKeys(dtlProyectos.EditItemIndex))
            For Each drEtProd As dsApp.EtapaProductosRow In dtEtapaProductos.Rows
                If System.IO.File.Exists(Server.MapPath(PathProducts & drEtProd.Ubicacion.ToString.Substring(drEtProd.Ubicacion.ToString.LastIndexOf("/") + 1))) Then
                    System.IO.File.Delete(Server.MapPath(PathProducts & drEtProd.Ubicacion.ToString.Substring(drEtProd.Ubicacion.ToString.LastIndexOf("/") + 1)))
                End If
            Next
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoEtapasPETAdd"), Panel).Visible = False
            LimpiarEtapa()
            CType(source, DataList).DataBind()

            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaEtapas()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:032"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvInstalacionesPVAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoEtapa.Dispose()
        End Try
    End Sub

    Protected Sub dtlEtapasPET_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoEtapasPETAdd"), Panel).Visible = False
        CurrentCveEtapa = CType(source, DataList).DataKeys(e.Item.ItemIndex)
        LimpiarEtapa()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("odsEtapasPET"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(source, DataList).DataKeyField.ToString & " = " & CType(source, DataList).DataKeys(e.Item.ItemIndex)
        CType(source, DataList).EditItemIndex = 0
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlEtapasPET_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoEtapasPETAdd"), Panel).Visible = False
        'LimpiarEtapa()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("odsEtapasPET"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(sender, DataList).DataKeyField.ToString & " = " & CType(sender, DataList).DataKeys(CType(sender, DataList).SelectedIndex)
        CType(sender, DataList).SelectedIndex = 0
        CType(sender, DataList).DataBind()
        CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblDescEtapaPETSel"), Label).Text = CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblDescEtapaPETSel"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblDescMetaPETSel"), Label).Text = CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblDescMetaPETSel"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblActividadesPETSel"), Label).Text = CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblActividadesPETSel"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblObservacionesPETSel"), Label).Text = CType(CType(sender, DataList).Controls.Item(CType(sender, DataList).SelectedIndex + 1).FindControl("lblObservacionesPETSel"), Label).Text.Replace(Chr(13) & Chr(10), "<br>")
        SelPestaniaEtapas()
    End Sub

    Protected Sub dtlEtapasPET_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoEtapa As New dsAppTableAdapters.ProyectoEtapaTableAdapter

        Try
            taProyectoEtapa.ActualizarEtapa( _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtNumEtapaPETEdt"), TextBox).Text, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtDescEtapaPETEdt"), TextBox).Text, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtDescMetaPETEdt"), TextBox).Text, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtActividadesPETEdt"), TextBox).Text, _
                CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaInicioPETEdt"), UpdatePanel).FindControl("dtpkFechaInicioPETEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaTermPETEdt"), UpdatePanel).FindControl("dtpkFechaTermPETEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaInfFinPETEdt"), UpdatePanel).FindControl("dtpkFechaInfFinPETEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtMontoMinPETEdt"), TextBox).Text, _
                CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaProgPETEdt"), UpdatePanel).FindControl("dtpkFechaInicioPETEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaFactPETEdt"), UpdatePanel).FindControl("dtpkFechaInicioPETEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtNumProrrogaPETEdt"), TextBox).Text, _
                CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaRealPETEdt"), UpdatePanel).FindControl("dtpkFechaRealPETEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaInfTecPETEdt"), UpdatePanel).FindControl("dtpkFechaInfTecPETEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtObservacionesPETEdt"), TextBox).Text, _
                CType(source, DataList).DataKeys(e.Item.ItemIndex), dtlProyectos.DataKeys(dtlProyectos.EditItemIndex))
            CType(source, DataList).EditItemIndex = -1
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaEtapas()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:034"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvNumEtapaPETEdt"), CustomValidator).IsValid = False
        Finally
            taProyectoEtapa.Dispose()
        End Try

    End Sub

    Protected Sub dtlEtapasPET_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse _
            e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Etapa As dsApp.ProyectoEtapaRow = _
                CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                           dsApp.ProyectoEtapaRow)

            Dim db As ImageButton = _
                CType(e.Item.FindControl("ibtnEliminarPETItm"), ImageButton)

            db.OnClientClick = String.Format( _
                "return confirm('¿Desea eliminar la etapa {0} y los productos relacionados a esta?');", _
                Etapa.DescEtapa.Replace("'", "\'"))
        End If
    End Sub

    Protected Sub ibtnNuevoPETAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoEtapasPETAdd"), Panel).Visible = Not CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoEtapasPETAdd"), Panel).Visible
    End Sub

    Protected Sub ibtnGuardarPETAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim taProyectoEtapa As New dsAppTableAdapters.ProyectoEtapaTableAdapter

        Try
            'taProyectoEtapa.Insert( _
            '    dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString, _
            '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtNumEtapaPETAdd"), TextBox).Text, _
            '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtDescEtapaPETAdd"), TextBox).Text, _
            '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtDescMetaPETAdd"), TextBox).Text, _
            '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtActividadesPETAdd"), TextBox).Text, _
            '    CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaInicioPETAdd"), UpdatePanel).FindControl("dtpkFechaInicioPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaTermPETAdd"), UpdatePanel).FindControl("dtpkFechaTermPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaInfFinPETAdd"), UpdatePanel).FindControl("dtpkFechaInfFinPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CDec(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtMontoMinPETAdd"), TextBox).Text), _
            '    CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaProgPETAdd"), UpdatePanel).FindControl("dtpkFechaProgPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaFactPETAdd"), UpdatePanel).FindControl("dtpkFechaFactPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CInt(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtNumProrrogaPETAdd"), TextBox).Text), _
            '    CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaRealPETAdd"), UpdatePanel).FindControl("dtpkFechaRealPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaInfTecPETAdd"), UpdatePanel).FindControl("dtpkFechaInfTecPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
            '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtObservacionesPETAdd"), TextBox).Text)
            Dim minvaldate As Date = CDate("1900/01/01")
            taProyectoEtapa.Insert( _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtNumEtapaPETAdd"), TextBox).Text, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtDescEtapaPETAdd"), TextBox).Text, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtDescMetaPETAdd"), TextBox).Text, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtActividadesPETAdd"), TextBox).Text, _
                CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaInicioPETAdd"), UpdatePanel).FindControl("dtpkFechaInicioPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaTermPETAdd"), UpdatePanel).FindControl("dtpkFechaTermPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                minvaldate, _
                CDec(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtMontoMinPETAdd"), TextBox).Text), _
                minvaldate, _
                minvaldate, _
                CInt(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtNumProrrogaPETAdd"), TextBox).Text), _
                minvaldate, _
                minvaldate, _
                CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtObservacionesPETAdd"), TextBox).Text)
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoEtapasPETAdd"), Panel).Visible = False

            'Se cancelaron
            'CDate(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpFechaInfFinPETAdd"), UpdatePanel).FindControl("dtpkFechaInfFinPETAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _

            LimpiarEtapa()
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaEtapas()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave" + ex.Message
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvNumEtapaPETAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoEtapa.Dispose()
        End Try

    End Sub

    Protected Sub ibtnCancelarPETAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlProyectoEtapasPETAdd"), Panel).Visible = False
        LimpiarEtapa()
    End Sub

#End Region

#Region "ProyectoEtapaProducto"

    Private Sub LimpiarProducto()
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("txtProductoPEPAdd"), TextBox).Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("ddlTipoProductoPEPAdd"), DropDownList).SelectedIndex = -1
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("txtTituloPEPAdd"), TextBox).Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("chkbEntregadoPEPAdd"), CheckBox).Checked = False
        CType(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("updpFechaEntPEPAdd"), UpdatePanel).FindControl("dtpkFechaEntPEPAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("txtPalabrasClavePEPAdd"), TextBox).Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("txtDescripcionCortaPEPAdd"), TextBox).Text = String.Empty
    End Sub

    Private Sub SelPestaniaEtapasEtapa()
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("ibtnProyectoEtapaPEPEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_sel.gif"
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("ibtnProyectoEtapaProductoPEPEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ep_rep.gif"
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("mviewEtapaProductoPEP"), MultiView).SetActiveView(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("viewEtapaPEP"), View))
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("odsEtapasPET"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).DataKeyField.ToString & " = " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).DataBind()
    End Sub

    Private Sub SelPestaniaEtapasProductos()
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("ibtnProyectoEtapaPEPEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_rep.gif"
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("ibtnProyectoEtapaProductoPEPEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ep_sel.gif"
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("mviewEtapaProductoPEP"), MultiView).SetActiveView(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("viewProductoPEP"), View))
    End Sub

    Protected Sub ibtnProyectoEtapaPEPEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaEtapasEtapa()
    End Sub

    Protected Sub ibtnProyectoEtapaProductoPEPEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaEtapasProductos()
    End Sub

    Protected Sub dtlProyectoEtapaProductoPEP_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("pnlProyectoEtapaProductoPEPAdd"), Panel).Visible = False
        LimpiarProducto()
        CType(source, DataList).EditItemIndex = -1
        CType(source, DataList).SelectedIndex = -1
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyectoEtapaProductoPEP_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoEtapaProducto As New dsAppTableAdapters.EtapaProductosTableAdapter
        Dim dtProyectoEtapaProducto As New dsApp.EtapaProductosDataTable
        '********* LUIS RANGEL 2008/02/06 ******
        'Obtener las Claves
        Dim CveEtapa As Integer = Convert.ToInt32(CType(CType(source, DataList).Parent.FindControl("hdfCveEtapa"), HiddenField).Value)
        Dim CveProyecto As String = CType(CType(source, DataList).Parent.FindControl("hdfCveProyecto"), HiddenField).Value

        Try
            'taProyectoEtapaProducto.FillByCveProyectoCveEtapaCveProducto(dtProyectoEtapaProducto, _
            '    dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), _
            '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex), _
            '    CType(source, DataList).DataKeys(e.Item.ItemIndex))
            taProyectoEtapaProducto.FillByCveProyectoCveEtapaCveProducto(dtProyectoEtapaProducto, _
                CveProyecto, _
                CveEtapa, _
                CType(source, DataList).DataKeys(e.Item.ItemIndex))
            'taProyectoEtapaProducto.Delete( _
            '    CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex), _
            '    dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), _
            '    CType(source, DataList).DataKeys(e.Item.ItemIndex))
            taProyectoEtapaProducto.Delete( _
                CveEtapa, _
                CveProyecto, _
                CType(source, DataList).DataKeys(e.Item.ItemIndex))
            '***** TERMINA LUIS RANGEL *************
            For Each drProductos As dsApp.EtapaProductosRow In dtProyectoEtapaProducto.Rows
                'Eliminar el(los) archivo PDF relacionado al producto
                Dim ArrArchivo() As String = drProductos.Ubicacion.ToString.Split("|")
                For Each strArchivo As String In ArrArchivo 'Ciclo por cada archivo
                    If System.IO.File.Exists(Server.MapPath(PathProducts & strArchivo)) Then
                        System.IO.File.Delete(Server.MapPath(PathProducts & strArchivo))
                    End If
                Next strArchivo
                'If System.IO.File.Exists(Server.MapPath(PathProducts & drProductos.Ubicacion.ToString.Substring(drProductos.Ubicacion.ToString.LastIndexOf("/") + 1))) Then
                '    System.IO.File.Delete(Server.MapPath(PathProducts & drProductos.Ubicacion.ToString.Substring(drProductos.Ubicacion.ToString.LastIndexOf("/") + 1)))
                'End If
            Next
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("pnlProyectoEtapaProductoPEPAdd"), Panel).Visible = False
            LimpiarProducto()
            CType(source, DataList).DataBind()
            'dtlProyectos.DataBind()
            'CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).DataBind()
            'SelPestaniaEtapas()
            'SelPestaniaEtapasProductos()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:036"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoEtapaProducto.Dispose()
        End Try
    End Sub

    Protected Sub dtlProyectoEtapaProductoPEP_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("pnlProyectoEtapaProductoPEPAdd"), Panel).Visible = False
        LimpiarProducto()
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("odsProyEtapaProductoPEP"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).DataKeyField.ToString & " = " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex) & " AND " & CType(source, DataList).DataKeyField.ToString & " = " & CType(source, DataList).DataKeys(e.Item.ItemIndex)
        CType(source, DataList).EditItemIndex = 0
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlProyectoEtapaProductoPEP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("pnlProyectoEtapaProductoPEPAdd"), Panel).Visible = False
        LimpiarProducto()
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("odsProyEtapaProductoPEP"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).DataKeyField.ToString & " = " & CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex) & " AND " & CType(sender, DataList).DataKeyField.ToString & " = " & CType(sender, DataList).DataKeys(CType(sender, DataList).SelectedIndex)
        CType(sender, DataList).SelectedIndex = 0
        CType(sender, DataList).DataBind()
    End Sub

    Protected Sub dtlProyectoEtapaProductoPEP_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoEtapaProducto As New dsAppTableAdapters.EtapaProductosTableAdapter
        '******* LUIS RANGEL 2008/02/06 *************
        'Obtener las Claves
        Dim CveEtapa As Integer = Convert.ToInt32(CType(CType(source, DataList).Parent.FindControl("hdfCveEtapa"), HiddenField).Value)
        Dim CveProyecto As String = CType(CType(source, DataList).Parent.FindControl("hdfCveProyecto"), HiddenField).Value

        Try
            'Actualizar el producto con las claves correctas
            taProyectoEtapaProducto.ActualizarProducto( _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtProductoPEPEdt"), TextBox).Text, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtTituloPEPEdt"), TextBox).Text, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("chkbEntregadoPEPEdt"), CheckBox).Checked, _
                CDate(CType(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("updpFechaEntPEPEdt"), UpdatePanel).FindControl("dtpkFechaEntPEPEdt"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("ddlTipoProductoPEPAdd"), DropDownList).SelectedValue, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("lblArchivoPEPEdt"), Label).Text, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtPalabrasClavePEPEdt"), TextBox).Text, _
                CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtDescripcionCortaPEPEdt"), TextBox).Text, _
                CveEtapa, _
                CveProyecto, _
                CType(source, DataList).DataKeys(e.Item.ItemIndex))
            '***** FIN LUIS RANGEL *****
            CType(source, DataList).EditItemIndex = -1
            CType(source, DataList).DataBind()
            'CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).DataBind()
            'SelPestaniaEtapas()
            'SelPestaniaEtapasProductos()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:036"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvProductoPEPEdt"), CustomValidator).IsValid = False
        Finally
            taProyectoEtapaProducto.Dispose()
        End Try

    End Sub

    Protected Sub dtlProyectoEtapaProductoPEP_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse _
            e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Producto As dsApp.EtapaProductosRow = _
                CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                           dsApp.EtapaProductosRow)

            Dim db As ImageButton = _
                CType(e.Item.FindControl("ibtnEliminarPEPItm"), ImageButton)

            db.OnClientClick = String.Format( _
                "return confirm('¿Desea eliminar el producto con el título {0}?');", _
                Producto.Titulo.Replace("'", "\'"))
        End If
    End Sub

    Protected Sub ibtnNuevoPEPAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("pnlProyectoEtapaProductoPEPAdd"), Panel).Visible = Not CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("pnlProyectoEtapaProductoPEPAdd"), Panel).Visible
    End Sub

    'Protected Sub poloKISS(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim cveProyectoPolo As Label = CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("poloCveProyecto"), Label)
    '    Dim cveEtapaPolo As Label = CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("poloCveEtapa"), Label)
    '    cveProyectoPolo.Text = dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString
    '    cveEtapaPolo.Text = CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).DataKeys(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex)
    'End Sub

    Protected Sub ibtnGuardarPEPAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim taProyectoEtapaProducto As New dsAppTableAdapters.EtapaProductosTableAdapter
        Dim boolAgregarRegistro As Boolean = True
        Dim NewNameArchivo As String = String.Empty
        Dim cuvGen As CustomValidator, cuvFile As CustomValidator
        Dim panelAdd As Panel = CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("pnlProyectoEtapaProductoPEPAdd"), Panel)

        cuvGen = CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator)
        Try
            'Hacer un ciclo por cada archivo
            Dim numeroArchivoCargados As Integer = 0
            Dim tempFile As FileUpload
            Dim textoFilesProductos As String = String.Empty
            Dim strExtArchivo As String
            Dim strExtPermitidas As String() = {".pdf"}
            Dim bolExtPermitida As Boolean
            For i As Integer = 1 To 5
                Try
                    tempFile = CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("flupArchivoPEPAdd_" + i.ToString()), FileUpload)
                    cuvFile = CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvArchivoPEPAdd_" + i.ToString()), CustomValidator)
                    If (tempFile.HasFile) Then 'hay archivo
                        'Verificamos las extenciones
                        bolExtPermitida = False
                        strExtArchivo = System.IO.Path.GetExtension(tempFile.FileName).ToLower()
                        For Each strExtPermitida As String In strExtPermitidas
                            bolExtPermitida = (strExtPermitida = strExtArchivo)
                        Next
                        If (bolExtPermitida = False) Then
                            panelAdd.Visible = True
                            cuvFile.ErrorMessage = String.Format("El tipo de archivo no esta permitido. Archivos permitidos '*{0}'", strExtPermitidas(0))
                            cuvFile.ToolTip = String.Format("El tipo de archivo no esta permitido. Archivos permitidos '*{0}'", strExtPermitidas(0))
                            cuvGen.IsValid = False
                            cuvFile.IsValid = False
                            Exit Sub
                        End If

                        'Comentario: Verificando que el archivo no exceda el límite de tamaño permitido, 
                        '   establecido en la bandera "MaxBytesArchivo" del web.config (LVC)
                        If tempFile.FileBytes.Length > CInt(System.Web.Configuration.WebConfigurationManager.AppSettings("MaxBytesArchivo").ToString) Then
                            panelAdd.Visible = True
                            cuvFile.ErrorMessage = String.Format("El tamaño del archivo excede el máximo permitido ({0} KB)", CInt(System.Web.Configuration.WebConfigurationManager.AppSettings("MaxBytesArchivo").ToString) / 1000)
                            cuvFile.ToolTip = String.Format("El tamaño del archivo excede el máximo permitido ({0} KB)", CInt(System.Web.Configuration.WebConfigurationManager.AppSettings("MaxBytesArchivo").ToString) / 1000)
                            cuvGen.IsValid = False
                            cuvFile.IsValid = False
                            Exit Sub
                        End If

                        Try
                            '******* LUIS RANGEL 2009/02/05 *****
                            'Se agrega la craeacion dinamica del nombre del archivo
                            'para que no se repita en la carpeta de productos
                            Dim CveProyecto As String = CType(CType(sender, ImageButton).Parent.FindControl("boraCveProyecto"), Label).Text
                            Dim CveEtapa As Integer = Convert.ToInt32(CType(CType(sender, ImageButton).Parent.FindControl("hdboraCveEtapa"), HiddenField).Value)

                            'El nombre formado de Proyecto+Etapa+FechaActual
                            NewNameArchivo = "Prod_" & CveProyecto & "_" & CveEtapa.ToString("000") & "_" & Now().ToString("yyyy-MM-dd_hhmmss") & "_" & i.ToString()
                            'Extencion de archivo
                            NewNameArchivo = NewNameArchivo & strExtArchivo

                            'SALVAR EL ARCHIVO
                            'objChorizoFile_FileUpload.SaveAs(Server.MapPath(PathProducts) & objChorizoFile_FileUpload.FileName.Substring(objChorizoFile_FileUpload.FileName.LastIndexOfAny("\") + 1))
                            tempFile.SaveAs(Server.MapPath(PathProducts) & NewNameArchivo)
                            numeroArchivoCargados = numeroArchivoCargados + 1
                            textoFilesProductos = textoFilesProductos + "|" + NewNameArchivo
                            '******* FIN LUIS RANGEL *************
                        Catch ex As Exception
                            cuvFile.ErrorMessage = "No fue posible guardar el archivo"
                            cuvFile.ToolTip = "No fue posible guardar el archivo"
                            cuvGen.IsValid = False
                            cuvFile.IsValid = False
                        End Try

                    End If
                Catch ex As Exception
                    'No se hace nada, el error se muestra despues
                End Try
            Next i
                

            If numeroArchivoCargados > 0 Then
                Try
                    '**********  LUIS RANGEL ************
                    If (textoFilesProductos <> String.Empty) Then textoFilesProductos = textoFilesProductos.Substring(1)
                    Dim CveProyecto As String = CType(CType(sender, ImageButton).Parent.FindControl("boraCveProyecto"), Label).Text
                    Dim CveEtapa As Integer = Convert.ToInt32(CType(CType(sender, ImageButton).Parent.FindControl("hdboraCveEtapa"), HiddenField).Value)
                    taProyectoEtapaProducto.InsertarProducto( _
                        CveEtapa, _
                        CveProyecto, _
                        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("txtProductoPEPAdd"), TextBox).Text, _
                        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("txtTituloPEPAdd"), TextBox).Text, _
                        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("chkbEntregadoPEPAdd"), CheckBox).Checked, _
                        CDate(CType(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("updpFechaEntPEPAdd"), UpdatePanel).FindControl("dtpkFechaEntPEPAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text), _
                        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("ddlTipoProductoPEPAdd"), DropDownList).SelectedValue, _
                        textoFilesProductos, _
                        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("txtPalabrasClavePEPAdd"), TextBox).Text, _
                        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("txtDescripcionCortaPEPAdd"), TextBox).Text)
                    panelAdd.Visible = False
                    '********** FIN LUIS RANGEL ************
                Catch basura As Exception
                    Response.Write(" 1: ") 'este espacio estaba reservado para enviar el primer parámetro de la sub-función taProyectoEtapaProducto.InsertarProducto, pero podía no ser un string y enviar un error fatal a TODO el sistema
                    Response.Write(" 2: " & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString)
                    Response.Write(" 3: " & CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("txtProductoPEPAdd"), TextBox).Text)
                    Response.Write(" 4: " & CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("txtTituloPEPAdd"), TextBox).Text)
                    Response.Write(" 5: " & CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("chkbEntregadoPEPAdd"), CheckBox).Checked)
                    Response.Write(" 6: " & CDate(CType(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("updpFechaEntPEPAdd"), UpdatePanel).FindControl("dtpkFechaEntPEPAdd"), EclipseWebSolutions.DatePicker.DatePicker).txtDate.Text))
                    Response.Write(" 7: " & CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("ddlTipoProductoPEPAdd"), DropDownList).SelectedValue)
                    Response.Write(" 8: " & PathProducts & CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("flupArchivoPEPAdd"), FileUpload).FileName.Substring(CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("flupArchivoPEPAdd"), FileUpload).FileName.LastIndexOfAny("\") + 1))
                End Try
                'Aquí sale el Polo (y victorioso): "Había que crear una carpeta que se llamara Productos, darle premisos de escritura y volver obligatorio el campo ddlTipoProductoPEPAdd"
                CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("pnlProyectoEtapaProductoPEPAdd"), Panel).Visible = False
                LimpiarProducto()
                CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("dtlProyectoEtapaProductoPEP"), DataList).DataBind()
                SelPestaniaEtapasProductos()
                'CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).DataBind()
                'SelPestaniaEtapas()
            Else
                CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "No existe un archivo para subir"
                CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "No existe un archivo para subir"
                CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
                'SelPestaniaEtapasProductos()
                'CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).DataBind()

            End If



        Catch concurrencyEx As DBConcurrencyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:037 "
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("cuvProductoPEPAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoEtapaProducto.Dispose()
        End Try
    End Sub

    Protected Sub ibtnCancelarPEPAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).Controls.Item(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlEtapasPET"), DataList).EditItemIndex + 1).FindControl("pnlProyectoEtapaProductoPEPAdd"), Panel).Visible = False
        LimpiarProducto()
    End Sub

    'Protected Sub odsProyEtapaProductoPEP_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs)
    '    e.InputParameters("CveProyecto") = CurrentCveProyecto()
    '    e.InputParameters("CveEtapa") = CurrentCveEtapa()
    'End Sub

#End Region

#Region "ProyectoInfraestructura"

    Private Sub LimpiarInfraestructura()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtMontoInfraPIAdd"), TextBox).Text = String.Empty
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpTipoInfraestructuraPIAdd"), UpdatePanel).FindControl("ddlTipoInfraestructuraPIAdd"), DropDownList).SelectedValue = -1
        CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpTipoInfraestructuraPIAdd"), UpdatePanel).FindControl("ddlInfraestructuraPIAdd"), DropDownList).SelectedValue = -1
    End Sub

    Private Sub SelPestaniaInfraestructura()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDatosGeneralesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEtapasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_et_rep.gif"
        '**ELIMINADO** CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnProblematicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pr_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnParticipantesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_pa_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEspeciesEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_es_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnEstadosEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_st_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDetalleMontoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dm_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnDifusionDivulgaEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_dd_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnVisitasTecnicasEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_vt_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnSeguimientoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_sg_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnAdministrativoEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_ad_rep.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("ibtnInfraestructuraEdt"), ImageButton).ImageUrl = "~/images/aplicacion/pestana_in_sel.gif"
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("mviewProyectosEdt"), MultiView).SetActiveView(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("viewInfraestructuraEdt"), View))
    End Sub

    Protected Sub ibtnInfraestructuraEdt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        SelPestaniaInfraestructura()
    End Sub

    Protected Sub dtlInfraestructuraPI_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlInfraestructuraPIAdd"), Panel).Visible = False
        LimpiarInfraestructura()
        CType(source, DataList).EditItemIndex = -1
        CType(source, DataList).SelectedIndex = -1
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlInfraestructuraPI_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoInfraestructura As New dsAppTableAdapters.ProyectoInfraestructuraTableAdapter

        Try
            taProyectoInfraestructura.Delete(dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), CType(source, DataList).DataKeys(e.Item.ItemIndex))
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlInfraestructuraPIAdd"), Panel).Visible = False
            LimpiarInfraestructura()
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaEtapas()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:038"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoInfraestructura.Dispose()
        End Try

    End Sub

    Protected Sub dtlInfraestructuraPI_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlInfraestructuraPIAdd"), Panel).Visible = False
        LimpiarInfraestructura()
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("odsInfraestructuraPI"), ObjectDataSource).FilterExpression = dtlProyectos.DataKeyField.ToString & " = '" & dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString & "' AND " & CType(source, DataList).DataKeyField.ToString & " = " & CType(source, DataList).DataKeys(e.Item.ItemIndex)
        CType(source, DataList).EditItemIndex = 0
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlInfraestructuraPI_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Dim taProyectoInfraestructura As New dsAppTableAdapters.ProyectoInfraestructuraTableAdapter
        Dim CveInfraestructura As Integer = Convert.ToInt32(CType(source, DataList).DataKeys(e.Item.ItemIndex))
        Dim Monto As Double = Convert.ToDouble(CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("txtMontoInfraPIEdt"), TextBox).Text)
        Try
            taProyectoInfraestructura.Update( _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex), _
                CveInfraestructura, _
                Monto)
            CType(source, DataList).EditItemIndex = -1
            CType(source, DataList).SelectedIndex = -1
            CType(source, DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaEtapas()
        Catch concurrencyEx As DBConcurrencyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "Fila no accesible"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "Restricción no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "Expresión no válida"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "Error de datos"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:039"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(CType(source, DataList).Controls.Item(e.Item.ItemIndex + 1).FindControl("cuvTipoInfraestructuraPIEdt"), CustomValidator).IsValid = False
        Finally
            taProyectoInfraestructura.Dispose()
        End Try

    End Sub

    Protected Sub dtlInfraestructuraPI_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse _
            e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Infraestructura As dsApp.ProyectoInfraestructuraRow = _
                CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                           dsApp.ProyectoInfraestructuraRow)

            Dim db As ImageButton = _
                CType(e.Item.FindControl("ibtnEliminarPIItm"), ImageButton)

            db.OnClientClick = String.Format( _
                "return confirm('¿Desea eliminar la infraestructura {0}?');", _
                Infraestructura.Infraestructura.Replace("'", "\'"))
        End If
    End Sub

    Protected Sub ibtnNuevoPIAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlInfraestructuraPIAdd"), Panel).Visible = Not CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlInfraestructuraPIAdd"), Panel).Visible
    End Sub

    Protected Sub ibtnGuardarPIAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim taProyectoInfraestructura As New dsAppTableAdapters.ProyectoInfraestructuraTableAdapter

        Try
            taProyectoInfraestructura.Insert( _
                dtlProyectos.DataKeys(dtlProyectos.EditItemIndex).ToString, _
                CType(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("updpTipoInfraestructuraPIAdd"), UpdatePanel).FindControl("ddlInfraestructuraPIAdd"), DropDownList).SelectedValue, _
                CDec(CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("txtMontoInfraPIAdd"), TextBox).Text))
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlInfraestructuraPIAdd"), Panel).Visible = False
            LimpiarInfraestructura()
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("dtlInfraestructuraPI"), DataList).DataBind()
            'odsProyecto.FilterExpression = "CveProyecto = '" + dtlProyectos.DataKeys(dtlProyectos.EditItemIndex) + "'"
            'dtlProyectos.DataBind()
            'SelPestaniaEtapas()
        Catch concurrencyEx As DBConcurrencyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Fila no accesible"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Restricción no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Expresión no válida"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Error de datos"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar clave:040"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("cuvTipoInfraestructuraPIAdd"), CustomValidator).IsValid = False
        Finally
            taProyectoInfraestructura.Dispose()
        End Try

    End Sub

    Protected Sub ibtnCancelarPIAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        CType(dtlProyectos.Controls.Item(dtlProyectos.EditItemIndex).FindControl("pnlInfraestructuraPIAdd"), Panel).Visible = False
        LimpiarInfraestructura()

    End Sub

#End Region

#Region "Descarga de productos"
    '***** Luis RANGEL 2008/02/09 ****
    Protected Sub dtlProductosST_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)

        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then

            Dim rowProducto As dsApp.EtapaProductosRow
            'obtiene los datos
            rowProducto = CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, dsApp.EtapaProductosRow)
            Try
                'Mostrar el control por cada archivo
                Dim contador As Integer = 0
                For Each strArchivo As String In rowProducto.Ubicacion.Split("|")
                    Dim tmpbtn As ImageButton = CType(e.Item.FindControl("imgbArch" & contador.ToString), ImageButton)
                    tmpbtn.CommandName = "Download"
                    tmpbtn.CommandArgument = rowProducto.CveProyecto & "|" & _
                                           rowProducto.CveEtapa.ToString() & "|" & _
                                           rowProducto.CveProducto.ToString() & "|" & _
                                           contador.ToString()
                    tmpbtn.Visible = True
                    tmpbtn.ToolTip = strArchivo
                    contador = contador + 1
                Next strArchivo
                'Ocultar los que falten
                If (contador < 9) Then
                    For i As Integer = contador To 9
                        Dim tmpbtn As ImageButton = CType(e.Item.FindControl("imgbArch" & i.ToString), ImageButton)
                        tmpbtn.Visible = False
                    Next i
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    '**** FIN LUIS RANGEL ******
    Protected Sub dtlProductosST_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs)
        Select Case e.CommandName
            Case "Download"
                Dim strArchivo() As String = e.CommandArgument.ToString.Split("|")
                Dim taEtapaProducto As New dsAppTableAdapters.EtapaProductosTableAdapter
                Dim CveProyecto As String = strArchivo(0)
                Dim CveEtapa As Integer = CInt(strArchivo(1))
                Dim CveProducto As Integer = CInt(strArchivo(2))
                Dim NumeroFile As Integer = CInt(strArchivo(3))
                Try
                    '********* LUIS RANGEL ************
                    'Obtener los datos de la DB
                    Dim rowProducto As dsApp.EtapaProductosRow = taEtapaProducto.GetDataByCveProyectoCveEtapaCveProducto(CveProyecto, CveEtapa, CveProducto)(0)
                    Dim arrArchivo() As String = rowProducto.Ubicacion.Split("|")
                    'Entra el Polo
                    'Esta instrucción da un problema si el nombre del archivo contiene espacios (LVC)
                    'Response.AddHeader("content-disposition", "attachment; filename=" & strArchivo(3).Substring(strArchivo(3).LastIndexOf("/") + 1))
                    'No es la mejor solución, pero es cómoda (LVC)
                    Response.AddHeader("content-disposition", "attachment; filename=" & arrArchivo(NumeroFile).Replace(" ", "_"))
                    'Sale el Polo
                    'Encontrar el archivo

                    'PathProducts
                    Response.TransmitFile(Server.MapPath(PathProducts & arrArchivo(NumeroFile)))
                    taEtapaProducto.AgregarDescarga(CveProyecto, CveEtapa, CveProducto)
                    Response.End()
                    '********* FIN LUIS RANGEL *********
                Catch concurrencyEx As DBConcurrencyException
                Catch constraintEx As ConstraintException
                Catch deletedRowEx As DeletedRowInaccessibleException
                Catch duplicateNameEx As DuplicateNameException
                Catch inRowChangingEx As InRowChangingEventException
                Catch invalidConstraintEx As InvalidConstraintException
                Catch invalidExpressionEx As InvalidExpressionException
                Catch missingPrimaryEx As MissingPrimaryKeyException
                Catch noNullEx As NoNullAllowedException
                Catch readOnlyEx As ReadOnlyException
                Catch rowNotInTableEx As RowNotInTableException
                Catch strongTypingEx As StrongTypingException
                Catch typedDataSetEx As TypedDataSetGeneratorException
                Catch versionNotFoundEx As VersionNotFoundException
                Catch dataEx As DataException
                Catch ex As Exception
                Finally
                    taEtapaProducto.Dispose()
                End Try


            Case Else
                Exit Select
        End Select
    End Sub

#End Region

    
    
End Class
