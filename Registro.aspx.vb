
Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography

Partial Class Registro
    Inherits System.Web.UI.Page

    Private Sub ClearFields()
        Me.txtNombre.Text = String.Empty
        Me.ddlEscolaridad.SelectedIndex = -1
        Me.ddlInstitucion.SelectedIndex = -1
        Me.txtDepartamento.Text = String.Empty
        Me.txtProfesion.Text = String.Empty
        Me.txtOcupacion.Text = String.Empty
        Me.ddlUsoInformacion.SelectedIndex = -1
        Me.txtEmail.Text = String.Empty
        Me.txtUsuario.Text = String.Empty
    End Sub

    Protected Sub ibtnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnRegistrar.Click

        Dim authRegistro As New clsAuthentication()
        Dim intResultado As Int16 = -1

        Try
            'EL ESTADO
            Dim CveEstado As String
            If (rdblNacionalidad.SelectedValue = "1") Then
                CveEstado = ddlEstado.SelectedValue.ToString()
            Else
                CveEstado = "0"
            End If
            intResultado = authRegistro.NewUser(Me.txtUsuario.Text, Me.txtNombre.Text, Me.txtAPaterno.Text, _
                            Me.txtAMaterno.Text, Me.ddlEscolaridad.SelectedValue, _
                            Me.ddlInstitucion.SelectedValue, Me.txtDepartamento.Text, _
                            Me.txtProfesion.Text, Me.txtOcupacion.Text, Me.txtEmail.Text, _
                            Me.ddlUsoInformacion.SelectedValue, clsCommonVars.NivelAcceso.Consultador, _
                            CveEstado, Me.txtContrasenia.Text)
            Select Case intResultado
                Case clsAuthentication.DatabaseResults.Inserted
                    Me.cmvUsuario.IsValid = True
                    Me.mviewRegistro.SetActiveView(Me.viewResultado)
                Case clsAuthentication.DatabaseResults.NotInserted
                    Me.cmvUsuario.ErrorMessage = "Ocurrio un error al tratar de registrar el usuario. Intente mas tarde"
                    Me.cmvUsuario.ToolTip = "Ocurrio un error al tratar de registrar el usuario. Intente mas tarde"
                    Me.cmvUsuario.IsValid = False
                Case clsAuthentication.DatabaseResults.ExistingUsr
                    Me.cmvUsuario.ErrorMessage = "El usuario '" & Me.txtUsuario.Text & "' ya existe. Elija uno distinto"
                    Me.cmvUsuario.ToolTip = "El usuario '" & Me.txtUsuario.Text & "' ya existe. Elija uno distinto"
                    Me.cmvUsuario.IsValid = False
                Case clsAuthentication.DatabaseResults.ExistingEmail
                    Me.cmvEmail.ErrorMessage = "El correo electrónico '" & Me.txtEmail.Text & "' ya esta registrado"
                    Me.cmvEmail.ToolTip = "El correo electrónico '" & Me.txtEmail.Text & "' ya esta registrado"
                    Me.cmvEmail.IsValid = False
                Case Else
                    Me.cmvUsuario.ErrorMessage = "Ocurrio un error al tratar de registrar el usuario. Intente mas tarde"
                    Me.cmvUsuario.ToolTip = "Ocurrio un error al tratar de registrar el usuario. Intente mas tarde"
                    Me.cmvUsuario.IsValid = False
            End Select

        Catch exRegistroUsr As Exception
            If exRegistroUsr.Message.Contains("PK_CatUsuario") Then
                Me.cmvUsuario.ErrorMessage = "El usuario '" & Me.txtUsuario.Text & "' ya existe. Elija uno distinto"
                Me.cmvUsuario.ToolTip = "El usuario '" & Me.txtUsuario.Text & "' ya existe. Elija uno distinto"
                Me.cmvUsuario.IsValid = False
            ElseIf exRegistroUsr.Message.Contains("IX_Correo") Then
                Me.cmvEmail.ErrorMessage = "El correo electrónico '" & Me.txtEmail.Text & "' ya esta registrado"
                Me.cmvEmail.ToolTip = "El correo electrónico '" & Me.txtEmail.Text & "' ya esta registrado"
                Me.cmvEmail.IsValid = False
            Else
                Me.cmvUsuario.ErrorMessage = "Ocurrio un error al tratar de registrar el usuario. Intente mas tarde"
                Me.cmvUsuario.ToolTip = "Ocurrio un error al tratar de registrar el usuario. Intente mas tarde"
                Me.cmvUsuario.IsValid = False
            End If
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.mviewRegistro.SetActiveView(Me.viewFormaLlenado)
    End Sub

    Protected Sub rdblNacionalidad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdblNacionalidad.SelectedIndexChanged
        'Si cambia la nacionalidad 
        'Habilitar o deshabilitar los estados
        If (rdblNacionalidad.SelectedValue = "1") Then 'Mexicana
            ddlEstado.Enabled = True
        Else
            ddlEstado.Enabled = False
        End If
    End Sub
End Class
