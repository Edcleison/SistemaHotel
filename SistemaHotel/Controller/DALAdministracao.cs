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

    public class DALAdministracao
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        public void inserirAdministracao(Administracao adm)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand
                    (@"INSERT INTO [DBO].[ADMINISTRACAO]
                                       ([ID_USUARIO]
                                       ,[ID_PERFIL])  
                                 VALUES (@ID_USUARIO,@ID_PERFIL)", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID_USUARIO", adm.IdUsuario);
                        cmd.Parameters.AddWithValue("ID_PERFIL", adm.IdPerfil);                       
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

  

        public Administracao buscarAdmId(int Id)
        {
            Administracao adm = new Administracao();
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_ADM]
                                                          ,[ID_USUARIO]
                                                          ,[ID_PERFIL]
                                                      FROM [DBO].[EQUIPE_ATENDIMENTO]
                                                       WHERE ID_USUARIO = @ID_USUARIO", connection))
                    {
                        cmd.Parameters.AddWithValue("ID_USUARIO", Id);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            adm.IdAdm = Convert.ToInt32(registro["ID_ADM"]);
                            adm.IdUsuario = Convert.ToInt32(registro["ID_USUARIO"]);
                            adm.IdPerfil = Convert.ToInt32(registro["ID_PERFIL"]);
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
            return adm;
        }
    }
}


