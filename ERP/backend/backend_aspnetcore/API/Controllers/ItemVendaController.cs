using BLL;
using Infra;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemVendaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(ItemVenda _itemVenda)
        {
            string erro;
            if (_itemVenda == null)
            {
                erro = Texto.Verbose(nameof(ItemVenda), Mensagem.EntidadeNula);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}");
                return BadRequest(erro);
            }

            try
            {
                new ItemVendaBLL().Inserir(_itemVenda);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _itemVenda.Id }, _itemVenda);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemVenda), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            Log.GravarLog($"Buscando todos os registros de {Texto.Verbose(nameof(ItemVenda)).ToLower()}.");
            string erro;
            try
            {
                var itemVendaList = new ItemVendaBLL().BuscarTodos();

                if (itemVendaList == null || itemVendaList.Count == 0)
                {
                    erro = Texto.Verbose(nameof(ItemVenda), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(itemVendaList)}");
                return Ok(itemVendaList);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemVenda), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            Log.GravarLog($"Buscando registro de {Texto.Verbose(nameof(ItemVenda)).ToLower()} por id: {_id}");
            string erro;
            try
            {
                var itemVenda = new ItemVendaBLL().BuscarPorId(_id);

                if (itemVenda == null)
                {
                    erro = Texto.Verbose(nameof(ItemVenda), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(itemVenda)}");
                return Ok(itemVenda);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemVenda), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, ItemVenda _itemVenda)
        {
            Log.GravarLog($"Alterando registro de {Texto.Verbose(nameof(ItemVenda))}: {JsonConvert.SerializeObject(_itemVenda)}");
            string erro;
            try
            {
                new ItemVendaBLL().Alterar(_itemVenda);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(ItemVenda))} alterado com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemVenda), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            Log.GravarLog($"Excluindo registro de {Texto.Verbose(nameof(ItemVenda))}: {_id}");
            string erro;
            try
            {
                new ItemVendaBLL().Excluir(_id);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(ItemVenda))} excluído com sucesso: {_id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemVenda), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
    }
}