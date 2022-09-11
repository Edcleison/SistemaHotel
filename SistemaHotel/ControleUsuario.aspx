<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="ControleUsuario.aspx.cs" Inherits="SistemaHotel.ControleUsuario" %>

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
    <link href="CSS/jquery.dataTables.min.css" rel="stylesheet" />

    <script src="Scripts/jquery-3.5.1.js"></script>
    <script src="Scripts/jquery.dataTables.min.js"></script>
    <script src="Scripts/dataTables.bootstrap4.min.js.js"></script>

    <style>
        .green {
            background-color: lightseagreen !important;
        }

        .red {
            background-color: lightcoral !important;
        }
    </style>



    <script type="text/javascript">
        $(document).ready(function () {
            $('#tabelaUsuarios').DataTable({
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
                "ordering": false,
                "info": false,
                dom: 'Bfrtip',
                buttons: ['excel'

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
                "ordering": false,
                "info": false,
                dom: 'Bfrtip',
                buttons: ['excel'

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

    <%--<script src="Scripts/mascara.js"></script>--%>
</asp:Content>

<asp:Content ID="Content12" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Panel ID="Panel3" runat="server" GroupingText="Controle de Usuários">

        <div class="container">
            <div class="row">
                <div class="col-sm">
                    <asp:LinkButton ID="novoUsuario" class="btn btn-primary" runat="server" OnClick="novoUsuario_Click">Novo Usuário</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" class="btn btn-primary" runat="server" OnClick="novoCliente_Click">Novo Cliente</asp:LinkButton>
                </div>
            </div>
            <div class="row">
                <div class="col-sm">
                    <span>&nbsp;</span>
                </div>
            </div>
            <div class="row">
                <div class="col-sm">
                    <span>Listar Por: </span>
                </div>
                <div class="col-sm">
                    <asp:DropDownList ID="ddlPerfil" runat="server"></asp:DropDownList>
                </div>
                <div class="col-sm">
                    <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                        <asp:ListItem Value="SELECIONE">SELECIONE</asp:ListItem>
                        <asp:ListItem Value="S">ATIVO</asp:ListItem>
                        <asp:ListItem Value="N">INATIVO</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-sm">
                    <span>&nbsp;</span>
                </div>
            </div>


            <div class="col-12" align="center">
                <div id="Panel1" runat="server" visible="true">
                </div>
            </div>
            <div class="modal-backdrop fade show" id="mdBack" runat="server" style="opacity: 0.2; display: block; filter: (alpha(opacity= 20))" visible="false"></div>
            <div class="modal fade show" id="mdUsu" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
                <%--<div class="modal-dialog modal-lg" role="document">--%>
                <div class="modal-dialog modal-personalizado" role="document">
                    <div class="modal-content" visible="false" style="border-radius: 10px;">
                        <div class="modal-header">
                            <h5 class="modal-title">Novo Usuário:</h5>
                            <asp:LinkButton type="button" runat="server" class="close" data-dismiss="modal" OnClick="lnkVoltar_Click" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                            </asp:LinkButton>
                        </div>
                        <div class="modal-body">
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Nome: </span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Sobrenome: </span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox runat="server" ID="txtSobreNome"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Digite o Login: </span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox runat="server" ID="txtLogin"></asp:TextBox>
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
                                    </div>
                                    <div class="col-sm">
                                        <asp:DropDownList ID="ddlPerfilNovoUsu" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Digite a Senha: </span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox type="password" runat="server" ID="txtNovaSenha" MaxLength="8">                                    
                                        </asp:TextBox>
                                        <img id="olho" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABDUlEQVQ4jd2SvW3DMBBGbwQVKlyo4BGC4FKFS4+TATKCNxAggkeoSpHSRQbwAB7AA7hQoUKFLH6E2qQQHfgHdpo0yQHX8T3exyPR/ytlQ8kOhgV7FvSx9+xglA3lM3DBgh0LPn/onbJhcQ0bv2SHlgVgQa/suFHVkCg7bm5gzB2OyvjlDFdDcoa19etZMN8Qp7oUDPEM2KFV1ZAQO2zPMBERO7Ra4JQNpRa4K4FDS0R0IdneCbQLb4/zh/c7QdH4NL40tPXrovFpjHQr6PJ6yr5hQV80PiUiIm1OKxZ0LICS8TWvpyyOf2DBQQtcXk8Zi3+JcKfNafVsjZ0WfGgJlZZQxZjdwzX+ykf6u/UF0Fwo5Apfcq8AAAAASUVORK5CYII=" />
                                        <p>**Senha até 8 caracteres</p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Confirme a senha: </span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox type="password" runat="server" ID="txtConfirmaSenha" MaxLength="8"></asp:TextBox>
                                        <img id="olhoDois" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABDUlEQVQ4jd2SvW3DMBBGbwQVKlyo4BGC4FKFS4+TATKCNxAggkeoSpHSRQbwAB7AA7hQoUKFLH6E2qQQHfgHdpo0yQHX8T3exyPR/ytlQ8kOhgV7FvSx9+xglA3lM3DBgh0LPn/onbJhcQ0bv2SHlgVgQa/suFHVkCg7bm5gzB2OyvjlDFdDcoa19etZMN8Qp7oUDPEM2KFV1ZAQO2zPMBERO7Ra4JQNpRa4K4FDS0R0IdneCbQLb4/zh/c7QdH4NL40tPXrovFpjHQr6PJ6yr5hQV80PiUiIm1OKxZ0LICS8TWvpyyOf2DBQQtcXk8Zi3+JcKfNafVsjZ0WfGgJlZZQxZjdwzX+ykf6u/UF0Fwo5Apfcq8AAAAASUVORK5CYII=" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="lnkSenha" class="btn btn-success" OnClick="lnkSenha_Click" runat="server">Salvar</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <script src="Scripts/jquery.min.js"></script>
                <script type="text/javascript">
                    var senha = $('#txtNovaSenha');
                    var olho = $("#olho");
                    olho.mousedown(function () {
                        senha.attr("type", "text");
                    });

                    olho.mouseup(function () {
                        senha.attr("type", "password");

                    });
                    // para evitar o problema de arrastar a imagem e a senha continuar exposta, 
                    //citada pelo nosso amigo nos comentários
                    $("#olho").mouseout(function () {
                        $("#txtNovaSenha").attr("type", "password");
                    });
                </script>
                <script type="text/javascript">
                    var ConfirmaSenha = $('#txtConfirmaSenha');
                    var olhoDois = $("#olhoDois");

                    olhoDois.mousedown(function () {
                        ConfirmaSenha.attr("type", "text");
                    });

                    olhoDois.mouseup(function () {
                        ConfirmaSenha.attr("type", "password");
                    });
                    // para evitar o problema de arrastar a imagem e a senha continuar exposta, 
                    //citada pelo nosso amigo nos comentários
                    $("#olhoDois").mouseout(function () {
                        $("#txtConfimaSenha").attr("type", "password");
                    });
                </script>
            </div>
            <div class="modal fade show" id="mdCli" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
                <%--<div class="modal-dialog modal-lg" role="document">--%>
                <div class="modal-dialog modal-personalizado" role="document">
                    <div class="modal-content" visible="false" style="border-radius: 10px;">
                        <div class="modal-header">
                            <h5 class="modal-title">Novo Cliente:</h5>
                            <asp:LinkButton type="button" runat="server" class="close" data-dismiss="modal" OnClick="lnkVoltar_Click" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                            </asp:LinkButton>
                        </div>
                        <div class="modal-body">

                            <div class="container">
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Cód. Reserva: </span>
                                        <asp:TextBox runat="server" ID="txtCodReserva"></asp:TextBox>
                                    </div>
                                    <div class="col-sm">
                                        <span>Quarto: </span>
                                        <asp:DropDownList ID="ddlQuarto" runat="server"></asp:DropDownList>
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
                                        <asp:TextBox runat="server" ID="txtNomeCliente"></asp:TextBox>
                                    </div>
                                    <div class="col-sm">
                                        <span>Sobrenome: </span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox runat="server" ID="txtSobrenomeCliente"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Data de Início:</span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox ID="txtInputDataIni" runat="server"></asp:TextBox>
                                        <%--onkeyup="formataDataeHora(this,event);" MaxLength="17"--%>
                                    </div>
                                    <div class="col-sm">
                                        <span>Data Fim:</span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox ID="txtInputDataFim" runat="server"></asp:TextBox>
                                        <%--onkeyup="formataDataeHora(this,event);" MaxLength="17"--%>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Senha Gerada:</span>
                                        <asp:TextBox ID="txtSenhaRand" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Período de: </span>
                                        <asp:TextBox ID="txtDataIni" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-sm">
                                        <span>Até: </span>
                                        <asp:TextBox ID="txtDataFim" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="salvarNovoCliente" class="btn btn-success" runat="server" OnClick="salvarNovoCliente_Click">Novo Cliente</asp:LinkButton>
                        </div>

                    </div>
                </div>

            </div>
            <div class="modal fade show" id="modEditCli" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content" visible="false" style="border-radius: 10px;">
                        <div class="modal-header">
                            <h5 class="modal-title">Editar Data Final do Cliente:</h5>
                            <asp:LinkButton type="button" runat="server" class="close" data-dismiss="modal" OnClick="lnkVoltar_Click" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                            </asp:LinkButton>
                        </div>
                        <div class="modal-body">
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm">
                                        Código da Reserva: 
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox runat="server" ID="txtCdReservaE" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Quarto: </span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:DropDownList ID="ddlQuartoE" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Nome Cliente: </span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox runat="server" ID="txtNomeClienteE" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Nova Data de Saída:</span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox ID="txtInputDataFimE" runat="server"></asp:TextBox>
                                        <%--onkeyup="formataDataeHora(this,event);" MaxLength="17"--%>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Período de: </span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox ID="txtDataIniE" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Até: </span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox ID="txtDataFimE" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:LinkButton ID="alterarData" class="btn btn-success" runat="server" OnClick="alterarData_Click">Salvar Alterações</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

