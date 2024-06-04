using BLL;
using System;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioBLL usuarioBLL;

        public UsuarioController()
        {
            usuarioBLL = new UsuarioBLL();
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var usuarios = usuarioBLL.BuscarTodos();
            return Ok(usuarios);
        }

        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            var usuario = usuarioBLL.BuscarPorId(_id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Inserir(Usuario _usuario)
        {
            if (_usuario == null)
            {
                return BadRequest("Usuário inválido");
            }

            try
            {
                usuarioBLL.Inserir(_usuario);
                return CreatedAtAction(nameof(BuscarPorId), new { id = _usuario.Id }, _usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPut("{_id}")]
        public IActionResult Atualizar(int _id, Usuario _usuario)
        {
            if (_usuario == null || _id != _usuario.Id)
            {
                return BadRequest("Dados do usuário inválidos");
            }

            var usuario = usuarioBLL.BuscarPorId(_id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            try
            {
                usuarioBLL.Alterar(_usuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            var usuario = usuarioBLL.BuscarPorId(_id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            try
            {
                usuarioBLL.Excluir(_id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }
    }
}