using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_DisciPlanner.Entities
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<Grade> Grades { get; set; } = new();
    }
}
