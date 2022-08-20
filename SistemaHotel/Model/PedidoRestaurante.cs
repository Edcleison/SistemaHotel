using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SistemaHotel.Model
{
    public class PedidoRestaurante
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public DateTime Data { get; set; }
        public float Valor { get; set; }
        public enum  Status { Aberto ='A',Recusado = 'R',Finalizado ='F'}
    }
}