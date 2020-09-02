namespace MinhaAplicacao.Dominio.Entidades
{
    public class Pedido : EntidadeBase<int>
    {
        public int ComandaId { get; set; }
        public int CardapioId { get; set; }

        public virtual Comanda Comanda { get; set; }
        public virtual Cardapio Cardapio { get; set; }

        //public virtual ICollection<PedidoCardapio> PedidoCardapios { get; set; }
    }
}
