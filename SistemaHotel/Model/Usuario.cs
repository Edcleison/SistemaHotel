using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Model
{
    public class Usuario
    {
       

        public int Id { get; set; }    
        public string Login { get; set; }
        public string Senha { get; set; }
        
        public Usuario()
        {
            this.Id = 0;          
            this.Login = "";
            this.Senha = "";
        }


    }
}