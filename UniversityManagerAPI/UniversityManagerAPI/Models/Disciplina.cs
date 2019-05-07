using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        public List<CursoDisciplina> CursosLink { get; set; }
        [NotMapped]
        public List<Curso> Cursos { get; set; }

    }
}
