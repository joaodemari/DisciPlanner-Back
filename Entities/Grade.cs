using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_DisciPlanner.Entities
{
    public class Grade : BaseEntity
    {
        public Aluno Aluno { get; set; } = null!;
        public int AlunoId { get; set; }
        public int SemestreId { get; set; }
        public Semestre Semestre { get; set; } = null!;
        public List<Turma> Turmas { get; set; } = new();
    }
}
