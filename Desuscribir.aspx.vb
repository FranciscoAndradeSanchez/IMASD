
Partial Class Desuscribir
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.mviwDesuscribir.SetActiveView(Me.viewDesuscribir)

    End Sub

    Protected Sub imgbEliminarUsuario_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbEliminarUsuario.Click

        Dim intResultado As Int32 = -1
        Dim authDesuscribir As New clsAuthentication()

        Try
            intResultado = authDesuscribir.DeleteUser(Me.txtEmail.Text)

            If intResultado = clsAuthentication.DatabaseResults.Deleted Then
                Me.cmvEmailDesuscribir.ErrorMessage = "El usuario fue eliminado"
                Me.cmvEmailDesuscribir.ToolTip = "El usuario fue eliminado"
                Me.cmvEmailDesuscribir.IsValid = True
                Me.mviwDesuscribir.SetActiveView(Me.viewDesuscrito)
            ElseIf intResultado = clsAuthentication.DatabaseResults.NotDeleted Then
                Me.cmvEmailDesuscribir.ErrorMessage = "No fue posible eliminar su usuario intente mas tarde"
                Me.cmvEmailDesuscribir.ToolTip = "No fue posible eliminar su usuario intente mas tarde"
                Me.cmvEmailDesuscribir.IsValid = False
            End If
        Catch exDesuscribir As Exception
            Me.cmvEmailDesuscribir.ErrorMessage = "No fue posible eliminar su usuario intente mas tarde"
            Me.cmvEmailDesuscribir.ToolTip = "No fue posible eliminar su usuario intente mas tarde"
            Me.cmvEmailDesuscribir.IsValid = False
        End Try

    End Sub
End Class
