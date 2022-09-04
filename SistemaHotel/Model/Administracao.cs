using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Model
{
    public class Administracao
    {
       
        public int IdAdm { get; set; }
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }

        public Administracao()
        {
            this.IdAdm = 0;
            this.IdUsuario = 0;
            this.IdPerfil = 0;   
        }

    }
}