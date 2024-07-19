using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd_DisciPlanner.Entities;
using BackEnd_DisciPlanner.Enums;

namespace BackEnd_DisciPlanner.DTOs
{
    public class GradeByAlunoResponseDTO
    {
        public int Creditos { get; set; }
        public int AlunoId { get; set; }
        public string Nome_Aluno { get; set; } = null!;
        public List<BlocoTurmaDTO> BlocosTurma { get; set; } = new List<BlocoTurmaDTO>();
        public List<LinhaPeriodoDTO> PeriodosFaculdade { get; set; } = new List<LinhaPeriodoDTO>();
    }

    public class LinhaPeriodoDTO
    {
        public int Posicao_Linha { get; set; }
        public string Label { get; set; } = null!;
        public string? CustomizedLabel { get; set; }
    }

    public class BlocoTurmaDTO
    {
        public int Numero_Turma { get; set; }
        public string Nome_Disciplina { get; set; } = null!;
        public int Linha_Comeco { get; set; }
        public int Linha_Fim { get; set; }
        public DiaSemana Dia_Semana { get; set; }
    }
}
