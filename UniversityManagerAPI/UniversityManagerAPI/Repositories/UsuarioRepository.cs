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
            try
            {
                _context.Add(model);

                if (_context.SaveChanges() > 0)
                    return model;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao registrar usuário: " + ex.Message);
            }
        }

        public Task<Usuario> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioLogin(Usuario usuario)
        {
            return _context.Usuarios
                .Where(u => u.Login == usuario.Login && u.Password == usuario.Password)
                .SingleOrDefault();
        }

        
    }
}
