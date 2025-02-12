using Application.Features.AtualizarCliente;
using Application.Features.Clientes.CadastrarCliente;
using Application.Features.Clientes.ConsultarCliente;
using Application.Features.Clientes.ListarClientes;
using Application.Features.ExcluirCliente;
using Application.Features.Logradouros.AtualizarLogradouro;
using Application.Features.Logradouros.CadastrarLogradouro;
using Application.Features.Logradouros.ExcluirLogradouro;
using Application.Features.Logradouros.ListarLogradouros;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CriarCliente([FromForm] CadastrarClienteRequest request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(ConsultarCliente), new { email = response.Email }, response);
        }

        /// <summary>
        /// Consulta um cliente pelo e-mail.
        /// </summary>
        [HttpGet("{email}")]
        public async Task<IActionResult> ConsultarCliente(string email)
        {
            var query = new ConsultarClienteRequest(email);
            var cliente = await _mediator.Send(query);

            return cliente != null ? Ok(cliente) : NotFound("Cliente não encontrado.");
        }

        /// <summary>
        /// Lista todos os clientes cadastrados
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ListarClientes()
        {
            var query = new ListarClientesRequest();
            var clientes = await _mediator.Send(query);

            return Ok(clientes);
        }

        [Authorize]
        [HttpPut("{email}")]
        public async Task<IActionResult> AtualizarCliente(string email, [FromForm] AtualizarClienteRequest request)
        {
            request.Email = email;

            var sucesso = await _mediator.Send(request);

            if (sucesso)
            {
                return NoContent();
            }

            return NotFound("Cliente não encontrado.");
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> ExcluirCliente(string email)
        {
            var comando = new ExcluirClienteRequest(email);
            var sucesso = await _mediator.Send(comando);

            if (sucesso)
            {
                return NoContent(); 
            }

            return NotFound("Cliente não encontrado.");
        }


        [HttpPost("{clienteEmail}/logradouros")]
        public async Task<IActionResult> CriarLogradouro(string clienteEmail, [FromBody] CadastrarLogradouroRequest request)
        {
            request.ClienteEmail = clienteEmail;

            var response = await _mediator.Send(request);

            return CreatedAtAction(nameof(ListarLogradouros), new { clienteEmail = clienteEmail }, response);
        }


        [HttpGet("{clienteEmail}/logradouros")]
        public async Task<IActionResult> ListarLogradouros(string clienteEmail)
        {
            var query = new ListarLogradourosRequest(clienteEmail);
            var logradouros = await _mediator.Send(query);

            if (logradouros.Count == 0)
                return NotFound("Nenhum logradouro encontrado.");

            return Ok(logradouros);
        }


        [HttpPut("logradouros/{id}")]
        public async Task<IActionResult> AtualizarLogradouro(Guid id, [FromBody] AtualizarLogradouroRequest request)
        {
            request.Id = id;
            var sucesso = await _mediator.Send(request);

            if (sucesso)
            {
                return NoContent(); 
            }

            return BadRequest("Erro ao atualizar logradouro.");
        }

        [HttpDelete("logradouros/{id}")]
        public async Task<IActionResult> ExcluirLogradouro(Guid id)
        {
            var comando = new ExcluirLogradouroRequest(id);
            var sucesso = await _mediator.Send(comando);

            if (sucesso)
            {
                return NoContent(); 
            }

            return BadRequest("Erro ao excluir logradouro.");
        }

    }
}
