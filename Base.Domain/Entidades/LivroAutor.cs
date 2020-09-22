using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Domain.Entidades
{
    public class LivroAutor : EntidadeBase
    {
       

        //
        public virtual Livro Livro { get; set; }

        public int? Livro_Id { get; set; }

        public virtual Autor Autor { get; set; }

        public int? Autor_Id { get; set; }
    }
}
