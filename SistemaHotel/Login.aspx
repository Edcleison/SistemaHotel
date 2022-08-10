<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaHotel.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="CSS/Estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" GroupingText="Login" CssClass="login">
                <span>Digite seu Email: </span>
                <br />
                <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                <br />
                <span>Digite sua Senha: </span>
                <br />
                <asp:TextBox type="password" runat="server" id="txtSenha"  ></asp:TextBox>
                <img id="olho" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABDUlEQVQ4jd2SvW3DMBBGbwQVKlyo4BGC4FKFS4+TATKCNxAggkeoSpHSRQbwAB7AA7hQoUKFLH6E2qQQHfgHdpo0yQHX8T3exyPR/ytlQ8kOhgV7FvSx9+xglA3lM3DBgh0LPn/onbJhcQ0bv2SHlgVgQa/suFHVkCg7bm5gzB2OyvjlDFdDcoa19etZMN8Qp7oUDPEM2KFV1ZAQO2zPMBERO7Ra4JQNpRa4K4FDS0R0IdneCbQLb4/zh/c7QdH4NL40tPXrovFpjHQr6PJ6yr5hQV80PiUiIm1OKxZ0LICS8TWvpyyOf2DBQQtcXk8Zi3+JcKfNafVsjZ0WfGgJlZZQxZjdwzX+ykf6u/UF0Fwo5Apfcq8AAAAASUVORK5CYII=" />
                 <br />
               

                <asp:Button ID="btlogar" runat="server" Text="Logar" OnClick="btlogar_Click"  />
                
                <asp:LinkButton ID="lnkRecadastrarSenha" runat="server" PostBackUrl="~/RedefinirSenha.aspx">[Esqueci a Senha]</asp:LinkButton>               
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
                
            </asp:Panel>
            
        </div>
    </form>
</body>
</html>

