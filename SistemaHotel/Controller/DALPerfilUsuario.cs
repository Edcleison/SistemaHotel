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
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=hotelservicos;Persist Security Info=True;User ID=hotelservicos;Password=Sc3f_r4_104t";




        public void inserirPerfil(PerfilUsuario pUsu)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [DBO].[PERFIL_USUARIO]
                                                   ([PERFIL]                                                   
                                                    ,[ATIVO]
                                                     ,[ID_USUARIO])
                                             VALUES(@PERFIL,@ATIVO,@ID_USUARIO)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("PERFIL", pUsu.Perfil);                        
                        cmd.Parameters.AddWithValue("ATIVO",'S');
                        cmd.Parameters.AddWithValue("ID_USUARIO",pUsu.IdUsuario);
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

        public PerfilUsuario buscarUsuarioPerfil(int IdUsuario)
        {
            PerfilUsuario pUsu = new PerfilUsuario();      
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
                                                        ,[PERFIL]
                                                        ,[ATIVO]
                                                        ,[ID_USUARIO]
                                                    FROM[DBO].[PERFIL_USUARIO] where ID_USUARIO = @ID_USUARIO", connection))
                    {
                        cmd.Parameters.AddWithValue("@ID_USUARIO", IdUsuario);
                        connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            pUsu.Id = Convert.ToInt32(registro["ID"]);
                            pUsu.Perfil = Convert.ToInt32(registro["PERFIL"]);                            
                            pUsu.Ativo = Convert.ToChar(registro["ATIVO"]);
                            pUsu.ID_USUARIO = Convert.ToInt32(registro["IdUsuario"]);
                            

                        }
                    }
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            return pUsu;

        }

        public void excluirUsuario(int IdUsuario)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[PERFIL_USUARIO] WHERE ID_USUARIO = @ID_USUARIO", connection))
                {

                    try
                    {

                        connection.Open();
                        cmd.Parameters.AddWithValue("ID_USUARIO", IdUsuario);
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