<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaHotel.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="lbNomeUsuarioLegenda" runat="server" Text="Nome:" ></asp:Label>
    <asp:Label ID="lbNomeUsuario" runat="server" Text="Nome do Usuário" ></asp:Label>
    <br />
    <asp:Label ID="lbLogin" runat="server" Text="Login:"></asp:Label>
    <asp:Label ID="lbCodigoReserva" runat="server" Text="Login" ></asp:Label>
    <br />
    <asp:Label ID="lbPerfilLegenda" runat="server" Text="Perfil:"></asp:Label>
    <asp:Label ID="lbPerfil" runat="server" Text="Perfil do Usuário"></asp:Label>
    
    <br />
</asp:Content>
