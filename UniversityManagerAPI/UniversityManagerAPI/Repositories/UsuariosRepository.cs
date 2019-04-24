using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagerAPI.Context;
using UniversityManagerAPI.Models;
using UniversityManagerAPI.Repositories.Interfaces;

namespace UniversityManagerAPI.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApiDBContext context) : base(context)
        {
        }

        public async Task<Usuario> Create(Usuario model)
        {

            _context.Add(model);

            if (_context.SaveChanges() > 0)
            {
                var teste = _context.Usuarios
                    .Include(i => i.Aluno)
                    .Where(w => w.Id == model.Aluno.Id)
                    .SingleOrDefault();

                _context.SaveChanges();
            }

            return null;
        }

        public Usuario GetUsuarioLogin(Usuario usuario)
        {
            return _context.Usuarios
                .Where(u => u.Login == usuario.Login && u.Password == usuario.Password)
                .SingleOrDefault();
        }
    }
}
