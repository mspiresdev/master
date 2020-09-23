using AutoMapper;
using Base.Aplicacao.DTO;
using Base.Aplicacao.Interfaces;
using Base.Domain.Entidades;
using Base.Domain.Intefaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Base.Aplicacao.Servicos
{
    public class LivroApp : ServicoAppBase<Livro, LivroDTO>, ILivroApp
    {
        public LivroApp(IMapper iMapper, ILivroServico servico)
            : base(iMapper, servico)
        {

        }

        public override int Incluir(LivroDTO entidade)
        {
            entidade.LivroAssuntos = entidade.Assuntos.Select(s => new LivroAssuntoDTO() { AssuntoId = s.Id }).ToList();
            entidade.LivroAutors = entidade.Autors.Select(s => new LivroAutorDTO() { Autor_Id = s.Id }).ToList();
            return base.Incluir(entidade);
        }

       
    }
}
