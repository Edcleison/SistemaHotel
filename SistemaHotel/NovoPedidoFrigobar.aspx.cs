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
    public partial class NovoPedidoFrigobar : System.Web.UI.Page
    {
        DALProduto dalProd = new DALProduto();
        DALCliente dalCli = new DALCliente();
        DALPedido dalPed = new DALPedido();
        DALItemPedido dalItemPed = new DALItemPedido();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["perfil"].ToString() == "Cliente")
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


        private void carregarTabela()
        {

            DataTable rDta = new DataTable();
            rDta = dalProd.buscarTodosProdutosTipo("2", "S");
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>ID</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>NOME</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>DESCRIÇÃO</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>PRECO</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>FOTO</center></th>");
            sb.AppendLine("<th style='font-size:15px; letter-spacing: 1px;'><center>ADICIONAR</center></th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["ID_Produto"] + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["NOME_PROD"] + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["DESCRICAO_PROD"] + "</center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center>" + dtr["PRECO_UNI"] + "</center></td>");
                sb.AppendLine($@"<td style='font-size:15px; letter-spacing: 1px;'><center><img src='IMAGENS_PRODUTOS\{dtr["FOTO_Prod"]}'></center></td>");
                sb.AppendLine("<td style='font-size:15px; letter-spacing: 1px;'><center><a href='NovoPedidoFrigobar.aspx?PRODUTO_N=" + Criptografia.Encrypt(dtr["ID_Produto"].ToString()) + "'><i class='fa fa-plus' style='color: green'></i></center></td>");
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
            if (cli.FlagPedidoFrigobar=='S')
            {
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
                //string msg = $"<script> alert('Pedido Realizado: ID: {ped.IdPedido}'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-success alert-dismissible fade show' role='alert'>
                           Pedido Realizado: ID: {ped.IdPedido}  
                            </div>");
                //inativa a flag para o cliente fazer pedidos de frigobar
                cli.FlagPedidoFrigobar = 'N';
                dalCli.alterarCliente(cli);

            }
            else
            {
                //string msg = $"<script> alert('Carrinho Vazio!'); </script>";
                //Response.Write(msg);
                Response.Write($@"<div class='alert alert-danger alert-dismissible fade show' role='alert'>
                       Pedido não Permitido!
                            </div>");
            }
            
           
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


    }
}