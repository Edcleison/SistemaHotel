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
            if (Session["login"] != null)
            {

                lbNomeUsuario.Text = Session["nomeUsuario"].ToString();
                lbCodigoReserva.Text = Session["login"].ToString();
                lbPerfil.Text = Session["perfil"].ToString();

            }

        }
    }

}

