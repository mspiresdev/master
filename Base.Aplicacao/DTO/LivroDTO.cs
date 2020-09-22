using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace Base.Aplicacao.DTO
{
    public class LivroDTO : DTOBase
    {
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public decimal Preco { get; set; }

        public List<AutorDTO> Autors { get; set; }
        public List<AssuntoDTO> Assuntos { get; set; }

        [JsonIgnore]
        public List<LivroAutorDTO> LivroAutor { get; set; }
        [JsonIgnore]
        public List<LivroAssuntoDTO> LivroAssunto{ get; set; }
        //
        public LivroDTO()
        {
            Autors = LivroAutor !=null? LivroAutor.Select(s => s.Autor).ToList(): new List<AutorDTO>();
            Assuntos = LivroAssunto != null ?LivroAssunto.Select(s => s.Assunto).ToList(): new List<AssuntoDTO>();
        }

    }
}
