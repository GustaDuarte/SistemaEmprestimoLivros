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
    public class LivroRepository : ILivroRepository
    {
        private readonly DataContext _context;

        public LivroRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IList<Livro>> GetAllAsync()
        {
            return await _context.DbSetLivro.ToListAsync();
        }

        public async Task<Livro> GetByIdAsync(int entityId)
        {
            return await _context.DbSetLivro
                .FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public void Save(Livro entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public async Task<IList<Livro>> SearchAll(Expression<Func<Livro, bool>> predicate)
        {
            return await _context.DbSetLivro.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Update(Livro entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public bool Delete(int entityId)
        {
            var livro = _context.DbSetLivro.FirstOrDefault(x => x.Id == entityId);

            if (livro == null)
                return false;
            else
            {
                _context.DbSetLivro.Remove(livro);
                return true;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}