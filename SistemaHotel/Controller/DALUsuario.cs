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
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[USUARIO]
                                                    ([Login]
                                                    ,[Senha]
                                                    ,[Nome_Usuario])VALUES(@Login,@Senha,@Nome_Usuario)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("Login", usu.Login);
                        cmd.Parameters.AddWithValue("Senha", usu.Senha);
                        cmd.Parameters.AddWithValue("Nome_Usuario", usu.NomeUsuario);
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
                using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Usuario]
                                                          ,[Login]
                                                          ,[Senha]
                                                          ,[Nome_Usuario]
                                                      FROM [servicohotelaria].[dbo].[USUARIO]", connection))
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
                                                            ,U.NOME_USUARIO                                                           
                                                            ,U.[LOGIN]
                                                            ,U.[SENHA]
                                                            ,P.Status_Perfil_Usuario
                                                            ,P.FK_PERFIL_Id_Perfil
                                                            FROM [DBO].[USUARIO] U
                                                            INNER JOIN PERFIL_USUARIO P
                                                            ON (P.FK_USUARIO_Id_Usuario = U.ID_USUARIO) WHERE P.ATIVO ='S'", connection))
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

        public DataTable buscarUsuariosPerfilAtivos(string perfil)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand($@"SELECT U.[ID_USUARIO]
                                                            ,U.NOME_USUARIO                                                           
                                                            ,U.[LOGIN]
                                                            ,U.[SENHA]
                                                            ,P.Status_Perfil_Usuario
                                                            ,P.FK_PERFIL_Id_Perfil
                                                            FROM [DBO].[USUARIO] U
                                                            INNER JOIN PERFIL_USUARIO P
                                                            ON (P.FK_USUARIO_Id_Usuario = U.ID_USUARIO) WHERE P.Status_Perfil_Usuario ='S' AND P.FK_PERFIL_Id_Perfil = '{perfil}'", connection))
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

        public DataTable buscarUsuariosClientesAtivos(string perfil)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand($@"SELECT U.[ID_Usuario]  
                                                            ,U.NOME_USUARIO
                                                            ,U.[LOGIN]
                                                            ,U.[SENHA]
                                                            ,U.Nome_Usuario
                                                            ,P.Status_Perfil_Usuario
                                                            ,P.FK_PERFIL_Id_Perfil
                                                            ,C.DATA_Entrada
                                                            ,C.DATA_Saida
                                                            ,C.Quarto
                                                            FROM [DBO].[USUARIO] U
                                                            INNER JOIN CLIENTE C ON(C.COD_RESERVA = U.LOGIN)
                                                            INNER JOIN PERFIL_USUARIO P
                                                            ON (P.FK_USUARIO_Id_Usuario = U.ID_Usuario)
                                                            WHERE P.Status_Perfil_Usuario ='S' AND P.FK_PERFIL_Id_Perfil = '{perfil}'", connection))
                    {
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
                using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Usuario]
                                                                      ,[Login]
                                                                      ,[Senha]
                                                                      ,[Nome_Usuario]
                                                                  FROM [dbo].[USUARIO] WHERE ID_Usuario = @Id_Usuario", connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@Id_Usuario", IdUsuario);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            usu.IdUsuario = Convert.ToInt32(registro["Id_Usuario"]);
                            usu.Login = Convert.ToString(registro["Login"]);
                            usu.Senha = Convert.ToString(registro["Senha"]);
                            usu.NomeUsuario = Convert.ToString(registro["Nome_Usuario"]);

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
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [Id_Usuario]
                                                                      ,[Login]
                                                                      ,[Senha]
                                                                      ,[Nome_Usuario]
                                                                  FROM [dbo].[USUARIO] WHERE Login = @Login", connection))
                    {

                        cmd.Parameters.AddWithValue("@Login", Login);
                        cmd.Connection.Open();
                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro.HasRows)
                        {
                            registro.Read();
                            usu.IdUsuario = Convert.ToInt32(registro["Id_Usuario"]);
                            usu.Login = Convert.ToString(registro["Login"]);
                            usu.Senha = Convert.ToString(registro["Senha"]);
                            usu.NomeUsuario = Convert.ToString(registro["Nome_Usuario"]);

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
                using (SqlCommand cmd = new SqlCommand(@"UPDATE USUARIO SET LOGIN = @LOGIN WHERE  ID_Usuario = @Id_Usuario", connection))
                {
                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("LOGIN", usu.Login);
                        cmd.Parameters.AddWithValue("Id_Usuario", usu.IdUsuario);
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
                using (SqlCommand cmd = new SqlCommand(@"UPDATE USUARIO SET SENHA =@SENHA where  ID_Usuario = @ID_Usuario", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("SENHA", usu.Senha);
                        cmd.Parameters.AddWithValue("ID_Usuario", usu.IdUsuario);
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

