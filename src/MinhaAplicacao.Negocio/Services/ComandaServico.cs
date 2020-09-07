using Microsoft.EntityFrameworkCore.Internal;
using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Enums;
using MinhaAplicacao.Dominio.Interfaces.Repositories;
using MinhaAplicacao.Dominio.Interfaces.Services;
using System;
using System.Linq;
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
            await base.Inserir(new Comanda
            {
                Codigo = GerarCodigo(),
                StatusComanda = StatusComanda.Aerta
            });
        }

        public async Task Resetar(int id)
        {
            var comanda = await this.SelecionarPorId(id, c => c.Pedidos);

            if (comanda != null && EnumerableExtensions.Any(comanda.Pedidos))
            {
                await this._pedidoServico.Deletar(comanda.Pedidos.ToList());
            }
        }

        public async Task<Comanda> Fechamento(int id)
        {
            var comandas = await this.SelecionarPorId(id, c => c.Pedidos); //.Select(p => p.Cardapio)

            var teste = comandas.Pedidos.GroupBy(p => p.CardapioId).ToList();

            return comandas;
        }

        private static string GerarCodigo()
        {
            return $"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}";
        }
    }
}
