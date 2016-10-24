
Partial Class CatMpio
    Inherits System.Web.UI.Page

    Protected Sub Grid_Mpio_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles Grid_Mpio.RowCancelingEdit
        Me.Grid_Mpio.EditIndex = -1
        Me.Grid_Mpio.ShowFooter = True
        Bind_Mpio()
    End Sub

    Protected Sub Grid_Mpio_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Grid_Mpio.RowCommand
        'Si el comando enviado es para Agregar un nuevo elemento al catalogo
        If (e.CommandName.Substring(0, 3) = "ADD") Then
            Dim str_CveEstado As String
            Dim str_CveMpio As String
            Dim str_DesMpio As String
            'Obtener la descripcion
            If (e.CommandName = "ADD_empty") Then
                str_CveMpio = CType(Grid_Mpio.Controls(0).Controls(0).FindControl("txt_CveMpio_ADD_empty"), TextBox).Text
                str_DesMpio = CType(Grid_Mpio.Controls(0).Controls(0).FindControl("txt_DesMpio_ADD_empty"), TextBox).Text
            Else
                str_CveMpio = CType(Grid_Mpio.FooterRow.FindControl("txt_CveMpio_ADD"), TextBox).Text
                str_DesMpio = CType(Grid_Mpio.FooterRow.FindControl("txt_DesMpio_ADD"), TextBox).Text
            End If
            str_CveEstado = Convert.ToInt32(Me.lst_CveEstado.SelectedValue).ToString("00")

            'Verificar que almenos contega valor la descripcion  y no se quiera insertar un campo vacio
            If (str_DesMpio.Trim().Length = 0) Then
                'Enviar un error de mensaje
                lb_Error.Text = "ERROR debe de indicar una descripcion valida"
                lb_Error.Visible = True
                Exit Sub
            End If

            'Insertar el nuevo valor
            Try
                Dim temp As New dsAppTableAdapters.CatMpioTableAdapter
                temp.Insert(str_CveMpio, str_CveEstado, str_DesMpio)
                Bind_Mpio()
            Catch ex As Exception
                Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
                CType(Me.Grid_Mpio.FooterRow.FindControl("lb_Error"), Label).Text = ExceptionHandler.Handler(ex, "Se produjo un error al insertar el registro intentelo m&aacute;s tarde")
                CType(Me.Grid_Mpio.FooterRow.FindControl("lb_Error"), Label).Visible = True
            End Try
        End If 'Termina ADD
    End Sub

    Protected Sub Grid_Mpio_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grid_Mpio.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            'Obtener la referencia al boton eliminar
            Dim botonEliminar As ImageButton = CType(e.Row.FindControl("cmdEliminar"), ImageButton)
            If (Not (botonEliminar Is Nothing)) Then
                Dim str_CveMpio As String = CType(e.Row.FindControl("lb_CveMpio"), Label).Text
                Dim str_DesMpio As String = CType(e.Row.FindControl("lb_DesMpio"), Label).Text
                botonEliminar.OnClientClick = String.Format("return confirm('¿Esta seguro de eliminar el Municipio {0} {1}?');", str_CveMpio, str_DesMpio)
                'Formate Clave
                CType(e.Row.FindControl("lb_CveMpio"), Label).Text = Convert.ToInt32(str_CveMpio).ToString("00000")
            End If

            'Verificar si hay alguna en edicion y poner el focus
            Dim textoEdit As TextBox = CType(e.Row.FindControl("txt_CveMpio"), TextBox)
            If (Not (textoEdit Is Nothing)) Then
                textoEdit.Focus()
                'Formatea Clave
                textoEdit.Text = Convert.ToInt32(textoEdit.Text).ToString("00000")
            End If
        End If
    End Sub

    Protected Sub Grid_Mpio_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Grid_Mpio.RowDeleting
        Dim str_CveMpio As String = Convert.ToInt32(CType(Me.Grid_Mpio.Rows(e.RowIndex).FindControl("lb_CveMpio"), Label).Text).ToString("00000")

        Try
            Dim temp As New dsAppTableAdapters.CatMpioTableAdapter
            temp.Delete(str_CveMpio)
            Bind_Mpio()
        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            lb_Error.Text = ExceptionHandler.Handler(ex, "Se produjo un error al eliminar el registro verifique con el administrador")
            lb_Error.Visible = True
        End Try
    End Sub
    Protected Sub Grid_Mpio_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles Grid_Mpio.RowEditing
        Me.Grid_Mpio.EditIndex = e.NewEditIndex
        Me.Grid_Mpio.ShowFooter = False
        Bind_Mpio()
    End Sub
    Protected Sub Grid_Mpio_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles Grid_Mpio.RowUpdating
        'Obtener los datos de referencia a guardar
        Dim str_CveEstado As String = Convert.ToInt32(Me.lst_CveEstado.SelectedValue).ToString("00")
        Dim str_CveMpio As String = Convert.ToInt32(CType(Me.Grid_Mpio.Rows(e.RowIndex).FindControl("txt_CveMpio"), TextBox).Text).ToString("00000")
        Dim str_DesMpio As String = CType(Me.Grid_Mpio.Rows(e.RowIndex).FindControl("txt_DesMpio"), TextBox).Text

        Try
            Dim temp As New dsAppTableAdapters.CatMpioTableAdapter
            temp.Update(str_CveMpio, str_CveEstado, str_DesMpio, str_CveMpio)
        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            lb_Error.Text = ExceptionHandler.Handler(ex, "Se produjo un error al actualizar los datos del registro verifique con el administrador")
            lb_Error.Visible = True
        End Try
        Grid_Mpio.EditIndex = -1
        Grid_Mpio.ShowFooter = True
        Bind_Mpio()
    End Sub

    Protected Sub Bind_Mpio()
        'Obtener el objeto del cual vamos a recuperar los datos
        Dim str_CveEstado As String = Convert.ToInt32(Me.lst_CveEstado.SelectedValue).ToString("00")
        Dim temp As New dsAppTableAdapters.spMunicipioDDLPorEstadoTableAdapter
        Dim ds As New dsApp.spMunicipioDDLPorEstadoDataTable
        ds = temp.GetDataByCveEstado(str_CveEstado)
        ds.Rows(0).Delete()
        Dim strDataKeyNames() As String = {"CveMpio"}
        Me.Grid_Mpio.DataSource = ds
        Me.Grid_Mpio.DataKeyNames = strDataKeyNames
        Me.Grid_Mpio.DataBind()
    End Sub

    Protected Sub lst_CveEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_CveEstado.SelectedIndexChanged
        Bind_Mpio()
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
    End Sub
End Class
