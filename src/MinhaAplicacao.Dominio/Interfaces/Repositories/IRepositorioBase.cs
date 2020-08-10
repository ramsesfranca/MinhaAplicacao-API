using MinhaAplicacao.Dominio.Entidades;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MinhaAplicacao.Dominio.Interfaces.Repositories
{
    public interface IRepositorioBase<in TId, TEntidade> : IDisposable
        where TId : IEquatable<TId>
        where TEntidade : EntidadeBase<TId>
    {
        void Inserir(TEntidade entidade);
        void Alterar(TEntidade entidade);
        void Deletar(TEntidade entidade);
        IQueryable<TEntidade> SelecionarPorId(TId id);
        IQueryable<TEntidade> SelecionarTodos();
        IQueryable<TEntidade> SelecionarPor(Expression<Func<TEntidade, bool>> predicado);
    }
}
