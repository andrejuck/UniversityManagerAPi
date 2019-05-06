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
        private AlunoViewModel _alunoViewModel;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
            _alunoViewModel = new AlunoViewModel();
        }

        // GET: api/Aluno/GetAluno/5
        [HttpGet("{idAluno}")]
        public async Task<ActionResult<Aluno>> GetAluno(int idAluno)
        {
            return Ok(_alunoViewModel
                .ConverterModelParaViewModel(await _alunoRepository.GetAsync(idAluno)));
        }

        [HttpGet]
        public async Task<ActionResult<List<Aluno>>> GetTodosAlunos()
        {
            return Ok(_alunoViewModel
                .ConverterListModelParaViewModel(await _alunoRepository.GetAllAsync()));
        }

        // POST: api/Aluno/RegistrarAluno
        [HttpPost]
        public async Task<ActionResult<bool>> SalvarAluno([FromBody] AlunoViewModel alunoViewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _alunoViewModel
                    .ConverterViewModelParaModel(alunoViewModel);

                if (await _alunoRepository.Create(model))
                    return Ok();
            }

            return BadRequest();
        }

        // PUT: api/Aluno/EditarAluno
        [HttpPut]
        public async Task<ActionResult<Aluno>> EditarAluno([FromBody] AlunoViewModel alunoViewModel)
        {
            
            if (ModelState.IsValid)
            {
                var model = _alunoViewModel
                    .ConverterViewModelParaModel(alunoViewModel);

                return Ok(_alunoViewModel
                    .ConverterModelParaViewModel(await _alunoRepository.Update(model)));
            }

            return BadRequest();
        }

        // DELETE: api/Aluno/ExcluirAluno/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ExcluirAluno(int id)
        {
            if (await _alunoRepository.Delete(id))
                return Ok();

            return BadRequest();
        }
    }
}
