using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Domain.Entidades
{
    public class Livro : EntidadeBase
    {
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        //

    }
}
