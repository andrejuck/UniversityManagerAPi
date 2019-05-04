﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagerAPI.Models
{
    public class Curso : BaseModel
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
    }
}
