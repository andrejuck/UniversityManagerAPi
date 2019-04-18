using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityManagerAPI.Models;
using UniversityManagerAPI.Repositories.Interfaces;

namespace UniversityManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public LoginController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Register(Usuarios user)
        {
            if (ModelState.IsValid)
            {
                var retorno = await _usuariosRepository.Create(user);
                return Ok(retorno);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}