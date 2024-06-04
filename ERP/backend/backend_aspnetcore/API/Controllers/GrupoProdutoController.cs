using BLL;
using Infra;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrupoProdutoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(GrupoProduto _grupoProduto)
        {
            string erro;
            if (_grupoProduto == null)
            {
                erro = Texto.Verbose(nameof(GrupoProduto), Mensagem.EntidadeNula);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}");
                return BadRequest(erro);
            }

            try
            {
                new GrupoProdutoBLL().Inserir(_grupoProduto);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _grupoProduto.Id }, _grupoProduto);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(GrupoProduto), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            Log.GravarLog($"Buscando todos os registros de {Texto.Verbose(nameof(GrupoProduto)).ToLower()}.");
            string erro;
            try
            {
                var grupoProdutoList = new GrupoProdutoBLL().BuscarTodos();

                if (grupoProdutoList == null || grupoProdutoList.Count == 0)
                {
                    erro = Texto.Verbose(nameof(GrupoProduto), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(grupoProdutoList)}");
                return Ok(grupoProdutoList);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(GrupoProduto), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            Log.GravarLog($"Buscando registro de {Texto.Verbose(nameof(GrupoProduto)).ToLower()} por id: {_id}");
            string erro;
            try
            {
                var grupoProduto = new GrupoProdutoBLL().BuscarPorId(_id);

                if (grupoProduto == null)
                {
                    erro = Texto.Verbose(nameof(GrupoProduto), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(grupoProduto)}");
                return Ok(grupoProduto);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(GrupoProduto), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, GrupoProduto _grupoProduto)
        {
            Log.GravarLog($"Alterando registro de {Texto.Verbose(nameof(GrupoProduto))}: {JsonConvert.SerializeObject(_grupoProduto)}");
            string erro;
            try
            {
                new GrupoProdutoBLL().Alterar(_grupoProduto);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(GrupoProduto))} alterado com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(GrupoProduto), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            Log.GravarLog($"Excluindo registro de {Texto.Verbose(nameof(GrupoProduto))}: {_id}");
            string erro;
            try
            {
                new GrupoProdutoBLL().Excluir(_id);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(GrupoProduto))} excluído com sucesso: {_id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(GrupoProduto), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
    }
}