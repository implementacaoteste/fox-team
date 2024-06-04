using BLL;
using Infra;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContasAPagarController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(ContasAPagar _contasAPagar)
        {
            string erro;
            if (_contasAPagar == null)
            {
                erro = Texto.Verbose(nameof(ContasAPagar), Mensagem.EntidadeNula);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}");
                return BadRequest(erro);
            }

            try
            {
                new ContasAPagarBLL().Inserir(_contasAPagar);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _contasAPagar.Id }, _contasAPagar);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ContasAPagar), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            Log.GravarLog($"Buscando todos os registros de {Texto.Verbose(nameof(ContasAPagar)).ToLower()}.");
            string erro;
            try
            {
                var contasAPagarList = new ContasAPagarBLL().BuscarTodos();

                if (contasAPagarList == null || contasAPagarList.Count == 0)
                {
                    erro = Texto.Verbose(nameof(ContasAPagar), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(contasAPagarList)}");
                return Ok(contasAPagarList);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ContasAPagar), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            Log.GravarLog($"Buscando registro de {Texto.Verbose(nameof(ContasAPagar)).ToLower()} por id: {_id}");
            string erro;
            try
            {
                var contasAPagar = new ContasAPagarBLL().BuscarPorId(_id);

                if (contasAPagar == null)
                {
                    erro = Texto.Verbose(nameof(ContasAPagar), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(contasAPagar)}");
                return Ok(contasAPagar);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ContasAPagar), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, ContasAPagar _contasAPagar)
        {
            Log.GravarLog($"Alterando registro de {Texto.Verbose(nameof(ContasAPagar))}: {JsonConvert.SerializeObject(_contasAPagar)}");
            string erro;
            try
            {
                new ContasAPagarBLL().Alterar(_contasAPagar);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(ContasAPagar))} alterado com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ContasAPagar), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            Log.GravarLog($"Excluindo registro de {Texto.Verbose(nameof(ContasAPagar))}: {_id}");
            string erro;
            try
            {
                new ContasAPagarBLL().Excluir(_id);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(ContasAPagar))} excluído com sucesso: {_id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ContasAPagar), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
    }
}