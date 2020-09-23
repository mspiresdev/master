using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Domain.Entidades
{
    public class LivroAssunto : EntidadeBase
    {
        

        //
        public virtual Livro Livro { get; set; }

       public int? LivroId { get; set; }

        public virtual Assunto Assunto { get; set; }

        public int? AssuntoId { get; set; }
    }
}
