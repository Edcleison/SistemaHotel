using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Model
{
    public class PerfilUsuario
    {

        public int IdPerfilUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public char StatusPerfilUsuario { get; set; }

        public PerfilUsuario()
        {
            this.IdPerfilUsuario = 0;
            this.IdUsuario = 0;        
            this.IdPerfil = 0;
            this.StatusPerfilUsuario = 'P';
        }


    }
}