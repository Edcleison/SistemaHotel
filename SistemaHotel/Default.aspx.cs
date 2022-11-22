using SistemaHotel.Controller;
using SistemaHotel.Model;
using System;
using System.Globalization;

namespace SistemaHotel
{
    public partial class Default : System.Web.UI.Page
    {
        CultureInfo ptBR = new CultureInfo("pt-BR");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["login"] != null)
                {

                    lbNomeUsuario.Text = Session["nome"].ToString();
                    lbLogin.Text = Session["login"].ToString();
                    lbPerfil.Text = Session["perfil"].ToString();
                    if (Session["perfil"].ToString() == "Cliente")
                    {
                        divTotal.Visible = true;
                        Cliente cli = DALCliente.buscarClienteReserva(Session["login"].ToString());  
                        lblTotal.Text = $"R$ {DALPedido.buscarValorTotalCliente(cli.IdCliente)}";

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