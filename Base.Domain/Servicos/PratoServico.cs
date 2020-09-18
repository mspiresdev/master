using Base.Domain.Entidades;
using Base.Domain.Intefaces.Repositorios;
using Base.Domain.Intefaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Domain.Servicos
{
    public class PratoServico : ServicoBase<Prato>, IPratoServico
    {
        public PratoServico(IPratoRepositorio repositorio)
            : base(repositorio)
        {

        }
    }
}
