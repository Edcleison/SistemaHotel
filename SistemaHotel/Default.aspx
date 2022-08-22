<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaHotel.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Perfil:"></asp:Label>
    <asp:Label ID="lbPerfil" runat="server" Text="Perfil do Usuário"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Login:"></asp:Label>
    <asp:Label ID="lbLogin" runat="server" Text="Login do Usuário"></asp:Label>
    <br />
</asp:Content>
