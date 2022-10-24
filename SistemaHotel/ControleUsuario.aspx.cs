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
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";
        // classes de persistência com o banco de dados

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["perfil"].ToString() == "Administração")
                {
                    int rParametro = 0;

                    if (!IsPostBack)
                    {

                        if (Request.QueryString["USUARIO_D"] != null)
                        {
                            rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["USUARIO_D"]));
                            DALPerfilUsuario.inativarUsuario(rParametro);
                            //string msg = $"<script> alert('Usuário Inativado: ID {rParametro}'); </script>";
                            //Response.Write(msg);
                            Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                    Usuário Inativado: ID {rParametro}
                                    <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                        }
                        if (Request.QueryString["USUARIO_E"] != null)
                        {


                            rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["USUARIO_E"]));
                            Usuario usu = DALUsuario.buscarUsuarioId(rParametro);
                            PerfilUsuario perfUsu = DALPerfilUsuario.buscarUsuarioPerfil(usu.IdUsuario);

                            carregaDdlUsuarioE();
                            txtIdUsuarioE.Text = usu.IdUsuario.ToString();
                            txtNomeE.Text = usu.NomeUsuario;
                            txtSobrenomeE.Text = usu.SobrenomeUsuario;
                            ddlPerfilUsuE.SelectedValue = perfUsu.IdPerfil.ToString();
                            txtLoginE.Text = usu.Login;
                            mdBack.Visible = true;
                            mdUsuE.Visible = true;
                        }
                        if (Request.QueryString["CLIENTE_E"] != null)
                        {
                            carregaDdlQuartoE();
                            rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["CLIENTE_E"]));
                            Usuario usu = DALUsuario.buscarUsuarioId(rParametro);
                            Cliente cli = DALCliente.buscarClienteReserva(usu.Login);
                            txtCdReservaE.Text = cli.CodReserva;
                            ddlQuartoE.SelectedValue = cli.IdQuarto.ToString();
                            txtNomeClienteE.Text = cli.NomeCliente + " " + cli.SobreNomeCliente;
                            txtDataIniE.Text = cli.DataEntrada.ToString("dd/MM/yyyy HH:mm");
                            txtDataFimE.Text = cli.DataSaida.ToString("dd/MM/yyyy HH:mm");
                            mdBack.Visible = true;
                            modEditCli.Visible = true;
                        }
                        if (Request.QueryString["USUARIO_A"] != null)
                        {

                            rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["USUARIO_A"]));
                            Usuario usu = DALUsuario.buscarUsuarioId(rParametro);
                            PerfilUsuario perfUsu = DALPerfilUsuario.buscarUsuarioPerfil(usu.IdUsuario);
                            if (perfUsu.IdPerfil == 3)
                            {
                                carregaDdlQuartoE();
                                Cliente cli = DALCliente.buscarClienteReserva(usu.Login);
                                txtCdReservaE.Text = cli.CodReserva;
                                ddlQuartoE.SelectedValue = cli.IdQuarto.ToString();
                                txtNomeClienteE.Text = cli.NomeCliente + " " + cli.SobreNomeCliente;
                                txtDataIni.Text = cli.DataEntrada.ToString("dd/MM/yyyy HH:mm");
                                txtDataIni.Text = cli.DataSaida.ToString("dd/MM/yyyy HH:mm");
                                txtDataIniE.Text = cli.DataEntrada.ToString("dd/MM/yyyy HH:mm");
                                txtDataFimE.Text = cli.DataSaida.ToString("dd/MM/yyyy HH:mm");
                                mdBack.Visible = true;
                                modEditCli.Visible = true;
                                mdBack.Visible = true;
                                modEditCli.Visible = true;
                            }
                            else
                            {
                                DALPerfilUsuario.ativarUsuario(rParametro);
                                //string msg = $"<script> alert('Usuário Ativado! ID:{rParametro}'); </script>";
                                //Response.Write(msg);
                                Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                    Usuário Ativado! ID:{rParametro}
                                    <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                            }
                        }
                        carregaDdl();
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }

            }
            catch (Exception)
            {

                Response.Redirect("~/Default.aspx");
            }

        }

        #region ControleUsuario

        private void carregarTabela(string Perfil, string Status)
        {
            DataTable rDta = new DataTable();
            rDta = DALUsuario.buscarUsuariosPerfilStatus(Perfil, Status);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='tabelaUsuarios' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>ID</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>NOME</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>LOGIN</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>STATUS</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>EDITAR</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>ATIVAR/INATIVAR</center></th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["ID_Usuario"] + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["NOME"] + " " + dtr["SOBRENOME"] + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["LOGIN"] + "</center></td>");
                if (dtr["STATUS_USUARIO"].ToString() == "S")
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["STATUS_USUARIO"].ToString().Replace("S", "ATIVO") + "</center></td>");
                }
                else
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["STATUS_USUARIO"].ToString().Replace("N", "INATIVO") + "</center></td>");
                }
                if (dtr["ID_Perfil"].ToString() == "3")
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href='ControleUsuario.aspx?CLIENTE_E=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-edit' style='color: blue'></i></center></td>");
                }
                else
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href='ControleUsuario.aspx?USUARIO_E=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-edit' style='color: blue'></i></center></td>");
                }

                if (dtr["STATUS_USUARIO"].ToString() == "S")
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href='ControleUsuario.aspx?USUARIO_D=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-power-off' style='color: red'></i></center></td>");
                }
                else
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href='ControleUsuario.aspx?USUARIO_A=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-power-off' style='color: green'></i></center></td>");
                }

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
            Usuario usu = DALUsuario.buscaUsuarioLogin(login);

            //varifica se todos os campos estão preenchidos
            if (!string.IsNullOrEmpty(txtLogin.Text) && !string.IsNullOrEmpty(txtNovaSenha.Text) && !string.IsNullOrEmpty(txtConfirmaSenha.Text) && ddlPerfilNovoUsu.SelectedValue != "SELECIONE")
            {
                if (txtNovaSenha.Text.Length >= 8 && txtConfirmaSenha.Text.Length >= 8)
                {
                    // verifica se as senhas são iguais
                    if (txtNovaSenha.Text == txtConfirmaSenha.Text)
                    {
                        //se o perfil estiver atívo retorna a mensagem de já cadastrado
                        if (usu.Login != "")
                        {
                            //string msg = "<script> alert('Usuário já cadastrado!'); </script>";
                            //Response.Write(msg);
                            Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                  Usuário já cadastrado!
                                    <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");




                        }
                        //se a consulta no banco retornar um login vazio ele cadastra o Usuário
                        else if (usu.Login == "")
                        {
                            //campos relacionados passagem devalores dos textbox para os atributos do objeto Usuário
                            usu.NomeUsuario = txtNome.Text;
                            usu.SobrenomeUsuario = txtSobreNome.Text;
                            usu.Login = txtLogin.Text;
                            usu.Senha = Criptografia.Encrypt(txtNovaSenha.Text);
                            //insere o objeto Usuário
                            DALUsuario.inserirUsuario(usu);
                            //recupera o usuário recém cadastrado para inserir o perfil
                            usu = DALUsuario.buscaUsuarioLogin(usu.Login);
                            //novo objeto PerfilUsuario
                            PerfilUsuario perfUsu = new PerfilUsuario();
                            //campos relacionados passagem devalores dos textbox para os atributos do objeto PerfilUsuário
                            perfUsu.IdPerfil = int.Parse(ddlPerfilNovoUsu.SelectedValue);
                            perfUsu.IdUsuario = usu.IdUsuario;
                            perfUsu.StatusPerfilUsuario = 'S';
                            //insere o objeto PerfilUsuário
                            DALPerfilUsuario.inserirPerfilUsuario(perfUsu);
                            //campos relacionados a criação do Usuário na Administração
                            if (ddlPerfilNovoUsu.SelectedValue == "1")
                            {
                                Administracao adm = new Administracao();
                                adm.IdUsuario = usu.IdUsuario;
                                adm.IdPerfil = perfUsu.IdPerfil;
                                DALAdministracao.inserirAdministracao(adm);
                            }
                            //campos relacionados a criação do Usuário na Funcionario
                            else
                            {
                                Funcionario fun = new Funcionario();
                                fun.IdUsuario = usu.IdUsuario;
                                fun.IdPerfil = perfUsu.IdPerfil;
                                DALFuncionario.inserirFuncionario(fun);

                            }

                            //string msg = "<script> alert('Cadastro realizado!'); </script>";
                            //Response.Write(msg);
                            Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                  Cadastro realizado!
                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                            limparCampos();
                        }
                    }
                    else
                    {
                        //string msg = "<script> alert('Senhas Diferentes!'); </script>";
                        //Response.Write(msg);
                        Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                 Senhas Diferentes!
                    <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");

                    }

                }
                else
                {
                    //string msg = "<script> alert('Senha mínimo 8 caracteres!'); </script>";
                    //Response.Write(msg);
                    Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                 Senha mínimo 8 caracteres!
                    <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");

                }


            }
            else
            {
                //string msg = "<script> alert('Preencha todos os campos!'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                               Preencha todos os campos!
                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
            }
        }

        private void carregaDdlNovoUsuario()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT ID_PERFIL, UPPER(DESCRICAO_PERFIL) AS PERFIL FROM PERFIL WHERE ID_PERFIL <> 3 ORDER BY PERFIL", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        ddlPerfilNovoUsu.DataTextField = "PERFIL";
                        ddlPerfilNovoUsu.DataValueField = "ID_PERFIL";
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
        private void carregaDdlUsuarioE()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT ID_PERFIL, UPPER(DESCRICAO_PERFIL) AS PERFIL FROM PERFIL WHERE ID_PERFIL <> 3 ORDER BY PERFIL", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        ddlPerfilUsuE.DataTextField = "PERFIL";
                        ddlPerfilUsuE.DataValueField = "ID_PERFIL";
                        ddlPerfilUsuE.DataSource = dta.Copy();
                        ddlPerfilUsuE.DataBind();
                        ddlPerfilUsuE.Items.Insert(0, "SELECIONE");
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

        protected void lnkAlterarUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuR = DALUsuario.buscarUsuarioId(int.Parse(txtIdUsuarioE.Text));
            PerfilUsuario perfUsuR = DALPerfilUsuario.buscarUsuarioPerfil(usuR.IdUsuario);
            //varifica se todos os campos estão preenchidos
            if (!string.IsNullOrEmpty(txtLoginE.Text) && ddlPerfilUsuE.SelectedValue != "SELECIONE")
            {

                Usuario usu = new Usuario();
                //campos relacionados passagem devalores dos textbox para os atributos do objeto Usuário
                usu.NomeUsuario = txtNomeE.Text;
                usu.SobrenomeUsuario = txtSobrenomeE.Text;
                usu.Login = txtLoginE.Text;
                usu.IdUsuario = int.Parse(txtIdUsuarioE.Text);
                //altera o objeto Usuário
                DALUsuario.alterarUsuario(usu);
                //objeto PerfilUsuario
                PerfilUsuario perfUsu = new PerfilUsuario();
                //campos relacionados passagem devalores dos textbox para os atributos do objeto PerfilUsuário
                perfUsu.IdPerfil = int.Parse(ddlPerfilUsuE.SelectedValue);
                perfUsu.IdUsuario = usu.IdUsuario;
                //insere o objeto PerfilUsuário
                DALPerfilUsuario.alterarPefilUsuario(perfUsu);
                //campos relacionados a criação do Usuário na Administração
                if (ddlPerfilUsuE.SelectedValue == "1")
                {
                    Administracao adm = new Administracao();
                    adm = DALAdministracao.buscarAdmIdUsuario(int.Parse(txtIdUsuarioE.Text));
                    if (adm.IdAdm == 0)
                    {
                        adm.IdUsuario = perfUsu.IdUsuario;
                        adm.IdPerfil = perfUsu.IdPerfil;
                        DALAdministracao.inserirAdministracao(adm);

                    }

                }
                else
                {
                    Funcionario fun = new Funcionario();
                    fun = DALFuncionario.buscarFuncionarioIdUsuario(int.Parse(txtIdUsuarioE.Text));
                    if (fun.IdFuncionario == 0)
                    {
                        fun.IdUsuario = perfUsu.IdUsuario;
                        fun.IdPerfil = perfUsu.IdPerfil;
                        DALFuncionario.inserirFuncionario(fun);
                    }
                }
                //string msg = $"<script> alert('Usuário Atualizado: ID {txtIdUsuarioE.Text}'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                               Usuário Atualizado: ID {txtIdUsuarioE.Text}
                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
            }


            else
            {
                //string msg = "<script> alert('Preencha todos os campos!'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                           Preencha todos os campos!
                                            </div>");
            }

        }

        #endregion

        #region ControleCliente

        private void carregarTabelaClientes(string Perfil, string Status)
        {
            DataTable rDta = new DataTable();
            rDta = DALUsuario.buscarUsuariosClientesStatus(Perfil, Status);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='tabelaClientes' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>ID</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>CÓDIGO DA RESERVA</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>QUARTO</th></center>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>NOME</th></center>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>DATA INICIO</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>DATA FIM</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>STATUS</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>EDITAR</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>ATIVAR/INATIVAR</center></th>");


            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["ID_USUARIO"] + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["LOGIN"] + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["NUMERO_QUARTO"] + " - " + dtr["DESCRICAO_QUARTO"] + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["NOME"] + " " + dtr["SOBRENOME"] + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + Convert.ToDateTime(dtr["DATA_Entrada"]).ToString("dd/MM/yyyy HH:mm") + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + Convert.ToDateTime(dtr["DATA_SAIDA"]).ToString("dd/MM/yyyy HH:mm") + "</center></td>");
                if (dtr["STATUS_USUARIO"].ToString() == "S")
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["STATUS_USUARIO"].ToString().Replace("S", "ATIVO") + "</center></td>");
                }
                else
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["STATUS_USUARIO"].ToString().Replace("N", "INATIVO") + "</center></td>");
                }
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href='ControleUsuario.aspx?CLIENTE_E=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-edit' style='color: blue'></i></center></td>");
                if (dtr["STATUS_USUARIO"].ToString() == "S")
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href='ControleUsuario.aspx?USUARIO_D=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-power-off' style='color: red'></i></center></td>");
                }
                else
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href='ControleUsuario.aspx?USUARIO_A=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-power-off' style='color: green'></i></center></td>");
                }
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
            carregaDdlQuarto();

        }

        protected void salvarNovoCliente_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(txtCodReserva.Text) && !string.IsNullOrEmpty(txtInputDataIni.Text) && !string.IsNullOrEmpty(txtInputDataFim.Text) && ddlQuarto.SelectedValue != "SELECIONE")
            {
                string sCdReserva = txtCodReserva.Text;
                Usuario usu = new Usuario();
                //busca o usuário para ver se já está cadastrado no banco
                usu = DALUsuario.buscaUsuarioLogin(sCdReserva);

                if (usu.Login == "")
                {
                    try
                    {
                        DateTime dataIni = DateTime.ParseExact(txtInputDataIni.Text, "dd/MM/yyyy HH:mm", null);
                        DateTime dataFim = DateTime.ParseExact(txtInputDataFim.Text, "dd/MM/yyyy HH:mm", null);

                        if (dataIni > DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", null))
                        {
                            if (dataIni < dataFim)
                            {
                                //campos relacionados ao cadastro de cliente                           
                                Cliente cli = new Cliente();
                                cli.CodReserva = sCdReserva;
                                cli.IdQuarto = int.Parse(ddlQuarto.SelectedValue);
                                cli.NomeCliente = txtNomeCliente.Text;
                                cli.SobreNomeCliente = txtSobrenomeCliente.Text;
                                cli.DataEntrada = dataIni;
                                cli.DataSaida = dataFim;
                                cli.FlagPedidoFrigobar = 'S';
                                //verifica se tem algum cliente ocupando o quarto com o id selecionado no DropDownList                           
                                DataTable dta = DALCliente.verificarOcupacaoQuarto(ddlQuarto.SelectedValue);

                                if (dta.Rows.Count > 0)
                                {
                                    DateTime dataOcupa = DateTime.ParseExact(Convert.ToDateTime(dta.Rows[0]["DATA_SAIDA"]).ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", null);
                                    if (dataOcupa < dataIni)
                                    {
                                        DALCliente.inserirCliente(cli);
                                        //campos relacionados ao cadastro de usuário
                                        usu.Login = sCdReserva;
                                        usu.NomeUsuario = txtNomeCliente.Text;
                                        usu.SobrenomeUsuario = txtSobrenomeCliente.Text;
                                        txtSenhaRand.Text = SenhaRandomica.RandLetras(5) + SenhaRandomica.RandNumeros(3);
                                        usu.Senha = Criptografia.Encrypt(txtSenhaRand.Text);
                                        DALUsuario.inserirUsuario(usu);

                                        //busca o usuário que cadastrou no banco
                                        usu = DALUsuario.buscaUsuarioLogin(sCdReserva);

                                        //campos relacionados ao cadastro do perfil do usuário
                                        PerfilUsuario perfUsu = new PerfilUsuario();
                                        perfUsu.IdPerfil = 3;
                                        perfUsu.IdUsuario = usu.IdUsuario;
                                        perfUsu.StatusPerfilUsuario = 'S';
                                        DALPerfilUsuario.inserirPerfilUsuario(perfUsu);

                                        //campos de retorno das datas cadastradas
                                        txtDataIni.Text = cli.DataEntrada.ToString("dd/MM/yyyy HH:mm");
                                        txtDataFim.Text = cli.DataSaida.ToString("dd/MM/yyyy HH:mm");

                                        //string msg = "<script> alert('Cadastro realizado!'); </script>";
                                        //Response.Write(msg);
                                        Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                                         Cadastro realizado!
                                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                                         </div>");

                                    }
                                    else
                                    {
                                        //string msg = $"<script> alert('Quarto {dta.Rows[0]["DESCRICAO_QUARTO"]} Ocupado até: {dataOcupa.ToString("dd/MM/yyyy HH:ss")} ID Cliente: {dta.Rows[0]["ID_CLIENTE"]}'); </script>";
                                        //Response.Write(msg);
                                        Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                                            Quarto {dta.Rows[0]["DESCRICAO_QUARTO"]} Ocupado até: {dataOcupa.ToString("dd/MM/yyyy HH: ss")} ID Cliente: {dta.Rows[0]["ID_CLIENTE"]}
                                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                                             </div>");

                                    }

                                }
                                else
                                {
                                    DALCliente.inserirCliente(cli);
                                    //campos relacionados ao cadastro de usuário
                                    usu.Login = sCdReserva;
                                    usu.NomeUsuario = txtNomeCliente.Text;
                                    usu.SobrenomeUsuario = txtSobrenomeCliente.Text;
                                    txtSenhaRand.Text = SenhaRandomica.RandLetras(5) + SenhaRandomica.RandNumeros(3);
                                    usu.Senha = Criptografia.Encrypt(txtSenhaRand.Text);
                                    DALUsuario.inserirUsuario(usu);

                                    //busca o usuário que cadastrou no banco
                                    usu = DALUsuario.buscaUsuarioLogin(sCdReserva);

                                    //campos relacionados ao cadastro do perfil do usuário
                                    PerfilUsuario perfUsu = new PerfilUsuario();
                                    perfUsu.IdPerfil = 3;
                                    perfUsu.IdUsuario = usu.IdUsuario;
                                    perfUsu.StatusPerfilUsuario = 'S';
                                    DALPerfilUsuario.inserirPerfilUsuario(perfUsu);

                                    //campos de retorno das datas cadastradas
                                    txtDataIni.Text = cli.DataEntrada.ToString("dd/MM/yyyy HH:mm");
                                    txtDataFim.Text = cli.DataEntrada.ToString("dd/MM/yyyy HH:mm");

                                    //string msg = "<script> alert('Cadastro realizado!'); </script>";
                                    //Response.Write(msg);
                                    Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                                    Cadastro realizado!
                                                    <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                                     </div>");

                                }

                            }
                            else
                            {
                                //string msg = "<script> alert('Datas não permitidas!'); </script>";
                                //Response.Write(msg);
                                Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                                Datas não permitidas!
                                                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                                </div>");
                            }

                        }
                        else
                        {
                            //string msg = "<script> alert('Datas não permitidas!'); </script>";
                            //Response.Write(msg);
                            Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                            Datas não permitidas!
                                            <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");


                        }

                    }
                    catch (Exception erro)
                    {
                           //string msg1 = $"<script> alert('{erro.Message}'); </script>";
                            //Response.Write(msg1);
                            Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                        por favor, inserir um horário
                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");                       

                    }

                }
                else
                {
                    //string msg = "<script> alert('Cliente já cadastrado!'); </script>";
                    //Response.Write(msg);
                    Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                       Cliente já cadastrado!
                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                }
            }
            else
            {
                //string msg = "<script> alert('Preencha Todos os campos!'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                    Preencha Todos os campos!
                    <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");

            }
        }

        protected void alterarData_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInputDataFimE.Text) && ddlQuartoE.SelectedValue != "SELECIONE")
            {
                //data de saída atual
                DateTime dataFim = DateTime.ParseExact(txtDataFimE.Text, "dd/MM/yyyy HH:mm", null);
                try
                {
                    //nova data de saída
                    // DateTime novaDataFim = DateTime.ParseExact($"{txtInputDataFimE.Text} {ddlInputHoraFimE}", "dd/MM/yyyy HH:mm", null);
                    DateTime novaDataFim = DateTime.ParseExact(txtInputDataFimE.Text, "dd/MM/yyyy HH:mm", null);

                    if (novaDataFim > DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", null) && novaDataFim > dataFim)
                    {
                        //campos relacionados a busca do cliente pelo cod_reserva
                        Cliente cli = DALCliente.buscarClienteReserva(txtCdReservaE.Text.ToUpper());
                        //alteração da data de saída
                        cli.DataSaida = Convert.ToDateTime(novaDataFim);
                        //flag para poder fazer outro pedido de frigobar
                        cli.FlagPedidoFrigobar = 'S';
                        cli.IdQuarto = int.Parse(ddlQuartoE.SelectedValue);

                        DataTable dta = DALCliente.verificarOcupacaoQuarto(ddlQuartoE.SelectedValue);
                        if (dta.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dta.Rows[0]["ID_CLIENTE"]) == cli.IdCliente)
                            {
                                //alterar a data de saída do cliente
                                DALCliente.alterarCliente(cli);
                                txtDataFimE.Text = novaDataFim.ToString("dd/MM/yyyy HH:mm");
                                //verifica se o perfil usuário está  inativo e ativa
                                Usuario u = DALUsuario.buscaUsuarioLogin(cli.CodReserva);
                                PerfilUsuario pu = DALPerfilUsuario.buscarUsuarioPerfil(u.IdUsuario);
                                if (pu.StatusPerfilUsuario == 'N')
                                {
                                    DALPerfilUsuario.ativarUsuario(u.IdUsuario);
                                }
                                //string msg = $"<script> alert('Data Alterada {novaDataFim.ToString("dd/MM/yyyy HH:mm")} ID Cliente {cli.IdCliente}'); </script>";
                                //Response.Write(msg);
                                Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                        Data Alterada {novaDataFim.ToString("dd/MM/yyyy HH:mm")} ID Cliente {cli.IdCliente}
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");

                            }
                            else if (DateTime.ParseExact(Convert.ToDateTime(dta.Rows[0]["DATA_SAIDA"]).ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", null) < DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", null))
                            {
                                //alterar a data de saída do cliente
                                DALCliente.alterarCliente(cli);
                                txtDataFimE.Text = novaDataFim.ToString("dd/MM/yyyy HH:mm");
                                //verifica se o perfil usuário está  inativo e ativa
                                Usuario u = DALUsuario.buscaUsuarioLogin(cli.CodReserva);
                                PerfilUsuario pu = DALPerfilUsuario.buscarUsuarioPerfil(u.IdUsuario);
                                if (pu.StatusPerfilUsuario == 'N')
                                {
                                    DALPerfilUsuario.ativarUsuario(u.IdUsuario);
                                }
                                //string msg = $"<script> alert('Data Alterada {novaDataFim.ToString("dd/MM/yyyy HH:mm")} ID Cliente {cli.IdCliente}'); </script>";
                                //Response.Write(msg);
                                Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                        Data Alterada {novaDataFim.ToString("dd/MM/yyyy HH:mm")} ID Cliente {cli.IdCliente}
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");

                            }
                            else
                            {
                                //string msg = $"<script> alert('Quarto {dta.Rows[0]["DESCRICAO_QUARTO"]} Ocupado até: {DateTime.ParseExact(Convert.ToDateTime(dta.Rows[0]["DATA_SAIDA"]).ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", null)} ID Cliente: {dta.Rows[0]["ID_CLIENTE"]}'); </script>";
                                //Response.Write(msg);
                                Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                  Quarto {dta.Rows[0]["DESCRICAO_QUARTO"]} Ocupado até: {DateTime.ParseExact(Convert.ToDateTime(dta.Rows[0]["DATA_SAIDA"]).ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", null)} ID Cliente: {dta.Rows[0]["ID_CLIENTE"]}
                    <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                            }

                        }
                        else
                        {
                            DALCliente.alterarCliente(cli);
                            Usuario usu = DALUsuario.buscaUsuarioLogin(cli.CodReserva);
                            PerfilUsuario perfUsu = DALPerfilUsuario.buscarUsuarioPerfil(usu.IdUsuario);
                            if (perfUsu.StatusPerfilUsuario != 'S')
                            {
                                DALPerfilUsuario.ativarUsuario(usu.IdUsuario);
                            }
                            //txtDataFimE.Text = novaDataFim.ToString();
                            //string msg = $"<script> alert('Data Alterada: ID Cliente:{cli.IdCliente} Data:{novaDataFim}!'); </script>";
                            //Response.Write(msg);
                            Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                    Data Alterada: ID Cliente:{cli.IdCliente} Data:{novaDataFim}!
                                    <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                    </div>");
                        }
                    }
                    else
                    {
                        //string msg = "<script> alert('Data não permitida!'); </script>";
                        //Response.Write(msg);
                        Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                        Data não permitida!
                                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                    </div>");

                    }

                }
                catch (Exception erro)
                {

                    //string msg1 = $"<script> alert('{erro.Message}'); </script>";
                    //Response.Write(msg1);
                    Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                     por favor, inserir um horário
                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                }

            }
            else
            {
                //string msg = "<script> alert('Preencha Todos os campos!'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                     Preencha todos os campos!
                    <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
            }



        }

        private void carregaDdlQuarto()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT ID_QUARTO,CONCAT(NUMERO_QUARTO,' - ', UPPER(DESCRICAO_QUARTO))AS DESCRICAO FROM QUARTO WHERE STATUS_QUAR ='S' ORDER BY DESCRICAO", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        ddlQuarto.DataTextField = "DESCRICAO";
                        ddlQuarto.DataValueField = "ID_QUARTO";
                        ddlQuarto.DataSource = dta.Copy();
                        ddlQuarto.DataBind();
                        ddlQuarto.Items.Insert(0, "SELECIONE");
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
        private void carregaDdlQuartoE()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT ID_QUARTO,CONCAT(NUMERO_QUARTO,' - ', UPPER(DESCRICAO_QUARTO))AS DESCRICAO FROM QUARTO WHERE STATUS_QUAR ='S' ORDER BY DESCRICAO", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        ddlQuartoE.DataTextField = "DESCRICAO";
                        ddlQuartoE.DataValueField = "ID_QUARTO";
                        ddlQuartoE.DataSource = dta.Copy();
                        ddlQuartoE.DataBind();
                        ddlQuartoE.Items.Insert(0, "SELECIONE");
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
        #endregion

        #region Geral
        private void limparCampos()
        {
            txtNome.Text = "";
            txtNomeE.Text = "";
            txtSobreNome.Text = "";
            txtSobrenomeE.Text = "";
            txtLoginE.Text = "";
            txtLogin.Text = "";
            txtNovaSenha.Text = "";
            txtConfirmaSenha.Text = "";
            ddlPerfil.SelectedIndex = -1;
            txtCdReservaE.Text = "";
            txtCodReserva.Text = "";
            ddlQuarto.SelectedIndex = -1;
            ddlQuartoE.SelectedIndex = -1;
            txtNomeCliente.Text = "";
            txtNomeClienteE.Text = "";
            txtDataFim.Text = "";
            txtDataFimE.Text = "";
            txtDataIni.Text = "";
            txtDataIniE.Text = "";
            ddlPerfilNovoUsu.SelectedIndex = -1;
            ddlPerfilUsuE.SelectedIndex = -1;
            txtSenhaRand.Text = "";
        }

        private void carregaDdl()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT ID_PERFIL, UPPER(DESCRICAO_PERFIL) AS PERFIL FROM PERFIL  ORDER BY PERFIL ", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        ddlPerfil.DataTextField = "PERFIL";
                        ddlPerfil.DataValueField = "ID_PERFIL";
                        ddlPerfil.DataSource = dta.Copy();
                        ddlPerfil.DataBind();
                        ddlPerfil.Items.Insert(0, "TODOS");
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
            mdUsuE.Visible = false;
            limparCampos();
        }

        protected void lnkPesquisar_Click(object sender, EventArgs e)
        {
            if (ddlPerfil.SelectedValue != "SELECIONE" && ddlStatus.SelectedValue != "SELECIONE")
            {
                if (ddlPerfil.SelectedValue != "3")
                {
                    if (ddlPerfil.SelectedValue != "TODOS" && ddlStatus.SelectedValue != "TODOS")
                    {
                        carregarTabela(ddlPerfil.SelectedValue.ToString(), ddlStatus.SelectedValue.ToString());
                    }
                    else if (ddlPerfil.SelectedValue != "TODOS" && ddlStatus.SelectedValue == "TODOS")
                    {
                        carregarTabela(ddlPerfil.SelectedValue.ToString(), "");
                    }
                    else if (ddlPerfil.SelectedValue == "TODOS" && ddlStatus.SelectedValue != "TODOS")
                    {
                        carregarTabela("", ddlStatus.SelectedValue.ToString());
                    }
                    else
                    {
                        carregarTabela("", "");
                    }


                }
                else
                {
                    if (ddlPerfil.SelectedValue != "TODOS" && ddlStatus.SelectedValue != "TODOS")
                    {
                        carregarTabelaClientes(ddlPerfil.SelectedValue.ToString(), ddlStatus.SelectedValue.ToString());
                    }
                    else if (ddlPerfil.SelectedValue != "TODOS" && ddlStatus.SelectedValue == "TODOS")
                    {
                        carregarTabelaClientes(ddlPerfil.SelectedValue.ToString(), "");
                    }
                    else if (ddlPerfil.SelectedValue == "TODOS" && ddlStatus.SelectedValue != "TODOS")
                    {
                        carregarTabelaClientes(ddlStatus.SelectedValue.ToString(), "");
                    }
                    else
                    {
                        carregarTabelaClientes("", "");
                    }

                }

            }

        }

        #endregion




    }
}

