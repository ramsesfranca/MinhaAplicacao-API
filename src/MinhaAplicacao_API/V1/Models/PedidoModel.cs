namespace MinhaAplicacao_API.V1.Models
{
    public class PedidoModel : ModelBase<int>
    {
        public int ComandaId { get; set; }
        public int CardapioId { get; set; }

        public ComandaModel Comanda { get; set; }
        public CardapioModel Cardapio { get; set; }
    }
}
