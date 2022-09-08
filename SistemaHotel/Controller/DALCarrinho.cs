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
    public class DALCarrinho
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        public void inserirCarrinho(Carrinho car)
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

        public DataTable buscarCarrinhoCliente(string codReserva, int TipoProd)
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

        public DataTable buscarCarrinhoQtdeProd(string codReserva, int TipoProd)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT C.ID_PRODUTO 
                                                        ,COUNT(C.[ID_PRODUTO]) AS QTDE
                                                        FROM CARRINHO C,PRODUTO P, CLIENTE CL
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

        public string buscarCarrinhoQtde(string codReserva)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT COUNT(ID_PRODUTO) AS QTDE FROM CARRINHO", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@COD_RESERVA", codReserva);
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

        public Carrinho buscarCarrinhoId(int IdCarrinho)
        {
            Carrinho car = new Carrinho();

            using (SqlConnection connection = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand(@"SELECT C.[ID_CARRINHO]
                                                                ,C.[ID_PRODUTO]
                                                                ,C.[ID_CLIENTE]
                                                                 FROM [DBO].[CARRINHO] C
                                                                 WHERE C.ID_CARRINHO= @ID_CARRINHO", connection))
                {
                    try
                    {


                        cmd.Parameters.AddWithValue("@ID_CARRINHO", IdCarrinho);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            car.IdCarrinho = Convert.ToInt32(registro["ID_CARRINHO"]);
                            car.IdProduto = Convert.ToInt32(registro["ID_PRODUTO"]);
                            car.IdCliente = Convert.ToInt32(registro["ID_CLIENTE"]);
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

            return car;
        }

        public Carrinho buscarProdutoId(int IdProduto)
        {
            Carrinho car = new Carrinho();

            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT C.[ID_CARRINHO]
                                                                ,C.[ID_PRODUTO]
                                                                ,C.[ID_CLIENTE]
                                                                 FROM [DBO].[CARRINHO] C
                                                                 WHERE C.ID_PRODUTO = @ID_PRODUTO", connection))
                {
                    try
                    {

                        cmd.Parameters.AddWithValue("@ID_PRODUTO", IdProduto);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            car.IdCarrinho = Convert.ToInt32(registro["ID_PEDIDO"]);
                            car.IdProduto = Convert.ToInt32(registro["ID_PRODUTO"]);
                            car.IdCliente = Convert.ToInt32(registro["ID_CLIENTE"]);
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
            return car;
        }

        public Carrinho buscarClienteId(int IdCliente)
        {
            Carrinho car = new Carrinho();

            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT C.[ID_CARRINHO]
                                                                ,C.[ID_PRODUTO]
                                                                ,C.[ID_CLIENTE]
                                                                 FROM [DBO].[CARRINHO] C
                                                                 WHERE C.ID_CLIENTE= @ID_CLIENTE", connection))
                {
                    try
                    {

                        cmd.Parameters.AddWithValue("@ID_CLIENTE", IdCliente);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            car.IdCarrinho = Convert.ToInt32(registro["ID_PEDIDO"]);
                            car.IdProduto = Convert.ToInt32(registro["ID_PRODUTO"]);
                            car.IdCliente = Convert.ToInt32(registro["ID_CLIENTE"]);
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
            return car;
        }

        public void excluirCarrinho(int IdCarrinho)
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

        public void excluirCarrinhoCliente(int IdCliente)
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

