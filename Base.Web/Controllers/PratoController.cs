using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Base.Web.Models;
using Base.Aplicacao.Interfaces;
using Base.Domain.Entidades;
using Base.Aplicacao.DTO;

namespace Base.Web.Controllers
{
    public class PratoController : ControllerBase<Prato, PratoDTO>
    {
        public PratoController(IPratoApp app)
            : base(app)
        { }
    }
}
