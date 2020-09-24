using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Aplicacao.DTO
{
    public class AssuntoDTO : DTOBase
    {
        [Required]
        public string Descricao { get; set; }
        

    }
}
