Imports System.Data

Partial Class CatParticipante
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
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
            'Iniciar la navegacion
            InicializarNavegacion()
            BindGrid_Participante()
        End If
        lb_Error.Visible = False
    End Sub

    Protected Sub InicializarNavegacion()
        Grid_Participantes.PageIndex = 0
        Grid_Participantes.PageSize = 20
        Dim temp As New dsAppTableAdapters.CatParticipanteTableAdapter
        'Dim TotalRegistros As Integer = temp.TotalRegistros
        Dim TotalRegistros As Integer = temp.TotalRegistrosFiltrado(Me.txtBuscar.Text)
        If (TotalRegistros Mod 20 > 0) Then
            TotalRegistros = Math.Truncate(TotalRegistros / 20) + 1
        Else
            TotalRegistros = Math.Truncate(TotalRegistros / 20)
        End If
        lb_paginas.Text = "1"
        lb_paginas_total.Text = TotalRegistros.ToString()
        lb_paginasDown.Text = lb_paginas.Text
        lb_paginas_totalDown.Text = lb_paginas_total.Text
    End Sub

    Protected Sub BindGrid_Participante()
        'Obtener el objeto del cual vamos a recuperar los datos
        Dim temp As New dsAppTableAdapters.CatParticipanteTableAdapter
        Dim ds As New dsApp.CatParticipanteDataTable
        'ds = temp.GetParticipante()
        ds = temp.GetParticipanteBuscado(Me.txtBuscar.Text)
        Dim strDataKeyNames() As String = {"CveParticipante"}
        Me.Grid_Participantes.DataSource = ds
        Me.Grid_Participantes.DataKeyNames = strDataKeyNames
        Me.Grid_Participantes.DataBind()
    End Sub

    Protected Sub Grid_Participantes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Grid_Participantes.RowCommand
        If (e.CommandName = "cmdMas") Then
            Dim indexRow As Integer
            indexRow = Convert.ToInt32(e.CommandArgument) + 2
            Dim tempPanel As Panel
            Dim tempImg As ImageButton
            Dim tempLabel As Label
            tempPanel = CType(Grid_Participantes.Controls.Item(0).Controls(indexRow).FindControl("pnlExpandirInfoInst"), System.Web.UI.WebControls.Panel)
            tempImg = CType(Grid_Participantes.Controls.Item(0).Controls(indexRow).FindControl("imgExpandirInfoInst"), System.Web.UI.WebControls.ImageButton)
            tempLabel = CType(Grid_Participantes.Controls.Item(0).Controls(indexRow).FindControl("lblMasInfoInst"), System.Web.UI.WebControls.Label)
            If (tempPanel Is Nothing) Then
                tempPanel = CType(Grid_Participantes.Controls.Item(0).Controls(indexRow).FindControl("pnlExpandirInfoInst_alter"), System.Web.UI.WebControls.Panel)
                tempImg = CType(Grid_Participantes.Controls.Item(0).Controls(indexRow).FindControl("imgExpandirInfoInst_alter"), System.Web.UI.WebControls.ImageButton)
                tempLabel = CType(Grid_Participantes.Controls.Item(0).Controls(indexRow).FindControl("lblMasInfoInst_alter"), System.Web.UI.WebControls.Label)
            End If

            If (tempImg.ImageUrl = "~/images/aplicacion/expandir.gif") Then tempImg.ImageUrl = "~/images/aplicacion/contraer.gif" Else tempImg.ImageUrl = "~/images/aplicacion/expandir.gif"
            If (tempLabel.Text = "Más...") Then tempLabel.Text = "" Else tempLabel.Text = "Más..."
            tempPanel.Visible = Not tempPanel.Visible
        End If
    End Sub

    Protected Sub Grid_Participantes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grid_Participantes.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            'Obtener la referencia al boton eliminar
            Dim botonEliminar As ImageButton = CType(e.Row.FindControl("cmdEliminar"), ImageButton)
            Dim str_CveParticipante As String = CType(e.Row.FindControl("lb_CveParticipante"), Label).Text
            If (Not (botonEliminar Is Nothing)) Then
                botonEliminar.OnClientClick = String.Format("return confirm('¿Esta seguro de eliminar al participante {0}?');", str_CveParticipante)
            End If

            'Verificar si hay alguna en edicion y poner el focus
            Dim textoEdit As TextBox = CType(e.Row.FindControl("txt_Nombre"), TextBox)
            If (Not (textoEdit Is Nothing)) Then
                textoEdit.Focus()
            End If

            'Poner el argumento del boton para expandir
            Dim imgTemp As ImageButton
            imgTemp = CType(e.Row.FindControl("imgExpandirInfoInst"), ImageButton)
            If (imgTemp Is Nothing) Then
                imgTemp = CType(e.Row.FindControl("imgExpandirInfoInst_alter"), ImageButton)
            End If
            'Guirdar el index de la fila
            If (Not (imgTemp Is Nothing)) Then
                imgTemp.CommandArgument = e.Row.RowIndex.ToString()
            End If

        End If

    End Sub
    '**** EDIT
    Protected Sub Grid_Participantes_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles Grid_Participantes.RowEditing
        Me.Grid_Participantes.EditIndex = e.NewEditIndex
        BindGrid_Participante()
    End Sub
    '*** UPDATE
    Protected Sub Grid_Participantes_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles Grid_Participantes.RowUpdating
        'Obtener los datos de referencia a guardar
        Dim int_CveParticipante As Integer = Convert.ToInt32(CType(Me.Grid_Participantes.Rows(e.RowIndex).FindControl("lb_CveParticipante"), Label).Text)
        Dim str_Nombre As String = CType(Me.Grid_Participantes.Rows(e.RowIndex).FindControl("txt_Nombre"), TextBox).Text
        Dim str_APaterno As String = CType(Me.Grid_Participantes.Rows(e.RowIndex).FindControl("txt_APaterno"), TextBox).Text
        Dim str_AMaterno As String = CType(Me.Grid_Participantes.Rows(e.RowIndex).FindControl("txt_AMaterno"), TextBox).Text
        Dim int_CveInstitucion As Integer = Convert.ToInt32(CType(Me.Grid_Participantes.Rows(e.RowIndex).FindControl("lst_CveInstitucion"), DropDownList).SelectedValue)
        Dim str_Departamento As String = CType(Me.Grid_Participantes.Rows(e.RowIndex).FindControl("txt_Departamento"), TextBox).Text
        Dim int_CveEscolaridad As Integer = Convert.ToInt32(CType(Me.Grid_Participantes.Rows(e.RowIndex).FindControl("lst_CveEscolaridad"), DropDownList).SelectedValue)
        Dim str_Especialidad As String = CType(Me.Grid_Participantes.Rows(e.RowIndex).FindControl("txt_Especialidad"), TextBox).Text
        Dim str_TelTrabajo As String = CType(Me.Grid_Participantes.Rows(e.RowIndex).FindControl("txt_TelTrabajo"), TextBox).Text
        Dim str_TelParticular As String = CType(Me.Grid_Participantes.Rows(e.RowIndex).FindControl("txt_TelParticular"), TextBox).Text
        Dim str_Correo As String = CType(Me.Grid_Participantes.Rows(e.RowIndex).FindControl("txt_Correo"), TextBox).Text

        'Verificar que almenos contega valor la descripcion  y no se quiera insertar un campo vacio
        If (str_Nombre.Trim().Length = 0 Or int_CveParticipante = 0) Then
            'Enviar un error de mensaje
            Dim tempObj_error As Label
            tempObj_error = CType(Grid_Participantes.Rows(e.RowIndex).FindControl("lb_Error"), Label)
            tempObj_error.Text = "ERROR debe de indicar un Nombre valido"
            tempObj_error.Visible = True
            Exit Sub
        End If
        'Formatear datos
        If (str_Nombre = String.Empty) Then str_Nombre = Nothing
        If (str_APaterno = String.Empty) Then str_APaterno = Nothing
        If (str_AMaterno = String.Empty) Then str_AMaterno = Nothing
        If (int_CveInstitucion = "-1") Then int_CveInstitucion = Nothing
        If (str_Departamento = String.Empty) Then str_Departamento = Nothing
        If (int_CveEscolaridad = "-1") Then int_CveEscolaridad = Nothing
        If (str_Especialidad = String.Empty) Then str_Especialidad = Nothing
        If (str_TelTrabajo = String.Empty) Then str_TelTrabajo = Nothing
        If (str_TelParticular = String.Empty) Then str_TelParticular = Nothing
        If (str_Correo = String.Empty) Then str_Correo = Nothing


        Try
            Dim temp As New dsAppTableAdapters.CatParticipanteTableAdapter
            temp.Update(str_Nombre, int_CveInstitucion, str_Departamento, int_CveEscolaridad _
                    , str_Especialidad, str_TelTrabajo, str_TelParticular, str_Correo _
                    , str_APaterno, str_AMaterno, int_CveParticipante, int_CveParticipante)
            
        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            lb_Error.Text = ExceptionHandler.Handler(ex, "Se produjo un error al actualizar el registro intentelo m&aacute;s tarde")
            lb_Error.Visible = True
        End Try
        Grid_Participantes.EditIndex = -1
        BindGrid_Participante()
    End Sub
    '*** CANCEL
    Protected Sub Grid_Participantes_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles Grid_Participantes.RowCancelingEdit
        Me.Grid_Participantes.EditIndex = -1
        BindGrid_Participante()
    End Sub
    '*** DELETE
    Protected Sub Grid_Participantes_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Grid_Participantes.RowDeleting
        Dim int_CveParticipante As Integer = Convert.ToInt32(CType(Me.Grid_Participantes.Rows(e.RowIndex).FindControl("lb_CveParticipante"), Label).Text)
        Try
            Dim temp As New dsAppTableAdapters.CatParticipanteTableAdapter
            temp.Delete(int_CveParticipante)
            BindGrid_Participante()

        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            Dim tempObj_error As Label
            tempObj_error = CType(Me.Grid_Participantes.Rows(e.RowIndex).FindControl("lb_Error"), Label)

            tempObj_error.Text = ExceptionHandler.Handler(ex, "No se fue posible eliminar el registro")
            tempObj_error.Visible = True
        End Try
    End Sub
    '*** PAGE CHANGE
    Protected Sub Grid_Participantes_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Grid_Participantes.PageIndexChanging
        Grid_Participantes.PageIndex = e.NewPageIndex
        lb_paginas.Text = Convert.ToString(e.NewPageIndex + 1)
        lb_paginasDown.Text = lb_paginas.Text
        BindGrid_Participante()
    End Sub

