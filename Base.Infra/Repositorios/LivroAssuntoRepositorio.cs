using Base.Domain.Entidades;
using Base.Domain.Intefaces.Repositorios;
using Base.Infra.Contextos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Base.Infra.Repositorios
{
    public class LivroAssuntoRepositorio : RepositorioBase<LivroAssunto>, ILivroAssuntoRepositorio
    {
        public LivroAssuntoRepositorio(Contexto contexto)
            : base(contexto)
        {
        }

        
    }
}
