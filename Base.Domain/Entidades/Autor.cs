using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Base.Domain.Entidades
{
    public class Autor : EntidadeBase
    {
        public string Nome { get; set; }
        
        public List<LivroAutor> LivroAutors { get; set; }
    }
}

