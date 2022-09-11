using SistemaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaHotel.Controller
{
    public class DALPerfilUsuario
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";



        #region DALPerfilUsuario_OLD
        //public void inserirPerfil(PerfilUsuario pUsu)
        //{
        //    using (SqlConnection connection = new SqlConnection(cnn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [DBO].[PERFIL_USUARIO]
        //                                           ([ID_PERFIL]                                                   
        //                                            ,[ATIVO]
        //                                             ,[ID_USUARIO])
        //                                     VALUES(@ID_PERFIL,@ATIVO,@ID_USUARIO)", connection))
        //        {

        //            try
        //            {
        //                cmd.Connection.Open();
        //                cmd.Parameters.AddWithValue("ID_PERFIL", pUsu.Perfil);                        
        //                cmd.Parameters.AddWithValue("ATIVO",'S');
        //                cmd.Parameters.AddWithValue("ID_USUARIO",pUsu.IdUsuario);
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

        //public PerfilUsuario buscarUsuarioPerfil(int IdUsuario)
        //{
        //    PerfilUsuario pUsu = new PerfilUsuario();      
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(cnn))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
        //                                                ,[ID_PERFIL]
        //                                                ,[ATIVO]
        //                                                ,[ID_USUARIO]
        //                                            FROM[DBO].[PERFIL_USUARIO] where ID_USUARIO = @ID_USUARIO", connection))
        //            {
        //                cmd.Parameters.AddWithValue("@ID_USUARIO", IdUsuario);
        //                connection.Open();
        //                SqlDataReader registro = cmd.ExecuteReader();
        //                if (registro.HasRows)
        //                {
        //                    registro.Read();
        //                    pUsu.Id = Convert.ToInt32(registro["ID"]);
        //                    pUsu.Perfil = Convert.ToInt32(registro["ID_PERFIL"]);                            
        //                    pUsu.Ativo = Convert.ToChar(registro["ATIVO"]);
        //                    pUsu.IdUsuario = Convert.ToInt32(registro["ID_USUARIO"]);


        //                }
        //            }
        //        }
        //    }
        //    catch (Exception erro)
        //    {
        //        throw new Exception(erro.Message);
        //    }
        //    return pUsu;

        //}

        //public void excluirUsuario(int IdUsuario)
        //{

        //    using (SqlConnection connection = new SqlConnection(cnn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[PERFIL_USUARIO] WHERE ID_USUARIO = @ID_USUARIO", connection))
        //        {

        //            try
        //            {

        //                connection.Open();
        //                cmd.Parameters.AddWithValue("ID_USUARIO", IdUsuario);
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

        public void inserirPerfilUsuario(PerfilUsuario pUsu)
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
        public PerfilUsuario buscarUsuarioPerfil(int IdUsuario)
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

        public void inativarUsuario(int IdUsuario)
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

        public void ativarUsuario(int IdUsuario)
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