using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;

namespace MinhaAplicacao.Infraestrutura.Repositorios
{
    public class ComandaRepositorio : RepositorioBase<int, Comanda>, IComandaRepositorio
    {
        public ComandaRepositorio(MinhaAplicacaoDbContext contexto)
            : base(contexto)
        {
        }
    }
}
