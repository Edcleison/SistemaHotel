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
                DALPerfilUsuario dalPerfUsu = new DALPerfilUsuario();
                DALUsuario dalUsu = new DALUsuario();
                Usuario usu = dalUsu.buscaUsuarioLogin(Session["login"].ToString());
                PerfilUsuario usuPerfil = dalPerfUsu.buscarUsuarioPerfil(usu.Id);



                if (usuPerfil.Perfil == 1 || usuPerfil.Perfil == 2)
                {
                    lbNomeUsuario.Visible = true;
                    lbNomeUsuarioLegenda.Visible = true;
                    lbNomeUsuario.Text = Session["nomeUsuario"].ToString();
                    lbPerfil.Text = Session["perfil"].ToString();
                }
                
                else
                {
                    lbCodigoReserva.Visible = true;
                    lbCodigoReservaLegenda.Visible = true;
                    lbCodigoReserva.Text = Session["codigoReserva"].ToString();
                    lbPerfil.Text = Session["perfil"].ToString();
                }

            }

        }
    }

}

