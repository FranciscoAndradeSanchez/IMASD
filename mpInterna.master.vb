
Partial Class mpInterna
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            If (Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) IsNot Nothing) Or _
               (Not (Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoUsuario").ToString) = String.Empty)) Then
                Select Case CInt(Session(System.Web.Configuration.WebConfigurationManager.AppSettings("SesionCampoNivel").ToString))
                    Case clsAuthentication.AuthorizationLevelList.Administering
                        Me.mnuAplicacion.Items.Add(New MenuItem("Proyectos", "Proyectos", String.Empty, "~/RegistroProyectos.aspx", "_self"))
                        Me.mnuAplicacion.Items.Add(New MenuItem("Catálogos", "Catálogos", String.Empty, "~/Catalogos.aspx", "_self"))
                        Me.mnuAplicacion.Items.Add(New MenuItem("Reportes", "Reportes", String.Empty, "javascript:;", "_self"))
                        Me.mnuAplicacion.Items(2).ChildItems.Add(New MenuItem("Estatus de proyectos", "Estatus de proyectos", String.Empty, "~/Reportes.aspx?rpt=1", "_self"))
                        Me.mnuAplicacion.Items(2).ChildItems.Add(New MenuItem("Reportes Financieros", "Reportes Financieros", String.Empty, "~/Reportes.aspx?rpt=2", "_self"))
                        Me.mnuAplicacion.Items(2).ChildItems.Add(New MenuItem("Acumulado de proyectos", "Acumulado de proyectos", String.Empty, "~/Reportes.aspx?rpt=3", "_self"))
                        Me.mnuAplicacion.Items(2).ChildItems.Add(New MenuItem("Estatus de productos", "Estatus de productos", String.Empty, "~/Reportes.aspx?rpt=4", "_self"))
                        Me.mnuAplicacion.Items(2).ChildItems.Add(New MenuItem("Descarga de productos", "Descarga de productos", String.Empty, "~/Reportes.aspx?rpt=5", "_self"))
                        Me.mnuAplicacion.Items(2).ChildItems.Add(New MenuItem("Usuarios", "Usuarios", String.Empty, "~/Reportes.aspx?rpt=6", "_self"))
                        Me.mnuAplicacion.Items(2).ChildItems.Add(New MenuItem("Beneficiarios", "Beneficiarios", String.Empty, "~/Reportes.aspx?rpt=7", "_self"))
                        Me.mnuAplicacion.Items(2).ChildItems.Add(New MenuItem("Infraestructura", "Infraestructura", String.Empty, "~/Reportes.aspx?rpt=8", "_self"))
                        Me.mnuAplicacion.Items.Add(New MenuItem("Usuarios", "Usuarios", String.Empty, "javascript:;", "_self"))
                        Me.mnuAplicacion.Items(3).ChildItems.Add(New MenuItem("Cambiar contraseña", "Cambiar contraseña", String.Empty, "~/Cambiarcontra.aspx", "_self"))
                        Me.mnuAplicacion.Items(3).ChildItems.Add(New MenuItem("Modificar permisos", "Modificar permisos", String.Empty, "~/Permisos.aspx", "_self"))
                        Me.mnuAplicacion.Items.Add(New MenuItem("Cerrar sesión", "Cerrar sesión", String.Empty, "~/logout.aspx", "_self"))
                        Me.mnuAplicacion.Items.Add(New MenuItem("Ayuda", "Ayuda", String.Empty, "~/ayuda/ayuda.aspx", "_blank"))
                        Me.idpnlEncabezado.Visible = False
                    Case clsAuthentication.AuthorizationLevelList.Financial
                        Me.mnuAplicacion.Items.Add(New MenuItem("Proyectos", "Proyectos", String.Empty, "~/RegistroProyectos.aspx", "_self"))
                        'Me.mnuAplicacion.Items.Add(New MenuItem("Catálogos", "Catálogos", String.Empty, "~/Catalogos.aspx", "_self"))
                        Me.mnuAplicacion.Items.Add(New MenuItem("Usuarios", "Usuarios", String.Empty, "~/#", "_self"))
                        Me.mnuAplicacion.Items(1).ChildItems.Add(New MenuItem("Cambiar contraseña", "Cambiar contraseña", String.Empty, "~/Cambiarcontra.aspx", "_self"))
                        'Me.mnuAplicacion.Items(2).ChildItems.Add(New MenuItem("Modificar permisos", "Modificar permisos", String.Empty, "~/#", "_self"))
                        Me.mnuAplicacion.Items.Add(New MenuItem("Cerrar sesión", "Cerrar sesión", String.Empty, "~/logout.aspx", "_self"))
                        Me.mnuAplicacion.Items.Add(New MenuItem("Ayuda", "Ayuda", String.Empty, "~/ayuda/ayuda.aspx", "_blank"))
                        Me.idpnlEncabezado.Visible = False
                    Case clsAuthentication.AuthorizationLevelList.LimitedUpdating
                        Me.mnuAplicacion.Items.Add(New MenuItem("Proyectos", "Proyectos", String.Empty, "~/RegistroProyectos.aspx", "_self"))
                        'Me.mnuAplicacion.Items.Add(New MenuItem("Catálogos", "Catálogos", String.Empty, "javascript:;", "_self"))
                        Me.mnuAplicacion.Items.Add(New MenuItem("Usuarios", "Usuarios", String.Empty, "javascript:;", "_self"))
                        Me.mnuAplicacion.Items(1).ChildItems.Add(New MenuItem("Cambiar contraseña", "Cambiar contraseña", String.Empty, "~/Cambiarcontra.aspx", "_self"))
                        'Me.mnuAplicacion.Items(2).ChildItems.Add(New MenuItem("Modificar permisos", "Modificar permisos", String.Empty, "javascript:;", "_self"))
                        Me.mnuAplicacion.Items.Add(New MenuItem("Cerrar sesión", "Cerrar sesión", String.Empty, "~/logout.aspx", "_self"))
                        Me.mnuAplicacion.Items.Add(New MenuItem("Ayuda", "Ayuda", String.Empty, "~/ayuda/ayuda.aspx", "_blank"))
                        Me.idpnlEncabezado.Visible = False
                    Case clsAuthentication.AuthorizationLevelList.Consulting
                        Me.mnuAplicacion.Items.Add(New MenuItem("Proyectos", "Proyectos", String.Empty, "~/RegistroProyectos.aspx", "_self"))
                        'Me.mnuAplicacion.Items.Add(New MenuItem("Catálogos", "Catálogos", String.Empty, "javascript:;", "_self"))
                        Me.mnuAplicacion.Items.Add(New MenuItem("Usuarios", "Usuarios", String.Empty, "javascript:;", "_self"))
                        Me.mnuAplicacion.Items(1).ChildItems.Add(New MenuItem("Cambiar contraseña", "Cambiar contraseña", String.Empty, "Cambiarcontra.aspx", "_self"))
                        'Me.mnuAplicacion.Items(2).ChildItems.Add(New MenuItem("Modificar permisos", "Modificar permisos", String.Empty, "~/#", "_self"))
                        Me.mnuAplicacion.Items.Add(New MenuItem("Cerrar sesión", "Cerrar sesión", String.Empty, "~/logout.aspx", "_self"))
                        Me.mnuAplicacion.Items.Add(New MenuItem("Ayuda", "Ayuda", String.Empty, "~/ayuda/ayuda.aspx", "_blank"))
                        Me.idpnlEncabezado.Visible = True
                    Case Else
                        Me.mnuAplicacion.Visible = False

                End Select
            End If
        End If
    End Sub

    Protected Sub mnuAplicacion_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles mnuAplicacion.MenuItemClick

    End Sub
End Class

