namespace MinhaAplicacao.Dominio.Entidades
{
    public class Cardapio : EntidadeBase<int>
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
