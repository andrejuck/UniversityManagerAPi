using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UniversityManagerAPI.Models;
using UniversityManagerAPI.Repositories.Interfaces;

namespace UniversityManagerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuariosRepository;
        private IConfiguration _config;
                
        public LoginController(IUsuarioRepository usuariosRepository, IConfiguration config)
        {
            _usuariosRepository = usuariosRepository;
            _config = config;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult Login([FromBody]Usuario usuario)
        //{
        //    IActionResult response = Unauthorized();
        //    var user = AuthenticateUser(usuario);
            
        //}

        //private Usuario AuthenticateUser(Usuario usuario)
        //{
        //    var retorno = _usuariosRepository.
        //}

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]Usuario user)
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