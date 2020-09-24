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
    public class AutorController : ControllerBase<Autor, AutorDTO>
    {
        IAutorApp _app;
        public AutorController(IAutorApp app)
            : base(app)
        {
            _app = app;
        }
        [Route("report")]
        public IActionResult Report()
        {
            try
            {
                
                return new OkObjectResult(_app.Report());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
