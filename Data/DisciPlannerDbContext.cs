using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd_DisciPlanner.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_DisciPlanner.Data
{
    public class DisciPlannerDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; } = null!;
        public DbSet<Grade> Grades { get; set; } = null!;
        public DbSet<Faculdade> Faculdades { get; set; } = null!;
        public DbSet<Disciplina> Disciplinas { get; set; } = null!;
        public DbSet<Periodo> Periodos { get; set; } = null!;
        public DbSet<Semestre> Semestres { get; set; } = null!;
        public DbSet<Turma> Turmas { get; set; } = null!;
        public DbSet<Horario> Horarios { get; set; } = null!;

        public DisciPlannerDbContext(DbContextOptions<DisciPlannerDbContext> options)
            : base(options) { }
    }
}
