Imports System.Data
Partial Class Permisos
    Inherits System.Web.UI.Page

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
            End If
        End If
    End Sub

    Protected Sub dtlUsuarios_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlUsuarios.CancelCommand
        CType(source, DataList).EditItemIndex = -1
        CType(source, DataList).SelectedIndex = -1
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlUsuarios_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlUsuarios.DeleteCommand
        Dim taUsuarioNivel As New dsAppTableAdapters.CatUsuarioTableAdapter

        Try
            taUsuarioNivel.Delete(dtlUsuarios.DataKeys(e.Item.ItemIndex))
            CType(source, DataList).DataBind()
        Catch concurrencyEx As DBConcurrencyException
            cuvAsignarNivel.ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            cuvAsignarNivel.ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            cuvAsignarNivel.IsValid = False
        Catch constraintEx As ConstraintException
            cuvAsignarNivel.ErrorMessage = "Error de llaves duplicadas"
            cuvAsignarNivel.ToolTip = "Error de llaves duplicadas"
            cuvAsignarNivel.IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            cuvAsignarNivel.ErrorMessage = "Fila no accesible"
            cuvAsignarNivel.ToolTip = "Fila no accesible"
            cuvAsignarNivel.IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            cuvAsignarNivel.ErrorMessage = "Nombre duplicado"
            cuvAsignarNivel.ToolTip = "Nombre duplicado"
            cuvAsignarNivel.IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            cuvAsignarNivel.ErrorMessage = "Fila esta siendo modificada"
            cuvAsignarNivel.ToolTip = "Fila esta siendo modificada"
            cuvAsignarNivel.IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            cuvAsignarNivel.ErrorMessage = "Restricción no válida"
            cuvAsignarNivel.ToolTip = "Restricción no válida"
            cuvAsignarNivel.IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            cuvAsignarNivel.ErrorMessage = "Expresión no válida"
            cuvAsignarNivel.ToolTip = "Expresión no válida"
            cuvAsignarNivel.IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            cuvAsignarNivel.ErrorMessage = "No se encontró una llave principal"
            cuvAsignarNivel.ToolTip = "No se encontró una llave principal"
            cuvAsignarNivel.IsValid = False
        Catch noNullEx As NoNullAllowedException
            cuvAsignarNivel.ErrorMessage = "Valor nulo no permitido"
            cuvAsignarNivel.ToolTip = "Valor nulo no permitido"
            cuvAsignarNivel.IsValid = False
        Catch readOnlyEx As ReadOnlyException
            cuvAsignarNivel.ErrorMessage = "La base de datos es de solo lectura"
            cuvAsignarNivel.ToolTip = "La base de datos es de solo lectura"
            cuvAsignarNivel.IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            cuvAsignarNivel.ErrorMessage = "La fila solicitada no esta en la base de datos"
            cuvAsignarNivel.ToolTip = "La fila solicitada no esta en la base de datos"
            cuvAsignarNivel.IsValid = False
        Catch strongTypingEx As StrongTypingException
            cuvAsignarNivel.ErrorMessage = "Error en tipos de datos"
            cuvAsignarNivel.ToolTip = "Error en tipos de datos"
            cuvAsignarNivel.IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            cuvAsignarNivel.ErrorMessage = "No fue posible generar el conjunto de datos"
            cuvAsignarNivel.ToolTip = "No fue posible generar el conjunto de datos"
            cuvAsignarNivel.IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            cuvAsignarNivel.ErrorMessage = "Versión no encontrada"
            cuvAsignarNivel.ToolTip = "Versión no encontrada"
            cuvAsignarNivel.IsValid = False
        Catch dataEx As DataException
            cuvAsignarNivel.ErrorMessage = "Error de datos"
            cuvAsignarNivel.ToolTip = "Error de datos"
            cuvAsignarNivel.IsValid = False
        Catch ex As Exception
            cuvAsignarNivel.ErrorMessage = "Ocurrió un error al intentar guardar"
            cuvAsignarNivel.ToolTip = "Ocurrió un error al intentar guardar"
            cuvAsignarNivel.IsValid = False
        Finally
            taUsuarioNivel.Dispose()
        End Try

    End Sub

    Protected Sub dtlUsuarios_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlUsuarios.EditCommand
        odsNivelesUsuario.FilterExpression = "CveUsuario = '" & dtlUsuarios.DataKeys(e.Item.ItemIndex).ToString & "'"
        dtlUsuarios.EditItemIndex = 0
        CType(source, DataList).DataBind()
    End Sub

    Protected Sub dtlUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtlUsuarios.SelectedIndexChanged
        odsNivelesUsuario.FilterExpression = "CveUsuario = '" & dtlUsuarios.DataKeys(dtlUsuarios.SelectedIndex).ToString & "'"
        dtlUsuarios.SelectedIndex = 0
        CType(sender, DataList).DataBind()
    End Sub

    Protected Sub dtlUsuarios_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlUsuarios.UpdateCommand
        Dim taUsuarioNivel As New dsAppTableAdapters.CatUsuarioTableAdapter

        Try
            taUsuarioNivel.ActualizarNivel( _
                CType(e.Item.FindControl("ddlNivelPUEdt"), DropDownList).SelectedValue, _
                dtlUsuarios.DataKeys(dtlUsuarios.EditItemIndex))
            CType(source, DataList).EditItemIndex = -1
            CType(source, DataList).DataBind()
        Catch concurrencyEx As DBConcurrencyException
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "No se pueden guardar los datos porque la base de datos esta siendo utilizada"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Catch constraintEx As ConstraintException
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "Error de llaves duplicadas"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "Error de llaves duplicadas"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Catch deletedRowEx As DeletedRowInaccessibleException
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "Fila no accesible"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "Fila no accesible"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Catch duplicateNameEx As DuplicateNameException
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "Nombre duplicado"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "Nombre duplicado"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Catch inRowChangingEx As InRowChangingEventException
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "Fila esta siendo modificada"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "Fila esta siendo modificada"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Catch invalidConstraintEx As InvalidConstraintException
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "Restricción no válida"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "Restricción no válida"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Catch invalidExpressionEx As InvalidExpressionException
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "Expresión no válida"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "Expresión no válida"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Catch missingPrimaryEx As MissingPrimaryKeyException
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "No se encontró una llave principal"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "No se encontró una llave principal"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Catch noNullEx As NoNullAllowedException
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "Valor nulo no permitido"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "Valor nulo no permitido"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Catch readOnlyEx As ReadOnlyException
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "La base de datos es de solo lectura"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "La base de datos es de solo lectura"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Catch rowNotInTableEx As RowNotInTableException
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "La fila solicitada no esta en la base de datos"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "La fila solicitada no esta en la base de datos"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Catch strongTypingEx As StrongTypingException
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "Error en tipos de datos"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "Error en tipos de datos"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Catch typedDataSetEx As TypedDataSetGeneratorException
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "No fue posible generar el conjunto de datos"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "No fue posible generar el conjunto de datos"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Catch versionNotFoundEx As VersionNotFoundException
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "Versión no encontrada"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "Versión no encontrada"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Catch dataEx As DataException
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "Error de datos"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "Error de datos"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Catch ex As Exception
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ErrorMessage = "Ocurrió un error al intentar guardar"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).ToolTip = "Ocurrió un error al intentar guardar"
            CType(e.Item.FindControl("cuvNivelUsuarioPUEdt"), CustomValidator).IsValid = False
        Finally
            taUsuarioNivel.Dispose()
        End Try
    End Sub

    Protected Sub dtlUsuarios_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dtlUsuarios.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse _
           e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim Usuario As dsApp.CatUsuarioRow = _
                CType(CType(e.Item.DataItem, System.Data.DataRowView).Row, _
                           dsApp.CatUsuarioRow)

            Dim db As ImageButton = _
                CType(e.Item.FindControl("ibtnEliminarPUItm"), ImageButton)

            db.OnClientClick = String.Format( _
                "return confirm('¿Desea eliminar el usuario {0}?');", _
                Usuario.CveUsuario.Replace("'", "\'"))
        End If
    End Sub
End Class
