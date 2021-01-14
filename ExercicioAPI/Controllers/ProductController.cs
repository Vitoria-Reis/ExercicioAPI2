using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using exercicio.Data;
using exercicio.Models;

namespace exercicio.Controllers
{
    [ApiController]
    [Route("v1/prestacoes")]
    public class PrestacaoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Prestacao>>> Get([FromServices] DataContext context)
        {
            var prestacao = await context.Prestacao.Include(x => x.Contrato).ToListAsync();
            return prestacao;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Prestacao>> GetById([FromServices] DataContext context, int id)
        {
            var prestacao = await context.Prestacao.Include(x => x.Contrato).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return prestacao;
        }

        [HttpGet]
        [Route("contratos/{id:int}")]
        public async Task<ActionResult<List<Prestacao>>> GetByContrato([FromServices] DataContext context, int id)
        {
            var prestacoes = await context.Prestacao.Include(x => x.Contrato).AsNoTracking().Where(x => x.ContratoId == id).ToListAsync();
            return prestacoes;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Prestacao>> Post([FromServices] DataContext context, [FromBody] Prestacao model)
        {
            if (ModelState.IsValid)
            {
                context.Prestacao.Add(model);
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