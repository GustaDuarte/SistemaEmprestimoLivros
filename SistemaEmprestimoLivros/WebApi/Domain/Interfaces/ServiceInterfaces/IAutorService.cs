using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poo_AS.Domain.Entities;

namespace Poo_AS.Domain.Interfaces.ServiceInterfaces
{
    public interface IAutorService : IDisposable
    {
        Task<bool> Add(Autor autor);
        Task<bool> Update(Autor autor);
        Task<bool> Remove(int id);
    }
}