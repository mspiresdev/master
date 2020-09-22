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
    public class AssuntoApp : ServicoAppBase<Assunto, AssuntoDTO>, IAssuntoApp
    {
        public AssuntoApp(IMapper iMapper, IAssuntoServico servico)
            : base(iMapper, servico)
        {

        }
    }
}
