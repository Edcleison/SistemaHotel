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

    public class DALFuncionario
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        public void inserirFuncionario(Funcionario fun)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand
                    (@"INSERT INTO [DBO].[FUNCIONARIO]
                                       ([ID_USUARIO]
                                       ,[ID_PERFIL])                                      
                                 VALUES (@ID_USUARIO,@ID_PERFIL)", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID_USUARIO", fun.IdUsuario);
                        cmd.Parameters.AddWithValue("ID_PERFIL", fun.IdPerfil);                       
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

  

        public Funcionario buscarFuncionarioIdUsuario(int IdUsuario)
        {
            Funcionario fun = new Funcionario();
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_FUNCIONARIO]
                                                          ,[ID_USUARIO]
                                                          ,[ID_PERFIL]
                                                      FROM [DBO].[FUNCIONARIO]
                                                       WHERE ID_USUARIO = @ID_USUARIO", connection))
                    {
                        cmd.Parameters.AddWithValue("ID_USUARIO", IdUsuario);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            fun.IdFuncionario = Convert.ToInt32(registro["ID_FUNCIONARIO"]);
                            fun.IdUsuario = Convert.ToInt32(registro["ID_USUARIO"]);
                            fun.IdPerfil = Convert.ToInt32(registro["ID_PERFIL"]);
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
            return fun;
        }
    }
}


