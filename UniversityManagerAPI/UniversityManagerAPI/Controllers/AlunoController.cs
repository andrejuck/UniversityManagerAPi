using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityManagerAPI.Models;
using UniversityManagerAPI.Models.ViewModel;
using UniversityManagerAPI.Repositories.Interfaces;

namespace UniversityManagerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        // GET: api/Aluno/GetAluno/5
        [HttpGet("{idAluno}")]
        public async Task<ActionResult<Aluno>> GetAluno(int idAluno)
        {
            var model = await _alunoRepository.GetAsync(idAluno);

            return Ok(model);
        }

        [HttpGet]
        public async Task<ActionResult<Aluno>> GetTodosAlunos()
        {
            var model = await _alunoRepository.GetAllAsync();

            return Ok(model);
        }

        // POST: api/Aluno/RegistrarAluno
        [HttpPost]
        public async Task<ActionResult<bool>> RegistrarAluno([FromBody] AlunoViewModel aluno)
        {
            var novoAluno = new AlunoViewModel().ConverterViewModelParaModel(aluno);
            var model = await _alunoRepository.Create(novoAluno);

            return Ok(model);
        }

        // PUT: api/Aluno/EditarAluno
        [HttpPut]
        public async Task<ActionResult<Aluno>> EditarAluno([FromBody] AlunoViewModel aluno)
        {
            //if (string.IsNullOrEmpty(aluno.Email))
            //    return BadRequest();
            if (ModelState.IsValid)
            {
                var alunoEditado = new AlunoViewModel().ConverterViewModelParaModel(aluno);
                var retorno = await _alunoRepository.Update(alunoEditado);

                return Ok(retorno);
            }

            return BadRequest();
        }

        // DELETE: api/Aluno/ExcluirAluno/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ExcluirAluno(int id)
        {
            var retorno = await _alunoRepository.Delete(id);
            if (retorno)
                return Ok();

            return BadRequest();
        }
    }
}
