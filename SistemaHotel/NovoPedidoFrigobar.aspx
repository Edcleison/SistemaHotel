﻿<%@ Page Title="Pedido - Frigobar" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="NovoPedidoFrigobar.aspx.cs" Inherits="SistemaHotel.NovoPedidoFrigobar" %>

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

    <script src="Scripts/jquery-3.3.1.slim.min.js"></script>
    <script>
        $(document).ready(function () {
            setTimeout(function () {
                $(".alert").fadeOut("slow", function () {
                    $(this).alert('close');
                });
            }, 5000);
        });
    </script>
    <script>
        $(document).ready(function () {
            $(".close").click(function () {
                $(".alert").hide();
            });
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                "language": {
                    "emptyTable": "Não foram encontrados registros",
                    "zeroRecords": "Não foram encontrados resultados",
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
    <asp:Panel ID="PnlPedido" runat="server" Style="font-family: Calibri"></asp:Panel>
    <h5 class="p-3 mb-2 bg-dark text-white">Pedido Frigobar</h5>
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
                        <div class="jumbotron">
                            <div class="row">
                                <div class="col-2">
                                    <span>Id Produto: </span>
                                </div>
                                <div class="col-4">
                                    <asp:TextBox runat="server" ID="txtIdProd" class="form-control" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-2">
                                    <img id="imgProd" alt="" class="rounded" src="" runat="server" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>&nbsp;</span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-2">
                                    <span>Nome: </span>
                                </div>
                                <div class="col-4">
                                    <asp:TextBox runat="server" ID="txtNomeProd" class="form-control" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>&nbsp;</span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-2">
                                    <span>Descricao: </span>
                                </div>
                                <div class="col-4">
                                    <asp:TextBox runat="server" ID="txtDescricao" class="form-control" Rows="5" Columns="40" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>&nbsp;</span>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-2">
                                    <span>Preço: </span>
                                </div>
                                <div class="col-4">
                                    <asp:TextBox runat="server" class="form-control" ID="txtPreco" onkeyup="formataValor(this,event);" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-6">
                                    <p style="font-size: 15px;">Seu desconto é de 
                                        <asp:Label ID="lblDesconto" runat="server"></asp:Label></p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>&nbsp;</span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-2">
                                    <span>Quantidade: </span>
                                </div>
                                <div class="col-4">
                                    <asp:TextBox ID="txtQuantidade" TextMode="Number" class="form-control" runat="server" min="0" max="20" step="1" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm">
                                    <span>&nbsp;</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton ID="lnkPedido" class="btn btn-dark" OnClick="lnkPedido_Click" runat="server"><i class="fa fa-check" aria-hidden="true"></i> Fechar Pedido</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
