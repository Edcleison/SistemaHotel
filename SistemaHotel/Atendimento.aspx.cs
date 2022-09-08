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


        DALPedido dalPed = new DALPedido();
        DALUsuario dalUsu = new DALUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["perfil"].ToString() != "CLIENTE")
            {
                int rParametro = 0;
                if (!IsPostBack)
                {
                    if (Request.QueryString["ATENDIMENTO_S"] != null)
                    {
                        rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["ATENDIMENTO_S"]));
                        Usuario usu = dalUsu.buscaUsuarioLogin(Session["login"].ToString());
                        Pedido ped = dalPed.buscarPedidoId(rParametro);
                        if (Session["perfil"].ToString() == "ADMINISTRADOR")
                        {
                            DALAdministracao dalAdm = new DALAdministracao();
                            Administracao adm = dalAdm.buscarAdmIdUsuario(usu.IdUsuario);
                            ped.IdStatus = 2;
                            ped.DataFinalizacao = DateTime.Now;
                            ped.IdAdm = adm.IdAdm;
                            dalPed.alterarStatusAtendimentoAdm(ped);
                            Response.Redirect("~/Atendimento.aspx");

                        }
                        if (Session["perfil"].ToString() == "FUNCIONARIO")
                        {
                            DALFuncionario dalFun = new DALFuncionario();
                            Funcionario fun = dalFun.buscarFuncionarioIdUsuario(usu.IdUsuario);
                            ped.IdStatus = 2;
                            ped.DataFinalizacao = DateTime.Now;
                            ped.IdFuncionario = fun.IdFuncionario;
                            dalPed.alterarStatusAtendimentoFuncionario(ped);
                            Response.Redirect("~/Atendimento.aspx");
                        }
                    }
                    if (Request.QueryString["ATENDIMENTO_N"] != null)
                    {
                        rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["ATENDIMENTO_N"]));
                        Usuario usu = dalUsu.buscaUsuarioLogin(Session["login"].ToString());
                        Pedido ped = dalPed.buscarPedidoId(rParametro);
                        if (Session["perfil"].ToString() == "ADMINISTRADOR")
                        {
                            DALAdministracao dalAdm = new DALAdministracao();
                            Administracao adm = dalAdm.buscarAdmIdUsuario(usu.IdUsuario);
                            ped.IdStatus = 3;
                            ped.DataFinalizacao = DateTime.Now;
                            ped.IdAdm = adm.IdAdm;
                            dalPed.alterarStatusAtendimentoAdm(ped);
                            Response.Redirect("~/Atendimento.aspx");
                        }
                        if (Session["perfil"].ToString() == "FUNCIONARIO")
                        {
                            DALFuncionario dalFun = new DALFuncionario();
                            Funcionario fun = dalFun.buscarFuncionarioIdUsuario(usu.IdUsuario);
                            ped.IdStatus = 3;
                            ped.DataFinalizacao = DateTime.Now;
                            ped.IdFuncionario = fun.IdFuncionario;
                            dalPed.alterarStatusAtendimentoFuncionario(ped);
                            Response.Redirect("~/Atendimento.aspx");

                        }
                    }
                    if (Session["perfil"].ToString() == "FUNCIONARIO")
                    {
                        carregarTabela(1);
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


        private void carregarTabela(int tipoProd)
        {

            DataTable rDta = new DataTable();
            rDta = dalPed.buscarTodosPedidosTipoStatus(tipoProd, 1);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:10px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th><center>DATA ABERTURA</center></th>");
            sb.AppendLine("<th><center>QUARTO</center></th>");
            sb.AppendLine("<th><center>NOME</center></th>");
            sb.AppendLine("<th><center>NOME PRODUTO</center></th>");
            //sb.AppendLine("<th style='font-size:10px; letter-spacing: 1px;><center>DESCRICAO PRODUTO</center></th>");
            //sb.AppendLine("<th style='font-size:10px; letter-spacing: 1px;><center>FOTO PRODUTO</center></th>");
            sb.AppendLine("<th><center>QUANTIDADE</center></th>");
            sb.AppendLine("<th><center>STATUS</center></th>");
            sb.AppendLine("<th><center>ATENDER</center></th>");
            sb.AppendLine("<th><center>RECUSAR</center></th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td><center>" + dtr["DATA_ABERTURA"] + "</center></td>");
                sb.AppendLine("<td><center>" + dtr["DESCRICAO_QUARTO"] + "</center></td>");
                sb.AppendLine($"<td><center>{dtr["NOME_CLIENTE"] + " " + dtr["SOBRENOME_CLIENTE"]}</center></td>");
                sb.AppendLine("<td><center>" + dtr["NOME_PROD"] + "</td></center>");
                // sb.AppendLine("<td><center>" + dtr["DESCRICAO_PROD"] + "</center></td>");
                //sb.AppendLine($@"<td><center><img src='IMAGENS_PRODUTOS\{dtr["FOTO_PROD"]}'></center></td>");
                sb.AppendLine("<td><center>" + dtr["QUANTIDADE"] + "</center></td>");
                sb.AppendLine("<td><center>" + dtr["DESCRICAO_STATUS_PED"] + "</td></center>");
                sb.AppendLine("<td><center><a href=Atendimento.aspx?ATENDIMENTO_S=" + Criptografia.Encrypt(dtr["ID_PEDIDO"].ToString()) + "><i class='fa fa-check-square'></i></center></td>");
                sb.AppendLine("<td><center><a href=Atendimento.aspx?ATENDIMENTO_N=" + Criptografia.Encrypt(dtr["ID_PEDIDO"].ToString()) + "><i class='fa fa-minus-square'></i></center></td>");
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarTabela(int.Parse(ddlTipo.SelectedValue));
        }

        private void carregaDdl()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_TIPO_PROD]
                                                          ,[DESCRICAO_TIPO_PROD]
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

