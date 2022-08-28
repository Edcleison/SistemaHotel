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

    public class DALEquipeAtendimento
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        public void InserirEquipeAtendimento(EquipeAtendimento equi)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand
                    (@"INSERT INTO [dbo].[EQUIPE_ATENDIMENTO]
                                       ([FK_USUARIO_Id_Usuario]
                                       ,[FK_PERFIL_Id_Perfil]
                                       ,[USUARIO_Nome_Usuario])
                                 VALUES (@FK_USUARIO_Id_Usuario,@FK_PERFIL_Id_Perfil,@USUARIO_Nome_Usuario)", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("FK_USUARIO_Id_Usuario", equi.IdUsuario);
                        cmd.Parameters.AddWithValue("FK_PERFIL_Id_Perfil", equi.IdPerfil);
                        cmd.Parameters.AddWithValue("USUARIO_Nome_Usuario", equi.NomeUsuario);  
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

  

        public EquipeAtendimento buscarEquipeId(int Id)
        {
            EquipeAtendimento equi = new EquipeAtendimento();
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Equipe]
                                                          ,[FK_USUARIO_Id_Usuario]
                                                          ,[FK_PERFIL_Id_Perfil]
                                                          ,[USUARIO_Nome_Usuario]
                                                      FROM [dbo].[EQUIPE_ATENDIMENTO]
                                                       WHERE FK_USUARIO_Id_Usuario = @FK_USUARIO_Id_Usuario", connection))
                    {
                        cmd.Parameters.AddWithValue("FK_USUARIO_Id_Usuario", Id);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            equi.IdEquipe = Convert.ToInt32(registro["Id_Equipe"]);
                            equi.IdUsuario = Convert.ToInt32(registro["FK_USUARIO_Id_Usuario"]);
                            equi.IdPerfil = Convert.ToInt32(registro["FK_PERFIL_Id_Perfil"]);
                            equi.NomeUsuario = Convert.ToString(registro["USUARIO_Nome_Usuario"]);                           
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
            return equi;
        }
    }
}


