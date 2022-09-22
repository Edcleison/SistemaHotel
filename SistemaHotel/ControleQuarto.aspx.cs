﻿using SistemaHotel.Model;
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
    public partial class ControleQuarto : System.Web.UI.Page
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        DALQuarto dalQua = new DALQuarto();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["perfil"].ToString() == "Administrador")
                {
                    int rParametro = 0;
                    if (!IsPostBack)
                    {
                        if (Request.QueryString["QUARTO_D"] != null)
                        {
                            rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["QUARTO_D"]));
                            dalQua.inativarQuarto(rParametro);
                            //string msg = $"<script> alert('Quarto Inativado: ID {rParametro}'); </script>";
                            //Response.Write(msg);
                            Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                     Quarto Inativado: ID {rParametro}
                                            </div>");
                        }
                        if (Request.QueryString["QUARTO_E"] != null)
                        {

                            rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["QUARTO_E"]));

                            Quarto qua = dalQua.buscarQuartoId(rParametro);

                            txtQuartoE.Text = qua.DescricaoQuarto;
                            mdBack.Visible = true;
                            mdQuarE.Visible = true;
                        }
                        if (Request.QueryString["QUARTO_A"] != null)
                        {

                            rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["QUARTO_A"]));
                            dalQua.ativarQuarto(rParametro);
                            //string msg = $"<script> alert('Quarto Ativado! ID: {rParametro}'); </script>";
                            //Response.Write(msg);
                            Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                     Quarto Ativado! ID: {rParametro}
                                            </div>");


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

        #region Controle Quarto

        private void carregarTabela(string Status)
        {
            DataTable rDta = new DataTable();
            rDta = dalQua.buscarTodosQuartos(Status);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>ID</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>DESCRIÇÃO</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>STATUS</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>EDITAR</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>ATIVAR/INATIVAR</center></th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["ID_QUARTO"] + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["DESCRICAO_QUARTO"] + "</center></td>");
                if (dtr["STATUS_QUAR"].ToString() == "S")
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["STATUS_QUAR"].ToString().Replace("S", "ATIVO") + "</td></center>");
                }
                else
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["STATUS_QUAR"].ToString().Replace("N", "INATIVO") + "</td></center>");
                }
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href='ControleQuarto.aspx?QUARTO_E=" + Criptografia.Encrypt(dtr["ID_QUARTO"].ToString()) + "'><i class='fa fa-edit' style='color: blue'></i></center></td>");
                if (dtr["STATUS_QUAR"].ToString() == "S")
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href='ControleQuarto.aspx?QUARTO_D=" + Criptografia.Encrypt(dtr["ID_QUARTO"].ToString()) + "'><i class='fa fa-power-off' style='color: red'></i></center></td>");
                }
                else
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href='ControleQuarto.aspx?QUARTO_A=" + Criptografia.Encrypt(dtr["ID_QUARTO"].ToString()) + "'><i class='fa fa-power-off' style='color: green'></i></center></td>");
                }

                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }

        #endregion
        private void limparCampos()
        {

            txtQuarto.Text = "";

        }


        protected void lnkVoltar_Click(object sender, EventArgs e)
        {
            mdBack.Visible = false;
            mdQuar.Visible = false;
            mdQuarE.Visible = false;
            limparCampos();
        }


        protected void novoQuarto_Click(object sender, EventArgs e)
        {

            mdBack.Visible = true;
            mdQuar.Visible = true;

        }

        protected void lnkSalvarQuarto_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuarto.Text))
            {
                Quarto qua = new Quarto();
                qua.DescricaoQuarto = txtQuarto.Text;
                qua.StatusQuar = 'S';
                dalQua.inserirQuarto(qua);
                //string msg = "<script> alert('Quarto inserido!'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                    Quarto inserido!
                                            </div>");

            }
            else
            {
                //string msg = "<script> alert('Preencha o Quarto!'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                  Preencha o Quarto!
                                            </div>");
            }

        }

        protected void lnkSalvarQuartoE_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuartoE.Text))
            {
                Quarto qua = new Quarto();
                qua.DescricaoQuarto = txtQuartoE.Text;
                dalQua.alterarQuarto(qua);
                //string msg = $"<script> alert('Quarto alterado: ID{qua.IdQuarto}'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                               Quarto alterado: ID {qua.IdQuarto}
                                            </div>");

            }
            else
            {
                //string msg = "<script> alert('Preencha o Quarto!'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                               Preencha o Quarto!
                                            </div>");
            }


        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedValue != "TODOS")
            {
                carregarTabela(ddlStatus.SelectedValue.ToString());
            }
            else
            {
                carregarTabela("");
            }

        }
    }
}

