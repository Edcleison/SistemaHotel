using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Model
{
    public class Cliente
    {
       
        public int IdCliente { get; set; }
        public string CodReserva { get; set; }
        public string NomeCliente { get; set; }
        public string Quarto { get; set; }
        public DateTime  DataEntrada { get; set; }
        public DateTime  DataSaida { get; set; }

        public Cliente()
        {
            this.IdCliente = 0;
            this.CodReserva = "";
            this.NomeCliente = "";
            this.Quarto = "";
            this.DataEntrada = DateTime.Now;
            this.DataSaida = DateTime.Now;
        }

    }
}