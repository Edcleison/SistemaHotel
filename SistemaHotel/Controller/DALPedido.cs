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
    public class DALPedido
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";


        public void inserirPedido(Pedido ped)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[PEDIDO]
                                                       ([FK_STATUS_Id_Status]
                                                       ,[FK_TIPO_PEDIDO_Id_Tipo_Ped]                                                      
                                                       ,[FK_CLIENTE_Id_Cliente]
                                                       ,[ITEM_PRODUTO_Descricao_Prod]
                                                       ,[CLIENTE_Quarto]
                                                       ,[ITEM_PEDIDO_Nome_Prod]
                                                       ,[Valor_Total]
                                                       ,[Data_Abertura])
                                                        VALUES
                                                        (@FK_STATUS_Id_Status,@FK_TIPO_PEDIDO_Id_Tipo_Ped,@FK_CLIENTE_Id_Cliente,
                                                        @ITEM_PRODUTO_Descricao_Prod,@CLIENTE_Quarto,@ITEM_PEDIDO_Nome_Prod,@Valor_Total,@Data_Abertura)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("FK_STATUS_Id_Status", ped.Status);
                        cmd.Parameters.AddWithValue("FK_TIPO_PEDIDO_Id_Tipo_Ped", ped.TipoPedido);
                        cmd.Parameters.AddWithValue("FK_CLIENTE_Id_Cliente", ped.IdCliente);
                        cmd.Parameters.AddWithValue("ITEM_PRODUTO_Descricao_Prod", ped.DescricaoProduto);
                        cmd.Parameters.AddWithValue("CLIENTE_Quarto", ped.Quarto);
                        cmd.Parameters.AddWithValue("ITEM_PEDIDO_Nome_Prod", ped.NomeProduto);
                        cmd.Parameters.AddWithValue("Valor_Total", ped.ValorTotal);
                        cmd.Parameters.AddWithValue("Data_Abertura", ped.DataAbertura);
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

        public DataTable buscarTodosPedidos()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Pedido]
                                                          ,[FK_STATUS_Id_Status]
                                                          ,[FK_TIPO_PEDIDO_Id_Tipo_Ped]
                                                          ,[FK_EQUIPE_ATENDIMENTO_Id_Equipe]
                                                          ,[FK_CLIENTE_Id_Cliente]
                                                          ,[ITEM_PRODUTO_Descricao_Prod]
                                                          ,[CLIENTE_Quarto]
                                                          ,[ITEM_PEDIDO_Nome_Prod]
                                                          ,[Valor_Total]
                                                          ,[Data_Abertura]
                                                          ,[Data_Finalizacao]
                                                      FROM [dbo].[PEDIDO]", connection))
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

        public DataTable buscarTodosPedidosTipo(int Tipo)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand($@"SELECT [Id_Pedido]
                                                              ,[FK_STATUS_Id_Status]
                                                              ,[FK_TIPO_PEDIDO_Id_Tipo_Ped]
                                                              ,[FK_EQUIPE_ATENDIMENTO_Id_Equipe]
                                                              ,[FK_CLIENTE_Id_Cliente]
                                                              ,[ITEM_PRODUTO_Descricao_Prod]
                                                              ,[CLIENTE_Quarto]
                                                              ,[ITEM_PEDIDO_Nome_Prod]
                                                              ,[Valor_Total]
                                                              ,[Data_Abertura]
                                                          FROM [dbo].[PEDIDO]
                                                        WHERE FK_TIPO_PEDIDO_Id_Tipo_Ped = {Tipo}", connection))
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

        public DataTable buscarTodosPedidosTipoStatus(int Tipo, int Status)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {

                using (SqlCommand cmd = new SqlCommand($@"SELECT [Id_Pedido]
                                                              ,[FK_STATUS_Id_Status]
                                                              ,[FK_TIPO_PEDIDO_Id_Tipo_Ped]
                                                              ,[FK_EQUIPE_ATENDIMENTO_Id_Equipe]
                                                              ,[FK_CLIENTE_Id_Cliente]
                                                              ,[ITEM_PRODUTO_Descricao_Prod]
                                                              ,[CLIENTE_Quarto]
                                                              ,[ITEM_PEDIDO_Nome_Prod]
                                                              ,[Valor_Total]
                                                              ,[Data_Abertura]
                                                          FROM [dbo].[PEDIDO]
                                                        WHERE FK_TIPO_PEDIDO_Id_Tipo_Ped = {Tipo} and FK_STATUS_Id_Status= {Status} ", connection))
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

        public Pedido buscarPedidoId(int IdPedido)
        {
            Pedido ped = new Pedido();

            using (SqlConnection connection = new SqlConnection(cnn))
            {


                using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Pedido]
                                                              ,[FK_STATUS_Id_Status]
                                                              ,[FK_TIPO_PEDIDO_Id_Tipo_Ped]
                                                              ,[FK_EQUIPE_ATENDIMENTO_Id_Equipe]
                                                              ,[FK_CLIENTE_Id_Cliente]
                                                              ,[ITEM_PRODUTO_Descricao_Prod]
                                                              ,[CLIENTE_Quarto]
                                                              ,[ITEM_PEDIDO_Nome_Prod]
                                                              ,[Valor_Total]
                                                              ,[Data_Abertura]
                                                              ,[Data_Finalizacao]
                                                          FROM [dbo].[PEDIDO] WHERE Id_Pedido = @Id_Pedido", connection))
                {
                    try
                    {

                        cmd.Parameters.AddWithValue("@Id_Pedido", IdPedido);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            ped.IdPedido = Convert.ToInt32(registro["Id_Pedido"]);
                            ped.TipoPedido = Convert.ToInt32(registro["FK_TIPO_PRODUTO_Id_Tipo_Prod"]);
                            ped.IdEquipe = Convert.ToInt32(registro["FK_EQUIPE_ATENDIMENTO_Id_Equipe"]);
                            ped.IdCliente = Convert.ToInt32(registro["FK_CLIENTE_Id_Cliente"]);
                            ped.DescricaoProduto = Convert.ToString(registro["ITEM_PRODUTO_Descricao_Prod"]);
                            ped.Quarto = Convert.ToString(registro["CLIENTE_Quarto"]);
                            ped.NomeProduto = Convert.ToString(registro["ITEM_PEDIDO_Nome_Prod"]);
                            ped.ValorTotal = Convert.ToDecimal(registro["Valor_Total"]);
                            ped.DataAbertura = Convert.ToDateTime(registro["Data_Ped"]);
                            ped.DataFinalizacao = Convert.ToDateTime(registro["Data_Ped"]);


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

        public void alterarStatusAtendimentoPedido(Pedido ped)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[PEDIDO]
                                                       SET [FK_STATUS_Id_Status] = @FK_STATUS_Id_Status
                                                          ,[FK_EQUIPE_ATENDIMENTO_Id_Equipe] = @FK_EQUIPE_ATENDIMENTO_Id_Equipe                                                         
                                                          ,[Data_Finalizacao] = @Data_Finalizacao
                                                     WHERE Id_Pedido = @Id_Pedido", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("FK_STATUS_Id_Status", ped.Status);
                        cmd.Parameters.AddWithValue("FK_EQUIPE_ATENDIMENTO_Id_Equipe", ped.IdEquipe);
                        cmd.Parameters.AddWithValue("ITEM_PRODUTO_Descricao_Prod", ped.DataFinalizacao);
                        cmd.Parameters.AddWithValue("Data_Finalizacao", ped.DataFinalizacao);
                        cmd.Parameters.AddWithValue("ID_Pedido", ped.IdPedido);
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

