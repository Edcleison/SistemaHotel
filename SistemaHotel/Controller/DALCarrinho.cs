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
    public static class DALCarrinho
    {
        static string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        public static void inserirCarrinho(Carrinho car)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[CARRINHO]
                                                       ([ID_PRODUTO]
                                                       ,[ID_CLIENTE])
                                                 VALUES
                                                        (@ID_PRODUTO,@ID_CLIENTE)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID_PRODUTO", car.IdProduto);
                        cmd.Parameters.AddWithValue("ID_CLIENTE", car.IdCliente);
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

        public static DataTable buscarCarrinhoCliente(string codReserva, int TipoProd)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT C.[ID_CARRINHO]
                                                            ,C.[ID_PRODUTO]
                                                            ,C.[ID_CLIENTE]
                                                            ,P.NOME_PROD
                                                            ,P.DESCRICAO_PROD
                                                            ,P.PRECO_UNI
                                                            ,P.FOTO_PROD
                                                            ,CL.COD_RESERVA
                                                            FROM [DBO].[CARRINHO] C
                                                            INNER JOIN PRODUTO P ON(P.ID_PRODUTO = C.ID_PRODUTO)
                                                            INNER JOIN CLIENTE CL ON(CL.ID_CLIENTE = C.ID_CLIENTE) 
                                                            WHERE CL.COD_RESERVA = @COD_RESERVA AND P.ID_TIPO_PROD =@ID_TIPO_PROD", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@COD_RESERVA", codReserva);
                        cmd.Parameters.AddWithValue("@ID_TIPO_PROD", TipoProd);
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
                        connection.Close();
                    }

                }
            }
            return dta;
        }

        public static DataTable buscarCarrinhoQtdeProd(string codReserva, int TipoProd)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT C.ID_PRODUTO 
                                                        ,COUNT(C.[ID_PRODUTO]) AS QTDE
                                                        FROM CARRINHO C
                                                        INNER JOIN PRODUTO P ON P.ID_PRODUTO =C.ID_PRODUTO
                                                        INNER JOIN CLIENTE CL ON CL.ID_CLIENTE = C.ID_CLIENTE
                                                        WHERE CL.COD_RESERVA=@COD_RESERVA AND P.ID_TIPO_PROD = @ID_TIPO_PROD
                                                        GROUP BY C.ID_PRODUTO", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@COD_RESERVA", codReserva);
                        cmd.Parameters.AddWithValue("@ID_TIPO_PROD", TipoProd);
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
                        connection.Close();
                    }
                }
            }
            return dta;
        }

        public static string buscarCarrinhoQtde(string CodReserva)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT COUNT(ID_PRODUTO) AS QTDE FROM CARRINHO car
                                                        INNER JOIN CLIENTE CLI ON (CAR.ID_CLIENTE=CLI.ID_CLIENTE)
                                                        WHERE CLI.COD_RESERVA =@COD_RESERVA", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@COD_RESERVA", CodReserva);
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
                        connection.Close();
                    }
                }
            }
            if (dta.Rows.Count > 0)
            {
                return dta.Rows[0]["QTDE"].ToString();
            }
            else
            {
                return "0";
            }

        }

        public static void excluirCarrinho(int IdCarrinho)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"DELETE [DBO].[CARRINHO] WHERE ID_CARRINHO=@ID_CARRINHO", connection))
                {

                    try
                    {

                        connection.Open();
                        cmd.Parameters.AddWithValue("ID_CARRINHO", IdCarrinho);
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

        public static void excluirCarrinhoCliente(int IdCliente)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"DELETE [DBO].[CARRINHO] WHERE ID_CLIENTE=@ID_CLIENTE", connection))
                {

                    try
                    {

                        connection.Open();
                        cmd.Parameters.AddWithValue("ID_CLIENTE", IdCliente);
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
    }
}

