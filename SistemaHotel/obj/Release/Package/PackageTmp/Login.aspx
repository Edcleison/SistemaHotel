<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaHotel.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <link href="CSS/Estilos.css" rel="stylesheet" />
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
</head>
<body color="blue">
    <form id="form1" runat="server">
        <div>
            <div class="modal-backdrop fade show" id="mdBack" runat="server" style="opacity: 0.2; display: block; filter: (alpha(opacity= 20))" visible="true"></div>
            <div class="modal fade show" id="mdLog" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="true">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content" visible="true" style="border-radius: 10px;">
                        <div class="modal-header">
                        </div>
                        <div class="modal-body">
                            <table>
                                <tr>
                                    <td>
                                        <span>Digite seu Login: </span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLogin" runat="server" Style="text-transform: uppercase;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Digite sua Senha: </span>
                                    </td>
                                    <td>
                                        <asp:TextBox type="password" runat="server" ID="txtSenha" MaxLength="8"></asp:TextBox>
                                        <img id="olho" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABDUlEQVQ4jd2SvW3DMBBGbwQVKlyo4BGC4FKFS4+TATKCNxAggkeoSpHSRQbwAB7AA7hQoUKFLH6E2qQQHfgHdpo0yQHX8T3exyPR/ytlQ8kOhgV7FvSx9+xglA3lM3DBgh0LPn/onbJhcQ0bv2SHlgVgQa/suFHVkCg7bm5gzB2OyvjlDFdDcoa19etZMN8Qp7oUDPEM2KFV1ZAQO2zPMBERO7Ra4JQNpRa4K4FDS0R0IdneCbQLb4/zh/c7QdH4NL40tPXrovFpjHQr6PJ6yr5hQV80PiUiIm1OKxZ0LICS8TWvpyyOf2DBQQtcXk8Zi3+JcKfNafVsjZ0WfGgJlZZQxZjdwzX+ykf6u/UF0Fwo5Apfcq8AAAAASUVORK5CYII=" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                        <asp:LinkButton ID="btlogar" runat="server" class="btn btn-primary" OnClick="btlogar_Click">Logar</asp:LinkButton>

                                        <asp:LinkButton ID="lnkRecadastrarSenha" runat="server" class="btn btn-primary" OnClick="lnkRecadastrarSenha_Click">Redefinir Senha</asp:LinkButton>
                                    </td>

                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <script src="Scripts/jquery.min.js"></script>
                <script type="text/javascript">
                    var senha = $('#txtSenha');
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
                        $("#txtSenha").attr("type", "password");
                    });
                </script>
            </div>
            <div class="modal fade show" id="mdRedPass" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100))" visible="false">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content" visible="false" style="border-radius: 10px;">
                        <div class="modal-header">
                        </div>
                        <div class="modal-body">
                            <table>
                                <tr>
                                    <td>
                                        <span>Digite seu Login: </span>
                                    </td>
                                    <td>
                                        <asp:TextBox type="text" runat="server" ID="txtLoginR" Style="text-transform: uppercase;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Digite a Nova Senha: </span>
                                    </td>
                                    <td>
                                        <asp:TextBox type="password" runat="server" ID="txtNovaSenha" MaxLength="8"></asp:TextBox>
                                        <img id="olhoR" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABDUlEQVQ4jd2SvW3DMBBGbwQVKlyo4BGC4FKFS4+TATKCNxAggkeoSpHSRQbwAB7AA7hQoUKFLH6E2qQQHfgHdpo0yQHX8T3exyPR/ytlQ8kOhgV7FvSx9+xglA3lM3DBgh0LPn/onbJhcQ0bv2SHlgVgQa/suFHVkCg7bm5gzB2OyvjlDFdDcoa19etZMN8Qp7oUDPEM2KFV1ZAQO2zPMBERO7Ra4JQNpRa4K4FDS0R0IdneCbQLb4/zh/c7QdH4NL40tPXrovFpjHQr6PJ6yr5hQV80PiUiIm1OKxZ0LICS8TWvpyyOf2DBQQtcXk8Zi3+JcKfNafVsjZ0WfGgJlZZQxZjdwzX+ykf6u/UF0Fwo5Apfcq8AAAAASUVORK5CYII=" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Confirme a senha: </span>
                                    </td>
                                    <td>
                                        <asp:TextBox type="password" runat="server" ID="txtConfirmaSenha" MaxLength="8"></asp:TextBox>
                                        <img id="olhoDois" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABDUlEQVQ4jd2SvW3DMBBGbwQVKlyo4BGC4FKFS4+TATKCNxAggkeoSpHSRQbwAB7AA7hQoUKFLH6E2qQQHfgHdpo0yQHX8T3exyPR/ytlQ8kOhgV7FvSx9+xglA3lM3DBgh0LPn/onbJhcQ0bv2SHlgVgQa/suFHVkCg7bm5gzB2OyvjlDFdDcoa19etZMN8Qp7oUDPEM2KFV1ZAQO2zPMBERO7Ra4JQNpRa4K4FDS0R0IdneCbQLb4/zh/c7QdH4NL40tPXrovFpjHQr6PJ6yr5hQV80PiUiIm1OKxZ0LICS8TWvpyyOf2DBQQtcXk8Zi3+JcKfNafVsjZ0WfGgJlZZQxZjdwzX+ykf6u/UF0Fwo5Apfcq8AAAAASUVORK5CYII=" />

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="lnkSenha" class="btn btn-primary" OnClick="lnkSenha_Click" runat="server">Salvar</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkVoltar" class="btn btn-primary" runat="server" OnClick="lnkVoltar_Click">Voltar</asp:LinkButton>
                                    </td>
                                </tr>

                            </table>

                        </div>
                    </div>
                </div>
                <script src="Scripts/jquery.min.js"></script>
                <script type="text/javascript">
                    var senha = $('#txtNovaSenha');
                    var olho = $("#olhoR");

                    olho.mousedown(function () {
                        senha.attr("type", "text");
                    });

                    olho.mouseup(function () {
                        senha.attr("type", "password");

                    });
                    // para evitar o problema de arrastar a imagem e a senha continuar exposta, 
                    //citada pelo nosso amigo nos comentários
                    $("#olhoR").mouseout(function () {
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

        </div>
    </form>
</body>
</html>

