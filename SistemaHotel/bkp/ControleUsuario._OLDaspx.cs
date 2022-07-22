using SistemaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaHotel.Controller;

namespace SistemaHotel.View
{
    public partial class ControleUsuario : System.Web.UI.Page
    {
        string cnn = @"Data Source=LAPTOP-JV98S2OU\SQLEXPRESS;Initial Catalog=sisFrases;Integrated Security=True";

        DALUsuario usu = new DALUsuario();

        protected void Page_Load(object sender, EventArgs e)

        {
            string rParametro = null;

            if (!IsPostBack)
            {

                if (Request.QueryString["USUARIO_D"] != null)
                {
                    rParametro = usu.Decrypt(Request.QueryString["USUARIO_D"].ToString());

                    if (usu.buscarUsuarioId(rParametro) != null)
                    {

                        usu.inativarUsuario(rParametro);
                        string msg = "<script> alert('Usuário Inativado!'); </script>";
                        Response.Write(msg);

                    }


                }

                else
                {
                    carregarTabela();
                }

            }

            carregarTabela();
        }

        private void carregarTabela()
        {

            DataTable rDta = new DataTable();
            rDta = usu.buscarTodosUsuarios();
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th><center>ID</th></center>");
            sb.AppendLine("<th><center>NOME</th></center>");
            sb.AppendLine("<th><center>EMAIL</th></center>");
            sb.AppendLine("<th><center>INATIVAR</th></center>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td><center>" + dtr["ID"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["NOME"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["EMAIL"] + "</td></center>");
                sb.AppendLine("<td><center><a href='ControleUsuario.aspx?USUARIO_D=" + usu.Encrypt(dtr["ID"].ToString()) + "'><i class='fa fa-trash'></i></center></td>");
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }
    }
}
