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
            var livro = contexto.Livros.FirstOrDefault(u=> u.Id == id);
            livro.Assuntos = contexto.LivroAssunto.Where(u => u.LivroId == id).Select(s => s.Assunto).ToList();
            livro.Autors = contexto.LivroAutor.Where(u => u.Livro_Id == id).Select(s => s.Autor).ToList();
            
            return livro;
        }

        //public override int Incluir(Livro entidade)
        //{
        //    contexto.Livros.Add(entidade);
        //    contexto.SaveChanges();
        //    return entidade.Id;
        //}
    }
}
