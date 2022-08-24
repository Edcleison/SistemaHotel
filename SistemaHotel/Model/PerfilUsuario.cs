using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Model
{
    public class PerfilUsuario
    {
        internal int ID_USUARIO;

        public int Id { get; set; }
        public int Perfil { get; set; }
        public char Ativo { get; set; }
        public int IdUsuario { get; set; }

        public PerfilUsuario()
        {
            this.Id = 0;
            this.Perfil = 0;        
            this.Ativo = 'P';
            this.IdUsuario = 0;
        }


    }
}