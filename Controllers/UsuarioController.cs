using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZAlert.Api.Application.DTOs;
using ZAlert.Api.Application.Services;

namespace ZAlert.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDto dto)
        {
            var usuario = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = usuario.IdUsu }, usuario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _service.BuscarPorIdAsync(id);
            return Ok(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _service.ListarAsync(0, 50);
            return Ok(usuarios);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletarAsync(id);
            return NoContent();
        }
    }
}
