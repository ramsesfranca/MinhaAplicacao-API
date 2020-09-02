using Microsoft.EntityFrameworkCore.Internal;
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
        private readonly IPedidoServico _pedidoServico;

        public ComandaServico(IUnitOfWork unitOfWork, IComandaRepositorio repositorio, IPedidoServico pedidoServico)
            : base(unitOfWork, repositorio)
        {
            this._pedidoServico = pedidoServico;
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

        public async Task Resetar(int id)
        {
            var pedidos = await this._pedidoServico.SelecionarPor(p => p.ComandaId == id);

            if (pedidos.Any())
            {
                await this._pedidoServico.Deletar(pedidos);
            }
        }
    }
}
