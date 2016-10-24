<%@ Page Language="VB" MasterPageFile="~/mpProiectus.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" Culture="es-MX" Theme="skin"%>
<%@ OutputCache Duration="5" VaryByParam="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphCabecera" Runat="Server">
<style>
.cabecera{background-image:url(images/2014/header.png); width:1024px;        height:365px;        display:inline-block;}
    
.login
{
    background-image:url(images/2014/login.png);
    width:322px;
    height:249px;
    display:inline-block;
    position:relative;
}
    .tbUsuario 
{
    background: none repeat scroll 0 0 rgba(0, 0, 0, 0);
    border: none;
    left: 52px;
    line-height: 22px;
    position: absolute;
    top: 55px;
    width: 218px;
}
    
.tbPass 
{
    background: none repeat scroll 0 0 rgba(0, 0, 0, 0);
    border: none;
    left: 52px;
    line-height: 22px;
    position: absolute;
    top: 99px;
    width: 218px;
}

.col2
{
    color:#FFFFFF;
}

.pie > p { font-size:20px;} 

     
.validacion {position:absolute;  left: 50px;    top: 192px; }
.uEquis{ position:absolute; left: 284px; top: 59px; }
.pEquis{ position:absolute; left: 284px; top: 103px; }
   
div.botonIngresa  
{
    position: absolute; left: 93px;  top: 150px; 
    width: 124px;
    background-repeat: no-repeat;
    background-position: center center;
}

div.botonIngresa > input.boton{ left:2px;}

.olvido{ bottom: 95px;    left: 65px;    position: absolute; }
.ayuda{ bottom: 95px;    position: absolute;    right: 59px;}
.btIngresar{ background: none repeat scroll 0 0 rgba(0, 0, 0, 0);    bottom: 50px;    left: 112px;    position: absolute;    width: 117px;}
</style>
</asp:Content>


<asp:Content ID="cntDefault" ContentPlaceHolderID="cphPrincipal" Runat="Server">


    <div class="row">

<div class="col1">
    <h2> Sistema de Control y Seguimiento de Proyectos de Desarrollo,
     Transferencia de Tecnología e Investigación</h2>


     <h3>Sistema de control y seguimientos de proyectos </h3>
     <p>El SCS constituye una herramienta de ayuda para el manejo y gestión integral de la información relacionada 
     con los proyectos de Investigación y desarrollo Tecnológico.</p>
    <h3>Entre sus alcances se encuentra:</h3>

    <ul>
    <li>Inventario de proyectos</li>
    <li>Seguimiento administrativo</li>
    <li>Seguimiento técnico</li>
    <li>Reportes y estadísticas</li>
    <li>Productos</li>
    </ul>

</div>

<div class="col2">
    <div class="login">

    <asp:TextBox ID="txtUsuario" runat="server" MaxLength="15" TabIndex="1" CssClass="tbUsuario"></asp:TextBox>
    
    <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="Usuario es requerido" ToolTip="Usuario es requerido" CssClass="uEquis">x</asp:RequiredFieldValidator>
        <asp:CustomValidator ID="cvUsuario" runat="server" ControlToValidate="txtUsuario"
                                ErrorMessage="Usuario no válido" ToolTip="Usuario no válido">x</asp:CustomValidator>

   <asp:TextBox ID="txtContrasenia" runat="server" MaxLength="20" TextMode="Password" TabIndex="2" CssClass="tbPass"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvContrasenia" runat="server" ControlToValidate="txtContrasenia"
                ErrorMessage="Contraseña es requerida" ToolTip="Contraseña es requerida" CssClass="pEquis">x</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="cvContrasenia" runat="server" ControlToValidate="txtContrasenia"
                ErrorMessage="Contraseña no válida" ToolTip="Contraseña no válida">x</asp:CustomValidator>

    <asp:ValidationSummary ID="vsInicioSesion" runat="server" CssClass="validacion" />
    <asp:HyperLink ID="hlnkReiniciarContra" runat="server" CssClass="olvido" NavigateUrl="~/Reiniciarcontra.aspx" >¿Olvidó su contraseña?</asp:HyperLink>&nbsp;
    <asp:HyperLink ID="hlnkAyuda" runat="server"  CssClass="ayuda" NavigateUrl="~/ayuda/ayuda.aspx" Target="_blank">Ayuda</asp:HyperLink>


        
   
                    
        <div class="boton_container botonIngresa">
            <asp:Button ID="ibtnIngresar" CssClass="boton" Text="Ingresar"  runat="server" PostBackUrl="~/Default.aspx" />
        </div>
    </div>

    <div class="conacyt">
        <a href="http://www.conacyt.mx/index.php/fondos-y-apoyos/fondos-sectoriales" target="_blank">
            <img src="images/2014/conacyt.png" alt="Información sobre lineamientos del fondo sectorial CONACYT-CONAFOR" border="0"/>
        </a>
    </div>

</div>

</div>

 
</asp:Content>

