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

        public async Task<bool> Create(Aluno model)
        {
            try
            {
                var usuario = _context.Usuarios
                    .Where(w => w.Email == model.Email)
                    .ToList();

                //Validating if ONLY one user has the student email.
                if (usuario.Count == 1)
                    usuario.FirstOrDefault().Aluno = model;
                else if (usuario.Count == 0)
                    throw new Exception("Nenhum usuário encontrado com o email fornecido.");
                else
                    throw new Exception("Mais de um usuario encontrado com o email do aluno.");

                if (await _context.SaveChangesAsync() > 0) return true;

                throw new Exception("Não foi possível salvar o Aluno.");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar o aluno: " + ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var aluno = _context.Alunos
                    .Include(curso => curso.Curso)
                    .Where(w => w.Id == id)
                    .SingleOrDefault();

                if (aluno != null)
                    _context.Remove(aluno);
                else
                    throw new Exception("Não foi possível encontrar o Aluno.");

                if (await _context.SaveChangesAsync() > 0) return true;

                throw new Exception("Não foi possível excluir o Aluno");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir Aluno: " + ex.Message);
            }
        }

        public async Task<List<Aluno>> GetAllAsync()
        {
            try
            {
                return await _context.Alunos
                    .Include(curso => curso.Curso)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar todos os alunos: " + ex.Message);
            }
        }

        public Task<Aluno> GetAlunoPorCurso(int idCurso)
        {
            throw new NotImplementedException();
        }

        public async Task<Aluno> GetAsync(int id)
        {
            try
            {
                var aluno = await _context.Alunos      
                    .Include(x => x.Curso)
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

        public async Task<Aluno> Update(Aluno model)
        {
            try
            {
                _context.Alunos.Update(model);
                if (await _context.SaveChangesAsync() > 0)
                    return _context.Alunos
                        .Include(curso => curso.Curso)
                        .Where(w => w.Id == model.Id)
                        .SingleOrDefault();

                throw new Exception("Não foi possível salvar os novos dados do aluno.");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar o aluno: " + ex.Message);
            }
        }
    }
}
