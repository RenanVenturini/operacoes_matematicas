using AutoMapper;
using OperacoesMatematicasAPI.Data.Table;
using OperacoesMatematicasAPI.Models.Request;
using OperacoesMatematicasAPI.Models.Response;

namespace OperacoesMatematicasAPI.Data.Mappings_Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioRequest, TbUsuario>();
            CreateMap<AtualizarUsuarioRequest, TbUsuario>();
            CreateMap<TbUsuario, UsuarioResponse>();
        }
    }
}
