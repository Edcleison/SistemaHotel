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
    public class DALUsuario
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=servicohotelaria;Persist Security Info=True;User ID=servicohotelaria;Password=Kd5rn9__2ARu";

        #region DALUsuario_OLD
        ////Creat
        //public void inserirUsuario(Usuario usu)
        //{
        //    using (SqlConnection connection = new SqlConnection(cnn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[USUARIO]
        //                                                   ([NOME_USUARIO]
        //                                                   ,[CODIGO_RESERVA_CLIENTE]
        //                                                   ,[LOGIN]
        //                                                   ,[SENHA])
        //                                             VALUES(@NOME_USUARIO,NULLIF(@CODIGO_RESERVA_CLIENTE,''),@LOGIN,@SENHA)", connection))
        //        {

        //            try
        //            {
        //                cmd.Connection.Open();
        //                cmd.Parameters.AddWithValue("NOME_USUARIO", usu.NomeUsuario);
        //                cmd.Parameters.AddWithValue("CODIGO_RESERVA_CLIENTE", usu.CogidoReserva);
        //                cmd.Parameters.AddWithValue("LOGIN", usu.Login);
        //                cmd.Parameters.AddWithValue("SENHA", usu.Senha);
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
        //public void inserirUsuarioCliente(Usuario usu)
        //{
        //    using (SqlConnection connection = new SqlConnection(cnn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[USUARIO]
        //                                                   ([NOME_USUARIO]
        //                                                   ,[CODIGO_RESERVA_CLIENTE]
        //                                                   ,[LOGIN]
        //                                                   ,[SENHA])
        //                                             VALUES(NULLIF(@NOME_USUARIO,''),@CODIGO_RESERVA_CLIENTE,@LOGIN,@SENHA)", connection))
        //        {

        //            try
        //            {
        //                cmd.Connection.Open();
        //                cmd.Parameters.AddWithValue("NOME_USUARIO", usu.NomeUsuario);
        //                cmd.Parameters.AddWithValue("CODIGO_RESERVA_CLIENTE", usu.CogidoReserva);
        //                cmd.Parameters.AddWithValue("LOGIN", usu.Login);
        //                cmd.Parameters.AddWithValue("SENHA", usu.Senha);
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
        //public DataTable buscarTodosUsuarios()
        //{
        //    DataTable dta = new DataTable();
        //    SqlDataAdapter adp;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(cnn))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
        //                                                  ,[NOME_USUARIO]
        //                                                  ,[CODIGO_RESERVA_CLIENTE]
        //                                                  ,[LOGIN]
        //                                                  ,[SENHA]
        //                                              FROM [dbo].[USUARIO]", connection))
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

        //public DataTable buscarUsuariosAtivos()
        //{
        //    DataTable dta = new DataTable();
        //    SqlDataAdapter adp;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(cnn))
        //        {
        //            using (SqlCommand cmd = new SqlCommand($@"SELECT U.[ID]
        //                                                    ,U.NOME_USUARIO
        //                                                    ,U.CODIGO_RESERVA_CLIENTE
        //                                                    ,U.[LOGIN]
        //                                                    ,U.[SENHA]
        //                                                    ,P.Ativo
        //                                                    ,P.ID_PERFIL
        //                                                    FROM [DBO].[USUARIO] U
        //                                                    INNER JOIN PERFIL_USUARIO P
        //                                                    ON (P.ID_USUARIO = U.ID) WHERE P.ATIVO ='S'", connection))
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

        //public DataTable buscarUsuariosPerfilAtivos(string perfil)
        //{
        //    DataTable dta = new DataTable();
        //    SqlDataAdapter adp;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(cnn))
        //        {
        //            using (SqlCommand cmd = new SqlCommand($@"SELECT U.[ID]
        //                                                    ,U.NOME_USUARIO
        //                                                    ,U.CODIGO_RESERVA_CLIENTE
        //                                                    ,U.[LOGIN]
        //                                                    ,U.[SENHA]
        //                                                    ,P.Ativo
        //                                                    ,P.ID_PERFIL
        //                                                    FROM [DBO].[USUARIO] U
        //                                                    INNER JOIN PERFIL_USUARIO P
        //                                                    ON (P.ID_USUARIO = U.ID) WHERE P.ATIVO ='S' AND P.ID_PERFIL = '{perfil}'", connection))
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
        //public DataTable buscarUsuariosClientesAtivos(string perfil)
        //{
        //    DataTable dta = new DataTable();
        //    SqlDataAdapter adp;
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(cnn))
        //        {
        //            using (SqlCommand cmd = new SqlCommand($@"SELECT U.[ID]  
        //                                                    ,U.NOME_USUARIO
        //                                                    ,U.CODIGO_RESERVA_CLIENTE
        //                                                    ,U.[LOGIN]
        //                                                    ,U.[SENHA]
        //                                                    ,P.ATIVO
        //                                                    ,P.ID_PERFIL
        //                                                    ,C.DATA_INICIO
        //                                                    ,C.DATA_FIM
        //                                                    FROM [DBO].[USUARIO] U
        //                                                    INNER JOIN CLIENTE C ON(C.CD_RESERVA = U.LOGIN)
        //                                                    INNER JOIN PERFIL_USUARIO P
        //                                                    ON (P.ID_USUARIO = U.ID)
        //                                                    WHERE P.ATIVO ='S' AND P.ID_PERFIL = '{perfil}'", connection))
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

        //public Usuario buscarUsuarioId(int Id)
        //{
        //    Usuario usu = new Usuario();
        //    try
        //    {

        //        using (SqlConnection connection = new SqlConnection(cnn))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
        //                                                  ,[NOME_USUARIO]
        //                                                  ,[CODIGO_RESERVA_CLIENTE]
        //                                                  ,[LOGIN]
        //                                                  ,[SENHA]
        //                                                  FROM [dbo].[USUARIO] WHERE ID = @ID", connection))
        //            {

        //                cmd.Parameters.AddWithValue("@ID", Id);
        //                cmd.Connection.Open();
        //                SqlDataReader registro = cmd.ExecuteReader();
        //                if (registro.HasRows)
        //                {
        //                    registro.Read();
        //                    usu.Id = Convert.ToInt32(registro["ID"]);
        //                    usu.Login = Convert.ToString(registro["LOGIN"]);
        //                    usu.Senha = Convert.ToString(registro["SENHA"]);

        //                }
        //            }
        //        }
        //    }
        //    catch (Exception erro)
        //    {
        //        throw new Exception(erro.Message);
        //    }

        //    return usu;
        //}

        //public Usuario buscaUsuarioLogin(string Login)
        //{
        //    Usuario usu = new Usuario();

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(cnn))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
        //                                                  ,[NOME_USUARIO]
        //                                                  ,[CODIGO_RESERVA_CLIENTE]
        //                                                  ,[LOGIN]
        //                                                  ,[SENHA]
        //                                              FROM [dbo].[USUARIO] WHERE LOGIN = @LOGIN", connection))
        //            {
        //                cmd.Parameters.AddWithValue("LOGIN", Login);
        //                cmd.Connection.Open();
        //                SqlDataReader registro = cmd.ExecuteReader();
        //                if (registro.HasRows)
        //                {
        //                    registro.Read();
        //                    usu.Id = Convert.ToInt32(registro["ID"]);
        //                    usu.Login = Convert.ToString(registro["LOGIN"]);
        //                    usu.Senha = Convert.ToString(registro["SENHA"]);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception erro)
        //    {
        //        throw new Exception(erro.Message);
        //    }
        //    return usu;

        //}

        ////Update
        //public void alterarUsuario(Usuario usu)
        //{
        //    using (SqlConnection connection = new SqlConnection(cnn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(@"UPDATE USUARIO SET LOGIN = @LOGIN WHERE  ID = @ID", connection))
        //        {
        //            try
        //            {
        //                cmd.Connection.Open();
        //                cmd.Parameters.AddWithValue("LOGIN", usu.Login);
        //                cmd.Parameters.AddWithValue("ID", usu.Id);
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

        //public void alterarSenha(Usuario usu)
        //{
        //    using (SqlConnection connection = new SqlConnection(cnn))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(@"UPDATE USUARIO SET SENHA =@SENHA where  ID = @ID", connection))
        //        {

        //            try
        //            {
        //                cmd.Connection.Open();
        //                cmd.Parameters.AddWithValue("SENHA", usu.Senha);
        //                cmd.Parameters.AddWithValue("ID", usu.Id);
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

        public void inserirUsuario(Usuario usu)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [DBO].[USUARIO]
                                                    ([LOGIN]
                                                    ,[SENHA]
                                                    ,[NOME]
                                                    ,[SOBRENOME])VALUES(@LOGIN,@SENHA,@NOME,@SOBRENOME)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("LOGIN", usu.Login);
                        cmd.Parameters.AddWithValue("SENHA", usu.Senha);
                        cmd.Parameters.AddWithValue("NOME", usu.NomeUsuario);
                        cmd.Parameters.AddWithValue("SOBRENOME", usu.SobrenomeUsuario);
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


        //Read
        public DataTable buscarTodosUsuarios()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_USUARIO]
                                                          ,[LOGIN]
                                                          ,[SENHA]
                                                          ,[NOME]
                                                          ,[SOBRENOME]
                                                      FROM [SERVICOHOTELARIA].[DBO].[USUARIO]", connection))
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
                return dta;
            }
        }

        public DataTable buscarUsuariosAtivos()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand($@"SELECT U.[ID_USUARIO]
                                                            ,U.NOME                                                          
                                                            ,U.SOBRENOME                                                          
                                                            ,U.[LOGIN]
                                                            ,U.[SENHA]
                                                            ,P.STATUS_USUARIO
                                                            ,P.ID_PERFIL
                                                            FROM [DBO].[USUARIO] U
                                                            INNER JOIN PERFIL_USUARIO P
                                                            ON (P.ID_USUARIO = U.ID_USUARIO) WHERE P.ATIVO ='S'", connection))
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

        public DataTable buscarUsuariosPerfilStatus(string Perfil,string Status)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            string parPerfilStatus = "";
            if (Perfil != "" && Status != "")
            {
                parPerfilStatus = "WHERE P.STATUS_USUARIO =@STATUS_USUARIO AND P.ID_PERFIL = @ID_PERFIL";
            }
            else if (Perfil != "" && Status == "")
            {
                parPerfilStatus = "WHERE P.ID_PERFIL = @ID_PERFIL";
            }
            else if (Perfil == "" && Status != "")
            {
                parPerfilStatus = "WHERE P.STATUS_USUARIO =@STATUS_USUARIO";
            }

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand($@"SELECT U.[ID_USUARIO]
                                                            ,U.NOME                                                         
                                                            ,U.SOBRENOME                                                          
                                                            ,U.[LOGIN]
                                                            ,U.[SENHA]
                                                            ,P.STATUS_USUARIO
                                                            ,P.ID_PERFIL
                                                            FROM [DBO].[USUARIO] U
                                                            INNER JOIN PERFIL_USUARIO P
                                                            ON (P.ID_USUARIO = U.ID_USUARIO) 
                                                            {parPerfilStatus}", connection))
                {
                    try
                    {
                        if (Perfil != "" && Status != "")
                        {
                            cmd.Parameters.AddWithValue("ID_PERFIL", Perfil);
                            cmd.Parameters.AddWithValue("@STATUS_USUARIO", Status);
                        }
                        else if (Perfil != "" && Status == "")
                        {
                            cmd.Parameters.AddWithValue("ID_PERFIL", Perfil);
                        }
                        else if (Perfil == "" && Status != "")
                        {
                            cmd.Parameters.AddWithValue("@STATUS_USUARIO", Status);
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

        public DataTable buscarUsuariosClientesStatus(string Perfil,string Status)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            string parPerfilStatus = "";
            if (Perfil != "" && Status != "")
            {
                parPerfilStatus = "WHERE P.STATUS_USUARIO =@STATUS_USUARIO AND P.ID_PERFIL = @ID_PERFIL";
            }
            else if (Perfil != "" && Status == "")
            {
                parPerfilStatus = "WHERE P.ID_PERFIL = @ID_PERFIL" ;
            }
            else if (Perfil == "" && Status != "")
            {
                parPerfilStatus = "WHERE P.STATUS_USUARIO =@STATUS_USUARIO";
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand($@"SELECT U.[ID_USUARIO]  
                                                            ,U.NOME
                                                            ,U.SOBRENOME
                                                            ,U.[LOGIN]
                                                            ,U.[SENHA]
                                                            ,U.NOME
                                                            ,U.SOBRENOME
                                                            ,P.STATUS_USUARIO
                                                            ,P.ID_PERFIL
                                                            ,C.DATA_ENTRADA
                                                            ,C.DATA_SAIDA
                                                            ,C.ID_QUARTO
                                                            ,Q.DESCRICAO_QUARTO
                                                            FROM [DBO].[USUARIO] U
                                                            INNER JOIN CLIENTE C ON(C.COD_RESERVA = U.LOGIN)
                                                            INNER JOIN QUARTO Q ON (Q.ID_QUARTO = C.ID_QUARTO)
                                                            INNER JOIN PERFIL_USUARIO P ON (P.ID_USUARIO = U.ID_USUARIO)
                                                            {parPerfilStatus}", connection))
                    {
                        if (Perfil != "" && Status != "")
                        {
                            cmd.Parameters.AddWithValue("ID_PERFIL", Perfil);
                            cmd.Parameters.AddWithValue("@STATUS_USUARIO", Status);
                        }
                        else if (Perfil != "" && Status == "")
                        {
                            cmd.Parameters.AddWithValue("ID_PERFIL", Perfil);
                        }
                        else if (Perfil == "" && Status != "")
                        {
                            cmd.Parameters.AddWithValue("@STATUS_USUARIO", Status);
                        }
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();

                    }
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            return dta;
        }

        public Usuario buscarUsuarioId(int IdUsuario)
        {
            Usuario usu = new Usuario();

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_USUARIO]
                                                                      ,[LOGIN]
                                                                      ,[SENHA]
                                                                      ,[NOME]
                                                                      ,[SOBRENOME]
                                                                  FROM [DBO].[USUARIO] WHERE ID_USUARIO = @ID_USUARIO", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@ID_USUARIO", IdUsuario);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            usu.IdUsuario = Convert.ToInt32(registro["ID_USUARIO"]);
                            usu.Login = Convert.ToString(registro["LOGIN"]);
                            usu.Senha = Convert.ToString(registro["SENHA"]);
                            usu.NomeUsuario = Convert.ToString(registro["NOME"]);
                            usu.SobrenomeUsuario = Convert.ToString(registro["SOBRENOME"]);

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
            return usu;
        }

        public Usuario buscaUsuarioLogin(string Login)
        {
            Usuario usu = new Usuario();

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID_USUARIO]
                                                                      ,[LOGIN]
                                                                      ,[SENHA]
                                                                      ,[NOME]
                                                                      ,[SOBRENOME]
                                                                  FROM [DBO].[USUARIO] WHERE LOGIN = @LOGIN", connection))
                    {

                        cmd.Parameters.AddWithValue("@LOGIN", Login);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            usu.IdUsuario = Convert.ToInt32(registro["ID_USUARIO"]);
                            usu.Login = Convert.ToString(registro["LOGIN"]);
                            usu.Senha = Convert.ToString(registro["SENHA"]);
                            usu.NomeUsuario = Convert.ToString(registro["NOME"]);
                            usu.SobrenomeUsuario = Convert.ToString(registro["SOBRENOME"]);

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
            return usu;

        }

        //Update
        public void alterarUsuario(Usuario usu)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE USUARIO SET LOGIN = @LOGIN WHERE  ID_Usuario = @ID_USUARIO", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("LOGIN", usu.Login);
                        cmd.Parameters.AddWithValue("ID_USUARIO", usu.IdUsuario);
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

        public void alterarSenha(Usuario usu)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE USUARIO SET SENHA =@SENHA WHERE  ID_USUARIO = @ID_USUARIO", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("SENHA", usu.Senha);
                        cmd.Parameters.AddWithValue("ID_USUARIO", usu.IdUsuario);
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

