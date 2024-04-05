using AutoMapper;
using OperacoesMatematicasAPI.Data.Table;
using OperacoesMatematicasAPI.Models.Request;

namespace OperacoesMatematicasAPI.Data.Mappings_Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioRequest, TbUsuario>();
        }
    }
}
