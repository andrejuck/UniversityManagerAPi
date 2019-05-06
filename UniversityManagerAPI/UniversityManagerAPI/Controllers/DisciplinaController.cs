using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityManagerAPI.Models.ViewModel;
using UniversityManagerAPI.Repositories.Interfaces;

namespace UniversityManagerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private DisciplinaViewModel _disciplinaViewModel;

        public DisciplinaController(IDisciplinaRepository disciplinaRepository)
        {
            _disciplinaRepository = disciplinaRepository;
            _disciplinaViewModel = new DisciplinaViewModel();
        }

        // GET: api/GetDisciplina/idDisciplina
        [HttpGet("idDisciplina")]
        public async Task<ActionResult<DisciplinaViewModel>> GetDisciplina(int idDisciplina)
        {
            return Ok(_disciplinaViewModel
                .ConverterModelParaViewModel(await _disciplinaRepository.GetAsync(idDisciplina)));
        }

        // GET: api/Disciplina/GetDisciplinaPorCurso/idCurso
        [HttpGet("{idCurso}")]
        public async Task<ActionResult<List<DisciplinaViewModel>>> GetDisciplinaPorCurso(int idCurso)
        {
            //TODO - Testar
            return Ok(_disciplinaViewModel
                .ConverterListModelParaListViewModel(await _disciplinaRepository.GetTodasDisciplinasPorCurso(idCurso)));
        }

        // GET: api/Disciplina/GetTodasDisciplinas
        [HttpGet]
        public async Task<ActionResult<List<DisciplinaViewModel>>> GetTodasDisciplinas(int idCurso)
        {
            return Ok(_disciplinaViewModel
                .ConverterListModelParaListViewModel(await _disciplinaRepository.GetAllAsync()));
        }

        // POST: api/Disciplina/
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Disciplina/SalvarDisciplina
        [HttpPost]
        public async Task<ActionResult<bool>> SalvarDisciplina([FromBody] DisciplinaViewModel disciplinaViewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _disciplinaViewModel
                    .ConverterViewModelParaModel(disciplinaViewModel);

                if (await _disciplinaRepository.Create(model))
                    Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<DisciplinaViewModel>> EditarDisciplina([FromBody] DisciplinaViewModel disciplinaViewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _disciplinaViewModel
                    .ConverterViewModelParaModel(disciplinaViewModel);

                return Ok(_disciplinaViewModel
                    .ConverterModelParaViewModel(await _disciplinaRepository.Update(model)));
            }

            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
