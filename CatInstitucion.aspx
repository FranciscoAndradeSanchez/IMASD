<%@ Page Language="VB" MasterPageFile="~/mpInterna.master" AutoEventWireup="false" CodeFile="CatInstitucion.aspx.vb" Inherits="CatInstitucion" title="Catalogo de Instituciones" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipalInterna" Runat="Server">

<script type="text/javascript" src="js/fnayuda.js"></script>

<asp:ScriptManager runat="server" ID="scrmInfoGeneral"></asp:ScriptManager>            

<asp:SiteMapPath ID="SiteMapPath2" runat="server"></asp:SiteMapPath>
<br /><br /><br />


    <asp:Label ID="lbTitulo" runat="server" CssClass="thtablaComun" Text="Catálogo de Instituciones"></asp:Label><br />
    <br />
    <asp:Label ID="lb_Error" runat="server" Text=""
        CssClass="mesajeError" Visible="false"></asp:Label>
    <center>
    <asp:MultiView ID="MultiViewInst" runat="server">
        <asp:View ID="viewLista" runat="server">
        
            <table class="tablaComun" width="90%">
                <tr>
                    <td align="left">
                        <asp:Panel ID="pnlBuscar" runat="server" DefaultButton="ibtnBuscar">
                        <asp:TextBox ID="txtBusqueda" runat="server" Width="250px" MaxLength="100"></asp:TextBox>
                        <asp:ImageButton ID="ibtnBuscar" runat="server" ImageUrl="~/images/aplicacion/btnBuscar.gif" />
                        </asp:Panel>
                        <asp:RegularExpressionValidator ID="revBusqueda" runat="server"
                            ControlToValidate="txtBusqueda" ErrorMessage="Texto a buscar tiene caracteres no permitidos"
                            ForeColor="" ToolTip="Texto a buscar tiene caracteres no permitidos" CssClass="mesajeError" 
                            ValidationExpression="^[a-zA-Z'ñÑÁáÉéÍíÓóÚúÜü)(.,;:\\/\-_\d\s]{0,100}$"
                            >Texto a buscar tiene caracteres no permitidos
                            <a href="javascript:MostrarAyuda('Ayuda_Busqueda')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                            </asp:RegularExpressionValidator>
                            
                        <span id="Ayuda_Busqueda" class="msgAyuda" style="visibility:hidden">
                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                <th><a href="javascript:MostrarAyuda('Ayuda_Busqueda')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                <td>
                                    Caracteres permitidos:<br /><br />
                                    Minusculas -> (a-z)<br />
                                    Mayusculas -> (A-Z)<br />
                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                    Especiales ->&nbsp;&nbsp;  - ' . ( ) , ; : \ / _<br />
                                    Máximo de caracteres -> 100<br />
                                </td></tr>
                            </table>
                        </span>
                            
                    </td>
                    <td align="right">
                        Páginas: <asp:Label ID="lb_paginas" runat="server" Text=""></asp:Label>/<asp:Label ID="lb_paginas_total" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:ImageButton ID="cmdNuevo" runat="server" ImageUrl="images/aplicacion/btnNuevo.gif" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="Grid_Institucion" runat="server" AutoGenerateColumns="false"
             BorderWidth="0px" AllowPaging="True" PagerSettings-Mode="NextPreviousFirstLast" 
             PagerSettings-FirstPageText="&lt;&lt; Primer Página" 
             PagerSettings-LastPageText="Última Página &gt;&gt;" 
             PagerSettings-NextPageText="Siguiente &gt;" 
             PagerSettings-PreviousPageText="Anterior &lt;" 
             PagerSettings-Position="TopAndBottom">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table border="0" class="tablaItemTemplate" width="100%">
                                <tr>
                                    <td style="width:110px;" rowspan="3">
                                        <asp:ImageButton ID="cmdEditar" runat="server" ImageUrl="~/images/aplicacion/btnEditar.gif" CommandName="edit" CausesValidation="false" />
                                    </td>
                                    
                                    <th style="width: 110px">Clave:</th>
                                    <td align="left" style="width: 100%"><asp:Label ID="lb_CveInstitucion" runat="server" Text='<%#Bind("CveInstitucion") %>'></asp:Label></td>
                                    
                                    <td style="width:110px;" rowspan="3">
                                        <asp:ImageButton ID="cmdEliminar" runat="server" ImageUrl="~/images/aplicacion/btnEliminar.gif" CommandName="delete" CausesValidation="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 110px">Descripcion:</th>
                                    <td align="left" style="width: 100%">
                                        <asp:Label ID="lb_DesInstitucion" runat="server" Text='<%#Bind("DesInstitucion") %>'></asp:Label><br />
                                        <asp:Label ID="lb_Error" runat="server" Text=""
                                            CssClass="mensajeFlotante" ForeColor="black" BackColor="yellow" 
                                            BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Visible="false" 
                                            Font-Size="X-Small"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">
                                        <asp:UpdatePanel id="updp_InfoInstitucion" runat="server">
                                            <contenttemplate>
                                                <asp:ImageButton id="imgExpandirInfoInst" runat="server" ImageUrl="~/images/aplicacion/expandir.gif" CausesValidation="False" CommandName="cmdMas" __designer:wfdid="w7"></asp:ImageButton> 
                                                <asp:Label id="lblMasInfoInst" runat="server" Text="Más..." __designer:wfdid="w8"></asp:Label> 
                                                <asp:UpdateProgress id="UpdateProgress1" runat="server" __designer:wfdid="w9" DisplayAfter="100" AssociatedUpdatePanelID="updp_InfoInstitucion">
                                                    <ProgressTemplate>
                                                        <IMG class="mensajeFlotante" src="images/aplicacion/relojAreana.gif" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress> <BR />
                                                <asp:Panel id="pnlExpandirInfoInst" runat="server" Visible="false" __designer:wfdid="w10" Width="100%">
                                                    <TABLE style="FONT-SIZE: 10px"><TBODY>
                                                        <TR>
                                                            <TH style="WIDTH: 90px">Domicilio:</TH>
                                                            <TD colSpan=3>
                                                                <asp:Label id="lb_Domicilio" runat="server" Text='<%# Bind("Domicilio") %>' __designer:wfdid="w11"></asp:Label>
                                                                <BR />
                                                                <asp:Label id="lb_Municipio" runat="server" Text='<%# Bind("Municipio") %>' __designer:wfdid="w12"></asp:Label>, <asp:Label id="lb_Estado" runat="server" Text='<%# Bind("Estado") %>' __designer:wfdid="w13"></asp:Label> 
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TH style="WIDTH: 90px">Telefono:</TH>
                                                            <TD><asp:Label id="lb_Telefono" runat="server" __designer:wfdid="w14" text='<%#Bind("Telefono") %>'></asp:Label></TD>
                                                            <TH>Fax:</TH>
                                                            <TD><asp:Label id="lb_Fax" runat="server" __designer:wfdid="w15" text='<%#Bind("Fax") %>'></asp:Label></TD>
                                                        </TR>
                                                        <TR>
                                                            <TH>CP:</TH>
                                                            <TD><asp:Label id="lb_CP" runat="server" text='<%#Bind("CP") %>'></asp:Label></TD>
                                                            <TH style="WIDTH: 90px">Web:</TH>
                                                            <TD><asp:Label id="lb_Web" runat="server" __designer:wfdid="w16" text='<%#Bind("Web") %>'></asp:Label></TD>                                                            
                                                        </TR>
                                                    </TBODY></TABLE>
                                                </asp:Panel> 
                                            </contenttemplate>
                                        </asp:UpdatePanel>
                                        
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <table border="0" class="tablaAlternatigTemplate" width="100%">
                                <tr>
                                    <td style="width:110px;" rowspan="3">
                                        <asp:ImageButton ID="cmdEditar" runat="server" ImageUrl="~/images/aplicacion/btnEditar.gif" CommandName="edit" CausesValidation="false" />
                                    </td>
                                    
                                    <th style="width: 110px">Clave:</th>
                                    <td align="left" style="width: 100%"><asp:Label ID="lb_CveInstitucion" runat="server" Text='<%#Bind("CveInstitucion") %>'></asp:Label></td>
                                    
                                    <td style="width:110px;" rowspan="3">
                                        <asp:ImageButton ID="cmdEliminar" runat="server" ImageUrl="~/images/aplicacion/btnEliminar.gif" CommandName="delete" CausesValidation="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 110px">Descripcion:</th>
                                    <td align="left" style="width: 100%">
                                        <asp:Label ID="lb_DesInstitucion" runat="server" Text='<%#Bind("DesInstitucion") %>'></asp:Label><br />
                                        <asp:Label ID="lb_Error" runat="server" Text=""
                                            CssClass="mensajeFlotante" ForeColor="black" BackColor="yellow" 
                                            BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Visible="false" 
                                            Font-Size="X-Small"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">
                                        <asp:UpdatePanel id="updp_InfoInstitucion_alter" runat="server">
                                            <contenttemplate>
                                                <asp:ImageButton id="imgExpandirInfoInst_alter" runat="server" ImageUrl="~/images/aplicacion/expandir.gif" CausesValidation="False" CommandName="cmdMas" ></asp:ImageButton> 
                                                <asp:Label id="lblMasInfoInst_alter" runat="server" Text="Más..." ></asp:Label>
                                                <asp:UpdateProgress ID="UpdateProgress1_alter" runat="server" AssociatedUpdatePanelID="updp_InfoInstitucion_alter" DisplayAfter="100">
                                                    <ProgressTemplate>
                                                        <img src="images/aplicacion/relojAreana.gif" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                                <br />
                                                
                                                <asp:Panel id="pnlExpandirInfoInst_alter" runat="server" Visible="false" Width="100%">
                                                    <TABLE style="FONT-SIZE: 10px"><TBODY>
                                                        <TR>
                                                            <TH style="width: 90px">Domicilio:</TH>
                                                            <TD colSpan="3">
                                                                <asp:Label id="lb_Domicilio_alter" runat="server" Text='<%# Bind("Domicilio") %>' ></asp:Label><BR />
                                                                <asp:Label id="lb_Municipio_alter" runat="server" Text='<%# Bind("Municipio") %>' ></asp:Label>, 
                                                                <asp:Label id="lb_Estado_alter" runat="server" Text='<%# Bind("Estado") %>' ></asp:Label> 
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TH style="width: 90px">Telefono:</TH>
                                                            <TD><asp:Label id="lb_Telefono_alter" runat="server" text='<%#Bind("Telefono") %>'></asp:Label></TD>
                                                            <TH>Fax:</TH>
                                                            <TD><asp:Label id="lb_Fax_alter" runat="server" text='<%#Bind("Fax") %>'></asp:Label></TD>
                                                        </TR>
                                                        <TR>
                                                            <TH>CP:</TH>
                                                            <TD><asp:Label id="lb_CP_alter" runat="server" text='<%#Bind("CP") %>'></asp:Label></TD>
                                                            <TH style="width: 90px">Web:</TH>
                                                            <TD><asp:Label id="lb_Web_alter" runat="server" text='<%#Bind("Web") %>'></asp:Label></TD>
                                                        </TR>
                                                    </TBODY></TABLE>
                                                </asp:Panel> 
                                            </contenttemplate>
                                        </asp:UpdatePanel>
                                        
                                        
                                    </td>
                                </tr>
                            </table>
                        </AlternatingItemTemplate>
                        <EditItemTemplate>
                            <table border="0" class="tablaEditarTemplate" width="100%">
                                <tr>
                                    <td style="width:110px;" rowspan="8"></td>
                                    
                                    <th style="width: 110px" align="right">Clave: </th>
                                    <td align="left">
                                        <asp:Label ID="lb_CveInstitucion" runat="server" Text='<%#Bind("CveInstitucion") %>' Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lb_Error" runat="server" Text=""
                                            CssClass="mesajeError" Visible="false"></asp:Label>
                                    </td>
                                    
                                    <td style="width:200px;" rowspan="8" align="center">
                                        <asp:ImageButton ID="cmdGuardar" CommandName="UPDATE" runat="server" ImageUrl="images/aplicacion/btnGuardar.gif" />
                                        <br /><br /><br />
                                        <asp:ImageButton ID="cmdCancelar" CommandName="CANCEL" runat="server" ImageUrl="images/aplicacion/btnCancelar.gif" CausesValidation="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">Descripción:</th>
                                    <td align="left">
                                        <asp:TextBox ID="txt_DesInstitucion" runat="server" MaxLength="100" Columns="60" Text='<%#Bind("DesInstitucion") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator
                                            ID="rfv_DesInstitucion" runat="server" ControlToValidate="txt_DesInstitucion"
                                            ErrorMessage="La descripción de la institución es requerida"
                                            ToolTip="La descripción de la institución es requerida" CssClass="mesajeError" 
                                            ForeColor="black" >La descripción de la institución es requerida</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="rev_DesInstitucion" runat="server" ControlToValidate="txt_DesInstitucion"
                                            ToolTip="La descripción de la institución tiene caracteres no permitidos"
                                            ErrorMessage="La descripción de la institución tiene caracteres no permitidos" 
                                            ValidationExpression="[a-zA-Z.'ñÑÁáÉéÍíÓóÚúÜü,\p{P}\s\x22-]{1,100}$"  CssClass="mesajeError" 
                                            ForeColor="black">La descripción de la institución tiene caracteres no permitidos
                                            <a href="javascript:MostrarAyuda('Ayuda_DesInstitucion')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_DesInstitucion" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_DesInstitucion')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Minusculas -> (a-z)<br />
                                                    Mayusculas -> (A-Z)<br />
                                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                    Especiales ->&nbsp;&nbsp;  - ' . " , { }<br />
                                                    Máximo de caracteres -> 100<br />
                                                </td></tr>
                                            </table>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">Domicilio</th>
                                    <td align="left">
                                        <asp:TextBox ID="txt_Domicilio" runat="server" MaxLength="100" Columns="60" Text='<%#Bind("Domicilio") %>'></asp:TextBox>
                                        <asp:RegularExpressionValidator
                                            ID="rev_Domicilio" runat="server" ControlToValidate="txt_Domicilio"
                                            ToolTip="El domicilio tiene caracteres no permitidos"
                                            ErrorMessage="El domicilio tiene caracteres no permitidos" 
                                            ValidationExpression="[0-9a-zA-Z.'ñÑÁáÉéÍíÓóÚúÜü,\p{P}\s\x23-]{1,100}$"  CssClass="mesajeError" 
                                            ForeColor="black">El domicilio tiene caracteres no permitidos
                                            <a href="javascript:MostrarAyuda('Ayuda_Domicilio')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_Domicilio" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_Domicilio')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Minusculas -> (a-z)<br />
                                                    Mayusculas -> (A-Z)<br />
                                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                                    Especiales ->&nbsp;&nbsp;  - ' . # , { }<br />
                                                    Máximo de caracteres -> 100<br />
                                                </td></tr>
                                            </table>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left" style="padding:0px;">
                                        <asp:UpdatePanel id="updp_EdoMnpio" runat="server">
                                            <contenttemplate>
                                                <TABLE border="0"><TBODY>
                                                    <TR>
                                                        <TH align=right>Estado:</TH>
                                                        <TD align=left>
                                                        <%--entra el polo--%>                                                        
                                                            <%--<asp:DropDownList id="lst_CveEstado" runat="server" __designer:wfdid="w22" 
                                                                DataSourceID="odsCatEstado" 
                                                                DataTextField="DesEstado" 
                                                                DataValueField="CveEstadoInt" 
                                                                SelectedValue='<%#Bind("CveEstado") %>' autopostback="true">
                                                                </asp:DropDownList>--%>
                                                            <asp:DropDownList id="lst_CveEstado" runat="server" 
                                                                DataSourceID="odsCatEstado" 
                                                                DataTextField="DesEstado" 
                                                                DataValueField="CveEstadoInt" 
                                                                SelectedValue='<%# Bind("CveEstado") %>' autopostback="true" OnLoad="queNosAgarreConfesadosLVC">
                                                                </asp:DropDownList>
                                                                
                                                        <%--sale el polo--%>         
                                                            <asp:ObjectDataSource id="odsCatEstado" runat="server" __designer:wfdid="w23" 
                                                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                                                                    TypeName="dsAppTableAdapters.spEstadoDDL_nullTableAdapter">
                                                            </asp:ObjectDataSource> 
                                                        </TD>
                                                        <TH align=right>Municipio:</TH>
                                                        <TD align=left>
                                                            <asp:HiddenField id="hdd_CveMpio" runat="server" __designer:wfdid="w24" 
                                                                value='<% #Bind("CveMpio") %>'></asp:HiddenField> 
                                                            <asp:DropDownList id="lst_CveMpio" runat="server" __designer:wfdid="w25" 
                                                                DataTextField="DesMpio" DataValueField="CveMpio">
                                                            </asp:DropDownList>
                                                        </TD>
                                                    </TR>
                                                </TBODY></TABLE>
</contenttemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">Telefono:</th>
                                    <td align="left">
                                        <asp:TextBox ID="txt_Telefono" runat="server" Text='<% #Bind("telefono") %>' MaxLength="20" Columns="15"></asp:TextBox>
                                        <asp:RegularExpressionValidator
                                            ID="rev_Telefono" runat="server" ControlToValidate="txt_Telefono"
                                            ToolTip="El telefono tiene caracteres no permitidos"
                                            ErrorMessage="El telefono tiene caracteres no permitidos" 
                                            ValidationExpression="([0-9-\s\(\)]|(ext)|(ext.)){1,20}$"  CssClass="mesajeError" 
                                            ForeColor="black">El telefono tiene caracteres no permitidos
                                            <a href="javascript:MostrarAyuda('Ayuda_Telefono')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_Telefono" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_Telefono')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                                    Especiales ->&nbsp;&nbsp;  - ( )<br />
                                                    Abreviaturas ->&nbsp;&nbsp; ext &nbsp;&nbsp; ext.<br />
                                                    Máximo de caracteres -> 20<br />
                                                </td></tr>
                                            </table>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">Fax:</th>
                                    <td align="left">
                                        <asp:TextBox ID="txt_Fax" runat="server" Text='<% #Bind("Fax") %>' MaxLength="20" Columns="15"></asp:TextBox>
                                        <asp:RegularExpressionValidator
                                            ID="rev_Fax" runat="server" ControlToValidate="txt_Fax"
                                            ToolTip="El fax tiene caracteres no permitidos"
                                            ErrorMessage="El fax tiene caracteres no permitidos" 
                                            ValidationExpression="([0-9-\s\(\)]|(ext)|(ext.)){1,20}$"  CssClass="mesajeError" 
                                            ForeColor="black">El fax tiene caracteres no permitidos
                                            <a href="javascript:MostrarAyuda('Ayuda_Fax')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>
                                            
                                        <span id="Ayuda_Fax" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_Fax')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                                    Especiales ->&nbsp;&nbsp;  - ( )<br />
                                                    Abreviaturas ->&nbsp;&nbsp; ext &nbsp;&nbsp; ext.<br />
                                                    Máximo de caracteres -> 20<br />
                                                </td></tr>
                                            </table>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">CP:</th>
                                    <td align="left">
                                        <asp:TextBox ID="txt_CP" runat="server" Text='<% #Bind("CP") %>' MaxLength="10" Columns="6"></asp:TextBox>
                                        <%--<asp:RegularExpressionValidator
                                            ID="rev_Correo" runat="server" ControlToValidate="txt_Correo"
                                            ToolTip="No es una correo electronico válido"
                                            ErrorMessage="No es una correo electronico válido" 
                                            ValidationExpression="(^[\w.]{3,}@[\w./]{3,}\x2E[\w]{2,3})"  CssClass="mensajeFlotante" 
                                            ForeColor="black" BackColor="yellow" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Font-Size="X-Small"
                                            >No es una correo electronico válido</asp:RegularExpressionValidator>--%>
                                            <%--entra el polo--%>
                                        <%--<asp:RegularExpressionValidator
                                            ID="rev_CP" runat="server" ControlToValidate="txt_CP"
                                            ToolTip="No es un codigo postal válido"
                                            ErrorMessage="No es un codigo postal válido" 
                                            ValidationExpression="[0-9]{4,10}"  CssClass="mesajeError" 
                                            ForeColor="black">No es un codigo postal válido
                                            <a href="javascript:MostrarAyuda('Ayuda_CP')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                                            </asp:RegularExpressionValidator>--%>
                                            <%--sale el polo--%>
                                            
                                        <span id="Ayuda_CP" class="msgAyuda" style="visibility:hidden">
                                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                                <th><a href="javascript:MostrarAyuda('Ayuda_CP')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                                <td>
                                                    Caracteres permitidos:<br /><br />
                                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                                    Minimo de caracteres -> 4 <br />
                                                    Máximo de caracteres -> 10<br />
                                                </td></tr>
                                            </table>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">Web:</th>
                                    <td align="left">
                                        <asp:TextBox ID="txt_Web" runat="server" Text='<% #Bind("Web") %>' MaxLength="30" Columns="30"></asp:TextBox>
                                        <br />
                                        <asp:RegularExpressionValidator
                                            ID="rev_Web" runat="server" ControlToValidate="txt_Web"
                                            ToolTip="No es una página web válida"
                                            ErrorMessage="No es una página web válida" 
                                            ValidationExpression="(^(http(s)?://)|(www)\x2E[\w./]+\x2E[\w]{2,3}){1,30}$"  CssClass="mesajeError" 
                                            ForeColor="black">No es una página web válida
                                            </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                       </asp:TemplateField>
                   </Columns>     
                <PagerSettings FirstPageText="&amp;lt;&amp;lt; Primer P&#225;gina" 
                    LastPageText="Ultima P&#225;gina &amp;gt;&amp;gt;"
                    Mode="NextPrevious" NextPageText="Siguiente &amp;gt;" Position="TopAndBottom"
                    PreviousPageText="&amp;lt; Anterior" />
            </asp:GridView>
        
        </asp:View>
    
        <asp:View ID="viewNuevo" runat="server">
           
           <table border="0" class="tablaAlternatigTemplate" width="80%">
                <tr>
                    <th align="right">Descripción:</th>
                    <td align="left">
                        <asp:TextBox ID="txt_DesInstitucion" runat="server" MaxLength="100" Columns="60" Text=""></asp:TextBox>
                        <%--<asp:RequiredFieldValidator
                            ID="rfv_DesInstitucion" runat="server" ControlToValidate="txt_DesInstitucion"
                            ErrorMessage="La descripción de la institución es requerida"
                            ToolTip="La descripción de la institución es requerida" CssClass="mesajeError" " 
                            ForeColor="black">La descripción de la institución es requerida</asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator
                            ID="rev_DesInstitucion" runat="server" ControlToValidate="txt_DesInstitucion"
                            ToolTip="La descripción de la institución tiene caracteres no permitidos"
                            ErrorMessage="La descripción de la institución tiene caracteres no permitidos" 
                            ValidationExpression="[a-zA-Z.',ñÑÁáÉéÍíÓóÚúÜü\p{P}\s\x22-]{1,100}$"  CssClass="mesajeError"
                            ForeColor="black">La descripción de la institución tiene caracteres no permitidos
                            <a href="javascript:MostrarAyuda('Ayuda_DesInstitucion')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                            </asp:RegularExpressionValidator>
                            
                        <span id="Ayuda_DesInstitucion" class="msgAyuda" style="visibility:hidden">
                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                <th><a href="javascript:MostrarAyuda('Ayuda_DesInstitucion')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr>
                                <td>
                                    Caracteres permitidos:<br /><br />
                                    Minusculas -> (a-z)<br />
                                    Mayusculas -> (A-Z)<br />
                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                    Especiales ->&nbsp;&nbsp;  - ' . " , { }<br />
                                    Máximo de caracteres -> 100<br />
                                </td>
                            </table>
                        </span>
                    </td>
                </tr>
                <tr>
                    <th align="right">Domicilio</th>
                    <td align="left">
                        <asp:TextBox ID="txt_Domicilio" runat="server" MaxLength="100" Columns="60" Text=""></asp:TextBox>
                        <asp:RegularExpressionValidator
                            ID="rev_Domicilio" runat="server" ControlToValidate="txt_Domicilio"
                            ToolTip="El domicilio tiene caracteres no permitidos"
                            ErrorMessage="El domicilio tiene caracteres no permitidos" 
                            ValidationExpression="[0-9a-zA-Z.',ñÑÁáÉéÍíÓóÚúÜü\p{P}\s\x23-]{1,100}$"  CssClass="mesajeError" 
                            ForeColor="black">El domicilio tiene caracteres no permitidos
                            <a href="javascript:MostrarAyuda('Ayuda_Domicilio')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                            </asp:RegularExpressionValidator>
                            
                        <span id="Ayuda_Domicilio" class="msgAyuda" style="visibility:hidden">
                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                <th><a href="javascript:MostrarAyuda('Ayuda_Domicilio')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                <td>
                                    Caracteres permitidos:<br /><br />
                                    Minusculas -> (a-z)<br />
                                    Mayusculas -> (A-Z)<br />
                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                    Acentuados -> (ñ,Ñ,Á,á,É,é,Í,í,Ó,ó,Ú,ú,Ü,ü)<br />
                                    Especiales ->&nbsp;&nbsp;  - ' . # , { }<br />
                                    Máximo de caracteres -> 100<br />
                                </td></tr>
                            </table>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="left" style="padding:0px;">
                        <asp:UpdatePanel id="updp_EdoMnpio" runat="server">
                            <contenttemplate>
