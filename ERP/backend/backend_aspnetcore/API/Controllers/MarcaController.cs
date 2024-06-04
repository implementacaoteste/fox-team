using BLL;
using Infra;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarcaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(Marca _marca)
        {
            string erro;
            if (_marca == null)
            {
                erro = Texto.Verbose(nameof(Marca), Mensagem.EntidadeNula);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}");
                return BadRequest(erro);
            }

            try
            {
                new MarcaBLL().Inserir(_marca);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _marca.Id }, _marca);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Marca), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            Log.GravarLog($"Buscando todos os registros de {Texto.Verbose(nameof(Marca)).ToLower()}.");
            string erro;
            try
            {
                var marcaList = new MarcaBLL().BuscarTodos();

                if (marcaList == null || marcaList.Count == 0)
                {
                    erro = Texto.Verbose(nameof(Marca), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(marcaList)}");
                return Ok(marcaList);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Marca), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            Log.GravarLog($"Buscando registro de {Texto.Verbose(nameof(Marca)).ToLower()} por id: {_id}");
            string erro;
            try
            {
                var marca = new MarcaBLL().BuscarPorId(_id);

                if (marca == null)
                {
                    erro = Texto.Verbose(nameof(Marca), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(marca)}");
                return Ok(marca);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Marca), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, Marca _marca)
        {
            Log.GravarLog($"Alterando registro de {Texto.Verbose(nameof(Marca))}: {JsonConvert.SerializeObject(_marca)}");
            string erro;
            try
            {
                new MarcaBLL().Alterar(_marca);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(Marca))} alterado com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Marca), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            Log.GravarLog($"Excluindo registro de {Texto.Verbose(nameof(Marca))}: {_id}");
            string erro;
            try
            {
                new MarcaBLL().Excluir(_id);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(Marca))} excluído com sucesso: {_id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Marca), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
    }
}