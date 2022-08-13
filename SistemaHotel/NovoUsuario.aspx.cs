using SistemaHotel.Controller;
using SistemaHotel.Model;
using SistemaHotel.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaHotel
{
    public partial class NovoUsuario : System.Web.UI.Page
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=hotelservicos;Persist Security Info=True;User ID=hotelservicos;Password=Sc3f_r4_104t";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregaDdl();
            }
        }

        protected void lnkSenha_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            DALPerfilUsuario dalPerfUsu = new DALPerfilUsuario();
            DALUsuario dalUsu = new DALUsuario();
            Usuario usu = dalUsu.buscaUsuarioEmail(email);
            PerfilUsuario perfUsu = dalPerfUsu.buscarUsuarioPerfil(usu.Id);
            if (txtNome.Text != "" && txtEmail.Text != "" && txtNovaSenha.Text != "" && txtConfirmaSenha.Text != "" && ddlPerfil.SelectedValue != "SELECIONE")
            {
                if (email.Contains("@") && email.Contains("."))
                {

                    if (txtNovaSenha.Text == txtConfirmaSenha.Text)
                    {
                        if (perfUsu.Ativo == 'N')
                        {
                            dalPerfUsu.ativarUsuario(perfUsu.Id);

                            string msg = "<script> alert('Cadastro realizado!'); </script>";
                            Response.Write(msg);
                            limparCampos();
                        }
                        else if (perfUsu.Ativo == 'S')
                        {
                            string msg = "<script> alert('Usuário já cadastrado!'); </script>";
                            Response.Write(msg);

                        }
                        else
                        {
                            if (usu.Email == "")
                            {
                                usu.Nome = txtNome.Text;
                                usu.Email = txtEmail.Text;
                                usu.Senha = Criptografia.Encrypt(txtNovaSenha.Text);
                                dalUsu.inserirUsuario(usu);
                            }
                            usu = dalUsu.buscaUsuarioEmail(usu.Email);
                            perfUsu.Perfil = ddlPerfil.SelectedIndex;
                            perfUsu.ID_USUARIO = usu.Id;
                            dalPerfUsu.inserirPerfil(perfUsu);
                            string msg = "<script> alert('Cadastro realizado!'); </script>";
                            Response.Write(msg);
                            limparCampos();
                        }
                    }
                    else
                    {
                        string msg = "<script> alert('Senhas Diferentes!'); </script>";
                        Response.Write(msg);

                    }
                }
                else
                {
                    string msg = "<script> alert('Digite um e-mail válido'); </script>";
                    Response.Write(msg);
                }


            }
            else
            {
                string msg = "<script> alert('Preencha todos os campos!'); </script>";
                Response.Write(msg);
            }
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtNovaSenha.Text = "";
            txtConfirmaSenha.Text = "";
            ddlPerfil.SelectedIndex = -1;
        }

        private void carregaDdl()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT ID, UPPER(PERFIL) AS PERFIL FROM PERFIL ORDER BY PERFIL", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        ddlPerfil.DataTextField = "PERFIL";
                        ddlPerfil.DataValueField = "ID";
                        ddlPerfil.DataSource = dta.Copy();
                        ddlPerfil.DataBind();
                        ddlPerfil.Items.Insert(0, "SELECIONE");
                    }
                    catch (Exception erro)
                    {
                        throw new Exception(erro.Message);
                    }

                }
            }
        }
    }

}
