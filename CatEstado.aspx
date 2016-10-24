<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="CatEstado.aspx.vb" Inherits="CatEstado" title="Catalogo de Estados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">

<script type="text/javascript" src="js/fnayuda.js"></script>

<asp:SiteMapPath ID="SiteMapPath2" runat="server"></asp:SiteMapPath>
<br /><br /><br />

<asp:Label ID="lbl_Titulo" runat="server" CssClass="thtablaComun">
    Catalogo de Estados
</asp:Label><br />
<asp:Label ID="lb_Error" runat="server" Text=""
        CssClass="mensajeFlotante" ForeColor="black" BackColor="yellow" 
        BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Visible="false"
        Font-Size="X-Small"></asp:Label>
<br />
<center>
<asp:GridView ID="Grid_Estados" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center"
     ShowFooter="true" BorderStyle="none" BorderWidth="0px" CssClass="tablaItemTemplate">
    <Columns>
        <asp:TemplateField HeaderText="Clave &#160; &#160; &#160; &#160; &#160; &#160; &#160; Descripci&#243;n" SortExpression="CveTemplate">
            <ItemStyle HorizontalAlign="Center"/>
            <ItemTemplate>
                <table class="tablaItemTemplate" width="100%" border="0" cellpadding="3">
                    <tr>
                        <td style="width:50px;">
                        <asp:Label ID="lbl_CveEstado" runat="server" Text='<%#Bind("CveEstado") %>' Font-Bold="true"></asp:Label>
                        </td>
                        <td align="left">
                        <asp:Label ID="lbl_DesEstado" runat="server" Text='<%#Bind("DesEstado") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <table class="tablaAlternatigTemplate" width="100%" border="0" cellpadding="3">
                    <tr>
                        <td style="width:50px;">
                        <asp:Label ID="lbl_CveEstado" runat="server" Text='<%#Bind("CveEstado") %>' Font-Bold="true"></asp:Label>
                        </td>
                        <td align="left">
                        <asp:Label ID="lbl_DesEstado" runat="server" Text='<%#Bind("DesEstado") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <table  class="tablaEditarTemplate" border="0" cellpadding="3">
                    <tr>
                        <th colspan="2">Editando...</th>
                    </tr>
                    <tr>
                        <td style="width:50px;">
                        <asp:Label ID="lbl_CveEstado" runat="server" Text='<%#Bind("CveEstado") %>' Font-Bold="true"></asp:Label>
                        </td>
                        <td align="left">
                        <asp:TextBox ID="txt_DesEstado" runat="server" Text='<%#Bind("DesEstado") %>' MaxLength="100" Columns="40"></asp:TextBox>
                        <asp:RequiredFieldValidator
                            ID="rfv_DesEstado" runat="server" ControlToValidate="txt_DesEstado"
                            ErrorMessage="La Descripción es requerida"
                            ToolTip="La descripción es requerida" CssClass="mensajeFlotante" 
                            ForeColor="black" BackColor="yellow" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Font-Size="X-Small"
                            >La descripción es requerida</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            ID="rev_DesEstado" runat="server" ControlToValidate="txt_DesEstado"
                            ToolTip="La descripción tiene caracteres no permitidos"
                            ErrorMessage="La descripción tiene caracteres no permitidos" 
                            ValidationExpression="^[a-zA-Z'ñÑÁáÉéÍíÓóÚúÜü\s-]{1,100}$"  CssClass="mensajeFlotante" 
                            ForeColor="black" BackColor="yellow" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Font-Size="X-Small"
                            >La descripción tiene caracteres no permitidos 
                            <a href="javascript:MostrarAyuda('Ayuda_DesEstado')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                            </asp:RegularExpressionValidator>
                        <span id="Ayuda_DesEstado" class="msgAyuda" style="visibility:hidden">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>&nbsp;Ayuda </th>
                                    <th>
                                        <a href="javascript:MostrarAyuda('Ayuda_DesEstado')">
                                            <img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" />
                                        </a>
                                    </th>
                                </tr>
                                <td>
                                    Caracteres permitidos:<br /><br />
                                    Minusculas -> (a-z)<br />
                                    Mayusculas -> (A-Z)<br />
                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                    Especiales -> (-, ,')<br />
                                    Máximo de caracteres -> 100<br />
                                </td>
                            </table>
                        </span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:ImageButton ID="cmdUpdate" runat="server" CommandName="Update"
                                ImageUrl="~/images/aplicacion/btnGuardar.gif" CausesValidation="true" />
                            &nbsp; &nbsp; &nbsp; &nbsp;                                
                            <asp:ImageButton ID="cmdCancel" runat="server" CommandName="Cancel"
                                ImageUrl="~/images/aplicacion/btnCancelar.gif" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:ImageButton ID="cmdEditar" runat="server" CommandName="Edit"
                    ImageUrl="~/images/aplicacion/btnEditar.gif" CausesValidation="false" />
            </ItemTemplate>
            <EditItemTemplate></EditItemTemplate>
        </asp:TemplateField>
    </Columns>
    
</asp:GridView>
</center>
<br />
<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>




</asp:Content>

