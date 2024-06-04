using BLL;
using Models;
using Microsoft.AspNetCore.Mvc;
using DAL;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteBLL clienteBLL;

        public ClienteController()
        {
            clienteBLL = new ClienteBLL();
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var clientes = clienteBLL.BuscarTodos();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var cliente = clienteBLL.BuscarPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Inserir(Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Cliente inválido");
            }

            try
            {
                clienteBLL.Inserir(cliente);
                return CreatedAtAction(nameof(BuscarPorId), new { id = cliente.Id }, cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Cliente cliente)
        {
            if (cliente == null || id != cliente.Id)
            {
                return BadRequest("Dados do cliente inválidos");
            }

            var clienteExistente = clienteBLL.BuscarPorId(id);
            if (clienteExistente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            try
            {
                clienteBLL.Alterar(cliente);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var cliente = clienteBLL.BuscarPorId(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            try
            {
                clienteBLL.Excluir(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }
    }
}
