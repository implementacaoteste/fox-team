using BLL;
using Infra;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormaPagamentoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(FormaPagamento _formaPagamento)
        {
            string erro;
            if (_formaPagamento == null)
            {
                erro = Texto.Verbose(nameof(FormaPagamento), Mensagem.EntidadeNula);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}");
                return BadRequest(erro);
            }

            try
            {
                new FormaPagamentoBLL().Inserir(_formaPagamento);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _formaPagamento.Id }, _formaPagamento);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(FormaPagamento), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            Log.GravarLog($"Buscando todos os registros de {Texto.Verbose(nameof(FormaPagamento)).ToLower()}.");
            string erro;
            try
            {
                var formaPagamentoList = new FormaPagamentoBLL().BuscarTodos();

                if (formaPagamentoList == null || formaPagamentoList.Count == 0)
                {
                    erro = Texto.Verbose(nameof(FormaPagamento), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(formaPagamentoList)}");
                return Ok(formaPagamentoList);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(FormaPagamento), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            Log.GravarLog($"Buscando registro de {Texto.Verbose(nameof(FormaPagamento)).ToLower()} por id: {_id}");
            string erro;
            try
            {
                var formaPagamento = new FormaPagamentoBLL().BuscarPorId(_id);

                if (formaPagamento == null)
                {
                    erro = Texto.Verbose(nameof(FormaPagamento), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(formaPagamento)}");
                return Ok(formaPagamento);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(FormaPagamento), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, FormaPagamento _formaPagamento)
        {
            Log.GravarLog($"Alterando registro de {Texto.Verbose(nameof(FormaPagamento))}: {JsonConvert.SerializeObject(_formaPagamento)}");
            string erro;
            try
            {
                new FormaPagamentoBLL().Alterar(_formaPagamento);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(FormaPagamento))} alterado com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(FormaPagamento), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            Log.GravarLog($"Excluindo registro de {Texto.Verbose(nameof(FormaPagamento))}: {_id}");
            string erro;
            try
            {
                new FormaPagamentoBLL().Excluir(_id);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(FormaPagamento))} excluído com sucesso: {_id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(FormaPagamento), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
    }
}