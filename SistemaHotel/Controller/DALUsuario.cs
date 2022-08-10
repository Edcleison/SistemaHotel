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
    public class DALUsuario
    {
        string cnn = @"Data Source=LAPTOP-JV98S2OU\SQLEXPRESS;Initial Catalog=hotelServicos;Integrated Security=True";

        //Creat
        public void inserirUsuario(Usuario usu)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[USUARIO]
                                                   ([NOME]
                                                   ,[EMAIL]
                                                   ,[SENHA])                                                 
                                             VALUES(@NOME,@EMAIL,@SENHA)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("NOME", usu.Nome);
                        cmd.Parameters.AddWithValue("EMAIL", usu.Email);
                        cmd.Parameters.AddWithValue("SENHA", usu.Senha);
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


        //Read

        public DataTable buscarTodosUsuarios()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
                                                      ,[NOME]
                                                      ,[EMAIL]
                                                      ,[SENHA]                                                     
                                                  FROM [DBO].[USUARIO]", connection))
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();

                    }
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            return dta;
        }


        public Usuario buscarUsuarioId(string Id)
        {
            Usuario usu = new Usuario();
            try
            {

                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM CLIENTES WHERE ID = @ID"))
                    {

                        cmd.Parameters.AddWithValue("@id", Id);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            usu.Id = Convert.ToInt32(registro["ID"]);
                            usu.Nome = Convert.ToString(registro["NOME"]);
                            usu.Email = Convert.ToString(registro["EMAIL"]);
                            usu.Senha = Convert.ToString(registro["SENHA"]);                           

                        }
                    }
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

            return usu;
        }

        public Usuario buscaUsuarioEmail(string Email)
        {
            Usuario usu = new Usuario();
            SqlDataAdapter adp;

            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
                                                      ,[NOME]
                                                      ,[EMAIL]
                                                      ,[SENHA]                                                     
                                                  FROM[DBO].[USUARIO] WHERE EMAIL = @EMAIL", connection))
                    {
                        cmd.Parameters.AddWithValue("EMAIL", Email);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            usu.Id = Convert.ToInt32(registro["ID"]);
                            usu.Nome = Convert.ToString(registro["NOME"]);
                            usu.Email = Convert.ToString(registro["EMAIL"]);
                            usu.Senha = Convert.ToString(registro["SENHA"]);
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            return usu;

        }
        

        //Update
        public void alterarUsuario(Usuario usu)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE USUARIO SET NOME = @NOME, EMAIL = @EMAIL where  ID = @ID", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("NOME", usu.Nome);
                        cmd.Parameters.AddWithValue("EMAIL", usu.Email);
                        cmd.Parameters.AddWithValue("ID", usu.Id);
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


        public void alterarSenha(Usuario usu)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE USUARIO SET SENHA =@SENHA where  ID = @ID", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("SENHA", usu.Senha);
                        cmd.Parameters.AddWithValue("ID", usu.Id);
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

