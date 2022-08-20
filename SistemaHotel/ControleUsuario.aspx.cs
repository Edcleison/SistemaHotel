using SistemaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaHotel.Controller;
using SistemaHotel.Utils;

namespace SistemaHotel
{
    public partial class ControleUsuario : System.Web.UI.Page
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=hotelservicos;Persist Security Info=True;User ID=hotelservicos;Password=Sc3f_r4_104t";

        DALPerfilUsuario dalPerfUsu = new DALPerfilUsuario();
        DALUsuario dalUsu = new DALUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            int rParametro = 0;

            if (!IsPostBack)
            {

                if (Request.QueryString["USUARIO_D"] != null)
                {
                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["USUARIO_D"]));

                    Usuario usu = dalUsu.buscarUsuarioId(rParametro);

                    if (usu.Id != 0)
                    {
                        dalPerfUsu.inativarUsuario(usu.Id);
                        string msg = "<script> alert('Usuário Inativado!'); </script>";
                        Response.Write(msg);

                    }
                }
                if (Request.QueryString["CLIENTE_E"] != null)
                {

                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["CLIENTE_E"]));

                    Usuario usu = dalUsu.buscarUsuarioId(rParametro);
                    DALCliente dalCliente = new DALCliente();
                    Cliente cli = dalCliente.buscarClienteReserva(usu.Login);
                    txtCdReservaE.Text = cli.Cd_Reserva;
                    dtInicioE.SelectedDate = cli.DataInicio;
                    dtFim.SelectedDate = cli.DataFim;
                    txtDataIniE.Text = cli.DataInicio.ToString("dd/MM/yyyy");
                    txtDataFimE.Text = cli.DataFim.ToString("dd/MM/yyyy");
                    modEditCli.Visible = true;
                }
                else
                {
                    carregaDdl();
                }
                carregaDdl();
            }

        }



        private void carregarTabela(string Perfil)
        {
            DataTable rDta = new DataTable();
            rDta = dalUsu.buscarUsuariosPerfilAtivos(Perfil);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th><center>ID</th></center>");
            sb.AppendLine("<th><center>NOME</th></center>");
            sb.AppendLine("<th><center>LOGIN</th></center>");
            sb.AppendLine("<th><center>INATIVAR</th></center>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td><center>" + dtr["ID"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["NOME"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["LOGIN"] + "</td></center>");
                sb.AppendLine("<td><center><a href='ControleUsuario.aspx?USUARIO_D=" + Criptografia.Encrypt(dtr["ID"].ToString()) + "'><i class='fa fa-trash'></i></center></td>");
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }

        private void carregarTabelaCliente(string Perfil)
        {
            DataTable rDta = new DataTable();
            rDta = dalUsu.buscarUsuariosClientesAtivos(Perfil);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th><center>ID</th></center>");
            sb.AppendLine("<th><center>RESERVA</th></center>");
            sb.AppendLine("<th><center>DATA INICIO</th></center>");
            sb.AppendLine("<th><center>DATA FIM</th></center>");
            sb.AppendLine("<th><center>EDITAR</th></center>");
            sb.AppendLine("<th><center>INATIVAR</th></center>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td><center>" + dtr["ID"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["LOGIN"] + "</td></center>");
                sb.AppendLine("<td><center>" + Convert.ToDateTime(dtr["DATA_INICIO"]).ToString("dd/MM/yyyy") + "</td></center>");
                sb.AppendLine("<td><center>" + Convert.ToDateTime(dtr["DATA_FIM"]).ToString("dd/MM/yyyy") + "</td></center>");
                sb.AppendLine("<td><center><a href='ControleUsuario.aspx?CLIENTE_E=" + Criptografia.Encrypt(dtr["ID"].ToString()) + "'><i class='fa fa-edit'></i></center></td>");
                sb.AppendLine("<td><center><a href='ControleUsuario.aspx?USUARIO_D=" + Criptografia.Encrypt(dtr["ID"].ToString()) + "'><i class='fa fa-trash'></i></center></td>");
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }

        protected void lnkSenha_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.ToUpper();
            DALPerfilUsuario dalPerfUsu = new DALPerfilUsuario();
            DALUsuario dalUsu = new DALUsuario();
            Usuario usu = dalUsu.buscaUsuarioLogin(login);
            PerfilUsuario perfUsu = dalPerfUsu.buscarUsuarioPerfil(usu.Id);
            if (txtNome.Text != "" && txtLogin.Text != "" && txtNovaSenha.Text != "" && txtConfirmaSenha.Text != "" && ddlPerfilNovoUsu.SelectedValue != "SELECIONE")
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
                    else if(usu.Login == "")
                    {
                        
                        usu.Nome = txtNome.Text.ToUpper();
                        usu.Login = txtLogin.Text.ToUpper();
                        usu.Senha = Criptografia.Encrypt(txtNovaSenha.Text);
                        dalUsu.inserirUsuario(usu);   
                        usu = dalUsu.buscaUsuarioLogin(usu.Login);
                        perfUsu.Perfil = int.Parse(ddlPerfilNovoUsu.SelectedValue);
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
                string msg = "<script> alert('Preencha todos os campos!'); </script>";
                Response.Write(msg);
            }
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtLogin.Text = "";
            txtNovaSenha.Text = "";
            txtConfirmaSenha.Text = "";
            ddlPerfil.SelectedIndex = -1;
            txtCdReservaE.Text = "";
            txtCodReserva.Text = "";
            txtDataFim.Text = "";
            txtDataFimE.Text = "";
            txtDataIni.Text = "";
            txtDataIniE.Text = "";
            ddlPerfilNovoUsu.SelectedIndex = -1;
            txtSenhaRand.Text = "";
            dtInicio.SelectedDate = DateTime.Now;
            dtFim.SelectedDate = DateTime.Now;
            dtInicioE.SelectedDate = DateTime.Now;
            dtFimE.SelectedDate = DateTime.Now;
            dtFimE.SelectedDate = DateTime.Now;


        }

        private void carregaDdl()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT ID, UPPER(PERFIL) AS PERFIL FROM PERFIL  ORDER BY PERFIL ", connection))
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

        private void carregaDdlNovoUsuario()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT ID, UPPER(PERFIL) AS PERFIL FROM PERFIL WHERE ID <> 3 ORDER BY PERFIL", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        ddlPerfilNovoUsu.DataTextField = "PERFIL";
                        ddlPerfilNovoUsu.DataValueField = "ID";
                        ddlPerfilNovoUsu.DataSource = dta.Copy();
                        ddlPerfilNovoUsu.DataBind();
                        ddlPerfilNovoUsu.Items.Insert(0, "SELECIONE");
                    }
                    catch (Exception erro)
                    {
                        throw new Exception(erro.Message);
                    }

                }
            }
        }

        protected void novoUsuario_Click(object sender, EventArgs e)
        {
            mdBack.Visible = true;
            mdUsu.Visible = true;
            carregaDdlNovoUsuario();

        }

        protected void lnkVoltar_Click(object sender, EventArgs e)
        {
            mdBack.Visible = false;
            mdUsu.Visible = false;
            mdCli.Visible = false;
            modEditCli.Visible = false;
            limparCampos();
        }

        protected void novoCliente_Click(object sender, EventArgs e)
        {
            mdBack.Visible = true;
            mdCli.Visible = true;
        }


        protected void salvarNovoCliente_Click(object sender, EventArgs e)
        {
            if (txtCodReserva.Text != "")
            {
                string sCdReserva = txtCodReserva.Text.ToUpper();
                txtSenhaRand.Text = SenhaRandomica.RandLetras(3) + SenhaRandomica.RandNumeros(5);
                DALCliente dalCli = new DALCliente();
                Cliente cli = new Cliente();
                cli.Cd_Reserva = sCdReserva;
                cli.DataInicio = dtInicio.SelectedDate;               
                cli.DataFim = dtFim.SelectedDate;
                dalCli.inserirCliente(cli);
                Usuario usu = new Usuario();
                usu.Login = sCdReserva;
                usu.Senha = Criptografia.Encrypt(txtSenhaRand.Text);
                usu.Nome = sCdReserva;
                dalUsu.inserirUsuario(usu);
                usu = dalUsu.buscaUsuarioLogin(sCdReserva);
                PerfilUsuario perfUsu = new PerfilUsuario();
                perfUsu.Perfil = 3;
                perfUsu.ID_USUARIO = usu.Id;
                dalPerfUsu.inserirPerfil(perfUsu);
                txtDataIni.Text = cli.DataInicio.ToString();
                txtDataFim.Text = cli.DataFim.ToString();
                string msg = "<script> alert('Cadastro realizado!'); </script>";
                Response.Write(msg);

            }
            else
            {
                string msg = "<script> alert('Insira o Código da Reserva!'); </script>";
                Response.Write(msg);

            }


        }

        protected void alterarData_Click(object sender, EventArgs e)
        {
            DALCliente dalCliente = new DALCliente();
            Cliente cli = dalCliente.buscarClienteReserva(txtCdReservaE.Text.ToUpper());
            cli.DataFim = dtFimE.SelectedDate;
            dalCliente.alterarCliente(cli);
            txtDataFimE.Text = dtFimE.SelectedDate.ToString("dd/MM/yyyy");
            string msg = "<script> alert('Data Alterada!'); </script>";
            Response.Write(msg);


        }

        protected void ddlPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPerfil.Text != "SELECIONE")
            {
                if (ddlPerfil.SelectedValue != "3")
                {
                    carregarTabela(ddlPerfil.SelectedValue.ToString());
                }
                else
                {
                    carregarTabelaCliente(ddlPerfil.SelectedValue.ToString());
                }

            }

        }

    }
}

