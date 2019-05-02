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
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApiDBContext context) : base(context)
        {
        }

        public async Task<Aluno> Create(Aluno model)
        {
            try
            {
                //TODO - Validate one to one relation on email. One Student to One User Email.
                var usuario = _context.Usuarios
                    .Include(i => i.Aluno)
                    .Where(w => w.Email == model.Email)
                    .SingleOrDefault();

                //TODO - Include FK to Aluno.

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar o aluno: " + ex.Message);
            }
        }

        public async Task<Aluno> GetAsync(int id)
        {
            try
            {
                var aluno = await _context.Alunos
                    .Where(w => w.Id == id)
                    .SingleAsync();

                if (aluno != null)
                    return aluno;

                throw new Exception("Aluno não encontrado!");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o aluno: " + ex.Message);
            }
        }
    }
}
