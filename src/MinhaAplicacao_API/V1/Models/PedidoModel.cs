using System.Collections.Generic;

namespace MinhaAplicacao_API.V1.Models
{
    public class PedidoModel : ModelBase<int>
    {
        public int ComandaId { get; set; }

        public ComandaModel Comanda { get; set; }

        public List<PedidoModel> Pedidos { get; set; }
    }
}
