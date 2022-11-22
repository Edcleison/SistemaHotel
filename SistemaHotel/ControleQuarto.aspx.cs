using SistemaHotel.Model;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using SistemaHotel.Controller;
using SistemaHotel.Utils;
using System.Globalization;

namespace SistemaHotel
{
    public partial class ControleQuarto : System.Web.UI.Page
    {
        CultureInfo ptBR = new CultureInfo("pt-BR");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["perfil"].ToString() == "Administração")
                {
                    int rParametro = 0;
                    if (!IsPostBack)
                    {
                        if (Request.QueryString["QUARTO_D"] != null)
                        {
                            rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["QUARTO_D"]));
                            DataTable dta = DALCliente.verificarOcupacaoQuarto(Criptografia.Decrypt(Request.QueryString["QUARTO_D"]));
                            if (dta.Rows.Count > 0)
                            {
                                if (DateTime.ParseExact(Convert.ToDateTime(dta.Rows[0]["DATA_SAIDA"]).ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", null) < DateTime.ParseExact(DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", null))
                                {
                                    DALQuarto.inativarQuarto(rParametro);
                                    //string msg = $"<script> alert('Quarto Inativado: ID {rParametro}'); </script>";
                                    //Response.Write(msg);
                                    Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                     Quarto Inativado: ID {rParametro}
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


                        }
                        if (Request.QueryString["QUARTO_E"] != null)
                        {

                            rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["QUARTO_E"]));

                            Quarto qua = DALQuarto.buscarQuartoId(rParametro);

                            txtNumeroQuartoE.Text = qua.NumeroQuarto.ToString();
                            txtDescricaoQuartoE.Text = qua.DescricaoQuarto;
                            txtIdQuartoE.Text = qua.IdQuarto.ToString();
                            mdBack.Visible = true;
                            mdQuarE.Visible = true;
                        }
                        if (Request.QueryString["QUARTO_A"] != null)
                        {

                            rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["QUARTO_A"]));
                            DALQuarto.ativarQuarto(rParametro);
                            //string msg = $"<script> alert('Quarto Ativado! ID: {rParametro}'); </script>";
                            //Response.Write(msg);
                            Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                     Quarto Ativado! ID: {rParametro}
                                    <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
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
            rDta = DALQuarto.buscarTodosQuartos(Status);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>ID</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>NÚMERO QUARTO</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>DESCRIÇÃO QUARTO</center></th>");
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
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["NUMERO_QUARTO"] + "</center></td>");
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

            txtNumeroQuarto.Text = "";
            txtNumeroQuartoE.Text = "";
            txtDescricaoQuartoE.Text = "";
            txtDescricaoQuarto.Text = "";

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
            if (!string.IsNullOrEmpty(txtNumeroQuarto.Text) && !string.IsNullOrEmpty(txtDescricaoQuarto.Text))
            {
                Quarto rQua = DALQuarto.buscarQuartoNumero(txtNumeroQuarto.Text);
                if (rQua.NumeroQuarto == "")
                {
                    Quarto qua = new Quarto();
                    qua.NumeroQuarto = txtNumeroQuarto.Text;
                    qua.DescricaoQuarto = txtDescricaoQuarto.Text;
                    qua.StatusQuar = 'S';
                    DALQuarto.inserirQuarto(qua);
                    //string msg = "<script> alert('Quarto inserido!'); </script>";
                    //Response.Write(msg);
                    Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                    Quarto inserido!
                                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                }
                else
                {
                    //string msg = "<script> alert('Preencha o Quarto!'); </script>";
                    //Response.Write(msg);
                    Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                 Quarto número {rQua.NumeroQuarto} já existe!
                                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");

                }
               
            }
            else
            {
                //string msg = "<script> alert('Preencha o Quarto!'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                  Preencha todas as informações do Quarto!
                                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
            }

        }

        protected void lnkSalvarQuartoE_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumeroQuartoE.Text) & !string.IsNullOrEmpty(txtDescricaoQuartoE.Text))
            {
                Quarto qua = new Quarto();
                qua.NumeroQuarto = txtNumeroQuartoE.Text;
                qua.DescricaoQuarto = txtDescricaoQuartoE.Text;
                qua.IdQuarto = int.Parse(txtIdQuartoE.Text);
                DALQuarto.alterarQuarto(qua);
                //string msg = $"<script> alert('Quarto alterado: ID{qua.IdQuarto}'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                               Quarto alterado: ID {qua.IdQuarto}
                                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");

            }
            else
            {
                //string msg = "<script> alert('Preencha o Quarto!'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                Preencha todas as informações do Quarto!
                                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
            }


        }

        protected void lnkPesquisar_Click(object sender, EventArgs e)
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

