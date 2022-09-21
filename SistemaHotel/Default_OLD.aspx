<%@ Page Title="Home" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="Default_OLD.aspx.cs" Inherits="SistemaHotel.Default_OLD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/a076d05399.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="PnlHome" Style="font-family: Calibri" runat="server">
        <h5 class="p-3 mb-2 bg-dark text-white">Página Inicial</h5>
        <hr />
        <div class="container">
            <div class="row">
                <div class="col-sm">
                    <br />
                    <asp:Label ID="lbNomeUsuarioLegenda" Font-Bold="true" runat="server" Text="Bem Vindo!"></asp:Label>
                    <asp:Label ID="lbNomeUsuario" runat="server" Font-Bold="true" Text="Nome do Usuário"></asp:Label>
                    <br />
                    <asp:Label ID="lbLoginLegenda" runat="server" Font-Bold="true" Text="Login:"></asp:Label>
                    <asp:Label ID="lbLogin" runat="server" Font-Bold="true" Text="Login"></asp:Label>
                    <br />
                    <asp:Label ID="lbPerfilLegenda" runat="server" Font-Bold="true" Text="Perfil:"></asp:Label>
                    <asp:Label ID="lbPerfil" runat="server" Font-Bold="true" Text="Perfil do Usuário"></asp:Label>
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
                        <asp:LinkButton ID="lnkConsumo" class="btn btn-dark" autoPostBack="true" OnClick="lnkConsumo_Click" runat="server"><i class="fas fa-wallet" aria-hidden="true"></i> Ver Consumo</asp:LinkButton>
                    </div>
                    <div class="col-sm">
                        <span>Sub Total:<asp:Label ID="lblTotal" runat="server" autoPostback="true"></asp:Label></span>
                    </div>

                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
