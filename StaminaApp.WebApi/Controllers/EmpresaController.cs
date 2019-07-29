using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StaminaApp.Core.Commands;
using StaminaApp.Domain.Compania.Commands;
using StaminaApp.Domain.Compania.Entidades;
using StaminaApp.Domain.Compania.Handlers;
using StaminaApp.Domain.Compania.Querys;
using StaminaApp.Domain.Repositorios;

namespace StaminaApp.WebApi.Controllers
{
    [Route("api/empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmpresaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            // EmpresaQueries queries = new EmpresaQueries(_empresaRepository);
            // var respoesta = _empresaRepository.FindAllEmpresas();
            // if (respoesta.Any())
            // {
            //     return Ok(respoesta);
            // }
            return NoContent();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // var respoesta = _empresaRepository.FindEmpresa(id);
            // if (respoesta != null)
            // {
            //     return Ok(respoesta);
            // }
            return NoContent();
        }

        [HttpPost("{id}/adicionar/centro-custo")]
        public async Task<IActionResult> Post([FromBody] CadastrarCentroCustoCommand command)
        {
            var response =  (CommandResult) await _mediator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CadastrarEmpresaCommand command)
        {
            var response =  (CommandResult) await _mediator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditarEmpresaCommand command)
        {
            var response =  (CommandResult) await _mediator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete("{id}/{cnpj}")]
        public async Task<IActionResult> Delete(string id, string cnpj)
        {
            DeletarEmpresaCommand command = new DeletarEmpresaCommand
            {
                Id = Convert.ToInt32(id),
                Cnpj = cnpj
            };
            var response =  (CommandResult) await _mediator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest();
        }
    }
}