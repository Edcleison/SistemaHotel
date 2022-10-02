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

    public static class DALCliente
    {
        static string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";

        public static void inserirCliente(Cliente cli)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand
                    (@"INSERT INTO CLIENTE (COD_RESERVA,ID_QUARTO,NOME_CLIENTE,SOBRENOME_CLIENTE,DATA_ENTRADA,DATA_SAIDA,FLAG_PEDIDO_FRIGOBAR) 
                      VALUES (@COD_RESERVA,@ID_QUARTO,@NOME_CLIENTE,@SOBRENOME_CLIENTE,@DATA_ENTRADA,@DATA_SAIDA,@FLAG_PEDIDO_FRIGOBAR)", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID_QUARTO", cli.IdQuarto);
                        cmd.Parameters.AddWithValue("COD_RESERVA", cli.CodReserva);
                        cmd.Parameters.AddWithValue("NOME_CLIENTE", cli.NomeCliente);
                        cmd.Parameters.AddWithValue("SOBRENOME_CLIENTE", cli.SobreNomeCliente);                 
                        cmd.Parameters.AddWithValue("DATA_ENTRADA", cli.DataEntrada);
                        cmd.Parameters.AddWithValue("DATA_SAIDA", cli.DataSaida);
                        cmd.Parameters.AddWithValue("FLAG_PEDIDO_FRIGOBAR", cli.FlagPedidoFrigobar);
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

        public static void alterarCliente(Cliente cli)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand
                    (@"UPDATE CLIENTE SET ID_QUARTO=@ID_QUARTO,COD_RESERVA=@COD_RESERVA, NOME_CLIENTE=@NOME_CLIENTE, SOBRENOME_CLIENTE=@SOBRENOME_CLIENTE, 
                       DATA_ENTRADA=@DATA_ENTRADA,DATA_SAIDA=@DATA_SAIDA,FLAG_PEDIDO_FRIGOBAR=@FLAG_PEDIDO_FRIGOBAR WHERE ID_CLIENTE = @ID_CLIENTE", connection))
                {

                    try
                    {
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("ID_QUARTO", cli.IdQuarto);
                        cmd.Parameters.AddWithValue("COD_RESERVA", cli.CodReserva);
                        cmd.Parameters.AddWithValue("NOME_CLIENTE", cli.NomeCliente);                      
                        cmd.Parameters.AddWithValue("SOBRENOME_CLIENTE", cli.SobreNomeCliente);                      
                        cmd.Parameters.AddWithValue("DATA_ENTRADA", cli.DataEntrada);
                        cmd.Parameters.AddWithValue("DATA_SAIDA", cli.DataSaida);
                        cmd.Parameters.AddWithValue("ID_CLIENTE", cli.IdCliente);
                        cmd.Parameters.AddWithValue("FLAG_PEDIDO_FRIGOBAR", cli.FlagPedidoFrigobar);
                        connection.Open();
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

        public static Cliente buscarClienteReserva(string Reserva)
        {
            Cliente cli = new Cliente();
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_CLIENTE]
                                                          ,[ID_QUARTO]
                                                          ,[COD_RESERVA]
                                                          ,[NOME_CLIENTE]
                                                          ,[SOBRENOME_CLIENTE]
                                                          ,[DATA_ENTRADA]
                                                          ,[DATA_SAIDA]
                                                          ,[FLAG_PEDIDO_FRIGOBAR]
                                                        FROM [dbo].[CLIENTE]
                                                         WHERE COD_RESERVA=@COD_RESERVA", connection))
                {
                    try
                    {

                        cmd.Parameters.AddWithValue("COD_RESERVA", Reserva);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            cli.IdCliente = Convert.ToInt32(registro["ID_Cliente"]);
                            cli.IdQuarto = Convert.ToInt32(registro["ID_QUARTO"]);
                            cli.CodReserva = Convert.ToString(registro["COD_RESERVA"]);
                            cli.NomeCliente = Convert.ToString(registro["NOME_CLIENTE"]);
                            cli.SobreNomeCliente = Convert.ToString(registro["SOBRENOME_CLIENTE"]);
                            cli.DataEntrada = Convert.ToDateTime(registro["DATA_ENTRADA"]);
                            cli.DataSaida = Convert.ToDateTime(registro["DATA_SAIDA"]);
                            cli.FlagPedidoFrigobar = Convert.ToChar(registro["FLAG_PEDIDO_FRIGOBAR"]);
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
                    return cli;
                }
            }
        }

        public static DataTable verificarOcupacaoQuarto(string IdQuarto)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;            
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand($@"SELECT TOP 1 C.[ID_CLIENTE]
                                                        ,C.[ID_QUARTO]
                                                        ,C.[DATA_SAIDA]
                                                        ,Q.NUMERO_QUARTO
                                                        ,Q.DESCRICAO_QUARTO
                                                        FROM [DBO].[CLIENTE] C
                                                        INNER JOIN QUARTO Q ON (Q.ID_QUARTO = C.ID_QUARTO)
                                                        WHERE C.ID_QUARTO = @ID_QUARTO
                                                        ORDER BY [DATA_SAIDA] DESC ", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("ID_QUARTO", IdQuarto);
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
                    
                    return dta;
                    
                    
                }
            }
        }

    }
}




