using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Poo_AS.Domain.Entities
{
    public class Autor : Entity
    {
        public int LivroId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Livro Livro { get; set; }
    }
}