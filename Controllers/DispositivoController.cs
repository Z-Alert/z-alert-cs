using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZAlert.Api.Application.DTOs;
using ZAlert.Api.Application.Services;

namespace ZAlert.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DispositivoController : ControllerBase
    {
        private readonly DispositivoService _service;

        public DispositivoController(DispositivoService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DispositivoDto dto)
        {
            var dispositivo = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dispositivo.IdDisposit }, dispositivo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dispositivo = await _service.BuscarPorIdAsync(id);
            return Ok(dispositivo);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dispositivos = await _service.ListarAsync(0, 50);
            return Ok(dispositivos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletarAsync(id);
            return NoContent();
        }
    }
}