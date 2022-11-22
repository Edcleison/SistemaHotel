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

    public static class DALQuarto
    {
        static string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        public static void inserirQuarto(Quarto qua)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand
                    (@"INSERT INTO [DBO].[QUARTO]
                                       ([NUMERO_QUARTO] 
                                        ,[DESCRICAO_QUARTO]                               
                                       ,[STATUS_QUAR])
                                 VALUES (@NUMERO_QUARTO,@DESCRICAO_QUARTO,@STATUS_QUAR)", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("NUMERO_QUARTO", qua.NumeroQuarto);
                        cmd.Parameters.AddWithValue("DESCRICAO_QUARTO", qua.DescricaoQuarto);
                        cmd.Parameters.AddWithValue("STATUS_QUAR", qua.StatusQuar);
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

        public static DataTable buscarTodosQuartos(string Status)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            string parStatus = "";
            if (Status != "")
            {
                parStatus = "WHERE STATUS_QUAR = @STATUS_QUAR";
            }
            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand($@"SELECT [ID_QUARTO]
                                                          ,[NUMERO_QUARTO]
                                                          ,[DESCRICAO_QUARTO]
                                                          ,[STATUS_QUAR]
                                                      FROM [DBO].[QUARTO] {parStatus}", connection))
                {
                    try
                    {
                        if (Status != "")
                        {
                            cmd.Parameters.AddWithValue("STATUS_QUAR", Status);
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

        public static Quarto buscarQuartoNumero(string Numero)
        {
            Quarto qua = new Quarto();
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT TOP 1 [ID_QUARTO]
                                                          ,[NUMERO_QUARTO]
                                                          ,[DESCRICAO_QUARTO]
                                                      FROM [DBO].[QUARTO]
                                                       WHERE NUMERO_QUARTO = @NUMERO_QUARTO", connection))
                    {
                        cmd.Parameters.AddWithValue("NUMERO_QUARTO", Numero);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            qua.IdQuarto = Convert.ToInt32(registro["ID_QUARTO"]);
                            qua.NumeroQuarto = Convert.ToString(registro["NUMERO_QUARTO"]);
                            qua.DescricaoQuarto = Convert.ToString(registro["DESCRICAO_QUARTO"]);
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
            return qua;
        }

        public static Quarto buscarQuartoId(int Id)
        {
            Quarto qua = new Quarto();
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_QUARTO]
                                                          ,[NUMERO_QUARTO]
                                                          ,[DESCRICAO_QUARTO]
                                                      FROM [DBO].[QUARTO]
                                                       WHERE ID_QUARTO = @ID_QUARTO", connection))
                    {
                        cmd.Parameters.AddWithValue("ID_QUARTO", Id);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            qua.IdQuarto = Convert.ToInt32(registro["ID_QUARTO"]);
                            qua.NumeroQuarto = Convert.ToString(registro["NUMERO_QUARTO"]);
                            qua.DescricaoQuarto = Convert.ToString(registro["DESCRICAO_QUARTO"]);
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
            return qua;
        }

        public static void alterarQuarto(Quarto qua)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [DBO].[QUARTO]
                                                       SET [NUMERO_QUARTO] =@NUMERO_QUARTO, [DESCRICAO_QUARTO] =@DESCRICAO_QUARTO
                                                          WHERE  ID_QUARTO = @ID_QUARTO", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("NUMERO_QUARTO", qua.NumeroQuarto);
                        cmd.Parameters.AddWithValue("DESCRICAO_QUARTO", qua.DescricaoQuarto);
                        cmd.Parameters.AddWithValue("ID_QUARTO", qua.IdQuarto);
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
        public static void inativarQuarto(int IdQuarto)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [DBO].[quarto] SET STATUS_QUAR = 'N' WHERE ID_QUARTO = @ID_QUARTO", connection))
                {

                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("ID_QUARTO", IdQuarto);
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
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
        public static void ativarQuarto(int IdQuarto)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [DBO].[quarto] SET STATUS_QUAR = 'S' WHERE ID_QUARTO = @ID_QUARTO", connection))
                {

                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("ID_QUARTO", IdQuarto);
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
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


