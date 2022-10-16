using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Model
{
    public class Cliente
    {

        public int IdCliente { get; set; }
        public int IdQuarto { get; set; }
        public string CodReserva { get; set; }
        public string NomeCliente { get; set; }
        public string SobreNomeCliente { get; set; }
        public DateTime  DataEntrada { get; set; }
        public DateTime  DataSaida { get; set; }
        public char  FlagPedidoFrigobar { get; set; }

        public Cliente()
        {
            this.IdCliente = 0;
            this.IdQuarto = 0;
            this.CodReserva = "";
            this.NomeCliente = "";
            this.SobreNomeCliente = "";
           
            this.DataEntrada = DateTime.Now;
            this.DataSaida = DateTime.Now;
            this.FlagPedidoFrigobar = 'P';
        }

    }
}