#Region "Agregar participante"

    Private Sub LimpiarNuevoPart()
        txtAPaternoCatPartAdd.Text = String.Empty
        txtAmaternoCatPartAdd.Text = String.Empty
        txtNombreCatPartAdd.Text = String.Empty
        ddlInstitucionCatPartAdd.SelectedValue = -1
        txtDepartamentoCatPartAdd.Text = String.Empty
        ddlEscolaridadCatPartAdd.SelectedValue = -1
        txtEspecialidadCatPartAdd.Text = String.Empty
        txtTelTrabajoCatPartAdd.Text = String.Empty
        txtTelParticularCatPartAdd.Text = String.Empty
        txtCorreoCatPartAdd.Text = String.Empty
    End Sub

    Protected Sub ibtnNuevoCatPart_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        pnlNuevoCatPart.Visible = Not pnlNuevoCatPart.Visible
        If Not pnlNuevoCatPart.Visible Then
            LimpiarNuevoPart()
        End If
    End Sub

    Protected Sub ibtnCancelarCatPartAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        LimpiarNuevoPart()
        pnlNuevoCatPart.Visible = False
    End Sub

    Protected Sub ibtnGuardarCatPartAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim taParticipante As New dsAppTableAdapters.CatParticipanteTableAdapter

        Try
            taParticipante.Insert( _
                txtNombreCatPartAdd.Text, _
                ddlInstitucionCatPartAdd.SelectedValue, _
                txtDepartamentoCatPartAdd.Text, _
                ddlEscolaridadCatPartAdd.SelectedValue, _
                txtEspecialidadCatPartAdd.Text, _
                txtTelTrabajoCatPartAdd.Text, _
                txtTelParticularCatPartAdd.Text, _
                txtCorreoCatPartAdd.Text, _
                txtAPaternoCatPartAdd.Text, _
                txtAmaternoCatPartAdd.Text)
            pnlNuevoCatPart.Visible = False
            LimpiarNuevoPart()
            BindGrid_Participante()
            'Grid_Participantes.DataBind()

        Catch concurrencyEx As DBConcurrencyException
            cuvApaternoCatPartAdd.ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            cuvApaternoCatPartAdd.ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            cuvApaternoCatPartAdd.IsValid = False
        Catch constraintEx As ConstraintException
            cuvApaternoCatPartAdd.ErrorMessage = "Error de llaves duplicadas"
            cuvApaternoCatPartAdd.ToolTip = "Error de llaves duplicadas"
            cuvApaternoCatPartAdd.IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            cuvApaternoCatPartAdd.ErrorMessage = "Fila no accesible"
            cuvApaternoCatPartAdd.ToolTip = "Fila no accesible"
            cuvApaternoCatPartAdd.IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            cuvApaternoCatPartAdd.ErrorMessage = "Nombre duplicado"
            cuvApaternoCatPartAdd.ToolTip = "Nombre duplicado"
            cuvApaternoCatPartAdd.IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            cuvApaternoCatPartAdd.ErrorMessage = "Fila esta siendo modificada"
            cuvApaternoCatPartAdd.ToolTip = "Fila esta siendo modificada"
            cuvApaternoCatPartAdd.IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            cuvApaternoCatPartAdd.ErrorMessage = "Restricción no válida"
            cuvApaternoCatPartAdd.ToolTip = "Restricción no válida"
            cuvApaternoCatPartAdd.IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            cuvApaternoCatPartAdd.ErrorMessage = "Expresión no válida"
            cuvApaternoCatPartAdd.ToolTip = "Expresión no válida"
            cuvApaternoCatPartAdd.IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            cuvApaternoCatPartAdd.ErrorMessage = "No se encontró una llave principal"
            cuvApaternoCatPartAdd.ToolTip = "No se encontró una llave principal"
            cuvApaternoCatPartAdd.IsValid = False
        Catch noNullEx As NoNullAllowedException
            cuvApaternoCatPartAdd.ErrorMessage = "Valor nulo no permitido"
            cuvApaternoCatPartAdd.ToolTip = "Valor nulo no permitido"
            cuvApaternoCatPartAdd.IsValid = False
        Catch readOnlyEx As ReadOnlyException
            cuvApaternoCatPartAdd.ErrorMessage = "La base de datos es de solo lectura"
            cuvApaternoCatPartAdd.ToolTip = "La base de datos es de solo lectura"
            cuvApaternoCatPartAdd.IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            cuvApaternoCatPartAdd.ErrorMessage = "La fila solicitada no esta en la base de datos"
            cuvApaternoCatPartAdd.ToolTip = "La fila solicitada no esta en la base de datos"
            cuvApaternoCatPartAdd.IsValid = False
        Catch strongTypingEx As StrongTypingException
            cuvApaternoCatPartAdd.ErrorMessage = "Error en tipos de datos"
            cuvApaternoCatPartAdd.ToolTip = "Error en tipos de datos"
            cuvApaternoCatPartAdd.IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            cuvApaternoCatPartAdd.ErrorMessage = "No fue posible generar el conjunto de datos"
            cuvApaternoCatPartAdd.ToolTip = "No fue posible generar el conjunto de datos"
            cuvApaternoCatPartAdd.IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            cuvApaternoCatPartAdd.ErrorMessage = "Versión no encontrada"
            cuvApaternoCatPartAdd.ToolTip = "Versión no encontrada"
            cuvApaternoCatPartAdd.IsValid = False
        Catch dataEx As DataException
            cuvApaternoCatPartAdd.ErrorMessage = "Error de datos"
            cuvApaternoCatPartAdd.ToolTip = "Error de datos"
            cuvApaternoCatPartAdd.IsValid = False
        Catch ex As Exception
            cuvApaternoCatPartAdd.ErrorMessage = "Ocurrió un error al intentar guardar"
            cuvApaternoCatPartAdd.ToolTip = "Ocurrió un error al intentar guardar"
            cuvApaternoCatPartAdd.IsValid = False
        Finally
            taParticipante.Dispose()
        End Try
    End Sub

#End Region

#Region "Busqueda"
    Protected Sub ibtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnBuscar.Click
        InicializarNavegacion()
        BindGrid_Participante()
    End Sub
#End Region


End Class
