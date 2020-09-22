﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Domain.Entidades
{
    public class Assunto : EntidadeBase
    {
        public string Descricao { get; set; }

        //
        public virtual Livro Livro { get; set; }

        public int? Livro_Id { get; set; }

        public ICollection<LivroAssunto> LAssuntos { get; set; }
    }
}
