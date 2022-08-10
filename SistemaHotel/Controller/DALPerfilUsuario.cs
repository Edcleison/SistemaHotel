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
        string cnn = @"Data Source=LAPTOP-JV98S2OU\SQLEXPRESS;Initial Catalog=hotelServicos;Integrated Security=True";



        public void inserirPerfil(PerfilUsuario pUsu)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [DBO].[PERFIL_USUARIO]
                                                   ([PERFIL]
                                                   ,[EMAIL]
                                                    ,[ATIVO])
                                             VALUES(@PERFIL,@EMAIL,@ATIVO)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("PERFIL", pUsu.Perfil);
                        cmd.Parameters.AddWithValue("EMAIL", pUsu.Email);
                        cmd.Parameters.AddWithValue("ATIVO",'S');
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

        public PerfilUsuario buscarUsuarioPerfil(string email)
        {
            PerfilUsuario pUsu = new PerfilUsuario();      
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
                                                        ,[PERFIL]
                                                        ,[EMAIL]
                                                        ,[ATIVO]
                                                    FROM[DBO].[PERFIL_USUARIO] where EMAIL = @EMAIL", connection))
                    {
                        cmd.Parameters.AddWithValue("@EMAIL", email);
                        connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            pUsu.Id = Convert.ToInt32(registro["ID"]);
                            pUsu.Perfil = Convert.ToInt32(registro["PERFIL"]);
                            pUsu.Email = Convert.ToString(registro["EMAIL"]);
                            pUsu.Ativo = Convert.ToChar(registro["ATIVO"]);
                            

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

        public void inativarUsuario(int Id)
        {

            //usu.
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE PERFIL_USUARIO SET ATIVO = 'N' WHERE ID = @ID", connection))
                {

                    try
                    {

                        connection.Open();
                        cmd.Parameters.AddWithValue("ID", Id);
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

        public void ativarUsuario(int Id)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE USUARIO SET ATIVO = 'S', NOME= @NOME, SENHA= @SENHA WHERE EMAIL = @EMAIL", connection))
                {

                    try
                    {

                        connection.Open();
                        cmd.Parameters.AddWithValue("ID", Id);
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