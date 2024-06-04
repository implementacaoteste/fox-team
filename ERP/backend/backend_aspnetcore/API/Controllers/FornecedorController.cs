using BLL;
using Infra;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {
        [HttpPost]
        public IActionResult Inserir(Fornecedor _fornecedor)
        {
            string erro;
            if (_fornecedor == null)
            {
                erro = Texto.Verbose(nameof(Fornecedor), Mensagem.EntidadeNula);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}");
                return BadRequest(erro);
            }

            try
            {
                new FornecedorBLL().Inserir(_fornecedor);
                return CreatedAtAction(nameof(BuscarPorId), new { _id = _fornecedor.Id }, _fornecedor);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Fornecedor), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            Log.GravarLog($"Buscando todos os registros de {Texto.Verbose(nameof(Fornecedor)).ToLower()}.");
            string erro;
            try
            {
                var fornecedorList = new FornecedorBLL().BuscarTodos();

                if (fornecedorList == null || fornecedorList.Count == 0)
                {
                    erro = Texto.Verbose(nameof(Fornecedor), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(fornecedorList)}");
                return Ok(fornecedorList);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Fornecedor), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpGet("{_id}")]
        public IActionResult BuscarPorId(int _id)
        {
            Log.GravarLog($"Buscando registro de {Texto.Verbose(nameof(Fornecedor)).ToLower()} por id: {_id}");
            string erro;
            try
            {
                var fornecedor = new FornecedorBLL().BuscarPorId(_id);

                if (fornecedor == null)
                {
                    erro = Texto.Verbose(nameof(Fornecedor), Mensagem.NaoEncontrado);
                    return NotFound(erro);
                }
                Log.GravarLog($"Resultado: {JsonConvert.SerializeObject(fornecedor)}");
                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Fornecedor), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpPut("{_id}")]
        public IActionResult Alterar(int _id, Fornecedor _fornecedor)
        {
            Log.GravarLog($"Alterando registro de {Texto.Verbose(nameof(Fornecedor))}: {JsonConvert.SerializeObject(_fornecedor)}");
            string erro;
            try
            {
                new FornecedorBLL().Alterar(_fornecedor);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(Fornecedor))} alterado com sucesso.");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Fornecedor), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
        [HttpDelete("{_id}")]
        public IActionResult Excluir(int _id)
        {
            Log.GravarLog($"Excluindo registro de {Texto.Verbose(nameof(Fornecedor))}: {_id}");
            string erro;
            try
            {
                new FornecedorBLL().Excluir(_id);
                Log.GravarLog($"Registro de {Texto.Verbose(nameof(Fornecedor))} excluído com sucesso: {_id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                erro = Texto.Verbose(nameof(Fornecedor), Mensagem.Erro500);
                Log.GravarLog($"Erro: {this.GetType().Name} | {erro}: {ex.Message}");
                return StatusCode(500, $"{erro}");
            }
        }
    }
}