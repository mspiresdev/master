using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Aplicacao.DTO
{
    public class LivroAssuntoDTO 
    {
        public virtual LivroDTO Livro { get; set; }

        public int? LivroId { get; set; }

        public virtual AssuntoDTO Assunto { get; set; }

        public int? AssuntoId { get; set; }
    }
}
