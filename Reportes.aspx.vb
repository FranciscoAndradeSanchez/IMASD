
Partial Class Reportes
    Inherits System.Web.UI.Page

#Region "Parámetros de los reportes"

#Region "Parámetros reporte estatus de proyectos"

    Private Property AnioConvRepEst() As Integer
        Get
            Dim o As Object = ViewState("vsAnioConvRepEst")
            If o Is Nothing Then
                Return 1900
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("vsAnioConvRepEst") = value
        End Set
    End Property

    Private Property TipoApoyoRepEst() As String
        Get
            Dim o As Object = ViewState("vsTipoApoyoRepEst")
            If o Is Nothing Then
                Return "--"
            Else
                Return CType(o, String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("vsTipoApoyoRepEst") = value
        End Set
    End Property

    Private Property EstatusRepEst() As Integer
        Get
            Dim o As Object = ViewState("vsEstatusRepEst")
            If o Is Nothing Then
                Return -1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("vsEstatusRepEst") = value
        End Set
    End Property

    Private Property RegionRepEst() As String
        Get
            Dim o As Object = ViewState("vsRegionRepEst")
            If o Is Nothing Then
                Return "---"
            Else
                Return CType(o, String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("vsRegionRepEst") = value
        End Set
    End Property

    Private Property TituloRepEst() As String
        Get
            Dim o As Object = ViewState("vsTituloRepEst")
            If o Is Nothing Then
                Return "Estatus general de los proyectos"
            Else
                Return CType(o, String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("vsTituloRepEstVS") = value
        End Set
    End Property

    Protected Sub ibtnReporteRepEst_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnReporteRepEst.Click

        AnioConvRepEst = ddlAnioConvocatoriaRepEst.SelectedValue
        TipoApoyoRepEst = ddlTipoApoyoRepEst.SelectedValue
        EstatusRepEst = ddlEstatusRepEst.SelectedValue
        RegionRepEst = ddlRegionRepEst.SelectedValue
        TituloRepEst = "Estatus general de los proyectos"
        If Not (ddlAnioConvocatoriaRepEst.SelectedValue = 1900) Then
            TituloRepEst &= ", del " & ddlAnioConvocatoriaRepEst.SelectedItem.Text
        End If
        If Not (ddlRegionRepEst.SelectedValue = "---") Then
            TituloRepEst &= ", de la " & ddlRegionRepEst.SelectedItem.Text
        End If
        If Not (ddlTipoApoyoRepEst.SelectedValue = "--") Then
            TituloRepEst &= ", del " & ddlTipoApoyoRepEst.SelectedItem.Text
        End If
        If Not (ddlEstatusRepEst.SelectedValue = -1) Then
            TituloRepEst &= ", en " & ddlEstatusRepEst.SelectedItem.Text
        End If

        BindReport(CInt(Request.QueryString("rpt")))
    End Sub

#End Region

#Region "Parámetros reportes financieros"

    Private Property TipoReporteRepFin() As Integer
        Get
            Dim o As Object = ViewState("vsTipoReporteRepFin")
            If o Is Nothing Then
                Return 2
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("vsTipoReporteRepFin") = value
        End Set
    End Property

    Private Property FechaInicialRepFin() As Date
        Get
            Dim o As Object = ViewState("vsFechaInicialRepFin")
            If o Is Nothing Then
                Return New Date(1900, 1, 1)
            Else
                Return CType(o, Date)
            End If
        End Get
        Set(ByVal value As Date)
            ViewState("vsFechaInicialRepFin") = value
        End Set
    End Property

    Private Property FechaFinalRepFin() As Date
        Get
            Dim o As Object = ViewState("vsFechaFinalRepFin")
            If o Is Nothing Then
                Return New Date(1900, 1, 1)
            Else
                Return CType(o, Date)
            End If
        End Get
        Set(ByVal value As Date)
            ViewState("vsFechaFinalRepFin") = value
        End Set
    End Property

    Private Property AnioConvRepFin() As Integer
        Get
            Dim o As Object = ViewState("vsAnioConvRepFin")
            If o Is Nothing Then
                Return 1900
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("vsAnioConvRepFin") = value
        End Set
    End Property

    Private Property EstatusPagoRepFin() As Integer
        Get
            Dim o As Object = ViewState("vsEstatusPagoRepFin")
            If o Is Nothing Then
                Return -1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("vsEstatusPagoRepFin") = value
        End Set
    End Property

    Private Property TituloRepFin() As String
        Get
            Dim o As Object = ViewState("vsTituloRepFin")
            If o Is Nothing Then
                Return "Estado de cuenta de los proyectos"
            Else
                Return CType(o, String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("vsTituloRepFin") = value
        End Set
    End Property

    Protected Sub ddlTipoReporte_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case ddlTipoReporte.SelectedValue
            Case 2
                pnlParRepPagosProg.Visible = True
                pnlEdoCuentaRepFin.Visible = False
            Case 3
                pnlParRepPagosProg.Visible = False
                pnlEdoCuentaRepFin.Visible = True
            Case Else
                pnlParRepPagosProg.Visible = True
                pnlEdoCuentaRepFin.Visible = False
        End Select
    End Sub

    Protected Sub ibtnMostrarReporteRepFin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnMostrarReporteRepFin.Click
        Select Case ddlTipoReporte.SelectedValue
            Case 2
                TipoReporteRepFin = ddlTipoReporte.SelectedValue
                FechaInicialRepFin = dtpkFechaInicialRepFin.DateValue
                FechaFinalRepFin = dtpkFechaFinalRepFin.DateValue
                EstatusPagoRepFin = ddlEstatusPagoRepFin.SelectedValue
                AnioConvRepFin = 1900
            Case 3
                TipoReporteRepFin = ddlTipoReporte.SelectedValue
                FechaInicialRepFin = New Date(1900, 1, 1)
                FechaFinalRepFin = New Date(Year(Date.Now), 12, 31)
                EstatusPagoRepFin = -1
                AnioConvRepFin = ddlAnioConvRepFin.SelectedValue
                TituloRepFin = "Estado de cuenta de los proyectos"
                If Not (ddlAnioConvRepFin.SelectedValue = 1900) Then
                    TituloRepFin &= " del " & ddlAnioConvRepFin.SelectedValue.ToString
                End If

            Case Else
                TipoReporteRepFin = ddlTipoReporte.SelectedValue
                FechaInicialRepFin = New Date(1900, 1, 1)
                FechaFinalRepFin = New Date(Year(Date.Now), 12, 31)
                EstatusPagoRepFin = -1
                AnioConvRepFin = 1900
        End Select
        BindReport(CInt(Request.QueryString("rpt")))
    End Sub

#End Region

#Region "Parámetros del reporte acumulado"
    Private Const EspacioLibre As Integer = 12600

    Private Property AgrupamientoRepAcu() As String
        Get
            Dim o As Object = ViewState("vsAgrupamientoRepAcu")
            If o Is Nothing Then
                Return String.Empty
            Else
                Return CType(o, String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("vsAgrupamientoRepAcu") = value
        End Set
    End Property

    Private Property AnioConvRepAcu() As Integer
        Get
            Dim o As Object = ViewState("vsAnioConvRepAcu")
            If o Is Nothing Then
                Return 1900
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("vsAnioConvRepAcu") = value
        End Set
    End Property

    Private Property RegionRepAcu() As String
        Get
            Dim o As Object = ViewState("vsRegionRepAcu")
            If o Is Nothing Then
                Return "---"
            Else
                Return CType(o, String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("vsRegionRepAcu") = value
        End Set
    End Property

    Protected Sub ibtnMostrarReporteRepAcu_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnMostrarReporteRepAcu.Click
        AgrupamientoRepAcu = String.Empty
        cuvAgruparPorRepAcu.IsValid = False
        For Each lstiAgrupamiento As ListItem In chkblAgruparRepAcu.Items
            If lstiAgrupamiento.Selected Then
                cuvAgruparPorRepAcu.IsValid = True
                AgrupamientoRepAcu &= lstiAgrupamiento.Value & ","
            End If
        Next
        If cuvAgruparPorRepAcu.IsValid Then
            AgrupamientoRepAcu = AgrupamientoRepAcu.Substring(0, AgrupamientoRepAcu.Length - 1)
            AnioConvRepAcu = ddlAnioConvRepAcu.SelectedValue
            RegionRepAcu = ddlRegionRepAcu.SelectedValue
            BindReport(CInt(Request.QueryString("rpt")))
        End If
    End Sub

    Private Sub FormatoReporte(ByRef repsReporte As CrystalDecisions.CrystalReports.Engine.ReportDocument)
        Dim intOffset As Integer
        Dim strElementos() As String = AgrupamientoRepAcu.Split(",")
        Dim intNumElementos As Integer = strElementos.Length
        Dim intIzqElemActual As Integer = 1000
        Dim Linea As CrystalDecisions.CrystalReports.Engine.LineObject
        

        If AgrupamientoRepAcu = String.Empty Then
            repsReporte.ReportDefinition.ReportObjects.Item("txtAnio").Width = 13600
            repsReporte.ReportDefinition.ReportObjects.Item("fldAnio").Width = 13600
        Else
            Linea = CType(repsReporte.ReportDefinition.ReportObjects.Item("Line1"), CrystalDecisions.CrystalReports.Engine.LineObject)
            Linea.ObjectFormat.EnableSuppress = False
            repsReporte.ReportDefinition.ReportObjects.Item("txtAnio").Width = intIzqElemActual
            repsReporte.ReportDefinition.ReportObjects.Item("fldAnio").Width = intIzqElemActual
            intOffset = EspacioLibre / intNumElementos
            Dim contador = 2

            For Each strElemento As String In strElementos
                repsReporte.ReportDefinition.ReportObjects.Item("txt" & strElemento).Left = intIzqElemActual
                repsReporte.ReportDefinition.ReportObjects.Item("fld" & strElemento).Left = intIzqElemActual
                repsReporte.ReportDefinition.ReportObjects.Item("txt" & strElemento).Width = intOffset
                repsReporte.ReportDefinition.ReportObjects.Item("fld" & strElemento).Width = intOffset
                repsReporte.ReportDefinition.ReportObjects.Item("txt" & strElemento).ObjectFormat.EnableSuppress = False
                repsReporte.ReportDefinition.ReportObjects.Item("fld" & strElemento).ObjectFormat.EnableSuppress = False
                intIzqElemActual += intOffset
                Linea = CType(repsReporte.ReportDefinition.ReportObjects.Item("Line" & contador.ToString), CrystalDecisions.CrystalReports.Engine.LineObject)
                Dim bottom As Integer = Linea.Bottom
                Linea.Bottom = Linea.Top
                Linea.Right = intIzqElemActual
                Linea.Left = intIzqElemActual
                Linea.Bottom = bottom
                Linea.LineStyle = CrystalDecisions.Shared.LineStyle.SingleLine
                Linea.ObjectFormat.EnableSuppress = False
                contador += 1
            Next
        End If
    End Sub

#End Region

#Region "Parámetros del reporte de productos"

    Private Property AnioConvRepPro() As Integer
        Get
            Dim o As Object = ViewState("vsAnioConvRepPro")
            If o Is Nothing Then
                Return 1900
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("vsAnioConvRepPro") = value
        End Set
    End Property

    Private Property TipoApoyoRepPro() As String
        Get
            Dim o As Object = ViewState("vsTipoApoyoRepPro")
            If o Is Nothing Then
                Return "--"
            Else
                Return CType(o, String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("vsTipoApoyoRepPro") = value
        End Set
    End Property

    Private Property AreaTematicaRepPro() As Integer
        Get
            Dim o As Object = ViewState("vsAreaTematicaRepPro")
            If o Is Nothing Then
                Return -1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("vsAreaTematicaRepPro") = value
        End Set
    End Property

    Private Property EntregadoRepPro() As Integer
        Get
            Dim o As Object = ViewState("vsEntregadoRepPro")
            If o Is Nothing Then
                Return -1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("vsEntregadoRepPro") = value
        End Set
    End Property

    Protected Sub ibtnMostrarReporteRepPro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnMostrarReporteRepPro.Click
        AnioConvRepPro = ddlAnioConvRepPro.SelectedValue
        TipoApoyoRepPro = ddlTipoApoyoRepPro.SelectedValue
        AreaTematicaRepPro = ddlAreaTematicaRepPro.SelectedValue
        EntregadoRepPro = ddlEstatusRepPro.SelectedValue
        BindReport(CInt(Request.QueryString("rpt")))

    End Sub

#End Region

#Region "Parámetros del reporte de productos descargados"

    Private Property NumeroProductos() As Integer
        Get
            Dim o As Object = ViewState("vsNumProductos")
            If o Is Nothing Then
                Return 20
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("vsNumProductos") = value
        End Set
    End Property

    Protected Sub imgbMostrarRepDesc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbMostrarRepDesc.Click
        'NumeroProductos = CInt(txtNumProductos.Text)
        BindReport(CInt(Request.QueryString("rpt")))
    End Sub

#End Region

#Region "Parámetros del reporte de usuarios"

    Private Property ClaveEstado() As String
        Get
            Dim o As Object = ViewState("vsCveEstadoRepUsr")
            If o Is Nothing Then
                Return "--"
            Else
                Return CType(o, String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("vsCveEstadoRepUsr") = value
        End Set

    End Property

    Private Property ClaveUsoInfo() As Integer
        Get
            Dim o As Object = ViewState("vsUsoInfoRepUsr")
            If o Is Nothing Then
                Return -1
            Else
                Return CType(o, Integer)
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("vsUsoInfoRepUsr") = value
        End Set
    End Property

    Private Property TituloRepUsr() As String
        Get
            Dim o As Object = ViewState("vsTituloRepUsr")
            If o Is Nothing Then
                Return "Reporte de usuarios del sistema"
            Else
                Return CType(o, String)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("vsTituloRepUsr") = value
        End Set

    End Property

    Protected Sub imgbMostrarRepUsr_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbMostrarRepUsr.Click
        ClaveEstado = ddlEstadoRepUsr.SelectedValue
        ClaveUsoInfo = ddlUsoInfoRepUsr.SelectedValue
        TituloRepUsr = "Reporte de usuarios del sistema"
        If Not (ddlEstadoRepUsr.SelectedValue = "--") Then
            TituloRepUsr &= " del Estado de " & ddlEstadoRepUsr.SelectedItem.Text
        End If
        If Not (CInt(ddlUsoInfoRepUsr.SelectedValue) = -1) Then
            TituloRepUsr &= " y '" & ddlUsoInfoRepUsr.SelectedItem.Text & "' como uso de información"
        End If
        BindReport(CInt(Request.QueryString("rpt")))
    End Sub

#End Region

#Region "Parámetros del reporte de beneficiarios"

    Protected Sub imgbMostrarRepBen_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbMostrarRepBen.Click
        'BeneficiariosDesde = CInt(txtBeneficiariosDesde.Text)
        'BeneficiariosHasta = CInt(txtBeneficiariosHasta.Text)
        BindReport(CInt(Request.QueryString("rpt")))
    End Sub

#End Region

#End Region

#Region "Código de la página"

    Private Sub BindReport(ByVal indexReporte As Integer)
        Dim dsProiectus As New dsApp

        Select Case indexReporte
            Case 1
                mviewReportes.SetActiveView(viewFiltrarEstatusProyectos)
                Dim taReporte As New dsAppTableAdapters.spReporteEstatusProyectoTableAdapter

                taReporte.FillReporteEstatusProyecto(dsProiectus.spReporteEstatusProyecto)
                crsrReportes.Report.FileName = "crEstatusProyecto.rpt"
                crsrReportes.ReportDocument.SetDataSource(dsProiectus)
                crvwReportes.HasToggleGroupTreeButton = False
                crvwReportes.EnableDrillDown = False
                crvwReportes.HasDrillUpButton = False
                crvwReportes.DisplayGroupTree = False
                crsrReportes.ReportDocument.SetParameterValue("TituloReporte", TituloRepEst)
                crsrReportes.ReportDocument.SetParameterValue("AnioConvocatoria", AnioConvRepEst)
                crsrReportes.ReportDocument.SetParameterValue("TipoApoyo", TipoApoyoRepEst)
                crsrReportes.ReportDocument.SetParameterValue("Estatus", EstatusRepEst)
                crsrReportes.ReportDocument.SetParameterValue("Region", RegionRepEst)
                crvwReportes.ReportSource = crsrReportes
                crvwReportes.DataBind()
            Case 2
                mviewReportes.SetActiveView(viewFiltrarFinancieros)
                Select Case TipoReporteRepFin
                    Case 2
                        Dim taReporte As New dsAppTableAdapters.spReportePagosProgramadosTableAdapter

                        taReporte.FillPagosProgramados(dsProiectus.spReportePagosProgramados, FechaInicialRepFin, FechaFinalRepFin.AddDays(1), EstatusPagoRepFin)
                        crsrReportes.Report.FileName = "crPagosProgramados.rpt"
                        crsrReportes.ReportDocument.SetDataSource(dsProiectus)
                        crvwReportes.HasToggleGroupTreeButton = False
                        crvwReportes.EnableDrillDown = False
                        crvwReportes.HasDrillUpButton = False
                        crvwReportes.DisplayGroupTree = False
                        crsrReportes.ReportDocument.SetParameterValue("FechaInicial", FechaInicialRepFin)
                        crsrReportes.ReportDocument.SetParameterValue("FechaFinal", FechaFinalRepFin)

                        crvwReportes.ReportSource = crsrReportes
                        crvwReportes.DataBind()
                    Case 3
                        Dim taReporte As New dsAppTableAdapters.spReporteEstadoCuentaTableAdapter

                        taReporte.FillEstadodeCuenta(dsProiectus.spReporteEstadoCuenta, AnioConvRepFin)
                        crsrReportes.Report.FileName = "crEstadodeCuenta.rpt"
                        crsrReportes.ReportDocument.SetDataSource(dsProiectus)
                        crvwReportes.HasToggleGroupTreeButton = False
                        crvwReportes.EnableDrillDown = False
                        crvwReportes.HasDrillUpButton = False
                        crvwReportes.DisplayGroupTree = False
                        crsrReportes.ReportDocument.SetParameterValue("TituloReporte", TituloRepFin)
                        crvwReportes.ReportSource = crsrReportes
                        crvwReportes.DataBind()
                    Case Else
                        Dim taReporte As New dsAppTableAdapters.spReportePagosProgramadosTableAdapter

                        taReporte.FillPagosProgramados(dsProiectus.spReportePagosProgramados, FechaInicialRepFin, FechaFinalRepFin.AddDays(1), EstatusPagoRepFin)
                        crsrReportes.Report.FileName = "crPagosProgramados.rpt"
                        crsrReportes.ReportDocument.SetDataSource(dsProiectus)
                        crvwReportes.HasToggleGroupTreeButton = False
                        crvwReportes.EnableDrillDown = False
                        crvwReportes.HasDrillUpButton = False
                        crvwReportes.DisplayGroupTree = False
                        crsrReportes.ReportDocument.SetParameterValue("FechaInicial", FechaInicialRepFin)
                        crsrReportes.ReportDocument.SetParameterValue("FechaFinal", FechaFinalRepFin)
                        crvwReportes.ReportSource = crsrReportes
                        crvwReportes.DataBind()
                End Select
            Case 3
                mviewReportes.SetActiveView(viewFiltrarAcumulado)
                Dim taReporte As New dsAppTableAdapters.ReporteAcumuladoTableAdapter
                'Dim dtReporte As dsApp.ReporteAcumuladoDataTable
                'dtReporte = taReporte.GetData(1900, "---", "")
                dsProiectus.ReporteAcumulado.Clear()
                'dsProiectus.spReporteAcumulado = taReporte.GetData(1900, "---", "")
                taReporte.Fill(dsProiectus.ReporteAcumulado, AnioConvRepAcu, RegionRepAcu, AgrupamientoRepAcu)
                'taReporte.Fill(dsProiectus.ReporteAcumulado, 1900, "---", "")
                crsrReportes.Report.FileName = "crAcumuladoProyectos.rpt"
                crsrReportes.ReportDocument.SetDataSource(dsProiectus)
                crvwReportes.HasToggleGroupTreeButton = False
                crvwReportes.EnableDrillDown = False
                crvwReportes.HasDrillUpButton = False
                crvwReportes.DisplayGroupTree = False
                FormatoReporte(crsrReportes.ReportDocument)
                crvwReportes.ReportSource = crsrReportes
                crvwReportes.DataBind()
            Case 4
                mviewReportes.SetActiveView(viewFiltrarProductos)
                Dim taReporte As New dsAppTableAdapters.spReporteProductosTableAdapter
                taReporte.FillReporteProductos(dsProiectus.spReporteProductos, AnioConvRepPro, TipoApoyoRepPro, AreaTematicaRepPro, EntregadoRepPro)
                crsrReportes.Report.FileName = "crProductos.rpt"
                crsrReportes.ReportDocument.SetDataSource(dsProiectus)
                crvwReportes.HasToggleGroupTreeButton = False
                crvwReportes.EnableDrillDown = False
                crvwReportes.HasDrillUpButton = False
                crvwReportes.DisplayGroupTree = False
                crvwReportes.ReportSource = crsrReportes
                crvwReportes.DataBind()
            Case 5
                mviewReportes.SetActiveView(viewFiltrarDescargas)
                Dim taReporte As New dsAppTableAdapters.spReporteProductosDescargadosTableAdapter
                taReporte.FillProductosDescargados(dsProiectus.spReporteProductosDescargados)
                crsrReportes.Report.FileName = "crDescargados.rpt"
                crsrReportes.ReportDocument.SetDataSource(dsProiectus)
                crvwReportes.HasToggleGroupTreeButton = False
                crvwReportes.EnableDrillDown = False
                crvwReportes.HasDrillUpButton = False
                crvwReportes.DisplayGroupTree = False
                crvwReportes.ReportSource = crsrReportes
                crvwReportes.DataBind()
            Case 6
                mviewReportes.SetActiveView(viewFiltrarUsuarios)
                Dim taReporte As New dsAppTableAdapters.spReporteUsuariosTableAdapter
                taReporte.FillReporteUsuarios(dsProiectus.spReporteUsuarios)
                crsrReportes.Report.FileName = "crUsuarios.rpt"
                crsrReportes.ReportDocument.SetDataSource(dsProiectus)
                crvwReportes.HasToggleGroupTreeButton = False
                crvwReportes.EnableDrillDown = False
                crvwReportes.HasDrillUpButton = False
                crvwReportes.DisplayGroupTree = False
                crsrReportes.ReportDocument.SetParameterValue("CveEstado", ClaveEstado)
                crsrReportes.ReportDocument.SetParameterValue("CveUsoInfo", ClaveUsoInfo)
                crsrReportes.ReportDocument.SetParameterValue("TituloReporte", TituloRepUsr)
                crvwReportes.ReportSource = crsrReportes
                crvwReportes.DataBind()
            Case 7
                mviewReportes.SetActiveView(viewFiltrarBeneficiarios)
                Dim taReporte As New dsAppTableAdapters.spReporteBeneficiariosTableAdapter
                taReporte.FillReporteBeneficiarios(dsProiectus.spReporteBeneficiarios, txtBeneficiariosDesde.Text, txtBeneficiariosHasta.Text)
                crsrReportes.Report.FileName = "crBeneficiarios.rpt"
                crsrReportes.ReportDocument.SetDataSource(dsProiectus)
                crvwReportes.HasToggleGroupTreeButton = False
                crvwReportes.EnableDrillDown = False
                crvwReportes.HasDrillUpButton = False
                crvwReportes.DisplayGroupTree = False
                crvwReportes.ReportSource = crsrReportes
                crvwReportes.DataBind()
            Case 8 'INFRAESTRUCTURA
                mviewReportes.SetActiveView(viewFiltrarInfraestructura)
                Dim taReporte As New dsAppTableAdapters.spReporteInfraestructuraTableAdapter
                Dim NomPro As String = IIf(Me.txtProyectoRepInfra Is Nothing, "", Me.txtProyectoRepInfra.Text)
                Dim Region As String = IIf(Me.ddlRegionRepInfra.Items.Count = 0, "---", Me.ddlRegionRepInfra.SelectedValue)
                Dim Institucion As Integer = -1
                If (Me.ddlInstitucionRepInfra.Items.Count > 0) Then
                    Institucion = Convert.ToInt32(Me.ddlInstitucionRepInfra.SelectedValue)
                End If

                taReporte.FillReporteInfraestructura(dsProiectus.spReporteInfraestructura, NomPro, Institucion, Region)
                crsrReportes.Report.FileName = "crInfraestructura.rpt"
                crsrReportes.ReportDocument.SetDataSource(dsProiectus)
                crvwReportes.HasToggleGroupTreeButton = False
                crvwReportes.EnableDrillDown = False
                crvwReportes.HasDrillUpButton = False
                crvwReportes.DisplayGroupTree = False
                crvwReportes.ReportSource = crsrReportes
                crvwReportes.DataBind()
            Case Else
                Exit Select
        End Select
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If (Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) IsNot Nothing) Then
                Select Case CInt(Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoNivel").ToString))
                    Case clsAuthentication.AuthorizationLevelList.Administering
                        Exit Select
                    Case clsAuthentication.AuthorizationLevelList.Financial
                        Server.Transfer("~/Inicio.aspx", False)
                    Case clsAuthentication.AuthorizationLevelList.LimitedUpdating
                        Server.Transfer("~/Inicio.aspx", False)
                    Case clsAuthentication.AuthorizationLevelList.Consulting
                        Server.Transfer("~/Inicio.aspx", False)
                    Case Else
                        Server.Transfer("~/Inicio.aspx", False)
                End Select
            Else
                Server.Transfer("~/Inicio.aspx", False)
            End If
        End If
        BindReport(CInt(Request.QueryString("rpt")))
    End Sub

#End Region


End Class
