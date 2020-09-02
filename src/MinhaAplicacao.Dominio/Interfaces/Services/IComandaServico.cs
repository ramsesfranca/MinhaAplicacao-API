using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;
using System.Threading.Tasks;

namespace MinhaAplicacao.Dominio.Interfaces.Services
{
    public interface IComandaServico : IServicoBase<int, Comanda, IComandaRepositorio>
    {
        Task Inserir();
        Task Resetar(int id);
    }
}
