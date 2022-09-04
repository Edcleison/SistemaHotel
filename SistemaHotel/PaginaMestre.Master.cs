using SistemaHotel.Controller;
using SistemaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
            else
            {
                DALPerfilUsuario dalPerfUsu = new DALPerfilUsuario();
                DALUsuario dalUsu = new DALUsuario();
                Usuario usu =dalUsu.buscaUsuarioLogin(Session["login"].ToString());
                PerfilUsuario usuPerfil = dalPerfUsu.buscarUsuarioPerfil(usu.IdUsuario);               
              

                if (usuPerfil.IdPerfil == 1)
                {
                    
                }
                else if (usuPerfil.IdPerfil == 2)
                {

                   

                }
                else
                {

                }
            }
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }
    }
}