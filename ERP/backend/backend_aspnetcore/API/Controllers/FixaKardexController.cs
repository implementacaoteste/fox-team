using BLL;
using Infra;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FixaKardexController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(FixaKardex _fixaKardex)
        {
            string erro;
            if (_fixaKardex == null)
            {
                erro = Texto.Verbose(nameof(FixaKardex), Mensagem.EntidadeNula);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}");
                return BadRequest(erro);
            }

            try
            {
                new FixaKardexBLL().Inserir(_fixaKardex);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _fixaKardex.Id }, _fixaKardex);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(FixaKardex), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            Log.GravarLog($"Buscando todos os registros de {Texto.Verbose(nameof(FixaKardex)).ToLower()}.");
            string erro;
            try
            {
                var fixaKardexList = new FixaKardexBLL().BuscarTodos();

                if (fixaKardexList == null || fixaKardexList.Count == 0)
                {
                    erro = Texto.Verbose(nameof(FixaKardex), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(fixaKardexList)}");
                return Ok(fixaKardexList);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(FixaKardex), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            Log.GravarLog($"Buscando registro de {Texto.Verbose(nameof(FixaKardex)).ToLower()} por id: {_id}");
            string erro;
            try
            {
                var fixaKardex = new FixaKardexBLL().BuscarPorId(_id);

                if (fixaKardex == null)
                {
                    erro = Texto.Verbose(nameof(FixaKardex), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(fixaKardex)}");
                return Ok(fixaKardex);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(FixaKardex), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, FixaKardex _fixaKardex)
        {
            Log.GravarLog($"Alterando registro de {Texto.Verbose(nameof(FixaKardex))}: {JsonConvert.SerializeObject(_fixaKardex)}");
            string erro;
            try
            {
                new FixaKardexBLL().Alterar(_fixaKardex);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(FixaKardex))} alterado com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(FixaKardex), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            Log.GravarLog($"Excluindo registro de {Texto.Verbose(nameof(FixaKardex))}: {_id}");
            string erro;
            try
            {
                new FixaKardexBLL().Excluir(_id);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(FixaKardex))} excluído com sucesso: {_id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(FixaKardex), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
    }
}