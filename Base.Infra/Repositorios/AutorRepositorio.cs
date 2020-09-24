using Base.Domain.Entidades;
using Base.Domain.Intefaces.Repositorios;
using Base.Infra.Contextos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Base.Infra.Repositorios
{
    public class AutorRepositorio : RepositorioBase<Autor>, IAutorRepositorio
    {
        public AutorRepositorio(Contexto contexto)
            : base(contexto)
        {
        }
        public dynamic Report()
        {
           return  contexto.Autors.Select(s => new
            {
                s.Nome,
                Livros = s.LivroAutors.Select(ls => ls.Livro)
            }).ToList();
        }
       
    }
}
