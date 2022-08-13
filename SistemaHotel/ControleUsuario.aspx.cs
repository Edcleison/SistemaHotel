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
using SistemaHotel.Utils;

namespace SistemaHotel
{
    public partial class ControleUsuario : System.Web.UI.Page
    {
        string cnn = @"Password=Sc3f_r4_104t;Persist Security Info=True;User ID = hotelservicos; Initial Catalog = hotelservicos; Data Source =den1.mssql8.gear.host;Initial";

        DALPerfilUsuario dalPerfUsu = new DALPerfilUsuario();
        DALUsuario dalUsu = new DALUsuario();

        protected void Page_Load(object sender, EventArgs e)

        {
            int rParametro = 0;

            if (!IsPostBack)
            {

                if (Request.QueryString["USUARIO_D"] != null)
                {
                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["USUARIO_D"]));

                    Usuario usu = dalUsu.buscarUsuarioId(rParametro);
                                    
                    if (usu.Id != 0)
                    {
                        dalPerfUsu.inativarUsuario(usu.Id);
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
            rDta = dalUsu.buscarTodosUsuariosAtivos();
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
                sb.AppendLine("<td><center><a href='ControleUsuario.aspx?USUARIO_D=" + Criptografia.Encrypt(dtr["ID"].ToString()) + "'><i class='fa fa-trash'></i></center></td>");
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }
    }
}
