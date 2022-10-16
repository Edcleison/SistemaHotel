using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Model
{
    public class Administracao : Membro
    {

        public int IdAdm { get; set; }

        public Administracao()
        {
            this.IdAdm = 0;
            this.IdUsuario = 0;
            this.IdPerfil = 0;   
        }

    }
}