using BLL;
using Infra;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(Venda _venda)
        {
            string erro;
            if (_venda == null)
            {
                erro = Texto.Verbose(nameof(Venda), Mensagem.EntidadeNula);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}");
                return BadRequest(erro);
            }

            try
            {
                new VendaBLL().Inserir(_venda);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _venda.Id }, _venda);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Venda), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            Log.GravarLog($"Buscando todos os registros de {Texto.Verbose(nameof(Venda)).ToLower()}.");
            string erro;
            try
            {
                var vendaList = new VendaBLL().BuscarTodos();

                if (vendaList == null || vendaList.Count == 0)
                {
                    erro = Texto.Verbose(nameof(Venda), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(vendaList)}");
                return Ok(vendaList);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Venda), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            Log.GravarLog($"Buscando registro de {Texto.Verbose(nameof(Venda)).ToLower()} por id: {_id}");
            string erro;
            try
            {
                var venda = new VendaBLL().BuscarPorId(_id);

                if (venda == null)
                {
                    erro = Texto.Verbose(nameof(Venda), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(venda)}");
                return Ok(venda);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Venda), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, Venda _venda)
        {
            Log.GravarLog($"Alterando registro de {Texto.Verbose(nameof(Venda))}: {JsonConvert.SerializeObject(_venda)}");
            string erro;
            try
            {
                new VendaBLL().Alterar(_venda);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(Venda))} alterado com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Venda), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            Log.GravarLog($"Excluindo registro de {Texto.Verbose(nameof(Venda))}: {_id}");
            string erro;
            try
            {
                new VendaBLL().Excluir(_id);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(Venda))} excluído com sucesso: {_id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Venda), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
    }
}