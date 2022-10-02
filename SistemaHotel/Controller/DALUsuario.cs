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
    public static class DALUsuario
    {
        static string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";

        public static void inserirUsuario(Usuario usu)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [DBO].[USUARIO]
                                                    ([LOGIN]
                                                    ,[SENHA]
                                                    ,[NOME]
                                                    ,[SOBRENOME])VALUES(@LOGIN,@SENHA,@NOME,@SOBRENOME)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("LOGIN", usu.Login);
                        cmd.Parameters.AddWithValue("SENHA", usu.Senha);
                        cmd.Parameters.AddWithValue("NOME", usu.NomeUsuario);
                        cmd.Parameters.AddWithValue("SOBRENOME", usu.SobrenomeUsuario);
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

        public static DataTable buscarUsuariosPerfilStatus(string Perfil, string Status)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            string parPerfilStatus = "";
            if (Perfil != "" && Status != "")
            {
                parPerfilStatus = "WHERE P.STATUS_USUARIO =@STATUS_USUARIO AND P.ID_PERFIL = @ID_PERFIL";
            }
            else if (Perfil != "" && Status == "")
            {
                parPerfilStatus = "WHERE P.ID_PERFIL = @ID_PERFIL";
            }
            else if (Perfil == "" && Status != "")
            {
                parPerfilStatus = "WHERE P.STATUS_USUARIO =@STATUS_USUARIO";
            }

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand($@"SELECT U.[ID_USUARIO]
                                                            ,U.NOME                                                         
                                                            ,U.SOBRENOME                                                          
                                                            ,U.[LOGIN]
                                                            ,U.[SENHA]
                                                            ,P.STATUS_USUARIO
                                                            ,P.ID_PERFIL
                                                            FROM [DBO].[USUARIO] U
                                                            INNER JOIN PERFIL_USUARIO P
                                                            ON (P.ID_USUARIO = U.ID_USUARIO) 
                                                            {parPerfilStatus}", connection))
                {
                    try
                    {
                        if (Perfil != "" && Status != "")
                        {
                            cmd.Parameters.AddWithValue("ID_PERFIL", Perfil);
                            cmd.Parameters.AddWithValue("@STATUS_USUARIO", Status);
                        }
                        else if (Perfil != "" && Status == "")
                        {
                            cmd.Parameters.AddWithValue("ID_PERFIL", Perfil);
                        }
                        else if (Perfil == "" && Status != "")
                        {
                            cmd.Parameters.AddWithValue("@STATUS_USUARIO", Status);
                        }

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

        public static DataTable buscarUsuariosClientesStatus(string Perfil, string Status)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            string parPerfilStatus = "";
            if (Perfil != "" && Status != "")
            {
                parPerfilStatus = "WHERE P.STATUS_USUARIO =@STATUS_USUARIO AND P.ID_PERFIL = @ID_PERFIL";
            }
            else if (Perfil != "" && Status == "")
            {
                parPerfilStatus = "WHERE P.ID_PERFIL = @ID_PERFIL";
            }
            else if (Perfil == "" && Status != "")
            {
                parPerfilStatus = "WHERE P.STATUS_USUARIO =@STATUS_USUARIO";
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand($@"SELECT U.[ID_USUARIO]  
                                                            ,U.NOME
                                                            ,U.SOBRENOME
                                                            ,U.[LOGIN]
                                                            ,U.[SENHA]
                                                            ,U.NOME
                                                            ,U.SOBRENOME
                                                            ,P.STATUS_USUARIO
                                                            ,P.ID_PERFIL
                                                            ,C.DATA_ENTRADA
                                                            ,C.DATA_SAIDA
                                                            ,C.ID_QUARTO
                                                            ,Q.DESCRICAO_QUARTO
                                                            FROM [DBO].[USUARIO] U
                                                            INNER JOIN CLIENTE C ON(C.COD_RESERVA = U.LOGIN)
                                                            INNER JOIN QUARTO Q ON (Q.ID_QUARTO = C.ID_QUARTO)
                                                            INNER JOIN PERFIL_USUARIO P ON (P.ID_USUARIO = U.ID_USUARIO)
                                                            {parPerfilStatus}", connection))
                    {
                        if (Perfil != "" && Status != "")
                        {
                            cmd.Parameters.AddWithValue("ID_PERFIL", Perfil);
                            cmd.Parameters.AddWithValue("@STATUS_USUARIO", Status);
                        }
                        else if (Perfil != "" && Status == "")
                        {
                            cmd.Parameters.AddWithValue("ID_PERFIL", Perfil);
                        }
                        else if (Perfil == "" && Status != "")
                        {
                            cmd.Parameters.AddWithValue("@STATUS_USUARIO", Status);
                        }
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

        public static Usuario buscarUsuarioId(int IdUsuario)
        {
            Usuario usu = new Usuario();

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_USUARIO]
                                                                      ,[LOGIN]
                                                                      ,[SENHA]
                                                                      ,[NOME]
                                                                      ,[SOBRENOME]
                                                                  FROM [DBO].[USUARIO] WHERE ID_USUARIO = @ID_USUARIO", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@ID_USUARIO", IdUsuario);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            usu.IdUsuario = Convert.ToInt32(registro["ID_USUARIO"]);
                            usu.Login = Convert.ToString(registro["LOGIN"]);
                            usu.Senha = Convert.ToString(registro["SENHA"]);
                            usu.NomeUsuario = Convert.ToString(registro["NOME"]);
                            usu.SobrenomeUsuario = Convert.ToString(registro["SOBRENOME"]);

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
            return usu;
        }

        public static Usuario buscaUsuarioLogin(string Login)
        {
            Usuario usu = new Usuario();

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_USUARIO]
                                                                      ,[LOGIN]
                                                                      ,[SENHA]
                                                                      ,[NOME]
                                                                      ,[SOBRENOME]
                                                                  FROM [DBO].[USUARIO] WHERE LOGIN = @LOGIN", connection))
                    {

                        cmd.Parameters.AddWithValue("@LOGIN", Login);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            usu.IdUsuario = Convert.ToInt32(registro["ID_USUARIO"]);
                            usu.Login = Convert.ToString(registro["LOGIN"]);
                            usu.Senha = Convert.ToString(registro["SENHA"]);
                            usu.NomeUsuario = Convert.ToString(registro["NOME"]);
                            usu.SobrenomeUsuario = Convert.ToString(registro["SOBRENOME"]);

                        }
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
            return usu;

        }

        public static void alterarUsuario(Usuario usu)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE USUARIO SET LOGIN = @LOGIN WHERE  ID_Usuario = @ID_USUARIO", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("LOGIN", usu.Login);
                        cmd.Parameters.AddWithValue("ID_USUARIO", usu.IdUsuario);
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

        public static void alterarSenha(Usuario usu)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE USUARIO SET SENHA =@SENHA WHERE  ID_USUARIO = @ID_USUARIO", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("SENHA", usu.Senha);
                        cmd.Parameters.AddWithValue("ID_USUARIO", usu.IdUsuario);
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

