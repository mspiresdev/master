using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Base.Domain.Entidades
{
    public class Livro : EntidadeBase
    {
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public decimal Preco { get; set; }
        [NotMapped]
        public List<Autor> Autors { get; set; }
        [NotMapped]
        public List<Assunto> Assuntos { get; set; }

        public List<LivroAutor> LivroAutors { get; set; }
        
        public List<LivroAssunto> LivroAssuntos { get; set; }
        //
        public Livro()
        {
            LivroAutors = new List<LivroAutor>();
            LivroAssuntos = new List<LivroAssunto>();
        }
    }
}
