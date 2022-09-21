using SistemaHotel.Controller;
using SistemaHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaHotel
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["login"] != null)
                {

                    lbNomeUsuario.Text = Session["nome"].ToString();
                    lbLogin.Text = Session["login"].ToString();
                    lbPerfil.Text = Session["perfil"].ToString();
                    if (Session["perfil"].ToString() == "CLIENTE")
                    {
                        divTotal.Visible = true;
                        DALCliente dalCli = new DALCliente();
                        Cliente cli = dalCli.buscarClienteReserva(Session["login"].ToString());
                        DALPedido dalPed = new DALPedido();
                        lblTotal.Text = $"R$ {dalPed.buscarValorTotalCliente(cli.IdCliente)}";

                    }

                }
            }

        }

        protected void lnkConsumo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AcompanhamentoCliente.aspx");
        }
    }
}