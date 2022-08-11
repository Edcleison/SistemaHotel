using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Model
{
    public class PerfilUsuario
    {
  
        public int Id { get; set; }
        public int Perfil { get; set; }
        public char Ativo { get; set; }
        public int ID_USUARIO { get; set; }

        public PerfilUsuario()
        {
            this.Id = 0;
            this.Perfil = 0;        
            this.Ativo = 'P';
            this.ID_USUARIO = 0;
        }


    }
}