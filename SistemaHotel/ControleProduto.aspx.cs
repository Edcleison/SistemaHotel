﻿using SistemaHotel.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using SistemaHotel.Controller;
using SistemaHotel.Utils;
using System.IO;
using System.Globalization;

namespace SistemaHotel
{
    public partial class ControleProduto : System.Web.UI.Page
    {
        CultureInfo ptBR = new CultureInfo("pt-BR");
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["perfil"].ToString() == "Administração")
                {
                    int rParametro = 0;
                    if (!IsPostBack)
                    {

                        if (Request.QueryString["PRODUTO_D"] != null)
                        {
                            rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["PRODUTO_D"]));
                            DALProduto.inativarProduto(rParametro);
                            //string msg = $"<script> alert('Produto Inativado! ID: {rParametro}'); </script>";
                            //Response.Write(msg);
                            Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                            Produto Inativado! ID: {rParametro}
                                            <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");

                        }
                        if (Request.QueryString["PRODUTO_E"] != null)
                        {

                            rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["PRODUTO_E"]));

                            Produto prod = DALProduto.buscarProdutoId(rParametro);


                            txtNomeE.Text = prod.NomeProduto;
                            txtDescricaoE.Text = prod.DescricaoProduto;
                            txtPrecoE.Text = prod.PrecoUnitario.ToString();
                            ddlTipoProdE.SelectedValue = prod.TipoProduto.ToString();
                            txtIdProdutoE.Text = rParametro.ToString();
                            //fuProdE.PostedFile.FileName = prod.FotoProduto;
                            carregaDdlEditarTipoProduto();
                            mdBack.Visible = true;
                            mdProdE.Visible = true;
                        }
                        if (Request.QueryString["PRODUTO_A"] != null)
                        {

                            rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["PRODUTO_A"]));
                            Produto prod = DALProduto.buscarProdutoId(rParametro);
                            DALProduto.ativarProduto(rParametro);
                            //string msg = $"<script> alert('Produto Ativado! ID:{rParametro}'); </script>";
                            //Response.Write(msg);
                            Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                        Produto Ativado!  ID {prod.IdProduto}
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");

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

        #region Controle Produto

        private void carregarTabela(string Tipo, string Status)
        {
            DataTable rDta = new DataTable();
            rDta = DALProduto.buscarTodosProdutosTipo(Tipo, Status);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>ID</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>NOME</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>DESCRIÇÃO</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>PREÇO</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>FOTO</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>STATUS</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>EDITAR</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>ATIVAR/INATIVAR</center></th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["ID_Produto"] + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["NOME_Prod"] + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["DESCRICAO_Prod"] + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + Convert.ToDecimal(dtr["PRECO_UNI"],ptBR) + "</td></center>");
                sb.AppendLine($@"<td style='font-size:15px; letter-spacing: 1px;'><center><img src='IMAGENS_PRODUTOS\{dtr["FOTO_Prod"]}'></center></td>");
                if (dtr["STATUS_PROD"].ToString() == "S")
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["STATUS_PROD"].ToString().Replace("S", "ATIVO") + "</td></center>");
                }
                else
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["STATUS_PROD"].ToString().Replace("N", "INATIVO") + "</td></center>");
                }
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href='ControleProduto.aspx?PRODUTO_E=" + Criptografia.Encrypt(dtr["ID_Produto"].ToString()) + "'><i class='fa fa-edit' style='color: blue'></i></center></td>");
                if (dtr["STATUS_PROD"].ToString() == "S")
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href='ControleProduto.aspx?PRODUTO_D=" + Criptografia.Encrypt(dtr["ID_Produto"].ToString()) + "'><i class='fa fa-power-off' style='color: red'></i></center></td>");
                }
                else
                {
                    sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href='ControleProduto.aspx?PRODUTO_A=" + Criptografia.Encrypt(dtr["ID_Produto"].ToString()) + "'><i class='fa fa-power-off' style='color: green'></i></center></td>");
                }
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }
        protected void lnkSalvarProduto_Click(object sender, EventArgs e)
        {
            if (fuProduto.PostedFile.FileName != "" && txtNome.Text != "" && txtDescricao.Text != "" && txtPreco.Text != "" && ddlTipoProdS.SelectedValue != "SELECIONE")
            {
                Produto rProd = DALProduto.buscarProdutoNome(txtNome.Text);

                if (rProd.NomeProduto == "")
                {
                    if (Convert.ToDecimal(txtPreco.Text, ptBR) > 0)
                    {
                        Produto prod = new Produto();
                        prod.NomeProduto = txtNome.Text;
                        prod.DescricaoProduto = txtDescricao.Text;
                        prod.PrecoUnitario = Convert.ToDecimal(txtPreco.Text, ptBR);
                        //prod.PrecoUnitario = decimal.Parse(txtPreco.Text);
                        prod.TipoProduto = Convert.ToInt32(ddlTipoProdS.SelectedValue);
                        prod.StatusProd = 'S';
                        //faz o upload da foto e salva o nome no obj

                        if (fuProduto.PostedFile.FileName.EndsWith(".png") || fuProduto.PostedFile.FileName.EndsWith(".bitmap") || fuProduto.PostedFile.FileName.EndsWith(".jpg") || fuProduto.PostedFile.FileName.EndsWith(".jpeg"))
                        {
                            try
                            {
                                string msg = "";
                                string caminho = Server.MapPath(@"IMAGENS_PRODUTOS\");
                                prod.FotoProduto = DateTime.Now.Millisecond.ToString() + fuProduto.PostedFile.FileName;
                                string img = caminho + prod.FotoProduto;
                                fuProduto.PostedFile.SaveAs(img);
                                DALProduto.inserirProduto(prod);

                                //msg = $"<script> alert('Produto Inserido!'); </script>";
                                //Response.Write(msg);
                                Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                          Produto Inserido!
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                            }
                            catch (Exception erro)
                            {
                                //msg = "<script> alert('Preencha todos os campos!'); </script>";
                                //Response.Write(msg);
                                Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                        {erro.Message}
                                    <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");


                            }
                            limparCampos();
                        }
                        else
                        {
                            //msg = "<script> alert('Preencha todos os campos!'); </script>";
                            //Response.Write(msg);
                            Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                       Só é permitido imagem com extensão: |.png |.bitmap |.jpg |.jpeg !
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                        }
                    }
                    else
                    {
                        //msg = "<script> alert('Preencha todos os campos!'); </script>";
                        //Response.Write(msg);
                        Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                         Não é permitido preço negativo!
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");

                    }

                }
                else
                {

                    //msg = "<script> alert('Preencha todos os campos!'); </script>";
                    //Response.Write(msg);
                    Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                        Produto {rProd.NomeProduto} já cadastrado!
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                }
               
            }
            else
            {
                //msg = "<script> alert('Preencha todos os campos!'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                         Preencha todos os campos!
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
            }
        }




        #endregion



        private void limparCampos()
        {
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtPreco.Text = "";
            ddlTipo.SelectedIndex = -1;
        }

        protected void lnkSenha_Click(object sender, EventArgs e)
        {

        }

        protected void lnkVoltar_Click(object sender, EventArgs e)
        {
            mdBack.Visible = false;
            mdProd.Visible = false;
            mdProdE.Visible = false;
            limparCampos();
        }

        protected void lnkSalvarProdutoE_Click(object sender, EventArgs e)
        {

            if (txtNomeE.Text != "" && txtDescricaoE.Text != "" && txtPrecoE.Text != "" && ddlTipoProdE.SelectedValue != "SELECIONE")
            {
                if (Convert.ToDecimal(txtPrecoE.Text, ptBR) > 0)
                {

                    Produto prod = new Produto();
                    prod.NomeProduto = txtNomeE.Text;
                    prod.DescricaoProduto = txtDescricaoE.Text;
                    prod.PrecoUnitario = Convert.ToDecimal(txtPrecoE.Text, ptBR);
                    prod.IdProduto = Convert.ToInt32(txtIdProdutoE.Text);
                    prod.TipoProduto = Convert.ToInt32(ddlTipoProdE.SelectedValue);
                    //alterar

                    if (fuProdE.PostedFile.FileName != "")
                    {
                        if (fuProdE.PostedFile.FileName.EndsWith(".png") || fuProdE.PostedFile.FileName.EndsWith(".jpg") || fuProdE.PostedFile.FileName.EndsWith(".bitmap") || fuProdE.PostedFile.FileName.EndsWith(".jpeg"))
                        {
                            string msg = "";
                            string caminho = Server.MapPath(@"IMAGENS_PRODUTOS\");

                            //verificar se existe foto existe e deletar
                            Produto rProd = DALProduto.buscarProdutoId(prod.IdProduto);
                            if (rProd.FotoProduto != "")
                            {
                                File.Delete(caminho + rProd.FotoProduto);
                            }
                            prod.FotoProduto = DateTime.Now.Millisecond.ToString() + fuProdE.PostedFile.FileName;
                            string img = caminho + prod.FotoProduto;
                            fuProdE.PostedFile.SaveAs(img);

                            DALProduto.alterarProduto(prod);
                            //msg = $"<script> alert('O Produto Alterado:  ID {prod.IdProduto}'); </script>";
                            //Response.Write(msg);
                            Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                       O Produto Alterado:  ID {prod.IdProduto}
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                            limparCampos();


                        }
                        else
                        {
                            //msg = "<script> alert('Preencha todos os campos!'); </script>";
                            //Response.Write(msg);
                            Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                       Só é permitido imagem com extensão: | .png | .bitmap | .jpg | .jpeg !
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");

                        }
                    }
                    else if (fuProdE.PostedFile.FileName == "")
                    {
                        DALProduto.alterarProduto(prod);
                        //msg = $"<script> alert('O Produto Alterado:  ID {prod.IdProduto}'); </script>";
                        //Response.Write(msg);
                        Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                                       O Produto Alterado:  ID {prod.IdProduto}
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
                        limparCampos();
                    }

                }
                else
                {
                    //msg = "<script> alert('Preencha todos os campos!'); </script>";
                    //Response.Write(msg);
                    Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                        Não é permitido preço negativo!
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");

                }


            }
            else
            {
                //msg = "<script> alert('Preencha todos os campos!'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                                         Preencha todos os campos!
                                        <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                                                <span aria-hidden='true'>&times;</span>
                                              </button>
                                            </div>");
            }
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

        private void carregaDdlEditarTipoProduto()
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
                        ddlTipoProdE.DataTextField = "DESCRICAO_TIPO_PROD";
                        ddlTipoProdE.DataValueField = "ID_TIPO_PROD";
                        ddlTipoProdE.DataSource = dta.Copy();
                        ddlTipoProdE.DataBind();
                        ddlTipoProdE.Items.Insert(0, "SELECIONE");
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
        private void carregaDdlSalvarTipoProduto()
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
                        ddlTipoProdS.DataTextField = "DESCRICAO_TIPO_PROD";
                        ddlTipoProdS.DataValueField = "ID_TIPO_PROD";
                        ddlTipoProdS.DataSource = dta.Copy();
                        ddlTipoProdS.DataBind();
                        ddlTipoProdS.Items.Insert(0, "SELECIONE");
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

        protected void novoProduto_Click(object sender, EventArgs e)
        {
            mdProd.Visible = true;
            carregaDdlSalvarTipoProduto();


        }


        protected void lnkPesquisar_Click(object sender, EventArgs e)
        {


            if (ddlTipo.SelectedValue != "TODOS" && ddlStatus.SelectedValue != "TODOS")
            {
                carregarTabela(ddlTipo.SelectedValue.ToString(), ddlStatus.SelectedValue.ToString());
            }
            else if (ddlTipo.SelectedValue != "TODOS" && ddlStatus.SelectedValue == "TODOS")
            {
                carregarTabela(ddlTipo.SelectedValue.ToString(), "");
            }
            else if (ddlTipo.SelectedValue == "TODOS" && ddlStatus.SelectedValue != "TODOS")
            {
                carregarTabela("", ddlStatus.SelectedValue.ToString());
            }
            else
            {
                carregarTabela("", "");
            }




        }
    }
}
