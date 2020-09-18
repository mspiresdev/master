using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Aplicacao.DTO
{
    public class LivroDTO : DTOBase
    {
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }

    }
}
