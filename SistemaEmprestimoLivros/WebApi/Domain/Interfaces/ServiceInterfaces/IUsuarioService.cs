using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poo_AS.Domain.Entities;

namespace Poo_AS.Domain.Interfaces.ServiceInterfaces
{
    public interface IUsuarioService : IDisposable
    {
        Task<bool> Add(Usuario usuario);
        Task<bool> Update(Usuario usuario);
        Task<bool> Remove(int id);

        Task<bool> UpdateLivro(Livro livro);
    }
}