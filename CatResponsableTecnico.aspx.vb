
Partial Class CatResponsableTecnico
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If (Not IsPostBack) Then
            If (Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) IsNot Nothing) Then
                Select Case CInt(Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoNivel").ToString))
                    Case clsAuthentication.AuthorizationLevelList.Administering
                        Exit Select
                    Case clsAuthentication.AuthorizationLevelList.Financial
                        Page.Response.Redirect("~/Inicio.aspx", True)

                    Case clsAuthentication.AuthorizationLevelList.LimitedUpdating
                        Page.Response.Redirect("~/Inicio.aspx", True)
                    Case clsAuthentication.AuthorizationLevelList.Consulting
                        Page.Response.Redirect("~/Inicio.aspx", True)
                    Case Else
                        Page.Response.Redirect("~/Inicio.aspx", True)
                End Select
            Else
                Page.Response.Redirect("~/Inicio.aspx", True)
            End If
            MultiViewRespTecnico.SetActiveView(ViewLista)
            Session("BusquedaRespTecnico") = String.Empty
        End If
        lbError.Text = String.Empty
    End Sub
    

#Region "Nuevo"
    Private Sub LimpiarNuevo()
        txtNombreAdd.Text = String.Empty
        txtUbicacionAdd.Text = String.Empty
        txtInfoAdd.Text = String.Empty
    End Sub

    Protected Sub imgbNuevoRespTecnico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbNuevoRespTecnico.Click
        LimpiarNuevo()
        MultiViewRespTecnico.SetActiveView(ViewAdd)
    End Sub

    Protected Sub imgbCancelarAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbCancelarAdd.Click
        MultiViewRespTecnico.SetActiveView(ViewLista)
    End Sub

    Protected Sub imgbGuardarAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbGuardarAdd.Click
        'Obtener objeto
        Dim taRespTecnico As dsAppTableAdapters.CatResponsableTecnicoTableAdapter = New dsAppTableAdapters.CatResponsableTecnicoTableAdapter

        Try
            taRespTecnico.Insert(txtNombreAdd.Text, txtUbicacionAdd.Text, txtInfoAdd.Text)
            MultiViewRespTecnico.SetActiveView(ViewLista)
            GridViewRespTecnico.DataBind()
        Catch ex As Exception
            lbError.Text = "ERROR: " & ex.Message
        End Try
    End Sub
#End Region

#Region "Lista"

#Region "Busqueda"
    Protected Sub imgbBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbBuscar.Click
        If (Me.txtBusqueda.Text.Trim() <> String.Empty) Then
            Session("BusquedaRespTecnico") = "Nombre+' '+Ubicacion+' '+info like '%" & Me.txtBusqueda.Text.Trim() & "%'"
        Else
            Session("BusquedaRespTecnico") = String.Empty
        End If
        GridViewRespTecnico.DataBind()
    End Sub

    Protected Sub lnkMostrarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMostrarTodos.Click
        Session("BusquedaRespTecnico") = String.Empty
        txtBusqueda.Text = String.Empty
        GridViewRespTecnico.DataBind()
    End Sub

    Protected Sub odsRespTecnico_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles odsRespTecnico.Selecting
        If (GridViewRespTecnico.EditIndex = -1) Then 'Solo si no es edicion porque ya trae filtro
            odsRespTecnico.FilterExpression = Session("BusquedaRespTecnico")
        End If
        If (Session("BusquedaRespTecnico") = String.Empty) Then lnkMostrarTodos.Visible = False Else lnkMostrarTodos.Visible = True
    End Sub

    Protected Sub GridViewRespTecnico_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridViewRespTecnico.RowEditing
        'Filtrar para que solo se vea uno
        odsRespTecnico.FilterExpression = GridViewRespTecnico.DataKeyNames(0) & "=" & GridViewRespTecnico.DataKeys(e.NewEditIndex).Value
        GridViewRespTecnico.EditIndex = 0
        e.Cancel = True
    End Sub
#End Region

    

#End Region

    
    
    
    
End Class
