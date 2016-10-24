
Partial Class CatTipoApoyo
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
            Bind_TipoApoyo()
        End If
        lb_Error.Visible = False
    End Sub

    Protected Sub Bind_TipoApoyo()
        'Obtener el objeto del cual vamos a recuperar los datos
        Dim temp As New dsAppTableAdapters.CatTipoApoyoTableAdapter
        Dim ds As New dsApp.CatTipoApoyoDataTable
        ds = temp.GetTipoApoyo()
        Dim strDataKeyNames() As String = {"CveTipoApoyo"}
        Me.Grid_TipoApoyo.DataSource = ds
        Me.Grid_TipoApoyo.DataKeyNames = strDataKeyNames
        Me.Grid_TipoApoyo.DataBind()
    End Sub

    Protected Sub Grid_TipoApoyo_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles Grid_TipoApoyo.RowCancelingEdit
        Me.Grid_TipoApoyo.EditIndex = -1
        Me.Grid_TipoApoyo.ShowFooter = True
        Bind_TipoApoyo()
    End Sub

    Protected Sub Grid_TipoApoyo_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Grid_TipoApoyo.RowCommand
        'Si el comando enviado es para Agregar un nuevo elemento al catalogo
        If (e.CommandName.Substring(0, 3) = "ADD") Then
            Dim str_CveTipoApoyo As String
            Dim str_DesTipoApoyo As String
            'Obtener la descripcion
            If (e.CommandName = "ADD_empty") Then
                str_CveTipoApoyo = CType(Grid_TipoApoyo.Controls(0).Controls(0).FindControl("txt_CveTipoApoyo_ADD_empty"), TextBox).Text
                str_DesTipoApoyo = CType(Grid_TipoApoyo.Controls(0).Controls(0).FindControl("txt_DesTipoApoyo_ADD_empty"), TextBox).Text
            Else
                str_CveTipoApoyo = CType(Grid_TipoApoyo.FooterRow.FindControl("txt_CveTipoApoyo_ADD"), TextBox).Text
                str_DesTipoApoyo = CType(Grid_TipoApoyo.FooterRow.FindControl("txt_DesTipoApoyo_ADD"), TextBox).Text
            End If

            'Verificar que almenos contega valor la descripcion  y no se quiera insertar un campo vacio
            If (str_DesTipoApoyo.Trim().Length = 0) Then
                'Enviar un error de mensaje
                lb_Error.Text = "ERROR debe de indicar una descripcion valida"
                lb_Error.Visible = True
                Exit Sub
            End If

            'Insertar el nuevo valor
            Try
                Dim temp As New dsAppTableAdapters.CatTipoApoyoTableAdapter
                temp.Insert(str_CveTipoApoyo, str_DesTipoApoyo)
                Bind_TipoApoyo()
            Catch ex As Exception
                Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
                CType(Me.Grid_TipoApoyo.FooterRow.FindControl("lb_Error"), Label).Text = ExceptionHandler.Handler(ex, "Se produjo un error al insertar el registro, verifique los datos")
                CType(Me.Grid_TipoApoyo.FooterRow.FindControl("lb_Error"), Label).Visible = True
            End Try
        End If 'Termina ADD
    End Sub

    Protected Sub Grid_TipoApoyo_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grid_TipoApoyo.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            'Obtener la referencia al boton eliminar
            Dim botonEliminar As ImageButton = CType(e.Row.FindControl("cmdEliminar"), ImageButton)
            If (Not (botonEliminar Is Nothing)) Then
                Dim str_CveTipoApoyo As String = CType(e.Row.FindControl("lb_CveTipoApoyo"), Label).Text
                Dim str_DesTipoApoyo As String = CType(e.Row.FindControl("lb_DesTipoApoyo"), Label).Text
                botonEliminar.OnClientClick = String.Format("return confirm('¿Esta seguro de eliminar el Municipio {0} {1}?');", str_CveTipoApoyo, str_DesTipoApoyo)
            End If

            'Verificar si hay alguna en edicion y poner el focus
            Dim textoEdit As TextBox = CType(e.Row.FindControl("txt_DesTipoApoyo"), TextBox)
            If (Not (textoEdit Is Nothing)) Then
                textoEdit.Focus()
            End If
        End If
    End Sub

    Protected Sub Grid_TipoApoyo_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Grid_TipoApoyo.RowDeleting
        Dim str_CveTipoApoyo As String = CType(Me.Grid_TipoApoyo.Rows(e.RowIndex).FindControl("lb_CveTipoApoyo"), Label).Text

        Try
            Dim temp As New dsAppTableAdapters.CatTipoApoyoTableAdapter
            temp.Delete(str_CveTipoApoyo)
            Bind_TipoApoyo()
        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            lb_Error.Text = ExceptionHandler.Handler(ex, "Se produjo un error al eliminar el registro verifique con el administrador")
            lb_Error.Visible = True
        End Try
    End Sub
    Protected Sub Grid_TipoApoyo_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles Grid_TipoApoyo.RowEditing
        Me.Grid_TipoApoyo.EditIndex = e.NewEditIndex
        Me.Grid_TipoApoyo.ShowFooter = False
        Bind_TipoApoyo()
    End Sub
    Protected Sub Grid_TipoApoyo_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles Grid_TipoApoyo.RowUpdating
        'Obtener los datos de referencia a guardar
        Dim str_CveTipoApoyo As String = CType(Me.Grid_TipoApoyo.Rows(e.RowIndex).FindControl("lb_CveTipoApoyo"), Label).Text
        Dim str_DesTipoApoyo As String = CType(Me.Grid_TipoApoyo.Rows(e.RowIndex).FindControl("txt_DesTipoApoyo"), TextBox).Text

        Try
            Dim temp As New dsAppTableAdapters.CatTipoApoyoTableAdapter
            temp.Update(str_CveTipoApoyo, str_DesTipoApoyo, str_CveTipoApoyo)
        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            lb_Error.Text = ExceptionHandler.Handler(ex, "Se produjo un error al actualizar los datos del registro verifique con el administrador")
            lb_Error.Visible = True
        End Try
        Grid_TipoApoyo.EditIndex = -1
        Grid_TipoApoyo.ShowFooter = True
        Bind_TipoApoyo()
    End Sub

End Class
