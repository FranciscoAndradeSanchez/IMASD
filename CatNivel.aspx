<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="CatNivel.aspx.vb" Inherits="CatNivel" title="Catalogo de Niveles de usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">

<asp:SiteMapPath ID="SiteMapPath2" runat="server"></asp:SiteMapPath>
<br /><br /><br />


    <asp:Label ID="lbTitulo" runat="server" CssClass="thtablaComun" Text="Catálogo de Niveles"></asp:Label><br />
    <br />
    <center>
    <table class="tablaHeaderTemplate" border="0">
        <tr>
            <td colspan="2">
            <asp:GridView ID="Grid_Estatus" runat="server" AutoGenerateColumns="False" ShowFooter="True"
             BorderWidth="0px" DataSourceID="odsCatNivel">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table border="0" class="tablaHeaderTemplate" width="100%">
                                <tr><td style="width:50px" align="center">Nivel</td><td>Descripción</td></tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table border="0" class="tablaItemTemplate" width="100%">
                                <tr>
                                    <td style="width:50px">
                                        <asp:Label ID="lb_Nivel" runat="server" Text='<%#Bind("Nivel") %>'></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lb_DesNivel" runat="server" Text='<%#Bind("DesNivel") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <table border="0" class="tablaAlternatigTemplate" width="100%">
                                <tr>
                                    <td style="width:50px">
                                        <asp:Label ID="lb_Nivel" runat="server" Text='<%#Bind("Nivel") %>'></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lb_DesNivel" runat="server" Text='<%#Bind("DesNivel") %>'></asp:Label>
                                    </td>                                    
                                </tr>
                            </table>
                        </AlternatingItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                <asp:ObjectDataSource ID="odsCatNivel" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetNivel" TypeName="dsAppTableAdapters.CatNivelTableAdapter"></asp:ObjectDataSource>
            </td>
        </tr>
    </table>
    </center>

<br />
<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>


</asp:Content>

