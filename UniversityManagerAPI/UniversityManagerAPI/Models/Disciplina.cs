using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagerAPI.Models
{
    public class Disciplina : BaseModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public CargaHoraria CargaHoraria { get; set; }
        public int CargaHorariaId { get; set; }
        public IList<Curso> Cursos { get; set; }
    }
}
