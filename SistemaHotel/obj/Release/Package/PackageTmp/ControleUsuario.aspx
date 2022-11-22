<%@ Page Title="Controle - Usuários" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="ControleUsuario.aspx.cs" Inherits="SistemaHotel.ControleUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="https://cdn.datatables.net/1.13.1/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/buttons/2.3.2/css/buttons.dataTables.min.css" rel="stylesheet" />

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.13.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/2.3.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
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
            $('#tabelaUsuarios').DataTable({
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
                buttons: ['excelHtml5', {
                    extend: 'pdfHtml5',
                    orientation: 'landscape',
                    pageSize: 'LEGAL'
                }

                ],
                "createdRow": function (row, data, dataIndex) {
                    if (data[3] == "<center>ATIVO</center>") {
                        $(row).addClass('green');

                    }
                    else if (data[3] == "<center>INATIVO</center>") {
                        $(row).addClass('red');

                    }
                },

            });
        })
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#tabelaClientes').DataTable({
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
                "scrollY": '500px',
                "scrollCollapse": true,
                "paging": true,
                "pageLength": 10,
                "ordering": true,
                "info": false,
                dom: 'Bfrtip',
                buttons: ['excel', 'pdf',

                ],
                "createdRow": function (row, data, dataIndex) {
                    if (data[6] == "<center>ATIVO</center>") {
                        $(row).addClass('green');

                    }
                    else if (data[6] == "<center>INATIVO</center>") {
                        $(row).addClass('red');

                    }
                },

            });
        })
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

    <script src="Scripts/jquery.mask.js"></script>
    <script>
        $(document).ready(function () {
            $("#ContentPlaceHolder1_txtInputDataIni").mask("99/99/9999 00:00");
            $("#ContentPlaceHolder1_txtInputDataFim").mask("99/99/9999 00:00");
            $("#ContentPlaceHolder1_txtInputDataFimE").mask("99/99/9999 00:00");
        });
    </script>

</asp:Content>

