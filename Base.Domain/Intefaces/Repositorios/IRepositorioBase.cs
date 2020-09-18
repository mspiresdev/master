using Base.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Domain.Intefaces.Repositorios
{
    public interface IRepositorioBase<TEntidade>
         where TEntidade : EntidadeBase
    {
        int Incluir(TEntidade entidade);
        void Excluir(int id);
        void Excluir(TEntidade entidade);
        void Alterar(TEntidade entidade);
        TEntidade SelecionarPorId(int id);
        IEnumerable<TEntidade> SelecionarTodos();
    }
}
