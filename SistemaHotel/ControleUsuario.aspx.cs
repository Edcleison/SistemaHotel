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
        DALPerfilUsuario dalPerfUsu = new DALPerfilUsuario();
        DALUsuario dalUsu = new DALUsuario();
        DALCliente dalCli = new DALCliente();
        DALAdministracao dalAdm = new DALAdministracao();
        DALFuncionario dalFun = new DALFuncionario();

        protected void Page_Load(object sender, EventArgs e)
        {


            int rParametro = 0;

            if (!IsPostBack)
            {

                if (Request.QueryString["USUARIO_D"] != null)
                {
                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["USUARIO_D"]));
                    dalPerfUsu.inativarUsuario(rParametro);
                    string msg = $"<script> alert('Usuário Inativado: Código {rParametro}'); </script>";
                    Response.Write(msg);
                }
                if (Request.QueryString["CLIENTE_E"] != null)
                {
                    carregaDdlQuartoE();
                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["CLIENTE_E"]));
                    Usuario usu = dalUsu.buscarUsuarioId(rParametro);
                    Cliente cli = dalCli.buscarClienteReserva(usu.Login);
                    txtCdReservaE.Text = cli.CodReserva;
                    ddlQuartoE.SelectedValue = cli.IdQuarto.ToString();
                    txtNomeClienteE.Text = cli.NomeCliente + " " + cli.SobreNomeCliente;
                    txtDataIni.Text = cli.DataEntrada.ToString("dd/MM/yyyy HH:mm");
                    txtDataIni.Text = cli.DataSaida.ToString("dd/MM/yyyy HH:mm");
                    txtDataIniE.Text = cli.DataEntrada.ToString("dd/MM/yyyy HH:mm");
                    txtDataFimE.Text = cli.DataSaida.ToString("dd/MM/yyyy HH:mm");
                    mdBack.Visible = true;
                    modEditCli.Visible = true;
                }
                if (Request.QueryString["USUARIO_A"] != null)
                {

                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["USUARIO_A"]));
                    dalPerfUsu.ativarUsuario(rParametro);
                    string msg = $"<script> alert('Usuário Ativado! Código:{rParametro}'); </script>";
                    Response.Write(msg);

                }
                carregaDdl();
            }

        }

        #region ControleUsuario

        private void carregarTabelaAtivos(string Perfil, string Status)
        {
            DataTable rDta = new DataTable();
            rDta = dalUsu.buscarUsuariosPerfilStatus(Perfil, Status);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='tabelaUsuarios' class='display' style='width: 100% font-size:12px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ID</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>NOME</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>LOGIN</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>STATUS</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>INATIVAR</center></th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["ID_Usuario"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["NOME"] + " " + dtr["SOBRENOME"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["LOGIN"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["STATUS_USUARIO"].ToString().Replace("S", "ATIVO") + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center><a href='ControleUsuario.aspx?USUARIO_D=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-power-off'></i></center></td>");
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }
        private void carregarTabelaInativos(string Perfil, string Status)
        {
            DataTable rDta = new DataTable();
            rDta = dalUsu.buscarUsuariosPerfilStatus(Perfil, Status);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='tabelaUsuarios' class='display' style='width: 100% font-size:12px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ID</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>NOME</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>LOGIN</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>STATUS</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ATIVAR</center></th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["ID_Usuario"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["NOME"] + " " + dtr["SOBRENOME"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["LOGIN"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["STATUS_USUARIO"].ToString().Replace("N", "INATIVO") + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center><a href='ControleUsuario.aspx?USUARIO_A=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-power-off'></i></center></td>");
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
                        usu.SobrenomeUsuario = txtSobreNome.Text;
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
                        //campos relacionados a criação do Usuário na Administracao
                        if (ddlPerfilNovoUsu.SelectedValue == "1")
                        {
                            Administracao adm = new Administracao();
                            adm.IdUsuario = usu.IdUsuario;
                            adm.IdPerfil = perfUsu.IdPerfil;
                            dalAdm.inserirAdministracao(adm);
                        }
                        //campos relacionados a criação do Usuário na Funcionario
                        else
                        {
                            Funcionario fun = new Funcionario();
                            fun.IdUsuario = usu.IdUsuario;
                            fun.IdPerfil = perfUsu.IdPerfil;
                            dalFun.inserirFuncionario(fun);

                        }

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

        protected void novoUsuario_Click(object sender, EventArgs e)
        {
            mdBack.Visible = true;
            mdUsu.Visible = true;
            carregaDdlNovoUsuario();

        }

        #endregion

        #region ControleCliente

        private void carregarTabelaClientesAtivos(string Perfil, string Status)
        {
            DataTable rDta = new DataTable();
            rDta = dalUsu.buscarUsuariosClientesStatus(Perfil, Status);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='tabelaClientes' class='display' style='width: 100% font-size:12px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ID</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>CÓDIGO DA RESERVA</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>QUARTO</th></center>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>NOME</th></center>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>DATA INICIO</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>DATA FIM</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>STATUS</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>EDITAR</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>INATIVAR</center></th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["ID_USUARIO"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["LOGIN"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["DESCRICAO_QUARTO"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["NOME"] + " " + dtr["SOBRENOME"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + Convert.ToDateTime(dtr["DATA_Entrada"]).ToString("dd/MM/yyyy") + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + Convert.ToDateTime(dtr["DATA_SAIDA"]).ToString("dd/MM/yyyy") + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["STATUS_USUARIO"].ToString().Replace("S", "ATIVO") + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center><a href='ControleUsuario.aspx?CLIENTE_E=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-edit'></i></center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center><a href='ControleUsuario.aspx?USUARIO_D=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-power-off'></i></center></td>");
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }

        private void carregarTabelaClientesInativos(string Perfil, string Status)
        {
            DataTable rDta = new DataTable();
            rDta = dalUsu.buscarUsuariosClientesStatus(Perfil, Status);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='tabelaClientes' class='display' style='width: 100% font-size:12px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ID</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>CÓDIGO DA RESERVA</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>QUARTO</th></center>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>NOME</th></center>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>DATA INICIO</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>DATA FIM</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>STATUS</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>EDITAR</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ATIVAR</center></th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["ID_USUARIO"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["LOGIN"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["DESCRICAO_QUARTO"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["NOME"] + " " + dtr["SOBRENOME"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + Convert.ToDateTime(dtr["DATA_Entrada"]).ToString("dd/MM/yyyy") + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["STATUS_USUARIO"].ToString().Replace("S", "ATIVO") + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center><a href='ControleUsuario.aspx?CLIENTE_E=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-edit'></i></center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center><a href='ControleUsuario.aspx?USUARIO_A=" + Criptografia.Encrypt(dtr["ID_Usuario"].ToString()) + "'><i class='fa fa-power-off'></i></center></td>");
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
                            cli.IdQuarto = int.Parse(ddlQuarto.SelectedValue);
                            cli.NomeCliente = txtNomeCliente.Text;
                            cli.SobreNomeCliente = txtSobrenomeCliente.Text;
                            cli.DataEntrada = dataIni;
                            cli.DataSaida = dataFim;
                            //verifica se tem algum cliente ocupando o quarto com o id selecionado no DropDownList                           
                            DataTable dta = dalCli.verificarOcupacaoQuarto(ddlQuarto.SelectedValue);
                            if (dta.Rows.Count > 0)
                            {
                                DateTime dataOcupa;
                                dataOcupa = Convert.ToDateTime(dta.Rows[0]["DATA_SAIDA"]);
                                if (dataOcupa < DateTime.Now)
                                {
                                    dalCli.inserirCliente(cli);
                                    //campos relacionados ao cadastro de usuário
                                    usu.Login = sCdReserva;
                                    usu.NomeUsuario = txtNomeCliente.Text;
                                    usu.SobrenomeUsuario = txtSobrenomeCliente.Text;
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
                                    string msg = $"<script> alert('Quarto {dta.Rows[0]["DESCRICAO_QUARTO"]} Ocupado até: {dataOcupa.ToString("dd/MM/yyyy HH:ss")} Cód. Cliente:{dta.Rows[0]["ID_CLIENTE"]}!'); </script>";
                                    Response.Write(msg);

                                }

                            }
                            else
                            {
                                dalCli.inserirCliente(cli);
                                //campos relacionados ao cadastro de usuário
                                usu.Login = sCdReserva;
                                usu.NomeUsuario = txtNomeCliente.Text;
                                usu.SobrenomeUsuario = txtSobrenomeCliente.Text;
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

                DataTable dta = dalCli.verificarOcupacaoQuarto(ddlQuartoE.SelectedValue);
                if (dta.Rows.Count > 0)
                {
                    DateTime dataOcupa;
                    dataOcupa = Convert.ToDateTime(dta.Rows[0]["DATA_SAIDA"]);
                    if (dataOcupa < DateTime.Now)
                    {
                        dalCliente.alterarCliente(cli);
                        txtDataFimE.Text = novaDataFim.ToString();
                        string msg = "<script> alert('Data Alterada!'); </script>";
                        Response.Write(msg);
                    }
                    else
                    {
                        string msg = $"<script> alert('Quarto {dta.Rows[0]["DESCRICAO_QUARTO"]} Ocupado até: {dataOcupa.ToString("dd/MM/yyyy HH:mm")} !'); </script>";
                        Response.Write(msg);
                    }

                }
                else
                {
                    dalCliente.alterarCliente(cli);
                    txtDataFimE.Text = novaDataFim.ToString();
                    string msg = $"<script> alert('Data Alterada: Código Cliente:{cli.IdCliente} Data:{novaDataFim}!'); </script>";
                    Response.Write(msg);
                }
            }
            else
            {
                string msg = "<script> alert('Data não permitida!!'); </script>";
                Response.Write(msg);

            }

        }

        private void carregaDdlQuarto()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT ID_QUARTO, UPPER(DESCRICAO_QUARTO) AS QUARTO FROM QUARTO ORDER BY DESCRICAO_QUARTO", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        ddlQuarto.DataTextField = "QUARTO";
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
                using (SqlCommand cmd = new SqlCommand(@"SELECT ID_QUARTO, UPPER(DESCRICAO_QUARTO) AS QUARTO FROM QUARTO ORDER BY DESCRICAO_QUARTO", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        ddlQuartoE.DataTextField = "QUARTO";
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
            txtSobreNome.Text = "";
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



        #endregion

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlPerfil.SelectedValue != "SELECIONE" && ddlStatus.SelectedValue != "SELECIONE")
            {
                if (ddlPerfil.SelectedValue != "3")
                {
                    if (ddlStatus.SelectedValue == "S")
                    {
                        carregarTabelaAtivos(ddlPerfil.SelectedValue, ddlStatus.SelectedValue);
                    }
                    else
                    {
                        carregarTabelaInativos(ddlPerfil.SelectedValue, ddlStatus.SelectedValue);
                    }

                }
                else
                {
                    if (ddlStatus.SelectedValue == "S")
                    {
                        carregarTabelaClientesAtivos(ddlPerfil.SelectedValue, ddlStatus.SelectedValue);
                    }
                    else
                    {
                        carregarTabelaClientesInativos(ddlPerfil.SelectedValue, ddlStatus.SelectedValue);
                    }

                }

            }

        }
    }
}

