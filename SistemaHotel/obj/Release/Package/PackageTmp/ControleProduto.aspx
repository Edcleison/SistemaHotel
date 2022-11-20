<%@ Page Title="Produtos" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="ControleProduto.aspx.cs" Inherits="SistemaHotel.ControleProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="https://cdn.datatables.net/1.13.1/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/buttons/2.3.2/css/buttons.dataTables.min.css" />

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.13.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.3.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.3.2/js/buttons.html5.min.js"></script>
    <%--<script src="Scripts/jquery-3.5.1.js"></script>
    <script src="Scripts/jquery.dataTables.min.js"></script>
    <script src="Scripts/dataTables.buttons.min.js"></script>
    <script src="Scripts/jszip.min.js"></script>
    <script src="Scripts/pdfmake.min.js"></script>
    <script src="Scripts/vfs_fonts.js"></script>
    <script src="Scripts/buttons.html5.min.js"></script>
    <script src="Scripts/buttons.print.min.js"></script>

    <link href="CSS/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="CSS/buttons.dataTables.min.css" rel="stylesheet" />--%>
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

    <style>
        .green {
            background-color: #90ee90 !important;
        }

        .red {
            background-color: #ffbdb9 !important;
        }

        #circulo_green {
            background: lightseagreen;
            border-radius: 50%;
            width: 100px;
            height: 100px;
        }

        #circulo_red {
            background: lightcoral;
            border-radius: 50%;
            width: 100px;
            height: 100px;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                "language": {
                    "emptyTable": "Não foram encontrados registros",

                    "paginate": {
                        "previous": "<",
                        "next": ">",
                        "first": "<<",
                        "last": ">>",
                    },
                    "search": "Pesquisar:",
                },
                //"scrollY": '500px',
                //"scrollCollapse": true,
                "paging": true,
                "pageLength": 10,
                "ordering": true,
                "info": false,
                dom: 'Bfrtip',
                buttons: ['excelHtml5', {
                    extend: 'pdfHtml5',
                    orientation: 'landscape',
                    pageSize: 'LEGAL'
                }

                ],
                "createdRow": function (row, data, dataIndex) {
                    if (data[5] == "<center>ATIVO</center>") {
                        $(row).addClass('green');

                    }
                    else if (data[5] == "<center>INATIVO</center>") {
                        $(row).addClass('red');

                    }
                },

            });
        })
    </script>


    <script src="Scripts/jquery-latest.min.js"></script>
    <script src="Scripts/autoNumeric.js"></script>
    <script>
        jQuery(function ($) {
            $('#ContentPlaceHolder1_txtPreco').autoNumeric({ aSep: '.', aDec: ',', vMax: '999999999.99' });
            $('#ContentPlaceHolder1_txtPrecoE').autoNumeric({ aSep: '.', aDec: ',', vMax: '999999999.99' });
        });
    </script>


    <style>
        .modal-personalizado {
            min-width: 95%;
            margin-left: 70px;
        }

            .modal-personalizado.modal-content {
                min-height: 50vh;
            }

        .modal-body {
            max-height: calc(120vh - 210px);
            overflow-y: auto;
            overflow-x: auto;
        }
    </style>



</asp:Content>


