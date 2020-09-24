using Base.Aplicacao.DTO;
using Base.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Aplicacao.Interfaces
{
    public interface IAutorApp : IAppBase<Autor, AutorDTO>
    {
        dynamic Report();
    }
}
