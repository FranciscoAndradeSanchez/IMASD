
Partial Class Catalogos
    Inherits System.Web.UI.Page

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
end if
    End Sub
End Class
