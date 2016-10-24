Imports System.Data
Partial Class CatEstatus
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
            BindList_Objetos()
            BindGrid_Estatus()
        End If
    End Sub
    Protected Sub lst_CveObjeto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_CveObjeto.SelectedIndexChanged
        BindGrid_Estatus()
    End Sub

    Protected Sub Grid_Estatus_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles Grid_Estatus.RowCancelingEdit
        Me.Grid_Estatus.EditIndex = -1
        Me.Grid_Estatus.ShowFooter = True
        BindGrid_Estatus()
    End Sub

    Protected Sub Grid_Estatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Grid_Estatus.RowCommand
        'Si el comando enviado es para Agregar un nuevo elemento al catalogo
        If (e.CommandName.Substring(0, 3) = "ADD") Then
            Dim int_CveObjeto As Integer
            Dim str_DesEstatus As String
            'Obtener la descripcion
            If (e.CommandName = "ADD_empty") Then
                str_DesEstatus = CType(Grid_Estatus.Controls(0).Controls(0).FindControl("txt_DesEstatus_ADD_empty"), TextBox).Text
            Else
                str_DesEstatus = CType(Grid_Estatus.FooterRow.FindControl("txt_DesEstatus_ADD"), TextBox).Text
            End If
            int_CveObjeto = Convert.ToInt32(Me.lst_CveObjeto.SelectedValue)

            'Verificar que almenos contega valor la descripcion  y no se quiera insertar un campo vacio
            If (str_DesEstatus.Trim().Length = 0) Then
                'Enviar un error de mensaje
                CType(Me.Grid_Estatus.FooterRow.FindControl("lb_Error"), Label).Text = "ERROR debe de indicar una descripcion valida"
                CType(Me.Grid_Estatus.FooterRow.FindControl("lb_Error"), Label).Visible = True
                Exit Sub
            End If

            'Insertar el nuevo valor
            Try
                Dim temp As New dsAppTableAdapters.CatEstatusTableAdapter
                temp.InsertSmart(int_CveObjeto, str_DesEstatus)
                BindGrid_Estatus()
            Catch ex As Exception
                Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
                CType(Me.Grid_Estatus.FooterRow.FindControl("lb_Error"), Label).Text = ExceptionHandler.Handler(ex, "Se produjo un error al insertar el registro intente m&aacute;s tarde")
                CType(Me.Grid_Estatus.FooterRow.FindControl("lb_Error"), Label).Visible = True
            End Try
        End If 'Termina ADD
    End Sub

    Protected Sub Grid_Estatus_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grid_Estatus.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            'Obtener la referencia al boton eliminar
            Dim botonEliminar As ImageButton = CType(e.Row.FindControl("cmdEliminar"), ImageButton)
            Dim str_Cve_Template As String = CType(e.Row.FindControl("lb_CveEstatus"), Label).Text
            If (Not (botonEliminar Is Nothing)) Then
                botonEliminar.OnClientClick = String.Format("return confirm('¿Esta seguro de eliminar el Estatus {0}?');", str_Cve_Template)
            End If

            'Verificar si hay alguna en edicion y poner el focus
            Dim textoEdit As TextBox = CType(e.Row.FindControl("txt_DesEstatus"), TextBox)
            If (Not (textoEdit Is Nothing)) Then
                textoEdit.Focus()
            End If
        End If
    End Sub

    Protected Sub Grid_Estatus_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Grid_Estatus.RowDeleting
        Dim int_CveEstatus As Integer = Convert.ToInt32(CType(Me.Grid_Estatus.Rows(e.RowIndex).FindControl("lb_CveEstatus"), Label).Text)
        Dim int_CveObjeto As Integer = Convert.ToInt32(Me.lst_CveObjeto.SelectedValue)
        Dim str_DesEstatus As String = CType(Me.Grid_Estatus.Rows(e.RowIndex).FindControl("lb_DesEstatus"), Label).Text

        Try
            Dim temp As New dsAppTableAdapters.CatEstatusTableAdapter
            temp.Delete(int_CveEstatus, int_CveObjeto, str_DesEstatus)
            BindGrid_Estatus()
        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            CType(Me.Grid_Estatus.Rows(e.RowIndex).FindControl("lb_Error"), Label).Text = ExceptionHandler.Handler(ex, "No se puede eliminar por que el estatus tiene un registro relacionado")
            CType(Me.Grid_Estatus.Rows(e.RowIndex).FindControl("lb_Error"), Label).Visible = True
        End Try

    End Sub
    Protected Sub Grid_Estatus_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles Grid_Estatus.RowEditing
        Me.Grid_Estatus.EditIndex = e.NewEditIndex
        Me.Grid_Estatus.ShowFooter = False
        BindGrid_Estatus()
    End Sub
    Protected Sub Grid_Estatus_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles Grid_Estatus.RowUpdating
        'Obtener los datos de referencia a guardar
        Dim int_CveObjeto As Integer = Convert.ToInt32(Me.lst_CveObjeto.SelectedValue)
        Dim int_CveEstatus As Integer = Convert.ToInt32(CType(Me.Grid_Estatus.Rows(e.RowIndex).FindControl("lb_CveEstatus"), Label).Text)
        Dim str_DesEstatus As String = CType(Me.Grid_Estatus.Rows(e.RowIndex).FindControl("txt_DesEstatus"), TextBox).Text

        Try
            Dim temp As New dsAppTableAdapters.CatEstatusTableAdapter
            temp.Update_DesEstatus(int_CveEstatus, int_CveObjeto, str_DesEstatus)
        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            CType(Me.Grid_Estatus.Rows(e.RowIndex).FindControl("lb_Error"), Label).Text = ExceptionHandler.Handler(ex, "Se produjo un error al actualizar el registro intentelo m&aacute;s tarde")
            CType(Me.Grid_Estatus.Rows(e.RowIndex).FindControl("lb_Error"), Label).Visible = True
        End Try
        Grid_Estatus.EditIndex = -1
        Grid_Estatus.ShowFooter = True
        BindGrid_Estatus()
    End Sub

    Protected Sub BindList_Objetos()
        Dim temp As New dsAppTableAdapters.CatObjetoTableAdapter
        Dim ds As New dsApp.CatObjetoDataTable
        ds = temp.GetObjeto()
        Me.lst_CveObjeto.DataSource = ds
        Me.lst_CveObjeto.DataTextField = "DesObjeto"
        Me.lst_CveObjeto.DataValueField = "CveObjeto"
        Me.lst_CveObjeto.DataBind()
    End Sub

    Protected Sub BindGrid_Estatus()
        'Obtener el objeto del cual vamos a recuperar los datos
        Dim int_CveObjeto As Integer = Convert.ToInt32(Me.lst_CveObjeto.SelectedValue)
        Dim temp As New dsAppTableAdapters.CatEstatusTableAdapter
        Dim ds As New dsApp.CatEstatusDataTable
        ds = temp.GetEstatusByCveObjeto(int_CveObjeto)
        Dim strDataKeyNames() As String = {"CveEstatus", "CveObjeto"}
        Me.Grid_Estatus.DataSource = ds
        Me.Grid_Estatus.DataKeyNames = strDataKeyNames
        Me.Grid_Estatus.DataBind()
    End Sub

    
End Class
