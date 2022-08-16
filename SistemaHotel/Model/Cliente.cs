using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Cd_Reserva { get; set; }
        public DateTime  DataInicio { get; set; }
        public DateTime  DataFim { get; set; }
        public char Ativo { get; set; }

        public Cliente()
        {
            this.Id = 0;
            this.Cd_Reserva = "";
            this.DataInicio = DateTime.Now;
            this.DataFim = DateTime.Now;
            this.Ativo = 'P';
        }
    }
}