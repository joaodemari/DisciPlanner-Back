using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_DisciPlanner.Entities
{
    public class Horario : BaseEntity
    {
        public int HorarioInicio { get; set; }
        public int HorarioFim { get; set; }
        public string Label { get; set; } = null!;
        public string? CustomizedLabel { get; set; }
        public List<Periodo> Periodos { get; set; } = new();
    }
}
