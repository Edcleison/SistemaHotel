using SistemaHotel.Controller;
using SistemaHotel.Model;
using SistemaHotel.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaHotel
{
    public partial class NovoPedido : System.Web.UI.Page
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";
        DALProduto dalProd = new DALProduto();
        DALCliente dalCli = new DALCliente();
        DALPedido  dalPed = new DALPedido();
        DALItemPedido dalItemPed = new DALItemPedido();
        protected void Page_Load(object sender, EventArgs e)
        {
            int rParametro = 0;
            if (!IsPostBack)
            {
                if (Request.QueryString["PRODUTO_N"] != null)
                {

                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["PRODUTO_N"]));
                    Produto prod = dalProd.buscarProdutoId(rParametro);
                    txtIdProd.Text = prod.IdProduto.ToString();
                    txtNomeProd.Text = prod.NomeProduto;
                    txtDescricao.Text = prod.DescricaoProduto;
                    txtPreco.Text = prod.PrecoUnitario.ToString();
                    if (prod.TipoProduto == 1)
                    {
                        txtQuantidade.Enabled = true;
                    }
                    else
                    {
                        txtQuantidade.Text = "1";
                    }
                    mdBack.Visible = true;
                    mdPed.Visible = true;

                }
                carregaDdl();
            }
            
        }
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
            sb.AppendLine("<th><center>NOVO</th></center>");
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
                sb.AppendLine("<td><center><a href='NovoPedido.aspx?PRODUTO_N=" + Criptografia.Encrypt(dtr["ID_Produto"].ToString()) + "'><i class='fa fa-plus'></i></center></td>");
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }

        protected void lnkPedido_Click(object sender, EventArgs e)
        {
           //busca os dados do cliente pelo cod_reserva
            Cliente cli = dalCli.buscarClienteReserva(Session["login"].ToString());
            //campos relacionados ao novo pedido
            Pedido ped = new Pedido();
            ped.IdCliente = cli.IdCliente;
            ped.IdStatus = 1;
            ped.DataAbertura = DateTime.Now;
            ped.ValorTotal = int.Parse(txtQuantidade.Text) * decimal.Parse(txtPreco.Text);
            dalPed.inserirPedido(ped);
            //busca o pedido pelo id_cliente e Data_Abertura
            ped = dalPed.buscarPedidoIdClienteData(ped.IdCliente, ped.DataAbertura);
            //campos relacionados ao Item_Pedido
            ItemPedido itemPed = new ItemPedido();
            itemPed.IdPedido = ped.IdPedido;
            itemPed.IdProduto = int.Parse(txtIdProd.Text);
            itemPed.IdCliente = cli.IdCliente;
            itemPed.Quantidade =int.Parse(txtQuantidade.Text);
            string msg = $"<script> alert('Pedido Realizado: Código: {ped.IdPedido}'); </script>";
            Response.Write(msg);

        }

        protected void lnkVoltar_Click(object sender, EventArgs e)
        {

            mdBack.Visible = false;
            mdPed.Visible = false;
            limparCampos();

        }

        private void limparCampos()
        {
            txtNomeProd.Text = "";
            txtDescricao.Text = "";
            txtPreco.Text = "";
            txtQuantidade.Text = "";
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipo.SelectedValue != "SELECIONE")
            {
                carregarTabela(int.Parse(ddlTipo.SelectedValue));
            }
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