<%@ Page Title="Pedido - Cozinha" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="NovoPedidoCozinha.aspx.cs" Inherits="SistemaHotel.NovoPedidoCozinha" %>

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

    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                "emptyTable": "Não foram encontrados registros",
                "language": {
                    "paginate": {
                        "previous": "<",
                        "next": ">",
                        "first": "<<",
                        "last": ">>",
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

    <script type="text/javascript">
        $(document).ready(function () {
            $('#exampleCarr').DataTable({
                "emptyTable": "Não foram encontrados registros",
                "language": {
                    "paginate": {
                        "previous": "<",
                        "next": ">",
                        "first": "<<",
                        "last": ">>",
                    },
                    "search": "Pesquisar:",

                },
                "scrollY": '150px',
                "scrollCollapse": true,
                "paging": true,
                "pageLength": 10,
                "ordering": true,
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
    <asp:Panel ID="PnlPedido" runat="server" Style="font-family: Calibri" ></asp:Panel>
      <h5 class="p-3 mb-2 bg-dark text-white">Pedido Cozinha</h5>
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
        <div class="col-sm">
            <asp:LinkButton ID="lnkCarrinho" class="btn btn-dark" OnClick="lnkCarrinho_Click" runat="server"><i class="fa fa-shopping-cart" aria-hidden="true"></i> Carrinho de Compras <asp:Label runat="server" ID="lblQtdeCarrinho" class="badge badge-danger"></asp:Label></asp:LinkButton>
        </div>
    </div>
    <hr />
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
                        <asp:LinkButton ID="LinkButton1" class="btn btn-dark" OnClick="lnkCarrinho_Click" runat="server"><i class="fa fa-shopping-cart" aria-hidden="true"></i> Ver Carrinho</asp:LinkButton>
                        <asp:LinkButton ID="lnkPedido" class="btn btn-dark" OnClick="lnkPedido_Click" runat="server"><i class="fa fa-shopping-cart" aria-hidden="true"></i> Adicionar ao Carrinho</asp:LinkButton>
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
                        <asp:LinkButton ID="lnkLimparCarrinho" class="btn btn-dark" OnClick="lnkLimparCarrinho_Click" runat="server"><i class="fa fa-trash" aria-hidden="true"></i> Excluir Carrinho</asp:LinkButton><i class="bi bi-cart"></i>
                        <asp:LinkButton ID="lnkFechaPedido" class="btn btn-dark" OnClick="lnkFechaPedido_Click" runat="server"><i class="fa fa-check" aria-hidden="true"></i> Fechar Pedido</asp:LinkButton>
                         
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
