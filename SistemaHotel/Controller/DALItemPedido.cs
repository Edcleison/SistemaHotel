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
    }
}

