<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaHotel.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/a076d05399.js"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm">
                <br />
                <asp:Label ID="lbNomeUsuarioLegenda" runat="server" Text="Bem Vindo!"></asp:Label>
                <asp:Label ID="lbNomeUsuario" runat="server" Text="Nome do Usuário"></asp:Label>
                <br />
                <asp:Label ID="lbLoginLegenda" runat="server" Text="Login:"></asp:Label>
                <asp:Label ID="lbLogin" runat="server" Text="Login"></asp:Label>
                <br />
                <asp:Label ID="lbPerfilLegenda" runat="server" Text="Perfil:"></asp:Label>
                <asp:Label ID="lbPerfil" runat="server" Text="Perfil do Usuário"></asp:Label>
                <br />
            </div>
            <div class="col-sm">
                <span>&nbsp;</span>
            </div>
            <div class="col-sm">
                <span>&nbsp;</span>
            </div>    
            <div id="divTotal" runat="server" class="col-sm" visible="false">
                 <div class="col-sm">
                    <asp:LinkButton ID="lnkConsumo" class="btn btn-info btn-lg" autoPostBack="true" OnClick="lnkConsumo_Click"  runat="server"><i class="fas fa-wallet" aria-hidden="true"></i> Ver Consumo</asp:LinkButton>
                </div>
                <div class="col-sm">
                    <span>Sub Total:<asp:Label ID="lblTotal" runat="server" autoPostback="true"></asp:Label></span>
                </div>
               
    </div>
    </div>
    </div>
</asp:Content>
