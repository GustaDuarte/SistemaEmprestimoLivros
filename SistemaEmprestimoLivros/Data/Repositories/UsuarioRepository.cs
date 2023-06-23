using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Poo_AS.Domain.Entities;
using Poo_AS.Domain.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Data.Context;

namespace Poo_AS.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IList<Usuario>> GetAllAsync()
        {
            return await _context.DbSetUsuario.ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(int entityId)
        {
            return await _context.DbSetUsuario
                .FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public void Save(Usuario entity)
        {
            _context.DbSetUsuario.Add(entity);
        }

        public async Task<IList<Usuario>> SearchAll(Expression<Func<Usuario, bool>> predicate)
        {
            return await _context.DbSetUsuario.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Update(Usuario entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public bool Delete(int entityId)
        {
            var usuario = _context.DbSetUsuario.FirstOrDefault(x => x.Id == entityId);

            if (usuario == null)
                return false;
            else
            {
                _context.DbSetUsuario.Remove(usuario);
                return true;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}