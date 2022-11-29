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
    public static class DALPedidoCozinha
    {
        static string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";
        public static void inserirPedidoCozinha(PedidoCozinha ped)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[PEDIDO]
                                                       ([ID_STATUS_PED]
                                                       ,[ID_CLIENTE]
                                                       ,[ID_ADM]
                                                       ,[ID_FUNCIONARIO]
                                                       ,[VALOR_TOTAL]
                                                       ,[DATA_ABERTURA])
                                                        VALUES
                                                        (@ID_STATUS,@ID_CLIENTE,NULLIF(@ID_ADM,''),NULLIF(@ID_FUNCIONARIO,''),@VALOR_TOTAL,@DATA_ABERTURA)", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID_STATUS", ped.IdStatus);
                        cmd.Parameters.AddWithValue("ID_CLIENTE", ped.IdCliente);
                        cmd.Parameters.AddWithValue("ID_ADM", ped.IdAdm);
                        cmd.Parameters.AddWithValue("ID_FUNCIONARIO", ped.IdFuncionario);
                        cmd.Parameters.AddWithValue("VALOR_TOTAL", ped.ValorTotal);
                        cmd.Parameters.AddWithValue("DATA_ABERTURA", ped.DataAbertura);
                        cmd.ExecuteNonQuery();
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
        }

        public static PedidoCozinha buscarPedidoCozinhaIdClienteData(int IdCliente, DateTime DataAbertura)
        {
            PedidoCozinha ped = new PedidoCozinha();

            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_PEDIDO]
                                                                ,[ID_STATUS_PED]
                                                                ,[ID_CLIENTE]                                                                
                                                                ,[VALOR_TOTAL]
                                                                ,[DATA_ABERTURA]                                                          
                                                          FROM [dbo].[PEDIDO] WHERE ID_CLIENTE = @ID_CLIENTE and DATA_ABERTURA = @DATA_ABERTURA", connection))
                {
                    try
                    {

                        cmd.Parameters.AddWithValue("@ID_CLIENTE", IdCliente);
                        cmd.Parameters.AddWithValue("@DATA_ABERTURA", DataAbertura);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            ped.IdPedido = Convert.ToInt32(registro["ID_PEDIDO"]);
                            ped.IdStatus = Convert.ToInt32(registro["ID_STATUS_PED"]);
                            ped.IdCliente = Convert.ToInt32(registro["ID_CLIENTE"]);
                            ped.ValorTotal = Convert.ToDecimal(registro["VALOR_TOTAL"]);
                            ped.DataAbertura = Convert.ToDateTime(registro["DATA_ABERTURA"]);
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
            return ped;
        }

        public static void alterarStatusAtendimentoFuncionario(PedidoCozinha ped)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [DBO].[PEDIDO]
                                                       SET [ID_STATUS_PED] = @ID_STATUS_PED
                                                          ,[ID_FUNCIONARIO] = @ID_FUNCIONARIO                                                        
                                                          ,[DATA_FINALIZACAO] = @DATA_FINALIZACAO
                                                     WHERE ID_PEDIDO = @ID_PEDIDO", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID_STATUS_PED", ped.IdStatus);
                        cmd.Parameters.AddWithValue("ID_FUNCIONARIO", ped.IdFuncionario);
                        cmd.Parameters.AddWithValue("DATA_FINALIZACAO", ped.DataFinalizacao);
                        cmd.Parameters.AddWithValue("ID_PEDIDO", ped.IdPedido);
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

        public static void alterarStatusAtendimentoAdm(PedidoCozinha ped)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [DBO].[PEDIDO]
                                                       SET [ID_STATUS_PED] = @ID_STATUS_PED
                                                          ,[ID_ADM] = @ID_ADM                                                        
                                                          ,[DATA_FINALIZACAO] = @DATA_FINALIZACAO
                                                     WHERE ID_PEDIDO = @ID_PEDIDO", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID_STATUS_PED", ped.IdStatus);
                        cmd.Parameters.AddWithValue("ID_ADM", ped.IdAdm);
                        cmd.Parameters.AddWithValue("DATA_FINALIZACAO", ped.DataFinalizacao);
                        cmd.Parameters.AddWithValue("ID_PEDIDO", ped.IdPedido);
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

