using BLL;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(Produto _produto)
        {
            if (_produto == null)
                return BadRequest("Produto inválido");

            try
            {
                new ProdutoBLL().Inserir(_produto);
                return CreatedAtAction(nameof(BuscarPorId), new { id = _produto.Id }, _produto);
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
                var produtoList = new ProdutoBLL().BuscarTodos();

                if (produtoList == null || produtoList.Count == 0)
                    return NotFound();

                    return Ok(produtoList);
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
                var produto = new ProdutoBLL().BuscarPorId(_id);

                if (produto == null)
                    return NotFound();

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, Produto _produto)
        {
            try
            {
                new ProdutoBLL().Alterar(_produto);
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
                new ProdutoBLL().Excluir(_id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}