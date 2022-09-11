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
    public partial class NovoPedidoFrigobar : System.Web.UI.Page
    {
        DALProduto dalProd = new DALProduto();
        DALCliente dalCli = new DALCliente();
        DALPedido dalPed = new DALPedido();
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
                    imgProd.Src = $@"IMAGENS_PRODUTOS\{prod.FotoProduto}";
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

                carregarTabela();

            }
            carregarTabela();
        }


        private void carregarTabela()
        {

            DataTable rDta = new DataTable();
            rDta = dalProd.buscarTodosProdutosTipo("1", "S");
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th><center>ID</center></th>");
            sb.AppendLine("<th><center>NOME</center></th>");
            sb.AppendLine("<th><center>DESCRICAO</center></th>");
            sb.AppendLine("<th><center>PRECO</center></th>");
            sb.AppendLine("<th><center>FOTO</center></th>");
            sb.AppendLine("<th><center>ADICIONAR</center></th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td><center>" + dtr["ID_Produto"] + "</center></td>");
                sb.AppendLine("<td><center>" + dtr["NOME_PROD"] + "</center></td>");
                sb.AppendLine("<td><center>" + dtr["DESCRICAO_PROD"] + "</center></td>");
                sb.AppendLine("<td><center>" + dtr["PRECO_UNI"] + "</center></td>");
                sb.AppendLine($@"<td><center><img src='IMAGENS_PRODUTOS\{dtr["FOTO_Prod"]}'></center></td>");
                sb.AppendLine("<td><center><a href='NovoPedidoCozinha.aspx?PRODUTO_N=" + Criptografia.Encrypt(dtr["ID_Produto"].ToString()) + "'><i class='fa fa-plus'></i></center></td>");
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
            ped.ValorTotal = decimal.Parse(txtPreco.Text);
            dalPed.inserirPedido(ped);
            //busca o pedido pelo id_cliente e Data_Abertura
            ped = dalPed.buscarPedidoIdClienteData(ped.IdCliente, ped.DataAbertura);
            //campos relacionados ao Item_Pedido
            ItemPedido itemPed = new ItemPedido();
            itemPed.IdPedido = ped.IdPedido;
            itemPed.IdProduto = int.Parse(txtIdProd.Text);
            itemPed.IdCliente = cli.IdCliente;
            itemPed.Quantidade = int.Parse(txtQuantidade.Text);
            dalItemPed.inserirItemPedido(itemPed);
            string msg = $"<script> alert('Pedido Realizado: Código: {ped.IdPedido}'); </script>";

        }



        protected void lnkVoltar_Click(object sender, EventArgs e)
        {

            mdBack.Visible = false;
            mdPed.Visible = false;
            Response.Redirect("~/NovoPedidoFrigobar.aspx");
            limparCampos();

        }

        private void limparCampos()
        {
            txtNomeProd.Text = "";
            txtDescricao.Text = "";
            txtPreco.Text = "";
            txtQuantidade.Text = "";
        }


    }
}