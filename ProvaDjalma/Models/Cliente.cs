using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvaDjalma.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Datanasc { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Vendedor { get; set; }
        public bool Excluido { get; set; }

    }
}