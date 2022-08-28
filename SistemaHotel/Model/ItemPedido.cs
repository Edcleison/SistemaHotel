using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Model
{
    public class EquipeAtendimento
    {
       
        public int IdEquipe { get; set; }
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public string NomeUsuario { get; set; }

        public EquipeAtendimento()
        {
            this.IdEquipe = 0;
            this.IdUsuario = 0;
            this.IdPerfil = 0;
            this.NomeUsuario = "";
        }

    }
}