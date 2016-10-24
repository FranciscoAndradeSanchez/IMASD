
Partial Class Reiniciarcontra
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.mviwReiniciarContra.SetActiveView(Me.viewSolicitarReinicio)
    End Sub

    Protected Sub ibtnEnviar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnEnviar.Click
        Dim authReininiciarContra As New clsAuthentication()
        Dim intResultado As Int32

        intResultado = authReininiciarContra.SendResetConfirmation(Me.txtEmail.Text)

        If intResultado = clsAuthentication.AuthenticationStatusList.NotValidEmail Then
            Me.cmvEmail.IsValid = False
        ElseIf intResultado = clsAuthentication.AuthenticationStatusList.Autheticated Then
            Me.cmvEmail.IsValid = True
            Me.mviwReiniciarContra.SetActiveView(Me.viewSolicitudRecibida)
        End If
    End Sub
End Class
