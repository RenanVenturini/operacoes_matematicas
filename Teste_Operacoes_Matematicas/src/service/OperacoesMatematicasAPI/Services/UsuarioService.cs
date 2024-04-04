using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using OperacoesMatematicasAPI.Data.Interfaces;
using OperacoesMatematicasAPI.Data.Table;
using OperacoesMatematicasAPI.Models.Request;
using OperacoesMatematicasAPI.Models.Response;
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
        public async Task<UsuarioResponse> UsuarioPorIdAsync(int id)
        {
            var usuario = await _repository.UsuarioPorIdAsync(id);
            return _mapper.Map<UsuarioResponse>(usuario);
        }
        public async Task AtualizarUsuarioAsync(AtualizarUsuarioRequest atualizarUsuarioRequest)
        {
            var usuario = _mapper.Map<TbUsuario>(atualizarUsuarioRequest);
            await _repository.AtualizarUsuarioAsync(usuario);
        }

        public async Task DeletarUsuarioAsync(int id)
        {
            var usuario = await _repository.UsuarioPorIdAsync(id);
            await _repository.DeletarUsuarioAsync(usuario);
        }

        public async Task<TbUsuario> ObterPorEmailSenhaAsync(string email, string senha)
        {
            var usuario = await _repository.ObterPorEmailSenhaAsync(email, senha);
            return usuario;
        }

        public async Task<string> GerarTokenAsync(TbUsuario usuario)
        {
            return await Task.Run(() =>
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim("Calcular", "true")
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Issuer = "OperacoesMatematicasAPI",
                    Audience = "OperacoesMatematicasAPI",
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("chave-secreta-api")),
                        SecurityAlgorithms.HmacSha256)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            });
        }
    }
}
