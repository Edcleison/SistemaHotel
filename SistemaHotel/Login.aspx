<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaHotel.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <link href="CSS/Estilos.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script>
        $(document).ready(function () {
            setTimeout(function () {
                $(".alert").fadeOut("slow", function () {
                    $(this).alert('close');
                });
            }, 5000);
        });
    </script>
    <style>
        .modal-backdrop {
            background-image: url('https://cdn.tapetender70er.de/media/image/07/6f/e5/Papel-de-Parede-para-Hoteleira_944x944@2x.webp');
            background-repeat: no-repeat;
            background-size: cover;
            height: auto;
        }

        div.alert {
            position: absolute;
            top: 30px;
            right: 0;
            width: 150px;
            height: 60px;
        }
    </style>



</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="modal-backdrop fade show" id="mdBack" runat="server" style="opacity: 0.2; display: block; filter: (alpha(opacity= 20))" visible="true"></div>
            <div class="modal fade show" id="mdLog" runat="server" tabindex="-1" role="dialog" aria-labelledby="mediumModalLabel" aria-hidden="true" style="opacity: 1; display: block; filter: (alpha(opacity= 100));">
                <%--<div class="modal-dialog modal-lg" role="document">--%>
                <div class="modal-dialog modal-personalizado" role="document">
                    <div class="modal-content" visible="true" style="border-radius: 10px;">
                        <div class="modal-header">
                            <h5 class="modal-title"></h5>
                        </div>
                        <div class="modal-body">
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Digite seu Login: </span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Digite sua Senha: </span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox type="password" runat="server" ID="txtSenha" MaxLength="8"></asp:TextBox>
                                    </div>
                                    <div class="col-sm">
                                        <img id="olho" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABDUlEQVQ4jd2SvW3DMBBGbwQVKlyo4BGC4FKFS4+TATKCNxAggkeoSpHSRQbwAB7AA7hQoUKFLH6E2qQQHfgHdpo0yQHX8T3exyPR/ytlQ8kOhgV7FvSx9+xglA3lM3DBgh0LPn/onbJhcQ0bv2SHlgVgQa/suFHVkCg7bm5gzB2OyvjlDFdDcoa19etZMN8Qp7oUDPEM2KFV1ZAQO2zPMBERO7Ra4JQNpRa4K4FDS0R0IdneCbQLb4/zh/c7QdH4NL40tPXrovFpjHQr6PJ6yr5hQV80PiUiIm1OKxZ0LICS8TWvpyyOf2DBQQtcXk8Zi3+JcKfNafVsjZ0WfGgJlZZQxZjdwzX+ykf6u/UF0Fwo5Apfcq8AAAAASUVORK5CYII=" />
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btlogar" runat="server" class="btn btn-dark" OnClick="btlogar_Click">Logar</asp:LinkButton>
                            <asp:LinkButton ID="lnkRecadastrarSenha" runat="server" class="btn btn-dark" OnClick="lnkRecadastrarSenha_Click">Redefinir Senha</asp:LinkButton>
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
                <%--<div class="modal-dialog modal-lg" role="document">--%>
                <div class="modal-dialog modal-personalizado" role="document">
                    <div class="modal-content" visible="false" style="border-radius: 10px;">
                        <div class="modal-header">
                            <h5 class="modal-title">Redefinir Senha:</h5>
                            <asp:LinkButton type="button" runat="server" class="close" data-dismiss="modal" OnClick="lnkVoltar_Click" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                            </asp:LinkButton>
                        </div>
                        <div class="modal-body">
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Digite seu Login: </span>
                                    </div>

                                    <div class="col-sm">
                                        <asp:TextBox type="text" runat="server" ID="txtLoginR"></asp:TextBox>
                                    </div>
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>&nbsp;</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm">
                                        <span>Digite a Nova Senha: </span>
                                    </div>
                                    <div class="col-sm">
                                        <asp:TextBox type="password" runat="server" ID="txtNovaSenha" MaxLength="8"></asp:TextBox>
                                    </div>
                                    <div class="col-sm">
                                        <img id="olhoR" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABDUlEQVQ4jd2SvW3DMBBGbwQVKlyo4BGC4FKFS4+TATKCNxAggkeoSpHSRQbwAB7AA7hQoUKFLH6E2qQQHfgHdpo0yQHX8T3exyPR/ytlQ8kOhgV7FvSx9+xglA3lM3DBgh0LPn/onbJhcQ0bv2SHlgVgQa/suFHVkCg7bm5gzB2OyvjlDFdDcoa19etZMN8Qp7oUDPEM2KFV1ZAQO2zPMBERO7Ra4JQNpRa4K4FDS0R0IdneCbQLb4/zh/c7QdH4NL40tPXrovFpjHQr6PJ6yr5hQV80PiUiIm1OKxZ0LICS8TWvpyyOf2DBQQtcXk8Zi3+JcKfNafVsjZ0WfGgJlZZQxZjdwzX+ykf6u/UF0Fwo5Apfcq8AAAAASUVORK5CYII=" />
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
                                    </div>
                                    <div class="col-sm">
                                        <img id="olhoDois" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABDUlEQVQ4jd2SvW3DMBBGbwQVKlyo4BGC4FKFS4+TATKCNxAggkeoSpHSRQbwAB7AA7hQoUKFLH6E2qQQHfgHdpo0yQHX8T3exyPR/ytlQ8kOhgV7FvSx9+xglA3lM3DBgh0LPn/onbJhcQ0bv2SHlgVgQa/suFHVkCg7bm5gzB2OyvjlDFdDcoa19etZMN8Qp7oUDPEM2KFV1ZAQO2zPMBERO7Ra4JQNpRa4K4FDS0R0IdneCbQLb4/zh/c7QdH4NL40tPXrovFpjHQr6PJ6yr5hQV80PiUiIm1OKxZ0LICS8TWvpyyOf2DBQQtcXk8Zi3+JcKfNafVsjZ0WfGgJlZZQxZjdwzX+ykf6u/UF0Fwo5Apfcq8AAAAASUVORK5CYII=" />
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:LinkButton ID="lnkSenha" class="btn btn-dark" OnClick="lnkSenha_Click" runat="server">Salvar</asp:LinkButton>
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
        </div>
    </form>
</body>
</html>

