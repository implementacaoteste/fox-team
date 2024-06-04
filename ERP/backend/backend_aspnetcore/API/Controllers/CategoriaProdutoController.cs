using BLL;
using Infra;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaProdutoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(CategoriaProduto _categoriaProduto)
        {
            string erro;
            if (_categoriaProduto == null)
            {
                erro = Texto.Verbose(nameof(CategoriaProduto), Mensagem.EntidadeNula);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}");
                return BadRequest(erro);
            }

            try
            {
                new CategoriaProdutoBLL().Inserir(_categoriaProduto);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _categoriaProduto.Id }, _categoriaProduto);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(CategoriaProduto), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            Log.GravarLog($"Buscando todos os registros de {Texto.Verbose(nameof(CategoriaProduto)).ToLower()}.");
            string erro;
            try
            {
                var categoriaProdutoList = new CategoriaProdutoBLL().BuscarTodos();

                if (categoriaProdutoList == null || categoriaProdutoList.Count == 0)
                {
                    erro = Texto.Verbose(nameof(CategoriaProduto), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(categoriaProdutoList)}");
                return Ok(categoriaProdutoList);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(CategoriaProduto), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            Log.GravarLog($"Buscando registro de {Texto.Verbose(nameof(CategoriaProduto)).ToLower()} por id: {_id}");
            string erro;
            try
            {
                var categoriaProduto = new CategoriaProdutoBLL().BuscarPorId(_id);

                if (categoriaProduto == null)
                {
                    erro = Texto.Verbose(nameof(CategoriaProduto), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(categoriaProduto)}");
                return Ok(categoriaProduto);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(CategoriaProduto), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, CategoriaProduto _categoriaProduto)
        {
            Log.GravarLog($"Alterando registro de {Texto.Verbose(nameof(CategoriaProduto))}: {JsonConvert.SerializeObject(_categoriaProduto)}");
            string erro;
            try
            {
                new CategoriaProdutoBLL().Alterar(_categoriaProduto);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(CategoriaProduto))} alterado com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(CategoriaProduto), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            Log.GravarLog($"Excluindo registro de {Texto.Verbose(nameof(CategoriaProduto))}: {_id}");
            string erro;
            try
            {
                new CategoriaProdutoBLL().Excluir(_id);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(CategoriaProduto))} excluído com sucesso: {_id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(CategoriaProduto), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
    }
}