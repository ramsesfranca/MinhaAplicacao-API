using MinhaAplicacao.Dominio.Enums;

namespace MinhaAplicacao.Dominio.Entidades
{
    public class Comanda : EntidadeBase<int>
    {
        public string Codigo { get; set; }
        public StatusComanda StatusComanda { get; set; }
    }
}
