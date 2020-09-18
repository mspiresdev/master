using Base.Domain.Entidades;
using Base.Domain.Intefaces.Repositorios;
using Base.Domain.Intefaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Domain.Servicos
{
    public class AutorServico : ServicoBase<Autor>, IAutorServico
    {
        public AutorServico(IAutorRepositorio repositorio)
            : base(repositorio)
        {

        }
    }
}
