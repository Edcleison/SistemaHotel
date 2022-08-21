using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SistemaHotel.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Foto { get; set; }
        public int Tipo { get; set; }

        public Produto()
        {
            Id = 0;
            Nome = "";
            Descricao = "";
            Preco = 0;
            Foto = "";
            Tipo = 0;
        }
    }
}