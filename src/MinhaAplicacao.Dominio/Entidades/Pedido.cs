using System.Collections.Generic;

namespace MinhaAplicacao.Dominio.Entidades
{
    public class Pedido : EntidadeBase<int>
    {
        public int ComandaId { get; set; }

        public virtual Comanda Comanda { get; set; }

        public virtual ICollection<PedidoCardapio> PedidoCardapios { get; set; }
    }
}
