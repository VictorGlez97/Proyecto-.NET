<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NET-Equipo7-Unidad0102-ControlEscolar.aspx.cs" Inherits="Aplicacion_1.NET_Equipo7_Unidad0102_ControlEscolar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid" id="contenedor">
        <h2> Control Escolar </h2><hr /><br />
        <form class="form-group mt-3 p-2">
            
            <asp:Label runat="server" class="control-label" Text="Numero de Control:"></asp:Label><br />
            <asp:TextBox ID="txt_ncontrol" runat="server"  class="form-control" OnTextChanged="control" AutoPostBack="true"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="Nombre de Alumno:"></asp:Label><br />
            <asp:TextBox ID="txt_numalumno" runat="server" class="form-control"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="Carrera :"></asp:Label><br />
           
            <div class="col-4">
                <asp:DropDownList ID="CmbCarreras" runat="server" CssClass="custom-select-lg">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>ELECTRONICA</asp:ListItem>
                    <asp:ListItem>ELECTRICA</asp:ListItem>
                    <asp:ListItem>INDUSTRIAL</asp:ListItem>
                    <asp:ListItem>MECANICA</asp:ListItem>
                    <asp:ListItem>MECATRONICA</asp:ListItem>
                    <asp:ListItem>SISTEMAS COMPUTACIONALES</asp:ListItem>
                </asp:DropDownList>
            </div><br /><br />

            <asp:Label runat="server" class="control-label" Text="Semestre:"></asp:Label><br />
            <asp:TextBox ID="txt_semestre" runat="server" class="form-control"></asp:TextBox><br /><br />

            <asp:Label runat="server" class="control-label" Text="Correo Electronico:"></asp:Label><br />
            <asp:TextBox ID="txt_correo" runat="server" class="form-control" OnTextChanged="correo" AutoPostBack="true"> </asp:TextBox><br /><br />
             <div class="row">
            <div class="col-4 col-sm-4">
                <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Guardar Alumno" CssClass="btn-primary" />
            </div>
                </div>
             <div class="row">
            <asp:GridView ID="GrdAlumnos" runat="server"  AutoGenerateColumns="False" BackColor="White" 
                BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                GridLines="Vertical" Width="430px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="CONTROL" HeaderText="CONTROL" />
                    <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                    <asp:BoundField DataField="CARRERA" HeaderText="CARRERA" />
                    <asp:BoundField DataField="SEMESTRE" HeaderText="SEMESTRE" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
                 </div>
        </form>
    </div>
</asp:Content>