<TABLE border=0><TBODY><TR><TH align=right>Estado:</TH><TD align=left><asp:DropDownList id="lst_CveEstado_new" runat="server" autopostback="true" DataValueField="CveEstadoInt" DataTextField="DesEstado" DataSourceID="odsCatEstado_new">
                                            </asp:DropDownList> <asp:ObjectDataSource id="odsCatEstado_new" runat="server" TypeName="dsAppTableAdapters.spEstadoDDLTableAdapter" SelectMethod="GetData" OldValuesParameterFormatString="original_{0}">
                                            </asp:ObjectDataSource> </TD><TH align=right>Municipio:</TH><TD align=left><asp:DropDownList id="lst_CveMpio_new" runat="server" DataValueField="CveMpio" DataTextField="DesMpio" DataSourceID="odsCatMpio_new">
                                </asp:DropDownList> <asp:ObjectDataSource id="odsCatMpio_new" runat="server" TypeName="dsAppTableAdapters.spMunicipioDDLPorEstadoTableAdapter" SelectMethod="GetDataByCveEstado" OldValuesParameterFormatString="original_{0}" OnSelecting="odsCatMpio_new_Selecting">
                                        <SelectParameters>
                                                <asp:ControlParameter 
                                                    PropertyName="SelectedValue" 
                                                    Type="String" 
                                                    Name="CveEstado" 
                                                    ControlID="lst_CveEstado_new">
                                                </asp:ControlParameter>
                                        </SelectParameters>
                                </asp:ObjectDataSource></TD></TR></TBODY></TABLE>
</contenttemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <th align="right">Telefono:</th>
                    <td align="left">
                        <asp:TextBox ID="txt_Telefono" runat="server" Text="" MaxLength="20" Columns="15"></asp:TextBox>
                        <asp:RegularExpressionValidator
                            ID="rev_Telefono" runat="server" ControlToValidate="txt_Telefono"
                            ToolTip="El telefono tiene caracteres no permitidos"
                            ErrorMessage="El telefono tiene caracteres no permitidos" 
                            ValidationExpression="([0-9-\s]|(ext)|(ext.)){1,20}$"  CssClass="mesajeError" 
                            ForeColor="black">El telefono tiene caracteres no permitidos
                            <a href="javascript:MostrarAyuda('Ayuda_Telefono')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                            </asp:RegularExpressionValidator>
                            
                        <span id="Ayuda_Telefono" class="msgAyuda" style="visibility:hidden">
                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                <th><a href="javascript:MostrarAyuda('Ayuda_Telefono')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                <td>
                                    Caracteres permitidos:<br /><br />
                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                    Especiales ->&nbsp;&nbsp;  - <br />
                                    Abreviaturas ->&nbsp;&nbsp; ext &nbsp;&nbsp; ext.<br />
                                    Máximo de caracteres -> 20<br />
                                </td></tr>
                            </table>
                        </span>
                    </td>
                </tr>
                <tr>
                    <th align="right">Fax:</th>
                    <td align="left">
                        <asp:TextBox ID="txt_Fax" runat="server" Text="" MaxLength="20" Columns="15"></asp:TextBox>
                        <asp:RegularExpressionValidator
                            ID="rev_Fax" runat="server" ControlToValidate="txt_Fax"
                            ToolTip="El fax tiene caracteres no permitidos"
                            ErrorMessage="El fax tiene caracteres no permitidos" 
                            ValidationExpression="([0-9-\s]|(ext)|(ext.)){1,20}$"  CssClass="mesajeError" 
                            ForeColor="black">El fax tiene caracteres no permitidos
                            <a href="javascript:MostrarAyuda('Ayuda_Fax')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                            </asp:RegularExpressionValidator>
                            
                        <span id="Ayuda_Fax" class="msgAyuda" style="visibility:hidden">
                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                <th><a href="javascript:MostrarAyuda('Ayuda_Fax')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                <td>
                                    Caracteres permitidos:<br /><br />
                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                    Especiales ->&nbsp;&nbsp;  - <br />
                                    Abreviaturas ->&nbsp;&nbsp; ext &nbsp;&nbsp; ext.<br />
                                    Máximo de caracteres -> 20<br />
                                </td></tr>
                            </table>
                        </span>
                    </td>
                </tr>
                <tr>
                    <th align="right">CP:</th>
                    <td align="left">
                        <asp:TextBox ID="txt_CP" runat="server" Text="" MaxLength="10" Columns="6"></asp:TextBox>
                        <asp:RegularExpressionValidator
                            ID="rev_CP" runat="server" ControlToValidate="txt_CP"
                            ToolTip="No es un código postal válido"
                            ErrorMessage="No es un código postal válido" 
                            ValidationExpression="[0-9]{4,10}"  CssClass="mesajeError" 
                            ForeColor="black">No es un código postal válido
                            <a href="javascript:MostrarAyuda('Ayuda_CP')"><img src="images/aplicacion/btnAyuda.gif" alt="Ayuda" border="0" /></a>
                            </asp:RegularExpressionValidator>
                            
                        <span id="Ayuda_CP" class="msgAyuda" style="visibility:hidden">
                            <table border="0" cellpadding="0" cellspacing="0"><tr><th>&nbsp;Ayuda </th>
                                <th><a href="javascript:MostrarAyuda('Ayuda_CP')"><img src="images/aplicacion/btnCerrar.gif" alt="Cerrar" style="azimuth:right;" border="0" /></a></th></tr><tr>
                                <td>
                                    Caracteres permitidos:<br /><br />
                                    Números    -> (0,1,2,3,4,5,6,7,8,9)<br />
                                    Minimo de caracteres -> 4 <br />
                                    Máximo de caracteres -> 10<br />
                                </td></tr>
                            </table>
                        </span>
                    </td>
                </tr>
                <tr>
                    <th align="right">Web:</th>
                    <td align="left">
                        <asp:TextBox ID="txt_Web" runat="server" Text="" MaxLength="30" Columns="30"></asp:TextBox>
                        <asp:RegularExpressionValidator
                            ID="rev_Web" runat="server" ControlToValidate="txt_Web"
                            ToolTip="No es una página web válida"
                            ErrorMessage="No es una página web válida" 
                            ValidationExpression="(^(http(s)?://)|(www)\x2E[\w./]+\x2E[\w]{2,3}){1,30}$"  CssClass="mensajeFlotante" 
                            ForeColor="black" BackColor="yellow" BorderStyle="Dashed" BorderWidth="1px" Font-Italic="True" Font-Size="X-Small"
                            >No es una página web válida</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width="60%" border="0">
                            <tr>
                                <td align="center" style="width:50%">
                                    <asp:ImageButton ID="cmdGuardar" runat="server" ImageUrl="images/aplicacion/btnGuardar.gif" />
                                </td>
                                <td align="center" style="width:50%">    
                                    <asp:ImageButton ID="cmdCancelar" runat="server" ImageUrl="images/aplicacion/btnCancelar.gif" CausesValidation="False" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        
        </asp:View>
    </asp:MultiView>
            
    </center>

<br />
<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>


</asp:Content>

