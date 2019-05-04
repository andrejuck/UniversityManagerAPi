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
    public class DisciplinaRepository : BaseRepository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(ApiDBContext context) : base(context)
        {
        }

        public async Task<bool> Create(Disciplina model)
        {
            try
            {
                var curso = await _context.Cursos
                    .Where(w => w.Id == model.Cursos.SingleOrDefault().Id)
                    .SingleOrDefaultAsync();

                if (curso == null)
                    throw new Exception("Não foi possível encontrar o Curso.");

                var cargaHoraria = await _context.CargasHorarias
                    .Where(w => w.Id == model.Id)
                    .SingleOrDefaultAsync();

                model.CargaHoraria = cargaHoraria ?? throw new Exception("Não foi possível encontrar a Carga Horária");
                model.Cursos.Add(curso);

                if (await _context.SaveChangesAsync() > 0)
                    return true;

                throw new Exception("Não foi possível salvar a disciplina");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar a Disciplina: " + ex.Message);
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Disciplina>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Disciplina> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Disciplina> Update(Disciplina model)
        {
            throw new NotImplementedException();
        }
    }
}
