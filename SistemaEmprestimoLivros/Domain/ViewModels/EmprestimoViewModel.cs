using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain.ViewModels
{
    public class EmprestimoViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int LivroId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int UsuarioId { get; set; }
    }
}