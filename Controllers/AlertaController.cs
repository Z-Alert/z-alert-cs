using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZAlert.Api.Application.DTOs;
using ZAlert.Api.Application.Services;

namespace ZAlert.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertaController : ControllerBase
    {
        private readonly AlertaService _service;

        public AlertaController(AlertaService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlertaDto dto)
        {
            var alerta = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = alerta.IdAlerta }, alerta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var alerta = await _service.BuscarPorIdAsync(id);
            return Ok(alerta);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alertas = await _service.ListarAsync(0, 50);
            return Ok(alertas);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletarAsync(id);
            return NoContent();
        }
    }
}