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
    public partial class ControleQuarto : System.Web.UI.Page
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        DALQuarto dalQua = new DALQuarto();

        protected void Page_Load(object sender, EventArgs e)
        {

            int rParametro = 0;
            if (!IsPostBack)
            {
                if (Request.QueryString["QUARTO_D"] != null)
                {
                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["QUARTO_D"]));
                    dalQua.inativarQuarto(rParametro);
                    string msg = $"<script> alert('Quarto Inativado: Código{rParametro}'); </script>";
                    Response.Write(msg);
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
                    string msg = $"<script> alert('Quarto Ativado! Código:{rParametro}'); </script>";
                    Response.Write(msg);

                }
            }
        }

        #region Controle Quarto

        private void carregarTabelaAtivos(string Status)
        {
            DataTable rDta = new DataTable();
            rDta = dalQua.buscarTodosQuartos(Status);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:12px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ID</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>DESCRIÇÃO</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>STATUS</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>EDITAR</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>INATIVAR</center></th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["ID_QUARTO"] + "</center></td>");      
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["DESCRICAO_QUARTO"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["STATUS_QUAR"].ToString().Replace("S", "ATIVO") + "</td></center>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center><a href='ControleQuarto.aspx?QUARTO_E=" + Criptografia.Encrypt(dtr["ID_QUARTO"].ToString()) + "'><i class='fa fa-edit'></i></center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center><a href='ControleQuarto.aspx?QUARTO_D=" + Criptografia.Encrypt(dtr["ID_QUARTO"].ToString()) + "'><i class='fa fa-power-off'></i></center></td>");
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }

        private void carregarTabelaInativos(string Status)
        {
            DataTable rDta = new DataTable();
            rDta = dalQua.buscarTodosQuartos(Status);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:12px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ID</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>DESCRIÇÃO</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>STATUS</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>EDITAR</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ATIVAR</center></th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["ID_QUARTO"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["DESCRICAO_QUARTO"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["STATUS_QUAR"].ToString().Replace("N", "INATIVO") + "</td></center>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center><a href='ControleQuarto.aspx?QUARTO_E=" + Criptografia.Encrypt(dtr["ID_QUARTO"].ToString()) + "'><i class='fa fa-edit'></i></center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center><a href='ControleQuarto.aspx?QUARTO_A=" + Criptografia.Encrypt(dtr["ID_QUARTO"].ToString()) + "'><i class='fa fa-power-off'></i></center></td>");
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
                string msg = "<script> alert('Quarto inserido!'); </script>";
                Response.Write(msg);

            }
            else
            {
                string msg = "<script> alert('Preencha o Quarto!'); </script>";
                Response.Write(msg);
            }

        }

        protected void lnkSalvarQuartoE_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuartoE.Text))
            {
                Quarto qua = new Quarto();
                qua.DescricaoQuarto = txtQuartoE.Text;
                dalQua.alterarQuarto(qua);
                string msg = $"<script> alert('Quarto alterado: Código{qua.IdQuarto}'); </script>";
                Response.Write(msg);

            }
            else
            {
                string msg = "<script> alert('Preencha o Quarto!'); </script>";
                Response.Write(msg);
            }


        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedValue != "SELECIONE")
            {
                if (ddlStatus.SelectedValue == "S")
                {
                    carregarTabelaAtivos(ddlStatus.SelectedValue);
                }
                else
                {
                    carregarTabelaInativos(ddlStatus.SelectedValue);
                }



            }
        }
    }
}

