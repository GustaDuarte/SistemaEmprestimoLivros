using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Poo_AS.Domain.Entities;

namespace WebApi.Domain.Entities
{
    public class Emprestimo : Entity
    {
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
    }
}