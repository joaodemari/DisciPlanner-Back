using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd_DisciPlanner.DTOs;
using BackEnd_DisciPlanner.Entities;
using BackEnd_DisciPlanner.Enums;
using BackEnd_DisciPlanner.Repositories.Interfaces;

namespace BackEnd_DisciPlanner.Services
{
    public class GetGradeByAlunoService
    {
        private IGradeRepository Repository { get; set; }

        public GetGradeByAlunoService(IGradeRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<GradeByAlunoResponseDTO> GetGradeByAluno(int alunoId)
        {
            var grade =
                await Repository.GetGradeByAluno(alunoId) ?? throw new Exception("Grade not found");

            Console.WriteLine("Grade: " + grade.Id);
            Console.WriteLine("Aluno: " + grade.Aluno.Nome);

            var Creditos = grade.Turmas.Sum(t => t.Disciplina.Creditos);

            var Nome_Aluno = grade.Aluno.Nome;

            Console.WriteLine(grade.Turmas.Count);

            grade.Turmas = grade
                .Turmas.Where(t => t.Periodos.Count > 0)
                .OrderBy(T => T.Periodos.Min(p => p.Horario.HorarioInicio))
                .ToList();

            var LinhasPeriodos = new Dictionary<string, LinhaPeriodoDTO>();

            var BlocosTurma = new Dictionary<string, Dictionary<DiaSemana, BlocoTurmaDTO>>();

            for (int i = 0; i < grade.Turmas.Count; i++)
            {
                var Turma = grade.Turmas[i];

                for (int j = 0; j < Turma.Periodos.Count; j++)
                {
                    var Periodo = Turma.Periodos[j];

                    if (!LinhasPeriodos.ContainsKey(Periodo.Horario.Label))
                    {
                        LinhasPeriodos[Periodo.Horario.Label] = new LinhaPeriodoDTO
                        {
                            Posicao_Linha = LinhasPeriodos.Count + 1,
                            Label = Periodo.Horario.Label,
                            CustomizedLabel = Periodo.Horario.CustomizedLabel,
                        };
                    }

                    var LinhaPeriodo = LinhasPeriodos[Periodo.Horario.Label];

                    if (!BlocosTurma.ContainsKey(Turma.Disciplina.Nome))
                    {
                        BlocosTurma[Turma.Disciplina.Nome] =
                            new Dictionary<DiaSemana, BlocoTurmaDTO>();
                    }

                    var BlocoTurma = BlocosTurma[Turma.Disciplina.Nome];

                    if (!BlocoTurma.ContainsKey(Periodo.DiaDaSemana))
                    {
                        BlocoTurma[Periodo.DiaDaSemana] = new BlocoTurmaDTO
                        {
                            Numero_Turma = Turma.NumeroDaTurma,
                            Nome_Disciplina = Turma.Disciplina.Nome,
                            Linha_Comeco = LinhaPeriodo.Posicao_Linha,
                            Linha_Fim = LinhaPeriodo.Posicao_Linha,
                            Dia_Semana = Periodo.DiaDaSemana,
                        };
                    }
                    else
                    {
                        var Bloco = BlocoTurma[Periodo.DiaDaSemana];
                        Bloco.Linha_Fim = LinhaPeriodo.Posicao_Linha;
                    }
                }
            }

            GradeByAlunoResponseDTO result =
                new()
                {
                    AlunoId = alunoId,
                    Creditos = Creditos,
                    Nome_Aluno = Nome_Aluno,
                    BlocosTurma = BlocosTurma
                        .SelectMany(bt => bt.Value.Select(bt2 => bt2.Value))
                        .ToList(),
                    PeriodosFaculdade = LinhasPeriodos.Values.ToList()
                };
            return result;
        }

        public void PopulateDB()
        {
            Repository.PopulateDB();
        }
    }
}
