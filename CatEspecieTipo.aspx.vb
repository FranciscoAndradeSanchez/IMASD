
Partial Class CatEspecieTipo
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
        End If
    End Sub

    Protected Sub GridViewCatEspecieTipo_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewCatEspecieTipo.RowCommand
        'Verificar el tipo
        If (e.CommandName = "edit") Then
            pnlAgregar.Visible = False
        Else
            pnlAgregar.Visible = True
        End If
    End Sub

    Protected Sub cmdAgregar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdAgregar.Click
        'Obtener los datos
        Dim DescTipo As String = Me.txt_DescTipo.Text

        'Iniciar objeto
        Dim taEspecieTipo As dsAppTableAdapters.CatEspecieTipoTableAdapter = New dsAppTableAdapters.CatEspecieTipoTableAdapter()
        Try
            taEspecieTipo.Insert(DescTipo)
            GridViewCatEspecieTipo.DataBind()
            txt_DescTipo.Text = String.Empty
        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            lbError.Text = ExceptionHandler.Handler(ex, "Se produjo un error al insertar el registro")
            lbError.Visible = True
        End Try
    End Sub
End Class
