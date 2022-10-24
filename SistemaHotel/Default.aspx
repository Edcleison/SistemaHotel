<%@ Page Title="Home" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaHotel.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery-3.5.1.js"></script>
    <script src="Scripts/jquery.dataTables.min.js"></script>
    <script src="Scripts/dataTables.buttons.min.js"></script>
    <script src="Scripts/jszip.min.js"></script>
    <script src="Scripts/pdfmake.min.js"></script>
    <script src="Scripts/vfs_fonts.js"></script>
    <script src="Scripts/buttons.html5.min.js"></script>
    <script src="Scripts/buttons.print.min.js"></script>

    <link href="CSS/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="CSS/buttons.dataTables.min.css" rel="stylesheet" />

    <script src="Scripts/a076d05399.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="PnlHome" Style="font-family: Calibri" runat="server">
        <h5 class="p-3 mb-2 bg-dark text-white">Página Inicial</h5>
        <hr />
            
        <div class="container-fluid">
            <div class="row justify-content-md-center">
                <div class="col-auto">
                        <div class="container">
                            <div class="jumbotron">
                                <div class="row">
                                    <div class="col-auto">
                                        <asp:Label ID="lbNomeUsuarioLegenda" Font-Bold="true" runat="server" Text="Bem Vindo:"></asp:Label>
                                    </div>
                                    <div class="col-auto">
                                        <asp:Label ID="lbNomeUsuario" runat="server" Font-Bold="true" Text="Nome do Usuário"></asp:Label>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-auto">
                                        <asp:Label ID="lbLoginLegenda" runat="server" Font-Bold="true" Text="Login:"></asp:Label>
                                    </div>
                                    <div class="col-auto">
                                        <asp:Label ID="lbLogin" runat="server" Font-Bold="true" Text="Login"></asp:Label>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-auto">
                                        <asp:Label ID="lbPerfilLegenda" runat="server" Font-Bold="true" Text="Perfil:"></asp:Label>
                                    </div>
                                    <div class="col-auto">
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
