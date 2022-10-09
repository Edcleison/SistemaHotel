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
            string msg = "";


            Usuario u = DALUsuario.buscaUsuarioLogin(login);

            PerfilUsuario pu = DALPerfilUsuario.buscarUsuarioPerfil(u.IdUsuario);

            if (pu.IdPerfil != 3)
            {
                if (login != "" && senha != "")
                {

                    if (pu.StatusPerfilUsuario == 'S')
                    {

                        if (login != u.Login && senha == u.Senha)
                        {
                            //msg = "<script> alert('Login incorreto!'); </script>";
                            //Response.Write(msg);
                            Response.Write(@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                              Login incorreto! 
                                            <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                        }
                        else if (login == u.Login && senha != u.Senha)
                        {
                            //msg = "<script> alert('Senha incorreta!'); </script>";
                            //Response.Write(msg);
                            Response.Write(@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                            <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                               Senha incorreta!
                                            </div>");
                        }
                        else if (login != u.Login && senha != u.Senha)
                        {
                            //msg = "<script> alert('Login e senha incorretos!'); </script>";
                            //Response.Write(msg);
                            Response.Write(@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                              Login e senha incorretos!
                                            <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                        }
                        else
                        {


                            Session["id"] = u.IdUsuario;
                            Session["nome"] = u.NomeUsuario;
                            Session["login"] = u.Login;
                            switch (pu.IdPerfil)
                            {
                                case 1:
                                    Session["perfil"] = "Administrador";
                                    break;
                                case 2:
                                    Session["perfil"] = "Funcionário";
                                    break;
                                case 3:
                                    Session["perfil"] = "Cliente";
                                    break;
                            }
                            Response.Redirect("~/Default.aspx");

                        }

                    }
                    else
                    {
                        //msg = "<script> alert('Login incorreto!'); </script>";
                        //Response.Write(msg);
                        Response.Write(@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                              Login incorreto! 
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                    }

                }
            }
            else
            {

                Cliente cli = DALCliente.buscarClienteReserva(login);
                if (DateTime.ParseExact(cli.DataSaida.ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", null) > DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", null))
                {
                    if (login != "" && senha != "")
                    {

                        if (pu.StatusPerfilUsuario == 'S')
                        {

                            if (login != u.Login && senha == u.Senha)
                            {
                                //msg = "<script> alert('Login incorreto!'); </script>";
                                //Response.Write(msg);
                                Response.Write(@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                              Login incorreto! 
                                                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                            }
                            else if (login == u.Login && senha != u.Senha)
                            {
                                //msg = "<script> alert('Senha incorreta!'); </script>";
                                //Response.Write(msg);
                                Response.Write(@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                             Senha incorreta!
                                            <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                            }
                            else if (login != u.Login && senha != u.Senha)
                            {
                                //msg = "<script> alert('Login e senha incorretos!'); </script>";
                                //Response.Write(msg);
                                Response.Write(@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                             Login e senha incorretos!
                                            <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                            }
                            else
                            {


                                Session["id"] = u.IdUsuario;
                                Session["nome"] = u.NomeUsuario;
                                Session["login"] = u.Login;
                                switch (pu.IdPerfil)
                                {
                                    case 1:
                                        Session["perfil"] = "Administrador";
                                        break;
                                    case 2:
                                        Session["perfil"] = "Funcionário";
                                        break;
                                    case 3:
                                        Session["perfil"] = "Cliente";
                                        break;
                                }
                                Response.Redirect("~/Default.aspx");
                            }

                        }
                        else
                        {
                            //msg = "<script> alert('Login incorreto!'); </script>";
                            //Response.Write(msg);
                            Response.Write(@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                           Login incorreto!
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                        }

                    }
                    else
                    {
                        //msg = "<script> alert('Login incorreto!'); </script>";
                        //Response.Write(msg);
                        Response.Write(@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                           Preencha todos os campos!
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                    }
                }
                else
                {
                    if (pu.StatusPerfilUsuario == 'S')
                    {
                        DALPerfilUsuario.inativarUsuario(u.IdUsuario);
                    }
                    //msg = "<script> alert('Login incorreto!'); </script>";
                    //Response.Write(msg);
                    Response.Write(@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                          Login incorreto!
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
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

            string login = txtLoginR.Text;
            Usuario usu = DALUsuario.buscaUsuarioLogin(login);
            PerfilUsuario perfUsu = DALPerfilUsuario.buscarUsuarioPerfil(usu.IdUsuario);

            if (perfUsu.StatusPerfilUsuario == 'S')
            {
                if (txtNovaSenha.Text == txtConfirmaSenha.Text)
                {

                    usu.IdUsuario = perfUsu.IdUsuario;
                    usu.Senha = Criptografia.Encrypt(txtConfirmaSenha.Text);
                    DALUsuario.alterarSenha(usu);
                    //string msg = "<script> alert('Senha Atualizada!'); </script>";
                    //Response.Write(msg);
                    Response.Write(@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                         Senha Atualizada!
                                    <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                    limparCampos();
                }
                else
                {
                    //string msg = "<script> alert('Digite as Senhas Iguais!'); </script>";
                    //Response.Write(msg);
                    Response.Write(@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                         Digite as Senhas Iguais!
                                    <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                }


            }
            else
            {
                //string msg = "<script> alert('Login não encontrado!'); </script>";
                //Response.Write(msg);
                Response.Write(@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                        Login não encontrado!
                                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
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

