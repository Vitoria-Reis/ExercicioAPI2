using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using exercicio.Data;
using exercicio.Models;

namespace exercicio.Controllers
{
    [ApiController]
    [Route("v1/contratos")]
    public class ContratoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Contrato>>> Get([FromServices] DataContext context)
        {
            var contratos = await context.Contrato.ToListAsync();
            return contratos;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Contrato>> Post([FromServices] DataContext context, [FromBody] Contrato model)
        {
            if (ModelState.IsValid)
            {
                context.Contrato.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else 
            {
                return BadRequest(ModelState);
            }
        }
    }
}