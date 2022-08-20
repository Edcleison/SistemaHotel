using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SistemaHotel.Model
{
    public class ProdutoRestaurante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public string Foto { get; set; }
        
    }
}