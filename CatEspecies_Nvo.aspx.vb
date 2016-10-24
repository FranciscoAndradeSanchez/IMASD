
Partial Class CatEspecies_Nvo
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
            Session("BusquedaEspecies") = String.Empty
            BindGrid_Infraestructura()
        End If
    End Sub
    Protected Sub ibtnBuscarEspecies_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnBuscarEspecies.Click
        If (Me.txtBusqueda.Text.Trim() <> String.Empty) Then
            Session("BusquedaEspecies") = "NomCientifico like '%" & Me.txtBusqueda.Text.Trim() & "%'"
        Else
            Session("BusquedaEspecies") = String.Empty
        End If
        BindGrid_Infraestructura()
    End Sub
    Protected Sub BindGrid_Infraestructura()
        'Obtener el objeto del cual vamos a recuperar los datos
        Dim temp As New dsAppTableAdapters.spEspecie_Select_NvoTableAdapter
        Dim ds As New dsApp.spEspecie_Select_NvoDataTable
        Dim strDataKeyNames() As String = {"CveEspecie", "NomCientifico"}
        ds = temp.GetData
        Me.Grid_Infraestructura.DataSource = ds.Select(Session("BusquedaEspecies"))
        Me.Grid_Infraestructura.DataKeyNames = strDataKeyNames
        Me.Grid_Infraestructura.DataBind()
    End Sub

    Protected Sub Grid_Infraestructura_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles Grid_Infraestructura.RowCancelingEdit
        Me.Grid_Infraestructura.EditIndex = -1
        Me.Grid_Infraestructura.ShowFooter = True
        BindGrid_Infraestructura()
    End Sub

    Protected Sub Grid_Infraestructura_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Grid_Infraestructura.RowCommand
        'Si el comando enviado es para Agregar un nuevo elemento al catalogo
        If (e.CommandName.Substring(0, 3) = "ADD") Then
            Dim NombreCientifico As String
            Dim EsMaderable As Boolean
            Dim CveEspecieTipo As Integer
            Dim tempObj_error As Label
            'Obtener la descripcion
            'If (e.CommandName = "ADD_empty") Then
            'str_Infraestructura = CType(Grid_Infraestructura.Controls(0).Controls(0).FindControl("txt_Infraestructura_ADD_empty"), TextBox).Text
            'int_CveTipoInfraestructura = CType(Grid_Infraestructura.Controls(0).Controls(0).FindControl("lst_CveTipoInfraestructura_ADD_empty"), DropDownList).SelectedValue
            'tempObj_error = CType(Grid_Infraestructura.Controls(0).Controls(0).FindControl("lb_Error"), Label)
            'Else
            NombreCientifico = CType(Grid_Infraestructura.FooterRow.FindControl("txt_NombreCientificoADD"), TextBox).Text
            EsMaderable = Convert.ToBoolean(CType(Grid_Infraestructura.FooterRow.FindControl("ddl_EsMaderableADD"), DropDownList).SelectedValue)
            CveEspecieTipo = Convert.ToInt32(CType(Grid_Infraestructura.FooterRow.FindControl("ddl_CveEspecieTipoADD"), DropDownList).SelectedValue)
            tempObj_error = CType(Grid_Infraestructura.FooterRow.FindControl("lb_Error"), Label)
            'End If


            'Verificar que almenos contega valor la descripcion  y no se quiera insertar un campo vacio
            If (NombreCientifico.Trim().Length = 0) Then
                'Enviar un error de mensaje
                tempObj_error.Text = "ERROR debe de indicar una descripcion valida"
                tempObj_error.Visible = True
                Exit Sub
            End If

            '---------- INSERT
            Try
                Dim temp As New dsAppTableAdapters.spEspecie_Select_NvoTableAdapter
                temp.Insert(NombreCientifico, EsMaderable, CveEspecieTipo)
                BindGrid_Infraestructura()
            Catch ex As Exception
                Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
                tempObj_error = CType(Me.Grid_Infraestructura.FooterRow.FindControl("lb_Error"), Label)

                tempObj_error.Text = ExceptionHandler.Handler(ex, "Se produjo un error al insertar el registro intente m&aacute;s tarde")
                tempObj_error.Visible = True
            End Try
        End If 'Termina ADD
    End Sub

    Protected Sub Grid_Infraestructura_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grid_Infraestructura.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            'Obtener la referencia al boton eliminar
            Dim botonEliminar As ImageButton = CType(e.Row.FindControl("cmdEliminar"), ImageButton)
            Dim str_CveInfraestructura As String = CType(e.Row.FindControl("lb_CveEspecie"), Label).Text
            If (Not (botonEliminar Is Nothing)) Then
                botonEliminar.OnClientClick = String.Format("return confirm('¿Esta seguro de eliminar la especie {0}?');", str_CveInfraestructura)
            End If

            'Verificar si hay alguna en edicion y poner el focus
            Dim textoEdit As TextBox = CType(e.Row.FindControl("txt_Infraestructura"), TextBox)
            If (Not (textoEdit Is Nothing)) Then
                textoEdit.Focus()
            End If
        End If
    End Sub

    Protected Sub Grid_Infraestructura_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Grid_Infraestructura.RowDeleting
        Dim int_CveInfraestructura As Integer = Convert.ToInt32(CType(Me.Grid_Infraestructura.Rows(e.RowIndex).FindControl("lb_CveEspecie"), Label).Text)

        '---------- DELETE
        Try
            Dim temp As New dsAppTableAdapters.spEspecie_Select_NvoTableAdapter
            temp.Delete(int_CveInfraestructura)
            BindGrid_Infraestructura()

        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            Dim tempObj_error As Label
            tempObj_error = CType(Me.Grid_Infraestructura.Rows(e.RowIndex).FindControl("lb_Error"), Label)

            tempObj_error.Text = ExceptionHandler.Handler(ex, "No se puede eliminar por que el estatus tiene un registro relacionado")
            tempObj_error.Visible = True
        End Try
    End Sub

    Protected Sub Grid_Infraestructura_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles Grid_Infraestructura.RowEditing
        Me.Grid_Infraestructura.EditIndex = e.NewEditIndex
        Me.Grid_Infraestructura.ShowFooter = False
        BindGrid_Infraestructura()
    End Sub

    Protected Sub Grid_Infraestructura_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles Grid_Infraestructura.RowUpdating
        'Obtener los datos de referencia a guardar
        Dim CveEspecie As Integer = Convert.ToInt32(CType(Me.Grid_Infraestructura.Rows(e.RowIndex).FindControl("lb_CveEspecie"), Label).Text)
        Dim EsMaderable As Boolean = Convert.ToBoolean(CType(Me.Grid_Infraestructura.Rows(e.RowIndex).FindControl("ddl_EsMaderable"), DropDownList).SelectedValue)
        Dim NombreCientifico As String = Convert.ToString(CType(Me.Grid_Infraestructura.Rows(e.RowIndex).FindControl("txt_NombreCientifico"), TextBox).Text)
        Dim CveEspecieTipo As Integer = Convert.ToInt32(CType(Me.Grid_Infraestructura.Rows(e.RowIndex).FindControl("ddl_CveEspecieTipoEdt"), DropDownList).SelectedValue)

        'Verificar que almenos contega valor la descripcion  y no se quiera insertar un campo vacio
        If (NombreCientifico.Trim().Length = 0) Then
            'Enviar un error de mensaje
            Dim tempObj_error As Label
            tempObj_error = CType(Grid_Infraestructura.Rows(e.RowIndex).FindControl("lb_Error"), Label)
            tempObj_error.Text = "ERROR debe de indicar una descripcion valida"
            tempObj_error.Visible = True
            Exit Sub
        End If
        '---------- UPDATE
        Try
            Dim temp As New dsAppTableAdapters.spEspecie_Select_NvoTableAdapter
            'temp.Update(int_CveTipoInfraestructura, str_Infraestructura, int_CveInfraestructura)
            temp.Update(NombreCientifico, CveEspecie, CveEspecie, EsMaderable, CveEspecieTipo)

        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            Dim tempObj_error As Label
            tempObj_error = CType(Grid_Infraestructura.Rows(e.RowIndex).FindControl("lb_Error"), Label)

            tempObj_error.Text = ExceptionHandler.Handler(ex, "Se produjo un error al actualizar el registro intentelo m&aacute;s tarde")
            tempObj_error.Visible = True
        End Try
        Grid_Infraestructura.EditIndex = -1
        Grid_Infraestructura.ShowFooter = True
        BindGrid_Infraestructura()
    End Sub

    
    Protected Sub Grid_Infraestructura_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Grid_Infraestructura.PageIndexChanging
        If (Grid_Infraestructura.EditIndex >= 0) Then
            'Se esta editando no se puede mover de página
            e.Cancel = True
        Else
            Grid_Infraestructura.PageIndex = e.NewPageIndex
            BindGrid_Infraestructura()
        End If
    End Sub
End Class
