<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="CatTemplate.aspx.vb" Inherits="CatTemplate" title="Catálogos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">


<script type="text/javascript" src="js/fnayuda.js"></script>
<asp:SiteMapPath ID="SiteMapPath2" runat="server"></asp:SiteMapPath>
<br /><br /><br />

<asp:Label ID="lbl_Titulo" runat="server" CssClass="thtablaComun">
    Llenar titulo pagina
</asp:Label><br /><br />
<asp:Label ID="lb_Error" runat="server" Text=""
        CssClass="mesajeError" Visible="false"></asp:Label>
<asp:GridView ID="Grid_Template" runat="server" AutoGenerateColumns="false"
     ShowFooter="true" BorderStyle="none" BorderWidth="0px" CssClass="tablaItemTemplate">
    <Columns>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:ImageButton ID="cmdEditar" runat="server" CommandName="Edit"
                    ImageUrl="~/images/aplicacion/btnEditar.gif" CausesValidation="false" />
            </ItemTemplate>
            <EditItemTemplate></EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Clave &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Descripción" SortExpression="CveTemplate">
            <ItemStyle HorizontalAlign="Center"/>
            <ItemTemplate>
                <table class="tablaItemTemplate" width="100%" border="0" cellpadding="3">
                    <tr>
                        <td style="width:50px;">
                        <asp:Label ID="lbl_CveTemplate" runat="server" Text='<%#Bind("CveTemplate") %>' Font-Bold="true"></asp:Label>
                        </td>
                        <td align="left">
                        <asp:Label ID="lbl_DesTemplate" runat="server" Text='<%#Bind("DesTemplate") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <table class="tablaAlternatigTemplate" width="100%" border="0" cellpadding="3">
                    <tr>
                        <td style="width:50px;">
                        <asp:Label ID="lbl_CveTemplate" runat="server" Text='<%#Bind("CveTemplate") %>' Font-Bold="true"></asp:Label>
                        </td>
                        <td align="left">
                        <asp:Label ID="lbl_DesTemplate" runat="server" Text='<%#Bind("DesTemplate") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <table class="tablaEditarTemplate" width="100%" border="0" cellpadding="3">
                    <tr>
                        <th colspan="2">Editando...</th>
                    </tr>
                    <tr>
                        <td style="width:50px;">
                        <asp:Label ID="lbl_CveTemplate" runat="server" Text='<%#Bind("CveTemplate") %>' Font-Bold="true"></asp:Label>
                        </td>
                        <td align="left">
                        <asp:TextBox ID="txt_DesTemplate" runat="server" Text='<%#Bind("DesTemplate") %>' MaxLength="100" Columns="70"></asp:TextBox><br />
                        <asp:RequiredFieldValidator
                            ID="rfv_DesTemplate" runat="server" ControlToValidate="txt_DesTemplate"
                            ErrorMessage="La Descripción es requerida"
                            ToolTip="La descripción es requerida" CssClass="mesajeError" 
                            ForeColor="black" >La descripción es requerida</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            ID="rev_DesTemplate" runat="server" ControlToValidate="txt_DesTemplate"
                            ToolTip="La descripción tiene caracteres no permitidos"
                            ErrorMessage="La descripción tiene caracteres no permitidos" 
                            ValidationExpression="^[0-9a-zA-Z',;:.ñÑÁáÉéÍíÓóÚúÜü\s\(\)\p{P}-]{1,100}$"  CssClass="mesajeError" 
                            ForeColor="black">La descripción tiene caracteres no permitidos
                            <a href="javascript:MostrarAyuda('Ayuda_DesTemplate')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                            </asp:RegularExpressionValidator>
                            
                        <span id="Ayuda_DesTemplate" class="msgAyuda" style="visibility:hidden">
                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                <th><a href="javascript:MostrarAyuda('Ayuda_DesTemplate')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                <td>
                                    Caracteres permitidos:<br /><br />
                                    Minusculas -> (a-z)<br />
                                    Mayusculas -> (A-Z)<br />
                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                    Especiales ->&nbsp;&nbsp;  - ' . ( ) , ; :<br />
                                    Máximo de caracteres -> 100<br />
                                </td></tr>
                            </table>
                        </span>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:Panel ID="Panel1" DefaultButton="linkAdd" runat="server">
                <asp:Image ID="felchita_add" runat="server" ImageUrl="~/images/aplicacion/felchamini.gif" />
                <asp:LinkButton ID="linkAdd" runat="server" CommandName="ADD"
                    Text="Agregar" CausesValidation="true"></asp:LinkButton>
                <asp:TextBox ID="txt_New_DesTemplate" runat="server" MaxLength="100" Columns="50"></asp:TextBox><br />
                <asp:RequiredFieldValidator
                    ID="rfv_NewDesTemplate" runat="server" ControlToValidate="txt_New_DesTemplate"
                    Text="La Descripción es requerida"
                    ToolTip="La descripción es requerida" CssClass="mesajeError" 
                    ForeColor="black">La Descripción es requerida</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ID="rev_NewDesTemplate" runat="server" ControlToValidate="txt_New_DesTemplate"
                    Text="La descripción contiene caracteres no permitidos" 
                    ErrorMessage="La descripción tiene caracteres no permitidos" ToolTip="La descripción tiene caracteres no permitidos"
                    ValidationExpression="^[0-9a-zA-Z',;:.ñÑÁáÉéÍíÓóÚúÜü\s\(\)\p{P}-]{1,100}$"  CssClass="mesajeError" 
                    ForeColor="black">La descripción tiene caracteres no permitidos
                    <a href="javascript:MostrarAyuda('Ayuda_NewDesTemplate')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                    </asp:RegularExpressionValidator>
                    
                <span id="Ayuda_NewDesTemplate" class="msgAyuda" style="visibility:hidden">
                    <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                        <th><a href="javascript:MostrarAyuda('Ayuda_NewDesTemplate')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                        <td>
                            Caracteres permitidos:<br /><br />
                            Minusculas -> (a-z)<br />
                            Mayusculas -> (A-Z)<br />
                            Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                            Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                            Especiales ->&nbsp;&nbsp;  - ' . ( ) , ; :<br />
                            Máximo de caracteres -> 100<br />
                        </td></tr>
                    </table>
                </span>
                </asp:Panel>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:ImageButton ID="cmdEliminar" runat="server" CommandName="Delete"
                    ImageUrl="~/images/aplicacion/btnEliminar.gif" CausesValidation="false" />
            </ItemTemplate>
            <EditItemTemplate>
                <br />
                <asp:ImageButton ID="cmdUpdate" runat="server" CommandName="Update"
                    ImageUrl="~/images/aplicacion/btnGuardar.gif" CausesValidation="true" />
                <asp:ImageButton ID="cmdCancel" runat="server" CommandName="Cancel"
                    ImageUrl="~/images/aplicacion/btnCancelar.gif" CausesValidation="false" />
                <br /><br />
            </EditItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        
        <asp:Panel ID="Panel1" DefaultButton="cmdNuevo" runat="server">
        <table class="" width="80%">
            <tr>
                <td align="right" style="width:100px">Descripción:</td>
                <td style="width:auto;">
                    <asp:TextBox ID="txt_New_DesTemplate" runat="server" MaxLength="100" Columns="50"></asp:TextBox>
                    <asp:ImageButton ID="cmdNuevo" runat="server" CommandName="ADD_empty"
                        ImageUrl="~/images/aplicacion/btnNuevo.gif" CausesValidation="true"
                        ImageAlign="AbsBottom" />
                    <br />
                    <asp:RequiredFieldValidator
                        ID="rfv_NewDesTemplate" runat="server" ControlToValidate="txt_New_DesTemplate"
                        Text="La Descripción es requerida"
                        ToolTip="La descripción es requerida" CssClass="mesajeError"
                        ForeColor="black">La descripción es requerida</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator
                        ID="rev_NewDesTemplate_empty" runat="server" ControlToValidate="txt_New_DesTemplate"
                        Text="La descripción contiene caracteres no permitidos" 
                        ErrorMessage="La descripción tiene caracteres no permitidos" 
                        ToolTip="La descripción tiene caracteres no permitidos" 
                        ValidationExpression="^[0-9a-zA-Z',;:.ñÑÁáÉéÍíÓóÚúÜü\s\(\)\p{P}-]{1,100}$"  CssClass="mesajeError" 
                        ForeColor="black">La descripción tiene caracteres no permitidos
                        <a href="javascript:MostrarAyuda('Ayuda_NewDesTemplate_empty')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                        </asp:RegularExpressionValidator>
                        
                    <span id="Ayuda_NewDesTemplate_empty" class="msgAyuda" style="visibility:hidden">
                        <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                            <th><a href="javascript:MostrarAyuda('Ayuda_NewDesTemplate_empty')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                            <td>
                                Caracteres permitidos:<br /><br />
                                Minusculas -> (a-z)<br />
                                Mayusculas -> (A-Z)<br />
                                Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                Especiales ->&nbsp;&nbsp;  - ' . ( ) , ; :<br />
                                Máximo de caracteres -> 100<br />
                            </td></tr>
                        </table>
                    </span>
                    
                </td>
            </tr>
        </table>
        
        </asp:Panel>
        
    </EmptyDataTemplate>
</asp:GridView>

<br />
<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>




</asp:Content>

