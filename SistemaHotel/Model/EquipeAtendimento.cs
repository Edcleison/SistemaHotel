using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Model
{
    public class ItemPedido
    {
       
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int IdCliente { get; set; }
        public int Quantidade { get; set; }
        public string DescricaoProduto { get; set; }
        public string NomeProduto { get; set; }

        public ItemPedido()
        {
            this.IdPedido = 0;
            this.IdProduto = 0;
            this.IdCliente = 0;
            this.DescricaoProduto = "";
            this.NomeProduto = "";
        }

    }
}