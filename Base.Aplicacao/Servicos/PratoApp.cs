using AutoMapper;
using Base.Aplicacao.DTO;
using Base.Aplicacao.Interfaces;
using Base.Domain.Entidades;
using Base.Domain.Intefaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Aplicacao.Servicos
{
    public class PratoApp : ServicoAppBase<Prato, PratoDTO>, IPratoApp
    {
        public PratoApp(IMapper iMapper, IPratoServico servico)
            : base(iMapper, servico)
        {

        }
    }
}
