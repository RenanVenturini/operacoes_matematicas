using Microsoft.AspNetCore.Mvc;
using OperacoesMatematicasAPI.Data.Interfaces;
using OperacoesMatematicasAPI.Models.Request;

namespace OperacoesMatematicasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarUsuarioAsync(UsuarioRequest usuarioRequest)
        {
            await _usuarioService.AdicionarUsuarioAsync(usuarioRequest);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
