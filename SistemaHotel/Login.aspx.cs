using SistemaHotel.Controller;
using SistemaHotel.Model;
using SistemaHotel.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SistemaHotel
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btlogar_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.ToUpper();
            string senha = Criptografia.Encrypt(txtSenha.Text);

            DALUsuario du = new DALUsuario();
            Usuario u = du.buscaUsuarioLogin(login);

            if (login != "" && senha != "")
            {
                if (login != u.Login && senha == u.Senha)
                {
                    String msg = "<script> alert('Login incorreto!'); </script>";
                    Response.Write(msg);
                }
                else if (login == u.Login && senha != u.Senha)
                {
                    String msg = "<script> alert('Senha incorreta!'); </script>";
                    Response.Write(msg);
                }
                else if (login != u.Login && senha != u.Senha)
                {
                    String msg = "<script> alert('Login e senha incorretos'); </script>";
                    Response.Write(msg);
                }
                else
                {


                    Session["id"] = u.Id;
                    Session["nome"] = u.Nome;
                    Session["Login"] = u.Login;
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                String msg = "<script> alert('Preencha corretamente!); </script>";
                Response.Write(msg);
            }
        }

        protected void lnkRecadastrarSenha_Click(object sender, EventArgs e)
        {

            mdLog.Visible = false;
            mdRedPass.Visible = true;
        }

        protected void lnkVoltar_Click(object sender, EventArgs e)
        {

            mdLog.Visible = true;
            mdRedPass.Visible = false;
        }

        protected void lnkSenha_Click(object sender, EventArgs e)
        {
            DALUsuario dalUsu = new DALUsuario();
            string login = txtLogin.Text.ToUpper();
            Usuario usu = dalUsu.buscaUsuarioLogin(login);
            DALPerfilUsuario dalPerfUsu = new DALPerfilUsuario();
            PerfilUsuario perfUsu = dalPerfUsu.buscarUsuarioPerfil(usu.Id);

            if (perfUsu.Ativo == 'S')
            {
                if (txtNovaSenha.Text == txtConfirmaSenha.Text)
                {

                    usu.Id = perfUsu.Id;
                    usu.Senha = Criptografia.Encrypt(txtConfirmaSenha.Text);
                    dalUsu.alterarSenha(usu);
                    string msg = "<script> alert('Senha Atualizada!'); </script>";
                    Response.Write(msg);
                    limparCampos(); 
                }
                else
                {
                    string msg = "<script> alert('Digite as Senhas Iguais!'); </script>";
                    Response.Write(msg);
                }


            }
            else
            {
                string msg = "<script> alert('Login não encontrado!'); </script>";
                Response.Write(msg);
            }

        }
        private void limparCampos()
        {
            txtLogin.Text = "";
            txtNovaSenha.Text = "";
            txtConfirmaSenha.Text = "";
            txtLoginR.Text = "";
            txtSenha.Text = "";
        }
    }
}

