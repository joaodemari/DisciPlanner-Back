using BackEnd_DisciPlanner.Entities;
using BackEnd_DisciPlanner.Enums;

namespace BackEnd_DisciPlanner
{
    public class Periodo : BaseEntity
    {
        public DiaSemana DiaDaSemana { get; set; }
        public Horario Horario { get; set; } = null!;
        public int HorarioId { get; set; }
    }
}
