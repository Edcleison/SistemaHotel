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

    public class DALQuarto
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        public void inserirQuarto(Quarto qua)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand
                    (@"INSERT INTO [DBO].[QUARTO]
                                       ([DESCRICAO_QUARTO]
                                       ,[STATUS_QUAR])
                                 VALUES (@DESCRICAO_QUARTO,@STATUS_QUAR)", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
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

        public DataTable buscarTodosQuartos()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_QUARTO]
                                                          ,[DESCRICAO_QUARTO]
                                                      FROM [DBO].[QUARTO] WHERE STATUS_QUAR='S'", connection))
                {
                    try
                    {
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



        public Quarto buscarQuartoId(int Id)
        {
            Quarto qua = new Quarto();
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_QUARTO]
                                                          ,[DESCRICAO_QUARTO]
                                                      FROM [DBO].[QUARTO]
                                                       WHERE ID_QUARTO = @ID_QUARTO AND STATUS_QUAR = 'S'", connection))
                    {
                        cmd.Parameters.AddWithValue("ID_QUARTO", Id);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            qua.IdQuarto = Convert.ToInt32(registro["ID_QUARTO"]);
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

        public void alterarQuarto(Quarto qua)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [DBO].[QUARTO]
                                                       SET [DESCRICAO_QUARTO] =@DESCRICAO_QUARTO
                                                          WHERE  ID_QUARTO = @ID_QUARTO", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
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

        public void inativarQuarto(int IdQuarto)
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
    }
}


