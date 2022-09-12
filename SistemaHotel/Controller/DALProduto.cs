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
    public class DALProduto
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";

        public void inserirProduto(Produto prod)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[PRODUTO]
                                                       ([ID_TIPO_PROD]
                                                       ,[PRECO_UNI]
                                                       ,[DESCRICAO_PROD]
                                                       ,[NOME_PROD]
                                                       ,[FOTO_PROD]
                                                       ,[STATUS_PROD])
                                                 VALUES
                                            (@ID_TIPO_PROD,@PRECO_UNI,@DESCRICAO_PROD,@NOME_PROD,@FOTO_PROD,@STATUS_PROD)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID_TIPO_PROD", prod.TipoProduto);
                        cmd.Parameters.AddWithValue("PRECO_UNI", prod.PrecoUnitario);
                        cmd.Parameters.AddWithValue("DESCRICAO_PROD", prod.DescricaoProduto);
                        cmd.Parameters.AddWithValue("NOME_PROD", prod.NomeProduto);
                        cmd.Parameters.AddWithValue("FOTO_PROD", prod.FotoProduto);
                        cmd.Parameters.AddWithValue("STATUS_PROD", prod.StatusProd);
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

        public DataTable buscarTodosProdutos()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_PRODUTO]
                                                          ,[ID_TIPO_PROD]
                                                          ,[PRECO_UNI]
                                                          ,[DESCRICAO_PROD]
                                                          ,[NOME_PROD]
                                                          ,[FOTO_PROD]
                                                      FROM [DBO].[PRODUTO]", connection))
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

        public DataTable buscarTodosProdutosTipo(string Tipo, string Status)
        {

            string parTipoStatus = "";
            if (Tipo != "" && Status != "")
            {
                parTipoStatus = "WHERE PR.ID_TIPO_PROD =@ID_TIPO_PROD AND P.ID_STATUS_PED = @ID_STATUS_PED";
            }
            else if (Tipo != "" && Status == "")
            {
                parTipoStatus = "WHERE PR.ID_TIPO_PROD =@ID_TIPO_PROD";
            }
            else if (Tipo == "" && Status != "")
            { 
                parTipoStatus = "WHERE P.ID_STATUS_PROD = @ID_STATUS_PROD";
            }

            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand($@"SELECT [ID_PRODUTO]
                                                            ,[ID_TIPO_PROD]
                                                            ,[PRECO_UNI]
                                                            ,[DESCRICAO_PROD]
                                                            ,[NOME_PROD]
                                                            ,[FOTO_PROD]
                                                            ,STATUS_PROD
                                                        FROM [DBO].[PRODUTO]
                                                        {parTipoStatus}", connection))
                {
                    try
                    {
                        if (Tipo != "" && Status != "")
                        {
                            cmd.Parameters.AddWithValue("@ID_TIPO_PROD", Tipo);
                            cmd.Parameters.AddWithValue("@STATUS_PROD", Status);
                        }
                        else if (Tipo != "" && Status == "")
                        {
                            cmd.Parameters.AddWithValue("@ID_TIPO_PROD", Tipo);
                        }
                        else if (Tipo == "" && Status != "")
                        {
                            cmd.Parameters.AddWithValue("@STATUS_PROD", Status);
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

        public Produto buscarProdutoId(int IdProduto)
        {
            Produto prod = new Produto();

            using (SqlConnection connection = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_PRODUTO]
                                                            ,[ID_TIPO_PROD]
                                                            ,[PRECO_UNI]
                                                            ,[DESCRICAO_PROD]
                                                            ,[NOME_PROD]
                                                            ,[FOTO_PROD]
                                                        FROM [DBO].[PRODUTO] WHERE ID_PRODUTO = @ID_PRODUTO", connection))
                {
                    try
                    {

                        cmd.Parameters.AddWithValue("@ID_PRODUTO", IdProduto);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            prod.IdProduto = Convert.ToInt32(registro["ID_PRODUTO"]);
                            prod.TipoProduto = Convert.ToInt32(registro["ID_TIPO_PROD"]);
                            prod.PrecoUnitario = Convert.ToDecimal(registro["PRECO_UNI"]);
                            prod.DescricaoProduto = Convert.ToString(registro["DESCRICAO_PROD"]);
                            prod.NomeProduto = Convert.ToString(registro["NOME_PROD"]);
                            prod.FotoProduto = Convert.ToString(registro["FOTO_PROD"]);
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
            return prod;
        }

        public void alterarProduto(Produto prod)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [DBO].[PRODUTO]
                                                       SET [PRECO_UNI] =@PRECO_UNI
                                                          ,[DESCRICAO_PROD] = @DESCRICAO_PROD
                                                          ,[NOME_PROD] = @NOME_PROD
                                                          ,[FOTO_PROD] = @FOTO_PROD                                                         
                                                          WHERE  ID_PRODUTO = @ID_PRODUTO", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("PRECO_UNI", prod.PrecoUnitario);
                        cmd.Parameters.AddWithValue("DESCRICAO_PROD", prod.DescricaoProduto);
                        cmd.Parameters.AddWithValue("NOME_PROD", prod.NomeProduto);
                        cmd.Parameters.AddWithValue("FOTO_PROD", prod.FotoProduto);
                        cmd.Parameters.AddWithValue("ID_PRODUTO", prod.IdProduto);
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

        public void inativarProduto(int IdProduto)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [DBO].[PRODUTO] SET STATUS_PROD ='N' WHERE ID_PRODUTO = @ID_PRODUTO", connection))
                {

                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("ID_PRODUTO", IdProduto);
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

        public void ativarProduto(int IdProduto)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [DBO].[PRODUTO] SET STATUS_PROD ='S' WHERE ID_PRODUTO = @ID_PRODUTO", connection))
                {

                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("ID_PRODUTO", IdProduto);
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

