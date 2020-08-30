using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Enums;
using MinhaAplicacao.Dominio.Interfaces.Repositories;
using MinhaAplicacao.Dominio.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace MinhaAplicacao.Negocio.Services
{
    public class ComandaServico : ServicoBase<int, Comanda, IComandaRepositorio>, IComandaServico
    {
        public ComandaServico(IUnitOfWork unitOfWork, IComandaRepositorio repositorio)
            : base(unitOfWork, repositorio)
        {
        }

        public async Task Inserir()
        {
            var comanda = new Comanda
            {
                Codigo = $"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}",
                StatusComanda = StatusComanda.Aerta
            };

            await base.Inserir(comanda);
        }
    }
}
