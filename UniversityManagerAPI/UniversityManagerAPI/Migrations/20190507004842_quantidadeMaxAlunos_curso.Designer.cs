﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityManagerAPI.Context;

namespace UniversityManagerAPI.Migrations
{
    [DbContext(typeof(ApiDBContext))]
    [Migration("20190507004842_quantidadeMaxAlunos_curso")]
    partial class quantidadeMaxAlunos_curso
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UniversityManagerAPI.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursoId");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<int>("RegistroMatricula");

                    b.Property<string>("Sobrenome");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("UniversityManagerAPI.Models.CargaHoraria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CustoBase");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<int>("QuantidadeHoras");

                    b.HasKey("Id");

                    b.ToTable("CargasHorarias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustoBase = 200.0,
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            QuantidadeHoras = 20
                        },
                        new
                        {
                            Id = 2,
                            CustoBase = 350.0,
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            QuantidadeHoras = 40
                        },
                        new
                        {
                            Id = 3,
                            CustoBase = 500.0,
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            QuantidadeHoras = 60
                        },
                        new
                        {
                            Id = 4,
                            CustoBase = 650.0,
                            DataCadastro = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            QuantidadeHoras = 80
                        });
                });

            modelBuilder.Entity("UniversityManagerAPI.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.Property<int>("QuantidadeMaximaAlunos");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("UniversityManagerAPI.Models.CursoDisciplina", b =>
                {
                    b.Property<int>("CursoId");

                    b.Property<int>("DisciplinaId");

                    b.HasKey("CursoId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("CursoDisciplina");
                });

            modelBuilder.Entity("UniversityManagerAPI.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CargaHorariaId");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("CargaHorariaId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("UniversityManagerAPI.Models.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlunoId");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<int>("Numero");

                    b.Property<int?>("TipoId");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("TipoId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("UniversityManagerAPI.Models.TipoTelefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<bool>("IsCelular");

                    b.Property<bool>("IsFixo");

                    b.HasKey("Id");

                    b.ToTable("TiposTelefones");
                });

            modelBuilder.Entity("UniversityManagerAPI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Email");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("UniversityManagerAPI.Models.Aluno", b =>
                {
                    b.HasOne("UniversityManagerAPI.Models.Curso", "Curso")
                        .WithMany("Alunos")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UniversityManagerAPI.Models.Usuario", "Usuario")
                        .WithOne("Aluno")
                        .HasForeignKey("UniversityManagerAPI.Models.Aluno", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagerAPI.Models.CursoDisciplina", b =>
                {
                    b.HasOne("UniversityManagerAPI.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UniversityManagerAPI.Models.Disciplina", "Disciplina")
                        .WithMany("CursosLink")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagerAPI.Models.Disciplina", b =>
                {
                    b.HasOne("UniversityManagerAPI.Models.CargaHoraria", "CargaHoraria")
                        .WithMany()
                        .HasForeignKey("CargaHorariaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagerAPI.Models.Telefone", b =>
                {
                    b.HasOne("UniversityManagerAPI.Models.Aluno", "Aluno")
                        .WithMany("Telefones")
                        .HasForeignKey("AlunoId");

                    b.HasOne("UniversityManagerAPI.Models.TipoTelefone", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId");
                });
#pragma warning restore 612, 618
        }
    }
}
