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
    public partial class ControleProduto : System.Web.UI.Page
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        DALProduto dalProd = new DALProduto();

        protected void Page_Load(object sender, EventArgs e)
        {
            int rParametro = 0;

            if (!IsPostBack)
            {

                if (Request.QueryString["PRODUTO_D"] != null)
                {
                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["USUARIO_D"]));

                    Produto prod = dalProd.buscarProdutoId(rParametro);

                    if (prod.IdProduto != 0)
                    {
                        dalProd.excluirProduto(prod.IdProduto);
                        string msg = "<script> alert('Produto Excluído!'); </script>";


                        Response.Write(msg);

                    }
                }
                if (Request.QueryString["PRODUTO_E"] != null)
                {

                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["PRODUTO_E"]));

                    Produto prod = dalProd.buscarProdutoId(rParametro);


                    txtNomeE.Text = prod.NomeProduto;
                    txtDescricaoE.Text = prod.DescricaoProduto;
                    txtPrecoE.Text = prod.PrecoUnitario.ToString();
                    ddlTipoProdE.SelectedValue = prod.TipoProduto.ToString();
                    carregaDdlEditarTipoProduto();
                    mdProdE.Visible = true;
                }
                carregaDdl();
            }

        }

        #region Controle Produto

        private void carregarTabela(int Tipo)
        {
            DataTable rDta = new DataTable();
            rDta = dalProd.buscarTodosProdutosTipo(Tipo);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th><center>ID</th></center>");
            sb.AppendLine("<th><center>NOME</th></center>");
            sb.AppendLine("<th><center>DESCRICAO</th></center>");
            sb.AppendLine("<th><center>PRECO</th></center>");
            sb.AppendLine("<th><center>FOTO</th></center>");
            sb.AppendLine("<th><center>EDITAR</th></center>");
            sb.AppendLine("<th><center>EXCLUIR</th></center>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td><center>" + dtr["ID_Produto"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["NOME_Prod"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["DESCRICAO_Prod"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["PRECO_Uni"] + "</td></center>");
                sb.AppendLine($@"<td><center><img src='IMAGENS_PRODUTOS\{dtr["FOTO_Prod"]}'></td></center>");
                sb.AppendLine("<td><center><a href='ControleProduto.aspx?PRODUTO_E=" + Criptografia.Encrypt(dtr["ID_Produto"].ToString()) + "'><i class='fa fa-edit'></i></center></td>");
                sb.AppendLine("<td><center><a href='ControleProduto.aspx?PRODUTO_D=" + Criptografia.Encrypt(dtr["ID_Produto"].ToString()) + "'><i class='fa fa-trash'></i></center></td>");
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
                prod.PrecoUnitario = decimal.Parse(txtPreco.Text);
                prod.TipoProduto = Convert.ToInt32(ddlTipoProdS.SelectedValue);
                //faz o upload da foto e salva o nome no obj
                if (fuProduto.PostedFile.FileName != "" && txtNome.Text != "" && txtDescricao.Text != "" && txtPreco.Text != "" && ddlTipoProdS.SelectedValue != "0")
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

            catch (Exception erro)
            {
                string msg1 = $"<script> alert({erro.Message}'); </script>";
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
                prod.NomeProduto = txtNome.Text;
                prod.DescricaoProduto = txtDescricao.Text;
                prod.PrecoUnitario = decimal.Parse(txtPreco.Text);
                //faz o upload da foto e salva o nome no obj
                if (fuProduto.PostedFile.FileName != "")
                {
                    prod.FotoProduto = DateTime.Now.Millisecond.ToString() + fuProduto.PostedFile.FileName;
                    string img = caminho + prod.FotoProduto;
                    fuProduto.PostedFile.SaveAs(img);
                    dalProd.alterarProduto(prod);
                    msg = $"<script> alert('O Produto Alterado: {prod.IdProduto}'); </script>";
                    Response.Write(msg);
                    limparCampos();
                }

            }

            catch (Exception erro)
            {
                string msg1 = $"<script> alert({erro.Message}'); </script>";

            }
        }
        private void carregaDdl()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Tipo_Prod]
                                                          ,[Descricao_Tipo_Prod]
                                                            FROM [dbo].[TIPO_PRODUTO] ORDER BY Descricao_Tipo_Prod", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        ddlTipo.DataTextField = "Descricao_Tipo_Prod";
                        ddlTipo.DataValueField = "Id_Tipo_Prod";
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

        private void carregaDdlEditarTipoProduto()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Tipo_Prod]
                                                          ,[Descricao_Tipo_Prod]
                                                            FROM [dbo].[TIPO_PRODUTO] ORDER BY Descricao_Tipo_Prod", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        ddlTipoProdE.DataTextField = "Descricao_Tipo_Prod";
                        ddlTipoProdE.DataValueField = "Id_Tipo_Prod";
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
                using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Tipo_Prod]
                                                          ,[Descricao_Tipo_Prod]
                                                            FROM [dbo].[TIPO_PRODUTO] ORDER BY Descricao_Tipo_Prod", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        ddlTipoProdS.DataTextField = "Descricao_Tipo_Prod";
                        ddlTipoProdS.DataValueField = "Id_Tipo_Prod";
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

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipo.SelectedValue != "0")
            {
                carregarTabela(int.Parse(ddlTipo.SelectedValue));
            }
        }

    }
}

