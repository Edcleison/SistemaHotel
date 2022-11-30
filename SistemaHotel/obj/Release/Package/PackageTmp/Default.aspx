﻿<%@ Page Title="Home" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaHotel.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--    <link href="CSS/bootstrap.min.css" rel="stylesheet"  />--%>
    <%--    <script src="Scripts/bootstrap.min.js" ></script>--%>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>

    <link href="https://cdn.datatables.net/1.13.1/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/buttons/2.3.2/css/buttons.dataTables.min.css" rel="stylesheet" />

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.13.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.3.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.3.2/js/buttons.html5.min.js"></script>


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
                        <span>Total Gasto:<asp:Label ID="lblTotal" runat="server" autoPostback="true"></asp:Label></span>
                    </div>

                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
