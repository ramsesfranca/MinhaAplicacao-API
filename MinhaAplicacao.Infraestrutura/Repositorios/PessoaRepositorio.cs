using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;

namespace MinhaAplicacao.Infraestrutura.Repositorios
{
    public class PessoaRepositorio : RepositorioBase<int, Pessoa>, IPessoaRepositorio
    {
        public PessoaRepositorio(MinhaAplicacaoDbContext contexto)
            : base(contexto)
        {
        }
    }
}
