﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230623222820_entityEmprestimoAdd")]
    partial class entityEmprestimoAdd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Poo_AS.Domain.Entities.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("LivroId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.HasIndex("LivroId");

                    b.ToTable("autores", (string)null);
                });

            modelBuilder.Entity("Poo_AS.Domain.Entities.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("titulo");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("usuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("livros", (string)null);
                });

            modelBuilder.Entity("Poo_AS.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("usuarios", (string)null);
                });

            modelBuilder.Entity("WebApi.Domain.Entities.Emprestimo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("TEXT")
                        .HasColumnName("data_devolucao");

                    b.Property<DateTime>("DataEmprestimo")
                        .HasColumnType("TEXT")
                        .HasColumnName("data_emprestimo");

                    b.Property<int>("LivroId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LivroId")
                        .IsUnique();

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("emprestimos", (string)null);
                });

            modelBuilder.Entity("Poo_AS.Domain.Entities.Autor", b =>
                {
                    b.HasOne("Poo_AS.Domain.Entities.Livro", "Livro")
                        .WithMany("Autores")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Livro_Autores");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Poo_AS.Domain.Entities.Livro", b =>
                {
                    b.HasOne("Poo_AS.Domain.Entities.Usuario", "Usuario")
                        .WithMany("LivrosEmprestados")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Usuario_Empresta_Livros");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebApi.Domain.Entities.Emprestimo", b =>
                {
                    b.HasOne("Poo_AS.Domain.Entities.Livro", "Livro")
                        .WithOne("Emprestimo")
                        .HasForeignKey("WebApi.Domain.Entities.Emprestimo", "LivroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Poo_AS.Domain.Entities.Usuario", "Usuario")
                        .WithOne("Emprestimo")
                        .HasForeignKey("WebApi.Domain.Entities.Emprestimo", "UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Poo_AS.Domain.Entities.Livro", b =>
                {
                    b.Navigation("Autores");

                    b.Navigation("Emprestimo")
                        .IsRequired();
                });

            modelBuilder.Entity("Poo_AS.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Emprestimo")
                        .IsRequired();

                    b.Navigation("LivrosEmprestados");
                });
#pragma warning restore 612, 618
        }
    }
}
