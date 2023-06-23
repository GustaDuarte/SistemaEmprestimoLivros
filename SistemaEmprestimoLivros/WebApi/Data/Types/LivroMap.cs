using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poo_AS.Domain.Entities;

namespace Poo_AS.Data.Types
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("livros");

            builder.Property(i => i.Id).HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Titulo)
                .HasColumnName("titulo")
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(i => i.UsuarioId)
                .HasColumnName("usuarioId")
                .HasColumnType("INTEGER")
                .IsRequired();
                
            builder.HasMany(l => l.Autores)
                .WithOne(a => a.Livro)
                .HasForeignKey(a => a.LivroId)
                .HasConstraintName("FK_Livro_Autores")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}