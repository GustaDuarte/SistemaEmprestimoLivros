using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poo_AS.Domain.Entities;

namespace Poo_AS.Domain.DTOs
{
    public class LivroDTO
    {             
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public List<AutorDTO> Autores { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}