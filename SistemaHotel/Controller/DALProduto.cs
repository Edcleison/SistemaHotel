using SistemaHotel.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;


namespace SistemaHotel.Controller
{
    public static class DALProduto
    {
         
        static string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";

        public static void inserirProduto(Produto prod)
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
                        cmd.Parameters.AddWithValue("PRECO_UNI", Convert.ToDecimal(prod.PrecoUnitario,new CultureInfo("en-US")));
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


        public static DataTable buscarTodosProdutosTipo(string Tipo, string Status)
        {

            string parTipoStatus = "";
            if (Tipo != "" && Status != "")
            {
                parTipoStatus = "WHERE ID_TIPO_PROD =@ID_TIPO_PROD AND STATUS_PROD = @STATUS_PROD";
            }
            else if (Tipo != "" && Status == "")
            {
                parTipoStatus = "WHERE ID_TIPO_PROD =@ID_TIPO_PROD";
            }
            else if (Tipo == "" && Status != "")
            {
                parTipoStatus = "WHERE STATUS_PROD = @STATUS_PROD";
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

        public static Produto buscarProdutoId(int IdProduto)
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

        public static Produto buscarProdutoNome(string NomeProduto)
        {
            Produto prod = new Produto();

            using (SqlConnection connection = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand(@"SELECT TOP 1 [ID_PRODUTO]
                                                            ,[ID_TIPO_PROD]
                                                            ,[PRECO_UNI]
                                                            ,[DESCRICAO_PROD]
                                                            ,[NOME_PROD]
                                                            ,[FOTO_PROD]
                                                        FROM [DBO].[PRODUTO] WHERE NOME_PROD = @NOME_PROD", connection))
                {
                    try
                    {

                        cmd.Parameters.AddWithValue("@NOME_PROD", NomeProduto);
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

        public static void alterarProduto(Produto prod)
        {
            string sFoto = "";
            if (prod.FotoProduto !="")
            {
                sFoto = ",[FOTO_PROD] = @FOTO_PROD";
            }
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand($@"UPDATE [DBO].[PRODUTO]
                                                       SET [PRECO_UNI] =@PRECO_UNI
                                                          ,[DESCRICAO_PROD] = @DESCRICAO_PROD
                                                          ,[NOME_PROD] = @NOME_PROD
                                                          {sFoto}                                                        
                                                          ,[ID_TIPO_PROD] = @ID_TIPO_PROD                                                         
                                                          WHERE  ID_PRODUTO = @ID_PRODUTO", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("PRECO_UNI", Convert.ToDecimal(prod.PrecoUnitario, new CultureInfo("en-US")));
                        cmd.Parameters.AddWithValue("DESCRICAO_PROD", prod.DescricaoProduto);
                        cmd.Parameters.AddWithValue("NOME_PROD", prod.NomeProduto);
                        cmd.Parameters.AddWithValue("ID_TIPO_PROD", prod.TipoProduto);
                        if (prod.FotoProduto !="")
                        {
                            cmd.Parameters.AddWithValue("FOTO_PROD", prod.FotoProduto);
                        }
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

        public static void inativarProduto(int IdProduto)
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

        public static void ativarProduto(int IdProduto)
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

