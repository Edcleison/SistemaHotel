using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RedefinirSenha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        

    }
   
    protected void lnkEmail_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();
        string email = txtEmail.Text;
        DataTable dta = new DataTable();
        dta = usu.buscaUsuarioEmailAtivo(email);
        if (dta.Rows.Count > 0)
        {
            divSenha.Visible = true;
        }
        else
        {
            string msg = "<script> alert('Email não encontrado!'); </script>";
            Response.Write(msg);
            divSenha.Visible = false;
        }


    }

    protected void lnkSenha_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();
        string email = txtEmail.Text;
        DataTable dta = new DataTable();
        dta = usu.buscaUsuarioEmailAtivo(email);
        if (dta.Rows.Count > 0)
        {
            if (txtNovaSenha.Text == txtConfirmaSenha.Text)
            {

                string senha = usu.Encrypt(txtConfirmaSenha.Text);
                string id = dta.Rows[0]["ID"].ToString();
                usu.alterarSenha(senha, id);

                string msg = "<script> alert('Senha Atualizada!'); </script>";
                Response.Write(msg);
                limparCampos();
                divSenha.Visible = false;
            }
            else
            {
                string msg = "<script> alert('Digite as Senhas Iguais!'); </script>";
                Response.Write(msg);
            }
            

        }
        else
        {
            string msg = "<script> alert('Email não encontrado!'); </script>";
            Response.Write(msg);
        }
        
    }
    private void limparCampos()
    {
        txtEmail.Text = "";
        txtNovaSenha.Text = "";
        txtConfirmaSenha.Text = "";
    }
}