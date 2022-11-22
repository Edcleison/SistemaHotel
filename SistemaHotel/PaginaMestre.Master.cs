using SistemaHotel.Controller;
using SistemaHotel.Model;
using System;
using System.Data;
using System.Globalization;


namespace SistemaHotel
{
    public partial class PaginaMestre : System.Web.UI.MasterPage
    {
        CultureInfo ptBR = new CultureInfo("pt-BR");
        DataTable dta = new DataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/login.aspx");

            }
            else if (Session["perfil"].ToString() == "Administração")
            {

                NovoPedidoCozinha.Visible = false;
                NovoPedidoFrigobar.Visible = false;
                ResumoPedidos.Visible = false;
            }

            else if (Session["perfil"].ToString() == "Funcionário")
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
              
                Cliente cli = DALCliente.buscarClienteReserva(Session["login"].ToString());
                Atendimento.Visible = false;
                ControleProduto.Visible = false;
                ControleAtendimento.Visible = false;
                ControleUsuario.Visible = false;
                ControleQuarto.Visible = false;
                if (cli.FlagPedidoFrigobar =='N')
                {
                    NovoPedidoFrigobar.Visible = false;
                }
            }
        }
    } 
}
