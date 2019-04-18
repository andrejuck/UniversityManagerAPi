using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagerAPI.Models
{
    public class Alunos : BaseModel
    {
        public int RegistroMatricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }        
        public List<Telefones> Telefones { get; set; }        
    }
}
