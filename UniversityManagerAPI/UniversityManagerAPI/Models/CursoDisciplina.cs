using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagerAPI.Models
{
    public class CursoDisciplina
    {
        public int CursoId { get; set; }
        public int DisciplinaId { get; set; }
        public Curso Curso { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
