using SistemaHotel.Controller;
using SistemaHotel.Model;
using SistemaHotel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaHotel
{
    public partial class RedefinirSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void lnkEmail_Click(object sender, EventArgs e)
        {
           
            DALUsuario dalUsu = new DALUsuario();
            string login = txtLogin.Text;
            Usuario usu = dalUsu.buscaUsuarioLogin(login);
            DALPerfilUsuario dalPerfUsu = new DALPerfilUsuario();
            PerfilUsuario perfUsu = dalPerfUsu.buscarUsuarioPerfil(usu.Id);

            if (perfUsu.Ativo == 'S')
            {
                divSenha.Visible = true;
            }
            else
            {
                string msg = "<script> alert('Email não encontrado!'); </script>";
                Response.Write(msg);
                divSenha.Visible = false;
            }


        }

        protected void lnkSenha_Click(object sender, EventArgs e)
        {
            DALUsuario dalUsu = new DALUsuario();
            string login = txtLogin.Text;
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
                    divSenha.Visible = false;
                }
                else
                {
                    string msg = "<script> alert('Digite as Senhas Iguais!'); </script>";
                    Response.Write(msg);
                }


            }
            else
            {
                string msg = "<script> alert('Email não encontrado!'); </script>";
                Response.Write(msg);
            }

        }
        private void limparCampos()
        {
            txtLogin.Text = "";
            txtNovaSenha.Text = "";
            txtConfirmaSenha.Text = "";
        }
    }
}