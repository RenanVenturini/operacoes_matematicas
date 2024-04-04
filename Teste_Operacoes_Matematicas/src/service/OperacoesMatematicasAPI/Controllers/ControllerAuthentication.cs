using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OperacoesMatematicasAPI.Data.Interfaces;
using OperacoesMatematicasAPI.Data.Table;
using OperacoesMatematicasAPI.Models.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OperacoesMatematicasAPI.ControllerAuthentication
{
    [ApiController]
    [Route("[controller]")]
    public class ControllerAuthentication : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public ControllerAuthentication(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            // Obtenha o usuário por email e senha
            var usuario = await _usuarioService.ObterPorEmailSenhaAsync(login.Username, login.Senha);

            if (usuario == null)
            {
                return Unauthorized();
            }

            // Gere o token com claims baseadas no usuário
            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
        new Claim(ClaimTypes.Email, usuario.Email),
        // Adicione outras claims se necessário, por exemplo, baseadas em roles do usuário
      };

            var token = new JwtSecurityToken(
              issuer: "localhost",
              audience: "localhost",
              claims: claims,
              expires: DateTime.UtcNow.AddMinutes(10),
              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my-secret-key")), SecurityAlgorithms.HmacSha256)
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        [Authorize(Policy = "User")]
        [HttpGet]
        [Route("math")]
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
