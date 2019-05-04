using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagerAPI.Models.ViewModel
{
    public class DisciplinaViewModel
    {
        public int DisciplinaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CargaHorariaId { get; set; }
        public string DataCadastro { get; set; }
        public List<Curso> Cursos { get; set; }

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
