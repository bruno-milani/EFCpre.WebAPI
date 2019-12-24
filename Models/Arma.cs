﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCpre.WebAPI.Models
{
    public class Arma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int HeroiId { get; set; }
        public Heroi Heroi { get; set; }        
    }
}
