using SistemaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SistemaHotel.Controller
{
    public class DALItemPedido
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        public void inserirItemPedido(ItemPedido ItemPed)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[ITEM_PEDIDO]
                                                       ([Id_Pedido]
                                                       ,[Id_Produto]
                                                       ,[FK_PEDIDO_Id_Cliente]
                                                       ,[Quantidade]
                                                       ,[PRODUTO_Descricao_Prod]
                                                       ,[PRODUTO_Nome_Prod])
                                                 VALUES

                                                        (@Id_Pedido,@Id_Produto,@FK_PEDIDO_Id_Cliente,
                                                        @Quantidade,@PRODUTO_Descricao_Prod,@PRODUTO_Nome_Prod)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("Id_Pedido", ItemPed.IdPedido);
                        cmd.Parameters.AddWithValue("Id_Produto", ItemPed.IdProduto);
                        cmd.Parameters.AddWithValue("FK_PEDIDO_Id_Cliente", ItemPed.IdCliente);
                        cmd.Parameters.AddWithValue("Quantidade", ItemPed.Quantidade);
                        cmd.Parameters.AddWithValue("PRODUTO_Descricao_Prod", ItemPed.DescricaoProduto);
                        cmd.Parameters.AddWithValue("PRODUTO_Nome_Prod", ItemPed.NomeProduto);
                        cmd.ExecuteNonQuery();
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

        public DataTable buscarTodosItensPedidos()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Pedido]
                                                          ,[Id_Produto]
                                                          ,[FK_PEDIDO_Id_Cliente]
                                                          ,[Quantidade]
                                                          ,[PRODUTO_Descricao_Prod]
                                                          ,[PRODUTO_Nome_Prod]
                                                      FROM [dbo].[ITEM_PEDIDO]", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);

                    }

                    catch (Exception erro)
                    {
                        throw new Exception(erro.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }
            return dta;
        }

        public DataTable buscarTodosPedidosTipo(int Tipo)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand($@"SELECT [Id_Pedido]
                                                              ,[FK_STATUS_Id_Status]
                                                              ,[FK_TIPO_PEDIDO_Id_Tipo_Ped]
                                                              ,[FK_EQUIPE_ATENDIMENTO_Id_Equipe]
                                                              ,[FK_CLIENTE_Id_Cliente]
                                                              ,[ITEM_PRODUTO_Descricao_Prod]
                                                              ,[CLIENTE_Quarto]
                                                              ,[ITEM_PEDIDO_Nome_Prod]
                                                              ,[Valor_Total]
                                                              ,[Data_Abertura]
                                                          FROM [dbo].[PEDIDO]
                                                        WHERE FK_TIPO_PEDIDO_Id_Tipo_Ped = {Tipo}", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);

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

            return dta;
        }


        public ItemPedido buscarPedidoId(int IdPedido)
        {
            ItemPedido ItemPed = new ItemPedido();

            using (SqlConnection connection = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Pedido]
                                                            ,[Id_Produto]
                                                            ,[FK_PEDIDO_Id_Cliente]
                                                            ,[Quantidade]
                                                            ,[PRODUTO_Descricao_Prod]
                                                            ,[PRODUTO_Nome_Prod]
                                                        FROM [dbo].[ITEM_PEDIDO] WHERE Id_Pedido = @Id_Pedido", connection))
                {
                    try
                    {


                        cmd.Parameters.AddWithValue("@Id_Pedido", IdPedido);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            ItemPed.IdPedido = Convert.ToInt32(registro["Id_Pedido"]);
                            ItemPed.IdProduto = Convert.ToInt32(registro["Id_Produto"]);
                            ItemPed.IdCliente = Convert.ToInt32(registro["FK_PEDIDO_Id_Cliente"]);
                            ItemPed.Quantidade = Convert.ToInt32(registro["Quantidade"]);
                            ItemPed.IdCliente = Convert.ToInt32(registro["FK_CLIENTE_Id_Cliente"]);
                            ItemPed.DescricaoProduto = Convert.ToString(registro["ITEM_PRODUTO_Descricao_Prod"]);
                            ItemPed.NomeProduto = Convert.ToString(registro["ITEM_PEDIDO_Nome_Prod"]);
                        }
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

            return ItemPed;
        }

        public ItemPedido buscarProdutoId(int IdProduto)
        {
            ItemPedido ItemPed = new ItemPedido();

            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Pedido]
                                                            ,[Id_Produto]
                                                            ,[FK_PEDIDO_Id_Cliente]
                                                            ,[Quantidade]
                                                            ,[PRODUTO_Descricao_Prod]
                                                            ,[PRODUTO_Nome_Prod]
                                                        FROM [dbo].[ITEM_PEDIDO] WHERE Id_Produto = @Id_Produto", connection))
                {
                    try
                    {

                        cmd.Parameters.AddWithValue("@Id_Produto", IdProduto);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            ItemPed.IdPedido = Convert.ToInt32(registro["Id_Pedido"]);
                            ItemPed.IdProduto = Convert.ToInt32(registro["Id_Produto"]);
                            ItemPed.IdCliente = Convert.ToInt32(registro["FK_PEDIDO_Id_Cliente"]);
                            ItemPed.Quantidade = Convert.ToInt32(registro["Quantidade"]);
                            ItemPed.IdCliente = Convert.ToInt32(registro["FK_CLIENTE_Id_Cliente"]);
                            ItemPed.DescricaoProduto = Convert.ToString(registro["ITEM_PRODUTO_Descricao_Prod"]);
                            ItemPed.NomeProduto = Convert.ToString(registro["ITEM_PEDIDO_Nome_Prod"]);
                        }
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
            return ItemPed;
        }

        public ItemPedido buscarClienteId(int IdCliente)
        {
            ItemPedido ItemPed = new ItemPedido();

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Pedido]
                                                            ,[Id_Produto]
                                                            ,[FK_PEDIDO_Id_Cliente]
                                                            ,[Quantidade]
                                                            ,[PRODUTO_Descricao_Prod]
                                                            ,[PRODUTO_Nome_Prod]
                                                        FROM [dbo].[ITEM_PEDIDO] WHERE FK_PEDIDO_Id_Cliente = @FK_PEDIDO_Id_Cliente", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@FK_PEDIDO_Id_Cliente", IdCliente);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            ItemPed.IdPedido = Convert.ToInt32(registro["Id_Pedido"]);
                            ItemPed.IdProduto = Convert.ToInt32(registro["Id_Produto"]);
                            ItemPed.IdCliente = Convert.ToInt32(registro["FK_PEDIDO_Id_Cliente"]);
                            ItemPed.Quantidade = Convert.ToInt32(registro["Quantidade"]);
                            ItemPed.IdCliente = Convert.ToInt32(registro["FK_CLIENTE_Id_Cliente"]);
                            ItemPed.DescricaoProduto = Convert.ToString(registro["ITEM_PRODUTO_Descricao_Prod"]);
                            ItemPed.NomeProduto = Convert.ToString(registro["ITEM_PEDIDO_Nome_Prod"]);
                        }
                    }
                    catch (Exception erro)
                    {
                        throw new Exception(erro.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return ItemPed;
        }
    }
}

