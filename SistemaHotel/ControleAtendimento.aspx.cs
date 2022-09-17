﻿using SistemaHotel.Controller;
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
    public partial class ControleAtendimento : System.Web.UI.Page
    {

        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";
        DALPedido dalPed = new DALPedido();
        protected void Page_Load(object sender, EventArgs e)
        {
            //    try
            //    {
            //        if (Session["perfil"].ToString() == "ADMINISTRADOR")
            //        {
            if (!IsPostBack)
                    {
                        carregaDdlStatus();
                        carregaDdlTipo();
                    }

                //}
            //    else
            //    {
            //        Response.Redirect("~/Default.aspx");
            //    }

            //}
            //catch (Exception)
            //{

            //    Response.Redirect("~/Default.aspx");
            //}
        //}
  
        }





        private void carregarTabela(string Tipo, string Status)
        {

            DataTable rDta = new DataTable();
            rDta = dalPed.buscarTodosPedidosTipoStatus(Tipo, Status);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:12px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ID PED.</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>DT. ABERTURA</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>QUARTO</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>NOME CLI.</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>NOME PROD.</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>QTDE</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>STATUS</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>DT. FIM</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ID ADM/FUN</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>NOME ADM/FUN</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>PERFIL</center></th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["ID_PEDIDO"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + Convert.ToDateTime(dtr["DATA_ABERTURA"]).ToString("dd/MM/yyyy HH:mm") + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["DESCRICAO_QUARTO"] + "</center></td>");
                sb.AppendLine($"<td style='font-size:12px; letter-spacing: 1px;'><center>{dtr["NOME_CLIENTE"] + " " + dtr["SOBRENOME_CLIENTE"]}</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["NOME_PROD"] + "</td></center>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["QUANTIDADE"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["DESCRICAO_STATUS_PED"] + "</td></center>");
                if (dtr["ID_ADM"].ToString() != "")
                {
                    sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + Convert.ToDateTime(dtr["DATA_FINALIZACAO"]).ToString("dd/MM/yyyy HH:mm") + "</center></td>");
                    sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["ID_ADM"] + "</center></th>");
                    sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["NOME_ADM"] + " " + dtr["SOBRENOME_ADM"] + "</center></th>");
                    sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["PERFIL_ADM"] + "</center></th>");
                }
                else if (dtr["ID_FUNCIONARIO"].ToString() != "")
                {
                    sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + Convert.ToDateTime(dtr["DATA_FINALIZACAO"]).ToString("dd/MM/yyyy HH:mm") + "</center></td>");
                    sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["ID_FUNCIONARIO"] + "</center></th>");
                    sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["NOME_FUNC"] + " " + dtr["SOBRENOME_FUNC"] + "</center></th>");
                    sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["PERFIL_FUNC"] + "</center></th>");

                }
                else
                {
                    sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>" + " " + "</center></th>");
                    sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>" + " " + "</center></th>");
                    sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>" + " " + "</center></th>");
                    sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>" + " " + "</center></th>");

                }
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }



        private void carregaDdlTipo()
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
                        ddlTipo.Items.Insert(0, "TODOS");
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

        private void carregaDdlStatus()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_STATUS_PED]
                                                          ,UPPER([DESCRICAO_STATUS_PED]) AS DESCRICAO_STATUS_PED
                                                            FROM [DBO].[STATUS_PEDIDO] ORDER BY DESCRICAO_STATUS_PED", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        ddlStatus.DataTextField = "DESCRICAO_STATUS_PED";
                        ddlStatus.DataValueField = "ID_STATUS_PED";
                        ddlStatus.DataSource = dta.Copy();
                        ddlStatus.DataBind();
                        ddlStatus.Items.Insert(0, "TODOS");
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

        protected void lnkPesquisar_Click(object sender, EventArgs e)
        {
            if (ddlTipo.SelectedValue != "TODOS" && ddlStatus.SelectedValue != "TODOS")
            {
                carregarTabela(ddlStatus.SelectedValue.ToString(), ddlTipo.SelectedValue.ToString());
            }
            else if (ddlTipo.SelectedValue != "TODOS" && ddlStatus.SelectedValue == "TODOS")
            {
                carregarTabela("", ddlTipo.SelectedValue.ToString());
            }
            else if (ddlTipo.SelectedValue == "TODOS" && ddlStatus.SelectedValue != "TODOS")
            {
                carregarTabela(ddlStatus.SelectedValue.ToString(), "");
            }
            else
            {
                carregarTabela("", "");
            }

        }
    }
}

