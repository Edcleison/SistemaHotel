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
        string cnn = @"Data Source=LAPTOP-JV98S2OU\SQLEXPRESS;Initial Catalog=hotelServicos;Integrated Security=True";
        public DataTable buscarTodosUsuarios()
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;
            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
                                                      ,[NOME]
                                                      ,[EMAIL]
                                                      ,[SENHA]
                                                      ,[ATIVO]
                                                  FROM [DBO].[USUARIO] WHERE ATIVO = 'S'", connection))
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        return dta;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }


        public void inserirUsuario(string Nome, string Email, string Senha)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[USUARIO]
                                                   ([NOME]
                                                   ,[EMAIL]
                                                   ,[SENHA]
                                                   ,[ATIVO])
                                             VALUES(@NOME,@EMAIL,@SENHA,'" + "S" + "')", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("NOME", Nome);
                        cmd.Parameters.AddWithValue("EMAIL", Email);
                        cmd.Parameters.AddWithValue("SENHA", Senha);
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    catch
                    {

                    }

                }
            }
        }

        public void inserirPerfil(string Perfil, string Email)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [DBO].[PERFIL_USUARIO]
                                                   ([PERFIL]
                                                   ,[EMAIL])
                                             VALUES(@PERFIL,@EMAIL)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("PERFIL", Perfil);
                        cmd.Parameters.AddWithValue("EMAIL", Email);
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    catch
                    {

                    }

                }
            }

        }


        public void alterarUsuario(string Nome, string Email, string Senha, string Id)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE USUARIO SET NOME = @NOME, EMAIL = @EMAIL where  ID = @ID", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("NOME", Nome);
                        cmd.Parameters.AddWithValue("EMAIL", Email);
                        cmd.Parameters.AddWithValue("ID", Id);
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    catch
                    {

                    }

                }
            }
        }

        public void alterarSenha(string Senha, string Id)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE USUARIO SET SENHA =@SENHA where  ID = @ID", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("SENHA", Senha);
                        cmd.Parameters.AddWithValue("ID", Id);
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    catch
                    {

                    }

                }
            }
        }

        

        public void inativarUsuario(string Id)
        {
            Usuario usu = new Usuario();

            //usu.
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE USUARIO SET ATIVO = 'N' WHERE ID = @ID", connection))
                {

                    try
                    {

                        connection.Open();
                        cmd.Parameters.AddWithValue("ID", Id);
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    catch
                    {

                    }
                }
            }
        }

        public void ativarUsuario(string Nome, string Email, string Senha)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE USUARIO SET ATIVO = 'S', NOME= @NOME, SENHA= @SENHA WHERE EMAIL = @EMAIL", connection))
                {

                    try
                    {

                        connection.Open();
                        cmd.Parameters.AddWithValue("NOME", Nome);
                        cmd.Parameters.AddWithValue("SENHA", Senha);
                        cmd.Parameters.AddWithValue("EMAIL", Email);
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    catch
                    {

                    }
                }
            }
        }

        public DataTable buscarUsuarioId(string Id)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
                                                      ,[NOME]
                                                      ,[EMAIL]
                                                      ,[SENHA]
                                                      ,[ATIVO]
                                                  FROM[DBO].[USUARIO] WHERE ID = @ID", connection))
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("ID", Id);
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        return dta;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public DataTable buscaUsuarioEmailAtivo(string Email)
        {

            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
                                                      ,[NOME]
                                                      ,[EMAIL]
                                                      ,[SENHA]
                                                      ,[ATIVO]
                                                  FROM[DBO].[USUARIO] WHERE EMAIL = @EMAIL AND ATIVO ='S'" + "", connection))
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("EMAIL", Email);
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        return dta;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        public DataTable buscaUsuarioEmailInativo(string Email)
        {

            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
                                                      ,[NOME]
                                                      ,[EMAIL]
                                                      ,[SENHA]
                                                      ,[ATIVO]
                                                  FROM[DBO].[USUARIO] WHERE EMAIL = @EMAIL AND ATIVO ='N'" + "", connection))
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("EMAIL", Email);
                        cmd.ExecuteNonQuery();
                        adp = new SqlDataAdapter(cmd);
                        adp.Fill(dta);
                        cmd.Connection.Close();
                        return dta;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public string Encrypt(string textToEncrypt)
        {
            try
            {

                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "87654321";
                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public string Decrypt(string textToDecrypt)
        {
            try
            {
                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "87654321";
                byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }

    }
}

