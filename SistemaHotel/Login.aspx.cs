﻿using SistemaHotel.Controller;
using SistemaHotel.Model;
using SistemaHotel.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            string login = txtLogin.Text;
            string senha = Criptografia.Encrypt(txtSenha.Text);

            DALUsuario du = new DALUsuario();
            Usuario u = du.buscaUsuarioLogin(login);
            DALPerfilUsuario dpu = new DALPerfilUsuario();
            PerfilUsuario pu = dpu.buscarUsuarioPerfil(u.IdUsuario);

            if (pu.IdPerfil != 3)
            {
                if (login != "" && senha != "")
                {

                    if (pu.StatusPerfilUsuario == 'S')
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


                            Session["id"] = u.IdUsuario;
                            Session["nome"] = u.NomeUsuario;
                            Session["login"] = u.Login;
                            switch (pu.IdPerfil)
                            {
                                case 1:
                                    Session["perfil"] = "ADMINISTRADOR";
                                    break;
                                case 2:
                                    Session["perfil"] = "FUNCIONARIO";
                                    break;
                                case 3:
                                    Session["perfil"] = "CLIENTE";
                                    break;
                            }
                            Response.Redirect("~/Default.aspx");
                        }

                    }

                }
            }
            else
            {
                DALCliente dcli = new DALCliente();
                Cliente cli = dcli.buscarClienteReserva(login);
                if (cli.DataSaida > DateTime.Now)
                {
                    if (login != "" && senha != "")
                    {

                        if (pu.StatusPerfilUsuario == 'S')
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


                                Session["id"] = u.IdUsuario;
                                Session["nome"] = u.NomeUsuario;
                                Session["login"] = u.Login;
                                switch (pu.IdPerfil)
                                {
                                    case 1:
                                        Session["perfil"] = "ADMINISTRADOR";
                                        break;
                                    case 2:
                                        Session["perfil"] = "FUNCIONARIO";
                                        break;
                                    case 3:
                                        Session["perfil"] = "CLIENTE";
                                        break;
                                }                                
                                Response.Redirect("~/Default.aspx");
                            }

                        }

                    }
                    else
                    {
                        string msg = "<script> alert('Login não permitido!); </script>";
                        Response.Write(msg);
                    }

                } 
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
            limparCampos();
        }

        protected void lnkSenha_Click(object sender, EventArgs e)
        {
            DALUsuario dalUsu = new DALUsuario();
            string login = txtLoginR.Text;
            Usuario usu = dalUsu.buscaUsuarioLogin(login);
            DALPerfilUsuario dalPerfUsu = new DALPerfilUsuario();
            PerfilUsuario perfUsu = dalPerfUsu.buscarUsuarioPerfil(usu.IdUsuario);

            if (perfUsu.StatusPerfilUsuario == 'S')
            {
                if (txtNovaSenha.Text == txtConfirmaSenha.Text)
                {

                    usu.IdUsuario = perfUsu.IdUsuario;
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

