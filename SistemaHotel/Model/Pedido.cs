using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SistemaHotel.Model
{
    public class Pedido
    {
       

        public int IdPedido { get; set; }
        public int IdStatus { get; set; }
        public int IdCliente { get; set; }
        public int IdAdm { get; set; }
        public int IdFuncionario { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFinalizacao { get; set; }

        public Pedido()
        {
            IdPedido = 0;
            IdStatus = 0;
            IdCliente = 0;           
            ValorTotal = 0;
            DataAbertura = DateTime.Now;
            DataFinalizacao = DateTime.Now;
        }
    }

   
}