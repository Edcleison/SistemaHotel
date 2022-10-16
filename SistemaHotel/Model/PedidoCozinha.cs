using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SistemaHotel.Model
{
    public class PedidoCozinha : Pedido
    {

        public int IdAdm { get; set; }
        public int IdFuncionario { get; set; }
        
        public PedidoCozinha()
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