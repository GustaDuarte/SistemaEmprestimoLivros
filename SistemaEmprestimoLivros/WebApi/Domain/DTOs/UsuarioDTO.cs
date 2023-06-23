using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Poo_AS.Domain.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<LivroDTO> LivrosEmprestados { get; set; }
    }
}