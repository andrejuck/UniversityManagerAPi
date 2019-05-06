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
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;
        private CursoViewModel _cursoViewModel;

        public CursoController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
            _cursoViewModel = new CursoViewModel();
        }

        // GET: api/Curso/GetCurso/{idCurso}
        [HttpGet("{idCurso}")]
        public async Task<ActionResult<CursoViewModel>> GetCurso(int idCurso)
        {
            return Ok(_cursoViewModel
                .ConverterModelParaViewModel(await _cursoRepository.GetAsync(idCurso)));
        }

        // GET: api/Curso/GetTodosCursos
        [HttpGet]
        public async Task<ActionResult<List<CursoViewModel>>> GetTodosCursos()
        {
            return Ok(_cursoViewModel
                .ConverterListModelParaListViewModel(await _cursoRepository.GetAllAsync()));
        }

        // POST: api/Curso/SalvarCurso
        [HttpPost]
        public async Task<ActionResult<bool>> SalvarCurso([FromBody] CursoViewModel cursoViewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _cursoViewModel
                    .ConverterViewModelParaModel(cursoViewModel);

                if (await _cursoRepository.Create(model))
                    return Ok();
            }

            return BadRequest();
        }

        // PUT: api/Curso/EditarCurso
        [HttpPut]
        public async Task<ActionResult<CursoViewModel>> EditarCurso([FromBody] CursoViewModel cursoViewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _cursoViewModel
                    .ConverterViewModelParaModel(cursoViewModel);

                return Ok(_cursoViewModel
                    .ConverterModelParaViewModel(await _cursoRepository.Update(model)));
            }

            return BadRequest();
        }

        // DELETE: api/ExcluirCurso/{idCurso}
        [HttpDelete("{idCurso}")]
        public async Task<ActionResult<bool>> ExcluirCurso(int idCurso)
        {
            if (await _cursoRepository.Delete(idCurso))
                return Ok();
                        
            return BadRequest();
        }
    }
}
