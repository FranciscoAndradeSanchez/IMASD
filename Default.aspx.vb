
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub ibtnIngresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnIngresar.Click
        Dim authIniciarSesion As New clsAuthentication()
        Dim intResultado As Int32

        intResultado = authIniciarSesion.AuthenticateUser(Me.txtUsuario.Text, Me.txtContrasenia.Text)
        Select Case intResultado
            Case clsAuthentication.AuthenticationStatusList.Autheticated

                Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) = Me.txtUsuario.Text
                Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoNombre").ToString) = authIniciarSesion.Name
                Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoNivel").ToString) = authIniciarSesion.AccesLevel

                FormsAuthentication.RedirectFromLoginPage(Me.txtUsuario.Text, False)

                'Dim strRedirect As String = Request("ReturnUrl")
                'Dim fatTicket As New FormsAuthenticationTicket(1, Me.txtUsuario.Text, _
                'DateTime.Now, DateTime.Now.AddMinutes(30), False, String.Empty, _
                'FormsAuthentication.FormsCookiePath)
                'Dim encryptedTicket As String = FormsAuthentication.Encrypt(fatTicket)
                'Dim authCookie As New HttpCookie( _
                '            FormsAuthentication.FormsCookieName, _
                '            encryptedTicket)
                'Response.Cookies.Add(authCookie)
                'If Not (strRedirect = String.Empty) Then
                'Server.Transfer(strRedirect, True)
                'Else
                'strRedirect = "Inicio.aspx"
                'Server.Transfer(strRedirect, True)
                'End If

                'Me.hlnkReiniciarContra.Visible = False
                Me.cvUsuario.IsValid = True
                Me.cvContrasenia.IsValid = True
            Case clsAuthentication.AuthenticationStatusList.NotValidUser
                'Me.hlnkReiniciarContra.Visible = False
                Me.cvUsuario.IsValid = False
            Case clsAuthentication.AuthenticationStatusList.NotValidPassword
                'Me.hlnkReiniciarContra.Visible = True
                Me.cvContrasenia.IsValid = False
            Case clsAuthentication.AuthenticationStatusList.NotAuthenticated
                'Me.hlnkReiniciarContra.Visible = False
                Me.cvUsuario.IsValid = False
        End Select
    End Sub
End Class
