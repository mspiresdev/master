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
    public class AutorApp : ServicoAppBase<Autor, AutorDTO>, IAutorApp
    {
        public AutorApp(IMapper iMapper, IAutorServico servico)
            : base(iMapper, servico)
        {

        }
    }
}
