using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagerAPI.Models.ViewModel
{
    public class CursoViewModel : BaseViewModel<CursoViewModel>
    {
        private DisciplinaViewModel _disciplinaViewModel;

        public CursoViewModel()
        {
            _disciplinaViewModel = new DisciplinaViewModel();
        }

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
                DataCadastro = Convert.ToDateTime(curso.DataCadastro),
                Nome = curso.Nome,
                Descricao = curso.Descricao,
                Disciplinas = curso.Disciplinas != null ? _disciplinaViewModel.ConverterListViewModelParaListModel(curso.Disciplinas) : null
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
                DataCadastro = string.Format("{0:dd/MM/yyyy}", curso.DataCadastro),
                Disciplinas = curso.Disciplinas != null ? _disciplinaViewModel.ConverterListModelParaListViewModel(curso.Disciplinas) : null
            };

            return viewModel;
        }
        public List<CursoViewModel> ConverterListModelParaListViewModel(List<Curso> lCursos)
        {
            //TODO - converter o retorno de disciplinas também
            var lCursosViewModel = lCursos.ConvertAll(x => new CursoViewModel
            {
                Descricao = x.Descricao,
                Codigo = x.Codigo,
                DataCadastro = string.Format("{0:dd/MM/yyyy}", x.DataCadastro),
                CursoId = x.Id,
                Nome = x.Nome
            });

            return lCursosViewModel;
        }

        public List<Curso> ConverterListViewModelParaListModel(List<CursoViewModel> lCursosViewModel)
        {
            //TODO - converter o retorno de disciplinas também
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
