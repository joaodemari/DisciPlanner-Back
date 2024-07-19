using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_DisciPlanner.Entities
{
    public class Disciplina : BaseEntity
    {
        public string Nome { get; set; } = null!;
        public int Creditos { get; set; }
        public List<Turma> Turmas { get; set; } = new();
    }
}
