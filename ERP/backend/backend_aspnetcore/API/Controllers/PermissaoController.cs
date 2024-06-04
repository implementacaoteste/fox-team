using BLL;
using Infra;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissaoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(Permissao _permissao)
        {
            string erro;
            if (_permissao == null)
            {
                erro = Texto.Verbose(nameof(Permissao), Mensagem.EntidadeNula);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}");
                return BadRequest(erro);
            }

            try
            {
                new PermissaoBLL().Inserir(_permissao);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _permissao.Id }, _permissao);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Permissao), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            Log.GravarLog($"Buscando todos os registros de {Texto.Verbose(nameof(Permissao)).ToLower()}.");
            string erro;
            try
            {
                var permissaoList = new PermissaoBLL().BuscarTodos();

                if (permissaoList == null || permissaoList.Count == 0)
                {
                    erro = Texto.Verbose(nameof(Permissao), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(permissaoList)}");
                return Ok(permissaoList);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Permissao), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            Log.GravarLog($"Buscando registro de {Texto.Verbose(nameof(Permissao)).ToLower()} por id: {_id}");
            string erro;
            try
            {
                var permissao = new PermissaoBLL().BuscarPorId(_id);

                if (permissao == null)
                {
                    erro = Texto.Verbose(nameof(Permissao), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(permissao)}");
                return Ok(permissao);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Permissao), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, Permissao _permissao)
        {
            Log.GravarLog($"Alterando registro de {Texto.Verbose(nameof(Permissao))}: {JsonConvert.SerializeObject(_permissao)}");
            string erro;
            try
            {
                new PermissaoBLL().Alterar(_permissao);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(Permissao))} alterado com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Permissao), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            Log.GravarLog($"Excluindo registro de {Texto.Verbose(nameof(Permissao))}: {_id}");
            string erro;
            try
            {
                new PermissaoBLL().Excluir(_id);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(Permissao))} excluído com sucesso: {_id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Permissao), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
    }
}