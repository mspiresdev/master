using Base.Domain.Entidades;
using Base.Domain.Intefaces.Repositorios;
using Base.Infra.Contextos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Infra.Repositorios
{
    public class LivroRepositorio : RepositorioBase<Livro>, ILivroRepositorio
    {
        public LivroRepositorio(Contexto contexto)
            : base(contexto)
        {
        }
    }
}
