﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="NovoPedidoCozinha.aspx.cs" Inherits="SistemaHotel.NovoPedidoCozinha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/bower_components/bootstrap/css/bootstrap.min.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/bower_components/sweetalert/css/sweetalert.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/assets/icon/themify-icons/themify-icons.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/assets/icon/icofont/css/icofont.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/assets/icon/feather/css/feather.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/assets/css/component.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/assets/css/jquery.mCustomScrollbar.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/assets/icon/icofont/css/icofont.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/assets/icon/font-awesome/css/font-awesome.min.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/layout/css/style.css") %>" />
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/bootstrap/js/bootstrap.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/datatables.net/js/jquery.dataTables.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/datatables.net-buttons/js/dataTables.buttons.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/assets/pages/data-table/js/jszip.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/assets/pages/data-table/js/pdfmake.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/assets/pages/data-table/js/vfs_fonts.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/assets/pages/data-table/extensions/key-table/js/dataTables.keyTable.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/datatables.net-buttons/js/buttons.print.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/datatables.net-buttons/js/buttons.html5.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/datatables.net-bs4/js/dataTables.bootstrap4.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/datatables.net-responsive/js/dataTables.responsive.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/bower_components/datatables.net-responsive-bs4/js/responsive.bootstrap4.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/assets/js/bootstrap-growl.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/assets/js/modalEffects.js") %>"></script>
    <!-- layout padrao  -->
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/plugins/bootstrap-notify/bootstrap-notify.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/layout/js/script.js") %>"></script>
    <link href="CSS/bootstrap.css" rel="stylesheet" />
    <link href="CSS/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <link href="CSS/jquery.dataTables.min.css.css" rel="stylesheet" />

    <script src="Scripts/jquery-3.5.1.js"></script>
    <script src="Scripts/jquery.dataTables.min.js"></script>
    <script src="Scripts/dataTables.bootstrap4.min.js.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                "language": {
                    "paginate": {
                        "previous": "Anterior:",
                        "next": "Próxima:",
                        "first": "Primeira:",
                        "last": "Última:",
                    },
                    "search": "Pesquisar:",

                },
                "scrollY": '500px',
                "scrollCollapse": true,
                "paging": true,
                "pageLength": 10,
                "ordering": false,
                "info": false,
                dom: 'Bfrtip',
                buttons: [

                ]



            });
        })
    </script>


    <style>
        .modal-dialog modal-lg {
            min-width: 90%;
            margin-left: 70px;
        }

            .modal-dialog modal-lg.modal-content {
                min-height: 50vh;
            }

        .modal-body {
            max-height: calc(120vh - 210px);
            overflow-y: auto;
            overflow-x: auto;
        }
    </style>


    <script src="Scripts/mascara.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="PnlPedido" runat="server" GroupingText="Pedido"></asp:Panel>
    <div class="row">
        <div class="col-sm">
            <span>&nbsp;</span>
        </div>
        <div class="col-sm">
            <span>&nbsp;</span>
        </div>
        <div class="col-sm">
            <span>&nbsp;</span>
        </div>
        <div class="col-sm">
            <asp:LinkButton ID="lnkCarrinho" class="btn btn-info btn-lg" OnClick="lnkCarrinho_Click" runat="server"><i class="fa fa-shopping-cart" aria-hidden="true"></i> Carrinho de Compras <asp:Label runat="server" ID="lblQtdeCarrinho" class="badge badge-danger"></asp:Label></asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-sm">
            <h3>Produtos Cozinha: </h3>
        </div>
    </div>
    <div class="col-12" align="center">
        <div id="Panel1" runat="server" visible="true">
        </div>
    </div>
    <div class="modal-backdrop fade show" id="mdBack" runat="server" style="opacity: 0.2; display: block; filter: (alpha(opacity= 20))" visible="false"></div>
    <div class="modal fade show" id="mdPed" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
        <div class="modal-dialog modal-lg" role="document">      
            <div class="modal-content" visible="false" style="border-radius: 10px;">
                <div class="modal-header">
                    <h5 class="modal-title">Novo Pedido:</h5>
                    <asp:LinkButton type="button" runat="server" class="close" data-dismiss="modal" OnClick="lnkVoltar_Click" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                    </asp:LinkButton>
                </div>
                <div class="modal-body">
                    <div class="container">
                        <div class="row">
                            <div class="col-sm">
                                <span>Id Produto: </span>
                            </div>
                            <div class="col-sm">
                                <asp:TextBox runat="server" ID="txtIdProd" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="col-sm">
                                <img id="imgProd" alt="" src="" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm">
                                <span>&nbsp;</span>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm">
                                <span>Nome: </span>
                            </div>
                            <div class="col-sm">
                                <asp:TextBox runat="server" ID="txtNomeProd" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm">
                                <span>&nbsp;</span>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm">
                                <span>Descricao: </span>
                            </div>
                            <div class="col-sm">
                                <asp:TextBox runat="server" ID="txtDescricao" Rows="5" Columns="40" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm">
                                <span>&nbsp;</span>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm">
                                <span>Preço: </span>
                            </div>
                            <div class="col-sm">
                                <asp:TextBox runat="server" ID="txtPreco" onkeyup="formataValor(this,event);" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm">
                                <span>&nbsp;</span>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm">
                                <span>Quantidade: </span>
                            </div>
                            <div class="col-sm">
                                <asp:TextBox ID="txtQuantidade" TextMode="Number" runat="server" min="0" max="20" step="1" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>&nbsp;</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton ID="LinkButton1" class="btn btn-info btn-lg" OnClick="lnkCarrinho_Click" runat="server"><i class="fa fa-shopping-cart" aria-hidden="true"></i> Ver Carrinho</asp:LinkButton>
                        <asp:LinkButton ID="lnkPedido" class="btn btn-success btn-lg" OnClick="lnkPedido_Click" runat="server"><i class="fa fa-shopping-cart" aria-hidden="true"></i> Adicionar ao Carrinho</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade show" id="mdCarr" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
        <div class="modal-dialog modal-lg" role="document">          
                <div class="modal-content" visible="false" style="border-radius: 10px;">
                    <div class="modal-header">
                        <h5 class="modal-title">Resumo Carrinho:</h5>
                        <asp:LinkButton type="button" runat="server" class="close" data-dismiss="modal" OnClick="lnkVoltar_Click" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                    </div>                   
                    <div class="modal-body">
                        <div class="col-12" align="center">
                            <div id="Panel2" runat="server" visible="true">
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-sm">
                                <span>&nbsp;</span>
                            </div>
                            <div class="col-sm">
                                <span>&nbsp;</span>
                            </div>
                            <div class="col-sm">
                                <span>&nbsp;</span>
                            </div>
                            <hr />
                            <div class="col-sm">
                                <span>Sub Total:<asp:Label ID="lblTotal" runat="server" autoPostback="true"></asp:Label></span>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton ID="lnkLimparCarrinho" class="btn btn-danger btn-lg" OnClick="lnkLimparCarrinho_Click" runat="server"><i class="fa fa-trash" aria-hidden="true"></i> Excluir Carrinho</asp:LinkButton><i class="bi bi-cart"></i>
                        <asp:LinkButton ID="lnkFechaPedido" class="btn btn-success" OnClick="lnkFechaPedido_Click" runat="server"><i class="fa fa-check" aria-hidden="true"></i> Fechar Pedido</asp:LinkButton>
                         
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
