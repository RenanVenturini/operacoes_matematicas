using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OperacoesMatematicasAPI.Data.Interfaces;
using OperacoesMatematicasAPI.Data.Table;
using OperacoesMatematicasAPI.Models.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OperacoesMatematicasAPI.CalcularController
{
    [ApiController]
    [Route("[controller]")]
    public class CalcularController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public CalcularController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize]
        [HttpPost]
        [Route("calcular")]
        public IActionResult Calcular([FromQuery] double valor1, [FromQuery] double valor2, [FromQuery] string operacao)
        {
            double resultado = 0;

            switch (operacao)
            {
                case "adicao":
                    resultado = valor1 + valor2;
                    break;
                case "subtracao":
                    resultado = valor1 - valor2;
                    break;
                case "multiplicacao":
                    resultado = valor1 * valor2;
                    break;
                case "divisao":
                    resultado = valor1 / valor2;
                    break;
            }

            return Ok(new { resultado });
        }
    }
}
