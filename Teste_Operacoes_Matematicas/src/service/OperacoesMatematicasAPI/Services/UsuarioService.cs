using AutoMapper;
using OperacoesMatematicasAPI.Data.Interfaces;
using OperacoesMatematicasAPI.Data.Table;
using OperacoesMatematicasAPI.Models.Request;
using OperacoesMatematicasAPI.Models.Response;

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
    }
}
