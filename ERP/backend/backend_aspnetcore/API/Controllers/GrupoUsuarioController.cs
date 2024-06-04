using BLL;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrupoUsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(GrupoUsuario _grupoUsuario)
        {
            if (_grupoUsuario == null)
                return BadRequest("Registro inválido");

            try
            {
                new GrupoUsuarioBLL().Inserir(_grupoUsuario);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _grupoUsuario.Id }, _grupoUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var grupoUsuarioList = new GrupoUsuarioBLL().BuscarTodos();

                if (grupoUsuarioList == null || grupoUsuarioList.Count == 0)
                    //return NotFound();
                    Console.WriteLine("Registro não encontrado");

                return Ok(grupoUsuarioList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            try
            {
                var grupoUsuario = new GrupoUsuarioBLL().BuscarPorId(_id);

                if (grupoUsuario == null)
                    return NotFound();

                return Ok(grupoUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, GrupoUsuario _grupoUsuario)
        {
            try
            {
                new GrupoUsuarioBLL().Alterar(_grupoUsuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            try
            {
                new GrupoUsuarioBLL().Excluir(_id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}