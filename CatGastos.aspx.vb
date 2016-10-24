Imports System.Data
Partial Class CatGastos
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
            BindGrid_Gastos()
        End If
    End Sub

    Protected Sub BindGrid_Gastos()
        'Obtener el objeto del cual vamos a recuperar los datos
        Dim temp As New dsAppTableAdapters.CatGastoTableAdapter
        Dim ds As New dsApp.CatGastoDataTable
        ds = temp.GetGasto
        Dim strDataKeyNames() As String = {"CveGasto", "CveTipoGasto"}
        Me.Grid_Gastos.DataSource = ds
        Me.Grid_Gastos.DataKeyNames = strDataKeyNames
        Me.Grid_Gastos.DataBind()
    End Sub

    Protected Sub Grid_Gastos_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles Grid_Gastos.RowCancelingEdit
        Me.Grid_Gastos.EditIndex = -1
        Me.Grid_Gastos.ShowFooter = True
        BindGrid_Gastos()
    End Sub

    Protected Sub Grid_Gastos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Grid_Gastos.RowCommand
        'Si el comando enviado es para Agregar un nuevo elemento al catalogo
        If (e.CommandName.Substring(0, 3) = "ADD") Then
            Dim int_CveTipoGasto As Integer = 0
            Dim str_DesGasto As String
            Dim tempObj_error As Label
            'Obtener la descripcion
            If (e.CommandName = "ADD_empty") Then
                str_DesGasto = CType(Grid_Gastos.Controls(0).Controls(0).FindControl("txt_DesGasto_ADD_empty"), TextBox).Text
                int_CveTipoGasto = CType(Grid_Gastos.Controls(0).Controls(0).FindControl("lst_CveTipoGasto_ADD_empty"), DropDownList).SelectedValue
                tempObj_error = CType(Grid_Gastos.Controls(0).Controls(0).FindControl("lb_Error"), Label)
            Else
                str_DesGasto = CType(Grid_Gastos.FooterRow.FindControl("txt_DesGasto_ADD"), TextBox).Text
                int_CveTipoGasto = Convert.ToInt32(CType(Grid_Gastos.FooterRow.FindControl("lst_CveTipoGasto_ADD"), DropDownList).SelectedValue)
                tempObj_error = CType(Grid_Gastos.FooterRow.FindControl("lb_Error"), Label)
            End If


            'Verificar que almenos contega valor la descripcion  y no se quiera insertar un campo vacio
            If (str_DesGasto.Trim().Length = 0 Or int_CveTipoGasto = 0) Then
                'Enviar un error de mensaje
                tempObj_error.Text = "ERROR debe de indicar una descripcion valida"
                tempObj_error.Visible = True
                Exit Sub
            End If
            
            '---------- INSERT
            Try
                Dim temp As New dsAppTableAdapters.CatGastoTableAdapter
                temp.Insert(int_CveTipoGasto, str_DesGasto)
                BindGrid_Gastos()
            Catch ex As Exception
                Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
                tempObj_error = CType(Me.Grid_Gastos.FooterRow.FindControl("lb_Error"), Label)

                tempObj_error.Text = ExceptionHandler.Handler(ex, "Se produjo un error al insertar el registro intente m&aacute;s tarde")
                tempObj_error.Visible = True
            End Try
        End If 'Termina ADD
    End Sub

    Protected Sub Grid_Gastos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grid_Gastos.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            'Obtener la referencia al boton eliminar
            Dim botonEliminar As ImageButton = CType(e.Row.FindControl("cmdEliminar"), ImageButton)
            Dim str_CveGasto As String = CType(e.Row.FindControl("lb_CveGasto"), Label).Text
            If (Not (botonEliminar Is Nothing)) Then
                botonEliminar.OnClientClick = String.Format("return confirm('¿Esta seguro de eliminar el Gasto {0}?');", str_CveGasto)
            End If

            'Verificar si hay alguna en edicion y poner el focus
            Dim textoEdit As TextBox = CType(e.Row.FindControl("txt_DesGasto"), TextBox)
            If (Not (textoEdit Is Nothing)) Then
                textoEdit.Focus()
            End If
        End If
    End Sub

    Protected Sub Grid_Gastos_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Grid_Gastos.RowDeleting
        Dim int_CveGasto As Integer = Convert.ToInt32(CType(Me.Grid_Gastos.Rows(e.RowIndex).FindControl("lb_CveGasto"), Label).Text)

        '---------- DELETE
        Try
            Dim temp As New dsAppTableAdapters.CatGastoTableAdapter
            temp.Delete(int_CveGasto)
            BindGrid_Gastos()

        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            Dim tempObj_error As Label
            tempObj_error = CType(Me.Grid_Gastos.Rows(e.RowIndex).FindControl("lb_Error"), Label)

            tempObj_error.Text = ExceptionHandler.Handler(ex, "No se puede eliminar por que el estatus tiene un registro relacionado")
            tempObj_error.Visible = True
        End Try
    End Sub

    Protected Sub Grid_Gastos_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles Grid_Gastos.RowEditing
        Me.Grid_Gastos.EditIndex = e.NewEditIndex
        Me.Grid_Gastos.ShowFooter = False
        BindGrid_Gastos()
    End Sub

    Protected Sub Grid_Gastos_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles Grid_Gastos.RowUpdating
        'Obtener los datos de referencia a guardar
        Dim int_CveGasto As Integer = Convert.ToInt32(CType(Me.Grid_Gastos.Rows(e.RowIndex).FindControl("lb_CveGasto"), Label).Text)
        Dim int_CveTipoGasto As Integer = Convert.ToInt32(CType(Me.Grid_Gastos.Rows(e.RowIndex).FindControl("lst_CveTipoGasto"), DropDownList).SelectedValue)
        Dim str_DesGasto As String = CType(Me.Grid_Gastos.Rows(e.RowIndex).FindControl("txt_DesGasto"), TextBox).Text

        'Verificar que almenos contega valor la descripcion  y no se quiera insertar un campo vacio
        If (str_DesGasto.Trim().Length = 0 Or int_CveTipoGasto = 0) Then
            'Enviar un error de mensaje
            Dim tempObj_error As Label
            tempObj_error = CType(Grid_Gastos.Rows(e.RowIndex).FindControl("lb_Error"), Label)
            tempObj_error.Text = "ERROR debe de indicar una descripcion valida"
            tempObj_error.Visible = True
            Exit Sub
        End If
        '---------- UPDATE
        Try
            Dim temp As New dsAppTableAdapters.CatGastoTableAdapter
            temp.Update(int_CveTipoGasto, str_DesGasto, int_CveGasto, int_CveGasto)

        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            Dim tempObj_error As Label
            tempObj_error = CType(Grid_Gastos.Rows(e.RowIndex).FindControl("lb_Error"), Label)

            tempObj_error.Text = ExceptionHandler.Handler(ex, "Se produjo un error al actualizar el registro intentelo m&aacute;s tarde")
            tempObj_error.Visible = True
        End Try
        Grid_Gastos.EditIndex = -1
        Grid_Gastos.ShowFooter = True
        BindGrid_Gastos()
    End Sub
End Class
