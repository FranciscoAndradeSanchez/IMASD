
Partial Class CatRegion
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
            Bind_Region()
        End If
        lb_Error.Visible = False
    End Sub

    Protected Sub Bind_Region()
        'Obtener el objeto del cual vamos a recuperar los datos
        Dim temp As New dsAppTableAdapters.CatRegionTableAdapter
        Dim ds As New dsApp.CatRegionDataTable
        ds = temp.GetRegion()
        Dim strDataKeyNames() As String = {"CveRegion"}
        Me.Grid_Region.DataSource = ds
        Me.Grid_Region.DataKeyNames = strDataKeyNames
        Me.Grid_Region.DataBind()
    End Sub

    Protected Sub Grid_Region_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles Grid_Region.RowCancelingEdit
        Me.Grid_Region.EditIndex = -1
        Me.Grid_Region.ShowFooter = True
        Bind_Region()
    End Sub

    Protected Sub Grid_Region_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Grid_Region.RowCommand
        'Si el comando enviado es para Agregar un nuevo elemento al catalogo
        If (e.CommandName.Substring(0, 3) = "ADD") Then
            Dim str_CveRegion As String
            Dim str_DesRegion As String
            'Obtener la descripcion
            If (e.CommandName = "ADD_empty") Then
                str_CveRegion = CType(Grid_Region.Controls(0).Controls(0).FindControl("txt_CveRegion_ADD_empty"), TextBox).Text
                str_DesRegion = CType(Grid_Region.Controls(0).Controls(0).FindControl("txt_DesRegion_ADD_empty"), TextBox).Text
            Else
                str_CveRegion = CType(Grid_Region.FooterRow.FindControl("txt_CveRegion_ADD"), TextBox).Text
                str_DesRegion = CType(Grid_Region.FooterRow.FindControl("txt_DesRegion_ADD"), TextBox).Text
            End If
            
            'Verificar que almenos contega valor la descripcion  y no se quiera insertar un campo vacio
            If (str_DesRegion.Trim().Length = 0) Then
                'Enviar un error de mensaje
                lb_Error.Text = "ERROR debe de indicar una descripcion valida"
                lb_Error.Visible = True
                Exit Sub
            End If

            'Insertar el nuevo valor
            Try
                Dim temp As New dsAppTableAdapters.CatRegionTableAdapter
                temp.Insert(str_CveRegion, str_DesRegion)
                Bind_Region()
            Catch ex As Exception
                Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
                CType(Me.Grid_Region.FooterRow.FindControl("lb_Error"), Label).Text = ExceptionHandler.Handler(ex, "Se produjo un error al insertar el registro, verifique los datos")
                CType(Me.Grid_Region.FooterRow.FindControl("lb_Error"), Label).Visible = True
            End Try
        End If 'Termina ADD
    End Sub

    Protected Sub Grid_Region_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grid_Region.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            'Obtener la referencia al boton eliminar
            Dim botonEliminar As ImageButton = CType(e.Row.FindControl("cmdEliminar"), ImageButton)
            If (Not (botonEliminar Is Nothing)) Then
                Dim str_CveRegion As String = CType(e.Row.FindControl("lb_CveRegion"), Label).Text
                Dim str_DesRegion As String = CType(e.Row.FindControl("lb_DesRegion"), Label).Text
                botonEliminar.OnClientClick = String.Format("return confirm('¿Esta seguro de eliminar el Municipio {0} {1}?');", str_CveRegion, str_DesRegion)
            End If

            'Verificar si hay alguna en edicion y poner el focus
            Dim textoEdit As TextBox = CType(e.Row.FindControl("txt_DesRegion"), TextBox)
            If (Not (textoEdit Is Nothing)) Then
                textoEdit.Focus()
            End If
        End If
    End Sub

    Protected Sub Grid_Region_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Grid_Region.RowDeleting
        Dim str_CveRegion As String = CType(Me.Grid_Region.Rows(e.RowIndex).FindControl("lb_CveRegion"), Label).Text

        Try
            Dim temp As New dsAppTableAdapters.CatRegionTableAdapter
            temp.Delete(str_CveRegion)
            Bind_Region()
        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            lb_Error.Text = ExceptionHandler.Handler(ex, "Se produjo un error al eliminar el registro verifique con el administrador")
            lb_Error.Visible = True
        End Try
    End Sub
    Protected Sub Grid_Region_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles Grid_Region.RowEditing
        Me.Grid_Region.EditIndex = e.NewEditIndex
        Me.Grid_Region.ShowFooter = False
        Bind_Region()
    End Sub
    Protected Sub Grid_Region_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles Grid_Region.RowUpdating
        'Obtener los datos de referencia a guardar
        Dim str_CveRegion As String = CType(Me.Grid_Region.Rows(e.RowIndex).FindControl("lb_CveRegion"), Label).Text
        Dim str_DesRegion As String = CType(Me.Grid_Region.Rows(e.RowIndex).FindControl("txt_DesRegion"), TextBox).Text

        Try
            Dim temp As New dsAppTableAdapters.CatRegionTableAdapter
            temp.Update(str_CveRegion, str_DesRegion, str_CveRegion)
        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            lb_Error.Text = ExceptionHandler.Handler(ex, "Se produjo un error al actualizar los datos del registro verifique con el administrador")
            lb_Error.Visible = True
        End Try
        Grid_Region.EditIndex = -1
        Grid_Region.ShowFooter = True
        Bind_Region()
    End Sub

    
End Class
