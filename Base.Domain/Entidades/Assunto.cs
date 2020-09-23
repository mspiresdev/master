using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Base.Domain.Entidades
{
    public class Assunto : EntidadeBase
    {
        public string Descricao { get; set; }

       
        public List<LivroAssunto> LivroAssuntos { get; set; }

    }
}
