using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poo_AS.Domain.Entities;

namespace Poo_AS.Data.Types
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {       
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");

            builder.Property(i => i.Id).HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
                .HasColumnName("nome")
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.HasMany(u => u.LivrosEmprestados)
                .WithOne(l => l.Usuario)
                .HasForeignKey(l => l.UsuarioId)
                .HasConstraintName("FK_Usuario_Empresta_Livros")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}