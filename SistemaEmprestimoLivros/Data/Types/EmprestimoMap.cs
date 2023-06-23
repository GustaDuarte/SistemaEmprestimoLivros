using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Entities;

namespace WebApi.Data.Types
{
    public class EmprestimoMap: IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("emprestimos");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.DataEmprestimo)
                .HasColumnName("data_emprestimo")
                .IsRequired();

            builder.Property(e => e.DataDevolucao)
                .HasColumnName("data_devolucao");

            // 1 : 1 => Emprestimo : Usuario
            builder.HasOne(i => i.Usuario)
                .WithOne(u => u.Emprestimo)
                .OnDelete(DeleteBehavior.Restrict);

            // 1 : 1 => Emprestimo : Usuario
            builder.HasOne(i => i.Livro)
                .WithOne(u => u.Emprestimo)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}