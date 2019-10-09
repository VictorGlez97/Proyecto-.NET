<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NET-Equipo7-Unidad0102-maildelsolicitante.aspx.cs" Inherits="Aplicacion_1.NET_Equipo7_Unidad0102_maildelsolicitante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid" id="contenedor">
        <h2> Formulario de contacto </h2><hr /><br />
        <form class="form-group mt-3 p-2">
            
            <asp:Label runat="server" class="control-label" Text="Nombre de solicitante:"></asp:Label><br />
            <asp:TextBox ID="txt_nombre" runat="server" class="form-control"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="Telefono:"></asp:Label><br />
            <asp:TextBox ID="txt_tel" runat="server" class="form-control"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="Vacante :"></asp:Label><br />
            <asp:TextBox ID="txt_vacante" runat="server" class="form-control"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="Correo:"></asp:Label><br />
            <asp:TextBox ID="txt_correo" runat="server" class="form-control"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="Mensaje:"></asp:Label><br />
            <asp:TextBox ID="txt_mensaje" runat="server" class="form-control" Height="125px" Rows="5"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="Agregar un adjunto:"></asp:Label><br />
            <asp:FileUpload ID="archivo" runat="server" class="btn btn-info"/><br />

            <asp:Button ID="btn_enviar" runat="server" CssClass="btn btn-success btn-block" Text="Enviar" OnClick="btn_enviar_Click" />
        </form>
    </div>
</asp:Content>
