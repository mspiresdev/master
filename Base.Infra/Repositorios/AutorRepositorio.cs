using Base.Domain.Entidades;
using Base.Domain.Intefaces.Repositorios;
using Base.Infra.Contextos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Infra.Repositorios
{
    public class AutorRepositorio : RepositorioBase<Autor>, IAutorRepositorio
    {
        public AutorRepositorio(Contexto contexto)
            : base(contexto)
        {
        }
    }
}
