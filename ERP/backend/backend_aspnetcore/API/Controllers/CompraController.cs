using BLL;
using Infra;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompraController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(Compra _compra)
        {
            string erro;
            if (_compra == null)
            {
                erro = Texto.Verbose(nameof(Compra), Mensagem.EntidadeNula);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}");
                return BadRequest(erro);
            }

            try
            {
                new CompraBLL().Inserir(_compra);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _compra.Id }, _compra);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Compra), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            Log.GravarLog($"Buscando todos os registros de {Texto.Verbose(nameof(Compra)).ToLower()}.");
            string erro;
            try
            {
                var compraList = new CompraBLL().BuscarTodos();

                if (compraList == null || compraList.Count == 0)
                {
                    erro = Texto.Verbose(nameof(Compra), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(compraList)}");
                return Ok(compraList);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Compra), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            Log.GravarLog($"Buscando registro de {Texto.Verbose(nameof(Compra)).ToLower()} por id: {_id}");
            string erro;
            try
            {
                var compra = new CompraBLL().BuscarPorId(_id);

                if (compra == null)
                {
                    erro = Texto.Verbose(nameof(Compra), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(compra)}");
                return Ok(compra);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Compra), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, Compra _compra)
        {
            Log.GravarLog($"Alterando registro de {Texto.Verbose(nameof(Compra))}: {JsonConvert.SerializeObject(_compra)}");
            string erro;
            try
            {
                new CompraBLL().Alterar(_compra);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(Compra))} alterado com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Compra), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            Log.GravarLog($"Excluindo registro de {Texto.Verbose(nameof(Compra))}: {_id}");
            string erro;
            try
            {
                new CompraBLL().Excluir(_id);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(Compra))} excluído com sucesso: {_id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Compra), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
    }
}