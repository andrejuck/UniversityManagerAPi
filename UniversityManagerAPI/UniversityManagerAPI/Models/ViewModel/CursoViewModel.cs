using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagerAPI.Models.ViewModel
{
    public class CursoViewModel : BaseViewModel<CursoViewModel>
    {
        public int CursoId { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DataCadastro { get; set; }
        public List<DisciplinaViewModel> Disciplinas { get; set; }

        public Curso ConverterViewModelParaModel(CursoViewModel curso)
        {
            var model = new Curso()
            {
                Id = curso.CursoId,
                Codigo = curso.Codigo,
                DataCadastro = string.IsNullOrEmpty(curso.DataCadastro) ? DateTime.Now : Convert.ToDateTime(curso.DataCadastro),
                Nome = curso.Nome,
                Descricao = curso.Descricao,
                Disciplinas = new DisciplinaViewModel().ConverterListViewModelParaListModel(curso.Disciplinas)
            };

            return model;
        }

        public CursoViewModel ConverterModelParaViewModel(Curso curso)
        {
            var viewModel = new CursoViewModel()
            {
                CursoId = curso.Id,
                Nome = curso.Nome,
                Descricao = curso.Descricao,
                Codigo = curso.Codigo,
                DataCadastro = string.Format("{0}:dd/MM/yyyy", curso.DataCadastro),
                Disciplinas = new DisciplinaViewModel().ConverterListModelParaListViewModel(curso.Disciplinas)
            };

            return viewModel;
        }
        public List<CursoViewModel> ConverterListModelParaListViewModel(List<Curso> lCursos)
        {
            var lCursosViewModel = lCursos.ConvertAll(x => new CursoViewModel
            {
                Descricao = x.Descricao,
                Codigo = x.Codigo,
                DataCadastro = string.Format("{0}:dd/MM/yyyy", x.DataCadastro),
                CursoId = x.Id,
                Nome = x.Nome
            });

            return lCursosViewModel;
        }

        public List<Curso> ConverterListViewModelParaListModel(List<CursoViewModel> lCursosViewModel)
        {
            var lCursos = lCursosViewModel.ConvertAll(x => new Curso
            {
                Id = x.CursoId,
                Codigo = x.Codigo,
                DataCadastro = Convert.ToDateTime(x.DataCadastro),
                Descricao = x.Descricao,
                Nome = x.Nome
            });

            return lCursos;
        }

    }
}