<asp:Content ID="Content12" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Panel ID="Panel3" runat="server" Style="font-family: Calibri">
        <h5 class="p-3 mb-2 bg-dark text-white">Controle de Usuários</h5>
        <hr />
        <div class="container">
            <div class="row">
                <div class="col-sm">
                    <asp:LinkButton ID="novoUsuario" class="btn btn-dark" runat="server" OnClick="novoUsuario_Click">Novo Membro</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" class="btn btn-dark" runat="server" OnClick="novoCliente_Click">Novo Cliente</asp:LinkButton>
                </div>
            </div>
            <div class="row">
                <div class="col-sm">
                    <span>&nbsp;</span>
                </div>
            </div>
            <div class="row">
                <div class="col-sm">
                    <span>Perfil: </span>
                    <asp:DropDownList ID="ddlPerfil" class="form-control" runat="server"></asp:DropDownList>
                    <div class="row">
                    </div>
                </div>
                <div class="col-sm">
                    <span>Status: </span>
                    <asp:DropDownList ID="ddlStatus" class="form-control" runat="server">
                        <asp:ListItem Value="TODOS">TODOS</asp:ListItem>
                        <asp:ListItem Value="S">ATIVO</asp:ListItem>
                        <asp:ListItem Value="N">INATIVO</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm">
                    <asp:LinkButton ID="lnkPesquisar" class="btn btn-dark" OnClick="lnkPesquisar_Click" runat="server">Pesquisar</asp:LinkButton>
                </div>
            </div>
            <hr />
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
        </div>
        <hr />

        <div class="col-12" align="center">
            <div id="Panel1" runat="server" visible="true">
            </div>
        </div>
        <div class="modal-backdrop fade show" id="mdBack" runat="server" style="opacity: 0.2; display: block; filter: (alpha(opacity= 20))" visible="false"></div>
        <div class="modal fade show" id="mdUsu" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
            <div class="modal-dialog modal-personalizado" role="document">
                <div class="modal-content" visible="false" style="border-radius: 10px;">
                    <div class="modal-header">
                        <h5 class="modal-title">Novo Membro:</h5>
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
                                        <span>Sobrenome: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox runat="server" class="form-control" ID="txtSobreNome"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-2">
                                        <span>Digite o Login: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox runat="server" class="form-control" ID="txtLogin"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-2">
                                        <span>Perfil: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:DropDownList ID="ddlPerfilNovoUsu" class="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-2">
                                        <span>Digite a Senha: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox type="password" class="form-control" runat="server" ID="txtNovaSenha"> 
                                        </asp:TextBox>
                                        <p>*Senha mínimo 8 caracteres</p>
                                    </div>
                                    <div class="col-2">
                                        <%--                                        <img id="olhoNovoUsu" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABDUlEQVQ4jd2SvW3DMBBGbwQVKlyo4BGC4FKFS4+TATKCNxAggkeoSpHSRQbwAB7AA7hQoUKFLH6E2qQQHfgHdpo0yQHX8T3exyPR/ytlQ8kOhgV7FvSx9+xglA3lM3DBgh0LPn/onbJhcQ0bv2SHlgVgQa/suFHVkCg7bm5gzB2OyvjlDFdDcoa19etZMN8Qp7oUDPEM2KFV1ZAQO2zPMBERO7Ra4JQNpRa4K4FDS0R0IdneCbQLb4/zh/c7QdH4NL40tPXrovFpjHQr6PJ6yr5hQV80PiUiIm1OKxZ0LICS8TWvpyyOf2DBQQtcXk8Zi3+JcKfNafVsjZ0WfGgJlZZQxZjdwzX+ykf6u/UF0Fwo5Apfcq8AAAAASUVORK5CYII=" />--%>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-2">
                                        <span>Confirme a senha: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox type="password" class="form-control" runat="server" ID="txtConfirmaSenha"> </asp:TextBox>
                                    </div>
                                    <div class="col-2">
                                        <%--                                        <img id="olhoConfirmaNovoUsu" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABDUlEQVQ4jd2SvW3DMBBGbwQVKlyo4BGC4FKFS4+TATKCNxAggkeoSpHSRQbwAB7AA7hQoUKFLH6E2qQQHfgHdpo0yQHX8T3exyPR/ytlQ8kOhgV7FvSx9+xglA3lM3DBgh0LPn/onbJhcQ0bv2SHlgVgQa/suFHVkCg7bm5gzB2OyvjlDFdDcoa19etZMN8Qp7oUDPEM2KFV1ZAQO2zPMBERO7Ra4JQNpRa4K4FDS0R0IdneCbQLb4/zh/c7QdH4NL40tPXrovFpjHQr6PJ6yr5hQV80PiUiIm1OKxZ0LICS8TWvpyyOf2DBQQtcXk8Zi3+JcKfNafVsjZ0WfGgJlZZQxZjdwzX+ykf6u/UF0Fwo5Apfcq8AAAAASUVORK5CYII=" />--%>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="modal-footer">
                            <asp:LinkButton ID="lnkSenha" class="btn btn-dark" OnClick="lnkSenha_Click" runat="server">Salvar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <script src="Scripts/jquery.min.js"></script>
            <script type="text/javascript">
                var senha = $('#ContentPlaceHolder1_txtNovaSenha');
                var olhoNovoUsu = $("#olhoNovoUsu");
                olhoNovoUsu.mousedown(function () {
                    senha.attr("type", "text");
                });

                olhoNovoUsu.mouseup(function () {
                    senha.attr("type", "password");

                });

                $("#olhoNovoUsu").mouseout(function () {
                    $("#ContentPlaceHolder1_txtNovaSenha").attr("type", "password");
                });
            </script>
            <script type="text/javascript">
                var ConfirmaSenha = $('#ContentPlaceHolder1_txtConfirmaSenha');
                var olhoConfirmaNovoUsu = $("#olhoConfirmaNovoUsu");

                olhoConfirmaNovoUsu.mousedown(function () {
                    ConfirmaSenha.attr("type", "text");
                });

                olhoConfirmaNovoUsu.mouseup(function () {
                    ConfirmaSenha.attr("type", "password");
                });
                $("#olhoConfirmaNovoUsu").mouseout(function () {
                    $("#ContentPlaceHolder1_txtConfimaSenha").attr("type", "password");
                });
            </script>
        </div>
        <div class="modal fade show" id="mdUsuE" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
            <div class="modal-dialog modal-personalizado" role="document">
                <div class="modal-content" visible="false" style="border-radius: 10px;">
                    <div class="modal-header">
                        <h5 class="modal-title">Editar Usuário:</h5>
                        <asp:LinkButton type="button" runat="server" class="close" data-dismiss="modal" OnClick="lnkVoltar_Click" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                    </div>
                    <div class="modal-body">
                        <div class="container">
                            <div class="jumbotron">
                                <div class="row">
                                    <div class="col-2">
                                        <span>Id: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox runat="server" ID="txtIdUsuarioE" class="form-control" Enabled="false"></asp:TextBox>
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
                                        <span>Sobrenome: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox runat="server" class="form-control" ID="txtSobrenomeE"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-2">
                                        <span>Digite o Login: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox runat="server" class="form-control" ID="txtLoginE"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-2">
                                        <span>Perfil: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:DropDownList ID="ddlPerfilUsuE" class="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="lnkAlterarUsuario" class="btn btn-dark" OnClick="lnkAlterarUsuario_Click" runat="server">Salvar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade show" id="mdCli" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
            <div class="modal-dialog modal-personalizado" role="document">
                <div class="modal-content" visible="false" style="border-radius: 10px;">
                    <div class="modal-header">
                        <h5 class="modal-title">Novo Cliente</h5>
                        <asp:LinkButton type="button" runat="server" class="close" data-dismiss="modal" OnClick="lnkVoltar_Click" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                    </div>
                    <div class="modal-body">
                        <div class="container">
                            <div class="jumbotron">
                                <div class="row">
                                    <div class="col-4">
                                        <span>Cód. Reserva: </span>
                                        <asp:TextBox runat="server" class="form-control" ID="txtCodReserva"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <span>Quarto: </span>
                                        <asp:DropDownList ID="ddlQuarto" class="form-control" runat="server"></asp:DropDownList>
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
                                        <asp:TextBox runat="server" class="form-control" ID="txtNomeCliente"></asp:TextBox>
                                    </div>
                                    <div class="col-2">
                                        <span>Sobrenome: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox runat="server" class="form-control" ID="txtSobrenomeCliente"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-2">
                                        <span>Check-In:</span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox ID="txtInputDataIni" class="form-control" runat="server"></asp:TextBox>

                                    </div>
                                    <div class="col-2">
                                        <span>Check-Out:</span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox ID="txtInputDataFim" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-4">
                                        <span>Senha Gerada:</span>
                                        <asp:TextBox ID="txtSenhaRand" class="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-4">
                                        <span>Período de: </span>
                                        <asp:TextBox ID="txtDataIni" class="form-control" ForeColor="red" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <span>Até: </span>
                                        <asp:TextBox ID="txtDataFim" class="form-control" ForeColor="red" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="modal-footer">
                            <asp:LinkButton ID="salvarNovoCliente" class="btn btn-dark" runat="server" OnClick="salvarNovoCliente_Click">Novo Cliente</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade show" id="modEditCli" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content" visible="false" style="border-radius: 10px;">
                    <div class="modal-header">
                        <h5 class="modal-title">Editar Data de Check-Out</h5>
                        <asp:LinkButton type="button" runat="server" class="close" data-dismiss="modal" OnClick="lnkVoltar_Click" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </asp:LinkButton>
                    </div>
                    <div class="modal-body">
                        <div class="container">
                            <div class="jumbotron">
                                <div class="row">
                                    <div class="col-2">
                                        Código da Reserva: 
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox runat="server" ID="txtCdReservaE" class="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-2">
                                        <span>Quarto: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:DropDownList ID="ddlQuartoE" class="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-2">
                                        <span>Nome Cliente: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox runat="server" ID="txtNomeClienteE" class="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-2">
                                        <span>Nova Data de Check-Out:</span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox ID="txtInputDataFimE" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-2">
                                        <span>Período de: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox ID="txtDataIniE" class="form-control" ForeColor="red" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-2">
                                        <span>Até: </span>
                                    </div>
                                    <div class="col-4">
                                        <asp:TextBox ID="txtDataFimE" class="form-control" ForeColor="red" runat="server" Enabled="false"></asp:TextBox>
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
                            <asp:LinkButton ID="alterarData" class="btn btn-dark" runat="server" OnClick="alterarData_Click">Salvar Alterações</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

