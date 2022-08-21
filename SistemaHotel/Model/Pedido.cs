using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SistemaHotel.Model
{
    public class Pedido
    {
       

        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public DateTime Data { get; set; }
        public float Valor { get; set; }
        public int Status { get; set; }
        public int Tipo { get; set; }

        public Pedido()
        {
            Id = 0;
            Id_Cliente = 0;
            Data = DateTime.Now;
            Valor = 0;
            Status = 0;
            Tipo = 0;
        }
    }

   
}