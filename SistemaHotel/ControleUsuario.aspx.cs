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
        // classes de persistência com o banco de dados
        DALPerfilUsuario dalPerfUsu = new DALPerfilUsuario();
        DALUsuario dalUsu = new DALUsuario();
        DALCliente dalCli = new DALCliente();
        DALEquipeAtendimento dalEqui = new DALEquipeAtendimento();

        protected void Page_Load(object sender, EventArgs e)
        {
            int rParametro = 0;

            if (!IsPostBack)
            {

                if (Request.QueryString["USUARIO_D"] != null)
                {
                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["USUARIO_D"]));

                    Usuario usu = dalUsu.buscarUsuarioId(rParametro);

                    if (usu.IdUsuario != 0)
                    {
                        dalPerfUsu.excluirUsuario(usu.IdUsuario);
                        string msg = "<script> alert('Usuário Excluído!'); </script>";
                        Response.Write(msg);

                    }
                }
                if (Request.QueryString["CLIENTE_E"] != null)
                {

                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["CLIENTE_E"]));

                    Usuario usu = dalUsu.buscarUsuarioId(rParametro);
                   
                    Cliente cli = dalCli.buscarClienteReserva(usu.Login);
                    txtCdReservaE.Text = cli.CodReserva;
                    txtQuartoE.Text = cli.Quarto;
                    txtNomeClienteE.Text = cli.NomeCliente;
                    txtDataIni.Text = cli.DataEntrada.ToString("dd/MM/yyyy HH:mm");
                    txtDataIni.Text = cli.DataSaida.ToString("dd/MM/yyyy HH:mm");
                    txtDataIniE.Text = cli.DataEntrada.ToString("dd/MM/yyyy HH:mm");
                    txtDataFimE.Text = cli.DataSaida.ToString("dd/MM/yyyy HH:mm");
                    modEditCli.Visible = true;
                }
                carregaDdl();
            }

        }

        #region ControleUsuario

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
            sb.AppendLine("<th><center>EXCLUIR</th></center>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td><center>" + dtr["ID_Usuario"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["NOME_USUARIO"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["LOGIN"] + "</td></center>");
                sb.AppendLine("<td><center><a href='ControleUsuario.aspx?USUARIO_D=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-trash'></i></center></td>");
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }

        protected void lnkSenha_Click(object sender, EventArgs e)
        {
            //trecho relacionado a busca de usuário pelo login para ver se ele já é cadastrado no banco
            string login = txtLogin.Text;
            Usuario usu = dalUsu.buscaUsuarioLogin(login);

            //varifica se todos os campos estão preenchidos
            if (!string.IsNullOrEmpty(txtLogin.Text) && !string.IsNullOrEmpty(txtNovaSenha.Text) && !string.IsNullOrEmpty(txtConfirmaSenha.Text) && ddlPerfilNovoUsu.SelectedValue != "0")
            {
                // verifica se as senhas são iguais
                if (txtNovaSenha.Text == txtConfirmaSenha.Text)
                {
                    //se o perfil estiver atívo retorna a mensagem de já cadastrado
                    if (usu.Login != "")
                    {
                        string msg = "<script> alert('Usuário já cadastrado!'); </script>";
                        Response.Write(msg);

                    }
                    //se a consulta no banco retornar um login vazio ele cadastra o Usuário
                    else if (usu.Login == "")
                    {
                        //campos relacionados passagem devalores dos textbox para os atributos do objeto Usuário
                        usu.NomeUsuario = txtNome.Text;
                        usu.Login = txtLogin.Text;
                        usu.Senha = Criptografia.Encrypt(txtNovaSenha.Text);
                        //insere o objeto Usuário
                        dalUsu.inserirUsuario(usu);
                        //recupera o usuário recém cadastrado para inserir o perfil
                        usu = dalUsu.buscaUsuarioLogin(usu.Login);
                        //novo objeto PerfilUsuario
                        PerfilUsuario perfUsu = new PerfilUsuario();
                        //campos relacionados passagem devalores dos textbox para os atributos do objeto PerfilUsuário
                        perfUsu.IdPerfil = int.Parse(ddlPerfilNovoUsu.SelectedValue);
                        perfUsu.IdUsuario = usu.IdUsuario;
                        perfUsu.StatusPerfilUsuario = 'S';
                        //insere o objeto PerfilUsuário
                        dalPerfUsu.inserirPerfilUsuario(perfUsu);
                        //campos relacionados a criação do Usuário na EquipeAtendimento
                        EquipeAtendimento equi = new EquipeAtendimento();
                        equi.NomeUsuario = usu.NomeUsuario;
                        equi.IdUsuario= usu.IdUsuario;
                        equi.IdPerfil = perfUsu.IdPerfil;
                        dalEqui.InserirEquipeAtendimento(equi);
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
                    finally
                    {
                        cmd.Connection.Close();
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

        #endregion

        #region ControleCliente

        private void carregarTabelaCliente(string Perfil)
        {
            DataTable rDta = new DataTable();
            rDta = dalUsu.buscarUsuariosClientesAtivos(Perfil);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th><center>ID</th></center>");
            sb.AppendLine("<th><center>CÓDIGO DA RESERVA</th></center>");
            sb.AppendLine("<th><center>QUARTO</th></center>");
            sb.AppendLine("<th><center>NOME</th></center>");
            sb.AppendLine("<th><center>DATA INICIO</th></center>");
            sb.AppendLine("<th><center>DATA FIM</th></center>");
            sb.AppendLine("<th><center>EDITAR/DATA FIM</th></center>");
            sb.AppendLine("<th><center>EXCLUIR</th></center>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td><center>" + dtr["ID_Usuario"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["LOGIN"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["Quarto"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["Nome_Usuario"] + "</td></center>");
                sb.AppendLine("<td><center>" + Convert.ToDateTime(dtr["DATA_Entrada"]).ToString("dd/MM/yyyy") + "</td></center>");
                sb.AppendLine("<td><center>" + Convert.ToDateTime(dtr["DATA_Saida"]).ToString("dd/MM/yyyy") + "</td></center>");
                sb.AppendLine("<td><center><a href='ControleUsuario.aspx?CLIENTE_E=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-edit'></i></center></td>");
                sb.AppendLine("<td><center><a href='ControleUsuario.aspx?USUARIO_D=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-trash'></i></center></td>");
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }

        protected void novoCliente_Click(object sender, EventArgs e)
        {
            mdBack.Visible = true;
            mdCli.Visible = true;
        }

        protected void salvarNovoCliente_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(txtCodReserva.Text) && !string.IsNullOrEmpty(txtInputDataIni.Text) && !string.IsNullOrEmpty(txtInputDataFim.Text))
            {

                string sCdReserva = txtCodReserva.Text;
                Usuario usu = new Usuario();
                //busca o usuário para ver se já está cadastrado no banco
                usu = dalUsu.buscaUsuarioLogin(sCdReserva);

                if (usu.Login == "")
                {
                    DateTime dataIni = Convert.ToDateTime(txtInputDataIni.Text);
                    DateTime dataFim = Convert.ToDateTime(txtInputDataFim.Text);

                    if (dataIni > DateTime.Now)
                    {
                        if (dataIni < dataFim)
                        {
                            //campos relacionados ao cadastro de cliente                           
                            Cliente cli = new Cliente();
                            cli.CodReserva = sCdReserva;
                            cli.Quarto = txtQuarto.Text;
                            cli.NomeCliente = txtNomeCliente.Text;
                            cli.DataEntrada = dataIni;
                            cli.DataSaida = dataFim;
                            dalCli.inserirCliente(cli);


                            //campos relacionados ao cadastro de usuário
                            usu.Login = sCdReserva;
                            usu.NomeUsuario = txtNomeCliente.Text;
                            txtSenhaRand.Text = SenhaRandomica.RandLetras(5) + SenhaRandomica.RandNumeros(3);
                            usu.Senha = Criptografia.Encrypt(txtSenhaRand.Text);
                            dalUsu.inserirUsuario(usu);

                            //busca o usuário que cadastrou no banco
                            usu = dalUsu.buscaUsuarioLogin(sCdReserva);

                            //campos relacionados ao cadastro do perfil do usuário
                            PerfilUsuario perfUsu = new PerfilUsuario();
                            perfUsu.IdPerfil = 3;
                            perfUsu.IdUsuario = usu.IdUsuario;
                            perfUsu.StatusPerfilUsuario = 'S';
                            dalPerfUsu.inserirPerfilUsuario(perfUsu);

                            //campos de retorno das datas cadastradas
                            txtDataIni.Text = cli.DataEntrada.ToString("dd/MM/yyyy HH:mm");
                            txtDataFim.Text = cli.DataEntrada.ToString("dd/MM/yyyy HH:mm");

                            string msg = "<script> alert('Cadastro realizado!'); </script>";
                            Response.Write(msg);
                        }
                        else
                        {
                            string msg = "<script> alert('Datas não permitidas!'); </script>";
                            Response.Write(msg);

                        }
                    }
                    else
                    {
                        string msg = "<script> alert('Datas não permitidas!'); </script>";
                        Response.Write(msg);
                    }

                }
                else
                {
                    string msg = "<script> alert('Cliente já cadastrado!'); </script>";
                    Response.Write(msg);
                }

            }
            else
            {
                string msg = "<script> alert('Preencha Todos os campos!'); </script>";
                Response.Write(msg);
            }


        }

        protected void alterarData_Click(object sender, EventArgs e)
        {
            //data de saída atual
            DateTime dataFim = Convert.ToDateTime(txtDataFimE.Text);
            //nova data de saída
            DateTime novaDataFim = Convert.ToDateTime(txtInputDataFimE.Text);

            if (novaDataFim > DateTime.Now && novaDataFim > dataFim)
            {
                //campos relacionados a busca do cliente pelo cod_reserva
                DALCliente dalCliente = new DALCliente();
                Cliente cli = dalCliente.buscarClienteReserva(txtCdReservaE.Text.ToUpper());
                //alteração da data de saída
                cli.DataSaida = Convert.ToDateTime(novaDataFim);
                dalCliente.alterarCliente(cli);
                txtDataFimE.Text = novaDataFim.ToString();
                string msg = "<script> alert('Data Alterada!'); </script>";
                Response.Write(msg);
            }
            else
            {
                string msg = "<script> alert('Data não permitida!!'); </script>";
                Response.Write(msg);

            }

        }

        #endregion

        #region Geral
        private void limparCampos()
        {
            txtNome.Text = "";
            txtLogin.Text = "";
            txtNovaSenha.Text = "";
            txtConfirmaSenha.Text = "";
            ddlPerfil.SelectedIndex = -1;
            txtCdReservaE.Text = "";
            txtCodReserva.Text = "";
            txtQuarto.Text = "";
            txtQuartoE.Text = "";
            txtNomeCliente.Text = "";
            txtNomeClienteE.Text = "";
            txtDataFim.Text = "";
            txtDataFimE.Text = "";
            txtDataIni.Text = "";
            txtDataIniE.Text = "";
            ddlPerfilNovoUsu.SelectedIndex = -1;
            txtSenhaRand.Text = "";
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


        protected void lnkVoltar_Click(object sender, EventArgs e)
        {
            mdBack.Visible = false;
            mdUsu.Visible = false;
            mdCli.Visible = false;
            modEditCli.Visible = false;
            limparCampos();
        }

        protected void ddlPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPerfil.SelectedValue != "0")
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

        #endregion

    }
}

