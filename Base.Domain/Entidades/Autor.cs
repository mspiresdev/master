using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Domain.Entidades
{
    public class Autor : EntidadeBase
    {
        public string Nome { get; set; }

        //
        public virtual Livro Livro { get; set; }

        public int? Livro_Id { get; set; }

        public ICollection<LivroAutor> LAutors { get; set; }
    }
}

