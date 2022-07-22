using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class Login : System.Web.UI.Page
{
    //variáves auxiliares
    string rId;
    string rEmail = "";
    string rSenhaD = "";
    string rNome;
    string rSenhaC = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
    }

    protected void btlogar_Click(object sender, EventArgs e)
    {
        // variáveis login do usuário
        Usuario usu = new Usuario();
        DataTable dta = new DataTable();
        string email = txtLogin.Text;
        rSenhaD = txtSenha.Text;
        dta = usu.buscaUsuarioEmailAtivo(email);


        //variáveis login cliente primeiro acesso
        Cliente cli = new Cliente();
        DataTable dta1 = new DataTable();
        dta1 = cli.buscarClienteEmailHotel(email);

        //cliente que já tem acesso
        DataTable dta2 = new DataTable();
        dta2 = cli.buscarClienteEmailSistema(email);

        //Login do Cliente (Primeira vez)
        if (dta1.Rows.Count > 0 && dta2.Rows.Count == 0)
        {
            if (rSenhaD == dta1.Rows[0]["CPF"].ToString())
            {
                divSenhaCliente.Visible = true;
                btlogar.Visible = false;
                lnkRecadastrarSenha.Visible = false;
            }
            else
            {
                string msg = "<script> alert('Senha incorreta!'); </script>";
                Response.Write(msg);

            }
        }

        // Login do Usuário 
        else if (dta.Rows.Count > 0)
        {
            rId = dta.Rows[0]["ID"].ToString();
            rNome = dta.Rows[0]["NOME"].ToString();
            rEmail = dta.Rows[0]["Email"].ToString();
            rSenhaC = usu.Decrypt(dta.Rows[0]["Senha"].ToString());
            VerificaLogin(email, rSenhaD);

        }
        // Login Cliente
        else if (dta2.Rows.Count > 0)
        {
            rId = dta2.Rows[0]["ID"].ToString();
            rNome = dta2.Rows[0]["NOME"].ToString();
            rEmail = dta2.Rows[0]["Email"].ToString();
            rSenhaC = cli.Decrypt(dta2.Rows[0]["Senha"].ToString());
            VerificaLogin(email, rSenhaD);
        }


    }

    protected void lnkSenha_Click(object sender, EventArgs e)
    {
        Cliente cli = new Cliente();
        string email = txtLogin.Text;
        DataTable dta = new DataTable();
        dta = cli.buscarClienteEmailHotel(email);



        if (dta.Rows.Count > 0)
        {
            if (txtSenha.Text == dta.Rows[0]["CPF"].ToString())
            {

                if (txtNovaSenha.Text == txtConfirmaSenha.Text)
                {
                    string nome = dta.Rows[0]["NOME"].ToString();
                    string cpf = dta.Rows[0]["CPF"].ToString();
                    string telefone = dta.Rows[0]["TELEFONE"].ToString();
                    string senha = cli.Encrypt(txtConfirmaSenha.Text);
                    string id = dta.Rows[0]["ID"].ToString();                              
                    cli.inserirCliente(nome,cpf,email,telefone);
                    cli.inserirUsuario(nome, email, senha);
                    cli.inserirPerfil(email);
                    string msg = "<script> alert('Senha Atualizada!'); </script>";
                    Response.Write(msg);
                    limparCampos();
                    divSenhaCliente.Visible = false;
                    btlogar.Visible = true;
                    lnkRecadastrarSenha.Visible = true;

                }
                else
                {
                    string msg = "<script> alert('Digite as Senhas Iguais!'); </script>";
                    Response.Write(msg);
                }
            }
            else
            {
                string msg = "<script> alert('No primeiro acesso a senha é o CPF!'); </script>";
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
        txtLogin.Text = "";
        txtSenha.Text = "";
        txtNovaSenha.Text = "";
        txtConfirmaSenha.Text = "";
    }

    private void VerificaLogin(string email, string rSenhaD)
    {
        if (email != "" && rSenhaD != "")
        {

            if (email == rEmail && rSenhaD != rSenhaC)
            {
                String msg = "<script> alert('Senha incorreta!'); </script>";
                Response.Write(msg);
            }
            else if (email != rEmail)
            {
                String msg = "<script> alert('Email incorreto!'); </script>";
                Response.Write(msg);
            }
            else
            {
                Session["id"] = rId;
                Session["nome"] = rNome;
                Session["email"] = rEmail;
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            String msg = "<script> alert('Preencha corretamente!); </script>";
            Response.Write(msg);
        }
    }
}

