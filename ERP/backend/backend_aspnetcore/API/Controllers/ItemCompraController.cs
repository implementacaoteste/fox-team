using BLL;
using Infra;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemCompraController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(ItemCompra _itemCompra)
        {
            string erro;
            if (_itemCompra == null)
            {
                erro = Texto.Verbose(nameof(ItemCompra), Mensagem.EntidadeNula);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}");
                return BadRequest(erro);
            }

            try
            {
                new ItemCompraBLL().Inserir(_itemCompra);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _itemCompra.Id }, _itemCompra);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemCompra), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            Log.GravarLog($"Buscando todos os registros de {Texto.Verbose(nameof(ItemCompra)).ToLower()}.");
            string erro;
            try
            {
                var itemCompraList = new ItemCompraBLL().BuscarTodos();

                if (itemCompraList == null || itemCompraList.Count == 0)
                {
                    erro = Texto.Verbose(nameof(ItemCompra), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(itemCompraList)}");
                return Ok(itemCompraList);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemCompra), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            Log.GravarLog($"Buscando registro de {Texto.Verbose(nameof(ItemCompra)).ToLower()} por id: {_id}");
            string erro;
            try
            {
                var itemCompra = new ItemCompraBLL().BuscarPorId(_id);

                if (itemCompra == null)
                {
                    erro = Texto.Verbose(nameof(ItemCompra), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(itemCompra)}");
                return Ok(itemCompra);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemCompra), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, ItemCompra _itemCompra)
        {
            Log.GravarLog($"Alterando registro de {Texto.Verbose(nameof(ItemCompra))}: {JsonConvert.SerializeObject(_itemCompra)}");
            string erro;
            try
            {
                new ItemCompraBLL().Alterar(_itemCompra);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(ItemCompra))} alterado com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemCompra), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            Log.GravarLog($"Excluindo registro de {Texto.Verbose(nameof(ItemCompra))}: {_id}");
            string erro;
            try
            {
                new ItemCompraBLL().Excluir(_id);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(ItemCompra))} excluído com sucesso: {_id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemCompra), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
    }
}