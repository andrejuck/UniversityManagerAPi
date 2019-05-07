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
                var cargaHoraria = await _context.CargasHorarias
                    .Where(w => w.Id == model.CargaHorariaId)
                    .SingleOrDefaultAsync();

                model.CargaHoraria = cargaHoraria ?? throw new Exception("Não foi possível encontrar a Carga Horária");
                model.CursosLink = new List<CursoDisciplina>()
                {
                    new CursoDisciplina()
                    {
                        Curso = _context.Cursos
                        .Where(w => w.Id == model.Cursos.SingleOrDefault().Id)
                        .SingleOrDefault(),
                        Disciplina = model
                    }
                };
                await _context.Disciplinas.AddAsync(model);

                if (await _context.SaveChangesAsync() > 0)
                    return true;

                throw new Exception("Não foi possível salvar a disciplina");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar a Disciplina: " + ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var disciplina = await _context.Disciplinas
                    .Where(w => w.Id == id)
                    .SingleOrDefaultAsync();

                if (disciplina != null)
                    _context.Remove(disciplina);
                else
                    throw new Exception("Não foi possível encontrar a disciplina.");

                if (await _context.SaveChangesAsync() > 0)
                    return true;

                throw new Exception("Não foi possível excluir a disciplina.");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir a disciplina: " + ex.Message);
            }
        }

        public async Task<List<Disciplina>> GetAllAsync()
        {
            try
            {
                return await _context.Disciplinas
                    //.Include(i => i.Cursos)
                    .Include(i => i.CargaHoraria)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar as disciplinsa: " + ex.Message);
            }
        }

        public async Task<Disciplina> GetAsync(int id)
        {
            try
            {
                var disciplina = await _context.Disciplinas
                    .Include(i => i.CargaHoraria)
                    .Include(disc => disc.CursosLink)                    
                    .Where(w => w.Id == id)
                    .SingleOrDefaultAsync();

                //Funcionou, porém não sei se é a melhor maneira.
                disciplina.Cursos = new List<Curso>();
                foreach (var item in disciplina.CursosLink)
                {                    
                    var curso = _context.Cursos.Find(item.CursoId);
                    disciplina.Cursos.Add(curso);
                }

                if (disciplina != null)
                    return disciplina;

                throw new Exception("Disciplina não encontrada");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar a disciplina: " + ex.Message);
            }
        }

        public async Task<List<Disciplina>> GetTodasDisciplinasPorCurso(int idCurso)
        {
            try
            {
                var cursosDisciplinas = await _context.CursoDisciplina
                    .Where(w => w.CursoId == idCurso)
                    .ToListAsync();

                var disciplinas = new List<Disciplina>();
                foreach (var item in cursosDisciplinas)
                {
                    var disciplina = await _context.Disciplinas
                        .Where(w => w.Id == item.DisciplinaId)
                        .SingleOrDefaultAsync();

                    disciplinas.Add(disciplina);
                }

                return disciplinas;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar as disciplinas do curso: " + ex.Message);
            }
        }

        public async Task<Disciplina> Update(Disciplina model)
        {
            try
            {
                _context.Disciplinas
                    .Update(model);

                if (await _context.SaveChangesAsync() > 0)
                    return await _context.Disciplinas                        
                        .Include(i => i.CargaHoraria)
                        .Where(w => w.Id == model.Id)
                        .SingleOrDefaultAsync();

                throw new Exception("Não foi possível salvar as alterações da disciplina.");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar a disciplina: " + ex.Message);
            }
        }
    }
}
