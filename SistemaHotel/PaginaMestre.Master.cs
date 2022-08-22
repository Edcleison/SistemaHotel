﻿using SistemaHotel.Controller;
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
               //Response.Redirect("~/login.aspx");

            }
            else
            {
                DALPerfilUsuario dalPerfUsu = new DALPerfilUsuario();
                DALUsuario dalUsu = new DALUsuario();
                Usuario usu =dalUsu.buscaUsuarioLogin(Session["login"].ToString());
                PerfilUsuario usuPerfil = dalPerfUsu.buscarUsuarioPerfil(usu.Id);

                //if (usuPerfil.Perfil == 1)
                //{
                //    h1Usuario.Visible = true;
                //    h1Cliente.Visible = true;
                //    h1Atendimento.Visible = true;
                //    h1Restaurante.Visible = true;
                //    h1Frigobar.Visible = true;
                //    h1ArCondicionado.Visible = true;
                //    h1Banheira.Visible = true;

                //}
                //else if (usuPerfil.Perfil == 2)
                //{

                //    h1Cliente.Visible = true;
                //    h1Atendimento.Visible = true;

                //}
                //else
                //{

                //    h1Restaurante.Visible = true;
                //    h1Frigobar.Visible = true;
                //    h1ArCondicionado.Visible = true;
                //    h1Banheira.Visible = true;

                //}
            }
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }
    }
}