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

        public async Task<bool> Create(Usuario model)
        {
            try
            {
                //Validating if the user email is unique.
                var user = _context.Usuarios
                    .Where(w => w.Email == model.Email)
                    .SingleOrDefault();

                if (user == null)
                {
                    _context.Add(model);
                    if (_context.SaveChanges() > 0)
                        return true;

                    throw new Exception("Erro ao salvar os dados do usuário");
                }
                else
                    throw new Exception("Email já cadastrado.");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao registrar usuário: " + ex.Message);
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> GetAllAsync()
        {
            throw new NotImplementedException();
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

        public Task<Usuario> Update(int id, Usuario model)
        {
            throw new NotImplementedException();
        }
    }
}
