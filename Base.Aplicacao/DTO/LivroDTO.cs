using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Base.Aplicacao.DTO
{
    public class LivroDTO : DTOBase
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Editora { get; set; }
        [Required]
        public int Edicao { get; set; }
        [Required]
        public string AnoPublicacao { get; set; }
        [Required]
        public decimal Preco { get; set; }

        public List<AutorDTO> Autors { get; set; }
        public List<AssuntoDTO> Assuntos { get; set; }

        [JsonIgnore]
        public List<LivroAutorDTO> LivroAutors { get; set; }
        [JsonIgnore]
        public List<LivroAssuntoDTO> LivroAssuntos { get; set; }
        //
        

    }
}
