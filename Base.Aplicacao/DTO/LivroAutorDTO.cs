using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Aplicacao.DTO
{
    public class LivroAutorDTO 
    {


        //
        public virtual LivroDTO Livro { get; set; }

        public int? Livro_Id { get; set; }

        public virtual AutorDTO Autor { get; set; }

        public int? Autor_Id { get; set; }
    }
}
