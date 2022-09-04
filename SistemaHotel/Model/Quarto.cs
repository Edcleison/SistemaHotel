using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Model
{
    public class Quarto
    {
       
        public int IdQuarto { get; set; }
        public string DescricaoQuarto { get; set; }

        public Quarto()
        {
            this.IdQuarto = 0;
            this.DescricaoQuarto = "";
        }

    }
}