using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;
using MinhaAplicacao.Dominio.Interfaces.Services;
using MinhaAplicacao.Negocio.Validations;
using System.Threading.Tasks;

namespace MinhaAplicacao.Negocio.Services
{
    public class PessoaServico : ServicoBase<int, Pessoa, IPessoaRepositorio>, IPessoaServico
    {
        public PessoaServico(IUnitOfWork unitOfWork, IPessoaRepositorio repositorio)
            : base(unitOfWork, repositorio)
        {
        }

        public override async Task Inserir(Pessoa entidade)
        {
            if (!this.ExecutarValidacao(new PessoaValidation(this), entidade))
            {
                return;
            }

            await base.Inserir(entidade);
        }

        public override async Task Alterar(Pessoa entidade)
        {
            if (!this.ExecutarValidacao(new PessoaValidation(this), entidade))
            {
                return;
            }

            await base.Alterar(entidade);
        }
    }
}
