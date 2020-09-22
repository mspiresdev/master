using Base.Domain.Entidades;
using Base.Domain.Intefaces.Repositorios;
using Base.Infra.Contextos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Base.Infra.Repositorios
{
    public class LivroAutorRepositorio : RepositorioBase<LivroAutor>, ILivroAutorRepositorio
    {
        public LivroAutorRepositorio(Contexto contexto)
            : base(contexto)
        {
        }

        
    }
}
