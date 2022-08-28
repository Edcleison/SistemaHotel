using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SistemaHotel.Model
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public int TipoProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public string DescricaoProduto { get; set; }
        public string NomeProduto { get; set; }     
        public string FotoProduto { get; set; }
        

        public Produto()
        {
            IdProduto = 0;
            TipoProduto = 0;
            PrecoUnitario = 0;
            DescricaoProduto = "";
            NomeProduto = "";
            FotoProduto = "";
            
        }
    }
}