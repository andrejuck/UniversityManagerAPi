using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagerAPI.Models.ViewModel
{
    public class DisciplinaViewModel
    {
        private CursoViewModel _cursoViewModel;
        public DisciplinaViewModel()
        {
            _cursoViewModel = new CursoViewModel();
        }
        public int DisciplinaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CargaHorariaId { get; set; }
        public string DataCadastro { get; set; }
        public List<CursoViewModel> Cursos { get; set; }

        public DisciplinaViewModel ConverterModelParaViewModel(Disciplina disciplina)
        {
            var disciplinaViewModel = new DisciplinaViewModel()
            {
                DisciplinaId = disciplina.Id,
                CargaHorariaId = disciplina.CargaHorariaId,
                DataCadastro = string.Format("{0:dd/MM/yyyy}", disciplina.DataCadastro),
                Descricao = disciplina.Descricao,
                Nome = disciplina.Nome,
                Cursos = disciplina.CursosLink != null ? _cursoViewModel.ConverterListModelParaListViewModel(disciplina.Cursos) : null
            };

            return disciplinaViewModel;
        }

        public Disciplina ConverterViewModelParaModel(DisciplinaViewModel disciplinaViewModel)
        {
            var disciplina = new Disciplina()
            {
                Id = disciplinaViewModel.DisciplinaId,
                CargaHorariaId = disciplinaViewModel.CargaHorariaId,
                DataCadastro = Convert.ToDateTime(disciplinaViewModel.DataCadastro),
                Descricao = disciplinaViewModel.Descricao,
                Nome = disciplinaViewModel.Nome,
                Cursos = disciplinaViewModel.Cursos != null ? _cursoViewModel.ConverterListViewModelParaListModel(disciplinaViewModel.Cursos) : null
            };

            return disciplina;
        }

        public List<DisciplinaViewModel> ConverterListModelParaListViewModel(List<Disciplina> lDisciplina)
        {
            var lDisciplinasViewModel = lDisciplina.ConvertAll(x => new DisciplinaViewModel
            {
                Descricao = x.Descricao,
                CargaHorariaId = x.CargaHorariaId,
                DataCadastro = string.Format("{0}:dd/MM/yyyy", x.DataCadastro),
                DisciplinaId = x.Id,
                Nome = x.Nome
            });

            return lDisciplinasViewModel;
        }

        public List<Disciplina> ConverterListViewModelParaListModel(List<DisciplinaViewModel> lDisciplinasViewModel)
        {
            var lDisciplinas = lDisciplinasViewModel.ConvertAll(x => new Disciplina
            {
                Id = x.DisciplinaId,
                CargaHorariaId = x.CargaHorariaId,
                DataCadastro = Convert.ToDateTime(x.DataCadastro),
                Descricao = x.Descricao,
                Nome = x.Nome
            });

            return lDisciplinas;
        }
    }
}
