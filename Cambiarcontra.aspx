<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="Cambiarcontra.aspx.vb" Inherits="Cambiarcontra" title="Cambiar contraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">
    <asp:MultiView ID="mviwCambiarContra" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewAutenticaUsuar" runat="server">
            <table width="80%" align="center" class="tablaComun">
                <tr>
                    <td colspan="2">
                        <asp:SiteMapPath ID="smpMapaAU" runat="server">
                        </asp:SiteMapPath>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">Escriba su contraseña anterior y su nueva contraseña.</td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Contraseña anterior</td>
                    <td style="width: 70%">
                        <asp:TextBox ID="txtContraseniaAnt" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvContraseniAnt" runat="server" ErrorMessage="La contraseña anterior es obligatoria"
                            ToolTip="La contraseña anterior es obligatoria" ControlToValidate="txtContraseniaAnt" ForeColor="">x</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cusvContraseniaAntAU" runat="server" ErrorMessage="La contraseña anterior no es correcta"
                            ToolTip="La contraseña anterior no es correcta" ControlToValidate="txtContraseniaAnt" ForeColor="">x</asp:CustomValidator></td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Nueva contraseña</td>
                    <td style="width: 70%">
                        <asp:TextBox ID="txtContraseniaNuevaAU" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nueva contraseña es requerida"
                            ToolTip="Nueva contraseña es requerida" ControlToValidate="txtContraseniaNuevaAU" ForeColor="">x</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Repetir nueva contraseña</td>
                    <td style="width: 70%">
                        <asp:TextBox ID="txtRContraseniaNuevaAU" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Vuelva a escribir su nueva contraseña"
                            ToolTip="Vuelva a escribir su nueva contraseña" ControlToValidate="txtRContraseniaNuevaAU" ForeColor="">x</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvCambiarContraAU" runat="server" ErrorMessage="Las nuevas contraseñas no coinciden"
                            ToolTip="Las nuevas contraseñas no coinciden" ControlToValidate="txtRContraseniaNuevaAU" ControlToCompare="txtContraseniaNuevaAU" ForeColor="">x</asp:CompareValidator></td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        &nbsp;</td>
                    <td style="width: 70%">
                        <asp:ValidationSummary ID="vsCambiarContraAU" runat="server" Width="300px" ForeColor="" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">
                    </td>
                    <td style="width: 70%">
                        &nbsp;<asp:ImageButton ID="imgbCambiarContraseniaUsr" runat="server" ImageUrl="~/images/aplicacion/btnCambiarContrasenia.gif" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewAutenticaEmail" runat="server">
            <asp:MultiView ID="mviwAutenticaEmail" runat="server">
                <asp:View ID="viewNuevaContra" runat="server">
<table width="100%" class="tablaComun">
    <tr>
        <td colspan="2">
            <asp:SiteMapPath ID="smpMapaAE" runat="server">
            </asp:SiteMapPath>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;</td>
    </tr>
                <tr>
                    <td colspan="2">
                        Indique su nueva contraseña, es necesario que confirme su nueva contraseña.</td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 1px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        Nueva contraseña</td>
                    <td style="width: 70%">
                        <asp:TextBox ID="txtConstraseniaNuevaAE" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNuevaContraseniaAE" runat="server" ErrorMessage="La nueva contraseña es requerida"
                            ToolTip="La nueva contraseña es requerida" ControlToValidate="txtConstraseniaNuevaAE" ForeColor="">x</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cusvNuevaContraseniaAE" runat="server" ControlToValidate="txtConstraseniaNuevaAE"
                            ErrorMessage="No fue posible reiniciar su contraseña" ToolTip="No fue posible reiniciar su contraseña" ForeColor="">x</asp:CustomValidator></td>
                </tr>
                <tr style="color: #000000">
                    <td style="width: 30%">
                        Repetir nueva contraseña</td>
                    <td style="width: 70%">
                        <asp:TextBox ID="txtRConstraseniaNuevaAE" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvRNuevaContraseniaAE" runat="server" ErrorMessage="Vuelva a teclear su nueva contraseña"
                            ToolTip="Vuelva a teclear su nueva contraseña" ControlToValidate="txtRConstraseniaNuevaAE" ForeColor="">x</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvNuevaContraseniaAE" runat="server" ErrorMessage="Las contraseñas no coinciden"
                            ToolTip="Las contraseñas no coinciden" ControlToValidate="txtRConstraseniaNuevaAE" ControlToCompare="txtConstraseniaNuevaAE" ForeColor="">x</asp:CompareValidator></td>
                </tr>
                <tr>
                    <td style="width: 30%">
                        <asp:HiddenField ID="hdnfEmail" runat="server" Visible="False" />
                        <asp:HiddenField ID="hdnfHash" runat="server" Visible="False" />
                        &nbsp;
                    </td>
                    <td style="width: 70%">
                        <asp:ValidationSummary ID="vsCambiarContraseniaAE" runat="server" Width="303px" ForeColor="" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%">
                    </td>
                    <td style="width: 70%">
                        &nbsp;<asp:ImageButton ID="imgbCambiarContraseniaEmail" runat="server" ImageUrl="~/images/aplicacion/btnCambiarContrasenia.gif" /></td>
                </tr>
            </table>                                    
                </asp:View>
                <asp:View ID="viewContraCambiada" runat="server">
                    <table class="tablaComun" style="width: 100%">
                        <tr>
                            <td>
                                <asp:SiteMapPath ID="SiteMapPath3" runat="server">
                                </asp:SiteMapPath>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>Su contraseña fue actualizada con éxito.</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                    <asp:HyperLink ID="hlnkInicioApp" runat="server" NavigateUrl="~/Default.aspx">Ingresar a la aplicación.</asp:HyperLink></td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView></asp:View>
    </asp:MultiView>
</asp:Content>

