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
        IAutorRepositorio _repositorio;
        public AutorServico(IAutorRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public dynamic Report()
        {
           return _repositorio.Report();
        }
    }
}
