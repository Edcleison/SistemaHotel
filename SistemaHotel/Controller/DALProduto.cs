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

        #region DALProduto_OLD
        ////Creat
        //public void inserirProduto(Produto prod)
        //{
        //    using (SqlConnection connection = new SqlConnection(cnn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[PRODUTO]
        //                                                       ([NOME]
        //                                                       ,[DESCRICAO]
        //                                                       ,[PRECO]
        //                                                       ,[FOTO]
        //                                                       ,[TIPO])
        //                                                 VALUES(@NOME,@DESCRICAO,@PRECO,@FOTO,@TIPO)", connection))
        //        {

        //            try
        //            {
        //                cmd.Connection.Open();                       
        //                cmd.Parameters.AddWithValue("NOME", prod.Nome);
        //                cmd.Parameters.AddWithValue("DESCRICAO", prod.Descricao);
        //                cmd.Parameters.AddWithValue("PRECO", prod.Preco);
        //                cmd.Parameters.AddWithValue("FOTO", prod.Foto);
        //                cmd.Parameters.AddWithValue("TIPO", prod.Tipo);
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

        ////Read
        //public DataTable buscarTodosProdutos()
        //{
        //    DataTable dta = new DataTable();
        //    SqlDataAdapter adp;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(cnn))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
        //                                                  ,[NOME]
        //                                                  ,[DESCRICAO]
        //                                                  ,[PRECO]
        //                                                  ,[FOTO]
        //                                                  ,[TIPO]
        //                                              FROM [dbo].[PRODUTO]", connection))
        //            {
        //                cmd.Connection.Open();
        //                cmd.ExecuteNonQuery();
        //                adp = new SqlDataAdapter(cmd);
        //                adp.Fill(dta);
        //                cmd.Connection.Close();

        //            }
        //        }
        //    }
        //    catch (Exception erro)
        //    {
        //        throw new Exception(erro.Message);
        //    }
        //    return dta;
        //}

        //public DataTable buscarTodosProdutosTipo(int Tipo)
        //{
        //    DataTable dta = new DataTable();
        //    SqlDataAdapter adp;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(cnn))
        //        {
        //            using (SqlCommand cmd = new SqlCommand($@"SELECT [ID]
        //                                                  ,[NOME]
        //                                                  ,[DESCRICAO]
        //                                                  ,[PRECO]
        //                                                  ,[FOTO]
        //                                                  ,[TIPO]
        //                                              FROM [dbo].[PRODUTO] WHERE TIPO = {Tipo}", connection))
        //            {
        //                cmd.Connection.Open();
        //                cmd.ExecuteNonQuery();
        //                adp = new SqlDataAdapter(cmd);
        //                adp.Fill(dta);
        //                cmd.Connection.Close();

        //            }
        //        }
        //    }
        //    catch (Exception erro)
        //    {
        //        throw new Exception(erro.Message);
        //    }
        //    return dta;
        //}

        //public Produto buscarProdutoId(int Id)
        //{
        //    Produto prod = new Produto();
        //    try
        //    {

        //        using (SqlConnection connection = new SqlConnection(cnn))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
        //                                                          ,[NOME]
        //                                                          ,[DESCRICAO]
        //                                                          ,[PRECO]
        //                                                          ,[FOTO]
        //                                                          ,[TIPO]
        //                                                      FROM [dbo].[PRODUTO] WHERE ID = @ID", connection))
        //            {

        //                cmd.Parameters.AddWithValue("@ID", Id);
        //                cmd.Connection.Open();
        //                SqlDataReader registro = cmd.ExecuteReader();
        //                if (registro.HasRows)
        //                {
        //                    registro.Read();
        //                    prod.Id = Convert.ToInt32(registro["ID"]);
        //                    prod.Nome = Convert.ToString(registro["NOME"]);
        //                    prod.Descricao = Convert.ToString(registro["DESCRICAO"]);
        //                    prod.Preco = decimal.Parse(registro["PRECO"].ToString());                           
        //                    prod.Foto = Convert.ToString(registro["FOTO"]);                           
        //                    prod.Tipo = Convert.ToInt32(registro["TIPO"]);                           

        //                }
        //            }
        //        }
        //    }
        //    catch (Exception erro)
        //    {
        //        throw new Exception(erro.Message);
        //    }

        //    return prod;
        //}

        ////Update
        //public void alterarProduto(Produto prod)
        //{
        //    using (SqlConnection connection = new SqlConnection(cnn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[PRODUTO]
        //                                               SET [NOME] = @NOME>
        //                                                  ,[DESCRICAO] = @DESCRICAO>
        //                                                  ,[PRECO] = @PRECO
        //                                                  ,[FOTO] = @FOTO
        //                                                  ,[TIPO] = @TIPO
        //                                                  WHERE  ID = @ID", connection))
        //        {
        //            try
        //            {
        //                cmd.Connection.Open();                       
        //                cmd.Parameters.AddWithValue("NOME", prod.Nome);
        //                cmd.Parameters.AddWithValue("DESCRICAO", prod.Descricao);
        //                cmd.Parameters.AddWithValue("PRECO", prod.Preco);
        //                cmd.Parameters.AddWithValue("FOTO", prod.Foto);
        //                cmd.Parameters.AddWithValue("TIPO", prod.Tipo);
        //                cmd.Parameters.AddWithValue("ID", prod.Id);
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
        ////delete
        //public void excluirProduto(int IdProduto)
        //{

        //    using (SqlConnection connection = new SqlConnection(cnn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[PRODUTO] WHERE ID = @ID", connection))
        //        {

        //            try
        //            {
        //                connection.Open();
        //                cmd.Parameters.AddWithValue("ID", IdProduto);
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

        public void inserirProduto(Produto prod)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[PRODUTO]
                                                       ([FK_TIPO_PRODUTO_Id_Tipo_Prod]
                                                       ,[Preco_Uni]
                                                       ,[Descricao_Prod]
                                                       ,[Nome_Prod]
                                                       ,[Foto_Prod])
                                                 VALUES
                                            (@FK_TIPO_PRODUTO_Id_Tipo_Prod,@Preco_Uni,@Descricao_Prod,@Nome_Prod,@Foto_Prod)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("FK_TIPO_PRODUTO_Id_Tipo_Prod", prod.TipoProduto);
                        cmd.Parameters.AddWithValue("Preco_Uni", prod.PrecoUnitario);
                        cmd.Parameters.AddWithValue("Descricao_Prod", prod.DescricaoProduto);
                        cmd.Parameters.AddWithValue("Nome_Prod", prod.NomeProduto);
                        cmd.Parameters.AddWithValue("Foto_Prod", prod.FotoProduto);
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


                using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Produto]
                                                          ,[FK_TIPO_PRODUTO_Id_Tipo_Prod]
                                                          ,[Preco_Uni]
                                                          ,[Descricao_Prod]
                                                          ,[Nome_Prod]
                                                          ,[Foto_Prod]
                                                      FROM [dbo].[PRODUTO]", connection))
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

        public DataTable buscarTodosProdutosTipo(int Tipo)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand($@"SELECT [Id_Produto]
                                                            ,[FK_TIPO_PRODUTO_Id_Tipo_Prod]
                                                            ,[Preco_Uni]
                                                            ,[Descricao_Prod]
                                                            ,[Nome_Prod]
                                                            ,[Foto_Prod]
                                                        FROM [dbo].[PRODUTO]
                                                        WHERE FK_TIPO_PRODUTO_Id_Tipo_Prod = {Tipo}", connection))
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

        public Produto buscarProdutoId(int IdProduto)
        {
            Produto prod = new Produto();

            using (SqlConnection connection = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Produto]
                                                            ,[FK_TIPO_PRODUTO_Id_Tipo_Prod]
                                                            ,[Preco_Uni]
                                                            ,[Descricao_Prod]
                                                            ,[Nome_Prod]
                                                            ,[Foto_Prod]
                                                        FROM [dbo].[PRODUTO] WHERE Id_Produto = @Id_Produto", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@Id_Produto", IdProduto);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            prod.IdProduto = Convert.ToInt32(registro["Id_Produto"]);
                            prod.TipoProduto = Convert.ToInt32(registro["FK_TIPO_PRODUTO_Id_Tipo_Prod"]);
                            prod.PrecoUnitario = Convert.ToDecimal(registro["Preco_Uni"]);
                            prod.DescricaoProduto = Convert.ToString(registro["Descricao_Prod"]);
                            prod.NomeProduto = Convert.ToString(registro["Nome_Prod"]);
                            prod.FotoProduto = Convert.ToString(registro["Foto_Prod"]);
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
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[PRODUTO]
                                                       SET [Preco_Uni] =@Preco_Uni
                                                          ,[Descricao_Prod] = @[Descricao_Prod]
                                                          ,[Nome_Prod] = @Nome_Prod
                                                          ,[Foto_Prod] = @Foto_Prod                                                         
                                                          WHERE  ID_Produto = @ID_Produto", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("Preco_Uni", prod.PrecoUnitario);
                        cmd.Parameters.AddWithValue("Descricao_Prod", prod.DescricaoProduto);
                        cmd.Parameters.AddWithValue("Nome_Prod", prod.NomeProduto);
                        cmd.Parameters.AddWithValue("Foto_Prod", prod.FotoProduto);
                        cmd.Parameters.AddWithValue("ID_Produto", prod.IdProduto);
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

        public void excluirProduto(int IdProduto)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[PRODUTO] WHERE ID_Produto = @ID_Produto", connection))
                {

                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("ID_Produto", IdProduto);
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

