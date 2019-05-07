using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagerAPI.Models.ViewModel
{
    public class AlunoViewModel : BaseViewModel<AlunoViewModel>
    {        
        public int IdAluno { get; set; }
        public int RegistroMatricula { get; set; }
        [Required]
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string DataNascimento { get; set; }
        public string DataCadastro { get; set; }
        public int UsuarioId { get; set; }
        public Curso Curso { get; set; }

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
                UsuarioId = aluno.UsuarioId,
                Curso = aluno.Curso                                
            };

            return model;
        }

        public AlunoViewModel ConverterModelParaViewModel(Aluno aluno)
        {
            var viewModel = new AlunoViewModel()
            {
                Nome = aluno.Nome,
                IdAluno = aluno.Id,
                DataCadastro = string.Format("{0:dd/MM/yyyy}", aluno.DataCadastro),
                DataNascimento = string.Format("{0:dd/MM/yyyy}", aluno.DataNascimento),
                Email = aluno.Email,
                RegistroMatricula = aluno.RegistroMatricula,
                Sobrenome = aluno.Sobrenome,
                UsuarioId = aluno.UsuarioId,
                Curso = aluno.Curso
            };

            return viewModel;
        }

        public List<AlunoViewModel> ConverterListModelParaViewModel(List<Aluno> lAlunos)
        {
            var lAlunosViewModel = lAlunos.ConvertAll(x => new AlunoViewModel()
            {
                IdAluno = x.Id,
                UsuarioId = x.UsuarioId,
                RegistroMatricula = x.RegistroMatricula,
                Sobrenome = x.Sobrenome,
                Nome = x.Nome,
                Email = x.Email,
                DataCadastro = string.Format("{0:dd/MM/yyyy}", x.DataCadastro),
                DataNascimento = string.Format("{0:dd/MM/yyyy}", x.DataNascimento),
                Curso = x.Curso
            });

            return lAlunosViewModel;
        }

        public List<Aluno> ConverterListViewModelParaListModel(List<AlunoViewModel> lAlunosViewModel)
        {
            var lAlunos = lAlunosViewModel.ConvertAll(x => new Aluno()
            {
                Id = x.IdAluno,
                UsuarioId = x.UsuarioId,
                Nome = x.Nome,
                Sobrenome = x.Sobrenome,
                RegistroMatricula = x.RegistroMatricula,
                Email = x.Email,
                DataCadastro = Convert.ToDateTime(x.DataCadastro),
                DataNascimento = Convert.ToDateTime(x.DataNascimento),
                Curso = x.Curso
            });

            return lAlunos;
        }
    }
}
