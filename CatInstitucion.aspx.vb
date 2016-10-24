
Partial Class CatInstitucion
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
            'Iniciar la navegacion (<--- LVC: ah ¿¡te cae!?)
            InicializarNavegacion()
            BindGrid_Institucion()
        End If
        lb_Error.Visible = False
    End Sub

    Protected Sub InicializarNavegacion()
        Grid_Institucion.PageIndex = 0
        Grid_Institucion.PageSize = 20
        lb_paginas.Text = "1"
        Me.MultiViewInst.SetActiveView(Me.viewLista)
    End Sub

    Protected Sub BindGrid_Institucion()
        'Obtener el objeto del cual vamos a recuperar los datos (<--- LVC: ¡qué valioso comentario!, retiro lo dicho.. este sistema sí tiene comentarios)
        Dim temp As New dsAppTableAdapters.CatInstitucionTableAdapter
        Dim ds As New dsApp.CatInstitucionDataTable
        ds = temp.GetInstitucionByFilter(Me.txtBusqueda.Text.Trim())
        Dim strDataKeyNames() As String = {"CveInstitucion"}
        Me.Grid_Institucion.DataSource = ds
        Me.Grid_Institucion.DataKeyNames = strDataKeyNames
        Me.Grid_Institucion.DataBind()

        Dim TotalRegistros As Integer = temp.TotalRegistros(Me.txtBusqueda.Text.Trim())
        If (TotalRegistros Mod 20 > 0) Then
            TotalRegistros = Math.Truncate(TotalRegistros / Grid_Institucion.PageSize) + 1
        Else
            TotalRegistros = Math.Truncate(TotalRegistros / Grid_Institucion.PageSize)
        End If
        lb_paginas_total.Text = TotalRegistros.ToString()
    End Sub

   
    Protected Sub Grid_Institucion_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Grid_Institucion.RowCommand
        If (e.CommandName = "cmdMas") Then
            Dim indexRow As Integer
            indexRow = Convert.ToInt32(e.CommandArgument) + 2
            Dim tempPanel As Panel
            Dim tempImg As ImageButton
            Dim tempLabel As Label
            tempPanel = CType(Grid_Institucion.Controls.Item(0).Controls(indexRow).FindControl("pnlExpandirInfoInst"), System.Web.UI.WebControls.Panel)
            tempImg = CType(Grid_Institucion.Controls.Item(0).Controls(indexRow).FindControl("imgExpandirInfoInst"), System.Web.UI.WebControls.ImageButton)
            tempLabel = CType(Grid_Institucion.Controls.Item(0).Controls(indexRow).FindControl("lblMasInfoInst"), System.Web.UI.WebControls.Label)
            If (tempPanel Is Nothing) Then
                tempPanel = CType(Grid_Institucion.Controls.Item(0).Controls(indexRow).FindControl("pnlExpandirInfoInst_alter"), System.Web.UI.WebControls.Panel)
                tempImg = CType(Grid_Institucion.Controls.Item(0).Controls(indexRow).FindControl("imgExpandirInfoInst_alter"), System.Web.UI.WebControls.ImageButton)
                tempLabel = CType(Grid_Institucion.Controls.Item(0).Controls(indexRow).FindControl("lblMasInfoInst_alter"), System.Web.UI.WebControls.Label)
            End If

            If (tempImg.ImageUrl = "~/images/aplicacion/expandir.gif") Then tempImg.ImageUrl = "~/images/aplicacion/contraer.gif" Else tempImg.ImageUrl = "~/images/aplicacion/expandir.gif"
            If (tempLabel.Text = "Más...") Then tempLabel.Text = "" Else tempLabel.Text = "Más..."
            tempPanel.Visible = Not tempPanel.Visible
        End If
    End Sub

    Protected Sub Grid_Institucion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grid_Institucion.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            'Obtener la referencia al boton eliminar
            Dim botonEliminar As ImageButton = CType(e.Row.FindControl("cmdEliminar"), ImageButton)
            Dim str_Cve_Template As String = CType(e.Row.FindControl("lb_CveInstitucion"), Label).Text
            If (Not (botonEliminar Is Nothing)) Then
                botonEliminar.OnClientClick = String.Format("return confirm('¿Esta seguro de eliminar la Institucion {0}?');", str_Cve_Template)
            End If

            'Verificar si hay alguna en edicion y poner el focus
            Dim textoEdit As TextBox = CType(e.Row.FindControl("txt_DesInstitucion"), TextBox)
            If (Not (textoEdit Is Nothing)) Then
                textoEdit.Focus()
            End If

            'Poner el argumento del boton para expandir
            Dim imgTemp As ImageButton
            imgTemp = CType(e.Row.FindControl("imgExpandirInfoInst"), ImageButton)
            If (imgTemp Is Nothing) Then
                imgTemp = CType(e.Row.FindControl("imgExpandirInfoInst_alter"), ImageButton)
            End If
            'Guiardar el index de la fila
            If (Not (imgTemp Is Nothing)) Then
                imgTemp.CommandArgument = e.Row.RowIndex.ToString()
            End If

        End If

    End Sub

    '**** EDIT
    Protected Sub Grid_Institucion_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles Grid_Institucion.RowEditing
        Me.Grid_Institucion.EditIndex = e.NewEditIndex
        BindGrid_Institucion()
        Bind_Municipios()
    End Sub
    '*** UPDATE
    Protected Sub Grid_Institucion_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles Grid_Institucion.RowUpdating
        'Obtener los datos de referencia a guardar
        Dim int_CveInstitucion As Integer = Convert.ToInt32(CType(Me.Grid_Institucion.Rows(e.RowIndex).FindControl("lb_CveInstitucion"), Label).Text)
        Dim str_DesInstitucion As String = CType(Me.Grid_Institucion.Rows(e.RowIndex).FindControl("txt_DesInstitucion"), TextBox).Text
        Dim str_Domicilio As String = CType(Me.Grid_Institucion.Rows(e.RowIndex).FindControl("txt_Domicilio"), TextBox).Text
        Dim str_CveEstado As String = CType(Me.Grid_Institucion.Rows(e.RowIndex).FindControl("lst_CveEstado"), DropDownList).SelectedValue
        'Response.Write(str_CveEstado)
        Dim str_CveMpio As String = CType(Me.Grid_Institucion.Rows(e.RowIndex).FindControl("lst_CveMpio"), DropDownList).SelectedValue
        Dim str_Telefono As String = CType(Me.Grid_Institucion.Rows(e.RowIndex).FindControl("txt_Telefono"), TextBox).Text
        Dim str_Fax As String = CType(Me.Grid_Institucion.Rows(e.RowIndex).FindControl("txt_Fax"), TextBox).Text
        Dim str_Web As String = CType(Me.Grid_Institucion.Rows(e.RowIndex).FindControl("txt_Web"), TextBox).Text
        Dim str_CP As String = CType(Me.Grid_Institucion.Rows(e.RowIndex).FindControl("txt_CP"), TextBox).Text

        'Verificar que almenos contega valor la descripcion  y no se quiera insertar un campo vacio
        If (str_DesInstitucion.Trim().Length = 0 Or int_CveInstitucion = 0) Then
            'Enviar un error de mensaje
            Dim tempObj_error As Label
            tempObj_error = CType(Grid_Institucion.Rows(e.RowIndex).FindControl("lb_Error"), Label)
            tempObj_error.Text = "ERROR debe de indicar una descripcion valida"
            tempObj_error.Visible = True
            Exit Sub
        End If
        'Formatear datos
        If (str_DesInstitucion = String.Empty) Then str_DesInstitucion = Nothing
        If (str_Domicilio = String.Empty) Then str_Domicilio = Nothing
        'entra el polo
        'no hay razón para agregar ceros al principio ni para descartar el valor Nothing
        'If (str_CveEstado = "-1") Then str_CveEstado = Nothing Else str_CveEstado = Convert.ToInt32(str_CveEstado).ToString("00")
        If (str_CveEstado = "-1") Then str_CveEstado = Nothing
        'y sale el polo victorioso
        If (str_CveMpio = "-1") Then str_CveMpio = Nothing Else str_CveMpio = Convert.ToInt32(str_CveMpio).ToString("00000")
        If (str_Telefono = String.Empty) Then str_Telefono = Nothing
        If (str_Fax = String.Empty) Then str_Fax = Nothing
        If (str_Web = String.Empty) Then str_Web = Nothing
        If (str_CP = String.Empty) Then str_CP = Nothing


        Try
            Dim temp As New dsAppTableAdapters.CatInstitucionTableAdapter
            temp.Update(str_DesInstitucion, str_Web, str_Domicilio, str_Telefono _
                    , str_Fax, str_CP, str_CveEstado, str_CveMpio, int_CveInstitucion, int_CveInstitucion)

        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            lb_Error.Text = ExceptionHandler.Handler(ex, "Se produjo un error al actualizar el registro intentelo m&aacute;s tarde")
            lb_Error.Visible = True
        End Try
        Grid_Institucion.EditIndex = -1
        BindGrid_Institucion()
    End Sub
    '*** CANCEL
    Protected Sub Grid_Institucion_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles Grid_Institucion.RowCancelingEdit
        Me.Grid_Institucion.EditIndex = -1
        BindGrid_Institucion()
    End Sub
    '*** DELETE
    Protected Sub Grid_Institucion_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Grid_Institucion.RowDeleting
        Dim int_CveInstitucion As Integer = Convert.ToInt32(CType(Me.Grid_Institucion.Rows(e.RowIndex).FindControl("lb_CveInstitucion"), Label).Text)
        Try
            Dim temp As New dsAppTableAdapters.CatInstitucionTableAdapter
            temp.Delete(int_CveInstitucion)
            BindGrid_Institucion()

        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            Dim tempObj_error As Label
            tempObj_error = CType(Me.Grid_Institucion.Rows(e.RowIndex).FindControl("lb_Error"), Label)

            tempObj_error.Text = ExceptionHandler.Handler(ex, "No se fue posible eliminar el registro")
            tempObj_error.Visible = True
        End Try
    End Sub
    '*** PAGE CHANGE
    Protected Sub Grid_Institucion_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Grid_Institucion.PageIndexChanging
        Grid_Institucion.PageIndex = e.NewPageIndex
        lb_paginas.Text = Convert.ToString(e.NewPageIndex + 1)
        BindGrid_Institucion()
    End Sub

    Protected Sub lst_CveEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_CveEstado.SelectedIndexChanged
        'Debemos rellenar el otro listBox
        CType(Me.Grid_Institucion.Rows(Me.Grid_Institucion.EditIndex).FindControl("hdd_CveMpio"), HiddenField).Value = String.Empty
        Bind_Municipios()
    End Sub

    Protected Sub Bind_Municipios()
        'Obtener el objeto del cual vamos a recuperar los datos
        Dim temp As New dsAppTableAdapters.spMunicipioDDLPorEstadoTableAdapter
        Dim ds As New dsApp.spMunicipioDDLPorEstadoDataTable
        If (lst_CveEstado.SelectedValue = String.Empty) Then
            ds = temp.GetDataByCveEstado("00")
        Else
            ds = temp.GetDataByCveEstado(Convert.ToInt32(lst_CveEstado.SelectedValue).ToString("00"))
        End If

        'Tengo un valor por default para el municipio
        Dim tempHidden As HiddenField
        If (Me.Grid_Institucion.EditIndex >= 0 And String.IsNullOrEmpty(lst_CveEstado.SelectedValue) = False) Then
            tempHidden = CType(Me.Grid_Institucion.Rows(Me.Grid_Institucion.EditIndex).FindControl("hdd_CveMpio"), HiddenField)
            If (String.IsNullOrEmpty(tempHidden.Value) = False) Then
                Me.lst_CveMpio.SelectedValue = tempHidden.Value
            End If
        End If
        Me.lst_CveMpio.DataSource = ds
        Me.lst_CveMpio.DataBind()
    End Sub
    Protected Sub odsCatMpio_new_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs)
        'Formate el parametro
        e.InputParameters.Item(0) = Convert.ToInt32(e.InputParameters.Item(0)).ToString("00")
    End Sub

    Protected Sub cmdNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdNuevo.Click
        Me.MultiViewInst.SetActiveView(Me.viewNuevo)
    End Sub
    Protected Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdCancelar.Click
        Me.MultiViewInst.SetActiveView(Me.viewLista)
    End Sub

    '*** ADD
    Protected Sub cmdGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdGuardar.Click
        'Obtener los datos de referencia a guardar
        Dim str_DesInstitucion As String = Me.txt_DesInstitucion.Text
        Dim str_Domicilio As String = Me.txt_Domicilio.Text
        Dim str_CveEstado As String = Me.lst_CveEstado_new.SelectedValue
        Dim str_CveMpio As String = Me.lst_CveMpio_new.SelectedValue
        Dim str_Telefono As String = Me.txt_Telefono.Text
        Dim str_Fax As String = Me.txt_Fax.Text
        Dim str_Web As String = Me.txt_Web.Text
        Dim str_CP As String = Me.txt_CP.Text

        'Formatear datos
        If (str_DesInstitucion = String.Empty) Then str_DesInstitucion = Nothing
        If (str_Domicilio = String.Empty) Then str_Domicilio = Nothing

        'entra el polo
        'no hay razón para agregar ceros al principio ni para descartar el valor Nothing ni para hacerle copy-paste al código, ya se inventaron la funciones y la rueda
        'If (str_CveEstado = "-1") Then str_CveEstado = Nothing Else str_CveEstado = Convert.ToInt32(str_CveEstado).ToString("00")
        If (str_CveEstado = "-1") Then str_CveEstado = Nothing
        'y sale el polo victorioso pero enfadado
        If (str_CveMpio = "-1") Then str_CveMpio = Nothing Else str_CveMpio = Convert.ToInt32(str_CveMpio).ToString("00000")
        If (str_Telefono = String.Empty) Then str_Telefono = Nothing
        If (str_Fax = String.Empty) Then str_Fax = Nothing
        If (str_Web = String.Empty) Then str_Web = Nothing
        If (str_CP = String.Empty) Then str_CP = Nothing

        Try
            Dim temp As New dsAppTableAdapters.CatInstitucionTableAdapter
            temp.Insert(str_DesInstitucion, str_Web, str_Domicilio, str_Telefono, str_Fax _
                    , str_CP, str_CveEstado, str_CveMpio)
        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            lb_Error.Text = ExceptionHandler.Handler(ex, "Se produjo un error al insertar el registro nuevo, verifique los datos")
            lb_Error.Visible = True
        End Try
        Me.MultiViewInst.SetActiveView(Me.viewLista)
        BindGrid_Institucion()
    End Sub

    Protected Sub ibtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnBuscar.Click
        Me.Grid_Institucion.EditIndex = -1
        Me.Grid_Institucion.SelectedIndex = -1
        BindGrid_Institucion()
    End Sub

    'entra el Polo
    Protected Sub queNosAgarreConfesadosLVC(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Write(Me.Grid_Institucion.EditIndex)
        'Dios me perdone por hacer esto con un valor tipo numérico
        'Pendiente... a retomar en feb 2009
    End Sub
    'sale el Polo

End Class

