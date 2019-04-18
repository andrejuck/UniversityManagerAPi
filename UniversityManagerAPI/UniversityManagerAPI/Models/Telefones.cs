namespace UniversityManagerAPI.Models
{
    public class Telefones : BaseModel
    {
        public int Numero { get; set; }        
        public TipoTelefone Tipo { get; set; }
        public Alunos Aluno { get; set; }
    }
}