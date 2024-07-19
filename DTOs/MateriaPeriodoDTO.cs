using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd_DisciPlanner.Entities;

namespace BackEnd_DisciPlanner.DTOs
{
    public class MateriaPeriodoDTO
    {
        public string NomeMaterial { get; set; } = null!;
        public int Creditos { get; set; }
    }
}