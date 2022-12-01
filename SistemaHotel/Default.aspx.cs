using SistemaHotel.Controller;
using SistemaHotel.Model;
using System;
using System.Data;
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
                        DateTime dataSaida = cli.DataSaida; 
                        DataTable dta = DALPedido.buscarValorTotalCliente(cli.IdCliente);
                        decimal total = 0;
                        if (dta != null )
                        {
                            foreach (DataRow dtr in dta.Rows)
                            {
                                if (dtr["DESCRICAO_STATUS_PED"].ToString() == "Finalizado")
                                {
                                    if (dtr["ID_TIPO_PROD"].ToString() == "1")
                                    {
                                        total += Convert.ToDecimal(dtr["PRECO_UNI"], ptBR) * int.Parse(dtr["QUANTIDADE"].ToString());
                                    }
                                    else
                                    {
                                        //calcula o preco total do pedido de frigobar = (valor unitario (por dia) x qtde. de dias) - qtde de dias
                                        int totalDias = (int)dataSaida.Subtract(DateTime.Today).TotalDays;
                                        decimal valorTotal = (Convert.ToDecimal(dtr["PRECO_UNI"], ptBR) * totalDias) - totalDias;
                                        total += valorTotal;
                                    }
                                }
                            }
                        }
                         lblTotal.Text = $"R$ {total}";

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