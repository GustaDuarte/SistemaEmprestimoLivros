using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces.RepositoryInterfaces;

namespace WebApi.Data.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly DataContext _context;

        public EmprestimoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IList<Emprestimo>> GetAllAsync()
        {
            return await _context.DbSetEmprestimo.ToListAsync();
        }
        
        public async Task<Emprestimo> GetByIdAsync(int entityId)
        {
            return await _context.DbSetEmprestimo
                .FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public void Save(Emprestimo entity)
        {
            _context.DbSetEmprestimo.Add(entity);
        }

        public async Task<IList<Emprestimo>> SearchAll(Expression<Func<Emprestimo, bool>> predicate)
        {
            return await _context.DbSetEmprestimo.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Update(Emprestimo entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public bool Delete(int entityId)
        {
            var emprestimo = _context.DbSetEmprestimo.FirstOrDefault(x => x.Id == entityId);

            if (emprestimo == null)
                return false;
            else
            {
                _context.DbSetEmprestimo.Remove(emprestimo);
                return true;
            }

        }

        public async Task<bool> IsLivroDisponivel(int livroId)
        {
            var emprestimo = await _context.DbSetEmprestimo
                .FirstOrDefaultAsync(e => e.LivroId == livroId && e.DataDevolucao == null);

            return emprestimo == null;
        }

        public async Task<Emprestimo> GetEmprestimoAtivoPorLivro(int livroId)
        {
            return await _context.DbSetEmprestimo
                .FirstOrDefaultAsync(e => e.LivroId == livroId && e.DataDevolucao == null);
        }

        public async Task<Emprestimo> GetEmprestimoAtivoPorUsuario(int usuarioId)
        {
            return await _context.DbSetEmprestimo
                .FirstOrDefaultAsync(e => e.UsuarioId == usuarioId && e.DataDevolucao == null);
        }

        public async Task<IList<Emprestimo>> GetEmprestimosAtivosPorUsuario(int usuarioId)
        {
            return await _context.DbSetEmprestimo
                .Where(e => e.UsuarioId == usuarioId && e.DataDevolucao == null)
                .ToListAsync();
        }

        public async Task<IList<Emprestimo>> GetEmprestimosAtivosPorLivro(int livroId)
        {
            return await _context.DbSetEmprestimo
                .Where(e => e.LivroId == livroId && e.DataDevolucao == null)
                .ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}