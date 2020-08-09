using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;
using MinhaAplicacao.Dominio.Interfaces.Services;

namespace MinhaAplicacao.Negocio.Services
{
    public class PessoaServico : ServicoBase<int, Pessoa, IPessoaRepositorio>, IPessoaServico
    {
        public PessoaServico(IUnitOfWork unitOfWork, IPessoaRepositorio repositorio)
            : base(unitOfWork, repositorio)
        {
        }
    }
}
