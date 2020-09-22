using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Base.Aplicacao.DTO
{
    public class LivroDTO : DTOBase
    {
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }

        public List<AutorDTO> Autors { get; set; }
        public List<AssuntoDTO> Assuntos { get; set; }

        public ICollection<LivroAutorDTO> LAutors { get; set; }
        public ICollection<LivroAssuntoDTO> LAssuntos { get; set; }
       
    }
}
