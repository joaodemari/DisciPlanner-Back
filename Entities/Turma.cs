using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_DisciPlanner.Entities
{
    public class Turma : BaseEntity
    {
        public int NumeroDaTurma { get; set; }
        public List<Periodo> Periodos { get; set; } = new();
        public Disciplina Disciplina { get; set; } = null!;
        public int DisciplinaId { get; set; }
        public Semestre Semestre { get; set; } = null!;
        public int SemestreId { get; set; }
        public List<Grade> Grades { get; set; } = new();
    }
}
