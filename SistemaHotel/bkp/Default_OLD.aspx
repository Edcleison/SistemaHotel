<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Nome:"></asp:Label>
    <asp:Label ID="lbNome" runat="server" Text="Nome do Usuário"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
    <asp:Label ID="lbEmail" runat="server" Text="Email do Usuário"></asp:Label>
    <br />
</asp:Content>
