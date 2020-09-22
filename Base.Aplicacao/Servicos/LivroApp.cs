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
        public override LivroDTO SelecionarPorId(int id)
        {
           var obj= base.SelecionarPorId(id);
            obj.Assuntos = obj.LivroAssunto.Select(s => s.Assunto).ToList();
            obj.Autors = obj.LivroAutor.Select(s => s.Autor).ToList();
            obj.LivroAutor = null;
            obj.LivroAssunto = null;
            return obj;
        }
    }
}
