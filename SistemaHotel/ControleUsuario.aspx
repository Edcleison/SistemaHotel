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
                "paging": true,
                "pageLength": 3,
                "ordering": false,
                "info": false,
                dom: 'Bfrtip',
                buttons: [

                ]



            });
        })
    </script>



</asp:Content>


<asp:Content ID="Content12" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel3" runat="server" GroupingText="Controle de Usuários">
        <table>
            <tr>
                <td>
                    <asp:LinkButton ID="novoUsuario" class="btn btn-primary" runat="server" OnClick="novoUsuario_Click">Novo Funcionário</asp:LinkButton></td>
                <td>
                    <b>&nbsp;</b>
                </td>
                <td>
                    <asp:LinkButton ID="novoCliente" class="btn btn-success" runat="server" OnClick="novoCliente_Click">Novo Cliente</asp:LinkButton></td>
            </tr>
            <tr>
                <td>
                    <b>&nbsp;</b>
                </td>
            </tr>
            <tr>
                <td>Listar Por: </td>
                <td>
                    <b>&nbsp;</b>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPerfil" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPerfil_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
        </table>
        <div class="col-12" align="center">
            <div id="Panel1" runat="server" visible="true">
            </div>
        </div>
        <div class="modal-backdrop fade show" id="mdBack" runat="server" style="opacity: 0.2; display: block; filter: (alpha(opacity= 20))" visible="false"></div>
        <div class="modal fade show" id="mdUsu" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content" visible="false" style="border-radius: 10px;">
                    <div class="modal-header">
                    </div>
                    <div class="modal-body">
                        <table>
                            <tr>
                                <td><span>Digite seu Nome: </span></td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtNome"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><span>Digite o Login: </span></td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtLogin"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><span>Perfil: </span></td>
                                <td>
                                    <asp:DropDownList ID="ddlPerfilNovoUsu" runat="server"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td><span>Digite a Senha: </span></td>
                                <td>
                                    <asp:TextBox type="password" runat="server" ID="txtNovaSenha"></asp:TextBox></td>
                                <td>
                                    <img id="olho" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABDUlEQVQ4jd2SvW3DMBBGbwQVKlyo4BGC4FKFS4+TATKCNxAggkeoSpHSRQbwAB7AA7hQoUKFLH6E2qQQHfgHdpo0yQHX8T3exyPR/ytlQ8kOhgV7FvSx9+xglA3lM3DBgh0LPn/onbJhcQ0bv2SHlgVgQa/suFHVkCg7bm5gzB2OyvjlDFdDcoa19etZMN8Qp7oUDPEM2KFV1ZAQO2zPMBERO7Ra4JQNpRa4K4FDS0R0IdneCbQLb4/zh/c7QdH4NL40tPXrovFpjHQr6PJ6yr5hQV80PiUiIm1OKxZ0LICS8TWvpyyOf2DBQQtcXk8Zi3+JcKfNafVsjZ0WfGgJlZZQxZjdwzX+ykf6u/UF0Fwo5Apfcq8AAAAASUVORK5CYII=" />
                                </td>
                            </tr>
                            <tr>
                                <td><span>Confirme a senha: </span></td>
                                <td>
                                    <asp:TextBox type="password" runat="server" ID="txtConfirmaSenha"></asp:TextBox></td>
                                <td>
                                    <img id="olhoDois" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABDUlEQVQ4jd2SvW3DMBBGbwQVKlyo4BGC4FKFS4+TATKCNxAggkeoSpHSRQbwAB7AA7hQoUKFLH6E2qQQHfgHdpo0yQHX8T3exyPR/ytlQ8kOhgV7FvSx9+xglA3lM3DBgh0LPn/onbJhcQ0bv2SHlgVgQa/suFHVkCg7bm5gzB2OyvjlDFdDcoa19etZMN8Qp7oUDPEM2KFV1ZAQO2zPMBERO7Ra4JQNpRa4K4FDS0R0IdneCbQLb4/zh/c7QdH4NL40tPXrovFpjHQr6PJ6yr5hQV80PiUiIm1OKxZ0LICS8TWvpyyOf2DBQQtcXk8Zi3+JcKfNafVsjZ0WfGgJlZZQxZjdwzX+ykf6u/UF0Fwo5Apfcq8AAAAASUVORK5CYII=" />

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnkSenha" class="btn btn-sucess" OnClick="lnkSenha_Click" runat="server">Salvar</asp:LinkButton></td>
                                <td>
                                    <asp:LinkButton ID="lnkVoltar" class="btn btn-primary" runat="server" OnClick="lnkVoltar_Click">Voltar</asp:LinkButton>
                            </tr>

                        </table>

                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade show" id="mdCli" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content" visible="false" style="border-radius: 10px;">
                    <div class="modal-header">
                    </div>
                    <div class="modal-body">

                        <table>
                            <tr>
                                <td><span>Código da Reserva: </span></td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCodReserva"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td><span>Data de Início:</span>
                                    <br />
                                    <asp:Calendar ID="dtInicio" runat="server"></asp:Calendar>
                                </td>

                                <td><span>Data Fim:</span>
                                    <br />
                                    <asp:Calendar ID="dtFim" runat="server"></asp:Calendar>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="salvarNovoCliente" class="btn btn-success" runat="server" OnClick="salvarNovoCliente_Click">Novo Cliente</asp:LinkButton></td>
                                <td><span>Senha Gerada:</span>
                                    <asp:TextBox ID="txtSenhaRand" runat="server" Enabled="false"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Período de: </span>
                                    <asp:TextBox ID="txtDataIni" runat="server" TextMode="DateTime" Enabled="false"></asp:TextBox>
                                </td>
                                <td>
                                    <span>Até: </span>
                                    <asp:TextBox ID="txtDataFim" runat="server" TextMode="DateTime" Enabled="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButton1" class="btn btn-primary" runat="server" OnClick="lnkVoltar_Click">Voltar</asp:LinkButton>
                                </td>

                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade show" id="modEditCli" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content" visible="false" style="border-radius: 10px;">
                    <div class="modal-header">
                    </div>
                    <div class="modal-body">

                        <table>
                            <tr>
                                <td><span>Código da Reserva: </span></td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCdReservaE" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td><span>Data de Início:</span>
                                    <br />
                                    <asp:Calendar ID="dtInicioE" runat="server" Enabled="false"></asp:Calendar>
                                </td>

                                <td><span>Data Fim:</span>
                                    <br />
                                    <asp:Calendar ID="dtFimE" runat="server"></asp:Calendar>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="alterarData" class="btn btn-success" runat="server" OnClick="alterarData_Click">Salvar Alterações</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Período de: </span>
                                    <asp:TextBox ID="txtDataIniE" runat="server" TextMode="DateTime" Enabled="false"></asp:TextBox>
                                </td>
                                <td>
                                    <span>Até: </span>
                                    <asp:TextBox ID="txtDataFimE" runat="server" TextMode="DateTime" Enabled="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkVoltarCliE" class="btn btn-primary" runat="server" OnClick="lnkVoltar_Click">Voltar</asp:LinkButton>
                                </td>

                            </tr>
                        </table>
                    </div>
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
        <script src="Scripts/jquery.min.js"></script>
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
    </asp:Panel>
</asp:Content>

