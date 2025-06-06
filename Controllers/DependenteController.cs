using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZAlert.Api.Application.DTOs;
using ZAlert.Api.Application.Services;

namespace ZAlert.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DependenteController : ControllerBase
    {
        private readonly DependenteService _service;

        public DependenteController(DependenteService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DependenteDto dto)
        {
            var dependente = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dependente.IdDepen }, dependente);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dependente = await _service.BuscarPorIdAsync(id);
            return Ok(dependente);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dependentes = await _service.ListarAsync(0, 50);
            return Ok(dependentes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletarAsync(id);
            return NoContent();
        }
    }
}