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
        string cnn = @"Data Source=LAPTOP-JV98S2OU\SQLEXPRESS;Initial Catalog=hotelServicos;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregaDdl();
            }
        }

        protected void lnkSenha_Click(object sender, EventArgs e)
        {
            string perfil = ddlPerfil.SelectedValue;
            Usuario usu = new Usuario();
            string email = txtEmail.Text;
            DataTable dta = new DataTable();
            DataTable dta1 = new DataTable();
            dta = usu.buscaUsuarioEmailInativo(email);
            dta1 = usu.buscaUsuarioEmailAtivo(email);

            if (txtNome.Text != "" && txtEmail.Text != "" && txtNovaSenha.Text != "" && txtConfirmaSenha.Text != "" && ddlPerfil.SelectedValue != "SELECIONE")
            {
                if (txtNovaSenha.Text == txtConfirmaSenha.Text)
                {
                    if (dta.Rows.Count > 0)
                    {
                        string nome = txtNome.Text;
                        string senha = txtNovaSenha.Text;
                        usu = new Usuario();
                        usu.ativarUsuario(nome, email, senha);
                        string msg = "<script> alert('Cadastro realizado!'); </script>";
                        Response.Write(msg);
                        limparCampos();
                    }
                    else if (dta1.Rows.Count > 0)
                    {
                        string msg = "<script> alert('Usuário já cadastrado!'); </script>";
                        Response.Write(msg);

                    }
                    else
                    {

                        string nome = txtNome.Text;
                        string senha = usu.Encrypt(txtNovaSenha.Text);
                        usu = new Usuario();
                        usu.inserirUsuario(nome, email, senha);
                        usu.inserirPerfil(perfil, email);
                        string msg = "<script> alert('Cadastro realizado!'); </script>";
                        Response.Write(msg);
                        limparCampos();
                    }
                }
                else
                {
                    string msg = "<script> alert('Senhas Diferentes!'); </script>";
                    Response.Write(msg);
                    limparCampos();

                }
            }
            else
            {
                string msg = "<script> alert('Preencha todos os campos!'); </script>";
                Response.Write(msg);
                limparCampos();
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
                    catch (Exception ex)
                    { }

                }
            }
        }
    }

}
