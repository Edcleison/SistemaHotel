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
        string cnn = @"Data Source=LAPTOP-JV98S2OU\SQLEXPRESS;Initial Catalog=hotelServicos;Integrated Security=True";

        public void inserirCliente(string Nome, string Cpf, string Email, string Telefone)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[CLIENTE]
           ([NOME]
           ,[CPF]
           ,[EMAIL]
           ,[TELEFONE]
           ,[ATIVO]) 
            VALUES(@NOME ,@CPF,@EMAIL,@TELEFONE,'S')", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("NOME", Nome);
                        cmd.Parameters.AddWithValue("CPF", Cpf);
                        cmd.Parameters.AddWithValue("EMAIL", Email);
                        cmd.Parameters.AddWithValue("TELEFONE", Email);
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

        public Cliente buscarClienteId(string Id)
        {
            Cliente cli = new Cliente();
            SqlDataAdapter adp;

            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
                                                       ,[NOME]
                                                      ,[CPF]
                                                      ,[EMAIL]
                                                      ,[TELEFONE]
                                                      ,[ATIVO]
                                                       FROM [DBO].[CLIENTE]
                                                       WHERE ID = @ID", connection))
                    {
                        cmd.Parameters.AddWithValue("ID", Id);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            cli.Id = Convert.ToInt32(registro["ID"]);
                            cli.Nome = Convert.ToString(registro["NOME"]);
                            cli.Email = Convert.ToString(registro["EMAIL"]);
                            cli.Telefone = Convert.ToString(registro["TELEFONE"]);
                            cli.Ativo = Convert.ToChar(registro["ATIVO"]);
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

        public Cliente buscarClienteEmail(string Email)
        {

            Cliente cli = new Cliente();
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
                                                              ,[NOME]
                                                              ,[CPF]
                                                              ,[EMAIL]
                                                              ,[SENHA]
                                                              ,[TELEFONE]
                                                              ,[ATIVO]
                                                    FROM [DBO].[USUARIOS] WHERE EMAIL =@EMAIL AND ATIVO= 'S'" + "", connection))
                    {
                        cmd.Parameters.AddWithValue("EMAIL", Email);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            cli.Id = Convert.ToInt32(registro["ID"]);
                            cli.Nome = Convert.ToString(registro["NOME"]);
                            cli.Email = Convert.ToString(registro["EMAIL"]);
                            cli.Telefone = Convert.ToString(registro["TELEFONE"]);
                            cli.Ativo = Convert.ToChar(registro["ATIVO"]);
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
    }
}

