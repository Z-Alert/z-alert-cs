using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZAlert.Api.Application.DTOs;
using ZAlert.Api.Application.Services;

namespace ZAlert.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalizacaoController : ControllerBase
    {
        private readonly LocalizacaoService _service;

        public LocalizacaoController(LocalizacaoService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LocalizacaoDto dto)
        {
            var localizacao = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = localizacao.IdLocali }, localizacao);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var localizacao = await _service.BuscarPorIdAsync(id);
            return Ok(localizacao);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var localizacoes = await _service.ListarAsync(0, 50);
            return Ok(localizacoes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletarAsync(id);
            return NoContent();
        }
    }
}