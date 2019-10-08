<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NET-Equipo7-Unidad0102-ControlEscolar.aspx.cs" Inherits="Aplicacion_1.NET_Equipo7_Unidad0102_ControlEscolar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2> Control Escolar </h2><hr /><br />
        <form class="form-group mt-3 p-2">
            
            <asp:Label runat="server" class="control-label" Text="Numero de Control:"></asp:Label><br />
            <asp:TextBox ID="txt_ncontrol" runat="server" class="form-control"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="Nombre de Alumno:"></asp:Label><br />
            <asp:TextBox ID="txt_numalumno" runat="server" class="form-control"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="Carrera :"></asp:Label><br />
            <asp:TextBox ID="txt_carrera" runat="server" class="form-control"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="Semestre:"></asp:Label><br />
            <asp:TextBox ID="txt_semestre" runat="server" class="form-control"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="Correo Electronico:"></asp:Label><br />
            <asp:TextBox ID="txtcorreo" runat="server" class="form-control" Height="125px" Rows="5"></asp:TextBox><br /><br />

        </form>
    </div>
</asp:Content>

