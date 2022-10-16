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
    public static class DALItemPedido
    {
        static  string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        public static void inserirItemPedido(ItemPedido ItemPed)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[ITEM_PEDIDO]
                                                       ([ID_PEDIDO]
                                                       ,[ID_PRODUTO]
                                                       ,[ID_CLIENTE]
                                                       ,[QUANTIDADE])
                                                 VALUES
                                                        (@ID_PEDIDO,@ID_PRODUTO,@ID_CLIENTE,
                                                        @QUANTIDADE)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID_PEDIDO", ItemPed.IdPedido);
                        cmd.Parameters.AddWithValue("ID_PRODUTO", ItemPed.IdProduto);
                        cmd.Parameters.AddWithValue("ID_CLIENTE", ItemPed.IdCliente);
                        cmd.Parameters.AddWithValue("QUANTIDADE", ItemPed.Quantidade);
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

        public static DataTable buscarTipoPedidooId(int IdPedido)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT TOP 1  IP.[ID_PEDIDO]
                                                        ,TP.ID_TIPO_PROD
                                                        FROM [SERVICOHOTELARIA].[DBO].[ITEM_PEDIDO] IP
                                                        INNER JOIN PRODUTO P ON (IP.ID_PRODUTO = P.ID_PRODUTO)
                                                        INNER JOIN TIPO_PRODUTO TP ON (TP.ID_TIPO_PROD = P.ID_TIPO_PROD)
                                                        WHERE ID_PEDIDO =@ID_PEDIDO", connection))
                {
                    try
                    {

                        cmd.Parameters.AddWithValue("@ID_PEDIDO", IdPedido);
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
    }
}

