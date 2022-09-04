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
                                                       ([ID_PEDIDO]
                                                       ,[ID_PRODUTO]
                                                       ,[ID_CLIENTE]
                                                       ,[QUANTIDADE]
                                                 VALUES
                                                        (@ID_PEDIDO,@ID_PRODUTO,@ID_CLIENTE,
                                                        @QUANTIDADE)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("Id_Pedido", ItemPed.IdPedido);
                        cmd.Parameters.AddWithValue("Id_Produto", ItemPed.IdProduto);
                        cmd.Parameters.AddWithValue("ID_CLIENTE", ItemPed.IdCliente);
                        cmd.Parameters.AddWithValue("Quantidade", ItemPed.Quantidade);
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


                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_PEDIDO]
                                                          ,[ID_PRODUTO]
                                                          ,[ID_CLIENTE]
                                                          ,[QUANTIDADE]
                                                      FROM [DBO].[ITEM_PEDIDO]", connection))
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

                using (SqlCommand cmd = new SqlCommand($@"SELECT P.[ID_PEDIDO]
                                                            ,P.[ID_STATUS]
                                                            ,P.[ID_USUARIO]
                                                            ,P.[ID_CLIENTE]
                                                            ,P.[VALOR_TOTAL]
                                                            ,P.[DATA_ABERTURA]
                                                            ,P.[DATA_FINALIZACAO]
                                                            ,IP.ID_PRODUTO
                                                            ,IP.QUANTIDADE
                                                            ,PR.ID_TIPO_PROD
                                                            FROM [DBO].[PEDIDO] P
                                                            INNER JOIN ITEM_PEDIDO IP ON(P.ID_PEDIDO =P.ID_PEDIDO)
                                                            INNER JOIN PRODUTO PR ON (PR.ID_PRODUTO =IP.ID_PRODUTO)
                                                            WHERE pr.ID_TIPO_PROD = {Tipo}", connection))
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

                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_PEDIDO]
                                                            ,[ID_PRODUTO]
                                                            ,[ID_CLIENTE]
                                                            ,[QUANTIDADE]
                                                        FROM [DBO].[ITEM_PEDIDO] WHERE ID_PEDIDO = @ID_PEDIDO", connection))
                {
                    try
                    {


                        cmd.Parameters.AddWithValue("@ID_PEDIDO", IdPedido);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            ItemPed.IdPedido = Convert.ToInt32(registro["ID_PEDIDO"]);
                            ItemPed.IdProduto = Convert.ToInt32(registro["ID_PRODUTO"]);
                            ItemPed.IdCliente = Convert.ToInt32(registro["ID_CLIENTE"]);
                            ItemPed.Quantidade = Convert.ToInt32(registro["QUANTIDADE"]);
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


                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_PEDIDO]
                                                            ,[ID_PRODUTO]
                                                            ,[ID_CLIENTE]
                                                            ,[QUANTIDADE]
                                                        FROM [DBO].[ITEM_PEDIDO] WHERE ID_PRODUTO = @ID_PRODUTO", connection))
                {
                    try
                    {

                        cmd.Parameters.AddWithValue("@Id_Produto", IdProduto);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            ItemPed.IdPedido = Convert.ToInt32(registro["ID_PEDIDO"]);
                            ItemPed.IdProduto = Convert.ToInt32(registro["ID_PRODUTO"]);
                            ItemPed.IdCliente = Convert.ToInt32(registro["ID_CLIENTE"]);
                            ItemPed.Quantidade = Convert.ToInt32(registro["QUANTIDADE"]);
                            ItemPed.IdCliente = Convert.ToInt32(registro["ID_CLIENTE"]);
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
                                                            ,[Id_Cliente]
                                                            ,[Quantidade]
                                                        FROM [dbo].[ITEM_PEDIDO] WHERE Id_Cliente = @Id_Cliente", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@ID_CLIENTE", IdCliente);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            ItemPed.IdPedido = Convert.ToInt32(registro["ID_PEDIDO"]);
                            ItemPed.IdProduto = Convert.ToInt32(registro["ID_PRODUTO"]);
                            ItemPed.IdCliente = Convert.ToInt32(registro["ID_CLIENTE"]);
                            ItemPed.Quantidade = Convert.ToInt32(registro["QUANTIDADE"]);
                            ItemPed.IdCliente = Convert.ToInt32(registro["ID_CLIENTE"]);
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