<asp:Content ID="Content12" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Panel ID="Panel3" runat="server" Style="font-family: Calibri">
        <h5 class="p-3 mb-2 bg-dark text-white">Controle de Produtos</h5>
        <hr />
        <div class="container">
            <div class="row">
                <div class="col-sm">
                    <asp:LinkButton ID="novoProduto" class="btn btn-dark" runat="server" OnClick="novoProduto_Click">Novo Produto</asp:LinkButton>
                </div>
            </div>
            <div class="row">
                <hr />
            </div>
            <div class="row">
                <div class="col-5">
                    <p>
                        <b>Tipo: </b>
                        <asp:DropDownList ID="ddlTipo" class="form-control" runat="server">
                        </asp:DropDownList>
                    </p>
                </div>

                <div class="col-5">
                    <p>
                        <b>Status:</b>
                        <asp:DropDownList ID="ddlStatus" class="form-control" runat="server">
                            <asp:ListItem Value="TODOS">TODOS</asp:ListItem>
                            <asp:ListItem Value="S">ATIVO</asp:ListItem>
                            <asp:ListItem Value="N">INATIVO</asp:ListItem>
                        </asp:DropDownList>
                    </p>
                </div>
                <div class="col-sm">
                    <asp:LinkButton ID="lnkPesquisar" class="btn btn-dark" OnClick="lnkPesquisar_Click" runat="server">Pesquisar</asp:LinkButton>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Legenda: </span>
                </div>
                <div class="col-4">
                    <div class="border border-dark" style="background-color: lightgrey">
                        <div class="row">
                            <div class="col-sm">
                                <span id="circulo_green" style="background-color: #90ee90">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span> Ativo</span>
                            </div>
                            <div class="col-sm">
                                <span id="circulo_red" style="background-color: #ffbdb9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span> Inativo</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <hr />

        </div>
        <div class="col-12" align="center">
            <div id="Panel1" runat="server" visible="true">
            </div>
        </div>
        <div class="modal-backdrop fade show" id="mdBack" runat="server" style="opacity: 0.2; display: block; filter: (alpha(opacity= 20))" visible="false"></div>
        <div class="modal fade show" id="mdProd" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
            <div class="modal-dialog modal-personalizado" role="document">
                <div class="modal-content" visible="false" style="border-radius: 10px;">
                    <div class="modal-header">
                        <h5 class="modal-title">Novo Produto:</h5>
                        <asp:LinkButton type="button" runat="server" class="close" data-dismiss="modal" OnClick="lnkVoltar_Click" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                    </div>
                    <div class="modal-body">
                        <div class="container">
                            <div class="jumbotron">
                                <div class="row">
                                    <div class="col-2">
                                        <span>Nome: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox runat="server" class="form-control" ID="txtNome"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-2">
                                        <span>Descrição: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox runat="server" ID="txtDescricao" class="form-control" Rows="5" Columns="40" TextMode="MultiLine"></asp:TextBox>
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
                                        <asp:TextBox runat="server" class="form-control" ID="txtPreco"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-2">
                                        <span>Tipo: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:DropDownList class="form-control" ID="ddlTipoProdS" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-2">
                                        <span>Foto: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:FileUpload ID="fuProduto" class="custom-file" runat="server" />
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
                            <asp:LinkButton ID="lnkSalvarProduto" class="btn btn-dark" OnClick="lnkSalvarProduto_Click" runat="server">Salvar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade show" id="mdProdE" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
            <div class="modal-dialog modal-personalizado" role="document">
                <div class="modal-content" visible="false" style="border-radius: 10px;">
                    <div class="modal-header">
                        <h5 class="modal-title">Editar Produto:</h5>
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
                                        <asp:TextBox runat="server" ID="txtIdProdutoE" class="form-control" Enabled="false"></asp:TextBox>
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
                                        <asp:TextBox runat="server" class="form-control" ID="txtNomeE"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-2">
                                        <span>Descrição: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox runat="server" ID="txtDescricaoE" class="form-control" Rows="5" Columns="40" TextMode="MultiLine"></asp:TextBox></td>
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
                                        <asp:TextBox runat="server" ID="txtPrecoE" class="form-control" onkeyup="formataValor(this,event);"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-2">
                                        <span>Tipo: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:DropDownList ID="ddlTipoProdE" class="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-2">
                                        <span>Foto: </span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-4">
                                        <asp:FileUpload ID="fuProdE" class="custom-file" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="lnkSalvarProdutoE" runat="server" class="btn btn-dark" OnClick="lnkSalvarProdutoE_Click">Alterar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

</asp:Content>
