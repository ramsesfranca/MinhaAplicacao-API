﻿namespace MinhaAplicacao.Dominio.Entidades
{
    public class Cardapio : EntidadeBase<int>
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        //public virtual ICollection<PedidoCardapio> PedidoCardapios { get; set; }
    }
}
