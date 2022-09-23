<%@ Page Title="Home" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaHotel.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.2.3/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.2.3/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.2.3/js/buttons.print.min.js"></script>

    <link href="https://cdn.datatables.net/1.12.1/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/buttons/2.2.3/css/buttons.dataTables.min.css" rel="stylesheet" />

    <script src="Scripts/a076d05399.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="PnlHome" Style="font-family: Calibri" runat="server">
        <h5 class="p-3 mb-2 bg-dark text-white">Página Inicial</h5>
        <hr />

        <div class="container">
            <div class="row">
                <div class="col-sm">
                    <div class="border border-dark">
                        <div class="container">

                            <div class="row">
                                <div class="col-sm">
                                    <asp:Label ID="lbNomeUsuarioLegenda" Font-Bold="true" runat="server" Text="Bem Vindo!"></asp:Label>
                                </div>
                                <div class="col-sm">
                                    <asp:Label ID="lbNomeUsuario" runat="server" Font-Bold="true" Text="Nome do Usuário"></asp:Label>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-sm">
                                    <asp:Label ID="lbLoginLegenda" runat="server" Font-Bold="true" Text="Login:"></asp:Label>
                                </div>
                                <div class="col-sm">
                                    <asp:Label ID="lbLogin" runat="server" Font-Bold="true" Text="Login"></asp:Label>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-sm">
                                    <asp:Label ID="lbPerfilLegenda" runat="server" Font-Bold="true" Text="Perfil:"></asp:Label>
                                </div>
                                <div class="col-sm">
                                    <asp:Label ID="lbPerfil" runat="server" Font-Bold="true" Text="Perfil do Usuário"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
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
