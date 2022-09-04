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
    public class DALPedido
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        public void inserirPedido(Pedido ped)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[PEDIDO]
                                                       ([ID_STATUS]
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

        public DataTable buscarTodosPedidos()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_PEDIDO]
                                                               ,[ID_STATUS]
                                                               ,[ID_CLIENTE]
                                                               ,[ID_ADM]
                                                               ,[ID_FUNCIONARIO]
                                                               ,[VALOR_TOTAL]
                                                               ,[DATA_ABERTURA]
                                                              ,[DATA_FINALIZACAO]
                                                          FROM [dbo].[PEDIDO]", connection))
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

        public DataTable buscarTodosPedidosTipo(int Tipo)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand($@"SELECT P.[ID_PEDIDO]
                                                                ,P.[ID_STATUS]
                                                                ,P.[ID_CLIENTE]
                                                                ,P.[ID_ADM]
                                                                ,P.[ID_FUNCIONARIO]
                                                                ,P.[VALOR_TOTAL]
                                                                ,P.[DATA_ABERTURA]
                                                                ,P.[DATA_FINALIZACAO]
                                                                ,PR.ID_TIPO_PROD
                                                                FROM [dbo].[PEDIDO] P
                                                                INNER JOIN ITEM_PEDIDO IP ON (P.ID_PEDIDO=IP.ID_PEDIDO)
                                                                INNER JOIN PRODUTO PR ON(PR.ID_PRODUTO = IP.ID_PRODUTO)
                                                                WHERE PR.TIPO_PROD = {Tipo}", connection))
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

        public DataTable buscarTodosPedidosTipoStatus(int Tipo, int Status)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand($@"SELECT [ID_PEDIDO]
                                                                ,[ID_STATUS]
                                                                ,[ID_CLIENTE]
                                                                ,[ID_ADM]
                                                                ,[ID_FUNCIONARIO]
                                                                ,[VALOR_TOTAL]
                                                                ,[DATA_ABERTURA]
                                                                ,[DATA_FINALIZACAO]                                                              
                                                                FROM [dbo].[PEDIDO]
                                                                WHERE ID_STATUS= {Status} ", connection))
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

        public Pedido buscarPedidoId(int IdPedido)
        {
            Pedido ped = new Pedido();

            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_PEDIDO]
                                                                ,[ID_STATUS]
                                                                ,[ID_CLIENTE]
                                                                ,[ID_ADM]
                                                                ,[ID_FUNCIONARIO]
                                                                ,[VALOR_TOTAL]
                                                                ,[DATA_ABERTURA]
                                                                ,[DATA_FINALIZACAO] 
                                                          FROM [dbo].[PEDIDO] WHERE ID_PEDIDO = @ID_PEDIDO", connection))
                {
                    try
                    {

                        cmd.Parameters.AddWithValue("@Id_Pedido", IdPedido);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            ped.IdPedido = Convert.ToInt32(registro["ID_PEDIDO"]);
                            ped.IdStatus = Convert.ToInt32(registro["ID_STATUS"]);
                            ped.IdCliente = Convert.ToInt32(registro["ID_CLIENTE"]);
                            ped.IdAdm = Convert.ToInt32(registro["ID_ADM"]);
                            ped.IdFuncionario = Convert.ToInt32(registro["ID_FUNCIONARIO"]);
                            ped.ValorTotal = Convert.ToDecimal(registro["VALOR_TOTAL"]);
                            ped.DataAbertura = Convert.ToDateTime(registro["DATA_ABERTURA"]);
                            ped.DataFinalizacao = Convert.ToDateTime(registro["DATA_FINALIZACAO"]);


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

        public Pedido buscarPedidoIdClienteData(int IdCliente, DateTime DataAbertura)
        {
            Pedido ped = new Pedido();

            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_PEDIDO]
                                                                ,[ID_STATUS]
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
                            ped.IdStatus = Convert.ToInt32(registro["ID_STATUS"]);
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

        public void alterarStatusAtendimentoPedido(Pedido ped)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [DBO].[PEDIDO]
                                                       SET [ID_STATUS] = ID_STATUS
                                                          ,[ID_ADM] = NULLIF(@ID_ADM,'')                                                         
                                                          ,[ID_FUNCIONARIO] = NULLIF(@ID_FUNCIONARIO,'')                                                         
                                                          ,[DATA_FINALIZACAO] = @DATA_FINALIZACAO
                                                     WHERE ID_PEDIDO = @ID_PEDIDO", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID_STATUS", ped.IdStatus);
                        cmd.Parameters.AddWithValue("ID_ADM", ped.IdAdm);
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













    }
}

