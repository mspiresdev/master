using Base.Domain.Entidades;
using Base.Domain.Intefaces.Repositorios;
using Base.Infra.Contextos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Base.Infra.Repositorios
{
    public class LivroRepositorio : RepositorioBase<Livro>, ILivroRepositorio
    {
        public LivroRepositorio(Contexto contexto)
            : base(contexto)
        {
        }

        
        public override IEnumerable<Livro> SelecionarTodos()
        {
            return contexto.Livros.ToList();
        }
        public override Livro SelecionarPorId(int id)
        {
          var lau = contexto.LivroAutor.ToList();
            var las = contexto.LivroAssunto.ToList();
            var lu = contexto.Autors.ToList();
            var ls = contexto.Assuntos.ToList();
            var livro = contexto.Livros.FirstOrDefault();

            return livro;
        }
    }
}
