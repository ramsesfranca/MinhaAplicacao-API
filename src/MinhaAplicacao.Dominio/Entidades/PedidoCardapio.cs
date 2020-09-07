namespace MinhaAplicacao.Dominio.Entidades
{
    public class PedidoCardapio
    {
        public int PedidoId { get; set; }
        public int CardapioId { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Cardapio Cardapio { get; set; }
    }
}
