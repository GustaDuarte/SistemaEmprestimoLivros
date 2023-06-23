using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Poo_AS.Domain.Entities
{
    public class Livro : Entity
    {
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public List<Autor> Autores { get; set; }
        public Usuario Usuario { get; set; }
        
    }
}