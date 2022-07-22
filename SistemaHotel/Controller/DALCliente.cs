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

    public class DALCliente
    {
        string cnn = @"Data Source=LAPTOP-JV98S2OU\SQLEXPRESS;Initial Catalog=HOTEL_RESTAURANTE;Integrated Security=True";
        
        public void inserirCliente(string Nome, string Cpf, string Email, string Telefone)
        {

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[CLIENTE]
           ([NOME]
           ,[CPF]
           ,[EMAIL]
           ,[TELEFONE]
           ,[ATIVO]) 
            VALUES(@NOME ,@CPF,@EMAIL,@TELEFONE,'S')", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
                        cmd.Parameters.AddWithValue("NOME", Nome);
                        cmd.Parameters.AddWithValue("CPF", Cpf);
                        cmd.Parameters.AddWithValue("EMAIL", Email);
                        cmd.Parameters.AddWithValue("TELEFONE", Email);
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    catch
                    {
                        Exception e;
                    }

                }
            }
        }

        public void inserirUsuario(string Nome, string Email, string Senha)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[USUARIOS]
           ([nome]
           ,[email]
           ,[senha]
           ,[ativo])
            VALUES(@NOME ,@EMAIL,@SENHA,'S')", connection))
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

        public void inserirPerfil(string Email)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[PERFIL_USUARIOS]
           ([PERFIL]
           ,[EMAIL])
            VALUES('3',@EMAIL)", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
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

        public DataTable buscarUsuarioPerfil(string Email)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
                                                      ,[PERFIL]
                                                      ,[EMAIL]
                                                       FROM[dbo].[PERFIL_USUARIOS] where EMAIL = @EMAIL", connection))
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

        public void alterarSenha(string Senha, string Email)
        {
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand(@"UPDATE USUARIOS SET SENHA= @SENHA WHERE  EMAIL =@EMAIL", connection))
                {

                    try
                    {
                        cmd.Connection.Open();
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




        public DataTable buscarClienteId(string Id)
        {
            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
                                                       ,[NOME]
                                                      ,[CPF]
                                                      ,[EMAIL]
                                                      ,[TELEFONE]
                                                      ,[ATIVO]
                                                       FROM [DBO].[CLIENTE]
                                                       WHERE ID = @ID", connection))
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

        public DataTable buscarClienteEmail(string Email)
        {

            DataTable dta = new DataTable();
            SqlDataAdapter adp;

            try
            {
                using (SqlConnection connection = new SqlConnection(cnn))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SELECT [ID]
                                                              ,[NOME]
                                                              ,[CPF]
                                                              ,[EMAIL]
                                                              ,[SENHA]
                                                              ,[TELEFONE]
                                                              ,[ATIVO]
                                                    FROM [DBO].[USUARIOS] WHERE EMAIL =@EMAIL AND ATIVO= 'S'" + "", connection))
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