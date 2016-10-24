
Partial Class logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormsAuthentication.SignOut()
        'Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) = String.Empty
        'Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoNombre").ToString) = String.Empty
        'Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoNivel").ToString) = String.Empty
        Session.Abandon()
        Server.Transfer("default.aspx", False)
    End Sub
End Class
