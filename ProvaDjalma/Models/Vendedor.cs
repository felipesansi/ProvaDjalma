using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvaDjalma.Models
{
    public class Vendedor
    {
        public int Id{ get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public bool Excluido { get; set; }
    }
}