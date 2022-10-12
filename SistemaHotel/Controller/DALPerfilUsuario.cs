using SistemaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaHotel.Controller
{
    public static class DALPerfilUsuario
    {
        static string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        public static void inserirPerfilUsuario(PerfilUsuario pUsu)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [DBO].[PERFIL_USUARIO]
                                                       ([ID_USUARIO]
                                                       ,[ID_PERFIL]
                                                       ,[STATUS_USUARIO])
                                                 VALUES(@ID_USUARIO,@ID_PERFIL,@STATUS_USUARIO)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID_USUARIO", pUsu.IdUsuario);
                        cmd.Parameters.AddWithValue("ID_PERFIL", pUsu.IdPerfil);
                        cmd.Parameters.AddWithValue("STATUS_USUARIO", pUsu.StatusPerfilUsuario);
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
        public static PerfilUsuario buscarUsuarioPerfil(int IdUsuario)
        {
            PerfilUsuario pUsu = new PerfilUsuario();

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_PERFIL_USUARIO]
                                                          ,[ID_USUARIO]
                                                          ,[ID_PERFIL]
                                                          ,[STATUS_USUARIO]
                                                      FROM [DBO].[PERFIL_USUARIO] WHERE ID_USUARIO = @ID_USUARIO", connection))
                {
                    try
                    {

                        cmd.Parameters.AddWithValue("@ID_USUARIO", IdUsuario);
                        connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            pUsu.IdPerfilUsuario = Convert.ToInt32(registro["ID_PERFIL_USUARIO"]);
                            pUsu.IdUsuario = Convert.ToInt32(registro["ID_USUARIO"]);
                            pUsu.IdPerfil = Convert.ToInt32(registro["ID_PERFIL"]);
                            pUsu.StatusPerfilUsuario = Convert.ToChar(registro["STATUS_USUARIO"]);



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
            return pUsu;
        }

        public static void alterarPefilUsuario(PerfilUsuario perfUsu)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE PERFIL_USUARIO SET ID_PERFIL = @ID_PERFIL WHERE  ID_USUARIO = @ID_USUARIO", connection))
                {
                    try
                    {
                       
                        cmd.Parameters.AddWithValue("ID_PERFIL", perfUsu.IdPerfil);
                        cmd.Parameters.AddWithValue("ID_USUARIO", perfUsu.IdUsuario);
                        cmd.Connection.Open();
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

        public static void inativarUsuario(int IdUsuario)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[PERFIL_USUARIO] set STATUS_USUARIO = 'N' where ID_USUARIO=@ID_USUARIO", connection))
                {

                    try
                    {
                        cmd.Parameters.AddWithValue("ID_USUARIO", IdUsuario);
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
        public static void inativarUsuariosProc()
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"[dbo].[INATIVA_CLIENTES_DATA_VENCIDA]", connection))
                {

                    try
                    {
                        connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
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

        public static void ativarUsuario(int IdUsuario)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[PERFIL_USUARIO] set STATUS_USUARIO = 'S' where ID_USUARIO=@ID_USUARIO", connection))
                {

                    try
                    {
                        cmd.Parameters.AddWithValue("ID_USUARIO", IdUsuario);
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
    }
}