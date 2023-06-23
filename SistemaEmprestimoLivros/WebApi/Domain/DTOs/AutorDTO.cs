using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poo_AS.Domain.Entities;

namespace Poo_AS.Domain.DTOs
{
    public class AutorDTO
    {
        public int Id { get; set; }
        public int LivroId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public LivroDTO Livro { get; set; }
    }
}