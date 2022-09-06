using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Model
{
    public class Carrinho
    {
       
        public int IdCarrinho { get; set; }
        public int IdProduto { get; set; }
        public int IdCliente { get; set; }
        public int Quantidade { get; set; }
      
        public Carrinho()
        {
            this.IdCarrinho = 0;
            this.IdProduto = 0;
            this.IdCliente = 0;          
        }

    }
}