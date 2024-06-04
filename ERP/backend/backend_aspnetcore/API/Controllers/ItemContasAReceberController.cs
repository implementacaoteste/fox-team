using BLL;
using Infra;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemContasAReceberController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(ItemContasAReceber _itemContaAReceber)
        {
            string erro;
            if (_itemContaAReceber == null)
            {
                erro = Texto.Verbose(nameof(ItemContasAReceber), Mensagem.EntidadeNula);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}");
                return BadRequest(erro);
            }

            try
            {
                new ItemContasAReceberBLL().Inserir(_itemContaAReceber);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _itemContaAReceber.Id }, _itemContaAReceber);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemContasAReceber), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            Log.GravarLog($"Buscando todos os registros de {Texto.Verbose(nameof(ItemContasAReceber)).ToLower()}.");
            string erro;
            try
            {
                var itemContaAReceberList = new ItemContasAReceberBLL().BuscarTodos();

                if (itemContaAReceberList == null || itemContaAReceberList.Count == 0)
                {
                    erro = Texto.Verbose(nameof(ItemContasAReceber), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(itemContaAReceberList)}");
                return Ok(itemContaAReceberList);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemContasAReceber), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            Log.GravarLog($"Buscando registro de {Texto.Verbose(nameof(ItemContasAReceber)).ToLower()} por id: {_id}");
            string erro;
            try
            {
                var itemContaAReceber = new ItemContasAReceberBLL().BuscarPorId(_id);

                if (itemContaAReceber == null)
                {
                    erro = Texto.Verbose(nameof(ItemContasAReceber), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(itemContaAReceber)}");
                return Ok(itemContaAReceber);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemContasAReceber), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, ItemContasAReceber _itemContaAReceber)
        {
            Log.GravarLog($"Alterando registro de {Texto.Verbose(nameof(ItemContasAReceber))}: {JsonConvert.SerializeObject(_itemContaAReceber)}");
            string erro;
            try
            {
                new ItemContasAReceberBLL().Alterar(_itemContaAReceber);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(ItemContasAReceber))} alterado com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemContasAReceber), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            Log.GravarLog($"Excluindo registro de {Texto.Verbose(nameof(ItemContasAReceber))}: {_id}");
            string erro;
            try
            {
                new ItemContasAReceberBLL().Excluir(_id);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(ItemContasAReceber))} excluído com sucesso: {_id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ItemContasAReceber), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
    }
}