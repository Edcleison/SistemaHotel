<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NovoUsuario.aspx.cs" Inherits="SistemaHotel.NovoUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Novo Usuário</title>
    <link href="CSS/Estilos.css" rel="stylesheet" />
    
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" GroupingText="Novo Usuario" CssClass="login">
                <span>Digite seu Nome: </span>
                <asp:Textbox  runat="server" id="txtNome"></asp:Textbox>                
                <br />
                <br />
                <span>Digite seu Email: </span>
                <asp:Textbox  runat="server" id="txtEmail"></asp:Textbox>                
                <br />
                <br />
                <span>Perfil: </span><asp:DropDownList ID="ddlPerfil" runat="server">
                </asp:DropDownList>
                <br />
                <br />
                <span>Digite a Senha: </span>
                <asp:Textbox type="password" runat="server" id="txtNovaSenha"></asp:Textbox>
                <img id="olho" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABDUlEQVQ4jd2SvW3DMBBGbwQVKlyo4BGC4FKFS4+TATKCNxAggkeoSpHSRQbwAB7AA7hQoUKFLH6E2qQQHfgHdpo0yQHX8T3exyPR/ytlQ8kOhgV7FvSx9+xglA3lM3DBgh0LPn/onbJhcQ0bv2SHlgVgQa/suFHVkCg7bm5gzB2OyvjlDFdDcoa19etZMN8Qp7oUDPEM2KFV1ZAQO2zPMBERO7Ra4JQNpRa4K4FDS0R0IdneCbQLb4/zh/c7QdH4NL40tPXrovFpjHQr6PJ6yr5hQV80PiUiIm1OKxZ0LICS8TWvpyyOf2DBQQtcXk8Zi3+JcKfNafVsjZ0WfGgJlZZQxZjdwzX+ykf6u/UF0Fwo5Apfcq8AAAAASUVORK5CYII=" />
                <br />              
                <br />
                <span>Confirme a senha: </span>            
                <asp:Textbox type="password" runat="server"  id="txtConfirmaSenha" ></asp:Textbox>
                <img id="olhoDois" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABDUlEQVQ4jd2SvW3DMBBGbwQVKlyo4BGC4FKFS4+TATKCNxAggkeoSpHSRQbwAB7AA7hQoUKFLH6E2qQQHfgHdpo0yQHX8T3exyPR/ytlQ8kOhgV7FvSx9+xglA3lM3DBgh0LPn/onbJhcQ0bv2SHlgVgQa/suFHVkCg7bm5gzB2OyvjlDFdDcoa19etZMN8Qp7oUDPEM2KFV1ZAQO2zPMBERO7Ra4JQNpRa4K4FDS0R0IdneCbQLb4/zh/c7QdH4NL40tPXrovFpjHQr6PJ6yr5hQV80PiUiIm1OKxZ0LICS8TWvpyyOf2DBQQtcXk8Zi3+JcKfNafVsjZ0WfGgJlZZQxZjdwzX+ykf6u/UF0Fwo5Apfcq8AAAAASUVORK5CYII=" />
                <br />
                <br />
                <asp:LinkButton ID="lnkSenha" class="btn btn-primary" OnClick="lnkSenha_Click" runat="server">[Salvar]</asp:LinkButton>
                <asp:LinkButton ID="lnkVoltar" class="btn btn-primary"  runat="server" PostBackUrl="~/Default.aspx">[Voltar]</asp:LinkButton>
                
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
            </asp:Panel>
            
            <%--<asp:LinkButton ID="recadastrarSenha" runat="server">[Esqueci a Senha]</asp:LinkButton>
            <asp:LinkButton ID="novoUsuario" runat="server">[Novo Usuário]</asp:LinkButton>--%>
        </div>
    </form>
</body>
    
</html>
