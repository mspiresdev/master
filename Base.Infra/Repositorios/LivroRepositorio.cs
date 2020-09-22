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

        public override int Incluir(Livro entidade)
        {
             base.Incluir(entidade);
            ILivroAssuntoRepositorio LivroAssuntoRep = new LivroAssuntoRepositorio(contexto);
            ILivroAutorRepositorio LivroAutorRep = new LivroAutorRepositorio(contexto);
            entidade.Assuntos.ToList().ForEach(f => LivroAssuntoRep.Incluir(new LivroAssunto() { Assunto_Id = f.Id,  Livro_Id = entidade.Id, Id= f.Id } ));
            entidade.Autors.ToList().ForEach(f => LivroAutorRep.Incluir(new LivroAutor() { Autor_Id = f.Id, Livro_Id = entidade.Id, Id = f.Id }));
            return entidade.Id;
        }

        public override Livro SelecionarPorId(int id)
        {
            ILivroAssuntoRepositorio LivroAssuntoRep = new LivroAssuntoRepositorio(contexto);
            ILivroAutorRepositorio LivroAutorRep = new LivroAutorRepositorio(contexto);
            IAssuntoRepositorio AssuntoRep = new AssuntoRepositorio(contexto);
            IAutorRepositorio AutorRep = new AutorRepositorio(contexto);
            var livro = base.SelecionarPorId(id);
            var ass = LivroAssuntoRep.SelecionarTodos().Where(u=> u.Livro_Id == livro.Id).Select(s=> s.Assunto_Id).ToList();
            var aus = LivroAutorRep.SelecionarTodos().Where(u => u.Livro_Id == livro.Id).Select(s => s.Autor_Id).ToList(); ;
            livro.Assuntos = AssuntoRep.SelecionarTodos().Where(a => ass.Contains(a.Id)).ToList();
            livro.Autors = AutorRep.SelecionarTodos().Where(a => aus.Contains(a.Id)).ToList();
            return livro;
        }
    }
}
