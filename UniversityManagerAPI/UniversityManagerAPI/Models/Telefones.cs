namespace UniversityManagerAPI.Models
{
    public class Telefone : BaseModel
    {
        public int Numero { get; set; }        
        public TipoTelefone Tipo { get; set; }
        public Aluno Aluno { get; set; }
    }
}