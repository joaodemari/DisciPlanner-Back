using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd_DisciPlanner.Data;
using BackEnd_DisciPlanner.Entities;
using BackEnd_DisciPlanner.Enums;
using BackEnd_DisciPlanner.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_DisciPlanner.Repositories.Implementations
{
    public class GradeRepository : BaseRepository<Grade>, IGradeRepository
    {
        public GradeRepository(DisciPlannerDbContext context)
            : base(context) { }

        public async Task<Grade?> GetGradeByAluno(int alunoId)
        {
            var grade = await context
                .Grades.Include(g => g.Turmas)
                .ThenInclude(t => t.Periodos)
                .ThenInclude(p => p.Horario)
                .Include(g => g.Turmas)
                .ThenInclude(t => t.Disciplina)
                .Include(g => g.Aluno)
                .FirstOrDefaultAsync(g => g.AlunoId == alunoId);

            Console.WriteLine("grade: " + grade);
            if (grade == null)
            {
                return null;
            }

            return grade;
        }

        public void PopulateDB()
        {
            var aluno = new Aluno
            {
                Id = 1,
                Nome = "João Pedro Tiellet Demari",
                Email = "joaodemari1@gmail.com"
            };

            context.Alunos.Add(aluno);

            var semestre = new Semestre { Id = 1, SemestreLabel = "2024/2" };

            context.Semestres.Add(semestre);

            var disciplinas = new List<Disciplina>
            {
                new()
                {
                    Id = 1,
                    Nome = "Aprendizado De Máquina",
                    Creditos = 4
                },
                new()
                {
                    Id = 2,
                    Nome = "Projeto E Otimização De Algoritmos",
                    Creditos = 4
                },
                new()
                {
                    Id = 3,
                    Nome = "Linguagens De Programação",
                    Creditos = 4
                },
                new()
                {
                    Id = 4,
                    Nome = "Fundamentos De Processamento Paralelo E Distribuído",
                    Creditos = 4
                },
                new()
                {
                    Id = 5,
                    Nome = "Verificação E Validação De Software",
                    Creditos = 4
                }
            };

            context.Disciplinas.AddRange(disciplinas);

            var horarios = new List<Horario>
            {
                new()
                {
                    Label = "17:30 - 18:15",
                    CustomizedLabel = "J",
                    HorarioFim = 18 * 60 + 15,
                    HorarioInicio = 17 * 60 + 30
                },
                new()
                {
                    Label = "18:15 - 19:00",
                    CustomizedLabel = "K",
                    HorarioFim = 19 * 60,
                    HorarioInicio = 18 * 60 + 15
                },
                new()
                {
                    Label = "19:15 - 20:00",
                    CustomizedLabel = "L",
                    HorarioFim = 20 * 60,
                    HorarioInicio = 19 * 60 + 15
                },
                new()
                {
                    Label = "20:00 - 20:45",
                    CustomizedLabel = "M",
                    HorarioFim = 20 * 60 + 45,
                    HorarioInicio = 20 * 60
                },
                new()
                {
                    Label = "20:45 - 21:30",
                    CustomizedLabel = "N",
                    HorarioFim = 21 * 60 + 30,
                    HorarioInicio = 20 * 60 + 45
                },
                new()
                {
                    Label = "21:30 - 22:15",
                    CustomizedLabel = "P",
                    HorarioFim = 22 * 60 + 15,
                    HorarioInicio = 21 * 60 + 30
                },
            };

            context.Horarios.AddRange(horarios);

            var DiaDaSemana = new List<Enums.DiaSemana>
            {
                DiaSemana.Segunda,
                DiaSemana.Terca,
                DiaSemana.Quarta,
                DiaSemana.Quinta,
                DiaSemana.Sexta,
                DiaSemana.Sabado
            };

            var periodos = new List<Periodo>();
            for (int i = 0; i < DiaDaSemana.Count; i++)
            {
                for (int j = 0; j < horarios.Count; j++)
                {
                    periodos.Add(
                        new Periodo { DiaDaSemana = DiaDaSemana[i], Horario = horarios[j], }
                    );
                }
            }

            context.Periodos.AddRange(periodos);

            var turmas = new List<Turma>
            {
                new()
                {
                    Id = 1,
                    NumeroDaTurma = 30,
                    Semestre = semestre,
                    Disciplina = disciplinas
                        .Where(d => d.Nome == "Aprendizado De Máquina")
                        .FirstOrDefault()!,
                    Periodos = FindPeriodos(
                        periodos,
                        new List<DiaSemana> { DiaSemana.Terca, DiaSemana.Quinta },
                        new List<string> { "J", "K" }
                    )
                },
                new()
                {
                    Id = 2,
                    NumeroDaTurma = 31,
                    Semestre = semestre,
                    Disciplina = disciplinas
                        .Where(d => d.Nome == "Projeto E Otimização De Algoritmos")
                        .FirstOrDefault()!,
                    Periodos = FindPeriodos(
                        periodos,
                        new List<DiaSemana> { DiaSemana.Segunda, DiaSemana.Quarta },
                        new List<string> { "L", "M" }
                    )
                },
                new()
                {
                    Id = 3,
                    NumeroDaTurma = 30,
                    Semestre = semestre,
                    Disciplina = disciplinas
                        .Where(d => d.Nome == "Linguagens De Programação")
                        .FirstOrDefault()!,
                    Periodos = FindPeriodos(
                        periodos,
                        new List<DiaSemana> { DiaSemana.Terca, DiaSemana.Quinta },
                        new List<string> { "L", "M" }
                    )
                },
                new()
                {
                    Id = 4,
                    NumeroDaTurma = 33,
                    Semestre = semestre,
                    Disciplina = disciplinas
                        .Where(d => d.Nome == "Fundamentos De Processamento Paralelo E Distribuído")
                        .FirstOrDefault()!,
                    Periodos = FindPeriodos(
                        periodos,
                        new List<DiaSemana> { DiaSemana.Segunda, DiaSemana.Quarta },
                        new List<string> { "N", "P" }
                    )
                },
                new()
                {
                    Id = 5,
                    NumeroDaTurma = 30,
                    Semestre = semestre,
                    Disciplina = disciplinas
                        .Where(d => d.Nome == "Verificação E Validação De Software")
                        .FirstOrDefault()!,
                    Periodos = FindPeriodos(
                        periodos,
                        new List<DiaSemana> { DiaSemana.Terca, DiaSemana.Quinta },
                        new List<string> { "N", "P" }
                    )
                }
            };

            context.Turmas.AddRange(turmas);

            var grade = new Grade
            {
                Aluno = aluno,
                Semestre = semestre,
                Turmas = turmas
            };

            context.Grades.Add(grade);
            context.SaveChangesAsync();
        }

        public List<Periodo> FindPeriodos(
            List<Periodo> periodos,
            List<DiaSemana> diaSemana,
            List<string> horariosLabel
        )
        {
            return periodos
                .Where(p =>
                    diaSemana.Contains(p.DiaDaSemana)
                    && horariosLabel.Contains(p.Horario.CustomizedLabel!)
                )
                .ToList();
        }
    }
}
