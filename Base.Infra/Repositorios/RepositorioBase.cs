using Base.Domain.Entidades;
using Base.Domain.Intefaces.Repositorios;
using Base.Infra.Contextos;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Data.SqlClient;

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

        public virtual void Alterar(TEntidade entidade)
        {
            contexto.InitTransacao();
            contexto.Set<TEntidade>().Attach(entidade);
            contexto.Entry(entidade).State = EntityState.Modified;
            contexto.SendChanges();
        }

        public virtual void Excluir(int id)
        {
            try
            {
                var entidade = SelecionarPorId(id);
                if (entidade != null)
                {
                    contexto.InitTransacao();
                    contexto.Set<TEntidade>().Remove(entidade);
                    contexto.SendChanges();
                }
            }
            catch (Exception ex)
            {
                throw GetTypeError(ex, "DELETE");
            }
            
        }



        private Exception GetTypeError(Exception ex, string action)
        {
            if(ex.InnerException != null)
            {
                if(ex.InnerException.Message.Contains("FK") && action == "DELETE" )
                        return new Exception("Item está em sendo utilizado.");
               
            }
            return ex;
        }

        public virtual void Excluir(TEntidade entidade)
        {
            contexto.InitTransacao();
            contexto.Set<TEntidade>().Remove(entidade);
            contexto.SendChanges();
        }

        public virtual int Incluir(TEntidade entidade)
        {
            contexto.InitTransacao();
            var id = contexto.Set<TEntidade>().Add(entidade).Entity.Id;
            contexto.SendChanges();
            return id;
        }

        public virtual TEntidade SelecionarPorId(int id)
        {
            return contexto.Set<TEntidade>().Find(id);
        }

        public virtual IEnumerable<TEntidade> SelecionarAllPorId(int id)
        {
            return contexto.Set<TEntidade>().Where(u=> u.Id == id);
        }

        public virtual IEnumerable<TEntidade> SelecionarTodos()
        {
            return contexto.Set<TEntidade>().ToList();
        }
    }
}
