using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Model
{
    public class Funcionario
    {
       
        public int IdFuncionario { get; set; }
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }

        public Funcionario()
        {
            this.IdFuncionario = 0;
            this.IdUsuario = 0;
            this.IdPerfil = 0;   
        }

    }
}