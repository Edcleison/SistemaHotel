<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaHotel.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="lbNomeUsuarioLegenda" runat="server" Text="Login:" Visible="false"></asp:Label>
    <asp:Label ID="lbNomeUsuario" runat="server" Text="Nome do Usuário" Visible="false"></asp:Label>
    <br />
    <asp:Label ID="lbPerfilLegenda" runat="server" Text="Perfil:"></asp:Label>
    <asp:Label ID="lbPerfil" runat="server" Text="Perfil do Usuário"></asp:Label>
    <br />
    <asp:Label ID="lbCodigoReservaLegenda" runat="server" Text="Código da Reserva:" Visible="false"></asp:Label>
    <asp:Label ID="lbCodigoReserva" runat="server" Text="Código da Reserva" Visible="false"></asp:Label>
    <br />
</asp:Content>
