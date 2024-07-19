using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd_DisciPlanner.Data;
using BackEnd_DisciPlanner.DTOs;
using BackEnd_DisciPlanner.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_DisciPlanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly GetGradeByAlunoService service;

        public GradeController(GetGradeByAlunoService service)
        {
            this.service = service;
        }

        [HttpGet("{idAluno:int}")]
        public async Task<ActionResult<GradeByAlunoResponseDTO>> GetGradeByAluno(int idAluno)
        {
            Console.WriteLine("idAluno: " + idAluno);
            // return Ok(new GradeByAlunoResponseDTO
            // {
            //     Nome_Aluno = "João Pedro Tiellet Demari",
            //     Creditos = 32,
            //     AlunoId = idAluno,
            //     PeriodosFaculdade = new List<LinhaPeriodoDTO>
            //     {
            //         new()
            //         {
            //             Posicao_Linha = 1,
            //             Label = "17:30 - 18:15",
            //             CustomizedLabel = "J"
            //         },
            //         new()
            //         {
            //             Posicao_Linha = 2,
            //             Label = "18:15 - 19:00",
            //             CustomizedLabel = "K"
            //         },
            //         new()
            //         {
            //             Posicao_Linha = 3,
            //             Label = "19:15 - 20:00",
            //             CustomizedLabel = "L"
            //         },
            //         new()
            //         {
            //             Posicao_Linha = 4,
            //             Label = "20:00 - 20:45",
            //             CustomizedLabel = "M"
            //         },
            //         new()
            //         {
            //             Posicao_Linha = 5,
            //             Label = "20:45 - 21:30",
            //             CustomizedLabel = "N"
            //         },
            //         new()
            //         {
            //             Posicao_Linha = 6,
            //             Label = "21:30 - 22:15",
            //             CustomizedLabel = "P"
            //         },
            //     },
            //     BlocosTurma = new List<BlocoTurmaDTO>
            //     {
            //         new()
            //         {
            //             Numero_Turma = 30,
            //             Nome_Disciplina = "Aprendizado De Máquina",
            //             Linha_Comeco = 1,
            //             Linha_Fim = 2,
            //             Dia_Semana = Enums.DiaSemana.Terca
            //         },
            //         new()
            //         {
            //             Numero_Turma = 30,
            //             Nome_Disciplina = "Aprendizado De Máquina",
            //             Linha_Comeco = 1,
            //             Linha_Fim = 2,
            //             Dia_Semana = Enums.DiaSemana.Quinta
            //         },
            //         new()
            //         {
            //             Numero_Turma = 31,
            //             Nome_Disciplina = "Projeto E Otimização De Algoritmos",
            //             Linha_Comeco = 3,
            //             Linha_Fim = 4,
            //             Dia_Semana = Enums.DiaSemana.Segunda
            //         },
            //         new()
            //         {
            //             Numero_Turma = 30,
            //             Nome_Disciplina = "Linguagens De Programação",
            //             Linha_Comeco = 3,
            //             Linha_Fim = 4,
            //             Dia_Semana = Enums.DiaSemana.Terca
            //         },
            //         new()
            //         {
            //             Numero_Turma = 31,
            //             Nome_Disciplina = "Projeto E Otimização De Algoritmos",
            //             Linha_Comeco = 3,
            //             Linha_Fim = 4,
            //             Dia_Semana = Enums.DiaSemana.Quarta
            //         },
            //         new()
            //         {
            //             Numero_Turma = 30,
            //             Nome_Disciplina = "Linguagens De Programação",
            //             Linha_Comeco = 3,
            //             Linha_Fim = 4,
            //             Dia_Semana = Enums.DiaSemana.Quinta
            //         },
            //         new()
            //         {
            //             Numero_Turma = 33,
            //             Nome_Disciplina = "Fundamentos De Processamento Paralelo E Distribuído",
            //             Linha_Comeco = 5,
            //             Linha_Fim = 6,
            //             Dia_Semana = Enums.DiaSemana.Segunda
            //         },
            //         new()
            //         {
            //             Numero_Turma = 30,
            //             Nome_Disciplina = "Verificação E Validação De Software",
            //             Linha_Comeco = 5,
            //             Linha_Fim = 6,
            //             Dia_Semana = Enums.DiaSemana.Terca
            //         },
            //         new()
            //         {
            //             Numero_Turma = 33,
            //             Nome_Disciplina = "Fundamentos De Processamento Paralelo E Distribuído",
            //             Linha_Comeco = 5,
            //             Linha_Fim = 6,
            //             Dia_Semana = Enums.DiaSemana.Quarta
            //         },
            //         new()
            //         {
            //             Numero_Turma = 30,
            //             Nome_Disciplina = "Verificação E Validação De Software",
            //             Linha_Comeco = 5,
            //             Linha_Fim = 6,
            //             Dia_Semana = Enums.DiaSemana.Quinta
            //         },
            //     }
            // });
            try
            {
                var grade = await service.GetGradeByAluno(idAluno);
                return Ok(grade);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult GetAsync()
        {
            service.PopulateDB();
            return Ok();
        }
    }
}
