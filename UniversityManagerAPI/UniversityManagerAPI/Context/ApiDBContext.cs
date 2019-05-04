using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagerAPI.Models;

namespace UniversityManagerAPI.Context
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<TipoTelefone> TiposTelefones { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CargaHoraria> CargasHorarias { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<CargaHoraria>()
                .HasData(
                    new CargaHoraria() { Id = 1, QuantidadeHoras = 20, CustoBase = 200.00 },
                    new CargaHoraria() { Id = 2, QuantidadeHoras = 40, CustoBase = 350.00 },
                    new CargaHoraria() { Id = 3, QuantidadeHoras = 60, CustoBase = 500.00 },
                    new CargaHoraria() { Id = 4, QuantidadeHoras = 80, CustoBase = 650.00 }                
                );

            modelBuilder.Entity<CursoDisciplina>()
                .HasKey(x => new { x.CursoId, x.DisciplinaId });
        }
    }
}
