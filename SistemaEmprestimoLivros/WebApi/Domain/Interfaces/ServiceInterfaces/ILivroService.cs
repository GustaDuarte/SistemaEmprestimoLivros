using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poo_AS.Domain.Entities;

namespace Poo_AS.Domain.Interfaces.ServiceInterfaces
{
    public interface ILivroService : IDisposable
    {
        Task<bool> Add(Livro livro);
        Task<bool> Update(Livro livro);
        Task<bool> Remove(int id);

        Task<bool> UpdateAutor(Autor autor);
    }
}