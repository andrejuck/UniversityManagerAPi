using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagerAPI.Models.ViewModel
{
    public class AlunoViewModel
    {
        [Required]
        public int IdAluno { get; set; }
        public int RegistroMatricula { get; set; }
        [Required]
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string DataNascimento { get; set; }
        public string DataCadastro { get; set; }
        [Required]
        public int UsuarioId { get; set; }

        public Aluno ConverterViewModelParaModel(AlunoViewModel aluno)
        {
            var model = new Aluno()
            {
                Id = aluno.IdAluno,
                RegistroMatricula = aluno.RegistroMatricula,
                Email = aluno.Email,
                Nome = aluno.Nome,
                Sobrenome = aluno.Sobrenome,
                DataNascimento = Convert.ToDateTime(aluno.DataNascimento),
                DataCadastro = string.IsNullOrEmpty(aluno.DataCadastro) ? DateTime.Now : Convert.ToDateTime(aluno.DataCadastro),
                UsuarioId = aluno.UsuarioId
            };

            return model;
        }

        public AlunoViewModel ConverterModelParaViewModel(Aluno aluno)
        {
            var model = new AlunoViewModel()
            {
                Nome = aluno.Nome,
                IdAluno = aluno.Id,
                DataCadastro = string.Format("{0}:dd/MM/yyyy", aluno.DataCadastro),
                DataNascimento = string.Format("{0}:dd/MM/yyyy", aluno.DataNascimento),
                Email = aluno.Email,
                RegistroMatricula = aluno.RegistroMatricula,
                Sobrenome = aluno.Sobrenome
            };

            return model;
        }
    }
}
