
Partial Class CatTemplate
    Inherits System.Web.UI.Page
    Dim strTipo As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        strTipo = Page.Request("i").Trim()
        If (strTipo.Length = 0) Then 'Si no trae dato es un error
            Page.Response.Redirect("~/Catalogos.aspx")
        End If
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
            BindGrid_Template()
        End If
        lb_Error.Visible = False

    End Sub

    Protected Sub Grid_Template_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Grid_Template.RowCommand
        'Si el comando enviado es para Agregar un nuevo elemento al catalogo
        If (e.CommandName.Substring(0, 3) = "ADD") Then
            Dim str_DesTemplate As String
            If (e.CommandName = "ADD_empty") Then
                str_DesTemplate = CType(Grid_Template.Controls(0).Controls(0).FindControl("txt_New_DesTemplate"), TextBox).Text
            Else
                str_DesTemplate = CType(Grid_Template.FooterRow.FindControl("txt_New_DesTemplate"), TextBox).Text
            End If


            'Verificar que almenos contega valor la descripcion  y no se quiera insertar un campo vacio
            If (str_DesTemplate.Trim().Length = 0) Then
                'Enviar un error de mensaje
                lb_Error.Text = "ERROR debe de indicar una descripcion valida"
                lb_Error.Visible = True
                Exit Sub
            End If

            'Insertar el nuevo valor
            AgregarRegistro(str_DesTemplate)
            
            BindGrid_Template()
        End If 'Termina ADD
    End Sub

    'Se llama cuando se EDITA una fila, debe de ponerse el EditIndex manualmente
    Protected Sub Grid_Template_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles Grid_Template.RowEditing
        Grid_Template.EditIndex = e.NewEditIndex
        Grid_Template.ShowFooter = False
        BindGrid_Template()
    End Sub

    'Se llama cuando se preciona CANCELAR
    Protected Sub Grid_Template_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles Grid_Template.RowCancelingEdit
        Grid_Template.EditIndex = -1
        Grid_Template.ShowFooter = True
        BindGrid_Template()
    End Sub

    'Se llama cuando GUARDAMOS un registro que se este editando
    Protected Sub Grid_Template_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles Grid_Template.RowUpdating
        'Usamos la propiedad EditIndex para encotnrar nuestros valores
        Dim int_CveTemplate As Integer
        Dim str_DesTemplate As String
        int_CveTemplate = Convert.ToInt32(CType(Grid_Template.Rows(Grid_Template.EditIndex).Cells(1).FindControl("lbl_CveTemplate"), Label).Text)
        str_DesTemplate = CType(Grid_Template.Rows(Grid_Template.EditIndex).Cells(1).FindControl("txt_DesTemplate"), TextBox).Text

        'Hacer el update
        GuardarCambios(str_DesTemplate, int_CveTemplate)

        Grid_Template.EditIndex = -1
        Grid_Template.ShowFooter = True
        BindGrid_Template()
    End Sub

    Protected Sub Grid_Template_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Grid_Template.RowDeleting
        'Usuamos la propiedad de RowIndex para obtener el indice a borrar
        Dim int_CveTemplate As Integer
        int_CveTemplate = Convert.ToInt32(CType(Grid_Template.Rows(e.RowIndex).Cells(1).FindControl("lbl_CveTemplate"), Label).Text)

        'Eliminamos el registro
        EliminarRegistro(int_CveTemplate)
        BindGrid_Template()
    End Sub

    'PROTEXION DE ELIMINACION ACCIDENTAL
    Protected Sub Grid_Template_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grid_Template.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            'Obtener la referencia al boton eliminar
            Dim botonEliminar As ImageButton = CType(e.Row.FindControl("cmdEliminar"), ImageButton)
            Dim str_Cve_Template As String = CType(e.Row.FindControl("lbl_CveTemplate"), Label).Text
            If (Not (botonEliminar Is Nothing)) Then
                botonEliminar.OnClientClick = String.Format("return confirm('¿Esta seguro de eliminar la Clave {0}?');", str_Cve_Template)
            End If

            'Verificar si hay alguna en edicion y poner el focus
            Dim textoEdit As TextBox = CType(e.Row.FindControl("txt_DesTemplate"), TextBox)
            If (Not (textoEdit Is Nothing)) Then
                textoEdit.Focus()
            End If

            'Si es Especies poner en cursivas
            If (strTipo = "Especie") Then
                Dim lbDesTemplate As Label = CType(e.Row.FindControl("lbl_DesTemplate"), Label)
                If (lbDesTemplate IsNot Nothing) Then
                    lbDesTemplate.Font.Italic = True
                End If
            End If
        End If
    End Sub
    '****************************************************************************
    'FUNCIONES PARA HACER LOS SELECTS
    Protected Sub BindGrid_Template()
        Select Case (strTipo)

            Case "AreaForestal"         'AREAS FORESTALES
                Me.lbl_Titulo.Text = "Catalogo de Áreas Forestales"
                Dim temp As New dsAppTableAdapters.CatAreaFtalTableAdapter()
                Dim ds As New dsApp.CatAreaFtalDataTable()
                ds = temp.GetAreaForestal()
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "AreaTematicas"        'AREAS TEMATICAS
                Me.lbl_Titulo.Text = "Catálogo de Áreas Temáticas"
                Dim temp As New dsAppTableAdapters.CatAreaTematicaTableAdapter()
                Dim ds As New dsApp.CatAreaTematicaDataTable()
                ds = temp.GetAreaTematica()
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "DifDiv"               'DIFUCION Y DIVULGACION
                Me.lbl_Titulo.Text = "Catálogo de difusión y divulgación"
                Dim temp As New dsAppTableAdapters.CatDifDivTableAdapter()
                Dim ds As New dsApp.CatDifDivDataTable()
                ds = temp.GetDifusionDivulgacion()
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "Escalas"              'ESCALAS
                Me.lbl_Titulo.Text = "Catálogo de escalas"
                Dim temp As New dsAppTableAdapters.CatEscalaTableAdapter()
                Dim ds As New dsApp.CatEscalaDataTable()
                ds = temp.GetEscala()
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "Ecosistemas"          'ECOSISTEMAS
                Me.lbl_Titulo.Text = "Catálogo de ecosistemas"
                Dim temp As New dsAppTableAdapters.CatEcosistemasTableAdapter()
                Dim ds As New dsApp.CatEcosistemasDataTable()
                ds = temp.GetEcosistema()
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "Escolaridad"          'ESCOLARIDAD
                Me.lbl_Titulo.Text = "Catálogo de escolaridad"
                Dim temp As New dsAppTableAdapters.CatEscolaridadTableAdapter()
                Dim ds As New dsApp.CatEscolaridadDataTable()
                ds = temp.GetEscolaridad()
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "Especie"              'ESPECIES
                Me.lbl_Titulo.Text = "Catálogo de especies"
                Dim temp As New dsAppTableAdapters.CatEspecieTableAdapter()
                Dim ds As New dsApp.CatEspecieDataTable
                ds = temp.GetEspecie()
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "Objeto"               'OBJETO
                Me.lbl_Titulo.Text = "Catálogo de objetos"
                Dim temp As New dsAppTableAdapters.CatObjetoTableAdapter
                Dim ds As New dsApp.CatObjetoDataTable
                ds = temp.GetObjeto()
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "Problematica"         'PROBLEMATICAS
                Me.lbl_Titulo.Text = "Catálogo de problemáticas"
                Dim temp As New dsAppTableAdapters.CatProblematicaTableAdapter
                Dim ds As New dsApp.CatProblematicaDataTable
                ds = temp.GetProblematica()
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "SectorTecnologia"        'SECTOR TECONOLOGIA
                Me.lbl_Titulo.Text = "Catálogo de sectores de tecnologia"
                Dim temp As New dsAppTableAdapters.CatSectorUsuarioTableAdapter
                Dim ds As New dsApp.CatSectorUsuarioDataTable
                ds = temp.GetSectorUsuario
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "TipoInfraestructura" 'TIPOS DE Infraestructura
                Me.lbl_Titulo.Text = "Catálogo de tipos de infraestructura"
                Dim temp As New dsAppTableAdapters.CatTipoInfraestructuraTableAdapter
                Dim ds As New dsApp.CatTipoInfraestructuraDataTable
                ds = temp.GetDataTipoInfraestructura
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "TipoGasto"        'TIPOS DE GASTOS
                Me.lbl_Titulo.Text = "Catálogo de tipos de gastos"
                Dim temp As New dsAppTableAdapters.CatTipoGastoTableAdapter
                Dim ds As New dsApp.CatTipoGastoDataTable
                ds = temp.GetTipoGasto()
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "TipoParticipante" 'TIPOS DE PARTICIPANTES
                Me.lbl_Titulo.Text = "Catálogo de tipos de participantes"
                Dim temp As New dsAppTableAdapters.CatTipoParticipanteTableAdapter
                Dim ds As New dsApp.CatTipoParticipanteDataTable
                ds = temp.GetTipoParticipante
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "TipoProducto"     'TIPOS DE PRODUCTOS
                Me.lbl_Titulo.Text = "Catálogo de tipos de productos"
                Dim temp As New dsAppTableAdapters.CatTipoProductoTableAdapter
                Dim ds As New dsApp.CatTipoProductoDataTable
                ds = temp.GetTipoProducto
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "TipoProyecto"     'TIPOS DE PROYECTOS
                Me.lbl_Titulo.Text = "Catálogo de tipos de proyectos"
                Dim temp As New dsAppTableAdapters.CatTipoProyectoTableAdapter
                Dim ds As New dsApp.CatTipoProyectoDataTable
                ds = temp.GetTipoProyecto
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "UsoInfo"          'USO DE LA INFORMACIÓN
                Me.lbl_Titulo.Text = "Catálogo uso de la información"
                Dim temp As New dsAppTableAdapters.CatUsoInfoTableAdapter
                Dim ds As New dsApp.CatUsoInfoDataTable
                ds = temp.GetUsoInformacion
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case "Vegetacion"       'VEGETACION
                Me.lbl_Titulo.Text = "Catálogo de vegetación"
                Dim temp As New dsAppTableAdapters.CatVegetacionTableAdapter
                Dim ds As New dsApp.CatVegetacionDataTable
                ds = temp.GetVegetacion
                Dim strDataKeyNames() As String = {"CveTemplate"}
                Me.Grid_Template.DataSource = ds
                Me.Grid_Template.DataKeyNames = strDataKeyNames
                Me.Grid_Template.DataBind()
            Case Else
                'No es ninguno valido
                Page.Response.Redirect("~/Catalogos.aspx")
        End Select
    End Sub
    '*******************************************************************************
    Protected Sub AgregarRegistro(ByVal str_DesTemplate As String)
        Try
            Select Case (strTipo)
                Case "AreaForestal"
                    Dim temp As New dsAppTableAdapters.CatAreaFtalTableAdapter()
                    temp.Insert(str_DesTemplate)
                Case "AreaTematicas"
                    Dim temp As New dsAppTableAdapters.CatAreaTematicaTableAdapter()
                    temp.Insert(str_DesTemplate)
                Case "DifDiv"
                    Dim temp As New dsAppTableAdapters.CatDifDivTableAdapter()
                    temp.Insert(str_DesTemplate)
                Case "Escalas"
                    Dim temp As New dsAppTableAdapters.CatEscalaTableAdapter()
                    temp.Insert(str_DesTemplate)
                Case "Ecosistemas"
                    Dim temp As New dsAppTableAdapters.CatEcosistemasTableAdapter()
                    temp.Insert(str_DesTemplate)
                Case "Escolaridad"
                    Dim temp As New dsAppTableAdapters.CatEscolaridadTableAdapter()
                    temp.Insert(str_DesTemplate)
                Case "Especie"
                    Dim temp As New dsAppTableAdapters.CatEspecieTableAdapter()
                    temp.Insert(str_DesTemplate)
                Case "Objeto"
                    Dim temp As New dsAppTableAdapters.CatObjetoTableAdapter()
                    temp.Insert(str_DesTemplate)
                Case "Problematica"
                    Dim temp As New dsAppTableAdapters.CatProblematicaTableAdapter
                    temp.Insert(str_DesTemplate)
                Case "SectorTecnologia"
                    Dim temp As New dsAppTableAdapters.CatSectorUsuarioTableAdapter
                    temp.Insert(str_DesTemplate)
                Case "TipoInfraestructura"
                    Dim temp As New dsAppTableAdapters.CatTipoInfraestructuraTableAdapter
                    temp.Insert(str_DesTemplate)
                Case "TipoGasto"
                    Dim temp As New dsAppTableAdapters.CatTipoGastoTableAdapter
                    temp.Insert(str_DesTemplate)
                Case "TipoParticipante"
                    Dim temp As New dsAppTableAdapters.CatTipoParticipanteTableAdapter
                    temp.Insert(str_DesTemplate)
                Case "TipoProducto"
                    Dim temp As New dsAppTableAdapters.CatTipoProductoTableAdapter
                    temp.Insert(str_DesTemplate)
                Case "TipoProyecto"
                    Dim temp As New dsAppTableAdapters.CatTipoProyectoTableAdapter
                    temp.Insert(str_DesTemplate)
                Case "UsoInfo"
                    Dim temp As New dsAppTableAdapters.CatUsoInfoTableAdapter
                    temp.Insert(str_DesTemplate)
                Case "Vegetacion"
                    Dim temp As New dsAppTableAdapters.CatVegetacionTableAdapter
                    temp.Insert(str_DesTemplate)
                Case Else
                    'No es ninguno valido
                    Page.Response.Redirect("~/Catalogos.aspx")
            End Select
        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            lb_Error.Text = ExceptionHandler.Handler(ex, "Problemas en la base de datos al Guardar los datos, verifique los datos")
            lb_Error.Visible = True
        End Try
    End Sub
    '****************************************************************************
    Protected Sub EliminarRegistro(ByVal int_CveTemplate As Integer)
        Try
            Select Case strTipo
                Case "AreaForestal"
                    Dim temp As New dsAppTableAdapters.CatAreaFtalTableAdapter
                    temp.Delete(int_CveTemplate)
                Case "AreaTematicas"
                    Dim temp As New dsAppTableAdapters.CatAreaTematicaTableAdapter
                    temp.Delete(int_CveTemplate)
                Case "DifDiv"
                    Dim temp As New dsAppTableAdapters.CatDifDivTableAdapter()
                    temp.Delete(int_CveTemplate)
                Case "Escalas"
                    Dim temp As New dsAppTableAdapters.CatEscalaTableAdapter()
                    temp.Delete(int_CveTemplate)
                Case "Ecosistemas"
                    Dim temp As New dsAppTableAdapters.CatEcosistemasTableAdapter()
                    temp.Delete(int_CveTemplate)
                Case "Escolaridad"
                    Dim temp As New dsAppTableAdapters.CatEscolaridadTableAdapter()
                    temp.Delete(int_CveTemplate)
                Case "Especie"
                    Dim temp As New dsAppTableAdapters.CatEspecieTableAdapter()
                    temp.Delete(int_CveTemplate)
                Case "Objeto"
                    Dim temp As New dsAppTableAdapters.CatObjetoTableAdapter
                    temp.Delete(int_CveTemplate)
                Case "Problematica"
                    Dim temp As New dsAppTableAdapters.CatProblematicaTableAdapter
                    temp.Delete(int_CveTemplate)
                Case "SectorTecnologia"
                    Dim temp As New dsAppTableAdapters.CatSectorUsuarioTableAdapter
                    temp.Delete(int_CveTemplate)
                Case "TipoInfraestructura"
                    Dim temp As New dsAppTableAdapters.CatTipoInfraestructuraTableAdapter
                    temp.Delete(int_CveTemplate)
                Case "TipoGasto"
                    Dim temp As New dsAppTableAdapters.CatTipoGastoTableAdapter
                    temp.Delete(int_CveTemplate)
                Case "TipoParticipante"
                    Dim temp As New dsAppTableAdapters.CatTipoParticipanteTableAdapter
                    temp.Delete(int_CveTemplate)
                Case "TipoProducto"
                    Dim temp As New dsAppTableAdapters.CatTipoProductoTableAdapter
                    temp.Delete(int_CveTemplate)
                Case "TipoProyecto"
                    Dim temp As New dsAppTableAdapters.CatTipoProyectoTableAdapter
                    temp.Delete(int_CveTemplate)
                Case "UsoInfo"
                    Dim temp As New dsAppTableAdapters.CatUsoInfoTableAdapter
                    temp.Delete(int_CveTemplate)
                Case "Vegetacion"
                    Dim temp As New dsAppTableAdapters.CatVegetacionTableAdapter
                    temp.Delete(int_CveTemplate)
                Case Else
                    'No es ninguno valido
                    Page.Response.Redirect("~/Catalogos.aspx")
            End Select
        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            lb_Error.Text = ExceptionHandler.Handler(ex, "Problemas en la base de datos al Eliminar, informe al administrador")
            lb_Error.Visible = True
        End Try

    End Sub
    '******************************************************************************
    Protected Sub GuardarCambios(ByVal str_DesTemplate As String, ByVal int_CveTemplate As Integer)
        Try
            Select Case strTipo
                Case "AreaForestal"
                    Dim temp As New dsAppTableAdapters.CatAreaFtalTableAdapter()
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case "AreaTematicas"
                    Dim temp As New dsAppTableAdapters.CatAreaTematicaTableAdapter()
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case "DifDiv"
                    Dim temp As New dsAppTableAdapters.CatDifDivTableAdapter()
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case "Escalas"
                    Dim temp As New dsAppTableAdapters.CatEscalaTableAdapter()
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case "Ecosistemas"
                    Dim temp As New dsAppTableAdapters.CatEcosistemasTableAdapter()
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case "Escolaridad"
                    Dim temp As New dsAppTableAdapters.CatEscolaridadTableAdapter()
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case "Especie"
                    Dim temp As New dsAppTableAdapters.CatEspecieTableAdapter()
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case "Objeto"
                    Dim temp As New dsAppTableAdapters.CatObjetoTableAdapter()
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case "Problematica"
                    Dim temp As New dsAppTableAdapters.CatProblematicaTableAdapter
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case "SectorTecnologia"
                    Dim temp As New dsAppTableAdapters.CatSectorUsuarioTableAdapter
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case "TipoInfraestructura"
                    Dim temp As New dsAppTableAdapters.CatTipoInfraestructuraTableAdapter
                    temp.Update(str_DesTemplate, int_CveTemplate)
                Case "TipoGasto"
                    Dim temp As New dsAppTableAdapters.CatTipoGastoTableAdapter
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case "TipoParticipante"
                    Dim temp As New dsAppTableAdapters.CatTipoParticipanteTableAdapter
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case "TipoProducto"
                    Dim temp As New dsAppTableAdapters.CatTipoProductoTableAdapter
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case "TipoProyecto"
                    Dim temp As New dsAppTableAdapters.CatTipoProyectoTableAdapter
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case "UsoInfo"
                    Dim temp As New dsAppTableAdapters.CatUsoInfoTableAdapter
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case "Vegetacion"
                    Dim temp As New dsAppTableAdapters.CatVegetacionTableAdapter
                    temp.Update(str_DesTemplate, int_CveTemplate, int_CveTemplate)
                Case Else
                    'No es ninguno valido
                    Page.Response.Redirect("~/Catalogos.aspx")
            End Select
        Catch ex As Exception
            Dim ExceptionHandler As clsErrorHandler = New clsErrorHandler()
            lb_Error.Text = ExceptionHandler.Handler(ex, "Problemas en la base al guardar, verifique los datos")
            lb_Error.Visible = True
        End Try
    End Sub
    
End Class
