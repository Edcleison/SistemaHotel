using SistemaHotel.Controller;
using SistemaHotel.Model;
using SistemaHotel.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaHotel
{
    public partial class Atendimento : System.Web.UI.Page
    {

        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["perfil"].ToString() == "Administrador" || Session["perfil"].ToString() == "Funcionário")
                {
                    if (!IsPostBack)
                    {
                        int rParametro = 0;
                        string msg = "";
                        if (Request.QueryString["ATENDIMENTO_S"] != null)
                        {

                            rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["ATENDIMENTO_S"]));
                            Usuario usu = DALUsuario.buscaUsuarioLogin(Session["login"].ToString());
                            Pedido ped = DALPedido.buscarPedidoId(rParametro);
                            if (Session["perfil"].ToString() == "Administrador")
                            {
                               
                                Administracao adm = DALAdministracao.buscarAdmIdUsuario(usu.IdUsuario);
                                ped.IdStatus = 2;
                                ped.DataFinalizacao = DateTime.Now;
                                ped.IdAdm = adm.IdAdm;
                                DALPedido.alterarStatusAtendimentoAdm(ped);
                                //msg = $"<script> alert('Atendimento Finalizado: ID do Administrador {adm.IdAdm}'); </script>";
                                //Response.Write(msg);
                                Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                             Atendimento Finalizado: ID do Administrador {adm.IdAdm}  
                                                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");


                            }
                            if (Session["perfil"].ToString() == "Funcionário")
                            {
                                Funcionario fun = DALFuncionario.buscarFuncionarioIdUsuario(usu.IdUsuario);
                                ped.IdStatus = 2;
                                ped.DataFinalizacao = DateTime.Now;
                                ped.IdFuncionario = fun.IdFuncionario;
                                DALPedido.alterarStatusAtendimentoFuncionario(ped);
                                //msg = $"<script> alert('Atendimento Finalizado: ID do Funcionário {fun.IdFuncionario}'); </script>";
                                //Response.Write(msg);
                                Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                             Atendimento Finalizado: ID do Funcionário {fun.IdFuncionario}
                                            <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                            }
                        }
                        if (Request.QueryString["ATENDIMENTO_N"] != null)
                        {
                            rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["ATENDIMENTO_N"]));
                            Usuario usu = DALUsuario.buscaUsuarioLogin(Session["login"].ToString());
                            Pedido ped = DALPedido.buscarPedidoId(rParametro);
                            if (Session["perfil"].ToString() == "Administrador")
                            {
                              
                                Administracao adm = DALAdministracao.buscarAdmIdUsuario(usu.IdUsuario);
                                ped.IdStatus = 3;
                                ped.DataFinalizacao = DateTime.Now;
                                ped.IdAdm = adm.IdAdm;
                                DALPedido.alterarStatusAtendimentoAdm(ped);
                                //msg = $"<script> alert('Atendimento Recusado: ID do Administrador {adm.IdAdm}'); </script>";
                                //Response.Write(msg);
                                Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                             Atendimento Recusado: ID do Administrador {adm.IdAdm}
                                            <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                            }
                            if (Session["perfil"].ToString() == "Funcionário")
                            {
                               
                                Funcionario fun = DALFuncionario.buscarFuncionarioIdUsuario(usu.IdUsuario);
                                ped.IdStatus = 3;
                                ped.DataFinalizacao = DateTime.Now;
                                ped.IdFuncionario = fun.IdFuncionario;
                                DALPedido.alterarStatusAtendimentoFuncionario(ped);
                                //msg = $"<script> alert('Atendimento Finalizado: ID do Funcionário {fun.IdFuncionario}'); </script>";
                                //Response.Write(msg);
                                Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                            Atendimento Finalizado: ID do Funcionário {fun.IdFuncionario}
                                                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");


                            }
                        }
                        if (Session["perfil"].ToString() == "Funcionário")
                        {
                            carregarTabela("1");
                        }
                        else
                        {
                            divTipo.Visible = true;
                            carregaDdl();
                        }

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
        private void carregarTabela(string tipoProd)
        {

            DataTable rDta = new DataTable();
            rDta = DALPedido.buscarTodosPedidosTipoStatus("1", tipoProd);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>ID PEDIDO</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>DATA ABERTURA</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>QUARTO</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>NOME CLIENTE</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>NOME PRODUTO</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>QUANTIDADE</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>STATUS</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>ATENDER</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>RECUSAR</center></th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["ID_PEDIDO"] + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + Convert.ToDateTime(dtr["DATA_ABERTURA"]).ToString("dd/MM/yyyy HH:mm") + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["NUMERO_QUARTO"] + " - " + dtr["DESCRICAO_QUARTO"] + "</center></td>");
                sb.AppendLine($"<td style='font-size:15px; letter-spacing: 1px;'><center>{dtr["NOME_CLIENTE"] + " " + dtr["SOBRENOME_CLIENTE"]}</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["NOME_PROD"] + "</td></center>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["QUANTIDADE"] + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["DESCRICAO_STATUS_PED"] + "</td></center>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href=Atendimento.aspx?ATENDIMENTO_S=" + Criptografia.Encrypt(dtr["ID_PEDIDO"].ToString()) + "><i class='fa fa-check' style='color: green'></i></center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href=Atendimento.aspx?ATENDIMENTO_N=" + Criptografia.Encrypt(dtr["ID_PEDIDO"].ToString()) + "><i class='fa fa-close' style='color: red'></i></center></td>");
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarTabela(ddlTipo.SelectedValue.ToString());
        }

        private void carregaDdl()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_TIPO_PROD]
                                                          ,UPPER([DESCRICAO_TIPO_PROD]) AS DESCRICAO_TIPO_PROD
                                                            FROM [DBO].[TIPO_PRODUTO] ORDER BY DESCRICAO_TIPO_PROD", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        ddlTipo.DataTextField = "DESCRICAO_TIPO_PROD";
                        ddlTipo.DataValueField = "ID_TIPO_PROD";
                        ddlTipo.DataSource = dta.Copy();
                        ddlTipo.DataBind();
                        ddlTipo.Items.Insert(0, "SELECIONE");
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
    }
}

