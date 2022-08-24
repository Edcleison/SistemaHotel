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
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=hotelservicos;Persist Security Info=True;User ID=hotelservicos;Password=Sc3f_r4_104t";

        public void inserirCliente(Cliente cli)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand                   
                    (@"INSERT INTO [dbo].[CLIENTE]
                       ([CD_RESERVA]
                       ,[DATA_INICIO]
                       ,[DATA_FIM]
                        ,ATIVO)
                        VALUES(@CD_RESERVA,@DATA_INICIO,@DATA_FIM,@ATIVO)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("CD_RESERVA", cli.Cd_Reserva);
                        cmd.Parameters.AddWithValue("DATA_INICIO", cli.DataInicio);
                        cmd.Parameters.AddWithValue("DATA_FIM", cli.DataFim);
                        cmd.Parameters.AddWithValue("ATIVO", 'S');
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    catch (Exception erro)
                    {
                        throw new Exception(erro.Message);
                    }

                }
            }
        }

        public Cliente buscarClienteId(int Id)
        {
            Cliente cli = new Cliente();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand(@"[ID]
                                                            ,[CD_RESERVA]
                                                            ,[DATA_INICIO]
                                                            ,[DATA_FIM]
                                                        FROM [dbo].[CLIENTE]
                                                       WHERE ID = @ID AND ATIVO ='S'", connection))
                    {
                        cmd.Parameters.AddWithValue("ID", Id);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            cli.Id = Convert.ToInt32(registro["ID"]);
                            cli.Cd_Reserva = Convert.ToString(registro["CD_RESERVA"]);
                            cli.DataInicio = Convert.ToDateTime(registro["DATA_INICIO"]);
                            cli.DataFim = Convert.ToDateTime(registro["DATA_FIM"]);
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

            return cli;
        }

        public Cliente buscarClienteReserva(string Reserva)
        {

            Cliente cli = new Cliente();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
                                                          ,[CD_RESERVA]
                                                          ,[DATA_INICIO]
                                                          ,[DATA_FIM]                                                         
                                                        FROM [dbo].[CLIENTE]
                                                         WHERE CD_RESERVA=@CD_RESERVA AND ATIVO ='S'", connection))
                    {
                        cmd.Parameters.AddWithValue("CD_RESERVA", Reserva);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            cli.Id = Convert.ToInt32(registro["ID"]);
                            cli.Cd_Reserva = Convert.ToString(registro["CD_RESERVA"]);
                            cli.DataInicio = Convert.ToDateTime(registro["DATA_INICIO"]);
                            cli.DataFim = Convert.ToDateTime(registro["DATA_FIM"]);
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

            return cli;
        }

        public void alterarCliente(Cliente cli)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE CLIENTE SET CD_RESERVA = @CD_RESERVA, DATA_INICIO = @DATA_INICIO, 
                                                        DATA_FIM = @DATA_FIM WHERE  ID = @ID", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID", cli.Id);
                        cmd.Parameters.AddWithValue("CD_RESERVA", cli.Cd_Reserva);
                        cmd.Parameters.AddWithValue("DATA_INICIO", cli.DataInicio);
                        cmd.Parameters.AddWithValue("DATA_FIM", cli.DataFim);
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    catch (Exception erro)
                    {
                        throw new Exception(erro.Message);
                    }


                }

            }
        }
    }
}

