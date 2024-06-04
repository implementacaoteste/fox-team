using BLL;
using Infra;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContasAReceberController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(ContasAReceber _cntasAReceber)
        {
            string erro;
            if (_cntasAReceber == null)
            {
                erro = Texto.Verbose(nameof(ContasAReceber), Mensagem.EntidadeNula);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}");
                return BadRequest(erro);
            }

            try
            {
                new ContasAReceberBLL().Inserir(_cntasAReceber);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _cntasAReceber.Id }, _cntasAReceber);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ContasAReceber), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            Log.GravarLog($"Buscando todos os registros de {Texto.Verbose(nameof(ContasAReceber)).ToLower()}.");
            string erro;
            try
            {
                var cntasAReceberList = new ContasAReceberBLL().BuscarTodos();

                if (cntasAReceberList == null || cntasAReceberList.Count == 0)
                {
                    erro = Texto.Verbose(nameof(ContasAReceber), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(cntasAReceberList)}");
                return Ok(cntasAReceberList);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ContasAReceber), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            Log.GravarLog($"Buscando registro de {Texto.Verbose(nameof(ContasAReceber)).ToLower()} por id: {_id}");
            string erro;
            try
            {
                var cntasAReceber = new ContasAReceberBLL().BuscarPorId(_id);

                if (cntasAReceber == null)
                {
                    erro = Texto.Verbose(nameof(ContasAReceber), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(cntasAReceber)}");
                return Ok(cntasAReceber);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ContasAReceber), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, ContasAReceber _cntasAReceber)
        {
            Log.GravarLog($"Alterando registro de {Texto.Verbose(nameof(ContasAReceber))}: {JsonConvert.SerializeObject(_cntasAReceber)}");
            string erro;
            try
            {
                new ContasAReceberBLL().Alterar(_cntasAReceber);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(ContasAReceber))} alterado com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ContasAReceber), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            Log.GravarLog($"Excluindo registro de {Texto.Verbose(nameof(ContasAReceber))}: {_id}");
            string erro;
            try
            {
                new ContasAReceberBLL().Excluir(_id);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(ContasAReceber))} excluído com sucesso: {_id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(ContasAReceber), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
    }
}