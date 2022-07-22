using SistemaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaHotel.Controller
{
    public class DALUsuarioPerfil
    {
        string cnn = @"Data Source=LAPTOP-JV98S2OU\SQLEXPRESS;Initial Catalog=hotelServicos;Integrated Security=True";

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
                                                    FROM[DBO].[PERFIL_USUARIO] where EMAIL = @EMAIL", connection))
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
    }
}