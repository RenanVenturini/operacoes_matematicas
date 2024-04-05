using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using OperacoesMatematicasAPI.Data.Interfaces;
using OperacoesMatematicasAPI.Data.Table;
using OperacoesMatematicasAPI.Models.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OperacoesMatematicasAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AdicionarUsuarioAsync(UsuarioRequest usuarioRequest)
        {
            var usuario = _mapper.Map<TbUsuario>(usuarioRequest);
            await _repository.AdicionarUsuarioAsync(usuario);
        }

        public async Task<Token> AutenticarAsync(Login login)
        {
            var usuario = await _repository.ObterUsuarioAsync(login.Username, login.Senha);

            if (usuario == null)
            {
                throw new Exception("Usuario ou Senha Invalido");
            }

            return GerarTokenAsync(usuario);
        }

        public Token GerarTokenAsync(TbUsuario usuario)
        {

            var claims = new[]
               {
                    new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                };

            var key = Encoding.ASCII.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNjQ0NTEyMzQ1fQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c\r\n");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = "OperacoesMatematicasAPI",
                Audience = "OperacoesMatematicasAPI",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

                Expires = DateTime.UtcNow.AddMinutes(30),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new Token
            {
                TokenJwt = tokenHandler.WriteToken(token),
                DataExpiracao = token.ValidFrom,
            };
        }
    }
}
