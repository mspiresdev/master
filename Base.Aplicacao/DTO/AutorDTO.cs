using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Aplicacao.DTO
{
    public class AutorDTO : DTOBase
    {
        [Required]
        public string Nome { get; set; }
        
       
    }
}
