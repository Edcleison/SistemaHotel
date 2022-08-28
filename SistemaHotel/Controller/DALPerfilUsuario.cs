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
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[PERFIL_USUARIO]
                                                       ([FK_USUARIO_Id_Usuario]
                                                       ,[FK_PERFIL_Id_Perfil]
                                                       ,[Status_Perfil_Usuario])
                                                 VALUES(@FK_USUARIO_Id_Usuario,@FK_PERFIL_Id_Perfil,@Status_Perfil_Usuario)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("FK_USUARIO_Id_Usuario", pUsu.IdUsuario);
                        cmd.Parameters.AddWithValue("FK_PERFIL_Id_Perfil", pUsu.IdPerfil);
                        cmd.Parameters.AddWithValue("Status_Perfil_Usuario", pUsu.StatusPerfilUsuario);
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
                using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Perfil_Usuario]
                                                          ,[FK_USUARIO_Id_Usuario]
                                                          ,[FK_PERFIL_Id_Perfil]
                                                          ,[Status_Perfil_Usuario]
                                                      FROM [dbo].[PERFIL_USUARIO] where FK_USUARIO_Id_Usuario = @FK_USUARIO_Id_Usuario", connection))
                {
                    try
                    {

                        cmd.Parameters.AddWithValue("@FK_USUARIO_Id_Usuario", IdUsuario);
                        connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            pUsu.IdPerfilUsuario = Convert.ToInt32(registro["Id_Perfil_Usuario"]);
                            pUsu.IdUsuario = Convert.ToInt32(registro["FK_USUARIO_Id_Usuario"]);
                            pUsu.IdPerfil = Convert.ToInt32(registro["FK_PERFIL_Id_Perfil"]);
                            pUsu.StatusPerfilUsuario = Convert.ToChar(registro["Status_Perfil_Usuario"]);



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

        public void excluirUsuario(int IdUsuario)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[PERFIL_USUARIO] WHERE FK_USUARIO_Id_Usuario = @FK_USUARIO_Id_Usuario", connection))
                {

                    try
                    {

                        connection.Open();
                        cmd.Parameters.AddWithValue("FK_USUARIO_Id_Usuario", IdUsuario);
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