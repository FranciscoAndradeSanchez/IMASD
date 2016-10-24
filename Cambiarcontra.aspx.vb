
Partial Class Cambiarcontra
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Request.QueryString("hash") = String.Empty) Then
            Dim authAutenticar As New clsAuthentication()
            authAutenticar.Email = Request.QueryString("email")
            authAutenticar.ConfirmationHash = Request.QueryString("hash")
            If authAutenticar.AuthenticateEmail() = clsAuthentication.AuthenticationStatusList.Autheticated Then
                Me.mviwCambiarContra.SetActiveView(Me.viewAutenticaEmail)
                Me.mviwAutenticaEmail.SetActiveView(Me.viewNuevaContra)
                Me.hdnfHash.Value = Request.QueryString("hash")
                Me.hdnfEmail.Value = Request.QueryString("email")
            Else
                Server.Transfer("Default.aspx")
            End If
        ElseIf (Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) IsNot Nothing) Then
            Me.mviwCambiarContra.SetActiveView(Me.viewAutenticaUsuar)
        Else
            Server.Transfer("Default.aspx")
        End If
    End Sub

    Protected Sub imgbCambiarContraseniaUsr_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbCambiarContraseniaUsr.Click
        If Not (Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) = String.Empty) Then
            Dim authCambiarContra As New clsAuthentication()

            Select Case authCambiarContra.ChangePassword(Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString), Me.txtContraseniaAnt.Text, Me.txtContraseniaNuevaAU.Text)
                Case clsAuthentication.DatabaseResults.PwdUpdated
                    Me.cusvContraseniaAntAU.IsValid = True
                    Me.mviwAutenticaEmail.SetActiveView(Me.viewContraCambiada)
                    Me.mviwCambiarContra.SetActiveView(Me.viewAutenticaEmail)
                Case clsAuthentication.DatabaseResults.PwdNotUpdated
                    Me.cusvContraseniaAntAU.IsValid = False
            End Select
        End If
    End Sub

    Protected Sub imgbCambiarContraseniaEmail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbCambiarContraseniaEmail.Click
        Dim authCambiarContra As New clsAuthentication()

        Select Case authCambiarContra.ResetPassword(Me.hdnfEmail.Value, Me.hdnfHash.Value, Me.txtConstraseniaNuevaAE.Text)
            Case clsAuthentication.DatabaseResults.PwdUpdated
                Me.cusvNuevaContraseniaAE.IsValid = True
                Me.mviwAutenticaEmail.SetActiveView(Me.viewContraCambiada)
            Case clsAuthentication.DatabaseResults.PwdNotUpdated
                Me.cusvNuevaContraseniaAE.IsValid = False
        End Select
    End Sub
End Class
