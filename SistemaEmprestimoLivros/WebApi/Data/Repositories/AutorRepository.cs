using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Poo_AS.Domain.Entities;
using Poo_AS.Domain.Entities.Interfaces;

namespace Poo_AS.Data.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly DataContext _context;

        public AutorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IList<Autor>> GetAllAsync()
        {
            return await _context.DbSetAutor.ToListAsync();
        }
        
        public async Task<Autor> GetByIdAsync(int entityId)
        {
            return await _context.DbSetAutor
                .FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public void Save(Autor entity)
        {
            _context.DbSetAutor.Add(entity);
        }

        public void Update(Autor entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<IList<Autor>> SearchAll(Expression<Func<Autor, bool>> predicate)
        {
            return await _context.DbSetAutor.AsNoTracking().Where(predicate).ToListAsync();
        }

        public bool Delete(int entityId)
        {
            var autor = _context.DbSetAutor.FirstOrDefault(x => x.Id == entityId);

            if (autor == null)
                return false;
            else
            {
                _context.DbSetAutor.Remove(autor);
                return true;
            }
        }
    }
}