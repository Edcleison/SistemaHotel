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
using System.IO;

namespace SistemaHotel
{
    public partial class ControleProduto : System.Web.UI.Page
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        DALProduto dalProd = new DALProduto();

        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Session["perfil"].ToString()=="ADMINISTRDOR")
            //    {
            int rParametro = 0;
            if (!IsPostBack)
            {

                if (Request.QueryString["PRODUTO_D"] != null)
                {
                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["PRODUTO_D"]));
                    dalProd.inativarProduto(rParametro);
                    string msg = $"<script> alert('Produto Inativado! ID:{rParametro}'); </script>";
                    Response.Write(msg);

                }
                if (Request.QueryString["PRODUTO_E"] != null)
                {

                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["PRODUTO_E"]));

                    Produto prod = dalProd.buscarProdutoId(rParametro);


                    txtNomeE.Text = prod.NomeProduto;
                    txtDescricaoE.Text = prod.DescricaoProduto;
                    txtPrecoE.Text = prod.PrecoUnitario.ToString();
                    ddlTipoProdE.SelectedValue = prod.TipoProduto.ToString();
                    txtIdProdutoE.Text = rParametro.ToString();
                    carregaDdlEditarTipoProduto();
                    mdBack.Visible = true;
                    mdProdE.Visible = true;
                }
                if (Request.QueryString["PRODUTO_A"] != null)
                {

                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["PRODUTO_A"]));
                    Produto prod = dalProd.buscarProdutoId(rParametro);
                    dalProd.ativarProduto(rParametro);
                    string msg = $"<script> alert('Produto Ativado! ID:{rParametro}'); </script>";
                    Response.Write(msg);

                }
                carregaDdl();
                //        }
                //        else
                //        {
                //            Response.Redirect("~/Default.aspx");
                //        }

                //    }

                //}
                //catch (Exception)
                //{

                //    Response.Redirect("~/Default.aspx");
            }

        }

        #region Controle Produto

        private void carregarTabela(string Tipo, string Status)
        {
            DataTable rDta = new DataTable();
            rDta = dalProd.buscarTodosProdutosTipo(Tipo, Status);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:12px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ID</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>NOME</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>DESCRICAO</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>PRECO</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>FOTO</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>STATUS</center></th>");
            sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>EDITAR</center></th>");
            if (Status == "S")
            {
                sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>INATIVAR</center></th>");
            }
            else if (Status == "N")
            {
                sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ATIVAR</center></th>");
            }
            else
            {
                sb.AppendLine("<th style='font-size:12px; letter-spacing: 1px;'><center>ATIVAR/INATIVAR</center></th>");
            }
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["ID_Produto"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["NOME_Prod"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["DESCRICAO_Prod"] + "</center></td>");
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["PRECO_Uni"] + "</td></center>");
                sb.AppendLine($@"<td style='font-size:12px; letter-spacing: 1px;'><center><img src='IMAGENS_PRODUTOS\{dtr["FOTO_Prod"]}'></center></td>");
                if (dtr["STATUS_PROD"].ToString() == "S")
                {
                    sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["STATUS_PROD"].ToString().Replace("S", "ATIVO") + "</td></center>");
                }
                else
                {
                    sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center>" + dtr["STATUS_PROD"].ToString().Replace("N", "INATIVO") + "</td></center>");
                }
                sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center><a href='ControleProduto.aspx?PRODUTO_E=" + Criptografia.Encrypt(dtr["ID_Produto"].ToString()) + "'><i class='fa fa-edit'></i></center></td>");
                if (dtr["STATUS_PROD"].ToString() == "S")
                {
                    sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center><a href='ControleProduto.aspx?PRODUTO_D=" + Criptografia.Encrypt(dtr["ID_Produto"].ToString()) + "'><i class='fa fa-power-off'></i></center></td>");
                }
                else
                {
                    sb.AppendLine("<td style='font-size:12px; letter-spacing: 1px;'><center><a href='ControleProduto.aspx?PRODUTO_A=" + Criptografia.Encrypt(dtr["ID_Produto"].ToString()) + "'><i class='fa fa-power-off'></i></center></td>");
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
            try
            {
                string msg = "";
                string caminho = Server.MapPath(@"IMAGENS_PRODUTOS\");
                Produto prod = new Produto();
                prod.NomeProduto = txtNome.Text;
                prod.DescricaoProduto = txtDescricao.Text;
                prod.PrecoUnitario = decimal.Parse(txtPreco.Text.Replace(",", "."));
                prod.TipoProduto = Convert.ToInt32(ddlTipoProdS.SelectedValue);
                prod.StatusProd = 'S';
                //faz o upload da foto e salva o nome no obj
                try
                {
                    if (fuProduto.PostedFile.FileName != "" && txtNome.Text != "" && txtDescricao.Text != "" && txtPreco.Text != "" && ddlTipoProdS.SelectedValue != "SELECIONE")
                    {
                        prod.FotoProduto = DateTime.Now.Millisecond.ToString() + fuProduto.PostedFile.FileName;
                        string img = caminho + prod.FotoProduto;
                        fuProduto.PostedFile.SaveAs(img);
                        dalProd.inserirProduto(prod);

                        msg = $"<script> alert('Produto Inserido'); </script>";
                        Response.Write(msg);
                        limparCampos();

                    }
                    else
                    {
                        msg = "<script> alert('Preencha todos os campos!'); </script>";
                        Response.Write(msg);
                    }

                }
                catch (Exception)
                {
                    msg = "<script> alert('Preencha todos os campos!'); </script>";
                    Response.Write(msg);
                }


            }

            catch (Exception erro)
            {
                string msg1 = $"<script> alert('{erro.Message}'); </script>";
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

            try
            {
                string msg = "";
                string caminho = Server.MapPath(@"IMAGENS_PRODUTOS\");
                Produto prod = new Produto();
                prod.NomeProduto = txtNomeE.Text;
                prod.DescricaoProduto = txtDescricaoE.Text;
                prod.PrecoUnitario = decimal.Parse(txtPrecoE.Text.Replace(",", "."));
                prod.IdProduto = Convert.ToInt32(txtIdProdutoE.Text);
                //alterar
                try
                {
                    if (fuProdE.PostedFile.FileName != "" && txtNomeE.Text != "" && txtDescricaoE.Text != "" && txtPrecoE.Text != "" && ddlTipoProdE.SelectedValue != "SELECIONE")
                    {
                        //verificar se existe foto existe e deletar
                        Produto rProd = dalProd.buscarProdutoId(prod.IdProduto);
                        if (rProd.FotoProduto != "")
                        {
                            File.Delete(caminho + rProd.FotoProduto);
                        }
                        prod.FotoProduto = DateTime.Now.Millisecond.ToString() + fuProdE.PostedFile.FileName;
                        string img = caminho + prod.FotoProduto;
                        fuProdE.PostedFile.SaveAs(img);
                        dalProd.alterarProduto(prod);
                        msg = $"<script> alert('O Produto Alterado:  ID {prod.IdProduto}'); </script>";
                        Response.Write(msg);
                        limparCampos();
                    }
                    else
                    {
                        msg = "<script> alert('Preencha todos os campos!'); </script>";
                        Response.Write(msg);
                    }
                }
                catch (Exception)
                {

                    msg = "<script> alert('Preencha todos os campos!'); </script>";
                    Response.Write(msg);
                }


            }

            catch (Exception erro)
            {
                string msg1 = $"<script> alert('{erro.Message}'); </script>";

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

