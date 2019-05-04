using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagerAPI.Models
{
    public class CargaHoraria : BaseModel
    {
        public int QuantidadeHoras { get; set; }
        public double CustoBase { get; set; }
        public Curso Curso { get; set; }
        public int CursoId { get; set; }
    }
}
