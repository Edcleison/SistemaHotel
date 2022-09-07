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
        List<Carrinho> prodsCar = new List<Carrinho>();
        DALCarrinho dalCar = new DALCarrinho();
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
                if (Request.QueryString["CARRINHO_C"] != null)
                {
                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["CARRINHO_C"]));

                    Carrinho car = dalCar.buscarCarrinhoId(rParametro);

                    if (car.IdCarrinho != 0)
                    {
                        dalCar.excluirCarrinho(car.IdCarrinho);
                        string msg = $"<script> alert('Produto Removido: Código: {car.IdProduto}'); </script>";
                        Response.Write(msg);

                    }
                    mdCarr.Visible = true;
                    carregarTabelaCarrinho(Session["login"].ToString());
                }
                carregarTabela();
            }

        }
        private void carregarTabela()
        {

            DataTable rDta = new DataTable();
            rDta = dalProd.buscarTodosProdutosTipo(2);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th><center>ID</th></center>");
            sb.AppendLine("<th><center>NOME</th></center>");
            sb.AppendLine("<th><center>DESCRICAO</th></center>");
            sb.AppendLine("<th><center>PRECO</th></center>");
            sb.AppendLine("<th><center>FOTO</th></center>");
            sb.AppendLine("<th><center>ADICIONAR</th></center>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td><center>" + dtr["ID_Produto"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["NOME_PROD"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["DESCRICAO_PROD"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["PRECO_UNI"] + "</td></center>");
                sb.AppendLine($@"<td><center><img src='IMAGENS_PRODUTOS\{dtr["FOTO_Prod"]}'></td></center>");
                sb.AppendLine("<td><center><a href='NovoPedidoFrigobar.aspx?PRODUTO_N=" + Criptografia.Encrypt(dtr["ID_Produto"].ToString()) + "'><i class='fa fa-plus'></i></center></td>");
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }

        private void carregarTabelaCarrinho(string codReserva)
        {

            decimal total = 0;
            DataTable rDta = new DataTable();
            rDta = dalCar.buscarCarrinhoCliente(codReserva, 2);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th><center>ID</th></center>");
            sb.AppendLine("<th><center>NOME</th></center>");
            sb.AppendLine("<th><center>DESCRICAO</th></center>");
            sb.AppendLine("<th><center>PRECO</th></center>");
            sb.AppendLine("<th><center>REMOVER</th></center>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine($"<td><center> {dtr["ID_Produto"]}</td></center>");
                sb.AppendLine($"<td><center> {dtr["NOME_PROD"]}</td></center>");
                sb.AppendLine($"<td><center>{dtr["DESCRICAO_PROD"]}</td></center>");
                sb.AppendLine($"<td><center>{dtr["PRECO_UNI"]}</td></center>");
                sb.AppendLine($"<td><center><a href='NovoPedidoFrigobar.aspx?CARRINHO_C={Criptografia.Encrypt(dtr["ID_CARRINHO"].ToString())}'><i class='fa fa-minus'></i></center></td>");
                sb.AppendLine("</tr>");
                total += decimal.Parse(dtr["PRECO_UNI"].ToString());

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");
            lblTotal.Text = total.ToString();

            Panel2.Controls.Clear();
            Panel2.Controls.Add(new LiteralControl(sb.ToString()));

        }

        protected void lnkPedido_Click(object sender, EventArgs e)
        {
            Carrinho car = new Carrinho();
            Cliente cli = dalCli.buscarClienteReserva(Session["login"].ToString());

            car.IdProduto = int.Parse(txtIdProd.Text);
            car.IdCliente = cli.IdCliente;

            for (int i = 1; i <= int.Parse(txtQuantidade.Text); i++)
            {
                dalCar.inserirCarrinho(car);
            }

            string msg = $"<script> alert('Produto(s) Adicionado(s): Código: {car.IdProduto} Qtde: {txtQuantidade.Text}'); </script>";
            Response.Write(msg);

        }

        protected void lnkVoltar_Click(object sender, EventArgs e)
        {

            mdBack.Visible = false;
            mdPed.Visible = false;
            mdCarr.Visible = false;
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

        protected void lnkCarrinho_Click(object sender, EventArgs e)
        {
            mdBack.Visible = true;
            mdCarr.Visible = true;
            mdPed.Visible = false;
            carregarTabelaCarrinho(Session["login"].ToString());

        }

        protected void lnkFechaPedido_Click(object sender, EventArgs e)
        {

            DataTable dta =  dalCar.buscarCarrinhoQtdeProd(Session["login"].ToString(), 2);

            if (dta.Rows.Count > 0)
            {
                decimal total = 0;
                //busca os dados do cliente pelo cod_reserva
                Cliente cli = dalCli.buscarClienteReserva(Session["login"].ToString());
                //campos relacionados ao novo pedido
                Pedido ped = new Pedido();
                ped.IdCliente = cli.IdCliente;
                ped.IdStatus = 1;
                ped.DataAbertura = DateTime.Now;
                ped.ValorTotal = total;
                dalPed.inserirPedido(ped);
                //busca o pedido pelo id_cliente e Data_Abertura
                ped = dalPed.buscarPedidoIdClienteData(ped.IdCliente, ped.DataAbertura);
                //campos relacionados ao Item_Pedido
               
                foreach (DataRow dtr in dta.Rows)
                {
                    ItemPedido itemPed = new ItemPedido();
                    itemPed.IdPedido = ped.IdPedido;
                    itemPed.IdProduto = int.Parse(dtr["ID_PRODUTO"].ToString());
                    itemPed.IdCliente = cli.IdCliente;
                    itemPed.Quantidade = int.Parse(dtr["QTDE"].ToString());
                    dalItemPed.inserirItemPedido(itemPed);
                    lblTotal.Text = "";
                }
                dalCar.excluirCarrinhoCliente(cli.IdCliente);
                string msg = $"<script> alert('Pedido Realizado: Código: {ped.IdPedido}'); </script>";
                Response.Write(msg);
                Response.Redirect("~/NovoPedidoCozinha.aspx");

            }
            else
            {
                string msg = $"<script> alert('Carrinho Vazio!'); </script>";
                Response.Write(msg);
                mdCarr.Visible = false;
                mdBack.Visible = false;
                carregarTabela();
            }



        }
    }
}