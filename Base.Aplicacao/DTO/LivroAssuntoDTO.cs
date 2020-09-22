using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Aplicacao.DTO
{
    public class LivroAssuntoDTO : DTOBase
    {
        public virtual LivroDTO Livro { get; set; }

        public int? Livro_Id { get; set; }

        public virtual AssuntoDTO Assunto { get; set; }

        public int? Assunto_Id { get; set; }
    }
}
