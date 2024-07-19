using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_DisciPlanner.Entities
{
    public class Faculdade : BaseEntity
    {
        public int Nome { get; set; }
        public List<Disciplina> Disciplinas { get; set; } = new();
        public List<Periodo> Periodos { get; set; } = new();
    }
}
