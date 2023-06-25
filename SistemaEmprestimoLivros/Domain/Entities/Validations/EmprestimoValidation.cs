using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Domain.Entities.Validations.ValidationDocuments
{
    public class EmprestimoValidation : AbstractValidator<Emprestimo>
    {
        public EmprestimoValidation()
        {
            RuleFor(e => e.LivroId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            
            RuleFor(e => e.UsuarioId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}