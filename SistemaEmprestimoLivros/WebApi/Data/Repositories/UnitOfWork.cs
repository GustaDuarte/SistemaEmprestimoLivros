using Data.Context;
using Domain.Interfaces;
using Poo_AS.Data.Repositories;
using Poo_AS.Domain.Entities.Interfaces;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
        private IAutorRepository _AutorRepository;
        private ILivroRepository _LivroRepository;
        private IUsuarioRepository _UsuarioRepository;



        public IAutorRepository AutorRepository
        {
            get { return _AutorRepository ??= new AutorRepository(_context); }
        }
        public ILivroRepository LivroRepository
        {
            get { return _LivroRepository ??= new LivroRepository(_context); }
        }
        public IUsuarioRepository UsuarioRepository
        {
            get { return _UsuarioRepository ??= new UsuarioRepository(_context); }
        }

    }
}