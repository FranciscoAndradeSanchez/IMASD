
Partial Class contactanos
    Inherits System.Web.UI.Page

    Protected Sub ibtnSugerencia_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnSugerencia.Click
        Dim envcCorreo As New clsEnviarCorreo
        Try
            envcCorreo.asunto = Me.ddlRazones.SelectedValue.ToString
            envcCorreo.remitente = Me.txtNombre.Text & "<" & Me.txtEmail.Text & ">"
            envcCorreo.destinatarios = System.Web.Configuration.WebConfigurationManager.AppSettings("CorreoIMASD").ToString
            envcCorreo.Cuerpo = "<p>" & Server.HtmlEncode(Me.txtSugerencia.Text) & "</p>"
            envcCorreo.ServidorSMTP = System.Web.Configuration.WebConfigurationManager.AppSettings("ServidorMail").ToString
            envcCorreo.PortSMTP = System.Web.Configuration.WebConfigurationManager.AppSettings("ServidorMailPORT").ToString
            envcCorreo.Dominio = System.Web.Configuration.WebConfigurationManager.AppSettings("NombreDominio").ToString
            envcCorreo.usuario = System.Web.Configuration.WebConfigurationManager.AppSettings("Usuario").ToString
            envcCorreo.contrasenia = System.Web.Configuration.WebConfigurationManager.AppSettings("PWDUsuario").ToString
            envcCorreo.TextoDesuscribir = String.Empty
            envcCorreo.EnviarCorreo()
            Me.cmvComentario.IsValid = True
            Me.mviewContactanos.SetActiveView(Me.viewSugEnviada)
        Catch exEnvCorreo As Exception
            Me.cmvComentario.ErrorMessage = "No fue posible enviar su comentario intente de nuevo mas tarde." & exEnvCorreo.Message
            Me.cmvComentario.ToolTip = "No fue posible enviar su comentario intente de nuevo mas tarde."
            Me.cmvComentario.IsValid = False
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.mviewContactanos.SetActiveView(Me.viewSugerencia)
    End Sub

    Protected Sub ibtnOtraSugerencia_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnOtraSugerencia.Click
        Me.txtNombre.Text = String.Empty
        Me.txtEmail.Text = String.Empty
        Me.ddlRazones.SelectedIndex = 0
        Me.txtSugerencia.Text = String.Empty
        Me.mviewContactanos.SetActiveView(Me.viewSugerencia)
    End Sub
End Class
