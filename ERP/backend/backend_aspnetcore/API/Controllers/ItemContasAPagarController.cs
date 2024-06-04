using BLL;
using Infra;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemContasAPagarController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(ItemContasAPagar _itemContasAPagar)
        {
            string erro;
            if (_itemContasAPagar == null)
            {
                erro = Texto.Verbose(nameof(ItemContasAPagar), Mensagem.EntidadeNula);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}");
                return BadRequest(erro);
            }

            try
            {
                new ItemContasAPagarBLL().Inserir(_itemContasAPagar);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _itemContasAPagar.Id }, _itemContasAPagar);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemContasAPagar), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            Log.GravarLog($"Buscando todos os registros de {Texto.Verbose(nameof(ItemContasAPagar)).ToLower()}.");
            string erro;
            try
            {
                var itemContasAPagarList = new ItemContasAPagarBLL().BuscarTodos();

                if (itemContasAPagarList == null || itemContasAPagarList.Count == 0)
                {
                    erro = Texto.Verbose(nameof(ItemContasAPagar), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(itemContasAPagarList)}");
                return Ok(itemContasAPagarList);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemContasAPagar), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            Log.GravarLog($"Buscando registro de {Texto.Verbose(nameof(ItemContasAPagar)).ToLower()} por id: {_id}");
            string erro;
            try
            {
                var itemContasAPagar = new ItemContasAPagarBLL().BuscarPorId(_id);

                if (itemContasAPagar == null)
                {
                    erro = Texto.Verbose(nameof(ItemContasAPagar), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(itemContasAPagar)}");
                return Ok(itemContasAPagar);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemContasAPagar), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, ItemContasAPagar _itemContasAPagar)
        {
            Log.GravarLog($"Alterando registro de {Texto.Verbose(nameof(ItemContasAPagar))}: {JsonConvert.SerializeObject(_itemContasAPagar)}");
            string erro;
            try
            {
                new ItemContasAPagarBLL().Alterar(_itemContasAPagar);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(ItemContasAPagar))} alterado com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemContasAPagar), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            Log.GravarLog($"Excluindo registro de {Texto.Verbose(nameof(ItemContasAPagar))}: {_id}");
            string erro;
            try
            {
                new ItemContasAPagarBLL().Excluir(_id);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(ItemContasAPagar))} excluído com sucesso: {_id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemContasAPagar), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
    }
}