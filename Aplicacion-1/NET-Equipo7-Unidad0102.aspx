<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NET-Equipo7-Unidad0102.aspx.cs" Inherits="Aplicacion_1.NET_Equipo7_Unidad0102" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2> Formulario de Solicitante </h2><hr /><br />
        <form class="form-group mt-3 p-2">
            
            <asp:Label runat="server" class="control-label" Text="Nombre completo de solicitante:"></asp:Label><br />
            <asp:TextBox ID="txt_nombre" runat="server" class="form-control"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="Fecha de nacimiento:"></asp:Label><br />
            <asp:TextBox ID="txt_nacimiento" runat="server" CssClass="form-control"></asp:TextBox>
            <br /><br />

            <asp:Label runat="server" class="control-label" Text="Correo:"></asp:Label><br />
            <asp:TextBox ID="txt_correo" runat="server" class="form-control"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="Telefono:"></asp:Label><br />
            <asp:TextBox ID="txt_tel" runat="server" class="form-control"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="CURP:"></asp:Label><br />
            <asp:TextBox ID="txt_CURP" runat="server" class="form-control"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="RFC:"></asp:Label><br />
            <asp:TextBox ID="txt_RFC" runat="server" class="form-control"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="Fotografia:"></asp:Label><br />
            <asp:FileUpload ID="archivo" runat="server" /><br />

            <asp:Label runat="server" class="control-label" Text="Curriculum o otro doc:"></asp:Label><br />
            <asp:FileUpload ID="doc" runat="server" /><br />

            <asp:Button ID="btn_enviar" runat="server" CssClass="btn btn-success btn-block" Text="Enviar" OnClick="btn_enviar_Click" />
        </form>
    </div>
</asp:Content>


