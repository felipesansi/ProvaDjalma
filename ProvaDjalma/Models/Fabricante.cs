using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvaDjalma.Models
{
    public class Fabricante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Fundacao { get; set; }
        public string Sede { get; set; }
        public bool Excluido{ get; set; }
    }
}