using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_DisciPlanner.Entities
{
    public class Semestre : BaseEntity
    {
        public string SemestreLabel { get; set; } = null!;
        public List<Grade> Grades { get; set; } = new();
        public List<Turma> Turmas { get; set; } = new();
    }
}
