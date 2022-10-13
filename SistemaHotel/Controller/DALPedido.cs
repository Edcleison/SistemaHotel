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
    public static class DALPedido
    {
        static string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        public static void inserirPedido(Pedido ped)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[PEDIDO]
                                                       ([ID_STATUS_PED]
                                                       ,[ID_CLIENTE]
                                                       ,[ID_ADM]
                                                       ,[ID_FUNCIONARIO]
                                                       ,[VALOR_TOTAL]
                                                       ,[DATA_ABERTURA])
                                                        VALUES
                                                        (@ID_STATUS,@ID_CLIENTE,NULLIF(@ID_ADM,''),NULLIF(@ID_FUNCIONARIO,''),@VALOR_TOTAL,@DATA_ABERTURA)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID_STATUS", ped.IdStatus);
                        cmd.Parameters.AddWithValue("ID_CLIENTE", ped.IdCliente);
                        cmd.Parameters.AddWithValue("ID_ADM", ped.IdAdm);
                        cmd.Parameters.AddWithValue("ID_FUNCIONARIO", ped.IdFuncionario);
                        cmd.Parameters.AddWithValue("VALOR_TOTAL", ped.ValorTotal);
                        cmd.Parameters.AddWithValue("DATA_ABERTURA", ped.DataAbertura);
                        cmd.ExecuteNonQuery();
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
        }

        public static string buscarValorTotalCliente(int IdCliente)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand($@"SELECT SUM(VALOR_TOTAL) AS VALOR_TOTAL FROM PEDIDO
                                                            WHERE ID_STATUS_PED = 2 AND ID_CLIENTE =@ID_CLIENTE", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@ID_CLIENTE", IdCliente);
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
                if (dta.Rows.Count > 0)
                {
                    return dta.Rows[0]["VALOR_TOTAL"].ToString();
                }

            }
            return "";
        }

        public static DataTable buscarTodosPedidosTipoStatus(string IdStatus, string IdTipoProd)
        {
            string parTipoStatus = "";
            if (IdTipoProd != "" && IdStatus != "")
            {
                parTipoStatus = "WHERE P.ID_STATUS_PED = @ID_STATUS_PED AND PR.ID_TIPO_PROD =@ID_TIPO_PROD";
            }
            else if (IdStatus != "" && IdTipoProd == "")
            {
                parTipoStatus = "WHERE P.ID_STATUS_PED = @ID_STATUS_PED";
            }
            else if (IdStatus == "" && IdTipoProd != "")
            {
                parTipoStatus = "WHERE PR.ID_TIPO_PROD =@ID_TIPO_PROD";
            }

            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand($@"SELECT P.ID_PEDIDO,P.DATA_ABERTURA,Q.NUMERO_QUARTO,Q.DESCRICAO_QUARTO,C.NOME_CLIENTE,C.SOBRENOME_CLIENTE,PR.NOME_PROD,
                                                            PR.DESCRICAO_PROD,IP.QUANTIDADE,S.DESCRICAO_STATUS_PED,P.DATA_FINALIZACAO,
                                                            P.ID_ADM,U.NOME AS NOME_ADM,U.SOBRENOME AS SOBRENOME_ADM,PA.DESCRICAO_PERFIL AS PERFIL_ADM,
                                                            P.ID_FUNCIONARIO,USU.NOME AS NOME_FUNC,USU.SOBRENOME AS SOBRENOME_FUNC,PF.DESCRICAO_PERFIL AS PERFIL_FUNC
                                                            FROM PEDIDO P 
                                                            INNER JOIN CLIENTE C ON (C.ID_CLIENTE = P. ID_CLIENTE)
                                                            INNER JOIN ITEM_PEDIDO IP ON (IP.ID_PEDIDO = P.ID_PEDIDO)
                                                            INNER JOIN PRODUTO PR ON (PR.ID_PRODUTO = IP.ID_PRODUTO)
                                                            INNER JOIN QUARTO Q ON (Q.ID_QUARTO = C.ID_QUARTO)INNER JOIN STATUS_PEDIDO S ON (S.ID_STATUS_PED = P.ID_STATUS_PED)
                                                            INNER JOIN TIPO_PRODUTO TP ON (TP.ID_TIPO_PROD = PR.ID_TIPO_PROD)LEFT JOIN FUNCIONARIO FU ON (FU.ID_FUNCIONARIO = P.ID_FUNCIONARIO)
                                                            LEFT JOIN ADMINISTRACAO A ON (A.ID_ADM = P.ID_ADM)
                                                            LEFT JOIN USUARIO USU ON (USU.ID_USUARIO = FU.ID_USUARIO)
                                                            LEFT JOIN USUARIO U ON (U.ID_USUARIO = A.ID_USUARIO)
                                                            LEFT JOIN PERFIL_USUARIO PUF ON (PUF.ID_USUARIO = USU.ID_USUARIO)
                                                            LEFT JOIN PERFIL_USUARIO PUA ON (PUA.ID_USUARIO = U.ID_USUARIO)
                                                            LEFT JOIN PERFIL PF ON (PF.ID_PERFIL = PUF.ID_PERFIL)
                                                            LEFT JOIN PERFIL PA ON (PA.ID_PERFIL = PUA.ID_PERFIL)
                                                            {parTipoStatus}", connection))
                {
                    try
                    {
                        if (IdTipoProd != "" && IdStatus != "")
                        {
                            cmd.Parameters.AddWithValue("@ID_STATUS_PED", IdStatus);
                            cmd.Parameters.AddWithValue("@ID_TIPO_PROD", IdTipoProd);
                        }
                        else if (IdStatus != "" && IdTipoProd == "")
                        {
                            cmd.Parameters.AddWithValue("@ID_STATUS_PED", IdStatus);
                        }
                        else if (IdStatus == "" && IdTipoProd != "")
                        {
                            cmd.Parameters.AddWithValue("@ID_TIPO_PROD", IdTipoProd);
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

        public static DataTable buscarTodosPedidosCliente(string IdCliente, string IdStatus, string IdTipoProd)
        {
            string parTipoStatus = "";
            if (IdTipoProd != "" && IdStatus != "")
            {
                parTipoStatus = "AND P.ID_STATUS_PED = @ID_STATUS_PED AND PR.ID_TIPO_PROD =@ID_TIPO_PROD";
            }
            else if (IdStatus != "" && IdTipoProd == "")
            {
                parTipoStatus = "AND P.ID_STATUS_PED = @ID_STATUS_PED";
            }
            else if (IdStatus == "" && IdTipoProd != "")
            {
                parTipoStatus = "AND PR.ID_TIPO_PROD =@ID_TIPO_PROD";
            }

            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand($@"SELECT P.ID_PEDIDO,P.DATA_ABERTURA,Q.NUMERO_QUARTO,Q.DESCRICAO_QUARTO,C.NOME_CLIENTE,C.SOBRENOME_CLIENTE,PR.NOME_PROD,
                                                            PR.DESCRICAO_PROD,pr.PRECO_UNI ,IP.QUANTIDADE,S.DESCRICAO_STATUS_PED,P.DATA_FINALIZACAO,TP.ID_TIPO_PROD
                                                            FROM PEDIDO P 
                                                            INNER JOIN CLIENTE C ON (C.ID_CLIENTE = P. ID_CLIENTE)
                                                            INNER JOIN ITEM_PEDIDO IP ON (IP.ID_PEDIDO = P.ID_PEDIDO)
                                                            INNER JOIN PRODUTO PR ON (PR.ID_PRODUTO = IP.ID_PRODUTO)
                                                            INNER JOIN QUARTO Q ON (Q.ID_QUARTO = C.ID_QUARTO)
                                                            INNER JOIN STATUS_PEDIDO S ON (S.ID_STATUS_PED = P.ID_STATUS_PED)
                                                            INNER JOIN TIPO_PRODUTO TP ON (TP.ID_TIPO_PROD = PR.ID_TIPO_PROD)
                                                            WHERE P.ID_CLIENTE =@ID_CLIENTE
                                                            {parTipoStatus}", connection))
                {

                    try
                    {
                        cmd.Parameters.AddWithValue("@ID_CLIENTE", IdCliente);
                        if (IdTipoProd != "" && IdStatus != "")
                        {
                            cmd.Parameters.AddWithValue("@ID_STATUS_PED", IdStatus);
                            cmd.Parameters.AddWithValue("@ID_TIPO_PROD", IdTipoProd);
                        }
                        else if (IdStatus != "" && IdTipoProd == "")
                        {
                            cmd.Parameters.AddWithValue("@ID_STATUS_PED", IdStatus);
                        }
                        else if (IdStatus == "" && IdTipoProd != "")
                        {
                            cmd.Parameters.AddWithValue("@ID_TIPO_PROD", IdTipoProd);
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

        public static Pedido buscarPedidoId(int IdPedido)
        {
            Pedido ped = new Pedido();

            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_PEDIDO]
                                                                ,[ID_STATUS_PED]
                                                                ,[ID_CLIENTE]
                                                                ,[VALOR_TOTAL]
                                                                ,[DATA_ABERTURA]
                                                          FROM [dbo].[PEDIDO] WHERE ID_PEDIDO = @ID_PEDIDO", connection))
                {
                    try
                    {

                        cmd.Parameters.AddWithValue("@Id_Pedido", IdPedido);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            ped.IdPedido = Convert.ToInt32(registro["ID_PEDIDO"]);
                            ped.IdStatus = Convert.ToInt32(registro["ID_STATUS_PED"]);
                            ped.IdCliente = Convert.ToInt32(registro["ID_CLIENTE"]);
                            ped.ValorTotal = Convert.ToDecimal(registro["VALOR_TOTAL"]);
                            ped.DataAbertura = Convert.ToDateTime(registro["DATA_ABERTURA"]);

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

            }
            return ped;
        }

        public static Pedido buscarPedidoIdClienteData(int IdCliente, DateTime DataAbertura)
        {
            Pedido ped = new Pedido();

            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_PEDIDO]
                                                                ,[ID_STATUS_PED]
                                                                ,[ID_CLIENTE]                                                                
                                                                ,[VALOR_TOTAL]
                                                                ,[DATA_ABERTURA]                                                          
                                                          FROM [dbo].[PEDIDO] WHERE ID_CLIENTE = @ID_CLIENTE and DATA_ABERTURA = @DATA_ABERTURA", connection))
                {
                    try
                    {

                        cmd.Parameters.AddWithValue("@ID_CLIENTE", IdCliente);
                        cmd.Parameters.AddWithValue("@DATA_ABERTURA", DataAbertura);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            ped.IdPedido = Convert.ToInt32(registro["ID_PEDIDO"]);
                            ped.IdStatus = Convert.ToInt32(registro["ID_STATUS_PED"]);
                            ped.IdCliente = Convert.ToInt32(registro["ID_CLIENTE"]);
                            ped.ValorTotal = Convert.ToDecimal(registro["VALOR_TOTAL"]);
                            ped.DataAbertura = Convert.ToDateTime(registro["DATA_ABERTURA"]);
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

            }
            return ped;
        }

        public static void alterarStatusAtendimentoAdm(Pedido ped)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [DBO].[PEDIDO]
                                                       SET [ID_STATUS_PED] = @ID_STATUS_PED
                                                          ,[ID_ADM] = @ID_ADM                                                       
                                                          ,[DATA_FINALIZACAO] = @DATA_FINALIZACAO
                                                     WHERE ID_PEDIDO = @ID_PEDIDO", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID_STATUS_PED", ped.IdStatus);
                        cmd.Parameters.AddWithValue("ID_ADM", ped.IdAdm);
                        cmd.Parameters.AddWithValue("DATA_FINALIZACAO", ped.DataFinalizacao);
                        cmd.Parameters.AddWithValue("ID_PEDIDO", ped.IdPedido);
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

        public static void alterarStatusAtendimentoFuncionario(Pedido ped)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [DBO].[PEDIDO]
                                                       SET [ID_STATUS_PED] = @ID_STATUS_PED
                                                          ,[ID_FUNCIONARIO] = @ID_FUNCIONARIO                                                        
                                                          ,[DATA_FINALIZACAO] = @DATA_FINALIZACAO
                                                     WHERE ID_PEDIDO = @ID_PEDIDO", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID_STATUS_PED", ped.IdStatus);
                        cmd.Parameters.AddWithValue("ID_FUNCIONARIO", ped.IdFuncionario);
                        cmd.Parameters.AddWithValue("DATA_FINALIZACAO", ped.DataFinalizacao);
                        cmd.Parameters.AddWithValue("ID_PEDIDO", ped.IdPedido);
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

