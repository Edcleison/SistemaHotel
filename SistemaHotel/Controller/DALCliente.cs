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

    public class DALCliente
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";

        #region DALCliente_OLD
        //public void inserirCliente(Cliente cli)
        //{

        //    using (SqlConnection connection = new SqlConnection(cnn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand                   
        //            (@"INSERT INTO [dbo].[CLIENTE]
        //               ([CD_RESERVA]
        //               ,[DATA_INICIO]
        //               ,[DATA_FIM]
        //                ,ATIVO)
        //                VALUES(@CD_RESERVA,@DATA_INICIO,@DATA_FIM,@ATIVO)", connection))
        //        {

        //            try
        //            {
        //                cmd.Connection.Open();
        //                cmd.Parameters.AddWithValue("CD_RESERVA", cli.Cd_Reserva);
        //                cmd.Parameters.AddWithValue("DATA_INICIO", cli.DataInicio);
        //                cmd.Parameters.AddWithValue("DATA_FIM", cli.DataFim);
        //                cmd.Parameters.AddWithValue("ATIVO", 'S');
        //                cmd.ExecuteNonQuery();
        //                cmd.Connection.Close();
        //            }
        //            catch (Exception erro)
        //            {
        //                throw new Exception(erro.Message);
        //            }

        //        }
        //    }
        //}

        //public Cliente buscarClienteId(int Id)
        //{
        //    Cliente cli = new Cliente();
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(cnn))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(@"[ID]
        //                                                    ,[CD_RESERVA]
        //                                                    ,[DATA_INICIO]
        //                                                    ,[DATA_FIM]
        //                                                FROM [dbo].[CLIENTE]
        //                                               WHERE ID = @ID AND ATIVO ='S'", connection))
        //            {
        //                cmd.Parameters.AddWithValue("ID", Id);
        //                cmd.Connection.Open();
        //                SqlDataReader registro = cmd.ExecuteReader();
        //                if (registro.HasRows)
        //                {
        //                    registro.Read();
        //                    cli.Id = Convert.ToInt32(registro["ID"]);
        //                    cli.Cd_Reserva = Convert.ToString(registro["CD_RESERVA"]);
        //                    cli.DataInicio = Convert.ToDateTime(registro["DATA_INICIO"]);
        //                    cli.DataFim = Convert.ToDateTime(registro["DATA_FIM"]);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception erro)
        //    {
        //        throw new Exception(erro.Message);
        //    }

        //    return cli;
        //}

        //public Cliente buscarClienteReserva(string Reserva)
        //{

        //    Cliente cli = new Cliente();
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(cnn))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
        //                                                  ,[CD_RESERVA]
        //                                                  ,[DATA_INICIO]
        //                                                  ,[DATA_FIM]                                                         
        //                                                FROM [dbo].[CLIENTE]
        //                                                 WHERE CD_RESERVA=@CD_RESERVA AND ATIVO ='S'", connection))
        //            {
        //                cmd.Parameters.AddWithValue("CD_RESERVA", Reserva);
        //                cmd.Connection.Open();
        //                SqlDataReader registro = cmd.ExecuteReader();
        //                if (registro.HasRows)
        //                {
        //                    registro.Read();
        //                    cli.Id = Convert.ToInt32(registro["ID"]);
        //                    cli.Cd_Reserva = Convert.ToString(registro["CD_RESERVA"]);
        //                    cli.DataInicio = Convert.ToDateTime(registro["DATA_INICIO"]);
        //                    cli.DataFim = Convert.ToDateTime(registro["DATA_FIM"]);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception erro)
        //    {
        //        throw new Exception(erro.Message);
        //    }

        //    return cli;
        //}

        //public void alterarCliente(Cliente cli)
        //{
        //    using (SqlConnection connection = new SqlConnection(cnn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(@"UPDATE CLIENTE SET CD_RESERVA = @CD_RESERVA, DATA_INICIO = @DATA_INICIO, 
        //                                                DATA_FIM = @DATA_FIM WHERE  ID = @ID", connection))
        //        {

        //            try
        //            {
        //                cmd.Connection.Open();
        //                cmd.Parameters.AddWithValue("ID", cli.Id);
        //                cmd.Parameters.AddWithValue("CD_RESERVA", cli.Cd_Reserva);
        //                cmd.Parameters.AddWithValue("DATA_INICIO", cli.DataInicio);
        //                cmd.Parameters.AddWithValue("DATA_FIM", cli.DataFim);
        //                cmd.ExecuteNonQuery();
        //                cmd.Connection.Close();
        //            }
        //            catch (Exception erro)
        //            {
        //                throw new Exception(erro.Message);
        //            }


        //        }

        //    }
        //}
        #endregion

        public void inserirCliente(Cliente cli)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand
                    (@"INSERT INTO CLIENTE (COD_RESERVA,NOME_CLIENTE,QUARTO,DATA_ENTRADA,DATA_SAIDA) 
                      VALUES (@COD_RESERVA,@NOME_CLIENTE,@QUARTO,@DATA_ENTRADA,@DATA_SAIDA)", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("COD_RESERVA", cli.CodReserva);
                        cmd.Parameters.AddWithValue("NOME_CLIENTE", cli.NomeCliente);
                        cmd.Parameters.AddWithValue("QUARTO", cli.Quarto);
                        cmd.Parameters.AddWithValue("DATA_ENTRADA", cli.DataEntrada);
                        cmd.Parameters.AddWithValue("DATA_SAIDA", cli.DataSaida);
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

        public void alterarCliente(Cliente cli)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand
                    (@"UPDATE CLIENTE SET COD_RESERVA=@COD_RESERVA, NOME_CLIENTE=@NOME_CLIENTE, QUARTO=@QUARTO, 
                       DATA_ENTRADA=@DATA_ENTRADA,DATA_SAIDA=@DATA_SAIDA WHERE ID_CLIENTE = @ID_CLIENTE", connection))
                {

                    try
                    {
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("cod_reserva", cli.CodReserva);
                        cmd.Parameters.AddWithValue("nome_cliente", cli.NomeCliente);
                        cmd.Parameters.AddWithValue("quarto", cli.Quarto);
                        cmd.Parameters.AddWithValue("data_entrada", cli.DataEntrada);

                        cmd.Parameters.AddWithValue("data_saida", cli.DataSaida);
                        connection.Open();
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

        public void excluirCliente(int idCliente)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand
                    ($"delete from cliente where id_cliente = @id_cliente", connection))
                    try
                    {
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("id_cliente", idCliente);
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

        public Cliente buscarClienteId(int Id)
        {
            Cliente cli = new Cliente();
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                {

                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_CLIENTE]
                                                          ,[COD_RESERVA]
                                                          ,[NOME_CLIENTE]
                                                          ,[QUARTO]
                                                          ,[DATA_ENTRADA]
                                                          ,[DATA_SAIDA]
                                                      FROM [DBO].[CLIENTE]
                                                       WHERE ID_CLIENTE = @ID_CLIENTE", connection))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("ID_CLIENTE", Id);
                            cmd.Connection.Open();
                            SqlDataReader registro = cmd.ExecuteReader();
                            if (registro.HasRows)
                            {
                                registro.Read();
                                cli.IdCliente = Convert.ToInt32(registro["ID_CLIENTE"]);
                                cli.CodReserva = Convert.ToString(registro["COD_RESERVA"]);
                                cli.NomeCliente = Convert.ToString(registro["NOME_CLIENTE"]);
                                cli.Quarto = Convert.ToString(registro["DATA_ENTRADA"]);
                                cli.DataEntrada = Convert.ToDateTime(registro["DATA_SAIDA"]);
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
                return cli;
            }
        }
        public Cliente buscarClienteReserva(string Reserva)
        {
            Cliente cli = new Cliente();
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_CLIENTE]
                                                          ,[COD_RESERVA]
                                                          ,[NOME_CLIENTE]
                                                          ,[QUARTO]
                                                          ,[DATA_ENTRADA]
                                                          ,[DATA_SAIDA]
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
                            cli.CodReserva = Convert.ToString(registro["COD_RESERVA"]);
                            cli.NomeCliente = Convert.ToString(registro["NOME_CLIENTE"]);
                            cli.Quarto = Convert.ToString(registro["QUARTO"]);
                            cli.DataEntrada = Convert.ToDateTime(registro["DATA_ENTRADA"]);
                            cli.DataSaida = Convert.ToDateTime(registro["DATA_SAIDA"]);
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
    }
}




