﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagerAPI.Models
{
    public class Aluno : BaseModel
    {
        public int RegistroMatricula { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }        
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<Telefone> Telefones { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
