using Microsoft.EntityFrameworkCore;
using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MinhaAplicacao.Infraestrutura.Repositorios
{
    public abstract class RepositorioBase<TId, TEntidade> : IRepositorioBase<TId, TEntidade>
        where TId : IEquatable<TId>
        where TEntidade : EntidadeBase<TId>
    {
        protected DbSet<TEntidade> Entidade => this._contexto.Set<TEntidade>();

        protected RepositorioBase(MinhaAplicacaoDbContext contexto)
        {
            this._contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        public virtual void Inserir(TEntidade entidade)
        {
            this.Entidade.Add(entidade);
        }

        public virtual void Alterar(TEntidade entidade)
        {
            this.Entidade.Update(entidade);
        }

        public virtual void Deletar(TEntidade entidade)
        {
            this.Entidade.Remove(entidade);
        }

        public virtual IQueryable<TEntidade> SelecionarPorId(TId id)
        {
            return this.Entidade.Where(e => e.Id.Equals(id)).AsNoTracking();
        }

        public virtual IQueryable<TEntidade> SelecionarTodos()
        {
            return this.Entidade.AsNoTracking();
        }

        public virtual IQueryable<TEntidade> SelecionarPor(Expression<Func<TEntidade, bool>> predicado)
        {
            return this.Entidade.Where(predicado).AsNoTracking();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._contexto.Dispose();
                }

                this._disposed = true;
            }
        }

        ~RepositorioBase()
        {
            this.Dispose(false);
        }

        private readonly MinhaAplicacaoDbContext _contexto;
        private bool _disposed;
    }
}
