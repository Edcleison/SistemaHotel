using SistemaHotel.Controller;
using SistemaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaHotel
{
    public partial class PaginaMestre : System.Web.UI.MasterPage
    {
        DataTable dta = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
               // Response.Redirect("~/login.aspx");

            }
            else if (Session["perfil"].ToString() == "ADMINISTRADOR")
            {
                ControleProduto.Visible = true;
                ControleAtendimento.Visible = true;
                ControleUsuario.Visible = true;
                ControleQuarto.Visible = true;
                Atendimento.Visible = true;

            }

            else if (Session["perfil"].ToString() == "FUNCIONARIO")
            {

                Atendimento.Visible = true;

            }
            else
            {
                NovoPedidoCozinha.Visible = true;
                NovoPedidoFrigobar.Visible = true;

            }
        }
    } 
}
