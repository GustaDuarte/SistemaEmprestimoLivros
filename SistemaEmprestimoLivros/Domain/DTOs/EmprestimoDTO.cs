using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poo_AS.Domain.DTOs;

namespace WebApi.Domain.DTOs
{
    public class EmprestimoDTO
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public int LivroId { get; set; }
        public LivroDTO Livro { get; set; }
    }
}