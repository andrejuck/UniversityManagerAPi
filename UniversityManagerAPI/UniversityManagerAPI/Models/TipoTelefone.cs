namespace UniversityManagerAPI.Models
{
    public class TipoTelefone : BaseModel
    {
        public bool IsCelular { get; set; }
        public bool IsFixo { get; set; }
        /// <summary>
        /// Define se é Comercial, Residencial, Cobrança e etc
        /// </summary>
        public string Categoria { get; set; }
    }
}