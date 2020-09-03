using MinhaAplicacao.Dominio.Enums;
using System.Collections.Generic;

namespace MinhaAplicacao.Dominio.Entidades
{
    public class Comanda : EntidadeBase<int>
    {
        public string Codigo { get; set; }
        public StatusComanda StatusComanda { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
