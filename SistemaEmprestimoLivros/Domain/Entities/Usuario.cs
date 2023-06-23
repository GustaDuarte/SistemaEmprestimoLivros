using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using WebApi.Domain.Entities;

namespace Poo_AS.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public List<Livro> LivrosEmprestados { get; set; }
        public Emprestimo Emprestimo { get; set; }
    }
}