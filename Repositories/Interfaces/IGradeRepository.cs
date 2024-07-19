using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd_DisciPlanner.Entities;

namespace BackEnd_DisciPlanner.Repositories.Interfaces
{
    public interface IGradeRepository : IBaseRepository<Grade>
    {
        public void PopulateDB();
        public Task<Grade?> GetGradeByAluno(int alunoId);
    }
}
