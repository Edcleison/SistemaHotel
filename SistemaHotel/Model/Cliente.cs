﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public char Ativo { get; set; }
    }
}