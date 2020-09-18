using Base.Domain.Entidades;
using Base.Domain.Intefaces.Repositorios;
using Base.Infra.Contextos;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace Base.Infra.Repositorios
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade>
        where TEntidade : EntidadeBase
    {
        protected readonly Contexto contexto;

        public RepositorioBase(Contexto contexto)
            : base()
        {
            this.contexto = contexto;
        }

        public void Alterar(TEntidade entidade)
        {
            contexto.InitTransacao();
            contexto.Set<TEntidade>().Attach(entidade);
            contexto.Entry(entidade).State = EntityState.Modified;
            contexto.SendChanges();
        }

        public void Excluir(int id)
        {
            var entidade = SelecionarPorId(id);
            if (entidade != null)
            {
                contexto.InitTransacao();
                contexto.Set<TEntidade>().Remove(entidade);
                contexto.SendChanges();
            }
        }

        public void Excluir(TEntidade entidade)
        {
            contexto.InitTransacao();
            contexto.Set<TEntidade>().Remove(entidade);
            contexto.SendChanges();
        }

        public int Incluir(TEntidade entidade)
        {
            contexto.InitTransacao();
            var id = contexto.Set<TEntidade>().Add(entidade).Entity.Id;
            contexto.SendChanges();
            return id;
        }

        public TEntidade SelecionarPorId(int id)
        {
            return contexto.Set<TEntidade>().Find(id);
        }

        public IEnumerable<TEntidade> SelecionarTodos()
        {
            return contexto.Set<TEntidade>().ToList();
        }
    }
}
