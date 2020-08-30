using MinhaAplicacao.Dominio.Enums;

namespace MinhaAplicacao_API.V1.Models
{
    public class ComandaModel : ModelBase<int>
    {
        public string Codigo { get; set; }
        public StatusComanda StatusComanda { get; set; }
    }
}
