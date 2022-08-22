using SistemaHotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaHotel.Controller;
using SistemaHotel.Utils;


namespace SistemaHotel
{
    public partial class ControleProduto : System.Web.UI.Page
    {
        string cnn = @"Data Source=den1.mssql8.gear.host;Initial Catalog=hotelservicos;Persist Security Info=True;User ID=hotelservicos;Password=Sc3f_r4_104t";

        
        DALProduto dalProd = new DALProduto();

        protected void Page_Load(object sender, EventArgs e)
        {
            int rParametro = 0;

            if (!IsPostBack)
            {

                if (Request.QueryString["PRODUTO_D"] != null)
                {
                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["USUARIO_D"]));

                    Produto prod = dalProd.buscarProdutoId(rParametro);

                    if (prod.Id != 0)
                    {
                        dalProd.excluirProduto(prod.Id);
                        string msg = "<script> alert('Produto Excluído!'); </script>";
                        Response.Write(msg);

                    }
                }
                if (Request.QueryString["PRODUTO_E"] != null)
                {

                    rParametro = int.Parse(Criptografia.Decrypt(Request.QueryString["CLIENTE_E"]));

                    Produto prod = dalProd.buscarProdutoId(rParametro);
                   
                   
                    txtNomeE.Text = prod.Nome;
                    txtDescricaoE.Text = prod.Descricao;
                    txtPrecoE.Text = prod.Preco.ToString();
                    ddlTipoProdE.SelectedValue = prod.Tipo.ToString();
                    mdProdE.Visible = true;
                }             
            }

        }

        #region Controle Produto

        private void carregarTabela(int Tipo)
        {
            DataTable rDta = new DataTable();
            rDta = dalProd.buscarTodosProdutosTipo(Tipo);
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("<table id='example' class='display' style='width: 100% font-size:15px;'>");
            sb.AppendLine("<thead>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th><center>ID</th></center>");
            sb.AppendLine("<th><center>NOME</th></center>");
            sb.AppendLine("<th><center>DESCRICAO</th></center>");
            sb.AppendLine("<th><center>PRECO</th></center>");
            sb.AppendLine("<th><center>FOTO</th></center>");
            sb.AppendLine("<th><center>TIPO</th></center>");
            sb.AppendLine("<th><center>EDITAR</th></center>");
            sb.AppendLine("<th><center>EXCLUIR</th></center>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");
            sb.AppendLine("<tbody>");

            foreach (DataRow dtr in rDta.Rows)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<td><center>" + dtr["ID"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["NOME"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["DESCRICAO"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["PRECO"] + "</td></center>");
                sb.AppendLine("<td><center>" + dtr["FOTO"] + "</td></center>");
                sb.AppendLine("<td><center><a href='ControleUsuario.aspx?PRODUTO_E=" + Criptografia.Encrypt(dtr["ID"].ToString()) + "'><i class='fa fa-edit'></i></center></td>");
                sb.AppendLine("<td><center><a href='ControleUsuario.aspx?PRODUTO_D=" + Criptografia.Encrypt(dtr["ID"].ToString()) + "'><i class='fa fa-trash'></i></center></td>");
                sb.AppendLine("</tr>");

            }
            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");

            Panel1.Controls.Clear();
            Panel1.Controls.Add(new LiteralControl(sb.ToString()));

        }

        protected void lnkSalvarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                string caminho = Server.MapPath(@"IMAGENS\PRODUTOS\");
                DALProduto dalProd = new DALProduto();
                Produto prod = new Produto();
                prod.Nome = txtNome.Text;
                prod.Descricao = txtDescricao.Text;
                prod.Preco = decimal.Parse(txtPreco.Text);
                prod.Preco = decimal.Parse(txtPreco.Text);
                //faz o upload da foto e salva o nome no obj
                if (!string.IsNullOrEmpty(fuProduto.PostedFile.FileName))
                {
                    prod.Foto = DateTime.Now.Millisecond.ToString() + fuProduto.PostedFile.FileName;
                    string img = caminho + prod.Foto;
                    fuProduto.PostedFile.SaveAs(img);
                }

                {
                    dalProd.inserirProduto(prod);
                    msg = $"<script> alert('O código gerado foi: {prod.Id}'); </script>";

                }
                //Response.Write(msg);
                PlaceHolder1.Controls.Add(new LiteralControl(msg));
                limparCampos();
            }

            catch (Exception erro)
            {
                string msg1 = $"<script> ShowMsg({erro.Message}'); </script>";
                PlaceHolder1.Controls.Add(new LiteralControl(msg1));
            }

        }




        #endregion



        private void limparCampos()
        {
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtPreco.Text ="";
            ddlTipo.SelectedIndex = -1;    
        }

        protected void lnkSenha_Click(object sender, EventArgs e)
        {

        }

        protected void lnkVoltar_Click(object sender, EventArgs e)
        {
            mdBack.Visible = false;
            mdProd.Visible = false;
            mdProdE.Visible = false;
            limparCampos();
        }

        protected void lnkSalvarProdutoE_Click(object sender, EventArgs e)
        {

            try
            {
                string msg = "";
                string caminho = Server.MapPath(@"IMAGENS\PRODUTOS\");
                DALProduto dalProd = new DALProduto();
                Produto prod = new Produto();
                prod.Nome = txtNome.Text;
                prod.Descricao = txtDescricao.Text;
                prod.Preco = decimal.Parse(txtPreco.Text);
                prod.Preco = decimal.Parse(txtPreco.Text);
                //faz o upload da foto e salva o nome no obj
                if (!string.IsNullOrEmpty(fuProduto.PostedFile.FileName))
                {
                    prod.Foto = DateTime.Now.Millisecond.ToString() + fuProduto.PostedFile.FileName;
                    string img = caminho + prod.Foto;
                    fuProduto.PostedFile.SaveAs(img);
                }

                {
                    dalProd.alterarProduto(prod);
                    msg = $"<script> alert('O Produto Alterado: {prod.Id}'); </script>";

                }
                //Response.Write(msg);
                PlaceHolder1.Controls.Add(new LiteralControl(msg));
                limparCampos();
            }

            catch (Exception erro)
            {
                string msg1 = $"<script> ShowMsg({erro.Message}'); </script>";
                PlaceHolder1.Controls.Add(new LiteralControl(msg1));
            }

        }

        protected void novoProduto_Click(object sender, EventArgs e)
        {
            mdProd.Visible = true;
           
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipo.Text != "SELECIONE")
            {
                    carregarTabela(int.Parse(ddlTipo.SelectedValue));              
            }
        }

       


    }
}

