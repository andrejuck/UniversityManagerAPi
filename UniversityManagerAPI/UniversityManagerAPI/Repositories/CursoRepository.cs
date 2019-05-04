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
    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        public CursoRepository(ApiDBContext context) : base(context)
        {
        }

        public async Task<bool> Create(Curso model)
        {
            try
            {
                await _context.Cursos.AddAsync(model);

                if (await _context.SaveChangesAsync() > 0)
                    return true;

                throw new Exception("Não foi possível salvar o Curso");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar o Curso: " + ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var curso = _context.Cursos
                    .Where(w => w.Id == id)
                    .SingleOrDefault();

                if (curso != null)
                    _context.Remove(curso);
                else
                    throw new Exception("Não foi possível encontrar o Curso.");

                if (await _context.SaveChangesAsync() > 0) return true;

                throw new Exception("Não foi possível excluir o Curso.");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir o Curso: " + ex.Message);
            }
        }

        public async Task<List<Curso>> GetAllAsync()
        {
            try
            {
                return await _context.Cursos
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar os Cursos: " + ex.Message);
            }
        }

        public async Task<Curso> GetAsync(int id)
        {
            try
            {
                var curso = await _context.Cursos
                    .Where(w => w.Id == id)
                    .SingleOrDefaultAsync();

                if (curso != null)
                    return curso;

                throw new Exception("Curso não Encontrado.");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o curso: " + ex.Message);
            }
        }

        public async Task<Curso> Update(Curso model)
        {
            try
            {
                _context.Cursos.Update(model);
                if (await _context.SaveChangesAsync() > 0)
                    return _context.Cursos
                        .Where(w => w.Id == model.Id)
                        .SingleOrDefault();

                throw new Exception("Não foi possível salvar os dados do Curso.");
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
    }
}
