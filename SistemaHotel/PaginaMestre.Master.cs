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
                Response.Redirect("~/login.aspx");

            }
            else if (Session["perfil"].ToString() == "ADMINISTRADOR")
            {

                //ControleProduto.Visible = true;
                //ControleAtendimento.Visible = true;
                //ControleUsuario.Visible = true;
                //ControleQuarto.Visible = true;
                //Atendimento.Visible = true;

                NovoPedidoCozinha.Visible = false;
                NovoPedidoFrigobar.Visible = false;
                ResumoPedidos.Visible = false;
            }

            else if (Session["perfil"].ToString() == "FUNCIONARIO")
            {

                ControleProduto.Visible = false;
                ControleAtendimento.Visible = false;
                ControleUsuario.Visible = false;
                ControleQuarto.Visible = false;

                NovoPedidoCozinha.Visible = false;
                NovoPedidoFrigobar.Visible = false;
                ResumoPedidos.Visible = false;


            }
            else
            {
                Atendimento.Visible = false;
                ControleProduto.Visible = false;
                ControleAtendimento.Visible = false;
                ControleUsuario.Visible = false;
                ControleQuarto.Visible = false;

            }
        }
    } 
}
