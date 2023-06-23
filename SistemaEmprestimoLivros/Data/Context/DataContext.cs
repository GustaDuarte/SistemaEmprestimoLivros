using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Poo_AS.Data.Types;
using Poo_AS.Domain.Entities;
using WebApi.Data.Types;
using WebApi.Domain.Entities;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Autor> DbSetAutor { get; set; }
        public DbSet<Livro> DbSetLivro { get; set; }
        public DbSet<Usuario> DbSetUsuario { get; set; }
        public DbSet<Emprestimo> DbSetEmprestimo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutorMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EmprestimoMap());
        }
    }
}