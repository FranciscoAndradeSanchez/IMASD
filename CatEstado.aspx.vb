
Partial Class CatEstado
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
            BindGrid_CatEstados()
        End If
        lb_Error.Visible = False
    End Sub

    Protected Sub BindGrid_CatEstados()
     
        Dim temp As New dsAppTableAdapters.CatEstadoTableAdapter
        Dim ds As New dsApp.CatEstadoDataTable
        ds = temp.GetEstado
        Dim strDataKeyNames() As String = {"CveEstado"}
        Me.Grid_Estados.DataSource = ds
        Me.Grid_Estados.DataKeyNames = strDataKeyNames
        Me.Grid_Estados.DataBind()
    End Sub


    'Se llama cuando se EDITA una fila, debe de ponerse el EditIndex manualmente
    Protected Sub Grid_Estados_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles Grid_Estados.RowEditing
        Grid_Estados.EditIndex = e.NewEditIndex
        Grid_Estados.ShowFooter = False
        BindGrid_CatEstados()
    End Sub

    'Se llama cuando se preciona CANCELAR
    Protected Sub Grid_Estados_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles Grid_Estados.RowCancelingEdit
        Grid_Estados.EditIndex = -1
        BindGrid_CatEstados()
    End Sub

    'Se llama cuando GUARDAMOS un registro que se este editando
    Protected Sub Grid_Estados_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles Grid_Estados.RowUpdating
        'Usamos la propiedad EditIndex para encotnrar nuestros valores
        Dim str_CveEstado As String
        Dim str_DesEstado As String
        str_CveEstado = CType(Grid_Estados.Rows(Grid_Estados.EditIndex).Cells(0).FindControl("lbl_CveEstado"), Label).Text.Trim()
        str_DesEstado = CType(Grid_Estados.Rows(Grid_Estados.EditIndex).Cells(0).FindControl("txt_DesEstado"), TextBox).Text.Trim()

        'Hacer el update
        Try
            Dim temp As New dsAppTableAdapters.CatEstadoTableAdapter
            temp.Update(str_CveEstado, str_DesEstado, str_CveEstado)
        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            lb_Error.Text = ExceptionHandler.Handler(ex, "Se produjo un error al actualizar los datos del registro verifique con el administrador")
            lb_Error.Visible = True
        End Try

        Grid_Estados.EditIndex = -1
        BindGrid_CatEstados()
    End Sub
End Class
